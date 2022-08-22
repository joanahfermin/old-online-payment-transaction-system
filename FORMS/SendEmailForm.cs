using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SampleRPT1.FORMS
{
    public partial class SendEmailForm : Form
    {
        MainForm parentForm;

        List<long> RptiDList = new List<long>();

        public SendEmailForm(List<long> RptIDList)
        {
            InitializeComponent();
            this.RptiDList = RptIDList;
            parentForm = GlobalVariables.MAINFORM;
            InitializeTemplates();
        }

        //public void setParent(MainForm mainForm)
        //{
        //    parentForm = mainForm;
        //}

        private void InitializeTemplates()
        {

            List<MessageTemplate> templates = MessageTemplateDatabase.SelectLatest();

            foreach (MessageTemplate item in templates)
            {
                cboTemplates.Items.Add(item.Name);
            }

            foreach (var RptId in RptiDList)
            {
                RealPropertyTax rpt = RPTDatabase.Get(RptId);

                if (rpt.Status == RPTStatus.OR_UPLOAD)
                {
                    MessageTemplate template = MessageTemplateDatabase.SelectByName(Name);

                    cboTemplates.Text = EmailTemplateUtil.RECEIPT;
                }
                if (rpt.Status == RPTStatus.ASSESSMENT_PRINTED)
                {
                    MessageTemplate template = MessageTemplateDatabase.SelectByName(Name);

                    cboTemplates.Text = EmailTemplateUtil.ASSESSMENT;
                }
            }

            cboTemplates.Focus();
        }

        private void cboTemplates_SelectedIndexChanged(object sender, EventArgs e)
        {
            MessageTemplate template = MessageTemplateDatabase.SelectByName(cboTemplates.Text);

            if (template != null)
            {
                textSubject.Text = template.Subject;
                richTextBox1.Text = template.Body + "\n" + GlobalVariables.RPTUSER.DisplayName + "-CTO";

                if (cboTemplates.Text == EmailTemplateUtil.ASSESSMENT)
                {
                    btnSendReceipt.Enabled = false;
                    btnSendEmail.Enabled = false;
                }

                if (cboTemplates.Text == EmailTemplateUtil.RECEIPT)
                {
                    btnSendAssessment.Enabled = false;
                    btnSendEmail.Enabled = false;
                }
                else
                {
                    btnSendEmail.Enabled = true;
                    btnSendReceipt.Enabled = false;
                    btnSendAssessment.Enabled = false;
                }
            }
        }

        private void btnSendEmail_Click(object sender, EventArgs e)
        {
            string SentTo = "";
            string FailedSend = "";

            foreach (var RptId in RptiDList)
            {
                RealPropertyTax rpt = RPTDatabase.Get(RptId);

                bool result = GmailUtil.SendMail(rpt.RequestingParty, textSubject.Text, richTextBox1.Text, null);

                if (result == true)
                {
                    SentTo = SentTo + rpt.RequestingParty + " ";
                }
                else
                {
                    FailedSend = FailedSend + rpt.RequestingParty + " ";
                }
            }

            if (SentTo.Length > 0)
            {
                MessageBox.Show("Email send to " + SentTo);
            }
            else
            {
                MessageBox.Show("No email sent ");
            }

            if (FailedSend.Length > 0)
            {
                MessageBox.Show("Email sending failed to " + FailedSend);
            }

            this.Close();
        }

        public Image byteArrayToImage(byte[] byteArrayIn)
        {
            using (var ms = new MemoryStream(byteArrayIn))
            {
                //return Image.FromStream(ms);
                return (Bitmap)((new ImageConverter()).ConvertFrom(byteArrayIn));
            }
        }

        private void btnSendAssessment_Click(object sender, EventArgs e)
        {
            string SentTo = "";
            string FailedSend = "";
            string SkipEmailToTaxdec = " ";

            foreach (var RptId in RptiDList)
            {
                RealPropertyTax rpt = RPTDatabase.Get(RptId);

                if (rpt.Status != RPTStatus.ASSESSMENT_PRINTED)
                {
                    SkipEmailToTaxdec = SkipEmailToTaxdec + rpt.TaxDec;
                    continue;
                }

                RPTAttachPicture RetrieveIdAndImage = RPTAttachPictureDatabase.SelectByRPTAndDocumentType(RptId, DocumentType.ASSESSMENT);

                if (RetrieveIdAndImage == null)
                {
                    SkipEmailToTaxdec = SkipEmailToTaxdec + rpt.TaxDec;
                    continue;
                }

                Image img = byteArrayToImage(RetrieveIdAndImage.FileData);

                bool result = GmailUtil.SendMail(rpt.RequestingParty, textSubject.Text, richTextBox1.Text, img);

                if (result == true)
                {
                    rpt.Status = RPTStatus.BILL_SENT;
                    rpt.SentBy = GlobalVariables.RPTUSER.UserName;
                    rpt.SentDate = DateTime.Now;
                    SentTo = SentTo + rpt.RequestingParty + " ";

                    RPTDatabase.Update(rpt);
                    RefreshMainListviewStatus();
                }
                else
                {
                    FailedSend = FailedSend + rpt.RequestingParty + " ";
                }
            }

            if (SentTo.Length > 0)
            {
                MessageBox.Show("Email send to " + SentTo);
            }
            else
            {
                MessageBox.Show("No email sent ");
            }

            if (FailedSend.Length > 0)
            {
                MessageBox.Show("Email sending failed to " + FailedSend);
            }

            if (SkipEmailToTaxdec.Length > 0)
            {
                MessageBox.Show("Skip the following " + SkipEmailToTaxdec);
            }

            this.Close();
        }

        private void RefreshMainListviewStatus()
        {
            parentForm.SearchORPickup();
        }

        private void btnSendReceipt_Click(object sender, EventArgs e)
        {
            string SentTo = "";
            string FailedSend = "";
            string SkipEmailToTaxdec = " ";

            foreach (var RptId in RptiDList)
            {
                RealPropertyTax rpt = RPTDatabase.Get(RptId);

                //if (rpt.Status == RPTStatus.OR_UPLOAD)
                //{
                //    MessageTemplate template = MessageTemplateDatabase.SelectByName(Name);

                //    template.Name = EmailTemplateUtil.RECEIPT;
                //}

                if (rpt.Status != RPTStatus.OR_UPLOAD)
                {
                    SkipEmailToTaxdec = SkipEmailToTaxdec + rpt.TaxDec;
                    continue;
                }

                RPTAttachPicture RetrieveIdAndImage = RPTAttachPictureDatabase.SelectByRPTAndDocumentType(RptId, DocumentType.RECEIPT);

                if (RetrieveIdAndImage == null)
                {
                    SkipEmailToTaxdec = SkipEmailToTaxdec + rpt.TaxDec;
                    continue;
                }

                Image img = byteArrayToImage(RetrieveIdAndImage.FileData);

                bool result = GmailUtil.SendMail(rpt.RequestingParty, textSubject.Text, richTextBox1.Text, img);

                if (result == true)
                {
                    rpt.Status = RPTStatus.OR_PICKUP;
                    rpt.UploadedBy = GlobalVariables.RPTUSER.UserName;
                    rpt.UploadedDate = DateTime.Now;
                    SentTo = SentTo + rpt.RequestingParty + " ";
                    rpt.LocCode = LocationCodeUtil.GetNextLocationCode();

                    RPTDatabase.Update(rpt);
                    RefreshMainListviewStatus();
                }
                else
                {
                    FailedSend = FailedSend + rpt.RequestingParty + " ";
                }
            }

            if (SentTo.Length > 0)
            {
                MessageBox.Show("Email send to " + SentTo);
            }
            else
            {
                MessageBox.Show("No email sent ");
            }

            if (FailedSend.Length > 0)
            {
                MessageBox.Show("Email sending failed to " + FailedSend);
            }

            if (SkipEmailToTaxdec.Length > 0)
            {
                MessageBox.Show("Skip the following " + SkipEmailToTaxdec);
            }

            this.Close();
        }

        private void SendEmailForm_Load(object sender, EventArgs e)
        {

        }
    }
}

