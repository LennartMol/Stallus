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
            this.tbLoginEmail = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbLoginPassword = new System.Windows.Forms.TextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label12 = new System.Windows.Forms.Label();
            this.tbRegistrateCountry = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.dtpRegistrateDateOfBirth = new System.Windows.Forms.DateTimePicker();
            this.tbRegistrateFirstName = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.tbRegistrateLastName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.tbRegistrateCity = new System.Windows.Forms.TextBox();
            this.tbRegistrateNumber = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tbRegistrateZipcode = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tbRegistrateEmail = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbRegistrateStreet = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnRegistrate = new System.Windows.Forms.Button();
            this.tbRegistratePassword = new System.Windows.Forms.TextBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btOpenApplication
            // 
            this.btOpenApplication.Location = new System.Drawing.Point(336, 222);
            this.btOpenApplication.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btOpenApplication.Name = "btOpenApplication";
            this.btOpenApplication.Size = new System.Drawing.Size(84, 34);
            this.btOpenApplication.TabIndex = 3;
            this.btOpenApplication.Text = "Login";
            this.btOpenApplication.UseVisualStyleBackColor = true;
            this.btOpenApplication.Click += new System.EventHandler(this.BtLogin_Click);
            // 
            // tbLoginEmail
            // 
            this.tbLoginEmail.Location = new System.Drawing.Point(296, 117);
            this.tbLoginEmail.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbLoginEmail.Name = "tbLoginEmail";
            this.tbLoginEmail.Size = new System.Drawing.Size(164, 22);
            this.tbLoginEmail.TabIndex = 1;
            this.tbLoginEmail.Text = "admin";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(356, 97);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Email:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(347, 160);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Password:";
            // 
            // tbLoginPassword
            // 
            this.tbLoginPassword.Location = new System.Drawing.Point(296, 180);
            this.tbLoginPassword.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbLoginPassword.Name = "tbLoginPassword";
            this.tbLoginPassword.PasswordChar = '*';
            this.tbLoginPassword.Size = new System.Drawing.Size(164, 22);
            this.tbLoginPassword.TabIndex = 2;
            this.tbLoginPassword.Text = "Stallus";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(776, 426);
            this.tabControl1.TabIndex = 5;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.tbLoginEmail);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.btOpenApplication);
            this.tabPage1.Controls.Add(this.tbLoginPassword);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage1.Size = new System.Drawing.Size(768, 397);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Login";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label12);
            this.tabPage2.Controls.Add(this.tbRegistrateCountry);
            this.tabPage2.Controls.Add(this.label11);
            this.tabPage2.Controls.Add(this.dtpRegistrateDateOfBirth);
            this.tabPage2.Controls.Add(this.tbRegistrateFirstName);
            this.tabPage2.Controls.Add(this.label10);
            this.tabPage2.Controls.Add(this.tbRegistrateLastName);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.label9);
            this.tabPage2.Controls.Add(this.tbRegistrateCity);
            this.tabPage2.Controls.Add(this.tbRegistrateNumber);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.tbRegistrateZipcode);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.tbRegistrateEmail);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.tbRegistrateStreet);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.btnRegistrate);
            this.tabPage2.Controls.Add(this.tbRegistratePassword);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage2.Size = new System.Drawing.Size(768, 397);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Registrate";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(419, 162);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(61, 17);
            this.label12.TabIndex = 27;
            this.label12.Text = "Country:";
            // 
            // tbRegistrateCountry
            // 
            this.tbRegistrateCountry.Location = new System.Drawing.Point(523, 160);
            this.tbRegistrateCountry.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbRegistrateCountry.Name = "tbRegistrateCountry";
            this.tbRegistrateCountry.Size = new System.Drawing.Size(164, 22);
            this.tbRegistrateCountry.TabIndex = 26;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(419, 52);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(90, 17);
            this.label11.TabIndex = 25;
            this.label11.Text = "Date of birth:";
            // 
            // dtpRegistrateDateOfBirth
            // 
            this.dtpRegistrateDateOfBirth.Location = new System.Drawing.Point(523, 47);
            this.dtpRegistrateDateOfBirth.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtpRegistrateDateOfBirth.Name = "dtpRegistrateDateOfBirth";
            this.dtpRegistrateDateOfBirth.Size = new System.Drawing.Size(200, 22);
            this.dtpRegistrateDateOfBirth.TabIndex = 10;
            // 
            // tbRegistrateFirstName
            // 
            this.tbRegistrateFirstName.Location = new System.Drawing.Point(192, 44);
            this.tbRegistrateFirstName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbRegistrateFirstName.Name = "tbRegistrateFirstName";
            this.tbRegistrateFirstName.Size = new System.Drawing.Size(164, 22);
            this.tbRegistrateFirstName.TabIndex = 4;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(69, 47);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(78, 17);
            this.label10.TabIndex = 23;
            this.label10.Text = "First name:";
            // 
            // tbRegistrateLastName
            // 
            this.tbRegistrateLastName.Location = new System.Drawing.Point(192, 75);
            this.tbRegistrateLastName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbRegistrateLastName.Name = "tbRegistrateLastName";
            this.tbRegistrateLastName.Size = new System.Drawing.Size(164, 22);
            this.tbRegistrateLastName.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(69, 78);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 17);
            this.label4.TabIndex = 21;
            this.label4.Text = "Last name:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(419, 127);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(35, 17);
            this.label9.TabIndex = 19;
            this.label9.Text = "City:";
            // 
            // tbRegistrateCity
            // 
            this.tbRegistrateCity.Location = new System.Drawing.Point(523, 124);
            this.tbRegistrateCity.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbRegistrateCity.Name = "tbRegistrateCity";
            this.tbRegistrateCity.Size = new System.Drawing.Size(164, 22);
            this.tbRegistrateCity.TabIndex = 12;
            // 
            // tbRegistrateNumber
            // 
            this.tbRegistrateNumber.Location = new System.Drawing.Point(192, 214);
            this.tbRegistrateNumber.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbRegistrateNumber.Name = "tbRegistrateNumber";
            this.tbRegistrateNumber.Size = new System.Drawing.Size(164, 22);
            this.tbRegistrateNumber.TabIndex = 9;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(419, 89);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 17);
            this.label7.TabIndex = 17;
            this.label7.Text = "Zipcode:";
            // 
            // tbRegistrateZipcode
            // 
            this.tbRegistrateZipcode.Location = new System.Drawing.Point(523, 82);
            this.tbRegistrateZipcode.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbRegistrateZipcode.Name = "tbRegistrateZipcode";
            this.tbRegistrateZipcode.Size = new System.Drawing.Size(164, 22);
            this.tbRegistrateZipcode.TabIndex = 11;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(69, 217);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(62, 17);
            this.label8.TabIndex = 15;
            this.label8.Text = "Number:";
            // 
            // tbRegistrateEmail
            // 
            this.tbRegistrateEmail.Location = new System.Drawing.Point(192, 110);
            this.tbRegistrateEmail.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbRegistrateEmail.Name = "tbRegistrateEmail";
            this.tbRegistrateEmail.Size = new System.Drawing.Size(164, 22);
            this.tbRegistrateEmail.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(69, 177);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 17);
            this.label5.TabIndex = 13;
            this.label5.Text = "Street:";
            // 
            // tbRegistrateStreet
            // 
            this.tbRegistrateStreet.Location = new System.Drawing.Point(192, 174);
            this.tbRegistrateStreet.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbRegistrateStreet.Name = "tbRegistrateStreet";
            this.tbRegistrateStreet.Size = new System.Drawing.Size(164, 22);
            this.tbRegistrateStreet.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(69, 112);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(46, 17);
            this.label6.TabIndex = 11;
            this.label6.Text = "Email:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(69, 146);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 17);
            this.label3.TabIndex = 9;
            this.label3.Text = "Password:";
            // 
            // btnRegistrate
            // 
            this.btnRegistrate.Location = new System.Drawing.Point(327, 281);
            this.btnRegistrate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnRegistrate.Name = "btnRegistrate";
            this.btnRegistrate.Size = new System.Drawing.Size(84, 34);
            this.btnRegistrate.TabIndex = 13;
            this.btnRegistrate.Text = "Registrate";
            this.btnRegistrate.UseVisualStyleBackColor = true;
            this.btnRegistrate.Click += new System.EventHandler(this.btnRegistrate_Click);
            // 
            // tbRegistratePassword
            // 
            this.tbRegistratePassword.Location = new System.Drawing.Point(192, 143);
            this.tbRegistratePassword.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbRegistratePassword.Name = "tbRegistratePassword";
            this.tbRegistratePassword.PasswordChar = '*';
            this.tbRegistratePassword.Size = new System.Drawing.Size(164, 22);
            this.tbRegistratePassword.TabIndex = 7;
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tabControl1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "LoginForm";
            this.Text = "Form1";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btOpenApplication;
        private System.Windows.Forms.TextBox tbLoginEmail;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbLoginPassword;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnRegistrate;
        private System.Windows.Forms.TextBox tbRegistratePassword;
        private System.Windows.Forms.TextBox tbRegistrateEmail;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbRegistrateNumber;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbRegistrateZipcode;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbRegistrateStreet;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tbRegistrateCity;
        private System.Windows.Forms.TextBox tbRegistrateFirstName;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox tbRegistrateLastName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DateTimePicker dtpRegistrateDateOfBirth;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox tbRegistrateCountry;
    }
}