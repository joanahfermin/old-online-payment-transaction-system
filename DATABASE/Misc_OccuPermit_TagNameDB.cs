using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleRPT1.DATABASE
{
    internal class Misc_OccuPermit_TagNameDB
    {
        public static string SelectBy_TaxpayerName(string OPNumber)
        {
            using (SqlConnection conn = DbUtils.getConnectionToMISCReportV_OccuPerm_Name())
            {
                //return conn.QuerySingleOrDefault<string>($"SELECT TOP (1) [BillNumber] FROM [TaxpayerLName] where BillNumber = @OPNumber order by billdate desc", new { OPNumber = OPNumber });
                return conn.QuerySingleOrDefault<string>($"SELECT TOP (1) [BillNumber] FROM [TaxpayerLName] where BillNumber = @OPNumber", new { OPNumber = OPNumber });

            }
        }
    }
}
