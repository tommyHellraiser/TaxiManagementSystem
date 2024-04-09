using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TaxiManagement.Classes;
using TaxiManagementSystem.Classes;

namespace TaxiManagement.Forms
{
	public partial class AddDriver : Form
	{
		internal string? name { get; set; }
		internal string? last_name { get; set; }
		internal string? document { get; set; }
		internal DateTime? date_of_birth { get; set; }
		internal int? license_number { get; set; }
		internal string? assign_license_plate { get; set; }

		private SqlConnection conn;

		public bool IsInputNull()
		{
			return (this.name.IsNullOrEmpty() || this.last_name.IsNullOrEmpty() || this.document.IsNullOrEmpty() || this.date_of_birth == null || this.license_number == null || this.assign_license_plate.IsNullOrEmpty());
		}

		public AddDriver(SqlConnection conn)
		{
			InitializeComponent();
			this.conn = conn;
		}

		private void btnAddDriverConfirm_Click(object sender, EventArgs e)
		{
			//	Set all labels as black
			lblAddDriverName.ForeColor = Color.Black;
			lblAddDriverLastName.ForeColor = Color.Black;
			lblAddDriverDocument.ForeColor = Color.Black;
			lblAddDriverDateOfBirth.ForeColor = Color.Black;
			lblAddDriverLicenseNumber.ForeColor = Color.Black;
			lblAddDriverAssignPlate.ForeColor = Color.Black;

			//	Validate all mandatory input is present
			if (!IsInputValid())
			{
				MessageBox.Show(
					"Please enter the mandatory fields marked in red",
					"Missing Fields",
					MessageBoxButtons.OK,
					MessageBoxIcon.Warning);

				return;
			}

			//	Assign initial values to this instance that don't need to be further validated
			this.name = txtAddDriverName.Text;
			this.last_name = txtAddDriverLastName.Text;
			this.document = txtAddDriverDocument.Text;

			try
			{
				//	Date of Birth validations
				this.date_of_birth = dtmAddDriverDateOfBirth.Value;
				if (!IsDateValid(out string error_message))
				{
					lblAddDriverDateOfBirth.ForeColor = Color.Red;
					MessageBox.Show(
						error_message,
						"Error in Date Of Birth",
						MessageBoxButtons.OK,
						MessageBoxIcon.Warning);

					return;
				}

				lblAddDriverDateOfBirth.ForeColor = Color.Black;
			}
			catch (Exception ex)
			{
				throw new Exception($"Error processing date of birth parameter: {ex.Message}");
			}


			try
			{
				//	License Number validations
				this.license_number = int.Parse(txtAddDriverLicenseNumber.Text);

				if (!IsLicenseNumberValid(out string error_message))
				{
					lblAddDriverLicenseNumber.ForeColor = Color.Red;
					MessageBox.Show(
						error_message,
						"Error in License Number parameter",
						MessageBoxButtons.OK,
						MessageBoxIcon.Warning);

					return;
				}

				lblAddDriverLicenseNumber.ForeColor = Color.Black;
			}
			catch (Exception ex)
			{
				throw new Exception($"Error processing license number parameter: {ex.Message}");
			}

			//	Validate used car is not currently assigned to someone else
			try
			{
				this.assign_license_plate = txtAddDriverPreferredCar.Text;

				if (!IsLicensePlateValid(out string error_message))
				{
					lblAddDriverAssignPlate.ForeColor = Color.Red;
					MessageBox.Show(
						error_message,
						"Error in License Plate Assignment",
						MessageBoxButtons.OK,
						MessageBoxIcon.Warning);

					return;
				}

				lblAddDriverAssignPlate.ForeColor = Color.Black;
			}
			catch (Exception ex)
			{
				throw new Exception($"Error processing license plate parameter: {ex.Message}");
			}


			this.Close();
		}

		private bool IsInputValid()
		{
			bool fields_error = true;
			//	Name
			if (txtAddDriverName.Text.IsNullOrEmpty())
			{
				fields_error = false;
				lblAddDriverName.ForeColor = Color.Red;
			}

			//	Last Name
			if (txtAddDriverLastName.Text.IsNullOrEmpty())
			{
				fields_error = false;
				lblAddDriverLastName.ForeColor = Color.Red;
			}

			//	Document
			if (txtAddDriverDocument.Text.IsNullOrEmpty())
			{
				fields_error = false;
				lblAddDriverDocument.ForeColor = Color.Red;
			}

			//	Date Of Birth
			if (dtmAddDriverDateOfBirth.Value.ToShortDateString().IsNullOrEmpty())
			{
				fields_error = false;
				lblAddDriverDateOfBirth.ForeColor = Color.Red;
			}

			//	License Number
			if (txtAddDriverLicenseNumber.Text.IsNullOrEmpty())
			{
				fields_error = false;
				lblAddDriverLicenseNumber.ForeColor = Color.Red;
			}

			// Preferred Car Plate
			if (txtAddDriverPreferredCar.Text.IsNullOrEmpty())
			{
				fields_error = false;
				lblAddDriverAssignPlate.ForeColor = Color.Red;
			}

			return fields_error;
		}

		private bool IsDateValid(out string error_message)
		{
			bool date_valid = true;

			if (this.date_of_birth > DateTime.Now)
			{
				date_valid = false;
				error_message = "We're not living in the future, and neither is the driver you're trying to hire. Check the date";
			}
			else if (this.date_of_birth > DateTime.Now.AddYears(-18))
			{
				date_valid = false;
				error_message = "What are you trying to hire minors?.. Check the birthdate";
			}
			else if (this.date_of_birth < DateTime.Now.AddYears(-75))
			{
				date_valid = false;
				error_message = "Driver might be a bit old to drive.. we're gonna pass on that one";
			}
			else
			{
				error_message = "";
			}

			return date_valid;
		}

		private bool IsLicenseNumberValid(out string error_message)
		{
			bool number_valid = true;

			if (this.license_number == null)
			{
				number_valid = false;
				error_message = "License number cannot be null!";
			}
			else if (this.license_number <= 0)
			{
				number_valid = false;
				error_message = "License Number cannot be zero or negative!";
			}
			else if (Driver.IsLicenseNumberRegistered(this.conn, (int)this.license_number))
			{
				number_valid = false;
				error_message = "License number is already registered, please enter a different one";
			}
			else
			{
				error_message = "";
			}

			return number_valid;
		}
		
		private bool IsLicensePlateValid(out string error_message)
		{
			bool plate_valid = true;

			if (this.assign_license_plate.IsNullOrEmpty())
			{
				plate_valid = false;
				error_message = "License plate cannot be empty or null!";
			}
			else if (!Car.DoesLicensePlateExist(this.conn, this.assign_license_plate!))
			{
				plate_valid = false;
				error_message = "License plate does not exist in this server!";
			}
			else if (CarAssignment.IsPlateAssigned(this.conn, this.assign_license_plate!))
			{
				plate_valid = false;
				error_message = "Car is assigned to another driver";
			}
			else
			{
				error_message = "";
			}

			return plate_valid;
		}
	}
}
