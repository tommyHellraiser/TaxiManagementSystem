using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TaxiManagementSystem.Classes;

namespace TaxiManagement.Forms
{
	internal partial class ShowCar : Form
	{
		public ShowCar(Car car)
		{
			InitializeComponent();

			lblShowBrand.Text = car.brand;
			lblShowModel.Text = car.model;
			lblShowYear.Text = car.year.ToString();
			lblShowLicensePlate.Text = car.license_plate;
			lblShowHourlyRate.Text = car.hourly_rate.ToString();
			lblShowReplacementCar.Text = car.is_replacement.ToString();
			lblShowActiveInFleet.Text = car.is_in_fleet.ToString();
			lblShowIsInGarage.Text = car.is_in_garage.ToString();
		}

		private void btnCarShowOk_Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
