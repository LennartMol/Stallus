using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QRCoder;
using System.IO;

namespace Stallus
{
    public partial class ApplicationForm : Form
    {
        private TCP_Client client;
        private User loggedinUser;

        public ApplicationForm(User loggedinUser)
        {
            this.loggedinUser = loggedinUser;
            InitializeComponent();
            ProcessAllStandId();
            client = new TCP_Client();
        }

        private void BtnLockBicycle_Click(object sender, EventArgs e)
        {
            if (client.LockBike(cbStandIds.SelectedText, loggedinUser))
            {
                DateTime time = DateTime.Now;
                lInCheckTime.Text = time.ToShortTimeString();
            }
        }

        private void BtnUnlockBicycle_Click(object sender, EventArgs e)
        {
            if (loggedinUser.CheckAmount(client.Req_Price(loggedinUser)))
            {
                QRcode qRcode = new QRcode(client.Req_VerificationKey(loggedinUser));
                pbQRCode.Image = qRcode.GenerateQrCode();
            }
        }

    private void btnRaiseBalance_Click(object sender, EventArgs e)
    {
        if (client.CheckConnection())
        {
            if (rb5.Checked)
            {
                client.RaiseBalance(loggedinUser, 5);
            }
            else if (rb10.Checked)
            {
                client.RaiseBalance(loggedinUser, 10);
            }
            else if (rb15.Checked)
            {
                client.RaiseBalance(loggedinUser, 15);
            }
            else if (rb10.Checked)
            {
                client.RaiseBalance(loggedinUser, 20);
            }
        }
        else MessageBox.Show("Problem with connecting to the server");
    }

    private void ProcessAllStandId()
    {
       foreach (string standId in client.Req_AllStandId())
        {
            cbStandIds.Items.Add(standId);
        }
    }

        private void btnChangeDetails_Click(object sender, EventArgs e)
        {
            List<TextBox> textBoxes = new List<TextBox>();
            List<string> textBoxInfo = new List<string>();
            string[] columNames = new string[8];
            string[] newValues = new string[8];
            int index = 0;
            
            foreach (Control control in tabPage3.Controls)
            {
                if (control is TextBox)
                {
                    textBoxInfo.Add(control.Text);
                    textBoxes.Add((TextBox)control);
                    Console.WriteLine(control);
                }
            }

            foreach (TextBox tb in textBoxes)
            {
                if ((string)tb.Tag == "first_name")
                {
                    if (tb.Text != loggedinUser.FirstName)
                    {
                        columNames[index] = tb.Tag + "%";
                        newValues[index] = tb.Text;
                        index++;
                    }
                }
                else if ((string)tb.Tag == "last_name")
                {
                    if (tb.Text != loggedinUser.LastName)
                    {
                        columNames[index] = tb.Tag + "%";
                        newValues[index] = tb.Text;
                        index++;
                    }
                }
                else if((string)tb.Tag == "email_address")
                {
                    if (tb.Text != loggedinUser.Email)
                    {
                        columNames[index] = tb.Tag + "%";
                        newValues[index] = tb.Text;
                        index++;
                    }
                }
                else if((string)tb.Tag == "password")
                {
                    if (tb.Text != loggedinUser.Password)
                    {
                        columNames[index] = tb.Tag + "%";
                        newValues[index] = tb.Text;
                        index++;
                    }
                }
                else if((string)tb.Tag == "street" || (string)tb.Tag == "number" || (string)tb.Tag == "zipcode" || (string)tb.Tag == "city" || (string)tb.Tag == "country")
                {
                    Address address = loggedinUser.Address;
                    if (!loggedinUser.Address.ToString().Contains(tbStreet.Text))
                    {
                        address.ChangeStreet(tb.Text);
                    }
                    else if (!loggedinUser.Address.ToString().Contains(tbNumber.Text))
                    {
                        address.ChangeNumber(tb.Text);
                    }
                    else if (!loggedinUser.Address.ToString().Contains(tbZipcode.Text))
                    {
                        address.ChangeZipcode(tb.Text);
                    }
                    else if (!loggedinUser.Address.ToString().Contains(tbCity.Text))
                    {
                        address.ChangeCity(tb.Text);
                    }
                    else if (!loggedinUser.Address.ToString().Contains(tbCountry.Text))
                    {
                        address.ChangeCounty(tb.Text);
                    }
                    columNames[index] = "physical_address";
                    newValues[index] = address.ToString();
                    index++;
                }
            }



        }


    }
}
