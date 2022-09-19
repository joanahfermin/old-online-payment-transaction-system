using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper.Contrib.Extensions;
using Dapper;
using Microsoft.Data.SqlClient;

namespace SampleRPT1
{
    internal class RPTUserDatabase
    {
        /// <summary>
        /// Returns a user from the database.
        /// </summary>
        public static RPTUser FindByUserName(string UserName)
        {
            using (SqlConnection conn = DbUtils.getConnection())
            {
                return conn.QuerySingleOrDefault<RPTUser>($"SELECT * FROM JO_RPT_Users where UserName = @UserName", new { UserName = UserName });
            }
        }
    }
}
