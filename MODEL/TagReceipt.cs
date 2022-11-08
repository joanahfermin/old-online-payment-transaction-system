using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleRPT1.MODEL
{
    internal class TagReceipt
    {
        //These are all objects of the table Jo_RPT_Users.

        public string MachNo { get; set; }
        public decimal ORAmount { get; set; }
        public string TaxYear { get; set; }
        public string Quarter { get; set; }
        //taxdec
        public string RefNo { get; set; }
        public DateTime OrDate { get; set; }
    }
}
