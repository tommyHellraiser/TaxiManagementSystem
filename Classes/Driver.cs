using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxiManagementSystem.Classes
{
	internal class Driver
	{
		public int id { get; set; }
		public string name { get; set; }
		public string last_name { get; set; }
		public string document { get; set; }
		public DateTime date_of_birth { get; set; }
		public int license_number { get; set; }

		internal Driver(string name, string last_name, string document, DateTime date_of_birth, int license_number)
		{
			//	Replace after selecting last ID from database and ready to insert
			this.id = 0;
			this.name = name;
			this.last_name = last_name;
			this.document = document;
			this.date_of_birth = date_of_birth;
			this.license_number = license_number;
		}

		internal bool TakeCar(int car_number)
		{
			//	TODO
			/*
			 Attempt to set car.is_in_garage as false, car.is_available as false and open driving session
			 */
			return true;
		}

		internal bool ReturnCar()
		{
			//	TODO
			return true;
		}

		internal bool PayCarRent()
		{
			//	TODO
			return true;
		}

		internal static Driver? GetDriverFromDocument(SqlConnection conn, string document)
		{
			Driver? driver = null;
			string query = "SELECT * FROM drivers WHERE document = @document;";
			SqlCommand cmd = new SqlCommand(query, conn);
			cmd.Parameters.AddWithValue("@document", document);
			SqlDataReader reader = cmd.ExecuteReader();

			if (reader.Read())
			{
				driver = new Driver(
					reader.GetString(1),
					reader.GetString(2),
					reader.GetString(3),
					reader.GetDateTime(4),
					reader.GetInt32(5)
				);
				driver.id = reader.GetInt32(0);
			}

			reader.Close();

			return driver;
		}

		#region Database Methods

		internal static List<Driver> SelectAll(SqlConnection conn)
		{
			string query = "SELECT * FROM drivers";
			SqlCommand cmd = new SqlCommand(query, conn);
			SqlDataReader reader = cmd.ExecuteReader();

			List<Driver> list = new List<Driver>();
			while (reader.Read())
			{
				Driver driver = new Driver(
					reader.GetString(1),
					reader.GetString(2),
					reader.GetString(3),
					reader.GetDateTime(4),
					reader.GetInt32(5)
				);
				driver.id = reader.GetInt32(0);
				list.Add(driver);
			}

			reader.Close();

			return list;
		}

		internal static bool IsLicenseNumberRegistered(SqlConnection conn, int license_number)
		{
			string query = "SELECT ID FROM drivers WHERE license_number = @license_number";
			SqlCommand cmd = new SqlCommand(query, conn);

			cmd.Parameters.AddWithValue("@license_number", license_number);

			SqlDataReader reader = cmd.ExecuteReader();

			//	If there was a match, an drivers.ID will be returned. It needs to be zero or null for the license number not to be registered
			//	Any number != 0 means the license_number is taken
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

		internal void AddToDrivers(SqlConnection conn)
		{
			string query = "INSERT INTO drivers(name, last_name, document, date_of_birth, license_number) " +
				"VALUES (@name, @last_name, @document, @date_of_birth, @license_number);" +
				"SELECT SCOPE_IDENTITY();";
			SqlCommand cmd = new SqlCommand(query, conn);
			cmd.Parameters.AddWithValue("@name", this.name);
			cmd.Parameters.AddWithValue("@last_name", this.last_name);
			cmd.Parameters.AddWithValue("@document", this.document);
			cmd.Parameters.AddWithValue("@date_of_birth", this.date_of_birth.ToString("yyyy-MM-dd"));
			cmd.Parameters.AddWithValue("@license_number", this.license_number);

			var id = cmd.ExecuteScalar();

			if (id == null)
			{
				throw new SqlNullValueException("Null value when scoping IDENTITY");
			}

			this.id = Convert.ToInt32(id);
		}

		#endregion

	}
}

/*

DATABASE tables:
- drivers: stores all drivers
- cars: stores all cars
- driving_sessions: records all driving sessions, opens when car is taken, closed when car is returned
- garage_availability: stores all cars and marks their availability in garage, true if the're in, false if they're driving
- repair_logs: stores all repair logs, when it exited for repairs and when it returned
- rent_logs: stores all payments from drivers, marking them as Pending, Completed or Partial, and the amounts
- driver_balances: stores drivers balances, if they oew money. Should implement a system where a driver is rejected if they owe 
	more than a certain amount

 */