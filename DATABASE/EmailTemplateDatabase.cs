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
    internal class EmailTemplateDatabase
    {
        public static List<EmailTemplate> SelectLatest()
        {
            using (SqlConnection conn = DbUtils.getConnection())
            {
                //Returns the list of records from the database. 
                return conn.Query<EmailTemplate>($"SELECT TOP {GlobalConstants.LISTVIEW_MAX_ROWS} * FROM JO_RPT_EmailTemplate where Deleted != 1 order by TemplateID DESC").ToList();
            }
        }

        public static EmailTemplate SelectByName(string Name)
        {
            using (SqlConnection conn = DbUtils.getConnection())
            {
                return conn.QuerySingleOrDefault<EmailTemplate>($"SELECT * FROM JO_RPT_EmailTemplate where Name = @Name and Deleted != 1", new { Name = Name });
            }
        }

        public static EmailTemplate Get(long TemplateID)
        {
            using (SqlConnection conn = DbUtils.getConnection())
            {
                return conn.Get<EmailTemplate>(TemplateID);
            }
        }

        public static long Insert(EmailTemplate modelInstance)
        {
            using (SqlConnection conn = DbUtils.getConnection())
            {
                BeforeInsertOrUpdate(conn, modelInstance);
                return conn.Insert<EmailTemplate>(modelInstance);
            }
        }

        private static void BeforeInsertOrUpdate(SqlConnection conn, EmailTemplate modelInstance)
        {
            if (modelInstance.isAssessment)
            {
                conn.Execute("Update JO_RPT_EmailTemplate set isAssessment = 0");
            }
            if (modelInstance.isReceipt)
            {
                conn.Execute("Update JO_RPT_EmailTemplate set isReceipt = 0");
            }
        }

        public static bool Update(EmailTemplate modelInstance)
        {
            using (SqlConnection conn = DbUtils.getConnection())
            {
                BeforeInsertOrUpdate(conn, modelInstance);
                return conn.Update<EmailTemplate>(modelInstance);
            }
        }

        public static bool Delete(EmailTemplate modelInstance)
        {
            using (SqlConnection conn = DbUtils.getConnection())
            {
                modelInstance.Deleted = 1;
                return conn.Update<EmailTemplate>(modelInstance);
            }
        }
    }
}
