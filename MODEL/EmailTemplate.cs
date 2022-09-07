using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper.Contrib.Extensions;

namespace SampleRPT1
{
    [Table("Jo_RPT_EmailTemplate")]

    //These are all objects of the table Jo_RPT_EmailTemplate.
    internal class EmailTemplate
    {
        [Key]
        public long TemplateID { get; set; }
        public string Name { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public int Deleted { get; set; } = 0;
        public bool isAssessment { get; set; }
        public bool isReceipt { get; set; }
    }
}
