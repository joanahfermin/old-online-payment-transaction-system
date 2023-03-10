using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleRPT1.MODEL
{
    [Table("MiscDetailsBillingSTAGE")]

    internal class Misc_OccuPermit_TagName
    {
        public string BillNumber { get; set; }
        public string TaxpayerLName { get; set; }
    }
}
