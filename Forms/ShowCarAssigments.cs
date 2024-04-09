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
	internal partial class ShowCarAssigments : Form
	{

		internal ShowCarAssigments(List<CarAssignment> assignments)
		{
			InitializeComponent();
			grdCarAssignments.DataSource = assignments;
		}

		private void btnShowAssignmentsOk_Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
