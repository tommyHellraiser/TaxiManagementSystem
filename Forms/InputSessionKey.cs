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
	public partial class InputSessionKey : Form
	{
		internal string? session_key;

		public InputSessionKey()
		{
			InitializeComponent();
		}

		private void btnInputSessionKeyConfirm_Click(object sender, EventArgs e)
		{
			if (txtInputSessionKey.Text.IsNullOrEmpty())
			{
				MessageBox.Show(
					"Please enter a session key!",
					"Input Required",
					MessageBoxButtons.OK,
					MessageBoxIcon.Warning
				);
				this.session_key = null;

				return;
			}

			this.session_key = txtInputSessionKey.Text;

			//	Validate input
			if (this.session_key.Length != 6)
			{
				MessageBox.Show(
					"Please enter a valid session key!",
					"Input Required",
					MessageBoxButtons.OK,
					MessageBoxIcon.Warning
				);
				this.session_key = null;

				return;
			}

			this.Close();
		}
	}
}
