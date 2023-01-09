using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleRPT1.MODEL
{
    [Table("Jo_RPT_Banks")]
    internal class RPTBank
    {
        [Key]
        public long BankID { get; set; }
        public string BankName { get; set; }
        public bool isEBank { get; set; }
    }
}
