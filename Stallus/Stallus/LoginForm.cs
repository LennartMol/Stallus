using System;
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
        private User loggedInUser;
        public LoginForm()
        {
            InitializeComponent();
        }

        private void BtLogin_Click(object sender, EventArgs e)
        {
            client = new TCP_Client();
            if (client.CheckConnection())
            {
                client.SendMessage($"DB_REQ_LOGIN:{tbLoginEmail.Text}");
                client.GetMessage();
                if (client.ReceivedData[2] == tbLoginPassword.Text)
                {
                    client.SendMessage($"DB_REQ_USER:{client.ReceivedData[0]}");
                    loggedInUser = new User(client.ReceivedData[1], client.ReceivedData[2], client.ReceivedData[5], client.ConvertStringToDateTime(client.ReceivedData[3]), client.ReceivedData[4], Convert.ToDecimal(client.ReceivedData[7]), client.GetAddress(client.ReceivedData[6]));
                    ApplicationForm app = new ApplicationForm();
                    this.Hide();
                    app.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Password doesn't match the email address");
                }
            }
            else MessageBox.Show("Problem with connecting to server");
        }

        private void btnRegistrate_Click(object sender, EventArgs e)
        {
            bool emailCheck = false;
            client = new TCP_Client();
            string name = tbRegistrateFirstName.Text + " " + tbRegistrateLastName.Text;
            if (!string.IsNullOrWhiteSpace(tbRegistrateStreet.Text) && !string.IsNullOrWhiteSpace(tbRegistrateNumber.Text) && !string.IsNullOrWhiteSpace(tbRegistrateZipcode.Text) && !string.IsNullOrWhiteSpace(tbRegistrateCity.Text) && !string.IsNullOrWhiteSpace(tbRegistrateCountry.Text))
            {
                Address address = new Address(tbRegistrateStreet.Text, tbRegistrateNumber.Text, tbRegistrateZipcode.Text, tbRegistrateCity.Text, tbRegistrateCountry.Text);
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


                if (client.CheckConnection())
                {
                    if (!string.IsNullOrWhiteSpace(name) && tbRegistratePassword.Text.Length > 6 && emailCheck)
                    {
                        User customer = new User(tbRegistrateFirstName.Text, tbRegistrateLastName.Text, tbRegistratePassword.Text, dtpRegistrateDateOfBirth.Value, tbRegistrateEmail.Text, 0, address);

                        client.SendMessage($"DB_INSERT_REGISTRATE:{customer.FirstName}/{customer.LastName}/{customer.DateOfBirth}/{customer.Email}/{customer.Address}/{customer.Password}");
                    }
                    else
                    {
                        MessageBox.Show("The password has to be bigger then 6 characters");
                    }
                }
                else MessageBox.Show("Problem with connecting to server");

            }
            else MessageBox.Show("Make sure you fill all the textboxes");
        }
    }
}
