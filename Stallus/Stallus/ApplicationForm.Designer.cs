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
            this.btnUnlockBicycle = new System.Windows.Forms.Button();
            this.tcApplication = new System.Windows.Forms.TabControl();
            this.tpStand = new System.Windows.Forms.TabPage();
            this.cbStandIds = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pbQRCode = new System.Windows.Forms.PictureBox();
            this.btnLockBicycle = new System.Windows.Forms.Button();
            this.lInCheckTime = new System.Windows.Forms.Label();
            this.tpSaldo = new System.Windows.Forms.TabPage();
            this.rb20 = new System.Windows.Forms.RadioButton();
            this.rb15 = new System.Windows.Forms.RadioButton();
            this.rb10 = new System.Windows.Forms.RadioButton();
            this.rb5 = new System.Windows.Forms.RadioButton();
            this.btnRaiseBalance = new System.Windows.Forms.Button();
            this.lSaldo = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tpAcount = new System.Windows.Forms.TabPage();
            this.label12 = new System.Windows.Forms.Label();
            this.tbCountry = new System.Windows.Forms.TextBox();
            this.tbFirstname = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.tbLastname = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.tbCity = new System.Windows.Forms.TextBox();
            this.tbNumber = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tbZipcode = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tbEmail = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbStreet = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.btnChangeDetails = new System.Windows.Forms.Button();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.tcApplication.SuspendLayout();
            this.tpStand.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbQRCode)).BeginInit();
            this.tpSaldo.SuspendLayout();
            this.tpAcount.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnUnlockBicycle
            // 
            this.btnUnlockBicycle.Location = new System.Drawing.Point(249, 116);
            this.btnUnlockBicycle.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnUnlockBicycle.Name = "btnUnlockBicycle";
            this.btnUnlockBicycle.Size = new System.Drawing.Size(116, 25);
            this.btnUnlockBicycle.TabIndex = 4;
            this.btnUnlockBicycle.Text = "Unlock bicycle";
            this.btnUnlockBicycle.UseVisualStyleBackColor = true;
            this.btnUnlockBicycle.Click += new System.EventHandler(this.BtnUnlockBicycle_Click);
            // 
            // tcApplication
            // 
            this.tcApplication.Controls.Add(this.tpStand);
            this.tcApplication.Controls.Add(this.tpSaldo);
            this.tcApplication.Controls.Add(this.tpAcount);
            this.tcApplication.Location = new System.Drawing.Point(12, 12);
            this.tcApplication.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tcApplication.Name = "tcApplication";
            this.tcApplication.SelectedIndex = 0;
            this.tcApplication.Size = new System.Drawing.Size(591, 532);
            this.tcApplication.TabIndex = 5;
            // 
            // tpStand
            // 
            this.tpStand.Controls.Add(this.cbStandIds);
            this.tpStand.Controls.Add(this.label3);
            this.tpStand.Controls.Add(this.label2);
            this.tpStand.Controls.Add(this.pbQRCode);
            this.tpStand.Controls.Add(this.btnUnlockBicycle);
            this.tpStand.Controls.Add(this.btnLockBicycle);
            this.tpStand.Controls.Add(this.lInCheckTime);
            this.tpStand.Location = new System.Drawing.Point(4, 25);
            this.tpStand.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tpStand.Name = "tpStand";
            this.tpStand.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tpStand.Size = new System.Drawing.Size(583, 503);
            this.tpStand.TabIndex = 0;
            this.tpStand.Text = "Stand";
            this.tpStand.UseVisualStyleBackColor = true;
            // 
            // cbStandIds
            // 
            this.cbStandIds.FormattingEnabled = true;
            this.cbStandIds.Location = new System.Drawing.Point(157, 25);
            this.cbStandIds.Name = "cbStandIds";
            this.cbStandIds.Size = new System.Drawing.Size(121, 24);
            this.cbStandIds.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(122, 17);
            this.label3.TabIndex = 9;
            this.label3.Text = "Select your stand:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(249, 176);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(266, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "Scan this QR code to unlock your bicycle";
            // 
            // pbQRCode
            // 
            this.pbQRCode.Location = new System.Drawing.Point(249, 199);
            this.pbQRCode.Margin = new System.Windows.Forms.Padding(4);
            this.pbQRCode.Name = "pbQRCode";
            this.pbQRCode.Size = new System.Drawing.Size(273, 252);
            this.pbQRCode.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbQRCode.TabIndex = 5;
            this.pbQRCode.TabStop = false;
            // 
            // btnLockBicycle
            // 
            this.btnLockBicycle.Location = new System.Drawing.Point(32, 116);
            this.btnLockBicycle.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnLockBicycle.Name = "btnLockBicycle";
            this.btnLockBicycle.Size = new System.Drawing.Size(103, 25);
            this.btnLockBicycle.TabIndex = 3;
            this.btnLockBicycle.Text = "Lock bicycle";
            this.btnLockBicycle.UseVisualStyleBackColor = true;
            this.btnLockBicycle.Click += new System.EventHandler(this.BtnLockBicycle_Click);
            // 
            // lInCheckTime
            // 
            this.lInCheckTime.AutoSize = true;
            this.lInCheckTime.Location = new System.Drawing.Point(32, 80);
            this.lInCheckTime.Name = "lInCheckTime";
            this.lInCheckTime.Size = new System.Drawing.Size(46, 17);
            this.lInCheckTime.TabIndex = 1;
            this.lInCheckTime.Text = "label1";
            // 
            // tpSaldo
            // 
            this.tpSaldo.Controls.Add(this.rb20);
            this.tpSaldo.Controls.Add(this.rb15);
            this.tpSaldo.Controls.Add(this.rb10);
            this.tpSaldo.Controls.Add(this.rb5);
            this.tpSaldo.Controls.Add(this.btnRaiseBalance);
            this.tpSaldo.Controls.Add(this.lSaldo);
            this.tpSaldo.Controls.Add(this.label1);
            this.tpSaldo.Location = new System.Drawing.Point(4, 25);
            this.tpSaldo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tpSaldo.Name = "tpSaldo";
            this.tpSaldo.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tpSaldo.Size = new System.Drawing.Size(583, 503);
            this.tpSaldo.TabIndex = 1;
            this.tpSaldo.Text = "Saldo";
            this.tpSaldo.UseVisualStyleBackColor = true;
            // 
            // rb20
            // 
            this.rb20.AutoSize = true;
            this.rb20.Checked = true;
            this.rb20.Location = new System.Drawing.Point(9, 193);
            this.rb20.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rb20.Name = "rb20";
            this.rb20.Size = new System.Drawing.Size(66, 21);
            this.rb20.TabIndex = 6;
            this.rb20.TabStop = true;
            this.rb20.Text = "€ 20,-";
            this.rb20.UseVisualStyleBackColor = true;
            // 
            // rb15
            // 
            this.rb15.AutoSize = true;
            this.rb15.Location = new System.Drawing.Point(9, 166);
            this.rb15.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rb15.Name = "rb15";
            this.rb15.Size = new System.Drawing.Size(66, 21);
            this.rb15.TabIndex = 5;
            this.rb15.Text = "€ 15,-";
            this.rb15.UseVisualStyleBackColor = true;
            // 
            // rb10
            // 
            this.rb10.AutoSize = true;
            this.rb10.Location = new System.Drawing.Point(9, 139);
            this.rb10.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rb10.Name = "rb10";
            this.rb10.Size = new System.Drawing.Size(66, 21);
            this.rb10.TabIndex = 4;
            this.rb10.Text = "€ 10,-";
            this.rb10.UseVisualStyleBackColor = true;
            // 
            // rb5
            // 
            this.rb5.AutoSize = true;
            this.rb5.Location = new System.Drawing.Point(9, 112);
            this.rb5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rb5.Name = "rb5";
            this.rb5.Size = new System.Drawing.Size(58, 21);
            this.rb5.TabIndex = 3;
            this.rb5.Text = "€ 5,-";
            this.rb5.UseVisualStyleBackColor = true;
            // 
            // btnRaiseBalance
            // 
            this.btnRaiseBalance.AutoSize = true;
            this.btnRaiseBalance.Location = new System.Drawing.Point(9, 220);
            this.btnRaiseBalance.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnRaiseBalance.Name = "btnRaiseBalance";
            this.btnRaiseBalance.Size = new System.Drawing.Size(144, 33);
            this.btnRaiseBalance.TabIndex = 2;
            this.btnRaiseBalance.Text = "Raise balance";
            this.btnRaiseBalance.UseVisualStyleBackColor = true;
            this.btnRaiseBalance.Click += new System.EventHandler(this.btnRaiseBalance_Click);
            // 
            // lSaldo
            // 
            this.lSaldo.AutoSize = true;
            this.lSaldo.Location = new System.Drawing.Point(59, 46);
            this.lSaldo.Name = "lSaldo";
            this.lSaldo.Size = new System.Drawing.Size(16, 17);
            this.lSaldo.TabIndex = 1;
            this.lSaldo.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Saldo:";
            // 
            // tpAcount
            // 
            this.tpAcount.Controls.Add(this.label12);
            this.tpAcount.Controls.Add(this.tbCountry);
            this.tpAcount.Controls.Add(this.tbFirstname);
            this.tpAcount.Controls.Add(this.label10);
            this.tpAcount.Controls.Add(this.tbLastname);
            this.tpAcount.Controls.Add(this.label4);
            this.tpAcount.Controls.Add(this.label9);
            this.tpAcount.Controls.Add(this.tbCity);
            this.tpAcount.Controls.Add(this.tbNumber);
            this.tpAcount.Controls.Add(this.label7);
            this.tpAcount.Controls.Add(this.tbZipcode);
            this.tpAcount.Controls.Add(this.label8);
            this.tpAcount.Controls.Add(this.tbEmail);
            this.tpAcount.Controls.Add(this.label5);
            this.tpAcount.Controls.Add(this.tbStreet);
            this.tpAcount.Controls.Add(this.label6);
            this.tpAcount.Controls.Add(this.label13);
            this.tpAcount.Controls.Add(this.btnChangeDetails);
            this.tpAcount.Controls.Add(this.tbPassword);
            this.tpAcount.Location = new System.Drawing.Point(4, 25);
            this.tpAcount.Name = "tpAcount";
            this.tpAcount.Padding = new System.Windows.Forms.Padding(3);
            this.tpAcount.Size = new System.Drawing.Size(583, 503);
            this.tpAcount.TabIndex = 2;
            this.tpAcount.Text = "Acount Details";
            this.tpAcount.UseVisualStyleBackColor = true;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(273, 194);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(61, 17);
            this.label12.TabIndex = 48;
            this.label12.Text = "Country:";
            // 
            // tbCountry
            // 
            this.tbCountry.Location = new System.Drawing.Point(377, 191);
            this.tbCountry.Name = "tbCountry";
            this.tbCountry.Size = new System.Drawing.Size(164, 22);
            this.tbCountry.TabIndex = 8;
            this.tbCountry.Tag = "country";
            // 
            // tbFirstname
            // 
            this.tbFirstname.Location = new System.Drawing.Point(87, 116);
            this.tbFirstname.Name = "tbFirstname";
            this.tbFirstname.Size = new System.Drawing.Size(164, 22);
            this.tbFirstname.TabIndex = 0;
            this.tbFirstname.Tag = "first_name";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 116);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(78, 17);
            this.label10.TabIndex = 45;
            this.label10.Text = "First name:";
            // 
            // tbLastname
            // 
            this.tbLastname.Location = new System.Drawing.Point(87, 147);
            this.tbLastname.Name = "tbLastname";
            this.tbLastname.Size = new System.Drawing.Size(164, 22);
            this.tbLastname.TabIndex = 1;
            this.tbLastname.Tag = "last_name";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 147);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 17);
            this.label4.TabIndex = 44;
            this.label4.Text = "Last name:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(273, 158);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(35, 17);
            this.label9.TabIndex = 43;
            this.label9.Text = "City:";
            // 
            // tbCity
            // 
            this.tbCity.Location = new System.Drawing.Point(377, 155);
            this.tbCity.Name = "tbCity";
            this.tbCity.Size = new System.Drawing.Size(164, 22);
            this.tbCity.TabIndex = 7;
            this.tbCity.Tag = "city";
            // 
            // tbNumber
            // 
            this.tbNumber.Location = new System.Drawing.Point(87, 286);
            this.tbNumber.Name = "tbNumber";
            this.tbNumber.Size = new System.Drawing.Size(164, 22);
            this.tbNumber.TabIndex = 5;
            this.tbNumber.Tag = "number";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(273, 120);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 17);
            this.label7.TabIndex = 42;
            this.label7.Text = "Zipcode:";
            // 
            // tbZipcode
            // 
            this.tbZipcode.Location = new System.Drawing.Point(377, 114);
            this.tbZipcode.Name = "tbZipcode";
            this.tbZipcode.Size = new System.Drawing.Size(164, 22);
            this.tbZipcode.TabIndex = 6;
            this.tbZipcode.Tag = "zipcode";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 286);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(62, 17);
            this.label8.TabIndex = 41;
            this.label8.Text = "Number:";
            // 
            // tbEmail
            // 
            this.tbEmail.Location = new System.Drawing.Point(87, 181);
            this.tbEmail.Name = "tbEmail";
            this.tbEmail.Size = new System.Drawing.Size(164, 22);
            this.tbEmail.TabIndex = 2;
            this.tbEmail.Tag = "email_address";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 246);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 17);
            this.label5.TabIndex = 40;
            this.label5.Text = "Street:";
            // 
            // tbStreet
            // 
            this.tbStreet.Location = new System.Drawing.Point(87, 246);
            this.tbStreet.Name = "tbStreet";
            this.tbStreet.Size = new System.Drawing.Size(164, 22);
            this.tbStreet.TabIndex = 4;
            this.tbStreet.Tag = "street";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 181);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(46, 17);
            this.label6.TabIndex = 37;
            this.label6.Text = "Email:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(6, 215);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(73, 17);
            this.label13.TabIndex = 33;
            this.label13.Text = "Password:";
            // 
            // btnChangeDetails
            // 
            this.btnChangeDetails.Location = new System.Drawing.Point(227, 354);
            this.btnChangeDetails.Name = "btnChangeDetails";
            this.btnChangeDetails.Size = new System.Drawing.Size(110, 42);
            this.btnChangeDetails.TabIndex = 9;
            this.btnChangeDetails.Text = "Change details";
            this.btnChangeDetails.UseVisualStyleBackColor = true;
            this.btnChangeDetails.Click += new System.EventHandler(this.btnChangeDetails_Click);
            // 
            // tbPassword
            // 
            this.tbPassword.Location = new System.Drawing.Point(87, 215);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.PasswordChar = '*';
            this.tbPassword.Size = new System.Drawing.Size(164, 22);
            this.tbPassword.TabIndex = 3;
            this.tbPassword.Tag = "password";
            // 
            // ApplicationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(949, 641);
            this.Controls.Add(this.tcApplication);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "ApplicationForm";
            this.tcApplication.ResumeLayout(false);
            this.tpStand.ResumeLayout(false);
            this.tpStand.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbQRCode)).EndInit();
            this.tpSaldo.ResumeLayout(false);
            this.tpSaldo.PerformLayout();
            this.tpAcount.ResumeLayout(false);
            this.tpAcount.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnUnlockBicycle;
        private System.Windows.Forms.TabControl tcApplication;
        private System.Windows.Forms.TabPage tpStand;
        private System.Windows.Forms.TabPage tpSaldo;
        private System.Windows.Forms.RadioButton rb20;
        private System.Windows.Forms.RadioButton rb15;
        private System.Windows.Forms.RadioButton rb10;
        private System.Windows.Forms.RadioButton rb5;
        private System.Windows.Forms.Button btnRaiseBalance;
        private System.Windows.Forms.Label lSaldo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pbQRCode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnLockBicycle;
        private System.Windows.Forms.Label lInCheckTime;
        private System.Windows.Forms.ComboBox cbStandIds;
        private System.Windows.Forms.TabPage tpAcount;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox tbCountry;
        private System.Windows.Forms.TextBox tbFirstname;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox tbLastname;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tbCity;
        private System.Windows.Forms.TextBox tbNumber;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbZipcode;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbEmail;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbStreet;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button btnChangeDetails;
        private System.Windows.Forms.TextBox tbPassword;
    }
}

