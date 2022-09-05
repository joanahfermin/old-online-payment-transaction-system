using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SampleRPT1
{
    public partial class RPTUserLoginForm : Form
    {
        public RPTUserLoginForm()
        {
            InitializeComponent();
        }

        private void btnRptLogin_Click(object sender, EventArgs e)
        {
            string userName = textUserName.Text.Trim();
            string passWord = textPassWord.Text.Trim();

            RPTUser rptUser = RPTUserDatabase.FindByUserName(userName);
            
            if (rptUser == null)
            {
                MessageBox.Show("Invalid Username.");
                return;
            }
            if (rptUser.PassWord != passWord)
            {
                MessageBox.Show("Invalid Password.");
                return;
            }
            GlobalVariables.RPTUSER = rptUser;
            ParentForm parentForm = new ParentForm();
            parentForm.SetLoginForm(this);
            parentForm.Show();
            this.Hide();
        }

        /// <summary>
        /// TEXTFIELD BEHAVIOR USING CLIK AND ENTER.
        /// </summary>
        private bool textUserNameJustEntered = false;
        private void textUserName_Enter(object sender, EventArgs e)
        {
            textUserName.SelectAll();
            textUserNameJustEntered = true;
        }

        private void textUserName_Click(object sender, EventArgs e)
        {
            if (textUserNameJustEntered)
            {
                textUserName.SelectAll();
            }

            textUserNameJustEntered = false;
        }

        private bool textPassWordJustEntered = false;
        private void textPassWord_Enter(object sender, EventArgs e)
        {
            textPassWord.SelectAll();
            textPassWordJustEntered = true;
        }

        private void textPassWord_Click(object sender, EventArgs e)
        {
            if (textPassWordJustEntered)
            {
                textPassWord.SelectAll();
            }

            textPassWordJustEntered = false;
        }

        private void EnterKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                SelectNextControl(ActiveControl, true, true, true, true);
            }
        }

        private void textUserName_KeyDown(object sender, KeyEventArgs e)
        {
            EnterKeyDown(sender, e);
        }

        private void textPassWord_KeyDown(object sender, KeyEventArgs e)
        {
            EnterKeyDown(sender, e);
        }
    }
}
