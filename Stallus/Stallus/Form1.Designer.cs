namespace Stallus
{
    partial class Form1
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
            this.cbLocation = new System.Windows.Forms.ComboBox();
            this.lInCheckTime = new System.Windows.Forms.Label();
            this.lOutCheckTime = new System.Windows.Forms.Label();
            this.btnCheckIn = new System.Windows.Forms.Button();
            this.btnCheckOut = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cbLocation
            // 
            this.cbLocation.FormattingEnabled = true;
            this.cbLocation.Location = new System.Drawing.Point(9, 15);
            this.cbLocation.Name = "cbLocation";
            this.cbLocation.Size = new System.Drawing.Size(121, 24);
            this.cbLocation.TabIndex = 0;
            // 
            // lInCheckTime
            // 
            this.lInCheckTime.AutoSize = true;
            this.lInCheckTime.Location = new System.Drawing.Point(9, 89);
            this.lInCheckTime.Name = "lInCheckTime";
            this.lInCheckTime.Size = new System.Drawing.Size(46, 17);
            this.lInCheckTime.TabIndex = 1;
            this.lInCheckTime.Text = "label1";
            // 
            // lOutCheckTime
            // 
            this.lOutCheckTime.AutoSize = true;
            this.lOutCheckTime.Location = new System.Drawing.Point(249, 89);
            this.lOutCheckTime.Name = "lOutCheckTime";
            this.lOutCheckTime.Size = new System.Drawing.Size(46, 17);
            this.lOutCheckTime.TabIndex = 2;
            this.lOutCheckTime.Text = "label1";
            // 
            // btnCheckIn
            // 
            this.btnCheckIn.Location = new System.Drawing.Point(9, 125);
            this.btnCheckIn.Name = "btnCheckIn";
            this.btnCheckIn.Size = new System.Drawing.Size(80, 25);
            this.btnCheckIn.TabIndex = 3;
            this.btnCheckIn.Text = "Check in";
            this.btnCheckIn.UseVisualStyleBackColor = true;
            // 
            // btnCheckOut
            // 
            this.btnCheckOut.Location = new System.Drawing.Point(252, 125);
            this.btnCheckOut.Name = "btnCheckOut";
            this.btnCheckOut.Size = new System.Drawing.Size(80, 25);
            this.btnCheckOut.TabIndex = 4;
            this.btnCheckOut.Text = "Check out";
            this.btnCheckOut.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnCheckOut);
            this.Controls.Add(this.btnCheckIn);
            this.Controls.Add(this.cbLocation);
            this.Controls.Add(this.lInCheckTime);
            this.Controls.Add(this.lOutCheckTime);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbLocation;
        private System.Windows.Forms.Label lInCheckTime;
        private System.Windows.Forms.Label lOutCheckTime;
        private System.Windows.Forms.Button btnCheckIn;
        private System.Windows.Forms.Button btnCheckOut;
    }
}

