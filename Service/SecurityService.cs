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
    }
}
