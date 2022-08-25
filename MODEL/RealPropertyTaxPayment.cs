using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper.Contrib.Extensions;
/// <summary>
/// JO: pwede na ata idelete ito
/// </summary>
namespace SampleRPT1
{
    [Table("Jo_Z3")]
    internal class RealPropertyTaxPayment
    {
        [Key]
        public long RptID { get; set; }
        public string TDNum { get; set; }
        public string YearQuarter { get; set; }
        public decimal AmountToPay { get; set; }
        public decimal TotalAmountTransferred { get; set; }
        //public decimal ExcessShortAmount { get; set; }
        //public string RefNum { get; set; }
        public string Remarks { get; set; }
    }
}
