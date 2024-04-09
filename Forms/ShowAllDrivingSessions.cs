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

namespace TaxiManagement.Forms
{
	internal partial class ShowAllDrivingSessions : Form
	{
		internal ShowAllDrivingSessions(List<DrivingSessionExtended> list)
		{
			InitializeComponent();
			grdShowOpenDrivingSessions.AutoGenerateColumns = true;
			grdShowOpenDrivingSessions.DataSource = list;
		}

		private void btnShowOpenDrivingSessionsOk_Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
