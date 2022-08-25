using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper.Contrib.Extensions;
using Dapper;
using Microsoft.Data.SqlClient;
using SampleRPT1.MODEL;

namespace SampleRPT1.DATABASE
{
    class SystemSettingDatabase
    {
        public static SystemSetting SelectBySettingName(string SettingName)
        {
            using (SqlConnection conn = DbUtils.getConnection())
            {
                return conn.QuerySingleOrDefault<SystemSetting>($"SELECT * FROM Jo_Z6 where SettingName = @SettingName", new { SettingName = SettingName });
            }
        }
    }
}
