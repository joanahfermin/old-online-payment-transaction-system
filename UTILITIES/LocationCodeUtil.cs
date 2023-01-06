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
        public const int FOLDERSIZE = 80;

        static string[] regPrefix = { "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "B" };
        static string[] EPrefix = { "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "Q" };

        /// <summary>
        /// Generates a Location code for the uploaded receipts.
        /// </summary>
        public static string GetNextLocationCode_RegPayment() //regular
        {
            string yearPrefix = DateTime.Now.Year.ToString();

            int Count = RPTDatabase.CountLocationReg() + GlobalConstants.LOC_CODE_ADJUSTMENT_REGULAR;
            int Folder = ((Count / FOLDERSIZE)) % 99 + 1 ;
            string prefix = regPrefix[Count/FOLDERSIZE / 99];
            return "(" + yearPrefix + ")" + " " + prefix + Folder;
        }

        public static string GetNextLocationCode_EPayment() //epayment
        {
            string yearPrefix = DateTime.Now.Year.ToString();

            int Count = RPTDatabase.CountLocationElec() + GlobalConstants.LOC_CODE_ADJUSTMENT_ELECTRONIC;
            int Folder = ((Count / FOLDERSIZE)) % 99 + 1;
            string prefix = EPrefix[Count / FOLDERSIZE / 99];

            return "(" + yearPrefix + ")" + " " + prefix + Folder;
        }
    }
}
