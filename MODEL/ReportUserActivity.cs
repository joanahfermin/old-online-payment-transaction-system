using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleRPT1.MODEL
{
     class ReportUserActivity
    {
        public string DisplayName { get; set; }
        public int EncodedCount { get; set; }
        public int BilledCount { get; set; }
        public int VerifiedCount { get; set; }
        public int UploadCount { get; set; }
        public int ValidatedCount { get; set; }
        public int ReleasedCount { get; set; }
    }
}
