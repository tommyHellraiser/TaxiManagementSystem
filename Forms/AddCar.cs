using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TaxiManagement.Classes;

namespace TaxiManagement.Forms
{
	public partial class AddCar : Form
	{
		internal string? brand;
		internal string? model;
		internal int? year;
		internal string? license_plate;
		internal double? hourly_rate;
		internal bool? is_replacement_car;

		public AddCar()
		{
			InitializeComponent();
		}

		public bool IsInputNull()
		{
			return (this.brand == null || this.model == null || this.year == null || this.license_plate == null || this.hourly_rate == null || this.is_replacement_car == null);
		}

		private void btnAddCarConfirm_Click(object sender, EventArgs e)
		{
			//	Set all labels in black
			lblAddCarBrand.ForeColor = Color.Black;
			lblAddCarModel.ForeColor = Color.Black;
			lblAddCarYear.ForeColor = Color.Black;
			lblAddCarLicensePlate.ForeColor = Color.Black;
			lblAddCarHourlyRate.ForeColor = Color.Black;
			lblAddCarReplacementCar.ForeColor = Color.Black;

			if (!IsInputValid())
			{
				MessageBox.Show(
					"Please enter the mandatory fields marked in red",
					"Missing Fields",
					MessageBoxButtons.OK,
					MessageBoxIcon.Warning);

				return;
			}

			//	If there were no validation errors, assign some of the fields and set the label text black
			lblAddCarBrand.ForeColor = Color.Black;
			this.brand = txtAddCarBrand.Text;
			lblAddCarModel.ForeColor = Color.Black;
			this.model = txtAddCarModel.Text;
			lblAddCarLicensePlate.ForeColor = Color.Black;
			this.license_plate = txtAddCarLicensePlate.Text;

			//	Additional Year validations
			try
			{
				this.year = int.Parse(txtAddCarYear.Text);

				//	Validate possible year inconsistencies
				if (!IsYearValid(out string error_message))
				{
					lblAddCarYear.ForeColor = Color.Red;
					MessageBox.Show(
						error_message,
						"Error in Year",
						MessageBoxButtons.OK,
						MessageBoxIcon.Warning);

					return;
				}

				//	Set year text black
				lblAddCarYear.ForeColor = Color.Black;
			}
			catch (Exception ex)
			{
				throw new Exception($"Errors getting year from input:\n{ex.Message}");
			}

			//	Hourly Rate
			try
			{
				this.hourly_rate = double.Parse(txtAddCarHourlyRate.Text);

				//	Validate Hourly Rate content
				if (!IsHourlyRateValid(out string error_message))
				{
					lblAddCarHourlyRate.ForeColor = Color.Red;
					MessageBox.Show(
						error_message,
						"Error in Hourly Rate",
						MessageBoxButtons.OK,
						MessageBoxIcon.Warning);

					return;
				}

				//	Set Hourly Rate text black
				lblAddCarHourlyRate.ForeColor = Color.Black;
			}
			catch (Exception ex)
			{
				throw new Exception($"Errors getting hourly rate from input:\n{ex.Message}");
			}

			//	Replacement Car
			switch (cboAddCarReplacement.SelectedIndex)
			{
				case 0:
					this.is_replacement_car = false;
					break;
				case 1:
					this.is_replacement_car = true;
					break;
				default:
					throw new IndexOutOfRangeException("Index error while selecting Replacement Car");
			}

			//	All validations completed. Return to keep processing by hiding this dialog
			this.Close();
		}

		private bool IsInputValid()
		{
			bool fields_error = true;
			//	Brand
			if (txtAddCarBrand.Text.IsNullOrEmpty())
			{
				fields_error = false;
				lblAddCarBrand.ForeColor = Color.Red;
			}

			//	Model
			if (txtAddCarModel.Text.IsNullOrEmpty())
			{
				fields_error = false;
				lblAddCarModel.ForeColor = Color.Red;
			}

			//	Year
			if (txtAddCarYear.Text.IsNullOrEmpty())
			{
				fields_error = false;
				lblAddCarYear.ForeColor = Color.Red;
			}

			//	license Plate
			if (txtAddCarLicensePlate.Text.IsNullOrEmpty())
			{
				fields_error = false;
				lblAddCarLicensePlate.ForeColor = Color.Red;
			}

			//	Hourly Rate
			if (txtAddCarHourlyRate.Text.IsNullOrEmpty())
			{
				fields_error = false;
				lblAddCarHourlyRate.ForeColor = Color.Red;
			}

			// Replacement Car
			if (cboAddCarReplacement.SelectedIndex == -1)
			{
				fields_error = false;
				lblAddCarReplacementCar.ForeColor = Color.Red;
			}

			return fields_error;
		}

		private bool IsYearValid(out string error_message)
		{
			bool year_valid = true;
			if (this.year <= 0)
			{
				error_message = "Year cannot be zero or negative!";
				year_valid = false;
			}
			else if (this.year < Config.minimum_year)
			{
				error_message = "Car is too old to be used in this agency!";
				year_valid = false;
			}
			else if (this.year > DateTime.Now.Year + 2)
			{
				error_message = "What are you, living in the future dude? Come on...";
				year_valid = false;
			}
			else
			{
				error_message = "";
			}

			return year_valid;
		}

		private bool IsHourlyRateValid(out string error_message)
		{
			bool valid_rate = true;

			if (this.hourly_rate <= 0)
			{
				valid_rate = false;
				error_message = "Hourly rate cannot be zero or negative!";
			}
			else if (this.hourly_rate < Config.min_hourly_rate)
			{
				valid_rate = false;
				error_message = $"Hourly rate needs to be a minimum of ${Config.min_hourly_rate}";
			}
			else if (Config.max_hourly_rate != null && this.hourly_rate > Config.max_hourly_rate)
			{
				valid_rate = false;
				error_message = "Come on man, who do you think you are? Lower your price a bit....";
			}
			else
			{
				error_message = "";
			}

			return valid_rate;
		}
	}
}
