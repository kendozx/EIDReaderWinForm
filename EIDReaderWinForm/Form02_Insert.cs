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
using System.IO;

namespace EIDReaderWinForm
{
    public partial class Form02_Insert : MaterialForm
    {
        public Form02_Insert()
        {
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            initComponent();
            clearValue();
        }

        private void initComponent()
        {
            reloadCardList();

            var dict = new Dictionary<string, string>();
            dict.Add("", "Select Gender");
            dict.Add("F", "F: Female");
            dict.Add("M", "M: Male");
            cbGender.DataSource = new BindingSource(dict, null);
            cbGender.DisplayMember = "Value";
            cbGender.ValueMember = "Key";
            cbGender.SelectedIndex = 0;
        }

        private void reloadCardList()
        {
            var dict = new Dictionary<string, string>();

            string[] array = EIDNative.EIDCard.ListReaders();
            dict.Add("", "Select Card Reader");
            foreach (string str in array)
            {
                dict.Add(str, str);
            }

            cbCardReader.DataSource = new BindingSource(dict, null);
            cbCardReader.DisplayMember = "Value";
            cbCardReader.ValueMember = "Key";
            cbCardReader.SelectedIndex = cbCardReader.Items.Count - 1;
        }


        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void materialLabel9_Click(object sender, EventArgs e)
        {

        }

        private void materialLabel8_Click(object sender, EventArgs e)
        {

        }

        private void materialLabel7_Click(object sender, EventArgs e)
        {

        }

        private void materialLabel6_Click(object sender, EventArgs e)
        {

        }

        private void materialLabel5_Click(object sender, EventArgs e)
        {

        }

        private void materialLabel4_Click(object sender, EventArgs e)
        {

        }

