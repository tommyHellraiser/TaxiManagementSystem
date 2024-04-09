namespace TaxiManagement.Forms
{
	partial class PayFee
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
			btnPayFeeConfirm = new Button();
			txtPayFee = new TextBox();
			SuspendLayout();
			// 
			// lblInputSessionKey
			// 
			lblInputSessionKey.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
			lblInputSessionKey.Location = new Point(12, 9);
			lblInputSessionKey.Name = "lblInputSessionKey";
			lblInputSessionKey.Size = new Size(262, 25);
			lblInputSessionKey.TabIndex = 25;
			lblInputSessionKey.Text = "Enter Payment Amount";
			lblInputSessionKey.TextAlign = ContentAlignment.MiddleCenter;
			// 
			// btnPayFeeConfirm
			// 
			btnPayFeeConfirm.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
			btnPayFeeConfirm.Location = new Point(60, 72);
			btnPayFeeConfirm.Name = "btnPayFeeConfirm";
			btnPayFeeConfirm.Size = new Size(166, 42);
			btnPayFeeConfirm.TabIndex = 24;
			btnPayFeeConfirm.Text = "Confirm!";
			btnPayFeeConfirm.UseVisualStyleBackColor = true;
			btnPayFeeConfirm.Click += btnPayFeeConfirm_Click;
			// 
			// txtPayFee
			// 
			txtPayFee.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
			txtPayFee.Location = new Point(12, 37);
			txtPayFee.Name = "txtPayFee";
			txtPayFee.Size = new Size(262, 29);
			txtPayFee.TabIndex = 23;
			// 
			// PayFee
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			BackColor = Color.LemonChiffon;
			ClientSize = new Size(288, 128);
			Controls.Add(lblInputSessionKey);
			Controls.Add(btnPayFeeConfirm);
			Controls.Add(txtPayFee);
			FormBorderStyle = FormBorderStyle.Fixed3D;
			MaximizeBox = false;
			Name = "PayFee";
			ShowIcon = false;
			StartPosition = FormStartPosition.CenterScreen;
			Text = "PayFee";
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Label lblInputSessionKey;
		private Button btnPayFeeConfirm;
		private TextBox txtPayFee;
	}
}