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
        public static string CONNECTION_STRING = ConfigurationManager.AppSettings["ConnectionString"];

        public static SqlConnection getConnection()
        {
            SqlConnection cnn = new SqlConnection(CONNECTION_STRING);
            //SqlConnection cnn = new(CONNECTION_STRING);
            cnn.Open();

            return cnn;
        }
    }
}
