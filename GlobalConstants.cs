using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace SampleRPT1
{
    class GlobalConstants
    {
        public static string DATABASE_CONNECTION_STRING = ConfigurationManager.AppSettings["ConnectionString"];

        public static int GMAIL_PORT;

        public static string GMAIL_HOST;

        public static int LISTVIEW_MAX_ROWS;

        public static int AUTO_REFRESH_LISTVIEW_INTERVAL_SECONDS;

        public static int AUTO_EMAIL_INTERVAL_SECONDS;
    }
}
