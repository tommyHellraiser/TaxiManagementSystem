using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxiManagement.Classes
{
	internal class DrivingSessionExtended
	{
		public string? name { get; set; }
		public string? last_name { get; set; }
		public string? document { get; set; }
		public string? car_brand { get; set; }
		public string? car_model { get; set; }
		public string? license_plate { get; set; }
		public double? hourly_rate { get; set; }
		public string? session_key { get; set; }

		public DrivingSessionExtended(string name, string last_name, string document, string car_brand, string car_model, string license_plate, double hourly_rate, string session_key)
		{
			this.name = name;
			this.last_name = last_name;
			this.document = document;
			this.car_brand = car_brand;
			this.car_model = car_model;
			this.license_plate = license_plate;
			this.hourly_rate = hourly_rate;
			this.session_key = session_key;
		}

		internal static List<DrivingSessionExtended> SelectAllOpenDrivingSessions(SqlConnection conn)
		{
			List<DrivingSessionExtended> list = new List<DrivingSessionExtended>();

			string query = "SELECT d.name, d.last_name, d.document, c.brand, c.model, c.license_plate, c.hourly_rate, ds.session_key, ds.start_time " +
				"FROM driving_sessions as ds " +
				"LEFT JOIN drivers AS d " +
				"ON ds.driver_ID = d.ID " +
				"LEFT JOIN cars AS c " +
				"ON ds.car_ID = c.ID " +
				"WHERE end_time IS NULL;";
			SqlCommand cmd = new SqlCommand(query, conn);
			SqlDataReader reader = cmd.ExecuteReader();

			while (reader.Read())
			{
				DrivingSessionExtended session = new DrivingSessionExtended(
					reader.GetString(0),
					reader.GetString(1),
					reader.GetString(2),
					reader.GetString(3),
					reader.GetString(4),
					reader.GetString(5),
					reader.GetDouble(6),
					reader.GetString(7)
				);

				list.Add(session);
			}

			reader.Close();

			return list;
		}
	}
}
