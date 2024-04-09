namespace TaxiManagement.Forms
{
	partial class InputDocument
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
			lblSearchDocument = new Label();
			btnSearchDocumentConfirm = new Button();
			txtSearchDocument = new TextBox();
			SuspendLayout();
			// 
			// lblSearchDocument
			// 
			lblSearchDocument.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
			lblSearchDocument.Location = new Point(12, 9);
			lblSearchDocument.Name = "lblSearchDocument";
			lblSearchDocument.Size = new Size(262, 25);
			lblSearchDocument.TabIndex = 16;
			lblSearchDocument.Text = "Enter Document";
			lblSearchDocument.TextAlign = ContentAlignment.MiddleCenter;
			// 
			// btnSearchDocumentConfirm
			// 
			btnSearchDocumentConfirm.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
			btnSearchDocumentConfirm.Location = new Point(60, 72);
			btnSearchDocumentConfirm.Name = "btnSearchDocumentConfirm";
			btnSearchDocumentConfirm.Size = new Size(166, 42);
			btnSearchDocumentConfirm.TabIndex = 15;
			btnSearchDocumentConfirm.Text = "Confirm!";
			btnSearchDocumentConfirm.UseVisualStyleBackColor = true;
			btnSearchDocumentConfirm.Click += btnSearchDocumentConfirm_Click;
			// 
			// txtSearchDocument
			// 
			txtSearchDocument.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
			txtSearchDocument.Location = new Point(12, 37);
			txtSearchDocument.Name = "txtSearchDocument";
			txtSearchDocument.Size = new Size(262, 29);
			txtSearchDocument.TabIndex = 14;
			// 
			// InputDocument
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			BackColor = Color.LemonChiffon;
			ClientSize = new Size(283, 125);
			Controls.Add(lblSearchDocument);
			Controls.Add(btnSearchDocumentConfirm);
			Controls.Add(txtSearchDocument);
			FormBorderStyle = FormBorderStyle.Fixed3D;
			MaximizeBox = false;
			Name = "InputDocument";
			ShowIcon = false;
			StartPosition = FormStartPosition.CenterScreen;
			Text = "Search";
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Label lblSearchDocument;
		private Button btnSearchDocumentConfirm;
		private TextBox txtSearchDocument;
	}
}