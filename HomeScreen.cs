using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Sql;
using Microsoft.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TaxiManagementSystem.Classes;
using System.Diagnostics;
using TaxiManagement.Properties;
using TaxiManagement.Classes;
using TaxiManagement.Forms;
using Microsoft.IdentityModel.Tokens;
using System.Data.SqlTypes;
using System.Data.Common;

namespace TaxiManagementSystem
{
	public partial class HomeScreen : Form
	{

		internal SqlConnection? conn;

		public HomeScreen()
		{
			InitializeComponent();
			//this.FormBorderStyle = FormBorderStyle.None;
			this.CenterToScreen();
			this.Show();

			//	Attempt to load critical data and connect to db
			try
			{
				Config.LoadFromJson();
				this.conn = InitDatabaseConnection();
			}
			catch (Exception ex)
			{
				Debug.WriteLine($"There were errors in initialization processes:\n{ex}");
				Application.Exit();
			}

			//	Spawn a cron job that checks connection with db constantly and attempts to reconnect if it fails
			//Task.Run(() => DbConnectionCron());
		}

		private SqlConnection InitDatabaseConnection()
		{
			//	Set db conn status image as in progress
			this.pbxDbConnStatus.Image = Resources.database_conn_in_progress;
			SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
			builder.DataSource = Config.data_source;
			builder.InitialCatalog = Config.initial_catalog;
			builder.IntegratedSecurity = Config.integrated_security;
			builder.TrustServerCertificate = Config.trust_server_certificate;

			SqlConnection conn = new SqlConnection(builder.ConnectionString);
			conn.Open();

			//	Set db conn status image as Ok
			this.pbxDbConnStatus.Image = Resources.database_conn_ok;

			return conn;
		}


		#region Driving Sessions Management Handlers

		private void btnStartDrivingShift_Click(object sender, EventArgs e)
		{
			StartDrivingShift();
		}

		private void btnEndDrivingShift_Click(object sender, EventArgs e)
		{
			EndDrivingShift();
		}

		private void btnPayPendingFees_Click(object sender, EventArgs e)
		{
			PayPendingFees();
		}

		private void btnCheckAllBalances_Click(object sender, EventArgs e)
		{
			CheckAllBalances();
		}

		private void btnShowOpenDrivingSessions_Click(object sender, EventArgs e)
		{
			CheckOpenDrivingSessions();
		}

		#endregion

		#region Fleet Management Handlers

		private void btnAddCarToFleet_Click(object sender, EventArgs e)
		{
			AddCarToFleet();
		}

		private void btnRemoveCarFromFleet_Click(object sender, EventArgs e)
		{
			RemoveCarFromFleet();
		}

		private void btnShowAllCarsInFleet_Click(object sender, EventArgs e)
		{
			ShowAllCarsInFleet();
		}

		private void btnRestoreCar_Click(object sender, EventArgs e)
		{
			RestoreCarToFleet();
		}

		#endregion

		#region Car management Handlers

		private void btnSendCarToRepair_Click(object sender, EventArgs e)
		{
			SendCarToRepair();
		}

		private void btnReceiveCarFromRepair_Click(object sender, EventArgs e)
		{
			ReceiveCarFromRepair();
		}

		private void btnCheckCarDetails_Click(object sender, EventArgs e)
		{
			CheckCarDetails();
		}

		private void btnCheckRepairLogs_Click(object sender, EventArgs e)
		{
			CheckRepairLogs();
		}

		#endregion

		#region Drivers Management Handlers

		private void btnAddDriver_Click(object sender, EventArgs e)
		{
			AddNewDriver();
		}

		private void btnCheckDriverDetails_Click(object sender, EventArgs e)
		{
			CheckDriverDetails();
		}

		private void btnShowAllDrivers_Click(object sender, EventArgs e)
		{
			ShowAllDrivers();
		}

		private void btnShowCarAssignments_Click(object sender, EventArgs e)
		{
			ShowCarAssignments();
		}

		#endregion




		#region Driving Sessions Management Functions

