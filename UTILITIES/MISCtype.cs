using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleRPT1
{
    internal class MISCtype
    {
        public const string OCCUPATIONAL_PERMIT = "OCCUPATIONAL PERMIT";
        public const string PTR = "PTR";
        public const string HEALTH_CERTIFICATE = "HEALTH CERTIFICATE";

        public static string[] ALL_MISC_TYPE = { OCCUPATIONAL_PERMIT, PTR, HEALTH_CERTIFICATE };

        public static string[] MISC_COMMON_COLUMN_NAMES = { "Amount To Pay", "Transferred Amount" };
        public static string[] MISC_OCCPERMIT_COLUMN_NAMES = {  };

        public static void Call_OccuPermit_Columns()
        {
            
        }
    }
}
