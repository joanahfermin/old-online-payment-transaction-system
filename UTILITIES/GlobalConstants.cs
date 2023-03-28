using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace SampleRPT1
{
    /// <summary>
    /// These are all global variable which contains value in the database.
    /// </summary>
    class GlobalConstants
    {
        public static string DATABASE_CONNECTION_STRING = ConfigurationManager.AppSettings["ConnectionString"];

        public static string DATABASE_CONNECTION_STRING_TO_MISCREPORT = ConfigurationManager.AppSettings["ConnectionStringToMiscServer"];

        public static string DATABASE_CONNECTION_STRING_TO_MISCREPORT_OCCUPERMIT_NAME = ConfigurationManager.AppSettings["ConnectionStringToMiscServer1"];



        public static int GMAIL_PORT;

        public static string GMAIL_HOST;

        public static int LISTVIEW_MAX_ROWS;

        public static int AUTO_REFRESH_LISTVIEW_INTERVAL_SECONDS;

        public static int AUTO_EMAIL_INTERVAL_SECONDS;

        public static int AUTO_REFRESH_CONFIRM_SENDEMAIL;

        public static int LOC_CODE_ADJUSTMENT_REGULAR;

        public static int LOC_CODE_ADJUSTMENT_ELECTRONIC;

        public static string AUTHORIZE_EDIT_DATA;

    }
}
