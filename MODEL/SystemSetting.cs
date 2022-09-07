using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper.Contrib.Extensions;

namespace SampleRPT1.MODEL
{
    [Table("Jo_RPT_SystemSetting")]

    //These are all objects of the table Jo_RPT_SystemSetting.
    class SystemSetting
    {
        public string SettingName { get; set; }
        public string SettingValue { get; set; }
    }
}
