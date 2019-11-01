using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StallusApp
{
    public partial class Main_Form : Form
    {
        QR_Code qr = new QR_Code();
        public Main_Form()
        {
            InitializeComponent();
        }

        private void GenerateQRCode_Button_Click(object sender, EventArgs e)
        {
            GraphicQRCode_PB.Image = qr.GenerateQR_Code("#USER_ID:001%");
        }
    }
}
