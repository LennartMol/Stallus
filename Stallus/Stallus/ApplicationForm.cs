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
            QRcode qRcode = new QRcode("7499");
            lShowString.Text = "String in QR code: " + qRcode.QrString;
            pbQRCode.Image = qRcode.GenerateQrCode();
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

    }
}
