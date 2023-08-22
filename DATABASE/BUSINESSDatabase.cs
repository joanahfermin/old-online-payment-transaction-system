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
    internal class BUSINESSDatabase
    {
        public static void Insert_BusinessRecord(BusinessTaxObj modelInstance)
        {
            using (SqlConnection con = DbUtils.getConnection())
            {
                con.Insert<BusinessTaxObj>(modelInstance);
            }
        }
    }
}
