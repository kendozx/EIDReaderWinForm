using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EIDReaderWinForm
{
    public partial class Option : Form
    {
        public Option()
        {
            InitializeComponent();
            InitEndPoint();
            cbEndPoint.SelectedValue = Properties.Settings.Default.OdataUri;
            txtCompanyID.Text = Properties.Settings.Default.CompanyID;
            txtUsername.Text = Properties.Settings.Default.Username;
            txtPassword.Text = Properties.Settings.Default.Password;
        }

        private void InitEndPoint()
        {
            var dict = new Dictionary<string, string>();
            dict.Add("", "Select Data Center");
            dict.Add("https://api2.successfactors.eu", "Amsterdam2/HCM(DC2) - Production");
            dict.Add("https://apisalesdemo2.successfactors.eu", "Amsterdam2/HCM(DC2) - SalesDemo");
            dict.Add("https://api2preview.sapsf.eu", "Amsterdam2/HCM(DC2) - Preview");
            dict.Add("https://api4.successfactors.com", "Chandler1/HCM (DC4) - Production");
            dict.Add("https://apisalesdemo4.successfactors.com", "Chandler1/HCM (DC4) - SalesDemo");
            dict.Add("https://api4preview.sapsf.com", "Chandler1/HCM (DC4) - Preview");
            dict.Add("https://api5.successfactors.eu", "DC 5 - Production");
            dict.Add("https://api8.successfactors.com ", "Ashburn1/HCM (DC8) - Production");
            dict.Add("https://apisalesdemo8.successfactors.com", "Ashburn1/HCM (DC8) - SalesDemo");
            dict.Add("https://api8preview.sapsf.com", "Ashburn1/HCM (DC8) - Preview");
            dict.Add("https://api10.successfactors.com", "Sydney1/HCM (DC10) - Production");
            dict.Add("https://api10preview.sapsf.com", "Sydney1/HCM (DC10) - Preview");
            dict.Add("https://api012.successfactors.eu", "Rot1/HCM (DC12) - Production");
            dict.Add("https://apirot.successfactors.eu", "Rot1/HCM (DC12) - Rot");
            dict.Add("https://api12preview.sapsf.eu", "Rot1/HCM (DC12) - Preview");
            dict.Add("https://api15.sapsf.cn", "Shanghai1/HCM (DC15) - Production");
            dict.Add("https://api16.sapsf.eu", "Magdeburg1/HCM(DC16) - Production");
            dict.Add("https://api17preview.sapsf.com", "Toronto1/HCM(DC17) - Preview");
            dict.Add("https://api17.sapsf.com", "Toronto1/HCM(DC17) - Production");
            dict.Add("https://api18preview.sapsf.com", "Moscow1/HCM (DC18) - Preview");
            dict.Add("https://api18.sapsf.com", "Moscow1/HCM (DC18) - Production");

            cbEndPoint.DataSource = new BindingSource(dict, null);
            cbEndPoint.DisplayMember = "Value";
            cbEndPoint.ValueMember = "Key";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Change option?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                if (cbEndPoint.SelectedValue.ToString() == String.Empty ||
                    txtCompanyID.Text == String.Empty ||
                    txtPassword.Text == String.Empty || 
                    txtUsername.Text == String.Empty)
                {
                    MessageBox.Show("All fields are required", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    Properties.Settings.Default.CompanyID = txtCompanyID.Text;
                    Properties.Settings.Default.Username = txtUsername.Text;
                    Properties.Settings.Default.Password = txtPassword.Text;
                    Properties.Settings.Default.OdataUri = cbEndPoint.SelectedValue.ToString();
                    Properties.Settings.Default.Save();
                    this.Close();
                }
            }
        }

        private void cbEndPoint_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbEndPoint.Text = cbEndPoint.SelectedValue.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
