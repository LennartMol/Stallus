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
            Form popupp = new Form();
            popupp.Text = "Qr code";
            PictureBox pb = new PictureBox();
            pb.Image = Image.FromFile("C:/Users/mpcme/OneDrive/Afbeeldingen/Shrek.JPG");
            pb.Location = new Point(25, 25);
            Size pictureBoxSize = new Size(300, 300);
            pb.Size = pictureBoxSize;
            Size formSize = new Size(365, 385);
            popupp.Size = formSize;
            pb.SizeMode = PictureBoxSizeMode.StretchImage;
            
            popupp.Controls.Add(pb);
            popupp.ShowDialog();

            if (/*Qr scan is success */true)
            {
                popupp.Close();
                ApplicationForm app = new ApplicationForm();
                this.Hide();
                app.ShowDialog();
            }









        }
    }
}
