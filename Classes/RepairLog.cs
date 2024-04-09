using Microsoft.Data.SqlClient;
using Microsoft.VisualBasic.Logging;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxiManagement.Classes
{
	internal class RepairLog
	{
		public int id { get; set; }
		public int car_id { get; set; }
		public DateTime start_repair { get; set; }
		public DateTime? end_repair { get; set; }

		internal RepairLog(int car_id)
		{
			this.id = 0;
			this.car_id = car_id;
			start_repair = DateTime.Now;
			end_repair = null;
		}

		internal bool IsCarAlreadyInRepair(SqlConnection conn, int car_id)
		{
			bool is_in_repair = true;
			string query = "SELECT ID FROM repair_logs WHERE car_ID = @car_id";
			SqlCommand cmd = new SqlCommand(query, conn);
			cmd.Parameters.AddWithValue("@car_id", this.car_id);
			SqlDataReader reader = cmd.ExecuteReader();

			if (reader.Read())
			{
				if (reader.GetInt32(0) != 0) {
					is_in_repair = true;
				}
				else
				{
					is_in_repair = false;
				}
			}
			else
			{
				is_in_repair = false;
			}

			reader.Close();

			return is_in_repair;
		}

		internal void SendToRepair(SqlConnection conn)
		{
			string query = "INSERT INTO repair_logs(car_id, start_repair) VALUES(@car_id, @start_repair); " +
				"SELECT SCOPE_IDENTITY();";
			SqlCommand cmd = new SqlCommand(query, conn);
			cmd.Parameters.AddWithValue("@car_id", this.car_id);
			cmd.Parameters.AddWithValue("@start_repair", this.start_repair);

			var id = cmd.ExecuteScalar();

			if (id == null)
			{
				throw new SqlNullValueException("Failed to read identity last inserted id");
			}

			this.id = Convert.ToInt32(id);
		}

		internal static RepairLog? SelectFromCarId(SqlConnection conn, int car_id)
		{
			RepairLog? log = null;

			string query = "SELECT * FROM repair_logs WHERE car_ID = @car_ID AND end_repair IS NULL;";
			SqlCommand cmd = new SqlCommand(query, conn);
			cmd.Parameters.AddWithValue("@car_id", car_id);
			SqlDataReader reader = cmd.ExecuteReader();

			if (reader.Read())
			{
				log = new RepairLog(
					reader.GetInt32(1)
				);
				log.id = reader.GetInt32(0);
				log.start_repair = reader.GetDateTime(2);
				if (reader["end_repair"] != DBNull.Value)
				{
					log.end_repair = reader.GetDateTime(3);
				}
			}

			reader.Close();

			return log;
		}

		internal void RepairEnd(SqlConnection conn)
		{
			string query = "UPDATE repair_logs SET end_repair = @end_repair WHERE ID = @id";
			DateTime end_repair = DateTime.Now;
			SqlCommand cmd = new SqlCommand(query, conn);
			cmd.Parameters.AddWithValue("@end_repair", end_repair);
			cmd.Parameters.AddWithValue("@id", this.id);

			int ar = cmd.ExecuteNonQuery();

			if (ar <= 0) {
				throw new SqlNotFilledException("No registries were updated in repaid end query");
			}
		}

		internal static List<RepairLog> SelectAll(SqlConnection conn)
		{
			List<RepairLog> list = new List<RepairLog>();

			string query = "SELECT * FROM repair_logs;";
			SqlCommand cmd = new SqlCommand(query, conn);
			SqlDataReader reader = cmd.ExecuteReader();

			while (reader.Read())
			{
				RepairLog log = new RepairLog(
					reader.GetInt32(1)
				);
				log.id = reader.GetInt32(0);
				log.start_repair = reader.GetDateTime(2);
				if (reader["end_repair"] != DBNull.Value)
				{
					log.end_repair = reader.GetDateTime(3);
				}

				list.Add(log);
			}

			reader.Close();

			return list;
		}
	}
}
