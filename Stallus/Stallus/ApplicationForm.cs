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

        private void btnRegistrate_Click(object sender, EventArgs e)
        {
            string columNames = "";
            string newValues = ""; 
            if (!string.IsNullOrWhiteSpace(tbChangeFirstname.Text))
            {
                columNames += "First_name%";
                newValues += tbChangeFirstname.Text;
            }
            if (!string.IsNullOrWhiteSpace(tbChangeLastname.Text))
            {
                columNames += "Last_name%";
                newValues += tbChangeLastname.Text;
            }
            if (!string.IsNullOrWhiteSpace(tbChangeEmail.Text))
            {
                columNames += "Email_Address%";
                newValues += tbChangeEmail.Text;
            }
            if (!string.IsNullOrWhiteSpace(tbChangePassword.Text))
            {
                columNames += "Password%";
                newValues += tbChangePassword.Text;
            }
            if (!string.IsNullOrWhiteSpace(tbChangeStreet.Text) && !string.IsNullOrWhiteSpace(tbChangeNumber.Text) && !string.IsNullOrWhiteSpace(tbChangeZipcode.Text) && !string.IsNullOrWhiteSpace(tbChangeCity.Text) && !string.IsNullOrWhiteSpace(tbChangeCountry.Text))
            {
                columNames += "Adress%";
                Address address = new Address(tbChangeStreet.Text, tbChangeNumber.Text, tbChangeZipcode.Text, tbChangeCity.Text, tbChangeCountry.Text);
                newValues += address;
            }
            client.ChangeDetails(client.ValuesStringTrimmer(columNames), client.ValuesStringTrimmer(newValues));
        }
    }
}
