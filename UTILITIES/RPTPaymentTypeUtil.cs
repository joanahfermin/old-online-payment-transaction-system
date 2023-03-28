using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleRPT1.UTILITIES
{
    internal class RPTPaymentTypeUtil
    {
        public const string ADJUSTMENT = "ADJ";
        public const string PARTIAL = "PAR";
        public const string COMPLETION = "COM";
        public const string DELINQUENT = "DEL";
        public const string ADVANCE = "ADV";
        public const string POSTMARK = "POS";
        public const string CURRENT = "CURR";

        public static string[] ALL_PAYMENT_TYPE = { ADJUSTMENT, PARTIAL , COMPLETION, DELINQUENT, ADVANCE, POSTMARK, CURRENT };
    }
}
