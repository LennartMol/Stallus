using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;

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
                 if (client.ReqLogin(tbLoginEmail.Text, tbLoginPassword.Text))
                 {
                     string userid = client.ReceivedData[0];
                     loggedInUser = client.ReqUser(userid);
                     if (loggedInUser != null)
                     {
                        ApplicationForm app = new ApplicationForm(loggedInUser);
                        this.Hide();
                        app.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Problem with connecting to server");
                    }
                }
                else
                {
                    MessageBox.Show("Password doesn't match the emailaddress");
                }
            }
            else MessageBox.Show("Problem with connecting to server");
        }

        private void btnRegistrate_Click(object sender, EventArgs e)
        {
            client = new TCP_Client();
            Address address = new Address(tbRegistrateStreet.Text, tbRegistrateNumber.Text, tbRegistrateZipcode.Text, tbRegistrateCity.Text, tbRegistrateCountry.Text);
            client.Registrate(tbRegistrateFirstName.Text, tbRegistrateLastName.Text, dtpRegistrateDateOfBirth.Value, tbRegistrateEmail.Text, tbRegistratePassword.Text, address);
        }



    }
}
