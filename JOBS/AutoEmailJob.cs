using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            if (GlobalVariables.RPTUSER == null || !GlobalVariables.RPTUSER.isAutomatedEmailSender)
            {
                // If user is not yet logged in, or user does not have rights for automated email sending
                // then do nothing.
                return;
            }
            Console.WriteLine("RunAutoEmail");
        }
    }
}
