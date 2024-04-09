namespace TaxiManagement.Forms
{
	partial class InputPlate
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
			lblAddCarBrand = new Label();
			btnInputPlateConfirm = new Button();
			txtInputPlate = new TextBox();
			SuspendLayout();
			// 
			// lblAddCarBrand
			// 
			lblAddCarBrand.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
			lblAddCarBrand.Location = new Point(12, 9);
			lblAddCarBrand.Name = "lblAddCarBrand";
			lblAddCarBrand.Size = new Size(262, 25);
			lblAddCarBrand.TabIndex = 13;
			lblAddCarBrand.Text = "Enter License Plate";
			lblAddCarBrand.TextAlign = ContentAlignment.MiddleCenter;
			// 
			// btnInputPlateConfirm
			// 
			btnInputPlateConfirm.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
			btnInputPlateConfirm.Location = new Point(60, 72);
			btnInputPlateConfirm.Name = "btnInputPlateConfirm";
			btnInputPlateConfirm.Size = new Size(166, 42);
			btnInputPlateConfirm.TabIndex = 12;
			btnInputPlateConfirm.Text = "Confirm!";
			btnInputPlateConfirm.UseVisualStyleBackColor = true;
			btnInputPlateConfirm.Click += btnInputPlateConfirm_Click;
			// 
			// txtInputPlate
			// 
			txtInputPlate.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
			txtInputPlate.Location = new Point(12, 37);
			txtInputPlate.Name = "txtInputPlate";
			txtInputPlate.Size = new Size(262, 29);
			txtInputPlate.TabIndex = 11;
			// 
			// InputPlate
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			BackColor = Color.LemonChiffon;
			ClientSize = new Size(287, 130);
			Controls.Add(lblAddCarBrand);
			Controls.Add(btnInputPlateConfirm);
			Controls.Add(txtInputPlate);
			FormBorderStyle = FormBorderStyle.Fixed3D;
			Name = "InputPlate";
			ShowIcon = false;
			StartPosition = FormStartPosition.CenterScreen;
			Text = "Search";
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Label lblAddCarBrand;
		private Button btnInputPlateConfirm;
		private TextBox txtInputPlate;
	}
}