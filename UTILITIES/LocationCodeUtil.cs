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
        /// <returns></returns>
        public static string GetNextLocationCode()
        {
            int Count = RPTDatabase.CountLocation();
            int Folder = (Count / FOLDERSIZE) + 1;
            return "C" + Folder;
        }
    }
}
