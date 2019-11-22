﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Stallus
{
    public partial class LoginForm : Form
    {
        private TCP_Client client;
        public LoginForm()
        {
            InitializeComponent();
        }

        private void BtLogin_Click(object sender, EventArgs e)
        {
            client = new TCP_Client();
            client.SendMessage($"DB_REQ_LOGIN:{tbLoginEmail.Text}");
            if (client.MessageHandler()[1] == tbLoginPassword.Text)
            {
                ApplicationForm app = new ApplicationForm();
                this.Hide();
                app.ShowDialog();
            }
            else
            {
                MessageBox.Show("Password doesn't match the email");
            }




            /*
            if (tbLoginPassword.Text == database.StallusLogin(tbLoginEmail.Text))
            {
                ApplicationForm app = new ApplicationForm();
                this.Hide();
                app.ShowDialog();
            }
            else
            {
                MessageBox.Show("Password doesn't match the email");
            }*/

        }

        private void btnRegistrate_Click(object sender, EventArgs e)
        {
            bool emailCheck = false;
            string name = tbRegistrateFirstName.Text + " " + tbRegistrateLastName.Text;
            if (!string.IsNullOrWhiteSpace(tbRegistrateStreet.Text) && !string.IsNullOrWhiteSpace(tbRegistrateNumber.Text) && !string.IsNullOrWhiteSpace(tbRegistrateZipcode.Text) && !string.IsNullOrWhiteSpace(tbRegistrateCity.Text))
            {
                Address address = new Address(tbRegistrateStreet.Text, tbRegistrateNumber.Text, tbRegistrateZipcode.Text, tbRegistrateCity.Text);

                try
                {
                    string cooperation = tbRegistrateEmail.Text.Substring(tbRegistrateEmail.Text.IndexOf('@'));
                    string domain = cooperation.Substring(cooperation.IndexOf('.'));
                    if (!string.IsNullOrWhiteSpace(cooperation) && !string.IsNullOrWhiteSpace(domain) && cooperation.Length > 1 && domain.Length > 1)
                    {
                        emailCheck = true;
                    }
                    else
                    {
                        MessageBox.Show("Not a valid emailaddress");
                    }
                }
                catch
                {
                    MessageBox.Show("Not a valid emailaddress");
                }

                if (!string.IsNullOrWhiteSpace(name) && tbRegistratePassword.Text.Length > 6 && emailCheck)
                {
                    Customer customer = new Customer(tbRegistrateFirstName.Text, tbRegistrateLastName.Text, tbRegistratePassword.Text, dtpRegistrateDateOfBirth.Value, tbRegistrateEmail.Text, 0, address);
                    client = new TCP_Client();
                    client.SendMessage($"DB_INSERT_REGISTRATE:{customer.FirstName}/{customer.LastName}/{customer.DateOfBirth}/{customer.Email}/{customer.Address}/{customer.Password}");
                }
                else
                {
                    MessageBox.Show("The password has to be bigger then 6 characters");
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            client = new TCP_Client();
            client.MessageHandler();
        }
    }
}