		private void StartDrivingShift()
		{
			try
			{
				//	Prompt user to enter driver's document
				InputDocument input = new InputDocument();
				input.ShowDialog();

				if (input.document.IsNullOrEmpty())
				{
					MessageBox.Show(
						"Shift opening cancelled!",
						"Info",
						MessageBoxButtons.OK,
						MessageBoxIcon.Information
					);

					return;
				}

				//	Search driver with document
				CheckDatabaseConnection();
				Driver? driver = Driver.GetDriverFromDocument(this.conn!, input.document!);
				if (driver == null)
				{
					MessageBox.Show(
						"No driver was found!",
						"Info",
						MessageBoxButtons.OK,
						MessageBoxIcon.Information
					);
					Debug.WriteLine($"No driver was found from document. Driver.ID: {input.document}");

					return;
				}

				//	Check if driver is allowed to rent a car from driver_balances
				CheckDatabaseConnection();
				DriverBalance? balance = DriverBalance.SelectFromDriverId(this.conn!, driver.id);
				if (balance == null)
				{
					MessageBox.Show(
						"No balance was found for driver!",
						"Info",
						MessageBoxButtons.OK,
						MessageBoxIcon.Information
					);
					Debug.WriteLine($"No balance was found for driver. Driver.ID: {driver.id}");

					return;
				}
				if ((balance.balance * -1) >= Config.maximum_pending_fees)
				{
					MessageBox.Show(
						"Please pay the pending fees before renting a car!",
						"Info",
						MessageBoxButtons.OK,
						MessageBoxIcon.Information
					);

					return;
				}

				//	Get car from driver document
				CheckDatabaseConnection();
				Car? car = Car.FromDriverDocument(this.conn!, driver.document);
				if (car == null)
				{
					MessageBox.Show(
						$"No car was found for driver with document{driver.document}. Contact administration!",
						"Error",
						MessageBoxButtons.OK,
						MessageBoxIcon.Error
					);

					return;
				}

				//	Check if car is in garage
				bool took_replacement_car = false;
				if (!car.is_in_garage)
				{
					//	If it's not, it should be in repair. Look for it
					CheckDatabaseConnection();
					RepairLog? repair_log = RepairLog.SelectFromCarId(this.conn!, (int)car.id!);

					//	if it's not in repair, notify it and return to Home Screen
					if (repair_log == null)
					{
						MessageBox.Show(
							$"No car was found in garage or in repairs. Contact administration as soon as possible!",
							"Error",
							MessageBoxButtons.OK,
							MessageBoxIcon.Error
						);

						return;
					}

					//	Otherwise, take a replacement car
					CheckDatabaseConnection();
					Car? replacement_car = Car.SelectFirstReplacementOccurence(this.conn!);
					//	If no replacement car is available, return
					if (replacement_car == null)
					{
						MessageBox.Show(
							$"There are no cars available at the moment, try again later!",
							"No cars available",
							MessageBoxButtons.OK,
							MessageBoxIcon.Warning
						);

						return;
					}

					//	Otherwise take the replacement, replace car with replacement_car
					car = replacement_car;
					took_replacement_car = true;
				}

				//	Mark it as not in garage
				CheckDatabaseConnection();
				car.MarkAsNotInGarage(this.conn!);

				//	 Create entry in driving_sessions
				DrivingSession driving_session = new DrivingSession(driver.id, (int)car.id!);
				CheckDatabaseConnection();
				driving_session.SaveIntoDatabase(this.conn!);

				//	Session created, give session key to driver so they can close it later!
				string message = "Driving session started!\n\n";
				if (took_replacement_car)
				{
					message += $"Replacement car selected. License plate: {car.license_plate}.\n\n";
				}
				MessageBox.Show(
					message + $"The session key is: {driving_session.session_key}",
					"Success!",
					MessageBoxButtons.OK,
					MessageBoxIcon.Information
				);

				return;
			}
			catch (Exception ex)
			{
				MessageBox.Show(
					"Error opening driving session!",
					"Error",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error
				);
				Debug.WriteLine($"Error opening driving session:\n{ex.Message}");
			}
		}

