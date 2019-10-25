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
            //ApplicationForm app = new ApplicationForm();
            Form popupp = new Form();
            PictureBox pb = new PictureBox();
            pb.Image = new Bitmap(Properties.Resources.shrek); // Used properties.resources to save image within project instead of a local location.
            pb.Location = new Point(5, 5);
            pb.Width = 200;
            pb.Height = 200;
            pb.SizeMode = PictureBoxSizeMode.StretchImage;
            popupp.Controls.Add(pb);
            popupp.ShowDialog();
            
            this.Hide();
           // app.ShowDialog();
        }
    }
}
