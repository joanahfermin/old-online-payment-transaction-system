using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper.Contrib.Extensions;

namespace SampleRPT1
{
    [Table("Jo_RPT_Audit")]

    ///These are all objects of the table Jo_RPT.
    
    internal class RealPropertyTaxAudit
    {
        [Key]
        public long AuditID { get; set; }
        public string Action { get; set; }
        public long RptID { get; set; }
        public string TaxDec { get; set; }
        public string TaxPayerName { get; set; }
        public decimal AmountToPay { get; set; }
        public decimal AmountTransferred { get; set; }
        public decimal TotalAmountTransferred { get; set; }
        public decimal ExcessShortAmount { get; set; }
        public string Bank { get; set; }
        public string YearQuarter { get; set; }
        public string Status { get; set; }
        public string RequestingParty { get; set; }
        public string EncodedBy { get; set; }
        public DateTime? EncodedDate { get; set; }
        public string RefNum { get; set; }
        public string RPTremarks { get; set; }
        public string SentBy { get; set; }
        public DateTime? SentDate { get; set; }
        public string BilledBy { get; set; }
        public string BillCount { get; set; }
        public DateTime? BilledDate { get; set; }
        public string VerifiedBy { get; set; }
        public DateTime? PaymentDate { get; set; }
        public DateTime? VerifiedDate { get; set; }
        public string ValidatedBy { get; set; }
        public DateTime? ValidatedDate { get; set; }       
        public string UploadedBy { get; set; }
        public DateTime? UploadedDate { get; set; }
        public string ReleasedBy { get; set; }
        public DateTime? ReleasedDate { get; set; }
        public string VerRemarks { get; set; }
        public string ValRemarks { get; set; }
        public string UploaderRemarks { get; set; }
        public string ReleasedRemarks { get; set; }
        public string LocCode { get; set; }
        public string RepName { get; set; }
        public string ContactNumber { get; set; }
        public bool WithAuthorizationLetter { get; set; } = false;
        public bool is_Released { get; set; } = false;
        public int DeletedRecord { get; set; } = 0;
        public bool SendAssessmentReady { get; set; } = false;
        public bool SendReceiptReady { get; set; } = false;

        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string LastUpdateBy { get; set; }
        public DateTime? LastUpdateDate { get; set; }

    }
}
