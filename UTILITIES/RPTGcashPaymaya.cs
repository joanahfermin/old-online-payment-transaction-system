using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleRPT1
{
    /// <summary>
    /// Contents of the Payment channel filter.
    /// </summary>
    internal class RPTGcashPaymaya
    {
        public const string BANK_TRANSFER = "BANK TRANSFER";
        public const string GCASH = "GCASH";
        public const string PAYGATE_ONLINE_BANKING = "ONLINE BANKING VIA PAYGATE";
        public const string PAYMAYA_EWALLET = "PAYMAYA (E-WALLET)";
        public const string PAYMAYA_VISTAMASTERCARD = "VISA/MASTERCARD VIA PAYMAYA";

        public static string[] ALL_PAYMENT_CHANNEL = { BANK_TRANSFER, GCASH, PAYGATE_ONLINE_BANKING, PAYMAYA_EWALLET, PAYMAYA_VISTAMASTERCARD };

        public static string[] E_PAYMENT_CHANNEL = { GCASH, PAYGATE_ONLINE_BANKING, PAYMAYA_EWALLET, PAYMAYA_VISTAMASTERCARD };

    }
}
