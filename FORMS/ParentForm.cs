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
        public static ParentForm INSTANCE;

        public ParentForm()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            INSTANCE = this;
        }

        private void ParentForm_Load(object sender, EventArgs e)
        {
            this.menuStrip1.Items.OfType<ToolStripMenuItem>().ToList().ForEach(x =>
            {
                x.MouseHover += (obj, arg) => ((ToolStripDropDownItem)obj).ShowDropDown();
            });
            CreateOrShowMainForm();
        }

        private void CreateOrShowMainForm()
        {
            if (MainForm.INSTANCE == null)
            {
                new MainForm(this);
            }
            MainForm.INSTANCE.Show();
        }

        private void MenuItemHome_Click(object sender, EventArgs e)
        {
            CreateOrShowMainForm();
        }

        private void MenuItemGcashPaymaya_Click(object sender, EventArgs e)
        {
            if (AddRecordGCASHPAYMAYAForm.INSTANCE == null)
            {
                new AddRecordGCASHPAYMAYAForm(this);
            }
            AddRecordGCASHPAYMAYAForm.INSTANCE.Show();
        }

        private void MenuItemAllocateExcess_Click(object sender, EventArgs e)
        {
            MainForm.INSTANCE.AllocateExcess();
        }

        private void MenuItemAllocateBalance_Click(object sender, EventArgs e)
        {
            MainForm.INSTANCE.AllocateShort();
        }

        private void MenuItemSendEmail_Click(object sender, EventArgs e)
        {
            MainForm.INSTANCE.SendEmail();
        }

        private void MenuItemEmailTemplate_Click(object sender, EventArgs e)
        {
            EmailTemplateForm emailTemplateForm = new EmailTemplateForm();
            emailTemplateForm.ShowDialog();
        }


        private void ParentForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            // When parent form is closed, we should also close the invisible login form
            if (RPTUserLoginForm.INSTANCE != null)
            {
                RPTUserLoginForm.INSTANCE.Close();
            }
		}
        private void ReleasingMenuItem_Click(object sender, EventArgs e)
        {
            if (ReleasingForm.INSTANCE == null)
            {
                new ReleasingForm(this);
            }
            ReleasingForm.INSTANCE.Show();
        }

        private void MenuItemReviewEmail_Click(object sender, EventArgs e)
        {
            if (ReviewEmailForm.INSTANCE == null)
            {
                new ReviewEmailForm(this);
            }
            ReviewEmailForm.INSTANCE.Show();
        }

        private void historyMenuItem_Click(object sender, EventArgs e)
        {
            long RptID = MainForm.INSTANCE.getSelectedRptID();

            if (RptID == 0)
            {
                MessageBox.Show("Please select a record");
            }

            else
            {
                if (ViewHistoryForm.INSTANCE == null)
                {
                    new ViewHistoryForm(this);
                }

                ViewHistoryForm.INSTANCE.Show();
                ViewHistoryForm.INSTANCE.setRpdID(RptID);
            }
        }

        private void ReportMenuItem_Click(object sender, EventArgs e)
        {
            if (ReportForm.INSTANCE == null)
            {
                new ReportForm(this);
            }
            ReportForm.INSTANCE.Show();
        }

        private void reorderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ReorderEncodeDateForm.INSTANCE == null)
            {
                new ReorderEncodeDateForm(this);
            }
            ReorderEncodeDateForm.INSTANCE.Show();
        }

        private void mISCToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MiscelleneousTaxForm.INSTANCE == null)
            {
                new MiscelleneousTaxForm(this);
            }
            MiscelleneousTaxForm.INSTANCE.Show();
        }
    }
}
