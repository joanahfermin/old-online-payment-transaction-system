using SampleRPT1.Service;
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
        private RPTUser loginUser = SecurityService.getLoginUser();

        List<long> RptiDList = new List<long>();

        /// <summary>
        /// Accepts all Rptid from MainForm and transfer it to the RptIDList.
        public SendEmailForm(List<long> RptIDList)
        {
            InitializeComponent();
            this.RptiDList = RptIDList;
            InitializeTemplates();
        }

        /// <summary>
        /// Initialize email templates based on the status. If OR_UPLOAD, email template is set to Receipt already. If ASSESSMENT, email template is set to Assessment.
        /// </summary>
        private void InitializeTemplates()
        {
            List<EmailTemplate> templates = EmailTemplateDatabase.SelectLatest();

            foreach (EmailTemplate item in templates)
            {
                cboTemplates.Items.Add(item.Name);
            }

            foreach (var RptId in RptiDList)
            {
                RealPropertyTax rpt = RPTDatabase.Get(RptId);

                if (rpt.Status == RPTStatus.OR_UPLOAD)
                {
                    EmailTemplate template = EmailTemplateDatabase.SelectByName(Name);

                    cboTemplates.Text = EmailTemplateUtil.RECEIPT;
                }

                if (rpt.Status == RPTStatus.ASSESSMENT_PRINTED)
                {
                    EmailTemplate template = EmailTemplateDatabase.SelectByName(Name);

                    cboTemplates.Text = EmailTemplateUtil.ASSESSMENT;
                }
            }
            cboTemplates.Focus();
        }

        /// <summary>
        /// Enabling the button function depending on the email template if Assessment or Receipt.
        /// If record has an attachment of assessment, button assessment is enabled.
        /// If record has an attachment of receipt, button receipt is enabled.
        /// If record has no attachments either assessment or receipt, send email button is enabled.
        /// </summary>
        private void cboTemplates_SelectedIndexChanged(object sender, EventArgs e)
        {
            EmailTemplate template = EmailTemplateDatabase.SelectByName(cboTemplates.Text);

            if (template != null)
            {
                textSubject.Text = template.Subject;
                richTextBox1.Text = template.Body + "\n\n\n" + loginUser.DisplayName + "-CTO";

                btnSendAssessment.Enabled = false;
                btnSendReceipt.Enabled = false;
                btnSendEmail.Enabled = false;

                if (template.isAssessment)
                {
                    if (RPTAttachPictureDatabase.HasDocumentType(RptiDList, DocumentType.ASSESSMENT))
                    {
                        btnSendAssessment.Enabled = true;
                    }
                }

                if (template.isReceipt)
                {
                    if (RPTAttachPictureDatabase.HasDocumentType(RptiDList, DocumentType.RECEIPT))
                    {
                        btnSendReceipt.Enabled = true;
                    }
                }

                if (!template.isAssessment && !template.isReceipt)
                {
                    btnSendEmail.Enabled = true;
                }
            }
        }

        /// <summary>
        /// Send email function.
        /// </summary>
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

        /// <summary>
        /// Send assessment function.
        /// </summary>
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

                bool result = GmailUtil.SendMail(rpt.RequestingParty, textSubject.Text, richTextBox1.Text, RetrieveIdAndImage);

                if (result == true)
                {
                    rpt.Status = RPTStatus.BILL_SENT;
                    rpt.SentBy = loginUser.DisplayName;
                    rpt.SentDate = DateTime.Now;
                    SentTo = SentTo + rpt.RequestingParty + " ";

                    RPTDatabase.Update(rpt);
                    RefreshMainListviewStatusBillSent();
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

        private void RefreshMainListviewStatusBillSent()
        {
            MainForm.INSTANCE.SearchBillSent();
        }

        private void RefreshMainListviewStatusORPickup()
        {
            MainForm.INSTANCE.SearchORPickup();
        }

        /// <summary>
        /// Send email receipt function.
        /// </summary>
        private void btnSendReceipt_Click(object sender, EventArgs e)
        {
            string SentTo = "";
            string FailedSend = "";
            string SkipEmailToTaxdec = " ";

            foreach (var RptId in RptiDList)
            {
                RealPropertyTax rpt = RPTDatabase.Get(RptId);

                //checking if the record is for upload status.
                if (rpt.Status != RPTStatus.OR_UPLOAD)
                {
                    SkipEmailToTaxdec = SkipEmailToTaxdec + rpt.TaxDec;
                    continue;
                }

                //checking if the record with for upload status has attachment.
                RPTAttachPicture RetrieveIdAndImage = RPTAttachPictureDatabase.SelectByRPTAndDocumentType(RptId, DocumentType.RECEIPT);

                if (RetrieveIdAndImage == null)
                {
                    SkipEmailToTaxdec = SkipEmailToTaxdec + rpt.TaxDec;
                    continue;
                }

                bool result = GmailUtil.SendMail(rpt.RequestingParty, textSubject.Text, richTextBox1.Text, RetrieveIdAndImage);

                if (result == true)
                {
                    RPTDatabase.ChangeStatusForORPickUp(rpt);
                    
                    SentTo = SentTo + rpt.RequestingParty + " ";
                    RefreshMainListviewStatusORPickup();
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
    }
}

