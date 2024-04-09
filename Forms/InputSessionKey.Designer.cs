namespace TaxiManagement.Forms
{
	partial class InputSessionKey
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
			btnInputSessionKeyConfirm = new Button();
			txtInputSessionKey = new TextBox();
			SuspendLayout();
			// 
			// lblInputSessionKey
			// 
			lblInputSessionKey.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
			lblInputSessionKey.Location = new Point(12, 9);
			lblInputSessionKey.Name = "lblInputSessionKey";
			lblInputSessionKey.Size = new Size(262, 25);
			lblInputSessionKey.TabIndex = 19;
			lblInputSessionKey.Text = "Enter Session Key";
			lblInputSessionKey.TextAlign = ContentAlignment.MiddleCenter;
			// 
			// btnInputSessionKeyConfirm
			// 
			btnInputSessionKeyConfirm.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
			btnInputSessionKeyConfirm.Location = new Point(60, 72);
			btnInputSessionKeyConfirm.Name = "btnInputSessionKeyConfirm";
			btnInputSessionKeyConfirm.Size = new Size(166, 42);
			btnInputSessionKeyConfirm.TabIndex = 18;
			btnInputSessionKeyConfirm.Text = "Confirm!";
			btnInputSessionKeyConfirm.UseVisualStyleBackColor = true;
			btnInputSessionKeyConfirm.Click += btnInputSessionKeyConfirm_Click;
			// 
			// txtInputSessionKey
			// 
			txtInputSessionKey.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
			txtInputSessionKey.Location = new Point(12, 37);
			txtInputSessionKey.Name = "txtInputSessionKey";
			txtInputSessionKey.Size = new Size(262, 29);
			txtInputSessionKey.TabIndex = 17;
			// 
			// InputSessionKey
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			BackColor = Color.LemonChiffon;
			ClientSize = new Size(285, 121);
			Controls.Add(lblInputSessionKey);
			Controls.Add(btnInputSessionKeyConfirm);
			Controls.Add(txtInputSessionKey);
			FormBorderStyle = FormBorderStyle.Fixed3D;
			MaximizeBox = false;
			Name = "InputSessionKey";
			ShowIcon = false;
			StartPosition = FormStartPosition.CenterScreen;
			Text = "Enter Session Key";
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Label lblInputSessionKey;
		private Button btnInputSessionKeyConfirm;
		private TextBox txtInputSessionKey;
	}
}