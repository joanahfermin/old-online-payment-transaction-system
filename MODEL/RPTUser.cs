using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper.Contrib.Extensions;

namespace SampleRPT1
{
    [Table("Jo_RPT_Users")]

    //These are all objects of the table Jo_RPT_Users.
    internal class RPTUser
    {
        [Key]
        public long UserID { get; set; }
        public string UserName { get; set; }
        public string DisplayName { get; set; }
        public string PassWord { get; set; }
        public bool isEncoder { get; set; }
        public bool isBiller { get; set; }
        public bool isVerifier { get; set; }
        public bool isValidator { get; set; }
        public bool isUploader { get; set; }
        public bool isReleaser { get; set; }
        public bool isAutomatedEmailSender { get; set; }
        public bool isActive { get; set; }
        public bool canDelete { get; set; }
    }
}
