﻿using SampleRPT1.UTILITIES;
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
        public const string ASSESS_RECORD = "ASSESS RECORD";
        public const string VERIFY_PAYMENT = "VERIFY PAYMENT";
        public const string VALIDATE_PAYMENT = "VALIDATE PAYMENT";
        public const string TRANSMIT = "TRANSMIT";
        public const string RELEASE = "RELEASE";
        public const string DELETED_RECORD = "DELETE";
        public const string TAG_DUPLICATE_RECORD = "TAG DUPLICATE RECORD";
        public const string ACTION_PENDING = "PENDING";
        public const string ACTION_DONE = "DONE";

        public static string[] ALL_ACTIONS = { ASSESS_RECORD, VERIFY_PAYMENT, VALIDATE_PAYMENT, TRANSMIT, RELEASE, DELETED_RECORD, TAG_DUPLICATE_RECORD, ACTION_PENDING, ACTION_DONE };

        //OCCUPATIONAL PERMIT STATUS.
        public const string STATUS_DONE = "DONE";
        public const string FOR_ASSESSMENT = "FOR ASSESSMENT";
        public const string FOR_PAYMENT_VERIFICATION = "FOR PAYMENT VERIFICATION";
        public const string FOR_PAYMENT_VALIDATION = "FOR PAYMENT VALIDATION";
        public const string FOR_TRANSMITTAL = "FOR TRANSMITTAL";
        public const string STATUS_PENDING = "PENDING";
        public const string RELEASED = "RELEASED";
        public const string TRANSMITTED = "TRANSMITTED";
        public static string[] ALL_OCCU_PERMIT_STATUS = { STATUS_DONE, FOR_ASSESSMENT, FOR_PAYMENT_VERIFICATION, FOR_PAYMENT_VALIDATION, FOR_TRANSMITTAL, STATUS_PENDING, RELEASED, TRANSMITTED };

        public const string MISCTYPE_OCCUPATIONAL_PERMIT = "OCCUPATIONAL PERMIT";
        public const string MISCTYPE_OVR = "OVR";
        public const string MISCTYPE_MARKET = "MARKET";
        public const string MISCTYPE_LIQUOR = "LIQUOR";
        public const string MISCTYPE_ZONING = "ZONING";

        //SIMILAR COLUMNS IN MISCELLENEOUS
        public static List<string> MISC_COMMON_COLUMN_NAMES = new List<string>
        { "Amount To Pay", "Transferred Amount", "ExcessShort", "Date of Payment", "Status", "Requesting Party", "Remarks", "Verified By", 
            "Verified Date", "LBP Date", "Validated By", "Validated Date", "Reference Number", "Transmitted By", "Transmitted Date", "Encoded By", "Encoded Date", "Released By", "Released Date", "Rep. Name", "Contact No." };

        public static List<string> MISC_COMMON_PROPERTY_NAMES = new List<string>
        { "AmountToBePaid", "TransferredAmount", "ExcessShort", "PaymentDate", "Status", "RequestingParty", "Remarks", "VerifiedBy", 
            "VerifiedDate", "LBPDate", "ValidatedBy", "ValidatedDate", "RefNum", "TransmittedBy", "TransmittedDate", "EncodedBy", "EncodedDate", "ReleasedBy", "ReleasedDate", "RepName", "ContactNumber" };

        public static Dictionary<string, List<string>> LIST_VIEW_COLUMN_NAMES_MAPPING = new Dictionary<string, List<string>>();

        public static Dictionary<string, List<string>> LIST_VIEW_PROPERTY_NAMES_MAPPING = new Dictionary<string, List<string>>();

        static MISCUtil()
        {
            LIST_VIEW_COLUMN_NAMES_MAPPING.Add(Misc_Type.OCCUPATIONAL_PERMIT, new List<string>
                { "MiscID", "Misc Type", "Taxpayer's Name", "O.P Number", "OPA Tracking Number", "Mode of Payment"});
            LIST_VIEW_PROPERTY_NAMES_MAPPING.Add(Misc_Type.OCCUPATIONAL_PERMIT, new List<string>
                { "MiscID", "MiscType", "TaxpayersName", "OrderOfPaymentNum", "OPATrackingNum", "ModeOfPayment"});

            LIST_VIEW_COLUMN_NAMES_MAPPING.Add(Misc_Type.OVR, new List<string>
                { "MiscID", "Misc Type", "Taxpayer's Name", "O.P Number", "OPA Tracking Number", "Mode of Payment"});
            LIST_VIEW_PROPERTY_NAMES_MAPPING.Add(Misc_Type.OVR, new List<string>
                { "MiscID", "MiscType", "TaxpayersName", "OrderOfPaymentNum", "OPATrackingNum", "ModeOfPayment"});

            LIST_VIEW_COLUMN_NAMES_MAPPING.Add(Misc_Type.LIQUOR, new List<string>
                { "MiscID", "Misc Type", "Taxpayer's Name", "O.P Number", "MP Number", "Mode of Payment"});
            LIST_VIEW_PROPERTY_NAMES_MAPPING.Add(Misc_Type.LIQUOR, new List<string>
                { "MiscID", "MiscType", "TaxpayersName", "OrderOfPaymentNum", "OPATrackingNum", "ModeOfPayment"});

            LIST_VIEW_COLUMN_NAMES_MAPPING.Add(Misc_Type.MARKET, new List<string>
                { "MiscID", "Misc Type", "Taxpayer's Name", "O.P Number", "OPA Tracking Number", "Mode of Payment"});
            LIST_VIEW_PROPERTY_NAMES_MAPPING.Add(Misc_Type.MARKET, new List<string>
                { "MiscID", "MiscType", "TaxpayersName", "OrderOfPaymentNum", "OPATrackingNum", "ModeOfPayment"});

            LIST_VIEW_COLUMN_NAMES_MAPPING.Add(Misc_Type.ZONING, new List<string>
                { "MiscID", "Misc Type", "Taxpayer's Name", "O.P Number", "OPA Tracking Number", "Mode of Payment"});
            LIST_VIEW_PROPERTY_NAMES_MAPPING.Add(Misc_Type.ZONING, new List<string>
                { "MiscID", "MiscType", "TaxpayersName", "OrderOfPaymentNum", "OPATrackingNum", "ModeOfPayment"});

            //LIST_VIEW_COLUMN_NAMES_MAPPING.Add(Misc_Type.HEALTH_CERTIFICATE, new List<string>
            //    { "MiscID", "Misc Type", "Taxpayer's Name"});
            //LIST_VIEW_PROPERTY_NAMES_MAPPING.Add(Misc_Type.HEALTH_CERTIFICATE, new List<string>
            //    { "MiscID", "MiscType", "TaxpayersName"});

            //LIST_VIEW_COLUMN_NAMES_MAPPING.Add(Misc_Type.TAX_CLEARANCE, new List<string>
            //    { "MiscID", "Misc Type", "Taxpayer's Name"});
            //LIST_VIEW_PROPERTY_NAMES_MAPPING.Add(Misc_Type.TAX_CLEARANCE, new List<string>
            //    { "MiscID", "MiscType", "TaxpayersName"});

            //LIST_VIEW_COLUMN_NAMES_MAPPING.Add(Misc_Type.CONTRACTORS_TAX, new List<string>
            //    { "MiscID", "Misc Type", "Taxpayer's Name"});
            //LIST_VIEW_PROPERTY_NAMES_MAPPING.Add(Misc_Type.CONTRACTORS_TAX, new List<string>
            //    { "MiscID", "MiscType", "TaxpayersName"});



            foreach (List<string> columnNames in LIST_VIEW_COLUMN_NAMES_MAPPING.Values)
            {
                columnNames.AddRange(MISC_COMMON_COLUMN_NAMES);
            }

            foreach (List<string> propertyNames in LIST_VIEW_PROPERTY_NAMES_MAPPING.Values)
            {
                propertyNames.AddRange(MISC_COMMON_PROPERTY_NAMES);
            }
        }
    }
}
