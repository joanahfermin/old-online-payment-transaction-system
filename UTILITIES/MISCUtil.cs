using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleRPT1
{
    internal class MISCUtil
    {

        //ACTIONS.
        public const string VERIFY_PAYMENT = "VERIFY PAYMENT";
        public const string VALIDATE_PAYMENT = "VALIDATE PAYMENT";
        public const string TRANSMIT = "TRANSMIT";
        public const string DELETED_RECORD = "DELETE";

        public static string[] ALL_ACTIONS = { VERIFY_PAYMENT, VALIDATE_PAYMENT, TRANSMIT, DELETED_RECORD };

        //OCCUPATIONAL PERMIT STATUS.
        public const string FOR_PAYMENT_VERIFICATION = "FOR PAYMENT VERIFICATION";
        public const string FOR_PAYMENT_VALIDATION = "FOR PAYMENT VALIDATION";
        public const string FOR_TRANSMITTAL = "FOR TRANSMITTAL";
        public const string TRANSMITTED = "TRANSMITTED";
        public static string[] ALL_OCCU_PERMIT_STATUS = { FOR_PAYMENT_VERIFICATION, FOR_PAYMENT_VALIDATION, FOR_TRANSMITTAL, TRANSMITTED };

        public const string MISCTYPE_OCCUPATIONAL_PERMIT = "OCCUPATIONAL PERMIT";
        public const string MISCTYPE_OVR = "OVR";
        public const string MISCTYPE_MARKET = "MARKET";
        public const string MISCTYPE_LIQUOR = "LIQUOR";


        //SIMILAR COLUMNS IN MISCELLENEOUS
        public static List<string> MISC_COMMON_COLUMN_NAMES = new List<string>
        { "Amount To Pay", "Transferred Amount", "ExcessShort", "Date of Payment", "Status", "Requesting Party", "Remarks", "Verified By", 
            "Verified Date", "LBP Date", "Validated By", "Validated Date", "Reference Number", "Transmitted By", "Transmitted Date", "Encoded By", "Encoded Date", "Released By", "Released Date" };

        //COLUMN NAMES OF THE OCCUPATIONAL PERMIT
        public static List<string> MISC_OCCPERMIT_COLUMN_NAMES = new List<string> 
        { "MiscID", "Misc Type", "Taxpayer's Name", "O.P Number", "OPA Tracking Number", "Mode of Payment",};

        //PROPERTY NAMES OF THE OCCUPATIONAL PERMIT
        public static List<string> MISC_OCCPERMIT_PROPERTY_NAMES = new List<string>
        { "MiscID", "MiscType", "TaxpayersName", "OrderOfPaymentNum", "OPATrackingNum", "ModeOfPayment",};


        //COLUMN NAMES OF PTR
        public static List<string> MISC_PTR_COLUMN_NAMES = new List<string>
        { "MiscID", "Misc Type", "Taxpayer's Name", "Profession", "Last O.R Date ", "Last O.R No.", "PRC/IBP No."};

        //PROPERTY NAMES OF PTR
        public static List<string> MISC_PTR_PROPERTY_NAMES = new List<string>
        { "MiscID", "MiscType", "TaxpayersName", "Profession", "LastORDate", "LastORNo", "PRC_IBP_No",};


        //COLUMN NAMES OF HEALTH CERT
        public static List<string> MISC_HEALTHCERT_COLUMN_NAMES = new List<string>
        { "MiscID", "Misc Type", "Taxpayer's Name"};

        //PROPERTY NAMES OF HEALTH CERT
        public static List<string> MISC_HEALTHCERT_PROPERTY_NAMES = new List<string>
        { "MiscID", "MiscType", "TaxpayersName"};

        //COLUMN NAMES OF TAX CLEARANCE
        public static List<string> MISC_TAXCLEARANCE_COLUMN_NAMES = new List<string>
        { "MiscID", "Misc Type", "Taxpayer's Name"};

        //PROPERTY NAMES OF TAX CLEARANCE
        public static List<string> MISC_TAXCLEARANCE_PROPERTY_NAMES = new List<string>
        { "MiscID", "MiscType", "TaxpayersName"};


        public static List<string> MISC_COMMON_PROPERTY_NAMES = new List<string>
        { "AmountToBePaid", "TransferredAmount", "ExcessShort", "PaymentDate", "Status", "RequestingParty", "Remarks", "VerifiedBy", 
            "VerifiedDate", "LBPDate", "ValidatedBy", "ValidatedDate", "RefNum", "TransmittedBy", "TransmittedDate", "EncodedBy", "EncodedDate", "ReleasedBy", "ReleasedDate" };


        static MISCUtil()
        {
            MISC_OCCPERMIT_COLUMN_NAMES.AddRange(MISC_COMMON_COLUMN_NAMES);
            MISC_OCCPERMIT_PROPERTY_NAMES.AddRange(MISC_COMMON_PROPERTY_NAMES);

            MISC_PTR_COLUMN_NAMES.AddRange(MISC_COMMON_COLUMN_NAMES);
            MISC_PTR_PROPERTY_NAMES.AddRange(MISC_COMMON_PROPERTY_NAMES);

            MISC_HEALTHCERT_COLUMN_NAMES.AddRange(MISC_COMMON_COLUMN_NAMES);
            MISC_HEALTHCERT_PROPERTY_NAMES.AddRange(MISC_COMMON_PROPERTY_NAMES);

            MISC_TAXCLEARANCE_COLUMN_NAMES.AddRange(MISC_COMMON_COLUMN_NAMES);
            MISC_TAXCLEARANCE_PROPERTY_NAMES.AddRange(MISC_COMMON_PROPERTY_NAMES);
        }
    }
}
