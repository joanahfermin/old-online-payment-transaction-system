using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper.Contrib.Extensions;

namespace SampleRPT1.MODEL
{
    [Table("Jo_Business")]

    internal class BusinessTaxObj
    {
        [Key]
        public long BusinessID { get; set; }
        public string Business_Type { get; set; }
        public string MP_Number { get; set; }
        public string TaxpayersName { get; set; }
        public string BusinessName { get; set; }
        public string BillNumber { get; set; }
        public decimal BillAmount { get; set; }
        public decimal MiscFees { get; set; }
        public decimal TotalAmount { get; set; }
        public string Year { get; set; }
        public string Qtrs { get; set; }
        public string Status { get; set; }
        public string PaymentChannel { get; set; }
        public string VerifiedBy { get; set; }
        public DateTime? VerifiedDate { get; set; }
        public DateTime? DateOfPayment { get; set; }
        public string ValidatedBy { get; set; }
        public DateTime? ValidatedDate { get; set; }
        public string RequestingParty { get; set; }
        public string ContactNumber { get; set; }
        public string BussinessRemarks { get; set; }
        public string EncodedBy { get; set; }
        public DateTime? EncodedDate { get; set; }
        public string UploadedBy { get; set; }
        public DateTime? UploadedDate { get; set; }

        public string ReleasedBy { get; set; }
        public DateTime? ReleasedDate { get; set; }


        public bool DeletedRecord { get; set; } = false;
        public int DuplicateRecord { get; set; } = 0;
    }
}
