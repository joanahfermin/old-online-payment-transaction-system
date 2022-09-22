using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper.Contrib.Extensions;
using Dapper;
using Microsoft.Data.SqlClient;
using SampleRPT1.MODEL;

namespace SampleRPT1
{
    internal class RPTBankDatabase
    {
        public static RPTBank SelectByBankName(string bankName)
        {
            using (SqlConnection conn = DbUtils.getConnection())
            {
                return conn.QuerySingleOrDefault<RPTBank>($"SELECT * FROM Jo_RPT_Banks where bankName = @bankName", new { bankName = bankName });
            }
        }

        public static long Insert(RPTBank modelInstance)
        {
            using (SqlConnection conn = DbUtils.getConnection())
            {
                return conn.Insert<RPTBank>(modelInstance);
            }
        }

        public static List<RPTBank> SelectAllBank()
        {
            using (SqlConnection conn = DbUtils.getConnection())
            {
                return conn.Query<RPTBank>($"SELECT * FROM Jo_RPT_Banks order by BankName ASC").ToList();
            }
        }
    }
}
