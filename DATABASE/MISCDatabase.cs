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
        public static MiscelleneousOccuPermit Get(long MiscID)
        {
            using (SqlConnection conn = DbUtils.getConnection())
            {
                return conn.Get<MiscelleneousOccuPermit>(MiscID);
            }
        }

        public static void InsertMisc(MiscelleneousOccuPermit modelInstance)
        {
            using (SqlConnection conn = DbUtils.getConnection())
            {
                conn.Insert<MiscelleneousOccuPermit>(modelInstance);
            }
        }

        /// <summary>
        /// Updates entire row in the database. 
        /// </summary>
        public static bool UpdateMisc(MiscelleneousOccuPermit modelInstance)
        {
            using (SqlConnection conn = DbUtils.getConnection())
            {
                bool result = conn.Update<MiscelleneousOccuPermit>(modelInstance);
                return result;
            }
        }

        public static List<MiscelleneousOccuPermit> SelectLatest(string miscType)
        {
            using (SqlConnection conn = DbUtils.getConnection())
            {
                String query = $"SELECT * FROM Jo_MISC WHERE MiscType = @miscType order by MiscID asc";
                return conn.Query<MiscelleneousOccuPermit>(query, new { MiscType = miscType }).ToList();
            }
        }


    }
}
