using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleRPT1.UTILITIES
{
    internal class BusinessUtil
    {
        public static string GenerateRefNo()
        {
            string refNo = "R" + DateTimeOffset.Now.ToUnixTimeMilliseconds();
            return refNo;
        }
    }
}
