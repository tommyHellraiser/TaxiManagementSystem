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
	internal partial class ShowAllRepairLogs : Form
	{
		internal ShowAllRepairLogs(List<RepairLog> logs)
		{
			InitializeComponent();
			grdShowAllRepairLogs.DataSource = logs;
		}

		private void btnShowAllRepairLogsOk_Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
