using SampleRPT1.DATABASE;
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
        /// <summary>
        /// Initialize the system when program is RUN.
        /// </summary>
        public static void Initializa()
        {
            GlobalConstants.GMAIL_PORT = getSystemSettingAsInt("GMAIL_PORT");

            GlobalConstants.GMAIL_HOST = getSystemSettingAsString("GMAIL_HOST");

            GlobalConstants.LISTVIEW_MAX_ROWS = getSystemSettingAsInt("LIST_VIEW_MAX_ROWS");

            GlobalConstants.AUTO_REFRESH_LISTVIEW_INTERVAL_SECONDS = getSystemSettingAsInt("AUTO_REFRESH_LIST_VIEW_INTERVAL");
        }

        public static int getSystemSettingAsInt(String SettingName)
        {
            return Int32.Parse(getSystemSettingAsString(SettingName));
        }

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
