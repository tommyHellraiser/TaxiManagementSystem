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
	internal partial class ShowAllBalances : Form
	{
		internal ShowAllBalances(List<DriverBalanceExtended> balances)
		{
			InitializeComponent();
			grdShowBalances.AutoGenerateColumns = true;
			grdShowBalances.DataSource = balances;
		}

		private void btnShowBalancesOk_Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
