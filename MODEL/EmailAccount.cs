using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper.Contrib.Extensions;

namespace SampleRPT1.MODEL
{
    [Table("Jo_RPT_EmailAccount")]

    //These are all objects of the table Jo_RPT_EmailAccount.
    class EmailAccount
    {
        public string UserName { get; set; }
        public string PassWord { get; set; }
    }
}
