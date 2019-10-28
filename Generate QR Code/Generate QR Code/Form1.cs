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

namespace Generate_QR_Code
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            Int64 date_context = (DateTime.Now.Year | (DateTime.Now.Month << 7)) | (DateTime.Now.Day << 11);
            Int64 time_context = (DateTime.Now.Second | (DateTime.Now.Minute << 6) | DateTime.Now.Hour << 6);
            Int64 user_id_context = 1 << 32;
            Int64 context = (user_id_context | (time_context << 16)) | date_context;
            QRCodeData qrCodeData = qrGenerator.CreateQrCode("@" + context.ToString() + "&", QRCodeGenerator.ECCLevel.H);
            QRCode qrCode = new QRCode(qrCodeData);     
            Bitmap customImage = new Bitmap(Generate_QR_Code.Properties.Resources.pepe);
            Bitmap qrCodeImage = qrCode.GetGraphic(20, Color.Black, Color.White, customImage, 27);
            pictureBox1.Image = qrCodeImage;
        }
    }
}
