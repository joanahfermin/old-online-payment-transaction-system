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

        public static int LISTVIEW_MAX_ROWS = Convert.ToInt32(ConfigurationManager.AppSettings["ListViewMaxRows"]);

        public static int AUTO_REFRESH_LISTVIEW_INTERVAL_SECONDS = Convert.ToInt32(ConfigurationManager.AppSettings["AutoRefreshListViewIntervalSeconds"]);

    }
}
