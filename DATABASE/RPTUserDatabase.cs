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
        public static RPTUser FindByUserName(string UserName)
        {
            using (SqlConnection conn = DbUtils.getConnection())
            {
                return conn.QuerySingleOrDefault<RPTUser>($"SELECT * FROM JO_Z2 where UserName = @UserName", new { UserName = UserName });
            }
        }
    }
}