		private void EndDrivingShift()
		{
			try
			{
				//	Prompt user to enter driver's document
				InputDocument input = new InputDocument();
				input.ShowDialog();

				if (input.document.IsNullOrEmpty())
				{
					MessageBox.Show(
						"Shift opening cancelled!",
						"Info",
						MessageBoxButtons.OK,
						MessageBoxIcon.Information
					);

					return;
				}

				//	Search driver with document
				CheckDatabaseConnection();
				Driver? driver = Driver.GetDriverFromDocument(this.conn!, input.document!);
				if (driver == null)
				{
					MessageBox.Show(
						"No driver was found!",
						"Info",
						MessageBoxButtons.OK,
						MessageBoxIcon.Information
					);

					return;
				}

				//	Get open session from driver ID
				CheckDatabaseConnection();
				DrivingSession? open_session = DrivingSession.SelectOpenFromDriverId(this.conn!, driver.id);
				if (open_session == null)
				{
					MessageBox.Show(
						"No open session was found!",
						"Warning",
						MessageBoxButtons.OK,
						MessageBoxIcon.Information
					);
					Debug.WriteLine($"No open session was found for this driver! Driver.ID: {driver.id}");

					return;
				}

				//	Get the car from open_session
				CheckDatabaseConnection();
				Car? car = Car.FromID(this.conn!, open_session.car_id);
				if (car == null)
				{
					MessageBox.Show(
						"No car was found for this open session!",
						"Warning",
						MessageBoxButtons.OK,
						MessageBoxIcon.Information
					);
					Debug.WriteLine($"No car was found for this open session! OpenSession.ID: {open_session.id}");

					return;
				}

				//	Prompt the driver to enter session_key
				InputSessionKey session_key_form = new InputSessionKey();
				session_key_form.ShowDialog();

				if (session_key_form.session_key.IsNullOrEmpty())
				{
					MessageBox.Show(
						"Open driving session processing cancelled!",
						"Info",
						MessageBoxButtons.OK,
						MessageBoxIcon.Information
					);

					return;
				}

				//	If session key does not match, loop until it does or until box is closed
				while (session_key_form.session_key != open_session.session_key)
				{
					session_key_form.ShowDialog();

					if (session_key_form.session_key.IsNullOrEmpty())
					{
						MessageBox.Show(
							"Open driving session processing cancelled!",
							"Info",
							MessageBoxButtons.OK,
							MessageBoxIcon.Information
						);

						return;
					}
				}

				//	Closing driving session, saves total rent amount in open_session
				open_session.CloseDrivingSession(car);

				//	Show driver the amount to pay and request payment
				InputPayment payment_form = new InputPayment((double)open_session.total_amount!);
				payment_form.ShowDialog();
				if (payment_form.amount == null)
				{
					MessageBox.Show(
						"Open driving session processing cancelled!",
						"Info",
						MessageBoxButtons.OK,
						MessageBoxIcon.Information
					);

					return;
				}

				//	Update rent status from payment
				double rent_remainder = open_session.SetRentStatusFromPayment((double)payment_form.amount);

				//	Save result in database
				CheckDatabaseConnection();
				open_session.CloseDrivingSessionInDatabase(this.conn!);

				//	Return car to garage
				CheckDatabaseConnection();
				car.MarkAsInGarage(this.conn!);

				//	Select driver balance
				CheckDatabaseConnection();
				DriverBalance? balance = DriverBalance.SelectFromDriverId(this.conn!, driver.id);
				if (balance == null)
				{
					MessageBox.Show(
						"No balance was found for this driver!",
						"Warning",
						MessageBoxButtons.OK,
						MessageBoxIcon.Information
					);
					Debug.WriteLine($"No balance was found for this driver! Driver.ID: {driver.id}");

					return;
				}

				//	Update balance amount
				balance.UpdateBalance(rent_remainder);

				//	Update balance in db
				CheckDatabaseConnection();
				balance.UpdateBalanceInDatabase(this.conn!);

				//	Finished processing session close
				MessageBox.Show(
					$"Driving session closed!\nThank you for choosing us!",
					"Success!",
					MessageBoxButtons.OK,
					MessageBoxIcon.Information
				);

				return;
			}
			catch (Exception ex)
			{
				MessageBox.Show(
					"Error closing driving session!",
					"Error",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error
				);
				Debug.WriteLine($"Error closing driving session:\n{ex.Message}");
			}
		}

