using SampleRPT1.FORMS;
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
    public partial class ParentForm : Form
    {
        MainForm mainForm;
        public ParentForm()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
        }

        private void ParentForm_Load(object sender, EventArgs e)
        {
            this.menuStrip1.Items.OfType<ToolStripMenuItem>().ToList().ForEach(x =>
            {
                x.MouseHover += (obj, arg) => ((ToolStripDropDownItem)obj).ShowDropDown();
            });
            MenuItemHome_Click(null, null);
            GlobalVariables.MAINFORM = mainForm;
        }

        private void MenuItemHome_Click(object sender, EventArgs e)
        {
            if (mainForm == null)
            {
                mainForm = new MainForm();
                mainForm.MdiParent = this;
                mainForm.ControlBox = false;
            }
            mainForm.Show();
            mainForm.WindowState = FormWindowState.Maximized;
        }

        private void MenuItemGcashPaymaya_Click(object sender, EventArgs e)
        {
            AddRecordGCASHPAYMAYAForm addRecordGcashPaymaya = new AddRecordGCASHPAYMAYAForm();
            addRecordGcashPaymaya.ShowDialog();
        }

        private void MenuItemAllocateExcess_Click(object sender, EventArgs e)
        {
            mainForm.AllocateExcess();
        }

        private void MenuItemAllocateBalance_Click(object sender, EventArgs e)
        {
            mainForm.AllocateShort();
        }

        private void MenuItemSendEmail_Click(object sender, EventArgs e)
        {
            mainForm.SendEmail();
        }

        private void MenuItemEmailTemplate_Click(object sender, EventArgs e)
        {
            EmailTemplateForm emailTemplateForm = new EmailTemplateForm();
            //emailTemplateForm.setParent(this);
            emailTemplateForm.ShowDialog();
        }
    }
}
