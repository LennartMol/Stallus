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
        public LoginForm()
        {
            InitializeComponent();
        }

        private void BtOpenApplication_Click(object sender, EventArgs e)
        {

                ApplicationForm app = new ApplicationForm();
                this.Hide();
                app.ShowDialog();

        }

        private void btnRegistrate_Click(object sender, EventArgs e)
        {
            bool emailCheck = false;
            string name = tbRegistrateFirstName.Text + " " + tbRegistrateLastName.Text;

            if (!string.IsNullOrWhiteSpace(tbRegistrateStreet.Text) && !string.IsNullOrWhiteSpace(tbRegistrateNumber.Text) && !string.IsNullOrWhiteSpace(tbRegistrateZipcode.Text) && !string.IsNullOrWhiteSpace(tbRegistrateCity.Text))
            {
                Address address = new Address(tbRegistrateStreet.Text, tbRegistrateNumber.Text, tbRegistrateZipcode.Text, tbRegistrateCity.Text);

                var emailaddr = new System.Net.Mail.MailAddress(tbRegistrateEmail.Text);
                if (emailaddr.Address == tbRegistrateEmail.Text)
                {
                    emailCheck = true;
                    if (name != " " && tbRegistratePassword.Text.Length > 6 && emailCheck)
                    {
                        Customer customer = new Customer(name, tbRegistratePassword.Text, dtpRegistrateDateOfBirth.Value, tbRegistrateEmail.Text, 0, address);
                    }
                }
            }

            


            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var emailaddr = new System.Net.Mail.MailAddress(tbRegistrateEmail.Text);
            MessageBox.Show(emailaddr.ToString());
        }
    }
}
