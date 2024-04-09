namespace TaxiManagement.Forms
{
	partial class ShowAllBalances
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			btnShowBalancesOk = new Button();
			grdShowBalances = new DataGridView();
			((System.ComponentModel.ISupportInitialize)grdShowBalances).BeginInit();
			SuspendLayout();
			// 
			// btnShowBalancesOk
			// 
			btnShowBalancesOk.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
			btnShowBalancesOk.Location = new Point(150, 270);
			btnShowBalancesOk.Name = "btnShowBalancesOk";
			btnShowBalancesOk.Size = new Size(166, 42);
			btnShowBalancesOk.TabIndex = 17;
			btnShowBalancesOk.Text = "OK";
			btnShowBalancesOk.UseVisualStyleBackColor = true;
			btnShowBalancesOk.Click += btnShowBalancesOk_Click;
			// 
			// grdShowBalances
			// 
			grdShowBalances.AllowUserToAddRows = false;
			grdShowBalances.AllowUserToDeleteRows = false;
			grdShowBalances.BackgroundColor = Color.LemonChiffon;
			grdShowBalances.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			grdShowBalances.GridColor = SystemColors.ControlDark;
			grdShowBalances.Location = new Point(12, 12);
			grdShowBalances.Name = "grdShowBalances";
			grdShowBalances.ReadOnly = true;
			grdShowBalances.Size = new Size(443, 252);
			grdShowBalances.TabIndex = 16;
			// 
			// ShowAllBalances
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			BackColor = Color.LemonChiffon;
			ClientSize = new Size(467, 318);
			Controls.Add(btnShowBalancesOk);
			Controls.Add(grdShowBalances);
			FormBorderStyle = FormBorderStyle.Fixed3D;
			MaximizeBox = false;
			Name = "ShowAllBalances";
			ShowIcon = false;
			StartPosition = FormStartPosition.CenterScreen;
			Text = "Balances";
			((System.ComponentModel.ISupportInitialize)grdShowBalances).EndInit();
			ResumeLayout(false);
		}

		#endregion

		private Button btnShowBalancesOk;
		private DataGridView grdShowBalances;
	}
}