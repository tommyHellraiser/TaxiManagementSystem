using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxiManagement.Classes
{
	public class DatabaseConnectionException : DbException
	{
		string? ErrorDetails;
		public DatabaseConnectionException(string message)
		{
			this.ErrorDetails = message;
		}

		public DatabaseConnectionException()
		{

		}
	}
}
