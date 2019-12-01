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
            client = new TCP_Client();
        }

        private void BtnLockBicycle_Click(object sender, EventArgs e)
        {
            // A message is sent to the main computer to lock the bicycle.
            client.SendMessage("User ID + Lock bicycle");
        }

        private void BtnUnlockBicycle_Click(object sender, EventArgs e)
        {
            QRcode qRcode = new QRcode("7499");
            lShowString.Text = "String in QR code: " + qRcode.QrString;
            pbQRCode.Image = qRcode.GenerateQrCode();
        }

        private void btnRaiseBalance_Click(object sender, EventArgs e)
        {
            client = new TCP_Client();
            if (client.CheckConnection())
            {
                if (rb5.Checked)
                {
                    loggedinUser.RaiseBalance(5);
                }
                else if (rb10.Checked)
                {
                    loggedinUser.RaiseBalance(10);
                }
                else if (rb15.Checked)
                {
                    loggedinUser.RaiseBalance(15);
                }
                else if (rb10.Checked)
                {
                    loggedinUser.RaiseBalance(20);
                }
            }
            else MessageBox.Show("Problem with connecting to the server");
        }

    }
}