		private void PayPendingFees()
		{
			try
			{
				//	Prompt user to enter driver's document
				InputDocument input = new InputDocument();
				input.ShowDialog();

				if (input.document.IsNullOrEmpty())
				{
					MessageBox.Show(
						"Shift opening cancelled!",
						"Info",
						MessageBoxButtons.OK,
						MessageBoxIcon.Information
					);

					return;
				}

				//	Search driver with document
				CheckDatabaseConnection();
				Driver? driver = Driver.GetDriverFromDocument(this.conn!, input.document!);
				if (driver == null)
				{
					MessageBox.Show(
						"No driver was found!",
						"Info",
						MessageBoxButtons.OK,
						MessageBoxIcon.Information
					);

					return;
				}

				//	Get driver balance
				CheckDatabaseConnection();
				DriverBalance? balance = DriverBalance.SelectFromDriverId(this.conn!, driver.id);
				if (balance == null)
				{
					MessageBox.Show(
						"No balance was found for this driver!",
						"Error",
						MessageBoxButtons.OK,
						MessageBoxIcon.Error
					);
					Debug.WriteLine($"No balance was found for this driver with document: {driver.document}");

					return;
				}

				// Show balance with message box
				var dialog_result = MessageBox.Show(
					$"Balance for driver {driver.name} {driver.last_name} is:\n${String.Format("{0:0.00}", balance.balance)}\nProceed to pay?",
					"Balance",
					MessageBoxButtons.YesNo,
					MessageBoxIcon.Information
				);

				if (dialog_result == DialogResult.No)
				{
					return;
				}

				//	Ask for payment
				PayFee fee_form = new PayFee();
				fee_form.ShowDialog();
				if (fee_form.amount == null)
				{
					MessageBox.Show(
						"Fees payment cancelled!",
						"Info",
						MessageBoxButtons.OK,
						MessageBoxIcon.Information
					);

					return;
				}

				//	Update balance
				balance.UpdateBalance((double)fee_form.amount);

				//	Update balance in db
				CheckDatabaseConnection();
				balance.UpdateBalanceInDatabase(this.conn!);

				//	Get current balance from db, to validate it was properly updated
				CheckDatabaseConnection();
				DriverBalance? new_balance = DriverBalance.SelectFromDriverId(this.conn!, driver.id);
				if (balance == null)
				{
					MessageBox.Show(
						"No balance was found for this driver!",
						"Error",
						MessageBoxButtons.OK,
						MessageBoxIcon.Error
					);
					Debug.WriteLine($"No balance was found for this driver with document: {driver.document}");

					return;
				}

				//	Show current balance with dialog box
				MessageBox.Show(
					$"Balance for driver {driver.name} {driver.last_name} is:\n${String.Format("{0:0.00}", balance.balance)}",
					"Balance",
					MessageBoxButtons.OK,
					MessageBoxIcon.Information
				);

				return;
			}
			catch (Exception ex)
			{
				MessageBox.Show(
					"Error paying pending balance!",
					"Error",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error
				);
				Debug.WriteLine($"Error paying pending balance:\n{ex.Message}");
			}
		}

		private void CheckAllBalances()
		{
			try
			{
				CheckDatabaseConnection();
				List<DriverBalanceExtended> balances = DriverBalanceExtended.SelectAllBalancesExtended(this.conn!);
				if (balances.IsNullOrEmpty())
				{
					MessageBox.Show(
						"No balances were found!",
						"Info",
						MessageBoxButtons.OK,
						MessageBoxIcon.Information
					);

					return;
				}

				ShowAllBalances balances_form = new ShowAllBalances(balances);
				balances_form.Show();
			}
			catch (Exception ex)
			{
				MessageBox.Show(
					"Error checking balances!",
					"Error",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error
				);
				Debug.WriteLine($"Error checking balances: {ex.Message}");
			}
		}

		private void CheckOpenDrivingSessions()
		{
			try
			{
				//	Select all extended driving sessions from database
				CheckDatabaseConnection();
				List<DrivingSessionExtended> sessions = DrivingSessionExtended.SelectAllOpenDrivingSessions(this.conn!);

				ShowAllDrivingSessions session_form = new ShowAllDrivingSessions(sessions);
				session_form.Show();
			}
			catch (Exception ex)
			{
				MessageBox.Show(
					"Error checking driving sessions!",
					"Error",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error
				);
				Debug.WriteLine($"Error checking driving sessions: {ex.Message}");
			}
		}

