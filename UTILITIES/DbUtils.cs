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
        public static SqlConnection getConnection()
        {
            SqlConnection cnn = new SqlConnection(GlobalConstants.DATABASE_CONNECTION_STRING);
            cnn.Open();
            return cnn;
        }
    }
}
