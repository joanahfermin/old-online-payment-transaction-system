using SampleRPT1.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SampleRPT1.JOBS
{
    class AutoEmailJob
    {
        private Timer AutoEmailJobTimer;
        public void Initialize()
        {
            AutoEmailJobTimer = new Timer();
            AutoEmailJobTimer.Tick += new EventHandler(RunAutoEmail);
            AutoEmailJobTimer.Interval = GlobalConstants.AUTO_EMAIL_INTERVAL_SECONDS * 1000; // convert seconds to milliseconds
            AutoEmailJobTimer.Start();
        }

        public void RunAutoEmail(object sender, EventArgs e)
        {
            Task.Run(() => RunAutoEmailLogic());
        }

        private async void RunAutoEmailLogic()
        {
            RPTUser loginUser = SecurityService.getLoginUser();

            if (loginUser == null || !loginUser.isAutomatedEmailSender)
            {
                // If user is not yet logged in, or user does not have rights for automated email sending
                // then do nothing.
                return;
            }
            Console.WriteLine("RunAutoEmail");

            RPTAttachPictureDatabase.FixEmptyFileName();
            SendORReceipt();
            SendAssessment();
        }

        //Send email of status: FOR OR UPLOAD in the background. 
        public void SendORReceipt()
        {
            List<RealPropertyTax> ListOfretrieveORSsendEmail = RPTDatabase.SelectForORUpload();

            EmailTemplate ORUploadTemplate = EmailTemplateDatabase.SelectORUploadTemplate();


            foreach (RealPropertyTax rpt in ListOfretrieveORSsendEmail)
            {
                RPTAttachPicture RetrieveIdAndImage = RPTAttachPictureDatabase.SelectByRPTAndDocumentType(rpt.RptID, DocumentType.RECEIPT);

                string body = "ATTENTION: " + rpt.TaxPayerName + " ("  + rpt.TaxDec + ") \n" + ORUploadTemplate.Body + "\n\n" + rpt.UploadedBy + "-CTO";
                string subject = ORUploadTemplate.Subject + " - " + rpt.TaxDec;

                bool result = GmailUtil.SendMail(rpt.RequestingParty, subject, body, RetrieveIdAndImage);

                if (result == true)
                {
                    RPTDatabase.ChangeStatusForORPickUp(rpt);
                }
            }
        }

        //Send email of status: ASSESSMENT PRINTED in the background. 
        public void SendAssessment()
        {
            RPTUser loginUser = SecurityService.getLoginUser();

            List<RealPropertyTax> ListOfretrieveAssessmentSendEmail = RPTDatabase.SelectAssessmentSendEmail();

            EmailTemplate AssessmentTemplate = EmailTemplateDatabase.SelectAssessmentTemplate();

            foreach (RealPropertyTax rpt in ListOfretrieveAssessmentSendEmail)
            {
                RPTAttachPicture RetrieveIdAndImage = RPTAttachPictureDatabase.SelectByRPTAndDocumentType(rpt.RptID, DocumentType.ASSESSMENT);

                string body = "ATTENTION: " + rpt.TaxPayerName + " (" + rpt.TaxDec + ") \n" + AssessmentTemplate.Body + "\n\n" + rpt.SentBy + "-CTO";
                string subject = AssessmentTemplate.Subject + " - " + rpt.TaxDec;

                bool result = GmailUtil.SendMail(rpt.RequestingParty, subject, body, RetrieveIdAndImage);

                if (result == true)
                {
                    rpt.Status = RPTStatus.BILL_SENT;
                    rpt.SentBy = loginUser.DisplayName;
                    rpt.SentDate = DateTime.Now;

                    RPTDatabase.Update(rpt);
                }
            }
        }
    }
}
