using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Data.SqlClient;
using SampleRPT1.MODEL;

namespace SampleRPT1.DATABASE
{
    internal class ReportDatabase
    {
        public static List<ReportUserActivity> SelectUserActivity()
        {
            using (SqlConnection conn = DbUtils.getConnection())
            {
                return conn.Query<ReportUserActivity>(
                    "SELECT DisplayName, " +
                    "    (SELECT COUNT(*) FROM Jo_RPT r WHERE DeletedRecord = 0 and r.EncodedBy = u.DisplayName and CAST(GETDATE() AS Date) = CAST(EncodedDate AS Date)) as EncodedCount," +
                    "    (SELECT COUNT(*) FROM Jo_RPT r WHERE DeletedRecord = 0 and r.BilledBy = u.DisplayName and CAST(GETDATE() AS Date) = CAST(BilledDate AS Date)) as BilledCount," +
                    "    (SELECT COUNT(*) FROM Jo_RPT r WHERE DeletedRecord = 0 and r.ValidatedBy = u.DisplayName and CAST(GETDATE() AS Date) = CAST(ValidatedDate AS Date)) as ValidatedCount," +
                    "    (SELECT COUNT(*) FROM Jo_RPT r WHERE DeletedRecord = 0 and r.UploadedBy = u.DisplayName and CAST(GETDATE() AS Date ) = CAST(UploadedDate AS Date)) as UploadCount" +
                    " FROM Jo_RPT_Users u" +
                    " WHERE isActive = 1 order by DisplayName asc").ToList();
            }
        }
    }
}
