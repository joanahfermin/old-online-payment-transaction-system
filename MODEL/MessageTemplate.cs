using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper.Contrib.Extensions;

namespace SampleRPT1
{
    [Table("Jo_Z3")]
    internal class MessageTemplate
    {
        [Key]
        public long TemplateID { get; set; }
        public string Name { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public int Deleted { get; set; } = 0;
    }
}
