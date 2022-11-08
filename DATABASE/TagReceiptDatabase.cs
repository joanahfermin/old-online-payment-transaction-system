using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper.Contrib.Extensions;
using Dapper;
using Microsoft.Data.SqlClient;
using SampleRPT1.MODEL;
using SampleRPT1.Service;

namespace SampleRPT1.DATABASE
{
    internal class TagReceiptDatabase
    {
        public static List<TagReceipt> SelectAll()
        {
            using (SqlConnection conn = DbUtils.getConnectionToMISCReportV())
            {
                return conn.Query<TagReceipt>($"Select * FROM V_RPTMaster WHERE CAST(OrDate AS Date) >= DATEADD(day, -1, CAST(GETDATE() AS date))").ToList();
            }
        }


    }
}
