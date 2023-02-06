using System;
using System.Collections.Generic;
//using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper.Contrib.Extensions;
using Dapper;
using Microsoft.Data.SqlClient;
using SampleRPT1.MODEL;

namespace SampleRPT1
{
    internal class MISCDatabase
    {
        public static void InsertMisc(MiscelleneousOccuPermit modelInstance)
        {
            using (SqlConnection conn = DbUtils.getConnection())
            {
                conn.Insert<MiscelleneousOccuPermit>(modelInstance);
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
