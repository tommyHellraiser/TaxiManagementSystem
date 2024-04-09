using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlTypes;
using System.Data;

namespace TaxiManagementSystem.Classes
{
	internal class Car
	{
		public int? id { get; set; }
		public string? brand { get; set; }
		public string? model { get; set; }
		public int year { get; set; }
		public string? license_plate { get; set; }
		public double hourly_rate { get; set; }
		public bool is_replacement { get; set; }
		public bool is_in_fleet { get; set; }
		public bool is_in_garage { get; set; }

		internal Car(string brand, string model, int year, string license_plate, double hourly_rate, bool is_replacement)
		{
			this.id = null;
			this.brand = brand;
			this.model = model;
			this.year = year;
			this.license_plate = license_plate;
			this.hourly_rate = hourly_rate;
			this.is_replacement = is_replacement;
		}


		#region Database Methods
		internal static Car? FromID(SqlConnection conn, int id)
		{
			string query = "SELECT * FROM cars WHERE ID = @car_ID AND is_in_fleet = 1;";

			SqlCommand cmd = new SqlCommand(query, conn);
			cmd.Parameters.AddWithValue("@car_ID", id);

			SqlDataReader reader = cmd.ExecuteReader();

			//	If a match was found, return only the first occurence. It should be the only one
			Car? car = null;
			if (reader.Read())
			{
				car = new Car
				(
					(string)reader.GetSqlString(1),
					(string)reader.GetSqlString(2),
					(int)reader.GetSqlInt32(3),
					(string)reader.GetString(4),
					(double)reader.GetDouble(5),
					(bool)reader.GetSqlBoolean(6)
				);
				car.id = (int)reader.GetSqlInt32(0);
				car.is_in_fleet = (bool)reader.GetSqlBoolean(7);

			}

			reader.Close();

			return car;
		}

		internal static Car? FromIDUnfiltered(SqlConnection conn, int id)
		{
			string query = "SELECT * FROM cars WHERE ID = @car_ID;";

			SqlCommand cmd = new SqlCommand(query, conn);
			cmd.Parameters.AddWithValue("@car_ID", id);

			SqlDataReader reader = cmd.ExecuteReader();

			//	If a match was found, return only the first occurence. It should be the only one
			Car? car = null;
			if (reader.Read())
			{
				car = new Car
				(
					(string)reader.GetSqlString(1),
					(string)reader.GetSqlString(2),
					(int)reader.GetSqlInt32(3),
					(string)reader.GetString(4),
					(double)reader.GetDouble(5),
					(bool)reader.GetSqlBoolean(6)
				);
				car.id = (int)reader.GetSqlInt32(0);
				car.is_in_fleet = (bool)reader.GetSqlBoolean(7);

			}

			reader.Close();

			return car;
		}

		internal static Car? FromlicensePlate(SqlConnection conn, string license_plate)
		{
			string query = "SELECT * FROM cars WHERE license_plate = @plate AND is_in_fleet = 1";
			SqlCommand cmd = new SqlCommand(query, conn);

			cmd.Parameters.AddWithValue("@plate", license_plate);

			SqlDataReader reader = cmd.ExecuteReader();

			Car? car = null;
			if (reader.Read())
			{
				car = new Car(
					reader.GetString(1),
					reader.GetString(2),
					reader.GetInt32(3),
					reader.GetString(4),
					reader.GetDouble(5),
					reader.GetBoolean(6)
				);
				car.id = reader.GetInt32(0);
				car.is_in_fleet = reader.GetBoolean(7);
				car.is_in_garage = reader.GetBoolean(8);
			}

			reader.Close();

			return car;
		}

		internal static Car? FromlicensePlateUnfiltered(SqlConnection conn, string license_plate)
		{
			string query = "SELECT * FROM cars WHERE license_plate = @plate";
			SqlCommand cmd = new SqlCommand(query, conn);

			cmd.Parameters.AddWithValue("@plate", license_plate);

			SqlDataReader reader = cmd.ExecuteReader();

			Car? car = null;
			if (reader.Read())
			{
				car = new Car(
					reader.GetString(1),
					reader.GetString(2),
					reader.GetInt32(3),
					reader.GetString(4),
					reader.GetDouble(5),
					reader.GetBoolean(6)
				);
				car.id = reader.GetInt32(0);
				car.is_in_fleet = reader.GetBoolean(7);
				car.is_in_garage = reader.GetBoolean(8);
			}

			reader.Close();

			return car;
		}

		internal static Car? FromDriverDocument(SqlConnection conn, string document)
		{
			string query = "SELECT c.* " +
				"FROM car_assignments as ca " +
				"LEFT JOIN cars as c " +
				"ON ca.car_ID = c.ID " +
				"LEFT JOIN drivers as d " +
				"ON ca.driver_ID = d.ID " +
				"WHERE d.document = @document;";
			SqlCommand cmd = new SqlCommand(query, conn);
			cmd.Parameters.AddWithValue("@document", document);
			SqlDataReader reader = cmd.ExecuteReader();

			Car? car = null;
			if (reader.Read())
			{
				car = new Car(
					reader.GetString(1),
					reader.GetString(2),
					reader.GetInt32(3),
					reader.GetString(4),
					reader.GetDouble(5),
					reader.GetBoolean(6)
				);
				car.id = reader.GetInt32(0);
				car.is_in_fleet = reader.GetBoolean(7);
				car.is_in_garage = reader.GetBoolean(8);
			}

			reader.Close();

			return car;
		}

