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
        public static List<ReportUserActivity> SelectUserActivity(DateTime _DateFrom, DateTime _DateTo)
        {
            using (SqlConnection conn = DbUtils.getConnection())
            {
                return conn.Query<ReportUserActivity>(
                    "SELECT DisplayName, " +
                    "    (SELECT COUNT(*) FROM Jo_RPT r WHERE DeletedRecord = 0 and r.EncodedBy = u.DisplayName   and CAST(EncodedDate AS Date)   >= CAST(@FromDate AS Date) and CAST(EncodedDate AS Date)   <= CAST(@ToDate AS Date) ) as EncodedCount," +
                    "    (SELECT COUNT(*) FROM Jo_RPT r WHERE DeletedRecord = 0 and r.BilledBy = u.DisplayName    and CAST(BilledDate AS Date)    >= CAST(@FromDate AS Date) and CAST(BilledDate AS Date)    <= CAST(@ToDate AS Date) ) as BilledCount," +
                    "    (SELECT COUNT(*) FROM Jo_RPT r WHERE DeletedRecord = 0 and r.VerifiedBy = u.DisplayName  and CAST(VerifiedDate AS Date)  >= CAST(@FromDate AS Date) and CAST(VerifiedDate AS Date)  <= CAST(@ToDate AS Date) ) as VerifiedCount," +
                    "    (SELECT COUNT(*) FROM Jo_RPT r WHERE DeletedRecord = 0 and r.ValidatedBy = u.DisplayName and CAST(ValidatedDate AS Date) >= CAST(@FromDate AS Date) and CAST(ValidatedDate AS Date) <= CAST(@ToDate AS Date) ) as ValidatedCount," +
                    "    (SELECT COUNT(*) FROM Jo_RPT r WHERE DeletedRecord = 0 and r.UploadedBy = u.DisplayName  and CAST(UploadedDate AS Date)  >= CAST(@FromDate AS Date) and CAST(UploadedDate AS Date)  <= CAST(@ToDate AS Date) ) as UploadCount," +
                    "    (SELECT COUNT(*) FROM Jo_RPT r WHERE DeletedRecord = 0 and r.ReleasedBy = u.DisplayName  and CAST(ReleasedDate AS Date)  >= CAST(@FromDate AS Date) and CAST(ReleasedDate AS Date)  <= CAST(@ToDate AS Date) ) as ReleasedCount" +
                    " FROM Jo_RPT_Users u" +
                    " WHERE isActive = 1 order by DisplayName asc", new { FromDate = _DateFrom, ToDate = _DateTo }).ToList();
            }
        }
    }
}
