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
	internal class DriverBalance
	{
		public int id { get; set; }
		public int driver_id { get; set; }
		public double balance { get; set; }

		public DriverBalance(int driver_id)
		{
			this.id = 0;
			this.driver_id = driver_id;
			this.balance = 0;
		}

		internal void UpdateBalance(double amount_to_add)
		{
			this.balance += amount_to_add;
		}

		#region Database Methods

		internal void InsertIntoDb(SqlConnection conn)
		{
			string query = "INSERT INTO driver_balances(driver_ID, balance) VALUES(@driver_ID, @balance);" +
				"SELECT SCOPE_IDENTITY();";
			SqlCommand cmd = new SqlCommand(query, conn);
			cmd.Parameters.AddWithValue("@driver_ID", this.driver_id);
			cmd.Parameters.AddWithValue("@balance", this.balance);

			var id = cmd.ExecuteScalar();

			if (id == null)
			{
				throw new SqlNullValueException("Failed scoping identity");
			}

			this.id = Convert.ToInt32(id);
		}

		internal static DriverBalance? SelectFromDriverId(SqlConnection conn, int driver_id)
		{
			DriverBalance? balance = null;

			string query = "SELECT * FROM driver_balances WHERE driver_ID = @driver_ID;";
			SqlCommand cmd = new SqlCommand(query, conn);
			cmd.Parameters.AddWithValue("@driver_ID", driver_id);

			SqlDataReader reader = cmd.ExecuteReader();

			if (reader.Read())
			{
				balance = new DriverBalance(
					reader.GetInt32(1)
				);
				balance.id = reader.GetInt32(0);
				balance.balance = reader.GetDouble(2);
			}

			reader.Close();

			return balance;
		}

		internal void UpdateBalanceInDatabase(SqlConnection conn)
		{
			string query = "UPDATE driver_balances SET balance = @balance WHERE driver_ID = @driver_ID;";
			SqlCommand cmd = new SqlCommand(query, conn);
			cmd.Parameters.AddWithValue("@balance", this.balance);
			cmd.Parameters.AddWithValue("@driver_ID", driver_id);

			int ar = cmd.ExecuteNonQuery();

			if (ar <= 0)
			{
				throw new SqlNotFilledException("No rows were updated while closing driving session");
			}
		}

		internal static List<DriverBalance> SelectAllBalances(SqlConnection conn)
		{
			string query = "SELECT * FROM driver_balances;";
			SqlCommand cmd = new SqlCommand(query, conn);

			SqlDataReader reader = cmd.ExecuteReader();

			List<DriverBalance> list = new List<DriverBalance>();

			while (reader.Read())
			{
				DriverBalance balance = new DriverBalance(
					reader.GetInt32(1)
				);
				balance.id = reader.GetInt32(0);
				balance.balance = reader.GetDouble(2);

				list.Add(balance);
			}

			reader.Close();

			return list;
		}

		#endregion

	}
}
