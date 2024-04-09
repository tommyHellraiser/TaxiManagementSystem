namespace TaxiManagement.Forms
{
	partial class InputPayment
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
			lblInputSessionKey = new Label();
			btnInputAmountConfirm = new Button();
			txtInputAmount = new TextBox();
			label1 = new Label();
			lblRentFee = new Label();
			SuspendLayout();
			// 
			// lblInputSessionKey
			// 
			lblInputSessionKey.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
			lblInputSessionKey.Location = new Point(15, 112);
			lblInputSessionKey.Name = "lblInputSessionKey";
			lblInputSessionKey.Size = new Size(262, 25);
			lblInputSessionKey.TabIndex = 22;
			lblInputSessionKey.Text = "Enter Payment Amount";
			lblInputSessionKey.TextAlign = ContentAlignment.MiddleCenter;
			// 
			// btnInputAmountConfirm
			// 
			btnInputAmountConfirm.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
			btnInputAmountConfirm.Location = new Point(63, 175);
			btnInputAmountConfirm.Name = "btnInputAmountConfirm";
			btnInputAmountConfirm.Size = new Size(166, 42);
			btnInputAmountConfirm.TabIndex = 21;
			btnInputAmountConfirm.Text = "Confirm!";
			btnInputAmountConfirm.UseVisualStyleBackColor = true;
			btnInputAmountConfirm.Click += btnInputAmountConfirm_Click;
			// 
			// txtInputAmount
			// 
			txtInputAmount.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
			txtInputAmount.Location = new Point(15, 140);
			txtInputAmount.Name = "txtInputAmount";
			txtInputAmount.Size = new Size(262, 29);
			txtInputAmount.TabIndex = 20;
			// 
			// label1
			// 
			label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
			label1.Location = new Point(13, 9);
			label1.Name = "label1";
			label1.Size = new Size(262, 25);
			label1.TabIndex = 23;
			label1.Text = "Taxi Rent Fee:";
			label1.TextAlign = ContentAlignment.MiddleCenter;
			// 
			// lblRentFee
			// 
			lblRentFee.BorderStyle = BorderStyle.Fixed3D;
			lblRentFee.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
			lblRentFee.ForeColor = Color.ForestGreen;
			lblRentFee.Location = new Point(12, 47);
			lblRentFee.Name = "lblRentFee";
			lblRentFee.Size = new Size(262, 43);
			lblRentFee.TabIndex = 24;
			lblRentFee.TextAlign = ContentAlignment.MiddleCenter;
			// 
			// InputPayment
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			BackColor = Color.LemonChiffon;
			ClientSize = new Size(287, 229);
			Controls.Add(lblRentFee);
			Controls.Add(label1);
			Controls.Add(lblInputSessionKey);
			Controls.Add(btnInputAmountConfirm);
			Controls.Add(txtInputAmount);
			FormBorderStyle = FormBorderStyle.Fixed3D;
			MaximizeBox = false;
			Name = "InputPayment";
			ShowIcon = false;
			StartPosition = FormStartPosition.CenterScreen;
			Text = "Enter Payment";
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Label lblInputSessionKey;
		private Button btnInputAmountConfirm;
		private TextBox txtInputAmount;
		private Label label1;
		private Label lblRentFee;
	}
}