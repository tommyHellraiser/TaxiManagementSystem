namespace TaxiManagement.Forms
{
	partial class ShowAllRepairLogs
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
			btnShowAllRepairLogsOk = new Button();
			grdShowAllRepairLogs = new DataGridView();
			((System.ComponentModel.ISupportInitialize)grdShowAllRepairLogs).BeginInit();
			SuspendLayout();
			// 
			// btnShowAllRepairLogsOk
			// 
			btnShowAllRepairLogsOk.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
			btnShowAllRepairLogsOk.Location = new Point(150, 290);
			btnShowAllRepairLogsOk.Name = "btnShowAllRepairLogsOk";
			btnShowAllRepairLogsOk.Size = new Size(166, 42);
			btnShowAllRepairLogsOk.TabIndex = 14;
			btnShowAllRepairLogsOk.Text = "OK";
			btnShowAllRepairLogsOk.UseVisualStyleBackColor = true;
			btnShowAllRepairLogsOk.Click += btnShowAllRepairLogsOk_Click;
			// 
			// grdShowAllRepairLogs
			// 
			grdShowAllRepairLogs.AllowUserToAddRows = false;
			grdShowAllRepairLogs.AllowUserToDeleteRows = false;
			grdShowAllRepairLogs.AllowUserToResizeColumns = false;
			grdShowAllRepairLogs.AllowUserToResizeRows = false;
			grdShowAllRepairLogs.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			grdShowAllRepairLogs.Location = new Point(12, 12);
			grdShowAllRepairLogs.Name = "grdShowAllRepairLogs";
			grdShowAllRepairLogs.ReadOnly = true;
			grdShowAllRepairLogs.Size = new Size(443, 272);
			grdShowAllRepairLogs.TabIndex = 15;
			// 
			// ShowAllRepairLogs
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			BackColor = Color.LemonChiffon;
			ClientSize = new Size(467, 339);
			Controls.Add(grdShowAllRepairLogs);
			Controls.Add(btnShowAllRepairLogsOk);
			FormBorderStyle = FormBorderStyle.Fixed3D;
			MaximizeBox = false;
			Name = "ShowAllRepairLogs";
			ShowIcon = false;
			StartPosition = FormStartPosition.CenterScreen;
			Text = "Repair Logs";
			((System.ComponentModel.ISupportInitialize)grdShowAllRepairLogs).EndInit();
			ResumeLayout(false);
		}

		#endregion

		private Button btnShowAllRepairLogsOk;
		private DataGridView grdShowAllRepairLogs;
	}
}