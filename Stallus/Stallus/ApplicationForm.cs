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
        TCP_Client client;
        public ApplicationForm()
        {
            InitializeComponent();
            client = new TCP_Client();
        }

        private void BtnLockBicycle_Click(object sender, EventArgs e)
        {
            // A message is sent to the main computer to lock the bicycle.
            client.sendMessage("User ID + Lock bicycle");
        }

        private void BtnUnlockBicycle_Click(object sender, EventArgs e)
        {
            // A QR code is generated and the message within the QR code is sent to the main computer.

            string generatedString = Path.GetRandomFileName(); // Create random string.
            generatedString = generatedString.Replace(".", ""); // Remove period.
            generatedString = generatedString.Substring(0, 8);  // Return 8 character string.
            client.sendMessage("User ID + Unlock bicycle + " + generatedString); // Send message to TCP server.

            QRCodeGenerator qrGenerator = new QRCodeGenerator(); // Create a QR with the generatedString.
            QRCodeData qrCodeData = qrGenerator.CreateQrCode("#" + generatedString + "%", QRCodeGenerator.ECCLevel.H);
            QRCode qrCode = new QRCode(qrCodeData);
            Bitmap qrCodeImage = qrCode.GetGraphic(20);
            pbQRCode.Image = qrCodeImage;

            lShowString.Text = "String in QR code: " + generatedString;
        }
    }
}
