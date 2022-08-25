using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper.Contrib.Extensions;

namespace SampleRPT1.MODEL
{
    [Table("Jo_Z5")]
    class EmailAccount
    {
        public string UserName { get; set; }
        public string PassWord { get; set; }
    }
}
