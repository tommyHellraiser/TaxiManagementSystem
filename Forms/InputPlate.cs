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

namespace TaxiManagement.Forms
{

	public partial class InputPlate : Form
	{
		internal string? license_plate;
		public InputPlate()
		{
			InitializeComponent();
		}

		private void btnInputPlateConfirm_Click(object sender, EventArgs e)
		{
			//	Input validations
			if (txtInputPlate.Text.IsNullOrEmpty() || txtInputPlate.Text.Length > 20)
			{
				MessageBox.Show(
					"Please enter a valid license plate",
					"Info",
					MessageBoxButtons.OK,
					MessageBoxIcon.Information
				);

				return;
			}

			this.license_plate = txtInputPlate.Text;
			this.Close();
		}
	}
}
