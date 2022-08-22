using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace SampleRPT1
{
    internal class GlobalVariables
    {
        public static RPTUser RPTUSER;

        public static int LISTVIEW_MAX_ROWS = Convert.ToInt32(ConfigurationManager.AppSettings["ListViewMaxRows"]);
        public static MainForm MAINFORM;
    }
}
