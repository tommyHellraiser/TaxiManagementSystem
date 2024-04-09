namespace TaxiManagement.Forms
{
	partial class ShowAllDrivers
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
			btnShowDriversOk = new Button();
			grdShowDrivers = new DataGridView();
			((System.ComponentModel.ISupportInitialize)grdShowDrivers).BeginInit();
			SuspendLayout();
			// 
			// btnShowDriversOk
			// 
			btnShowDriversOk.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
			btnShowDriversOk.Location = new Point(250, 286);
			btnShowDriversOk.Name = "btnShowDriversOk";
			btnShowDriversOk.Size = new Size(166, 42);
			btnShowDriversOk.TabIndex = 15;
			btnShowDriversOk.Text = "OK";
			btnShowDriversOk.UseVisualStyleBackColor = true;
			btnShowDriversOk.Click += btnShowDriversOk_Click;
			// 
			// grdShowDrivers
			// 
			grdShowDrivers.AllowUserToAddRows = false;
			grdShowDrivers.AllowUserToDeleteRows = false;
			grdShowDrivers.BackgroundColor = Color.LemonChiffon;
			grdShowDrivers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			grdShowDrivers.GridColor = SystemColors.ControlDark;
			grdShowDrivers.Location = new Point(12, 12);
			grdShowDrivers.Name = "grdShowDrivers";
			grdShowDrivers.ReadOnly = true;
			grdShowDrivers.Size = new Size(644, 252);
			grdShowDrivers.TabIndex = 14;
			// 
			// ShowDrivers
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			BackColor = Color.LemonChiffon;
			ClientSize = new Size(668, 340);
			Controls.Add(btnShowDriversOk);
			Controls.Add(grdShowDrivers);
			FormBorderStyle = FormBorderStyle.Fixed3D;
			Name = "ShowDrivers";
			ShowIcon = false;
			StartPosition = FormStartPosition.CenterScreen;
			Text = "Current Drivers";
			((System.ComponentModel.ISupportInitialize)grdShowDrivers).EndInit();
			ResumeLayout(false);
		}

		#endregion

		private Button btnShowDriversOk;
		private DataGridView grdShowDrivers;
	}
}