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
	public partial class InputPayment : Form
	{
		internal double? amount;

		public InputPayment(double amount_to_pay)
		{
			InitializeComponent();
			lblRentFee.Text = String.Format("{0:0.##}", amount_to_pay);
		}

		private void btnInputAmountConfirm_Click(object sender, EventArgs e)
		{
			if (txtInputAmount.Text.IsNullOrEmpty())
			{
				MessageBox.Show(
					"Please enter an amount!",
					"Input Required",
					MessageBoxButtons.OK,
					MessageBoxIcon.Warning
				);

				return;
			}

			try
			{
				this.amount = Double.Parse(txtInputAmount.Text);
			}
			catch
			{
				MessageBox.Show(
					"Error converting amount!",
					"Conversion Error",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error
				);

				throw new ArgumentException("Error converting amount when parsing payment");
			}

			if (amount <= 0)
			{
				MessageBox.Show(
					"Please enter a valid amount!",
					"Input Required",
					MessageBoxButtons.OK,
					MessageBoxIcon.Warning
				);

				return;
			}

			this.Close();
		}
	}
}
