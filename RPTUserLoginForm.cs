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
            string userName = textUserName.Text;
            string passWord = textPassWord.Text;

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
            new ParentForm().Show();
            this.Hide();
        }
    }
}