        private void txtNatId_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void txtLastName_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtFirstName_TextChanged(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void materialLabel10_Click(object sender, EventArgs e)
        {

        }

        private void materialLabel1_Click(object sender, EventArgs e)
        {

        }

        private void materialLabel2_Click(object sender, EventArgs e)
        {

        }

        private void cbGender_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dateDOB_ValueChanged(object sender, EventArgs e)
        {

        }

        private void materialRaisedButton5_Click(object sender, EventArgs e)
        {
            clearValue();
        }

        private void clearValue()
        {
            txtFirstName.Text = String.Empty;
            txtLastName.Text = String.Empty;
            txtPassword.Text = String.Empty;
            txtUserID.Text = String.Empty;
            txtUsername.Text = String.Empty;
            cbGender.SelectedIndex = 0;
            dateDOB.Value = DateTime.Today;
            pictureBox1.ImageLocation = String.Empty;
            pictureBox1.Image = Properties.Resources.default_user_icon_profile;
        }

        private void materialRaisedButton6_Click(object sender, EventArgs e)
        {
            if (cbCardReader.SelectedValue.ToString() == String.Empty)
            {
                return;
            }

            CardReader cardReader = new CardReader(cbCardReader.SelectedValue.ToString());
            if (String.IsNullOrEmpty(CardReader.eidCard.Identity.CardNumber))
            {
                MessageBox.Show(Resources.MessageText.MsgInvalidCard, "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                using (EIDNative.EIDCard card = CardReader.eidCard)
                {
                    txtFirstName.Text = card.Identity.FirstName1;
                    txtLastName.Text = card.Identity.Surname;
                    cbGender.SelectedValue = card.Identity.Sex;
                    pictureBox1.Image = card.Picture;
                    dateDOB.Value = EIDNative.CardDate.ToDate(card.Identity.BirthDate);
                    txtUserID.Text = txtUsername.Text = (card.Identity.FirstName1[0] + card.Identity.Surname).ToLower();
                }
            }
        }

        private void materialRaisedButton2_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofile = new OpenFileDialog();
            ofile.Filter = "Image Files (*.bmp;*.jpg;*.jpeg,*.png)|*.BMP;*.JPG;*.JPEG;*.PNG";
            if (ofile.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.ImageLocation = ofile.FileName;

            }
        }

        private Boolean validateForm()
        {
            Boolean isError = false;
            TextBox[] newTextBox = { txtUserID, txtUsername, txtPassword, txtFirstName, txtLastName };
            for (int i = 0; i < newTextBox.Length; i++)
            {
                if (newTextBox[i].Text == string.Empty)
                {
                    if (!isError)
                    {
                        newTextBox[i].Focus();
                        isError = true;
                    }
                    newTextBox[i].BackColor = Color.Yellow;
                }
                else
                {
                    newTextBox[i].BackColor = SystemColors.Window;
                }
            }

            ComboBox[] newCombobox = { cbGender };
            for (int i = 0; i < newCombobox.Length; i++)
            {
                if (newCombobox[i].SelectedValue.ToString() == string.Empty)
                {
                    if (!isError)
                    {
                        newCombobox[i].Focus();
                        isError = true;
                    }
                    newCombobox[i].BackColor = Color.Yellow;
                }
                else
                {
                    newCombobox[i].BackColor = SystemColors.Window;
                }
            }

            if (isError)
            {
                MessageBox.Show(Resources.MessageText.MsgRequired, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return isError;
        }

        public byte[] imageToByteArray(Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, imageIn.RawFormat);
            return ms.ToArray();
        }

        private void materialRaisedButton3_Click(object sender, EventArgs e)
        {
            pictureBox1.ImageLocation = String.Empty;
            pictureBox1.Image = Properties.Resources.default_user_icon_profile;
        }

        private void materialRaisedButton1_Click(object sender, EventArgs e)
        {
            bool isError = validateForm();
            if (!isError)
            {

                bool isIdExisted = false;
                try
                {
                    isIdExisted = ODataQuery.isIDExisted(txtNatId.Text);

                }
                catch (Exception ex)
                {
                    string result2 = ex.InnerException.Message;
                    try
                    {
                        var str = XElement.Parse(result2);
                        result2 = str.Value;
                    }
                    catch (Exception ex2)
                    {
                        result2 = ex.InnerException.Message;
                    }
                    MessageBox.Show(result2, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (isIdExisted)
                {
                    string sIdExisted = Resources.MessageText.MsgIdDuplicate;
                    sIdExisted = sIdExisted.Replace("{0}", txtNatId.Text);
                    MessageBox.Show(sIdExisted, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                SFOData.User oNewUser = new SFOData.User()
                {
                    username = txtUsername.Text,
                    status = "ACTIVE",
                    userId = txtUserID.Text,
                    defaultLocale = "en_US",
                    gender = cbGender.SelectedValue.ToString(),
                    password = txtPassword.Text,
                    timeZone = "US/Eastern",
                    firstName = txtFirstName.Text,
                    lastName = txtLastName.Text,
                    dateOfBirth = dateDOB.Value,
                    country = "BEL"
                };

                string result = ODataQuery.addUser(oNewUser);
                if (result != "SUCCESS")
                {
                    MessageBox.Show(result, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (pictureBox1.ImageLocation != String.Empty)
                    {
                        Image imgPhoto = Image.FromFile(pictureBox1.ImageLocation);
                        //ImageFormat format = imgPhoto.RawFormat;
                        //ImageCodecInfo codec = ImageCodecInfo.GetImageDecoders().First(c => c.FormatID == format.Guid);
                        //string mimeType = codec.MimeType;
                        SFOData.Photo oNewPhoto = new SFOData.Photo()
                        {
                            //userNav = oNewUser,
                            photoType = 1,
                            //height = imgPhoto.Height,
                            //width = imgPhoto.Width,
                            photo = imageToByteArray(imgPhoto),
                            //mimeType = mimeType,
                            userId = oNewUser.userId
                        };
                        result = ODataQuery.addPhoto(oNewPhoto);
                    }
                    if (result != "SUCCESS")
                    {
                        MessageBox.Show(result, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show(Resources.MessageText.MsgSuccessAdded + " " + oNewUser.username, "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }
    }
}
