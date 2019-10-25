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

namespace Stallus
{
    public partial class ApplicationForm : Form
    {
        public ApplicationForm()
        {
            InitializeComponent();
        }

        private void BtnLockBicycle_Click(object sender, EventArgs e)
        {
            // A message has to be send to the main computer to lock the bicycle.
        }

        private void BtnUnlockBicycle_Click(object sender, EventArgs e)
        {
            // A QR code is generated and the message within the QR code is send to the main computer to verificate the user's location (is he/she at the bicycle stand?)

            string generatedString = "Test";


            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(generatedString, QRCodeGenerator.ECCLevel.H);
            QRCode qrCode = new QRCode(qrCodeData);
            Bitmap qrCodeImage = qrCode.GetGraphic(20);
            pbQRCode.Image = qrCodeImage;
        }
    }
}
