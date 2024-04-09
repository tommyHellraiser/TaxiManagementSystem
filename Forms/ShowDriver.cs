using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TaxiManagement.Forms
{
	public partial class ShowDriver : Form
	{
		public ShowDriver(string name, string last_name, string document, DateTime date_of_birth, int license_number, string? brand, string? model, string? license_plate, double? hourly_rate)
		{
			InitializeComponent();

			//	Set fields in form
			lblShowDriverNameShow.Text = name;
			lblShowDriverLastNameShow.Text = last_name;
			lblShowDriverDocumentShow.Text = document;
			lblShowDriverDateOfBirthShow.Text = date_of_birth.ToString("yyyy-MM-dd");
			lblShowDriverLicenseNumberShow.Text = license_number.ToString();
			lblShowDriverBrandShow.Text = brand;
			lblShowDriverModelShow.Text = model;
			lblShowDriverLicensePlateShow.Text = license_plate;
			lblShowDriverHourlyRateShow.Text = hourly_rate.ToString();
		}

		private void btnCarShowOk_Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
