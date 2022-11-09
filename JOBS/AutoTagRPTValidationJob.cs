using SampleRPT1.DATABASE;
using SampleRPT1.MODEL;
using SampleRPT1.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SampleRPT1.JOBS
{
    class AutoTagRPTValidationJob
    {
        private Timer AutoTimer;
        public void Initialize()
        {
            AutoTimer = new Timer();
            AutoTimer.Tick += new EventHandler(RunTag);
            //AutoTimer.Interval = 3600*1000; // convert seconds to milliseconds
            AutoTimer.Interval = 1800 * 1000; //30 mins

            //AutoTimer.Interval = 10 * 1000;
            AutoTimer.Start();
        }

        public void RunTag(object sender, EventArgs e)
        {
            Task.Run(() => RunAutoTagLogic());
        }

        private async void RunAutoTagLogic()
        {
            RPTUser loginUser = SecurityService.getLoginUser();

            if (loginUser == null || !loginUser.isAutomatedEmailSender)
            {
                // If user is not yet logged in, or user does not have rights for automated email sending
                // then do nothing.
                return;
            }

            List<TagReceipt> tagReceiptList = TagReceiptDatabase.SelectAll();

            foreach (TagReceipt tagReceipt in tagReceiptList)
            {
                RealPropertyTax rpt = RPTDatabase.SearchByTagReceipt(tagReceipt);

                if (rpt != null)
                {
                    RPTUser rptUser = RPTUserDatabase.FindByMAchNo(tagReceipt.MachNo);
                    rpt.ValidatedBy = rptUser.DisplayName;
                    rpt.ValidatedDate = DateTime.Now;
                    rpt.Status = RPTStatus.OR_UPLOAD;

                    RPTDatabase.Update(rpt);
                }
            }
        }
    }
}
