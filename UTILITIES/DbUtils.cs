using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using System.Configuration;

namespace SampleRPT1
{

    internal class DbUtils
    {
        /// <summary>
        /// Establishing sql connection.
        /// </summary>
        /// <returns></returns>
        public static SqlConnection getConnection()
        {
            SqlConnection cnn = new SqlConnection(GlobalConstants.DATABASE_CONNECTION_STRING);
            cnn.Open();
            return cnn;
        }

        public static SqlConnection getConnectionToMISCReportV()
        {
            SqlConnection cnn = new SqlConnection(GlobalConstants.DATABASE_CONNECTION_STRING_TO_MISCREPORT);
            cnn.Open();
            return cnn;
        }
    }
}
