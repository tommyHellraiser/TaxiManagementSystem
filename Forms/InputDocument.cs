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
	internal partial class InputDocument : Form
	{
		internal string? document;
		internal InputDocument()
		{
			InitializeComponent();
		}

		private void btnSearchDocumentConfirm_Click(object sender, EventArgs e)
		{
			//	Input validations
			if (txtSearchDocument.Text.IsNullOrEmpty() || txtSearchDocument.Text.Length > 20)
			{
				MessageBox.Show(
					"Please enter a valid document",
					"Info",
					MessageBoxButtons.OK,
					MessageBoxIcon.Information
				);

				return;
			}

			this.document = txtSearchDocument.Text;
			this.Close();
		}
	}
}
