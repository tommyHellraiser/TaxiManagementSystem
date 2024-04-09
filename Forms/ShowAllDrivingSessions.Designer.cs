namespace TaxiManagement.Forms
{
	partial class ShowAllDrivingSessions
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
			btnShowOpenDrivingSessionsOk = new Button();
			grdShowOpenDrivingSessions = new DataGridView();
			((System.ComponentModel.ISupportInitialize)grdShowOpenDrivingSessions).BeginInit();
			SuspendLayout();
			// 
			// btnShowOpenDrivingSessionsOk
			// 
			btnShowOpenDrivingSessionsOk.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
			btnShowOpenDrivingSessionsOk.Location = new Point(351, 270);
			btnShowOpenDrivingSessionsOk.Name = "btnShowOpenDrivingSessionsOk";
			btnShowOpenDrivingSessionsOk.Size = new Size(166, 42);
			btnShowOpenDrivingSessionsOk.TabIndex = 19;
			btnShowOpenDrivingSessionsOk.Text = "OK";
			btnShowOpenDrivingSessionsOk.UseVisualStyleBackColor = true;
			btnShowOpenDrivingSessionsOk.Click += btnShowOpenDrivingSessionsOk_Click;
			// 
			// grdShowOpenDrivingSessions
			// 
			grdShowOpenDrivingSessions.AllowUserToAddRows = false;
			grdShowOpenDrivingSessions.AllowUserToDeleteRows = false;
			grdShowOpenDrivingSessions.BackgroundColor = Color.LemonChiffon;
			grdShowOpenDrivingSessions.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			grdShowOpenDrivingSessions.GridColor = SystemColors.ControlDark;
			grdShowOpenDrivingSessions.Location = new Point(12, 12);
			grdShowOpenDrivingSessions.Name = "grdShowOpenDrivingSessions";
			grdShowOpenDrivingSessions.ReadOnly = true;
			grdShowOpenDrivingSessions.Size = new Size(843, 252);
			grdShowOpenDrivingSessions.TabIndex = 18;
			// 
			// ShowAllDrivingSessions
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			BackColor = Color.LemonChiffon;
			ClientSize = new Size(867, 320);
			Controls.Add(btnShowOpenDrivingSessionsOk);
			Controls.Add(grdShowOpenDrivingSessions);
			FormBorderStyle = FormBorderStyle.Fixed3D;
			MaximizeBox = false;
			Name = "ShowAllDrivingSessions";
			ShowIcon = false;
			StartPosition = FormStartPosition.CenterScreen;
			Text = "Open Driving Sessions";
			((System.ComponentModel.ISupportInitialize)grdShowOpenDrivingSessions).EndInit();
			ResumeLayout(false);
		}

		#endregion

		private Button btnShowOpenDrivingSessionsOk;
		private DataGridView grdShowOpenDrivingSessions;
	}
}