namespace TaxiManagement.Forms
{
	partial class ShowFleet
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
			grdShowFleet = new DataGridView();
			btnInputPlateConfirm = new Button();
			((System.ComponentModel.ISupportInitialize)grdShowFleet).BeginInit();
			SuspendLayout();
			// 
			// grdShowFleet
			// 
			grdShowFleet.AllowUserToAddRows = false;
			grdShowFleet.AllowUserToDeleteRows = false;
			grdShowFleet.BackgroundColor = Color.LemonChiffon;
			grdShowFleet.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			grdShowFleet.GridColor = SystemColors.ControlDark;
			grdShowFleet.Location = new Point(12, 12);
			grdShowFleet.Name = "grdShowFleet";
			grdShowFleet.ReadOnly = true;
			grdShowFleet.Size = new Size(945, 252);
			grdShowFleet.TabIndex = 0;
			// 
			// btnInputPlateConfirm
			// 
			btnInputPlateConfirm.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
			btnInputPlateConfirm.Location = new Point(401, 287);
			btnInputPlateConfirm.Name = "btnInputPlateConfirm";
			btnInputPlateConfirm.Size = new Size(166, 42);
			btnInputPlateConfirm.TabIndex = 13;
			btnInputPlateConfirm.Text = "OK";
			btnInputPlateConfirm.UseVisualStyleBackColor = true;
			btnInputPlateConfirm.Click += btnInputPlateConfirm_Click;
			// 
			// ShowFleet
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			BackColor = Color.LemonChiffon;
			ClientSize = new Size(969, 338);
			Controls.Add(btnInputPlateConfirm);
			Controls.Add(grdShowFleet);
			FormBorderStyle = FormBorderStyle.Fixed3D;
			Name = "ShowFleet";
			ShowIcon = false;
			StartPosition = FormStartPosition.CenterScreen;
			Text = "Current Fleet";
			((System.ComponentModel.ISupportInitialize)grdShowFleet).EndInit();
			ResumeLayout(false);
		}

		#endregion

		private DataGridView grdShowFleet;
		private Button btnInputPlateConfirm;
	}
}