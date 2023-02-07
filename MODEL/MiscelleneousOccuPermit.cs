using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper.Contrib.Extensions;

namespace SampleRPT1
{
    [Table("Jo_MISC")]

    internal class MiscelleneousOccuPermit
    {
        [Key]
        public long MiscID { get; set; }
        public string MiscType { get; set; }
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
        public string EncodedBy { get; set; }
        public DateTime? EncodedDate { get; set; }
        public string ReleasedBy { get; set; }
        public DateTime? ReleasedDate { get; set; }

        public int isDeleted { get; set; } = 0;
    }
}
