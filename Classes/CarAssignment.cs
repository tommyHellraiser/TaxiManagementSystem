using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxiManagementSystem.Classes;

namespace TaxiManagement.Classes
{
	public class CarAssignment
	{
		public int id { get; set; }
		public int? car_id { get; set; }
		public string? car_brand { get; set; }
		public string? car_model { get; set; }
		public string? car_plate { get; set; }
		public int? driver_id { get; set; }
		public string? driver_name { get; set; }
		public string? driver_last_name { get; set; }
		public string? driver_document { get; set; }

		internal CarAssignment(int id, int car_id, string car_brand, string car_model, string car_plate, int driver_id, string driver_name, string driver_last_name, string driver_document)
		{
			this.id = id;
			this.car_id = car_id;
			this.car_brand = car_brand;
			this.car_model = car_model;
			this.car_plate = car_plate;
			this.driver_id = driver_id;
			this.driver_name = driver_name;
			this.driver_last_name = driver_last_name;
			this.driver_document = driver_document;
		}

		#region Database Methods

		internal static List<CarAssignment> SelectAll(SqlConnection conn)
		{
			List<CarAssignment> list = new List<CarAssignment>();

			string query = "SELECT ca.ID, ca.car_ID, c.brand, c.model, c.license_plate, ca.driver_ID, d.name, d.last_name, d.document " +
				"FROM car_assignments AS ca " +
				"LEFT JOIN cars AS c " +
				"ON ca.car_ID = c.ID " +
				"LEFT JOIN drivers AS d " +
				"ON ca.driver_ID = d.ID;";
			SqlCommand cmd = new SqlCommand(query, conn);
			SqlDataReader reader = cmd.ExecuteReader();

			while (reader.Read())
			{
				CarAssignment assignment = new CarAssignment(
					reader.GetInt32(0),
					reader.GetInt32(1),
					reader.GetString(2),
					reader.GetString(3),
					reader.GetString(4),
					reader.GetInt32(5),
					reader.GetString(6),
					reader.GetString(7),
					reader.GetString(8)
				);

				list.Add(assignment);
			}

			reader.Close();

			return list;
		}

		internal static bool IsPlateAssigned(SqlConnection conn, string plate)
		{
			bool assigned = true;

			string query = "SELECT c.ID " +
				"FROM car_assignments as ca " +
				"LEFT JOIN cars as c " +
				"ON ca.car_ID = c.ID " +
				"WHERE c.license_plate = @plate;";
			SqlCommand cmd = new SqlCommand(query, conn);
			cmd.Parameters.AddWithValue("@plate", plate);

			SqlDataReader reader = cmd.ExecuteReader();

			if (reader.Read())
			{
				if (reader.GetInt32(0) != 0)
				{
					assigned = true;
				}
				else
				{
					assigned = false;
				}
			}
			else
			{
				assigned = false;
			}

			reader.Close();

			return assigned;
		}

		internal void AssignCarToDriver(SqlConnection conn)
		{
			string query = "INSERT INTO car_assignments(car_ID, driver_ID) " +
				"VALUES(@car_id, @driver_id);" +
				"SELECT SCOPE_IDENTITY();";
			SqlCommand cmd = new SqlCommand(query, conn);
			cmd.Parameters.AddWithValue("@car_id", this.car_id);
			cmd.Parameters.AddWithValue("@driver_id", this.driver_id);

			var id = cmd.ExecuteScalar();

			if (id == null)
			{
				throw new SqlNullValueException("Null value when scoping IDENTITY");
			}

			this.id = Convert.ToInt32(id);
		}

		internal static CarAssignment? FromDriverDocument(SqlConnection conn, string document)
		{
			CarAssignment? assignment = null;

			string query = "SELECT ca.ID, ca.car_ID, c.brand, c.model, c.license_plate, ca.driver_ID, d.name, d.last_name, d.document " +
				"FROM car_assignments AS ca " +
				"LEFT JOIN cars AS c " +
				"ON ca.car_ID = c.ID " +
				"LEFT JOIN drivers AS d " +
				"ON ca.driver_ID = d.ID " +
				"WHERE d.document = @document;";
			SqlCommand cmd = new SqlCommand(query, conn);
			cmd.Parameters.AddWithValue("@document", document);
			SqlDataReader reader = cmd.ExecuteReader();

			if (reader.Read())
			{
				assignment = new CarAssignment(
					reader.GetInt32(0),
					reader.GetInt32(1),
					reader.GetString(2),
					reader.GetString(3),
					reader.GetString(4),
					reader.GetInt32(5),
					reader.GetString(6),
					reader.GetString(7),
					reader.GetString(8)
				);
			}

			reader.Close();

			return assignment;
		}

		#endregion
	}
}
