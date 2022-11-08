using SampleRPT1.DATABASE;
using SampleRPT1.JOBS;
using SampleRPT1.MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleRPT1
{
    class Bootstrap
    {
        private static AutoEmailJob autoEmailJob;
        private static AutoTagRPTValidationJob autoTag;
        /// <summary>
        /// Initialize the system when program is RUN.
        /// </summary>
        public static void Initialize()
        {
            GlobalConstants.GMAIL_PORT = getSystemSettingAsInt("GMAIL_PORT");

            GlobalConstants.GMAIL_HOST = getSystemSettingAsString("GMAIL_HOST");

            GlobalConstants.LISTVIEW_MAX_ROWS = getSystemSettingAsInt("LIST_VIEW_MAX_ROWS");

            GlobalConstants.AUTO_REFRESH_LISTVIEW_INTERVAL_SECONDS = getSystemSettingAsInt("AUTO_REFRESH_LIST_VIEW_INTERVAL");

            GlobalConstants.AUTO_EMAIL_INTERVAL_SECONDS = getSystemSettingAsInt("AUTO_EMAIL_INTERVAL");

            GlobalConstants.AUTO_REFRESH_CONFIRM_SENDEMAIL = getSystemSettingAsInt("AUTO_REFRESH_CONFIRM_SENDEMAIL");

            autoEmailJob = new AutoEmailJob();
            autoEmailJob.Initialize();

            autoTag = new AutoTagRPTValidationJob();
            autoTag.Initialize();
        }

        /// <summary>
        /// Returns a value that is already converted into int.
        /// </summary>
        /// <param name="SettingName"></param>
        /// <returns></returns>
        public static int getSystemSettingAsInt(String SettingName)
        {
            return Int32.Parse(getSystemSettingAsString(SettingName));
        }

        /// <summary>
        /// Returns a value that is already converted into string.
        /// </summary>
        /// <param name="SettingName"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static string getSystemSettingAsString(String SettingName)
        {
            SystemSetting setting = SystemSettingDatabase.SelectBySettingName(SettingName);
            if (setting != null)
            {
                return setting.SettingValue;
            } 
            else
            {
                throw new Exception($"Settings {SettingName} not found in database");
            }
        }

    }
}
