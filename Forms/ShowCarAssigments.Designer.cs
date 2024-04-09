namespace TaxiManagement.Forms
{
	partial class ShowCarAssigments
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
			grdCarAssignments = new DataGridView();
			btnShowAssignmentsOk = new Button();
			((System.ComponentModel.ISupportInitialize)grdCarAssignments).BeginInit();
			SuspendLayout();
			// 
			// grdCarAssignments
			// 
			grdCarAssignments.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			grdCarAssignments.Location = new Point(12, 12);
			grdCarAssignments.Name = "grdCarAssignments";
			grdCarAssignments.Size = new Size(943, 264);
			grdCarAssignments.TabIndex = 0;
			// 
			// btnShowAssignmentsOk
			// 
			btnShowAssignmentsOk.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
			btnShowAssignmentsOk.Location = new Point(400, 294);
			btnShowAssignmentsOk.Name = "btnShowAssignmentsOk";
			btnShowAssignmentsOk.Size = new Size(166, 42);
			btnShowAssignmentsOk.TabIndex = 14;
			btnShowAssignmentsOk.Text = "OK";
			btnShowAssignmentsOk.UseVisualStyleBackColor = true;
			btnShowAssignmentsOk.Click += btnShowAssignmentsOk_Click;
			// 
			// ShowCarAssigments
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			BackColor = Color.LemonChiffon;
			ClientSize = new Size(967, 348);
			Controls.Add(btnShowAssignmentsOk);
			Controls.Add(grdCarAssignments);
			FormBorderStyle = FormBorderStyle.Fixed3D;
			MaximizeBox = false;
			Name = "ShowCarAssigments";
			ShowIcon = false;
			StartPosition = FormStartPosition.CenterScreen;
			Text = "Car Assigments";
			((System.ComponentModel.ISupportInitialize)grdCarAssignments).EndInit();
			ResumeLayout(false);
		}

		#endregion

		private DataGridView grdCarAssignments;
		private Button btnShowAssignmentsOk;
	}
}