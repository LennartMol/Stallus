namespace Stallus
{
    partial class LoginForm
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
            this.btOpenApplication = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btOpenApplication
            // 
            this.btOpenApplication.Location = new System.Drawing.Point(363, 221);
            this.btOpenApplication.Name = "btOpenApplication";
            this.btOpenApplication.Size = new System.Drawing.Size(75, 23);
            this.btOpenApplication.TabIndex = 0;
            this.btOpenApplication.Text = "Open";
            this.btOpenApplication.UseVisualStyleBackColor = true;
            this.btOpenApplication.Click += new System.EventHandler(this.BtOpenApplication_Click);
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btOpenApplication);
            this.Name = "LoginForm";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btOpenApplication;
    }
}