namespace TaxiManagement.Forms
{
	partial class AddCar
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
			txtAddCarBrand = new TextBox();
			txtAddCarModel = new TextBox();
			txtAddCarYear = new TextBox();
			txtAddCarLicensePlate = new TextBox();
			txtAddCarHourlyRate = new TextBox();
			cboAddCarReplacement = new ComboBox();
			btnAddCarConfirm = new Button();
			lblAddCarModel = new Label();
			lblAddCarBrand = new Label();
			lblAddCarYear = new Label();
			lblAddCarLicensePlate = new Label();
			lblAddCarHourlyRate = new Label();
			lblAddCarReplacementCar = new Label();
			SuspendLayout();
			// 
			// txtAddCarBrand
			// 
			txtAddCarBrand.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
			txtAddCarBrand.Location = new Point(12, 37);
			txtAddCarBrand.Name = "txtAddCarBrand";
			txtAddCarBrand.Size = new Size(262, 29);
			txtAddCarBrand.TabIndex = 0;
			// 
			// txtAddCarModel
			// 
			txtAddCarModel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
			txtAddCarModel.Location = new Point(12, 108);
			txtAddCarModel.Name = "txtAddCarModel";
			txtAddCarModel.Size = new Size(262, 29);
			txtAddCarModel.TabIndex = 1;
			// 
			// txtAddCarYear
			// 
			txtAddCarYear.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
			txtAddCarYear.Location = new Point(12, 179);
			txtAddCarYear.Name = "txtAddCarYear";
			txtAddCarYear.Size = new Size(262, 29);
			txtAddCarYear.TabIndex = 2;
			// 
			// txtAddCarLicensePlate
			// 
			txtAddCarLicensePlate.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
			txtAddCarLicensePlate.Location = new Point(12, 251);
			txtAddCarLicensePlate.Name = "txtAddCarLicensePlate";
			txtAddCarLicensePlate.Size = new Size(262, 29);
			txtAddCarLicensePlate.TabIndex = 3;
			// 
			// txtAddCarHourlyRate
			// 
			txtAddCarHourlyRate.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
			txtAddCarHourlyRate.Location = new Point(12, 322);
			txtAddCarHourlyRate.Name = "txtAddCarHourlyRate";
			txtAddCarHourlyRate.Size = new Size(262, 29);
			txtAddCarHourlyRate.TabIndex = 4;
			// 
			// cboAddCarReplacement
			// 
			cboAddCarReplacement.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
			cboAddCarReplacement.FormattingEnabled = true;
			cboAddCarReplacement.Items.AddRange(new object[] { "No", "Yes" });
			cboAddCarReplacement.Location = new Point(12, 395);
			cboAddCarReplacement.Name = "cboAddCarReplacement";
			cboAddCarReplacement.Size = new Size(262, 29);
			cboAddCarReplacement.TabIndex = 6;
			// 
			// btnAddCarConfirm
			// 
			btnAddCarConfirm.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
			btnAddCarConfirm.Location = new Point(63, 441);
			btnAddCarConfirm.Name = "btnAddCarConfirm";
			btnAddCarConfirm.Size = new Size(166, 42);
			btnAddCarConfirm.TabIndex = 7;
			btnAddCarConfirm.Text = "Confirm!";
			btnAddCarConfirm.UseVisualStyleBackColor = true;
			btnAddCarConfirm.Click += btnAddCarConfirm_Click;
			// 
			// lblAddCarModel
			// 
			lblAddCarModel.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
			lblAddCarModel.Location = new Point(12, 80);
			lblAddCarModel.Name = "lblAddCarModel";
			lblAddCarModel.Size = new Size(262, 25);
			lblAddCarModel.TabIndex = 9;
			lblAddCarModel.Text = "Model";
			lblAddCarModel.TextAlign = ContentAlignment.MiddleCenter;
			// 
			// lblAddCarBrand
			// 
			lblAddCarBrand.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
			lblAddCarBrand.Location = new Point(12, 9);
			lblAddCarBrand.Name = "lblAddCarBrand";
			lblAddCarBrand.Size = new Size(262, 25);
			lblAddCarBrand.TabIndex = 10;
			lblAddCarBrand.Text = "Brand";
			lblAddCarBrand.TextAlign = ContentAlignment.MiddleCenter;
			// 
			// lblAddCarYear
			// 
			lblAddCarYear.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
			lblAddCarYear.Location = new Point(12, 151);
			lblAddCarYear.Name = "lblAddCarYear";
			lblAddCarYear.Size = new Size(262, 25);
			lblAddCarYear.TabIndex = 11;
			lblAddCarYear.Text = "Year";
			lblAddCarYear.TextAlign = ContentAlignment.MiddleCenter;
			// 
			// lblAddCarLicensePlate
			// 
			lblAddCarLicensePlate.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
			lblAddCarLicensePlate.Location = new Point(12, 223);
			lblAddCarLicensePlate.Name = "lblAddCarLicensePlate";
			lblAddCarLicensePlate.Size = new Size(262, 25);
			lblAddCarLicensePlate.TabIndex = 12;
			lblAddCarLicensePlate.Text = "License Plate";
			lblAddCarLicensePlate.TextAlign = ContentAlignment.MiddleCenter;
			// 
			// lblAddCarHourlyRate
			// 
			lblAddCarHourlyRate.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
			lblAddCarHourlyRate.Location = new Point(12, 294);
			lblAddCarHourlyRate.Name = "lblAddCarHourlyRate";
			lblAddCarHourlyRate.Size = new Size(262, 25);
			lblAddCarHourlyRate.TabIndex = 13;
			lblAddCarHourlyRate.Text = "Hourly rate";
			lblAddCarHourlyRate.TextAlign = ContentAlignment.MiddleCenter;
			// 
			// lblAddCarReplacementCar
			// 
			lblAddCarReplacementCar.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
			lblAddCarReplacementCar.Location = new Point(12, 367);
			lblAddCarReplacementCar.Name = "lblAddCarReplacementCar";
			lblAddCarReplacementCar.Size = new Size(262, 25);
			lblAddCarReplacementCar.TabIndex = 14;
			lblAddCarReplacementCar.Text = "Is It Replacement Car?";
			lblAddCarReplacementCar.TextAlign = ContentAlignment.MiddleCenter;
			// 
			// AddCar
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			BackColor = Color.LemonChiffon;
			ClientSize = new Size(284, 497);
			Controls.Add(lblAddCarReplacementCar);
			Controls.Add(lblAddCarHourlyRate);
			Controls.Add(lblAddCarLicensePlate);
			Controls.Add(lblAddCarYear);
			Controls.Add(lblAddCarBrand);
			Controls.Add(lblAddCarModel);
			Controls.Add(btnAddCarConfirm);
			Controls.Add(cboAddCarReplacement);
			Controls.Add(txtAddCarHourlyRate);
			Controls.Add(txtAddCarLicensePlate);
			Controls.Add(txtAddCarYear);
			Controls.Add(txtAddCarModel);
			Controls.Add(txtAddCarBrand);
			FormBorderStyle = FormBorderStyle.Fixed3D;
			MaximizeBox = false;
			Name = "AddCar";
			ShowIcon = false;
			StartPosition = FormStartPosition.CenterScreen;
			Text = "Enter Car Details";
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private TextBox txtAddCarBrand;
		private TextBox txtAddCarModel;
		private TextBox txtAddCarYear;
		private TextBox txtAddCarLicensePlate;
		private TextBox txtAddCarHourlyRate;
		private ComboBox cboAddCarReplacement;
		private Button btnAddCarConfirm;
		private Label lblAddCarModel;
		private Label lblAddCarBrand;
		private Label lblAddCarYear;
		private Label lblAddCarLicensePlate;
		private Label lblAddCarHourlyRate;
		private Label lblAddCarReplacementCar;
	}
}