		#endregion

		#region Fleet Management Functions

		private void AddCarToFleet()
		{
			AddCar input_car = new();
			try
			{
				input_car.ShowDialog();
			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex.Message);
			}

			if (input_car.IsInputNull())
			{
				MessageBox.Show(
					"Car creation cancelled!",
					"Info",
					MessageBoxButtons.OK,
					MessageBoxIcon.Information
				);

				return;
			}

			Debug.WriteLine("\nCreated new car, inserting into db");

			Car new_car = new Car(
				input_car.brand!,
				input_car.model!,
				(int)input_car.year!,
				input_car.license_plate!,
				(double)input_car.hourly_rate!,
				(bool)input_car.is_replacement_car!
			);

			try
			{
				Car? existing_car = Car.FromlicensePlateUnfiltered(this.conn!, new_car.license_plate!);

				if (existing_car != null)
				{
					MessageBox.Show(
						$"There's an existing car for plate {new_car.license_plate}!\nTry restoring it instead",
						"Conflict",
						MessageBoxButtons.OK,
						MessageBoxIcon.Information
					);

					return;
				}

				new_car.AddToFleet(this.conn!);
				Debug.WriteLine($"Car inserted into database with ID: {new_car.id}");
				MessageBox.Show(
					"Car created successfully!",
					"Success",
					MessageBoxButtons.OK,
					MessageBoxIcon.Information
				);
			}
			catch (Exception ex)
			{
				MessageBox.Show(
					"Error adding car to fleet!",
					"Error",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error
				);
				Debug.WriteLine($"Error inserting car into db:\n{ex.Message}");
			}
		}

