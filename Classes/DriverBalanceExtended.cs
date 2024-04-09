using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxiManagement.Classes
{
	internal class DriverBalanceExtended
	{
		public string name { get; set; }
		public string last_name { get; set; }
		public string document { get; set; }
		public double balance { get; set; }
		
		internal DriverBalanceExtended(string name, string last_name, string document, double balance)
		{
			this.name = name;
			this.last_name = last_name;
			this.document = document;
			this.balance = balance;
		}

		internal static List<DriverBalanceExtended> SelectAllBalancesExtended(SqlConnection conn)
		{
			string query = "SELECT d.name, d.last_name, d.document, db.balance " +
				"FROM driver_balances as db " +
				"JOIN drivers as d " +
				"ON db.driver_ID = d.ID;";
			SqlCommand cmd = new SqlCommand(query, conn);

			SqlDataReader reader = cmd.ExecuteReader();

			List<DriverBalanceExtended> list = new List<DriverBalanceExtended>();

			while (reader.Read())
			{
				DriverBalanceExtended balance = new DriverBalanceExtended
				(
					reader.GetString(0),
					reader.GetString(1),
					reader.GetString(2),
					reader.GetDouble(3)
				);

				list.Add(balance);
			}

			reader.Close();

			return list;
		}
	}
}
