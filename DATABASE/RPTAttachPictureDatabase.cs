using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper.Contrib.Extensions;
using Dapper;
using Microsoft.Data.SqlClient;
using System.IO;

namespace SampleRPT1
{
    internal class RPTAttachPictureDatabase
    {
        /// <summary>
        /// Inserts attachment to the database.
        /// </summary>
        public static long InsertPicture(RPTAttachPicture rptAttachPicture)
        {
            using (SqlConnection conn = DbUtils.getConnection())
            {
                if (rptAttachPicture.FileName == null || rptAttachPicture.FileName.Trim().Length == 0)
                {
                    rptAttachPicture.FileName = "RECEIPT.jpg";
                }

                return conn.Insert<RPTAttachPicture>(rptAttachPicture);
            }
        }

        public static void FixEmptyFileName()
        {
            using (SqlConnection conn = DbUtils.getConnection())
            {
                conn.Execute("UPDATE Jo_RPT_Pictures SET FileName = 'ATTACHEDPICTURE.jpg' WHERE FileName = NULL OR ltrim(rtrim(FileName)) =''");
            }
        }

        /// <summary>
        /// Updates entire row in the database.
        /// </summary>
        public static bool Update(RPTAttachPicture RptPicture)
        {
            using (SqlConnection conn = DbUtils.getConnection())
            {
                if (RptPicture.FileName == null || RptPicture.FileName.Trim().Length == 0)
                {
                    RptPicture.FileName = "RECEIPT.jpg";
                }

                return conn.Update<RPTAttachPicture>(RptPicture);
            }
        }

        /// <summary>
        /// Returns a list of records based on Rptid and Document type. 
        /// </summary>
        public static RPTAttachPicture SelectByRPTAndDocumentType(long RPTid, string DocumentType)
        {
            using (SqlConnection conn = DbUtils.getConnection())
            {
                return conn.QuerySingleOrDefault<RPTAttachPicture>($"SELECT * FROM Jo_RPT_Pictures where RPTId= @RPTId and DocumentType = @DocumentType", new { RPTId = RPTid, DocumentType = DocumentType });
            }
        }

        /// <summary>
        /// Returns a list of records based on Rptid. 
        /// </summary>
        /// <param name="RPTId"></param>
        /// <returns></returns>
        public static List<RPTAttachPicture> SelectByRPT(long RPTId)
        {
            using (SqlConnection conn = DbUtils.getConnection())
            {
                return conn.Query<RPTAttachPicture>($"SELECT * FROM Jo_RPT_Pictures where RPTId= @RPTId order by PictureId ASC", new { RPTId = RPTId }).ToList();
            }
        }

        public static RPTAttachPicture Get(long RPTId)
        {
            using (SqlConnection conn = DbUtils.getConnection())
            {
                return conn.Get<RPTAttachPicture>(RPTId);
            }
        }

        /// <summary>
        /// Confirms if the selected record has document: Assessment or Receipt.
        /// </summary>
        /// <param name="RptiDList"></param>
        /// <param name="DocumentType"></param>
        /// <returns></returns>
        public static bool HasDocumentType(List<long> RptiDList, string DocumentType)
        {
            using (SqlConnection conn = DbUtils.getConnection())
            {
                int count = conn.ExecuteScalar<int>($"SELECT count(*) FROM Jo_RPT_Pictures where RPTId in @RptiDList and DocumentType = @DocumentType", new { RptiDList = RptiDList, DocumentType = DocumentType });

                return count > 0;
            }
        }
    }
}