		private void RemoveCarFromFleet()
		{
			try
			{
				//	Search car
				Car? car = SearchCar(false);

				if (car != null)
				{
					//	Prompt user to delete car
					var dialog_result = MessageBox.Show(
						"Are you sure you want to delete this car?",
						"Warning",
						MessageBoxButtons.YesNo,
						MessageBoxIcon.Question
					);

					if (dialog_result == DialogResult.Yes)
					{
						if (!car.MarkAsDeleted(this.conn!))
						{
							MessageBox.Show(
								"Error deleting car. Returning to main page",
								"Error",
								MessageBoxButtons.OK,
								MessageBoxIcon.Error
							);
							Debug.WriteLine("Error deleting car. Returning to main page");

							return;
						}

						MessageBox.Show(
							"Car deleted successfully",
							"Info",
							MessageBoxButtons.OK,
							MessageBoxIcon.Information
						);
					}

					return;
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(
					"Error deleting car. Returning to main page",
					"Error",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error
				);

				Debug.WriteLine($"Error executing car search: {ex.Message}");
			}
		}

		private void ShowAllCarsInFleet()
		{
			try
			{
				List<Car> car_list = Car.SelectAllInFleet(this.conn!);

				if (car_list.IsNullOrEmpty())
				{
					MessageBox.Show(
						"No cars were found!",
						"Info",
						MessageBoxButtons.OK,
						MessageBoxIcon.Information
					);

					return;
				}

				ShowFleet fleet_form = new(car_list);
				fleet_form.Show();
			}
			catch (Exception ex)
			{
				MessageBox.Show(
					"Error getting cars. Returning to main page",
					"Error",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error
				);

				Debug.WriteLine($"Error executing car search: {ex.Message}");
			}
		}

		private void RestoreCarToFleet()
		{
			try
			{
				//	Search car
				Car? car = SearchCar(true);

				if (car != null)
				{
					if (!car.RestoreToFleet(this.conn!))
					{
						MessageBox.Show(
							"Error restoring car. Returning to main page",
							"Error",
							MessageBoxButtons.OK,
							MessageBoxIcon.Error
						);
					}

					MessageBox.Show(
						"Car restored successfully!",
						"Info",
						MessageBoxButtons.OK,
						MessageBoxIcon.Information
					);
				}

				//	No car was found in this case. Warning was already shown
				return;
			}
			catch (Exception ex)
			{
				MessageBox.Show(
					"Error restoring car. Returning to main page",
					"Error",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error
				);

				Debug.WriteLine($"Error executing car search: {ex.Message}");
			}
		}

		#endregion

		#region Car Management Functions

		private void SendCarToRepair()
		{
			try
			{
				//	Get car from license plate
				Car? car = SearchCar(false);
				if (car == null)
				{
					return;
				}

				//	Show confirmation box
				var dialog_result = MessageBox.Show(
					"Are you sure you want to send the car to repair?",
					"Confirm",
					MessageBoxButtons.YesNo,
					MessageBoxIcon.Warning
				);
				if (dialog_result == DialogResult.No)
				{
					MessageBox.Show(
						"Cancelled car repair!",
						"Cancelled",
						MessageBoxButtons.OK,
						MessageBoxIcon.Information
					);

					return;
				}

				CheckDatabaseConnection();

				//	If car's not null, then check if car is already in repair
				RepairLog? check_log = RepairLog.SelectFromCarId(this.conn!, (int)car.id!);
				if (check_log != null)
				{
					MessageBox.Show(
						"Car is already in repair. Please wait for it to be fixed!",
						"Information",
						MessageBoxButtons.OK,
						MessageBoxIcon.Information
					);

					return;
				}

				//	Check if car is in garage. If it is, then send it to repair
				if (!car.is_in_garage)
				{
					MessageBox.Show(
						"Car is not in garage. I don't know what's up. Tell the boss dude!",
						"Warning",
						MessageBoxButtons.OK,
						MessageBoxIcon.Warning
					);

					return;
				}

				//	If car is not in repair, send it to repair instantiating a new RepairLog
				RepairLog repair_log = new RepairLog((int)car.id);

				CheckDatabaseConnection();
				car.MarkAsNotInGarage(this.conn!);

				CheckDatabaseConnection();
				repair_log.SendToRepair(this.conn!);

				MessageBox.Show(
					"Car successfully sent to repair",
					"Success!",
					MessageBoxButtons.OK,
					MessageBoxIcon.Information
				);

				return;
			}
			catch (Exception ex)
			{
				MessageBox.Show(
					"Error Sending car to repair. Returning to main page",
					"Error",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error
				);

				Debug.WriteLine($"Error Sending car to repair: {ex.Message}");
			}
		}

		private void ReceiveCarFromRepair()
		{
			try
			{
				//	Get car from license plate
				Car? car = SearchCar(false);
				if (car == null)
				{
					return;
				}

				CheckDatabaseConnection();

				//	If car's not null, then check if car is already in garage
				RepairLog? receive_log = RepairLog.SelectFromCarId(this.conn!, (int)car.id!);
				if (receive_log == null)
				{
					MessageBox.Show(
						"Car is not in repair. Please check the garage",
						"Information",
						MessageBoxButtons.OK,
						MessageBoxIcon.Information
					);

					return;
				}

				//	Check if car is in garage. If it is, then send it to repair
				if (car.is_in_garage)
				{
					MessageBox.Show(
						"Car is in garage. Who tf brought it without telling me?",
						"Warning",
						MessageBoxButtons.OK,
						MessageBoxIcon.Warning
					);

					return;
				}

				//	If car's not in garage, then receive it and mark it as in garage
				CheckDatabaseConnection();
				car.MarkAsInGarage(this.conn!);
				CheckDatabaseConnection();
				receive_log.RepairEnd(this.conn!);

				MessageBox.Show(
					"Car successfully received from repair!",
					"Success!",
					MessageBoxButtons.OK,
					MessageBoxIcon.Information
				);
			}
			catch (Exception ex)
			{
				MessageBox.Show(
					"Error Sending car to repair. Returning to main page",
					"Error",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error
				);

				Debug.WriteLine($"Error Sending car to repair: {ex.Message}");
			}
		}

		private void CheckCarDetails()
		{
			try
			{
				//	Search car
				SearchCar(false);

				return;
			}
			catch (Exception ex)
			{
				MessageBox.Show(
					"Error searching car. Returning to main page",
					"Error",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error
				);

				Debug.WriteLine($"Error executing car search: {ex.Message}");
			}
		}

		private void CheckRepairLogs()
		{
			try
			{
				//	Get all repair logs from db
				CheckDatabaseConnection();
				List<RepairLog> logs = RepairLog.SelectAll(this.conn!);

				//	Instantiate form and show data
				ShowAllRepairLogs logs_form = new ShowAllRepairLogs(logs);
				logs_form.Show();
			}
			catch (Exception ex)
			{
				MessageBox.Show(
					"Error retrieving repair logs. Returning to main page",
					"Error",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error
				);

				Debug.WriteLine($"Error retrieving repair logs: {ex.Message}");
			}
		}

		#endregion

		#region Drivers Management Functions

		private void AddNewDriver()
		{
			try
			{

				CheckDatabaseConnection();

				//	Get driver data
				AddDriver driver_form = new AddDriver(this.conn!);
				driver_form.ShowDialog();

				if (driver_form.IsInputNull())
				{
					MessageBox.Show(
						"Driver creation cancelled!",
						"Info",
						MessageBoxButtons.OK,
						MessageBoxIcon.Information
					);

					return;
				}

				//	Once data has been obtained and validated, build Driver
				//	Assuring data isn't null cause it was already validated when prompted for input
				Driver new_driver = new Driver(
					driver_form.name!,
					driver_form.last_name!,
					driver_form.document!,
					(DateTime)driver_form.date_of_birth!,
					(int)driver_form.license_number!
				);

				//	Insert driver into database
				CheckDatabaseConnection();
				new_driver.AddToDrivers(this.conn!);

				//	Select car from license plate. It should exist at this point, it was validated during creation
				CheckDatabaseConnection();
				Car assigned_car = Car.FromlicensePlate(this.conn!, driver_form.assign_license_plate!)!;

				//	With driver built, add car_assignment from driver's last inserted ID
				CarAssignment assignment = new CarAssignment(
					0,
					(int)assigned_car.id!,
					assigned_car.brand!,
					assigned_car.model!,
					assigned_car.license_plate!,
					new_driver.id,
					new_driver.name,
					new_driver.last_name,
					new_driver.document
				);

				CheckDatabaseConnection();
				assignment.AssignCarToDriver(this.conn!);

				//	Create driver balance
				DriverBalance balance = new DriverBalance(new_driver.id);
				CheckDatabaseConnection();
				balance.InsertIntoDb(this.conn!);

				MessageBox.Show(
					"Successfully created a driver!",
					"Successs!",
					MessageBoxButtons.OK,
					MessageBoxIcon.Information
				);
			}
			catch (Exception ex)
			{
				MessageBox.Show(
					"Error adding driver. Returning to main page",
					"Error",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error
				);

				Debug.WriteLine($"Error executing driver addition: {ex.Message}");
			}
		}

		private void CheckDriverDetails()
		{
			try
			{
				InputDocument input = new InputDocument();
				input.ShowDialog();

				if (input.document.IsNullOrEmpty())
				{
					MessageBox.Show(
						$"Search cancelled!",
						"Info",
						MessageBoxButtons.OK,
						MessageBoxIcon.Information
					);

					return;
				}

				//	Get driver from document
				Driver? driver;

				CheckDatabaseConnection();

				driver = Driver.GetDriverFromDocument(this.conn!, input.document!);

				//	Get car from license_plate
				Car? car = null;

				CheckDatabaseConnection();

				if (driver == null)
				{
					MessageBox.Show(
						"Driver was not found in database. Returning to home screen",
						"Warning",
						MessageBoxButtons.OK,
						MessageBoxIcon.Warning
					);
					return;
				}
				car = Car.FromDriverDocument(this.conn, driver.document);

				//	If car or driver is null log error and return
				if (car == null)
				{
					MessageBox.Show(
						$"No car was found for driver's document {driver.document}. Please notify the developer",
						"Error",
						MessageBoxButtons.OK,
						MessageBoxIcon.Error
					);
					Debug.WriteLine($"No car was found for driver's document {driver.document}");

					return;
				}

				ShowDriver show_driver_form = new ShowDriver(
					driver.name,
					driver.last_name,
					driver.document,
					driver.date_of_birth,
					driver.license_number,
					car.brand,
					car.model,
					car.license_plate,
					car.hourly_rate
					);
				show_driver_form.ShowDialog();
			}
			catch (Exception ex)
			{
				MessageBox.Show(
					"Error showing driver details. Returning to main page",
					"Error",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error
				);

				Debug.WriteLine($"Error showing driver details: {ex.Message}");
			}
		}

		private void ShowAllDrivers()
		{
			try
			{
				List<Driver> drivers = Driver.SelectAll(this.conn!);

				if (drivers.IsNullOrEmpty())
				{
					MessageBox.Show(
						"No drivers were found!",
						"Info",
						MessageBoxButtons.OK,
						MessageBoxIcon.Information
					);

					return;
				}

				ShowAllDrivers drivers_form = new(drivers);
				drivers_form.Show();
			}
			catch (Exception ex)
			{
				MessageBox.Show(
					"Error getting drivers. Returning to main page",
					"Error",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error
				);

				Debug.WriteLine($"Error executing car search: {ex.Message}");
			}
		}

		private void ShowCarAssignments()
		{
			CheckDatabaseConnection();

			List<CarAssignment> assignments = CarAssignment.SelectAll(this.conn!);

			ShowCarAssigments assignments_form = new ShowCarAssigments(assignments);
			assignments_form.Show();
		}

		#endregion

		#region General Functions

		private void btnResetDatabase_Click(object sender, EventArgs e)
		{
			//	Prompt user to confirm
			var dialog_result = MessageBox.Show(
				"Are you sure you want to reset the database?\nThis operation cannot be undone",
				"Warning",
				MessageBoxButtons.YesNo,
				MessageBoxIcon.Warning
			);

			if (dialog_result == DialogResult.No)
			{
				return;
			}

			//	Start execution of database reset
			try
			{
				//	Load .sql files to execute
				string schema_delete = File.ReadAllText("../../../Sql/reset/schema_delete.sql");
				string schema_rebuild = File.ReadAllText("../../../Sql/reset/schema_rebuild.sql");
				string schema_data = File.ReadAllText("../../../Sql/reset/schema_data.sql");

				//	Prepare and run first two transactions to drop all tables
				SqlCommand cmd = new(schema_delete, this.conn);
				cmd.ExecuteNonQuery();

				//	Prepare and run second transaction
				cmd.CommandText = schema_rebuild;
				cmd.ExecuteNonQuery();

				//	Prepare and run third transaction
				cmd.CommandText = schema_data;
				var result = cmd.ExecuteNonQuery();

				Debug.WriteLine("Schema reset executed succesfully!");

				MessageBox.Show(
					"Database reset successfully executed!",
					"Success",
					MessageBoxButtons.OK,
					MessageBoxIcon.Information
				);
			}
			catch (Exception ex)
			{
				Debug.WriteLine($"Error running database reset scripts:\n{ex.Message}");
				MessageBox.Show(
					"Error resetting. Check debug console",
					"Error",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error
				);
			}
		}

		private Car? SearchCar(bool unfiltered)
		{
			//	Enter license plate number from form
			InputPlate input = new();
			input.ShowDialog();

			//	Validate form wasn't closed before completing input
			if (input.license_plate.IsNullOrEmpty())
			{
				MessageBox.Show(
					$"Search cancelled!",
					"Info",
					MessageBoxButtons.OK,
					MessageBoxIcon.Information
				);

				return null;
			}

			//	Get car
			Car? car_select = null;
			if (unfiltered)
			{
				car_select = Car.FromlicensePlateUnfiltered(this.conn!, input.license_plate!);
			}
			else
			{
				car_select = Car.FromlicensePlate(this.conn!, input.license_plate!);
			}


			if (car_select == null)
			{
				MessageBox.Show(
				$"No car was found for license plate: {input.license_plate!}",
				"Info",
				MessageBoxButtons.OK,
				MessageBoxIcon.Information
			);

				return null;
			}

			//	Show details in form
			ShowCar form = new(car_select);
			form.ShowDialog();

			return car_select;
		}

		private void CheckDatabaseConnection()
		{
			if (this.conn == null)
			{
				MessageBox.Show(
					$"Coudln't connect to database, please retry in a few moments. If the problem persists, notify the developer",
					"Connection Error",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error
				);

				throw new DatabaseConnectionException("Lost connection to database");
			}
		}

		#endregion

		#region Cron Jobs

		private void DbConnectionCron()
		{
			
		}

		#endregion
	}
}
