using SampleRPT1.Service;
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
        public static RPTUserLoginForm INSTANCE;

        public RPTUserLoginForm()
        {
            InitializeComponent();
            INSTANCE = this;
        }

        /// <summary>
        /// Passess the retrieved user to the GlobalVariables.RPTUSER.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRptLogin_Click(object sender, EventArgs e)
        {
            string userName = textUserName.Text.Trim();
            string passWord = textPassWord.Text.Trim();

            try
            {
                SecurityService.login(userName, passWord);
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
                return;
            }
            
            ParentForm parentForm = new ParentForm();
            parentForm.Show();
            this.Hide();
        }

        /// <summary>
        /// Selects all word using click and enter keypress.
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

        //TEXTFIELD BEHAVIOR USING CLIK AND ENTER.
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
