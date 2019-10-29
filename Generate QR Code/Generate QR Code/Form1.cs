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
            ulong user_id = 1;
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            ulong time_context_2 = Convert.ToUInt32(DateTime.Now.Second) | Convert.ToUInt32(DateTime.Now.Minute) << 6 | Convert.ToUInt32(DateTime.Now.Hour) << 12;
            ulong date_context_2 = Convert.ToUInt32(DateTime.Now.Year - 2000) | Convert.ToUInt32(DateTime.Now.Month) << 7 | Convert.ToUInt32(DateTime.Now.Day) << 11;
            ulong context = user_id << 33 | date_context_2 << 17 | time_context_2;
            QRCodeData qrCodeData = qrGenerator.CreateQrCode("@" + context.ToString() + "&", QRCodeGenerator.ECCLevel.H);
            QRCode qrCode = new QRCode(qrCodeData);     
            Bitmap customImage = new Bitmap(Generate_QR_Code.Properties.Resources.pepe);
            Bitmap qrCodeImage = qrCode.GetGraphic(20, Color.Black, Color.White, customImage, 27);
            pictureBox1.Image = qrCodeImage;
        }
    }
}
