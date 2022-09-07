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
        /// <summary>
        /// Returns the list of records from the database. 
        /// </summary>
        /// <returns></returns>
        public static List<EmailTemplate> SelectLatest()
        {
            using (SqlConnection conn = DbUtils.getConnection())
            {
                return conn.Query<EmailTemplate>($"SELECT TOP {GlobalConstants.LISTVIEW_MAX_ROWS} * FROM JO_RPT_EmailTemplate where Deleted != 1 order by TemplateID DESC").ToList();
            }
        }

        /// <summary>
        /// Returns a list of records based on the Name of the email template.
        /// </summary>
        /// <param name="Name"></param>
        /// <returns></returns>
        public static EmailTemplate SelectByName(string Name)
        {
            using (SqlConnection conn = DbUtils.getConnection())
            {
                return conn.QuerySingleOrDefault<EmailTemplate>($"SELECT * FROM JO_RPT_EmailTemplate where Name = @Name and Deleted != 1", new { Name = Name });
            }
        }

        /// <summary>
        /// Gets the entire row depending on the TemplateID.
        /// </summary>
        /// <param name="TemplateID"></param>
        /// <returns></returns>
        public static EmailTemplate Get(long TemplateID)
        {
            using (SqlConnection conn = DbUtils.getConnection())
            {
                return conn.Get<EmailTemplate>(TemplateID);
            }
        }

        /// <summary>
        /// Inserts data to the database.
        /// </summary>
        /// <param name="modelInstance"></param>
        /// <returns></returns>
        public static long Insert(EmailTemplate modelInstance)
        {
            using (SqlConnection conn = DbUtils.getConnection())
            {
                BeforeInsertOrUpdate(conn, modelInstance);
                return conn.Insert<EmailTemplate>(modelInstance);
            }
        }

        /// <summary>
        /// Tagging of the email template if it is for Assessment or for Receipt.
        /// </summary>
        /// <param name="conn"></param>
        /// <param name="modelInstance"></param>
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

        /// <summary>
        /// Updates entire row in the database. 
        /// </summary>
        /// <param name="modelInstance"></param>
        /// <returns></returns>
        public static bool Update(EmailTemplate modelInstance)
        {
            using (SqlConnection conn = DbUtils.getConnection())
            {
                BeforeInsertOrUpdate(conn, modelInstance);
                return conn.Update<EmailTemplate>(modelInstance);
            }
        }

        /// <summary>
        /// Tagging of deleted record in the database.
        /// </summary>
        /// <param name="modelInstance"></param>
        /// <returns></returns>
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
