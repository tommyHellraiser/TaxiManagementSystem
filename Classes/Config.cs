using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using static TaxiManagement.Classes.Config;

namespace TaxiManagement.Classes
{
	public static class Config
	{
		public static string? data_source { get; set; }
		public static string? initial_catalog { get; set; }
		public static bool integrated_security { get; set; }
		public static bool trust_server_certificate { get; set; }
		public static int minimum_year { get; set; }
		public static double? max_hourly_rate { get; set; }
		public static double min_hourly_rate { get; set; }
		public static double maximum_pending_fees { get; set; }

		public class Rootobject
		{
			public required Dbconfig DbConfig { get; set; }
			public required Fleetconfig FleetConfig { get; set; }

			internal bool ValidateConfigParameters()
			{
				//	Global validations
				if (this.DbConfig == null)
				{
					return false;
				}

				if (this.FleetConfig == null)
				{
					return false;
				}

				//	Db validations
				if (this.DbConfig.DataSource.IsNullOrEmpty() || this.DbConfig.InitialCatalog.IsNullOrEmpty())
				{
					return false;
				}

				return true;
			}
		}

		public class Dbconfig
		{
			public required string DataSource { get; set; }
			public required string InitialCatalog { get; set; }
			public bool IntegratedSecurity { get; set; }
			public bool TrustServerCertificate { get; set; }
		}

		public class Fleetconfig
		{
			public int MinimumYear { get; set; }
			public int MaxHourlyRate { get; set; }
			public int MinHourlyRate { get; set; }
			public double MaximumPendingFees { get; set; }
		}


		public static void LoadFromJson()
		{
			//	Attempt to load from file
			using (StreamReader reader = new StreamReader("../../../config/config.json"))
			{
				string? json = reader.ReadToEnd();
				if (json == null)
				{
					throw new NullReferenceException("No config.json was found in specified directory");
				}
				Rootobject? configuration = JsonSerializer.Deserialize<Rootobject>(json);
				if (configuration == null)
				{
					throw new NullReferenceException("Couldn't load configuration from config.json file");
				}

				//	Validate no mandatory fields are null
				if (!configuration.ValidateConfigParameters())
				{
					throw new ArgumentNullException("Mandatory fields were not found in config.json");
				}

				Config.data_source = configuration.DbConfig!.DataSource;
				Config.initial_catalog = configuration.DbConfig.InitialCatalog;
				Config.integrated_security = configuration.DbConfig.IntegratedSecurity;
				Config.trust_server_certificate = configuration.DbConfig.TrustServerCertificate;
				Config.minimum_year = (int)configuration.FleetConfig!.MinimumYear!;
				Config.min_hourly_rate = (int)configuration.FleetConfig!.MinHourlyRate!;
				Config.max_hourly_rate = configuration.FleetConfig!.MaxHourlyRate!;
				Config.maximum_pending_fees = configuration.FleetConfig!.MaximumPendingFees!;

			}
		}
	}
}
