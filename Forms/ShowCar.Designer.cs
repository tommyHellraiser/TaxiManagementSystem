
using TaxiManagementSystem.Classes;

namespace TaxiManagement.Forms
{
	partial class ShowCar : Form
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
			lblAddCarReplacementCar = new Label();
			lblAddCarHourlyRate = new Label();
			lblAddCarlicensePlate = new Label();
			lblAddCarYear = new Label();
			lblAddCarBrand = new Label();
			lblAddCarModel = new Label();
			btnCarShowOk = new Button();
			lblShowBrand = new Label();
			lblShowModel = new Label();
			lblShowYear = new Label();
			lblShowLicensePlate = new Label();
			lblShowHourlyRate = new Label();
			lblShowReplacementCar = new Label();
			lblShowIsInGarage = new Label();
			lblShowActiveInFleet = new Label();
			label8 = new Label();
			label9 = new Label();
			SuspendLayout();
			// 
			// lblAddCarReplacementCar
			// 
			lblAddCarReplacementCar.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
			lblAddCarReplacementCar.Location = new Point(302, 82);
			lblAddCarReplacementCar.Name = "lblAddCarReplacementCar";
			lblAddCarReplacementCar.Size = new Size(262, 25);
			lblAddCarReplacementCar.TabIndex = 27;
			lblAddCarReplacementCar.Text = "Is It Replacement Car?";
			lblAddCarReplacementCar.TextAlign = ContentAlignment.MiddleCenter;
			// 
			// lblAddCarHourlyRate
			// 
			lblAddCarHourlyRate.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
			lblAddCarHourlyRate.Location = new Point(302, 9);
			lblAddCarHourlyRate.Name = "lblAddCarHourlyRate";
			lblAddCarHourlyRate.Size = new Size(262, 25);
			lblAddCarHourlyRate.TabIndex = 26;
			lblAddCarHourlyRate.Text = "Hourly rate";
			lblAddCarHourlyRate.TextAlign = ContentAlignment.MiddleCenter;
			// 
			// lblAddCarlicensePlate
			// 
			lblAddCarlicensePlate.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
			lblAddCarlicensePlate.Location = new Point(12, 223);
			lblAddCarlicensePlate.Name = "lblAddCarlicensePlate";
			lblAddCarlicensePlate.Size = new Size(262, 25);
			lblAddCarlicensePlate.TabIndex = 25;
			lblAddCarlicensePlate.Text = "License Plate";
			lblAddCarlicensePlate.TextAlign = ContentAlignment.MiddleCenter;
			// 
			// lblAddCarYear
			// 
			lblAddCarYear.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
			lblAddCarYear.Location = new Point(12, 151);
			lblAddCarYear.Name = "lblAddCarYear";
			lblAddCarYear.Size = new Size(262, 25);
			lblAddCarYear.TabIndex = 24;
			lblAddCarYear.Text = "Year";
			lblAddCarYear.TextAlign = ContentAlignment.MiddleCenter;
			// 
			// lblAddCarBrand
			// 
			lblAddCarBrand.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
			lblAddCarBrand.Location = new Point(12, 9);
			lblAddCarBrand.Name = "lblAddCarBrand";
			lblAddCarBrand.Size = new Size(262, 25);
			lblAddCarBrand.TabIndex = 23;
			lblAddCarBrand.Text = "Brand";
			lblAddCarBrand.TextAlign = ContentAlignment.MiddleCenter;
			// 
			// lblAddCarModel
			// 
			lblAddCarModel.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
			lblAddCarModel.Location = new Point(12, 80);
			lblAddCarModel.Name = "lblAddCarModel";
			lblAddCarModel.Size = new Size(262, 25);
			lblAddCarModel.TabIndex = 22;
			lblAddCarModel.Text = "Model";
			lblAddCarModel.TextAlign = ContentAlignment.MiddleCenter;
			// 
			// btnCarShowOk
			// 
			btnCarShowOk.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
			btnCarShowOk.Location = new Point(202, 291);
			btnCarShowOk.Name = "btnCarShowOk";
			btnCarShowOk.Size = new Size(166, 42);
			btnCarShowOk.TabIndex = 21;
			btnCarShowOk.Text = "OK";
			btnCarShowOk.UseVisualStyleBackColor = true;
			btnCarShowOk.Click += btnCarShowOk_Click;
			// 
			// lblShowBrand
			// 
			lblShowBrand.BackColor = Color.WhiteSmoke;
			lblShowBrand.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
			lblShowBrand.Location = new Point(12, 34);
			lblShowBrand.Name = "lblShowBrand";
			lblShowBrand.Size = new Size(262, 29);
			lblShowBrand.TabIndex = 28;
			lblShowBrand.TextAlign = ContentAlignment.MiddleCenter;
			// 
			// lblShowModel
			// 
			lblShowModel.BackColor = Color.WhiteSmoke;
			lblShowModel.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
			lblShowModel.Location = new Point(12, 105);
			lblShowModel.Name = "lblShowModel";
			lblShowModel.Size = new Size(262, 29);
			lblShowModel.TabIndex = 29;
			lblShowModel.TextAlign = ContentAlignment.MiddleCenter;
			// 
			// lblShowYear
			// 
			lblShowYear.BackColor = Color.WhiteSmoke;
			lblShowYear.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
			lblShowYear.Location = new Point(12, 176);
			lblShowYear.Name = "lblShowYear";
			lblShowYear.Size = new Size(262, 29);
			lblShowYear.TabIndex = 30;
			lblShowYear.TextAlign = ContentAlignment.MiddleCenter;
			// 
			// lblShowLicensePlate
			// 
			lblShowLicensePlate.BackColor = Color.WhiteSmoke;
			lblShowLicensePlate.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
			lblShowLicensePlate.Location = new Point(12, 248);
			lblShowLicensePlate.Name = "lblShowLicensePlate";
			lblShowLicensePlate.Size = new Size(262, 29);
			lblShowLicensePlate.TabIndex = 31;
			lblShowLicensePlate.TextAlign = ContentAlignment.MiddleCenter;
			// 
			// lblShowHourlyRate
			// 
			lblShowHourlyRate.BackColor = Color.WhiteSmoke;
			lblShowHourlyRate.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
			lblShowHourlyRate.Location = new Point(302, 34);
			lblShowHourlyRate.Name = "lblShowHourlyRate";
			lblShowHourlyRate.Size = new Size(262, 29);
			lblShowHourlyRate.TabIndex = 32;
			lblShowHourlyRate.TextAlign = ContentAlignment.MiddleCenter;
			// 
			// lblShowReplacementCar
			// 
			lblShowReplacementCar.BackColor = Color.WhiteSmoke;
			lblShowReplacementCar.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
			lblShowReplacementCar.Location = new Point(302, 107);
			lblShowReplacementCar.Name = "lblShowReplacementCar";
			lblShowReplacementCar.Size = new Size(262, 29);
			lblShowReplacementCar.TabIndex = 33;
			lblShowReplacementCar.TextAlign = ContentAlignment.MiddleCenter;
			// 
			// lblShowIsInGarage
			// 
			lblShowIsInGarage.BackColor = Color.WhiteSmoke;
			lblShowIsInGarage.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
			lblShowIsInGarage.Location = new Point(302, 249);
			lblShowIsInGarage.Name = "lblShowIsInGarage";
			lblShowIsInGarage.Size = new Size(262, 29);
			lblShowIsInGarage.TabIndex = 37;
			lblShowIsInGarage.TextAlign = ContentAlignment.MiddleCenter;
			// 
			// lblShowActiveInFleet
			// 
			lblShowActiveInFleet.BackColor = Color.WhiteSmoke;
			lblShowActiveInFleet.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
			lblShowActiveInFleet.Location = new Point(302, 176);
			lblShowActiveInFleet.Name = "lblShowActiveInFleet";
			lblShowActiveInFleet.Size = new Size(262, 29);
			lblShowActiveInFleet.TabIndex = 36;
			lblShowActiveInFleet.TextAlign = ContentAlignment.MiddleCenter;
			// 
			// label8
			// 
			label8.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
			label8.Location = new Point(302, 224);
			label8.Name = "label8";
			label8.Size = new Size(262, 25);
			label8.TabIndex = 35;
			label8.Text = "Is It In Garage?";
			label8.TextAlign = ContentAlignment.MiddleCenter;
			// 
			// label9
			// 
			label9.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
			label9.Location = new Point(302, 151);
			label9.Name = "label9";
			label9.Size = new Size(262, 25);
			label9.TabIndex = 34;
			label9.Text = "Is It Active In Fleet?";
			label9.TextAlign = ContentAlignment.MiddleCenter;
			// 
			// CarShow
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			BackColor = Color.LemonChiffon;
			ClientSize = new Size(579, 345);
			Controls.Add(lblShowIsInGarage);
			Controls.Add(lblShowActiveInFleet);
			Controls.Add(label8);
			Controls.Add(label9);
			Controls.Add(lblShowReplacementCar);
			Controls.Add(lblShowHourlyRate);
			Controls.Add(lblShowLicensePlate);
			Controls.Add(lblShowYear);
			Controls.Add(lblShowModel);
			Controls.Add(lblShowBrand);
			Controls.Add(lblAddCarReplacementCar);
			Controls.Add(lblAddCarHourlyRate);
			Controls.Add(lblAddCarlicensePlate);
			Controls.Add(lblAddCarYear);
			Controls.Add(lblAddCarBrand);
			Controls.Add(lblAddCarModel);
			Controls.Add(btnCarShowOk);
			FormBorderStyle = FormBorderStyle.Fixed3D;
			Name = "CarShow";
			ShowIcon = false;
			StartPosition = FormStartPosition.CenterScreen;
			Text = "Car Properties";
			ResumeLayout(false);
		}

		#endregion

		private Label lblAddCarReplacementCar;
		private Label lblAddCarHourlyRate;
		private Label lblAddCarlicensePlate;
		private Label lblAddCarYear;
		private Label lblAddCarBrand;
		private Label lblAddCarModel;
		private Button btnCarShowOk;
		private Label lblShowBrand;
		private Label lblShowModel;
		private Label lblShowYear;
		private Label lblShowLicensePlate;
		private Label lblShowHourlyRate;
		private Label lblShowReplacementCar;
		private Label lblShowIsInGarage;
		private Label lblShowActiveInFleet;
		private Label label8;
		private Label label9;
	}
}