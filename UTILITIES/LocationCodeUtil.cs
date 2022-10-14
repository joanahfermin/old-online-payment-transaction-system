using SampleRPT1.FORMS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleRPT1
{
    class LocationCodeUtil
    {
        public const int FOLDERSIZE = 5;

        /// <summary>
        /// Generates a Location code for the uploaded receipts.
        /// </summary>
        public static string GetNextLocationCode_RegPayment()
        {
            string yearPrefix = DateTime.Now.Year.ToString();

            int Count = RPTDatabase.CountLocation();
            int Folder = (Count / FOLDERSIZE) + 1;
            return "(" + yearPrefix + ")" + " " + "C" + Folder;
        }

        public static string GetNextLocationCode_EPayment()
        {
            string yearPrefix = DateTime.Now.Year.ToString();

            int Count = RPTDatabase.CountLocation();
            int Folder = (Count / FOLDERSIZE) + 1;
            return "(" + yearPrefix + ")" + " " + "GP" + Folder;
        }
    }
}
