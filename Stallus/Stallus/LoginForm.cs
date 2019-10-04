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
            ApplicationForm app = new ApplicationForm();
            this.Hide();
            app.ShowDialog();
        }
    }
}
