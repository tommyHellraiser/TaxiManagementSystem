namespace TaxiManagementSystem
{
	partial class HomeScreen
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HomeScreen));
			backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
			pbxDbConnStatus = new PictureBox();
			lblDbConn = new Label();
			btnStartDrivingShift = new Button();
			btnEndDrivingShift = new Button();
			btnAddCarToFleet = new Button();
			btnRemoveCarFromFleet = new Button();
			btnSendCarToRepair = new Button();
			btnReceiveCarFromRepair = new Button();
			btnAddDriver = new Button();
			btnCheckDriverDetails = new Button();
			label1 = new Label();
			label2 = new Label();
			label3 = new Label();
			label4 = new Label();
			label5 = new Label();
			label6 = new Label();
			label7 = new Label();
			btnCheckCarDetails = new Button();
			btnResetDatabase = new Button();
			btnRestoreCar = new Button();
			btnShowAllCarsInGarage = new Button();
			btnShowAllDrivers = new Button();
			btnShowCarAssignments = new Button();
			btnCheckRepairLogs = new Button();
			btnPayPendingFees = new Button();
			btnCheckAllBalances = new Button();
			btnShowOpenDrivingSessions = new Button();
			((System.ComponentModel.ISupportInitialize)pbxDbConnStatus).BeginInit();
			SuspendLayout();
			// 
			// pbxDbConnStatus
			// 
			pbxDbConnStatus.BackColor = Color.Transparent;
			pbxDbConnStatus.BackgroundImageLayout = ImageLayout.Stretch;
			pbxDbConnStatus.Image = TaxiManagement.Properties.Resources.database_conn_error;
			pbxDbConnStatus.Location = new Point(891, 476);
			pbxDbConnStatus.Name = "pbxDbConnStatus";
			pbxDbConnStatus.Size = new Size(30, 30);
			pbxDbConnStatus.SizeMode = PictureBoxSizeMode.StretchImage;
			pbxDbConnStatus.TabIndex = 2;
			pbxDbConnStatus.TabStop = false;
			// 
			// lblDbConn
			// 
			lblDbConn.AutoSize = true;
			lblDbConn.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
			lblDbConn.Location = new Point(811, 480);
			lblDbConn.Name = "lblDbConn";
			lblDbConn.Size = new Size(74, 21);
			lblDbConn.TabIndex = 3;
			lblDbConn.Text = "Db Conn:";
			// 
			// btnStartDrivingShift
			// 
			btnStartDrivingShift.Location = new Point(11, 64);
			btnStartDrivingShift.Name = "btnStartDrivingShift";
			btnStartDrivingShift.Size = new Size(209, 49);
			btnStartDrivingShift.TabIndex = 4;
			btnStartDrivingShift.Text = "Start Driving Shift";
			btnStartDrivingShift.UseVisualStyleBackColor = true;
			btnStartDrivingShift.Click += btnStartDrivingShift_Click;
			// 
			// btnEndDrivingShift
			// 
			btnEndDrivingShift.Location = new Point(226, 64);
			btnEndDrivingShift.Name = "btnEndDrivingShift";
			btnEndDrivingShift.Size = new Size(209, 49);
			btnEndDrivingShift.TabIndex = 5;
			btnEndDrivingShift.Text = "End Driving Shift";
			btnEndDrivingShift.UseVisualStyleBackColor = true;
			btnEndDrivingShift.Click += btnEndDrivingShift_Click;
			// 
			// btnAddCarToFleet
			// 
			btnAddCarToFleet.Location = new Point(500, 96);
			btnAddCarToFleet.Name = "btnAddCarToFleet";
			btnAddCarToFleet.Size = new Size(209, 49);
			btnAddCarToFleet.TabIndex = 6;
			btnAddCarToFleet.Text = "Add Car to Fleet";
			btnAddCarToFleet.UseVisualStyleBackColor = true;
			btnAddCarToFleet.Click += btnAddCarToFleet_Click;
			// 
			// btnRemoveCarFromFleet
			// 
			btnRemoveCarFromFleet.Location = new Point(715, 96);
			btnRemoveCarFromFleet.Name = "btnRemoveCarFromFleet";
			btnRemoveCarFromFleet.Size = new Size(209, 49);
			btnRemoveCarFromFleet.TabIndex = 7;
			btnRemoveCarFromFleet.Text = "Remove Car from Fleet";
			btnRemoveCarFromFleet.UseVisualStyleBackColor = true;
			btnRemoveCarFromFleet.Click += btnRemoveCarFromFleet_Click;
			// 
			// btnSendCarToRepair
			// 
			btnSendCarToRepair.Location = new Point(11, 330);
			btnSendCarToRepair.Name = "btnSendCarToRepair";
			btnSendCarToRepair.Size = new Size(209, 49);
			btnSendCarToRepair.TabIndex = 8;
			btnSendCarToRepair.Text = "Send Car To Repair";
			btnSendCarToRepair.UseVisualStyleBackColor = true;
			btnSendCarToRepair.Click += btnSendCarToRepair_Click;
			// 
			// btnReceiveCarFromRepair
			// 
			btnReceiveCarFromRepair.Location = new Point(226, 330);
			btnReceiveCarFromRepair.Name = "btnReceiveCarFromRepair";
			btnReceiveCarFromRepair.Size = new Size(209, 49);
			btnReceiveCarFromRepair.TabIndex = 9;
			btnReceiveCarFromRepair.Text = "Receive Car From Repair";
			btnReceiveCarFromRepair.UseVisualStyleBackColor = true;
			btnReceiveCarFromRepair.Click += btnReceiveCarFromRepair_Click;
			// 
			// btnAddDriver
			// 
			btnAddDriver.Location = new Point(500, 330);
			btnAddDriver.Name = "btnAddDriver";
			btnAddDriver.Size = new Size(209, 49);
			btnAddDriver.TabIndex = 10;
			btnAddDriver.Text = "Add Driver";
			btnAddDriver.UseVisualStyleBackColor = true;
			btnAddDriver.Click += btnAddDriver_Click;
			// 
			// btnCheckDriverDetails
			// 
			btnCheckDriverDetails.Location = new Point(715, 330);
			btnCheckDriverDetails.Name = "btnCheckDriverDetails";
			btnCheckDriverDetails.Size = new Size(209, 49);
			btnCheckDriverDetails.TabIndex = 11;
			btnCheckDriverDetails.Text = "Check Driver Details";
			btnCheckDriverDetails.UseVisualStyleBackColor = true;
			btnCheckDriverDetails.Click += btnCheckDriverDetails_Click;
			// 
			// label1
			// 
			label1.BorderStyle = BorderStyle.Fixed3D;
			label1.Location = new Point(12, 251);
			label1.Name = "label1";
			label1.Size = new Size(912, 2);
			label1.TabIndex = 12;
			// 
			// label2
			// 
			label2.BorderStyle = BorderStyle.Fixed3D;
			label2.Location = new Point(461, 9);
			label2.Name = "label2";
			label2.Size = new Size(2, 229);
			label2.TabIndex = 13;
			// 
			// label3
			// 
			label3.BorderStyle = BorderStyle.Fixed3D;
			label3.Location = new Point(461, 268);
			label3.Name = "label3";
			label3.Size = new Size(2, 238);
			label3.TabIndex = 14;
			// 
			// label4
			// 
			label4.AutoSize = true;
			label4.Font = new Font("Segoe UI", 21.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
			label4.Location = new Point(12, 21);
			label4.Name = "label4";
			label4.Size = new Size(400, 40);
			label4.TabIndex = 15;
			label4.Text = "Driving Sessions Management";
			// 
			// label5
			// 
			label5.AutoSize = true;
			label5.Font = new Font("Segoe UI", 21.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
			label5.Location = new Point(500, 21);
			label5.Name = "label5";
			label5.Size = new Size(256, 40);
			label5.TabIndex = 16;
			label5.Text = "Fleet Management";
			// 
			// label6
			// 
			label6.AutoSize = true;
			label6.Font = new Font("Segoe UI", 21.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
			label6.Location = new Point(12, 268);
			label6.Name = "label6";
			label6.Size = new Size(238, 40);
			label6.TabIndex = 17;
			label6.Text = "Car Management";
			// 
			// label7
			// 
			label7.AutoSize = true;
			label7.Font = new Font("Segoe UI", 21.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
			label7.Location = new Point(500, 268);
			label7.Name = "label7";
			label7.Size = new Size(283, 40);
			label7.TabIndex = 18;
			label7.Text = "Drivers Management";
			// 
			// btnCheckCarDetails
			// 
			btnCheckCarDetails.Location = new Point(11, 385);
			btnCheckCarDetails.Name = "btnCheckCarDetails";
			btnCheckCarDetails.Size = new Size(209, 49);
			btnCheckCarDetails.TabIndex = 19;
			btnCheckCarDetails.Text = "Check Car Details";
			btnCheckCarDetails.UseVisualStyleBackColor = true;
			btnCheckCarDetails.Click += btnCheckCarDetails_Click;
			// 
			// btnResetDatabase
			// 
			btnResetDatabase.Location = new Point(12, 484);
			btnResetDatabase.Name = "btnResetDatabase";
			btnResetDatabase.Size = new Size(98, 23);
			btnResetDatabase.TabIndex = 20;
			btnResetDatabase.Text = "Reset Database";
			btnResetDatabase.UseVisualStyleBackColor = true;
			btnResetDatabase.Click += btnResetDatabase_Click;
			// 
			// btnRestoreCar
			// 
			btnRestoreCar.Location = new Point(715, 151);
			btnRestoreCar.Name = "btnRestoreCar";
			btnRestoreCar.Size = new Size(209, 49);
			btnRestoreCar.TabIndex = 21;
			btnRestoreCar.Text = "Restore Car To Fleet";
			btnRestoreCar.UseVisualStyleBackColor = true;
			btnRestoreCar.Click += btnRestoreCar_Click;
			// 
			// btnShowAllCarsInGarage
			// 
			btnShowAllCarsInGarage.Location = new Point(500, 151);
			btnShowAllCarsInGarage.Name = "btnShowAllCarsInGarage";
			btnShowAllCarsInGarage.Size = new Size(209, 49);
			btnShowAllCarsInGarage.TabIndex = 22;
			btnShowAllCarsInGarage.Text = "Show All Cars In Fleet";
			btnShowAllCarsInGarage.UseVisualStyleBackColor = true;
			btnShowAllCarsInGarage.Click += btnShowAllCarsInFleet_Click;
			// 
			// btnShowAllDrivers
			// 
			btnShowAllDrivers.Location = new Point(500, 385);
			btnShowAllDrivers.Name = "btnShowAllDrivers";
			btnShowAllDrivers.Size = new Size(209, 49);
			btnShowAllDrivers.TabIndex = 23;
			btnShowAllDrivers.Text = "Show All Drivers";
			btnShowAllDrivers.UseVisualStyleBackColor = true;
			btnShowAllDrivers.Click += btnShowAllDrivers_Click;
			// 
			// btnShowCarAssignments
			// 
			btnShowCarAssignments.Location = new Point(715, 385);
			btnShowCarAssignments.Name = "btnShowCarAssignments";
			btnShowCarAssignments.Size = new Size(209, 49);
			btnShowCarAssignments.TabIndex = 24;
			btnShowCarAssignments.Text = "Show Car Assignments";
			btnShowCarAssignments.UseVisualStyleBackColor = true;
			btnShowCarAssignments.Click += btnShowCarAssignments_Click;
			// 
			// btnCheckRepairLogs
			// 
			btnCheckRepairLogs.Location = new Point(226, 385);
			btnCheckRepairLogs.Name = "btnCheckRepairLogs";
			btnCheckRepairLogs.Size = new Size(209, 49);
			btnCheckRepairLogs.TabIndex = 25;
			btnCheckRepairLogs.Text = "Check Repair Logs";
			btnCheckRepairLogs.UseVisualStyleBackColor = true;
			btnCheckRepairLogs.Click += btnCheckRepairLogs_Click;
			// 
			// btnPayPendingFees
			// 
			btnPayPendingFees.Location = new Point(11, 119);
			btnPayPendingFees.Name = "btnPayPendingFees";
			btnPayPendingFees.Size = new Size(209, 49);
			btnPayPendingFees.TabIndex = 26;
			btnPayPendingFees.Text = "Pay Pending Fees";
			btnPayPendingFees.UseVisualStyleBackColor = true;
			btnPayPendingFees.Click += btnPayPendingFees_Click;
			// 
			// btnCheckAllBalances
			// 
			btnCheckAllBalances.Location = new Point(226, 119);
			btnCheckAllBalances.Name = "btnCheckAllBalances";
			btnCheckAllBalances.Size = new Size(209, 49);
			btnCheckAllBalances.TabIndex = 27;
			btnCheckAllBalances.Text = "Check All Balances";
			btnCheckAllBalances.UseVisualStyleBackColor = true;
			btnCheckAllBalances.Click += btnCheckAllBalances_Click;
			// 
			// btnShowOpenDrivingSessions
			// 
			btnShowOpenDrivingSessions.Location = new Point(123, 174);
			btnShowOpenDrivingSessions.Name = "btnShowOpenDrivingSessions";
			btnShowOpenDrivingSessions.Size = new Size(209, 49);
			btnShowOpenDrivingSessions.TabIndex = 28;
			btnShowOpenDrivingSessions.Text = "Show Open Sessions";
			btnShowOpenDrivingSessions.UseVisualStyleBackColor = true;
			btnShowOpenDrivingSessions.Click += btnShowOpenDrivingSessions_Click;
			// 
			// HomeScreen
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			BackColor = Color.LemonChiffon;
			ClientSize = new Size(933, 519);
			Controls.Add(btnShowOpenDrivingSessions);
			Controls.Add(btnCheckAllBalances);
			Controls.Add(btnPayPendingFees);
			Controls.Add(btnCheckRepairLogs);
			Controls.Add(btnShowCarAssignments);
			Controls.Add(btnShowAllDrivers);
			Controls.Add(btnShowAllCarsInGarage);
			Controls.Add(btnRestoreCar);
			Controls.Add(btnResetDatabase);
			Controls.Add(btnCheckCarDetails);
			Controls.Add(label7);
			Controls.Add(label6);
			Controls.Add(label5);
			Controls.Add(label4);
			Controls.Add(label3);
			Controls.Add(label2);
			Controls.Add(label1);
			Controls.Add(btnCheckDriverDetails);
			Controls.Add(btnAddDriver);
			Controls.Add(btnReceiveCarFromRepair);
			Controls.Add(btnSendCarToRepair);
			Controls.Add(btnRemoveCarFromFleet);
			Controls.Add(btnAddCarToFleet);
			Controls.Add(btnEndDrivingShift);
			Controls.Add(btnStartDrivingShift);
			Controls.Add(lblDbConn);
			Controls.Add(pbxDbConnStatus);
			Icon = (Icon)resources.GetObject("$this.Icon");
			Margin = new Padding(4, 3, 4, 3);
			MaximizeBox = false;
			Name = "HomeScreen";
			SizeGripStyle = SizeGripStyle.Hide;
			Text = "Taxi Management";
			((System.ComponentModel.ISupportInitialize)pbxDbConnStatus).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private System.ComponentModel.BackgroundWorker backgroundWorker1;
		private PictureBox pbxDbConnStatus;
		private Label lblDbConn;
		private Button btnStartDrivingShift;
		private Button btnEndDrivingShift;
		private Button btnAddCarToFleet;
		private Button btnRemoveCarFromFleet;
		private Button btnSendCarToRepair;
		private Button btnReceiveCarFromRepair;
		private Button btnAddDriver;
		private Button btnCheckDriverDetails;
		private Label label1;
		private Label label2;
		private Label label3;
		private Label label4;
		private Label label5;
		private Label label6;
		private Label label7;
		private Button btnCheckCarDetails;
		private Button btnResetDatabase;
		private Button btnRestoreCar;
		private Button btnShowAllCarsInGarage;
		private Button btnShowAllDrivers;
		private Button btnShowCarAssignments;
		private Button btnCheckRepairLogs;
		private Button btnPayPendingFees;
		private Button btnCheckAllBalances;
		private Button btnShowOpenDrivingSessions;
	}
}

