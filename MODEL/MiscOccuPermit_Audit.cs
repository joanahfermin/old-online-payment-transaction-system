using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper.Contrib.Extensions;

namespace SampleRPT1.MODEL
{
    [Table("Jo_MISC_Audit")]

    internal class MiscOccuPermit_Audit
    {
        [Key]
        public long AuditID { get; set; }
        public long MiscID { get; set; }
        public string MiscType { get; set; }
        public string Action { get; set; }
        public string TaxpayersName { get; set; }
        public string OrderOfPaymentNum { get; set; }
        public string ModeOfPayment { get; set; }
        public string OPATrackingNum { get; set; }
        public decimal AmountToBePaid { get; set; }
        public decimal TransferredAmount { get; set; }
        public decimal ExcessShort { get; set; }
        public DateTime? PaymentDate { get; set; }
        public string Status { get; set; }
        public string RequestingParty { get; set; }
        public string Remarks { get; set; }
        public string VerifiedBy { get; set; }
        public DateTime? VerifiedDate { get; set; }
        public DateTime? LBPDate { get; set; }
        public string ValidatedBy { get; set; }
        public DateTime? ValidatedDate { get; set; }
        public string RefNum { get; set; }
        public string EncodedBy { get; set; }
        public DateTime? EncodedDate { get; set; }
        public string TransmittedBy { get; set; }
        public DateTime? TransmittedDate { get; set; }
        public string ReleasedBy { get; set; }
        public DateTime? ReleasedDate { get; set; }
        public string LastUpdateBy { get; set; }
        public DateTime? LastUpdateDate { get; set; }

        public int DeletedRecord { get; set; } = 0;
    }
}
