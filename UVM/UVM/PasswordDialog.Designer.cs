namespace UVM
{
    partial class PasswordDialog
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
            this.PasswordBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.OKBtn = new System.Windows.Forms.Button();
            this.CancelBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // PasswordBox
            // 
            this.PasswordBox.Location = new System.Drawing.Point(12, 25);
            this.PasswordBox.Name = "PasswordBox";
            this.PasswordBox.Size = new System.Drawing.Size(399, 20);
            this.PasswordBox.TabIndex = 0;
            this.PasswordBox.TextChanged += new System.EventHandler(this.PasswordBox_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Password:";
            // 
            // OKBtn
            // 
            this.OKBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OKBtn.Location = new System.Drawing.Point(324, 51);
            this.OKBtn.Name = "OKBtn";
            this.OKBtn.Size = new System.Drawing.Size(87, 27);
            this.OKBtn.TabIndex = 0;
            this.OKBtn.Text = "OK";
            this.OKBtn.UseVisualStyleBackColor = true;
            this.OKBtn.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // CancelBtn
            // 
            this.CancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelBtn.Location = new System.Drawing.Point(231, 51);
            this.CancelBtn.Name = "CancelBtn";
            this.CancelBtn.Size = new System.Drawing.Size(87, 27);
            this.CancelBtn.TabIndex = 3;
            this.CancelBtn.Text = "Cancel";
            this.CancelBtn.UseVisualStyleBackColor = true;
            this.CancelBtn.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // PasswordDialog
            // 
            this.AcceptButton = this.OKBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.CancelBtn;
            this.ClientSize = new System.Drawing.Size(423, 86);
            this.Controls.Add(this.CancelBtn);
            this.Controls.Add(this.OKBtn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.PasswordBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "PasswordDialog";
            this.Text = "Enter an Password";
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.PasswordDialog_KeyUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox PasswordBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button OKBtn;
        private System.Windows.Forms.Button CancelBtn;
    }
}