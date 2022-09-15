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
            if (GlobalVariables.RPTUSER == null || !GlobalVariables.RPTUSER.isAutomatedEmailSender)
            {
                // If user is not yet logged in, or user does not have rights for automated email sending
                // then do nothing.
                return;
            }
            Console.WriteLine("RunAutoEmail");

            SendORReceipt();
            SendAssessment();
        }

        public void SendORReceipt()
        {
            List<RealPropertyTax> ListOfretrieveORSsendEmail = RPTDatabase.SelectForORUpload();

            EmailTemplate ORUploadTemplate = EmailTemplateDatabase.SelectORUploadTemplate();

            foreach (RealPropertyTax rpt in ListOfretrieveORSsendEmail)
            {
                RPTAttachPicture RetrieveIdAndImage = RPTAttachPictureDatabase.SelectByRPTAndDocumentType(rpt.RptID, DocumentType.RECEIPT);

                bool result = GmailUtil.SendMail(rpt.RequestingParty, ORUploadTemplate.Subject, ORUploadTemplate.Body, RetrieveIdAndImage);

                if (result == true)
                {
                    rpt.Status = RPTStatus.OR_PICKUP;
                    rpt.UploadedBy = GlobalVariables.RPTUSER.UserName;
                    rpt.UploadedDate = DateTime.Now;
                    rpt.LocCode = LocationCodeUtil.GetNextLocationCode();

                    RPTDatabase.Update(rpt);
                }
            }
        }

        public void SendAssessment()
        {
            List<RealPropertyTax> ListOfretrieveAssessmentSendEmail = RPTDatabase.SelectAssessmentSendEmail();

            EmailTemplate AssessmentTemplate = EmailTemplateDatabase.SelectAssessmentTemplate();

            foreach (RealPropertyTax rpt in ListOfretrieveAssessmentSendEmail)
            {
                RPTAttachPicture RetrieveIdAndImage = RPTAttachPictureDatabase.SelectByRPTAndDocumentType(rpt.RptID, DocumentType.ASSESSMENT);

                bool result = GmailUtil.SendMail(rpt.RequestingParty, AssessmentTemplate.Subject, AssessmentTemplate.Body, RetrieveIdAndImage);

                if (result == true)
                {
                    rpt.Status = RPTStatus.BILL_SENT;
                    rpt.UploadedBy = GlobalVariables.RPTUSER.UserName;
                    rpt.UploadedDate = DateTime.Now;
                    rpt.LocCode = LocationCodeUtil.GetNextLocationCode();

                    RPTDatabase.Update(rpt);
                }
            }
        }
    }
}
