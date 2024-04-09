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
	internal partial class ShowFleet : Form
	{
		internal ShowFleet(List<Car> cars)
		{
			InitializeComponent();
			grdShowFleet.AutoGenerateColumns = true;
			grdShowFleet.DataSource = cars;
		}

		private void btnInputPlateConfirm_Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