		internal void AddToFleet(SqlConnection conn)
		{
			int is_replacement = (this.is_replacement == true) ? 1 : 0;

			string query = "INSERT INTO cars(brand, model, year, license_plate, hourly_rate, is_replacement)" +
				"VALUES(@brand, @model, @year, @license_plate, @hourly_rate, @is_replacement)" + 
				"SELECT SCOPE_IDENTITY()";

			SqlCommand cmd = new SqlCommand(query, conn);

			cmd.Parameters.AddWithValue("@brand", this.brand);
			cmd.Parameters.AddWithValue("@model", this.model);
			cmd.Parameters.AddWithValue("@year", this.year);
			cmd.Parameters.AddWithValue("@license_plate", this.license_plate);
			cmd.Parameters.AddWithValue("@hourly_rate", this.hourly_rate);
			cmd.Parameters.AddWithValue("@is_replacement", this.is_replacement);

			//	Executes query, returns false if affected rows was <= 0
			var id = cmd.ExecuteScalar();

			if (id == null)
			{
				throw new SqlNullValueException("Null value when scoping IDENTITY");
			}

			this.id = Convert.ToInt32(id);
		}

		internal bool MarkAsDeleted(SqlConnection conn)
		{
			string query = "UPDATE cars SET is_in_fleet = 0 WHERE ID = @car_ID";
			SqlCommand cmd = new SqlCommand(query, conn);

			cmd.Parameters.AddWithValue("@car_ID", this.id);

			return cmd.ExecuteNonQuery() > 0;
		}

		internal bool RestoreToFleet(SqlConnection conn)
		{
			string query = "UPDATE cars SET is_in_fleet = 1 WHERE ID = @car_ID";
			SqlCommand cmd = new SqlCommand(query, conn);

			cmd.Parameters.AddWithValue("@car_ID", this.id);

			return cmd.ExecuteNonQuery() > 0;
		}

		internal static List<Car> SelectAllInFleet(SqlConnection conn)
		{
			string query = "SELECT * FROM cars WHERE is_in_fleet = 1";
			SqlCommand cmd = new SqlCommand(query, conn);

			SqlDataReader reader = cmd.ExecuteReader();

			List<Car> car_list = new List<Car>();

			while (reader.Read())
			{
				Car car = new Car(
					reader.GetString(1),
					reader.GetString(2),
					reader.GetInt32(3),
					reader.GetString(4),
					reader.GetDouble(5),
					reader.GetBoolean(6)
				);
				car.id = reader.GetInt32(0);
				car.is_in_fleet = reader.GetBoolean(7);
				car.is_in_garage = reader.GetBoolean(8);

				car_list.Add(car);
			}

			reader.Close();

			return car_list;
		}

		internal static bool DoesLicensePlateExist(SqlConnection conn, string license_plate)
		{
			string query = "SELECT ID FROM cars WHERE license_plate = @plate;";
			SqlCommand cmd = new SqlCommand(query, conn);

			cmd.Parameters.AddWithValue("@plate", license_plate);
			SqlDataReader reader = cmd.ExecuteReader();

			bool taken = true;

			if (reader.Read())
			{
				if (reader.GetInt32(0) != 0)
				{
					taken = true;
				}
				else
				{
					taken = false;
				}
			}
			else
			{
				taken = false;
			}

			reader.Close();

			return taken;
		}

		internal void MarkAsNotInGarage(SqlConnection conn)
		{
			string query = "UPDATE cars SET is_in_garage = 0 WHERE ID = @car_id;";
			SqlCommand cmd = new SqlCommand(query, conn);
			cmd.Parameters.AddWithValue("@car_id", this.id);

			int ar = cmd.ExecuteNonQuery();

			if (ar <= 0)
			{
				throw new SqlNotFilledException("No registries were updated in repaid end query");
			}
		}

		internal void MarkAsInGarage(SqlConnection conn)
		{
			string query = "UPDATE cars SET is_in_garage = 1 WHERE ID = @car_id;";
			SqlCommand cmd = new SqlCommand(query, conn);
			cmd.Parameters.AddWithValue("@car_id", this.id);

			int ar = cmd.ExecuteNonQuery();

			if (ar <= 0)
			{
				throw new SqlNotFilledException("No registries were updated in repaid end query");
			}
		}

		internal static Car? SelectFirstReplacementOccurence(SqlConnection conn)
		{
			Car? car = null;

			string query = "SELECT TOP 1 * FROM cars WHERE is_replacement = 1 AND is_in_garage = 1;";
			SqlCommand cmd = new SqlCommand(query, conn);
			SqlDataReader reader = cmd.ExecuteReader();

			if (reader.Read())
			{
				car = new Car(
					reader.GetString(1),
					reader.GetString(2),
					reader.GetInt32(3),
					reader.GetString(4),
					reader.GetDouble(5),
					reader.GetBoolean(6)
				);
				car.id = reader.GetInt32(0);
				car.is_in_fleet = reader.GetBoolean(7);
				car.is_in_garage = reader.GetBoolean(8);
			}

			reader.Close();

			return car;
		}

		#endregion
	}
}
