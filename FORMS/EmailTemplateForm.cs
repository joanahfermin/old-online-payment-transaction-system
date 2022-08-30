using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SampleRPT1.FORMS
{
    public partial class EmailTemplateForm : Form
    {
        MainForm parentForm;
        long TemplateID;
        public EmailTemplateForm()
        {
            InitializeComponent();
            InitializeData();
            parentForm = GlobalVariables.MAINFORM;
        }

        //public void setParent(MainForm mainForm)
        //{
        //    parentForm = mainForm;
        //}

        public void InitializeData()
        {
            List<EmailTemplate> TemplateList = EmailTemplateDatabase.SelectLatest();
            PopulateListView(TemplateList);
        }
        private void PopulateListView(List<EmailTemplate> TemplateList)
        {
            ListViewUtil.copyFromListToListview<EmailTemplate>(TemplateList, LVEmail, new List<string>
            { "TemplateID", "Name", "Subject", "isAssessment", "isReceipt"});
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            EmailTemplate mgTemplate = new EmailTemplate();

            mgTemplate.Name = textName.Text;
            mgTemplate.Subject = textSubject.Text;
            mgTemplate.Body = richTextBox1.Text;
            mgTemplate.isAssessment = cbAssessment.Checked;
            mgTemplate.isReceipt = cbReceipt.Checked;

            EmailTemplateDatabase.Insert(mgTemplate);

            MessageBox.Show("Successfully saved.");

            InitializeData();

            textName.Clear();
            textSubject.Clear();
            richTextBox1.Text = string.Empty;
        }

        private void LVEmail_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (LVEmail.SelectedItems.Count > 0)
            {
                string templateID = LVEmail.SelectedItems[0].Text;
                TemplateID = Convert.ToInt32(templateID);

                EmailTemplate mgTemplate = EmailTemplateDatabase.Get(TemplateID);

                textName.Text = mgTemplate.Name;
                textSubject.Text = mgTemplate.Subject;
                richTextBox1.Text = mgTemplate.Body;

                cbAssessment.Checked = mgTemplate.isAssessment;
                cbReceipt.Checked = mgTemplate.isReceipt;
            }
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            EmailTemplate mgTemplate = EmailTemplateDatabase.Get(TemplateID);

            mgTemplate.Name = textName.Text;
            mgTemplate.Subject = textSubject.Text;
            mgTemplate.Body = richTextBox1.Text;
            mgTemplate.isAssessment = cbAssessment.Checked;
            mgTemplate.isReceipt = cbReceipt.Checked;

            EmailTemplateDatabase.Update(mgTemplate);

            MessageBox.Show("Successfully saved.");

            InitializeData();

            textName.Clear();
            textSubject.Clear();
            richTextBox1.Text = string.Empty;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (LVEmail.SelectedIndices.Count > 0)
            {
                var Confirmation = MessageBox.Show("Are you sure you want to delete record?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (Confirmation == DialogResult.Yes)
                {
                    for (int i = LVEmail.SelectedIndices.Count - 1; i >= 0; i--)
                    {
                        LVEmail.Items.RemoveAt(LVEmail.SelectedIndices[i]);
                    }

                    EmailTemplate mgTemplate = EmailTemplateDatabase.Get(TemplateID);
                    EmailTemplateDatabase.Delete(mgTemplate);
                }
            }

            else
            {
                MessageBox.Show("Invalid deletion of record.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            textName.Clear();
            textSubject.Clear();
            richTextBox1.Text = string.Empty;

            InitializeData();
        }
    }
}
