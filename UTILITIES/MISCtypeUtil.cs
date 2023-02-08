using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleRPT1
{
    internal class MISCtypeUtil
    {
        public const string OCCUPATIONAL_PERMIT = "OCCUPATIONAL PERMIT";
        public const string PTR = "PTR";
        public const string HEALTH_CERTIFICATE = "HEALTH CERTIFICATE";
        public static string[] ALL_MISC_TYPE = { OCCUPATIONAL_PERMIT, PTR, HEALTH_CERTIFICATE };

        //OCCUPATIONAL PERMIT STATUS.
        public const string FOR_PAYMENT_VERIFICATION = "FOR PAYMENT VERIFICATION";
        public const string FOR_PAYMENT_VALIDATION = "FOR PAYMENT VALIDATION";
        public const string FOR_TRANSMITTAL = "FOR TRANSMITTAL";
        public static string[] ALL_OCCU_PERMIT_STATUS = { FOR_PAYMENT_VERIFICATION, FOR_PAYMENT_VALIDATION, FOR_TRANSMITTAL };

        //SIMILAR COLUMNS IN MISCELLENEOUS
        public static List<string> MISC_COMMON_COLUMN_NAMES = new List<string>
        { "Amount To Pay", "Transferred Amount", "ExcessShort", "Date of Payment", "Status", "Requesting Party", "Remarks", "Verified By", 
            "Verified Date", "LBP Date", "Validated By", "Validated Date", "Reference Number", "EncodedBy", "EncodedDate", "Released By", "Released Date" };

        //COLUMN NAMES OF THE OCCUPATIONAL PERMIT
        public static List<string> MISC_OCCPERMIT_COLUMN_NAMES = new List<string> 
        { "MiscID", "Misc Type", "Taxpayer's Name", "O.P Number", "Mode of Payment", "OPA Tracking Number"};

        public static List<string> MISC_COMMON_PROPERTY_NAMES = new List<string>
        { "AmountToBePaid", "TransferredAmount", "ExcessShort", "PaymentDate", "Status", "RequestingParty", "Remarks", "VerifiedBy", 
            "VerifiedDate", "LBPDate", "ValidatedBy", "ValidatedDate", "RefNum", "EncodedBy", "EncodedDate", "ReleasedBy", "ReleasedDate" };

        //COLUMN NAMES OF THE OCCUPATIONAL PERMIT
        public static List<string> MISC_OCCPERMIT_PROPERTY_NAMES = new List<string>
        { "MiscID", "MiscType", "TaxpayersName", "OrderOfPaymentNum", "ModeOfPayment", "OPATrackingNum"};


        static MISCtypeUtil()
        {
            MISC_OCCPERMIT_COLUMN_NAMES.AddRange(MISC_COMMON_COLUMN_NAMES);
            MISC_OCCPERMIT_PROPERTY_NAMES.AddRange(MISC_COMMON_PROPERTY_NAMES);
        }
    }
}
