﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleRPT1.MODEL
{
    internal class ReportCollection
    {
        public string TaxDec{ get; set; }
        public string TaxPayerName { get; set; }
        public decimal Collection { get; set; }
        public decimal Billing { get; set; }
        public decimal ExcessShort { get; set; }
        public string RPTremarks { get; set; }

    }
}