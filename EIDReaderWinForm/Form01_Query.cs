using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin.Controls;
using MaterialSkin;
using System.Xml.Linq;

namespace EIDReaderWinForm
{
    public partial class Form01_Query : MaterialForm
    {
        public Form01_Query()
        {
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            queryEmp();
        }

        private void queryEmp()
        {
            string username = textSearchUser.Text;
            StringBuilder html = new StringBuilder();

            try
            {
                List<SFODataRead.User> lsEmp = ODataQuery.getUser(username);
                dgSearchResult.DataSource = lsEmp.Select(o => new
                { Username = o.username, FirstName = o.firstName, LastName = o.lastName, DateOfBirth = o.dateOfBirth }).ToList();
                dgSearchResult.Columns["FirstName"].HeaderText = "First Name";
                dgSearchResult.Columns["LastName"].HeaderText = "Last Name";
                dgSearchResult.Columns["DateOfBirth"].HeaderText = "Date of Birth";
                lbSearchResult.Text = lsEmp.Count.ToString();
            }
            catch (Exception ex)
            {
                string result;
                try
                {
                    result = ex.InnerException.Message;
                    var str = XElement.Parse(result);
                    result = str.Value;
                }
                catch (Exception e)
                {
                    result = ex.InnerException.Message;
                }
                MessageBox.Show(result, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lbSearchResult.Text = "0";
                dgSearchResult.DataSource = null;
            }
        }
    }
}
