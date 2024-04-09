using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxiManagementSystem.Classes;

namespace TaxiManagement.Classes
{
	internal class DrivingSession
	{
		public int id { get; set; }
		public int driver_id { get; set; }
		public int car_id { get; set; }
		public string session_key { get; set; }
		public DateTime start_time { get; set; }
		public DateTime? end_time { get; set; }
		public double? total_amount { get; set; }
		public RentStatus rent_status { get; set; }

		public DrivingSession(int driver_id, int car_id)
		{
			this.id = 0;
			this.driver_id = driver_id;
			this.car_id = car_id;
			this.session_key = GenerateRandomSessionKey();
			this.start_time = DateTime.Now;
			this.end_time = null;
			this.total_amount = null;
			this.rent_status = RentStatus.Riding;
		}

		#region Database Methods

		internal static DrivingSession? SelectOpenFromDriverId(SqlConnection conn, int driver_id)
		{
			DrivingSession? session = null;

			string query = "SELECT * FROM driving_sessions WHERE driver_ID = @driver_ID AND end_time IS NULL;";
			SqlCommand cmd = new SqlCommand(query, conn);
			cmd.Parameters.AddWithValue("@driver_ID", driver_id);
			SqlDataReader reader = cmd.ExecuteReader();

			if (reader.Read())
			{
				session = new DrivingSession(
					reader.GetInt32(1),
					reader.GetInt32(2)
				);
				session.id = reader.GetInt32(0);
				session.session_key = reader.GetString(3);
				session.start_time = reader.GetDateTime(4);
				if (reader["total_amount"] != DBNull.Value)
				{
					throw new NoNullAllowedException("Total amount in an open driving session should not be other than null");
				}
				session.rent_status = (RentStatus)reader.GetByte(7);
			}

			reader.Close();

			return session;
		}

		internal void SaveIntoDatabase(SqlConnection conn)
		{
			string query = "INSERT INTO driving_sessions(driver_ID, car_ID, session_key, start_time, rent_status) " +
				"VALUES(@driver_ID, @car_ID, @session_key, @start_time, @rent_status); " +
				"SELECT SCOPE_IDENTITY();";
			SqlCommand cmd = new SqlCommand(query, conn);
			cmd.Parameters.AddWithValue("@driver_ID", this.driver_id);
			cmd.Parameters.AddWithValue("@car_ID", this.car_id);
			cmd.Parameters.AddWithValue("@session_key", this.session_key);
			cmd.Parameters.AddWithValue("@start_time", this.start_time);
			cmd.Parameters.AddWithValue("@rent_status", this.rent_status);

			var id = cmd.ExecuteScalar();

			if (id == null)
			{
				throw new ArgumentNullException("Error scoping identity");
			}

			this.id = Convert.ToInt32(id);
		}

		internal void CloseDrivingSession(Car car)
		{
			this.end_time = DateTime.Now;
			TimeSpan? ellapsed_time = (this.end_time - this.start_time);
			if (ellapsed_time != null)
			{
				double total_seconds = ellapsed_time.Value.TotalSeconds;
				this.total_amount = (car.hourly_rate / 3600) * (total_seconds);
			}
			else
			{
				throw new NoNullAllowedException("Ellapsed time returned null for driving session");
			}
		}

		internal double SetRentStatusFromPayment(double payment)
		{
			double pending_amount = 0.0;

			if (payment >= this.total_amount)
			{
				this.rent_status = RentStatus.Covered;
				pending_amount = payment - (double)this.total_amount;
			}
			else if (payment < this.total_amount && payment > 0)
			{
				this.rent_status = RentStatus.Partial;
				pending_amount = payment - (double)this.total_amount;
			}
			else if (payment == 0)
			{
				this.rent_status = RentStatus.Pending;
				pending_amount = (double)total_amount!;
			}

			return pending_amount;
		}

		internal void CloseDrivingSessionInDatabase(SqlConnection conn)
		{
			string query = "UPDATE driving_sessions SET end_time = @end_time, total_amount = @total_amount, rent_status = @rent_status " +
				"WHERE ID = @ID;";
			SqlCommand cmd = new SqlCommand(query, conn);
			cmd.Parameters.AddWithValue("@end_time", this.end_time);
			cmd.Parameters.AddWithValue("@total_amount", this.total_amount);
			cmd.Parameters.AddWithValue("@rent_status", (int)this.rent_status);
			cmd.Parameters.AddWithValue("@ID", this.id);

			int ar = cmd.ExecuteNonQuery();

			if (ar <= 0)
			{
				throw new SqlNotFilledException("No rows were updated while closing driving session");
			}
		}

		#endregion

		private string GenerateRandomSessionKey()
		{
			string str = "";
			int str_length = 6;
			Random rand = new Random();

			for (int i = 0; i < str_length; i++)
			{
				//	Generate a number for case 0 and a letter for case 1. Default, go for number
				switch (rand.Next(2))
				{
					case 0:
						str += rand.Next(10).ToString();
						break;
					case 1:
						str += Convert.ToChar(rand.Next(26) + 65);
						break;
					default:
						str += rand.Next(10).ToString();
						break;
				}
			}

			return str;
		}

	}

	public enum RentStatus
	{
		Riding = 0,
		Pending = 1,
		Partial = 2,
		Covered = 3,
		Undefined = 9
	}
}
