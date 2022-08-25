using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Data.SqlClient;
using SampleRPT1.MODEL;

namespace SampleRPT1.DATABASE
{
    class EmailAccountDatabase
    {
        /// <summary>
        /// Find any email account randomly from pool of email accounts.
        /// </summary>
        /// <returns></returns>
        public static EmailAccount GetEmailAccount()
        {
            using (SqlConnection conn = DbUtils.getConnection())
            {
                return conn.QuerySingleOrDefault<EmailAccount>($"select TOP 1 * from JO_Z5 order by NEWID()");
            }
        }
    }
}
