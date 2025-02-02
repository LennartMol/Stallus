﻿using System;
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
        private bool sessionStarted = false;

        public ApplicationForm(User loggedinUser)
        {
            client = new TCP_Client();
            this.loggedinUser = loggedinUser;
            InitializeComponent();
            ProcessAllStandId();
            lSaldo.Text = loggedinUser.Balance.ToString();
            string session = client.Req_Check_Exsisting_session(loggedinUser);
            if (session != null)
            {
                lInCheckTime.Text = session;
                sessionStarted = true;
            }
            LoadForm(sessionStarted);
        }

        private void BtnLockBicycle_Click(object sender, EventArgs e)
        {
            try
            {
                if (client.LockBike(cbStandIds.Text, loggedinUser))
                {
                    DateTime time = DateTime.Now;
                    lInCheckTime.Text = time.ToString();
                    sessionStarted = true;
                }
            }
            catch (ArgumentOutOfRangeException ex)
            {
                MessageBox.Show(ex.Message + "No message received");
            }
            LoadForm(sessionStarted);
        }

        private void BtnUnlockBicycle_Click(object sender, EventArgs e)
        {
            decimal price = client.Req_Price(loggedinUser);
            if (loggedinUser.CheckAmount(price))
            {
                DateTime time = DateTime.Now;
                lOutCheckTime.Text = time.ToString();
                double stringPrice = Convert.ToDouble(price);
                lPrice.Text = stringPrice.ToString();
                QRcode qRcode = new QRcode(client.Req_VerificationKey(loggedinUser));
                pbQRCode.Image = qRcode.GenerateQrCode();
                sessionStarted = false;
            }
            else
            {
                MessageBox.Show("Not enough balance");
                tpSaldo.Show();
            }
            LoadForm(sessionStarted);
        }

        private void btnRaiseBalance_Click(object sender, EventArgs e)
        {
            if (client.CheckConnection())
            {
                if (rb5.Checked)
                {
                    client.ChangeBalance(loggedinUser, 5);
                }
                else if (rb10.Checked)
                {
                    client.ChangeBalance(loggedinUser, 10);
                }
                else if (rb15.Checked)
                {
                    client.ChangeBalance(loggedinUser, 15);
                }
                else if (rb20.Checked)
                {
                    client.ChangeBalance(loggedinUser, 20);
                }
            }
            else MessageBox.Show("Problem with connecting to the server");
            lSaldo.Text = loggedinUser.Balance.ToString();
        }

        private void ProcessAllStandId()
        {
            foreach (string standId in client.Req_AllStandId())
            {
                cbStandIds.Items.Add(standId);
            }
        }

        private void LoadForm(bool sessionStarted)
        {
            if (sessionStarted == true)
            {
                btnLockBicycle.Enabled = false;
                btnUnlockBicycle.Enabled = true;
                cbStandIds.Enabled = false;
                lOutCheckTime.Text = "";
            }
            else
            {
                btnLockBicycle.Enabled = true;
                btnUnlockBicycle.Enabled = false;
                cbStandIds.Enabled = true;
            }
        }

        private void btnChangeDetails_Click(object sender, EventArgs e)
        {
            List<TextBox> textBoxes = new List<TextBox>();
            List<string> textBoxInfo = new List<string>();
            List<string> columnNames = new List<string>();
            List<string> newValues = new List<string>();

            foreach (Control control in tpAcount.Controls)
            {
                if (control is TextBox)
                {
                    textBoxInfo.Add(control.Text);
                    textBoxes.Add((TextBox)control);
                    Console.WriteLine(control);
                }
            }

            foreach (TextBox tb in textBoxes)
            {
                if (!string.IsNullOrWhiteSpace(tb.Text))
                {
                    if ((string)tb.Tag == "first_name")
                    {
                        if (tb.Text != loggedinUser.FirstName)
                        {
                            columnNames.Add(tb.Tag.ToString());
                            newValues.Add(tb.Text);
                        }
                    }
                    else if ((string)tb.Tag == "last_name")
                    {
                        if (tb.Text != loggedinUser.LastName)
                        {
                            columnNames.Add(tb.Tag.ToString());
                            newValues.Add(tb.Text);
                        }
                    }
                    else if ((string)tb.Tag == "email_address")
                    {
                        if (tb.Text != loggedinUser.Email)
                        {
                            columnNames.Add(tb.Tag.ToString());
                            newValues.Add(tb.Text);
                        }
                    }
                    else if ((string)tb.Tag == "password")
                    {
                        if (tb.Text != loggedinUser.Password)
                        {
                            columnNames.Add(tb.Tag.ToString());
                            newValues.Add(tb.Text);
                        }
                    }
                    else if ((string)tb.Tag == "street" || (string)tb.Tag == "number" || (string)tb.Tag == "zipcode" || (string)tb.Tag == "city" || (string)tb.Tag == "country")
                    {
                        Address address = loggedinUser.Address;
                        if (!loggedinUser.Address.ToString().Contains(tbStreet.Text))
                        {
                            address.ChangeStreet(tb.Text);
                        }
                        else if (!loggedinUser.Address.ToString().Contains(tbNumber.Text))
                        {
                            address.ChangeNumber(tb.Text);
                        }
                        else if (!loggedinUser.Address.ToString().Contains(tbZipcode.Text))
                        {
                            address.ChangeZipcode(tb.Text);
                        }
                        else if (!loggedinUser.Address.ToString().Contains(tbCity.Text))
                        {
                            address.ChangeCity(tb.Text);
                        }
                        else if (!loggedinUser.Address.ToString().Contains(tbCountry.Text))
                        {
                            address.ChangeCounty(tb.Text);
                        }
                        columnNames.Add("physical_address");
                        newValues.Add(address.ToString());

                    }
                }
            }
            client.ChangeDetails(loggedinUser, columnNames, newValues);

        }

    }
}
