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
        public static long InsertPicture(RPTAttachPicture rptAttachPicture)
        {
            using (SqlConnection conn = DbUtils.getConnection())
            {
                return conn.Insert<RPTAttachPicture>(rptAttachPicture);
            }
        }

        public static bool Update(RPTAttachPicture RptPicture)
        {
            using (SqlConnection conn = DbUtils.getConnection())
            {
                return conn.Update<RPTAttachPicture>(RptPicture);
            }
        }

        public static RPTAttachPicture SelectByRPTAndDocumentType(long RPTid, string DocumentType)
        {
            using (SqlConnection conn = DbUtils.getConnection())
            {
                return conn.QuerySingleOrDefault<RPTAttachPicture>($"SELECT * FROM Jo_RPT_Pictures where RPTId= @RPTId and DocumentType = @DocumentType", new { RPTId = RPTid, DocumentType = DocumentType });
            }
        }

        public static List<RPTAttachPicture> SelectByRPT(long RPTId)
        {
            using (SqlConnection conn = DbUtils.getConnection())
            {
                return conn.Query<RPTAttachPicture>($"SELECT * FROM Jo_RPT_Pictures where RPTId= @RPTId order by PictureId ASC", new { RPTId = RPTId }).ToList();
            }
        }

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
