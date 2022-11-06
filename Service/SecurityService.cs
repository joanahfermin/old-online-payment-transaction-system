using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleRPT1.Service
{
    class SecurityService
    {
        private static RPTUser LOGIN_USER;

        public static void login(string userName, string passWord)
        {
            RPTUser rptUser = RPTUserDatabase.FindByUserName(userName);

            if (rptUser == null)
            {
                throw new Exception("Invalid Username.");
            }
            if (rptUser.PassWord != passWord)
            {
                throw new Exception("Invalid Password.");
            }
            LOGIN_USER = rptUser;
        }

        public static RPTUser getLoginUser()
        {
            return LOGIN_USER;
        }

        public static List<string> getLoginUserAllowedRptActions()
        {
            List<string> AllowedRptActions = new List<string>();

            if (LOGIN_USER.isBiller)
            {
                AllowedRptActions.Add(RPTAction.BILL_NO_POP);
                AllowedRptActions.Add(RPTAction.BILL_WITH_POP);
            }

            if (LOGIN_USER.isEncoder)
            {
                AllowedRptActions.Add(RPTAction.MANUAL_SEND_BILL);
            }

            if (LOGIN_USER.isUploader)
            {
                AllowedRptActions.Add(RPTAction.MANUAL_SEND_OR);
            }

            if (LOGIN_USER.isVerifier)
            {
                AllowedRptActions.Add(RPTAction.VERIFY_PAYMENT);
            }

            if (LOGIN_USER.isValidator)
            {
                AllowedRptActions.Add(RPTAction.VALIDATE_PAYMENT);
                //cboAction.SelectedIndex = 0; ;
            }

            return AllowedRptActions;
        }
    }
}
