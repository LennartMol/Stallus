namespace Stallus
{
    partial class ApplicationForm
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
            this.btnLockBicycle = new System.Windows.Forms.Button();
            this.btnUnlockBicycle = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.pbQRCode = new System.Windows.Forms.PictureBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.rb20 = new System.Windows.Forms.RadioButton();
            this.rb15 = new System.Windows.Forms.RadioButton();
            this.rb10 = new System.Windows.Forms.RadioButton();
            this.rb5 = new System.Windows.Forms.RadioButton();
            this.button1 = new System.Windows.Forms.Button();
            this.lSaldo = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbQRCode)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbLocation
            // 
            this.cbLocation.FormattingEnabled = true;
            this.cbLocation.Location = new System.Drawing.Point(4, 5);
            this.cbLocation.Margin = new System.Windows.Forms.Padding(2);
            this.cbLocation.Name = "cbLocation";
            this.cbLocation.Size = new System.Drawing.Size(92, 21);
            this.cbLocation.TabIndex = 0;
            // 
            // lInCheckTime
            // 
            this.lInCheckTime.AutoSize = true;
            this.lInCheckTime.Location = new System.Drawing.Point(4, 65);
            this.lInCheckTime.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lInCheckTime.Name = "lInCheckTime";
            this.lInCheckTime.Size = new System.Drawing.Size(35, 13);
            this.lInCheckTime.TabIndex = 1;
            this.lInCheckTime.Text = "label1";
            // 
            // lOutCheckTime
            // 
            this.lOutCheckTime.AutoSize = true;
            this.lOutCheckTime.Location = new System.Drawing.Point(184, 65);
            this.lOutCheckTime.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lOutCheckTime.Name = "lOutCheckTime";
            this.lOutCheckTime.Size = new System.Drawing.Size(35, 13);
            this.lOutCheckTime.TabIndex = 2;
            this.lOutCheckTime.Text = "label1";
            // 
            // btnLockBicycle
            // 
            this.btnLockBicycle.Location = new System.Drawing.Point(4, 94);
            this.btnLockBicycle.Margin = new System.Windows.Forms.Padding(2);
            this.btnLockBicycle.Name = "btnLockBicycle";
            this.btnLockBicycle.Size = new System.Drawing.Size(77, 20);
            this.btnLockBicycle.TabIndex = 3;
            this.btnLockBicycle.Text = "Lock bicycle";
            this.btnLockBicycle.UseVisualStyleBackColor = true;
            this.btnLockBicycle.Click += new System.EventHandler(this.BtnLockBicycle_Click);
            // 
            // btnUnlockBicycle
            // 
            this.btnUnlockBicycle.Location = new System.Drawing.Point(187, 94);
            this.btnUnlockBicycle.Margin = new System.Windows.Forms.Padding(2);
            this.btnUnlockBicycle.Name = "btnUnlockBicycle";
            this.btnUnlockBicycle.Size = new System.Drawing.Size(87, 20);
            this.btnUnlockBicycle.TabIndex = 4;
            this.btnUnlockBicycle.Text = "Unlock bicycle";
            this.btnUnlockBicycle.UseVisualStyleBackColor = true;
            this.btnUnlockBicycle.Click += new System.EventHandler(this.BtnUnlockBicycle_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(9, 10);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(443, 432);
            this.tabControl1.TabIndex = 5;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.pbQRCode);
            this.tabPage1.Controls.Add(this.cbLocation);
            this.tabPage1.Controls.Add(this.btnUnlockBicycle);
            this.tabPage1.Controls.Add(this.lOutCheckTime);
            this.tabPage1.Controls.Add(this.btnLockBicycle);
            this.tabPage1.Controls.Add(this.lInCheckTime);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(2);
            this.tabPage1.Size = new System.Drawing.Size(435, 406);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Stand";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // pbQRCode
            // 
            this.pbQRCode.Location = new System.Drawing.Point(187, 162);
            this.pbQRCode.Name = "pbQRCode";
            this.pbQRCode.Size = new System.Drawing.Size(205, 205);
            this.pbQRCode.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbQRCode.TabIndex = 5;
            this.pbQRCode.TabStop = false;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.rb20);
            this.tabPage2.Controls.Add(this.rb15);
            this.tabPage2.Controls.Add(this.rb10);
            this.tabPage2.Controls.Add(this.rb5);
            this.tabPage2.Controls.Add(this.button1);
            this.tabPage2.Controls.Add(this.lSaldo);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(2);
            this.tabPage2.Size = new System.Drawing.Size(435, 406);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Saldo";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // rb20
            // 
            this.rb20.AutoSize = true;
            this.rb20.Checked = true;
            this.rb20.Location = new System.Drawing.Point(7, 157);
            this.rb20.Margin = new System.Windows.Forms.Padding(2);
            this.rb20.Name = "rb20";
            this.rb20.Size = new System.Drawing.Size(52, 17);
            this.rb20.TabIndex = 6;
            this.rb20.TabStop = true;
            this.rb20.Text = "€ 20,-";
            this.rb20.UseVisualStyleBackColor = true;
            // 
            // rb15
            // 
            this.rb15.AutoSize = true;
            this.rb15.Location = new System.Drawing.Point(7, 135);
            this.rb15.Margin = new System.Windows.Forms.Padding(2);
            this.rb15.Name = "rb15";
            this.rb15.Size = new System.Drawing.Size(52, 17);
            this.rb15.TabIndex = 5;
            this.rb15.Text = "€ 15,-";
            this.rb15.UseVisualStyleBackColor = true;
            // 
            // rb10
            // 
            this.rb10.AutoSize = true;
            this.rb10.Location = new System.Drawing.Point(7, 113);
            this.rb10.Margin = new System.Windows.Forms.Padding(2);
            this.rb10.Name = "rb10";
            this.rb10.Size = new System.Drawing.Size(52, 17);
            this.rb10.TabIndex = 4;
            this.rb10.Text = "€ 10,-";
            this.rb10.UseVisualStyleBackColor = true;
            // 
            // rb5
            // 
            this.rb5.AutoSize = true;
            this.rb5.Location = new System.Drawing.Point(7, 91);
            this.rb5.Margin = new System.Windows.Forms.Padding(2);
            this.rb5.Name = "rb5";
            this.rb5.Size = new System.Drawing.Size(46, 17);
            this.rb5.TabIndex = 3;
            this.rb5.Text = "€ 5,-";
            this.rb5.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.AutoSize = true;
            this.button1.Location = new System.Drawing.Point(7, 179);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(85, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Raise balance";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // lSaldo
            // 
            this.lSaldo.AutoSize = true;
            this.lSaldo.Location = new System.Drawing.Point(44, 37);
            this.lSaldo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lSaldo.Name = "lSaldo";
            this.lSaldo.Size = new System.Drawing.Size(13, 13);
            this.lSaldo.TabIndex = 1;
            this.lSaldo.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 37);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Saldo:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(187, 143);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(203, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Scan this QR code to unlock your bicycle";
            // 
            // ApplicationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(712, 521);
            this.Controls.Add(this.tabControl1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ApplicationForm";
            this.Text = "Form1";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbQRCode)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cbLocation;
        private System.Windows.Forms.Label lInCheckTime;
        private System.Windows.Forms.Label lOutCheckTime;
        private System.Windows.Forms.Button btnLockBicycle;
        private System.Windows.Forms.Button btnUnlockBicycle;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.RadioButton rb20;
        private System.Windows.Forms.RadioButton rb15;
        private System.Windows.Forms.RadioButton rb10;
        private System.Windows.Forms.RadioButton rb5;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lSaldo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pbQRCode;
        private System.Windows.Forms.Label label2;
    }
}

