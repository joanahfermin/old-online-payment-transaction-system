using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Data.SqlClient;
using SampleRPT1.MODEL;
using SampleRPT1.Service;

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

        public static List<ReportCollection> Select_Collector_RPT(DateTime _DateFrom, DateTime _DateTo)
        {
            using (SqlConnection conn = DbUtils.getConnection())
            {
                string UserName = SecurityService.getLoginUser().DisplayName;
                return conn.Query<ReportCollection>(
                "SELECT TaxDec, TaxPayerName, Collection, Billing, ExcessShort, iif(rptremarks like '%SHORT%' or rptremarks like '%CASH%' or rptremarks like '%MC%' or rptremarks like '%EXCESS%', rptremarks, '' ) as rptremarks " +
                "FROM ( " +
                " SELECT TaxDec, TaxPayerName, AmountTransferred as Collection,  AmountToPay as Billing, 0 as ExcessShort, RPTremarks, ValidatedDate, RPTID, EncodedDate " +
                " FROM Jo_RPT r " +
                " WHERE Bank in @OnlinePaymentChannels " +
                " and DeletedRecord = 0 and CAST(ValidatedDate AS Date)>= CAST(@FromDate AS Date) and CAST(ValidatedDate AS Date) <= CAST(@ToDate AS Date) and ValidatedBy=@UserName " +
                " UNION " +

                " SELECT TaxDec, TaxPayerName, TotalAmountTransferred as Collection, AmountToPay as Billing, ExcessShortAmount as ExcessShort, RPTremarks, (select min(ValidatedDate) from Jo_RPT r2 where r2.RefNum = r.RefNum ) as ValidatedDate, RPTID, EncodedDate " +
                " FROM Jo_RPT r " +
                " WHERE Bank not in @OnlinePaymentChannels and RefNum is not null " +
                " and DeletedRecord = 0 and CAST(ValidatedDate AS Date)>= CAST(@FromDate AS Date) and CAST(ValidatedDate AS Date) <= CAST(@ToDate AS Date) and ValidatedBy=@UserName " +
                " UNION " +

                " SELECT TaxDec, TaxPayerName, TotalAmountTransferred as Collection, AmountToPay as Billing, ExcessShortAmount as ExcessShort, RPTremarks, ValidatedDate, RPTID, EncodedDate " +
                " FROM Jo_RPT r " +
                " WHERE Bank not in @OnlinePaymentChannels and RefNum is null " +
                " and DeletedRecord = 0 and CAST(ValidatedDate AS Date)>= CAST(@FromDate AS Date) and CAST(ValidatedDate AS Date) <= CAST(@ToDate AS Date) and ValidatedBy=@UserName " +
                ") AS ReportView " +
                "order by ValidatedDate, EncodedDate ", 
                
                new { FromDate = _DateFrom, ToDate = _DateTo, UserName = UserName, OnlinePaymentChannels = RPTGcashPaymaya.E_PAYMENT_CHANNEL }).ToList();
            }
        }

       
        public static List<ReportCollection_OccuPermit> Select_Collector_MISC(DateTime _DateFrom, DateTime _DateTo)
        {
            using (SqlConnection conn = DbUtils.getConnection())
            {
                string UserName = SecurityService.getLoginUser().DisplayName;
                return conn.Query<ReportCollection_OccuPermit>(

                "SELECT TaxPayersName, OrderOfPaymentNum, Billing, Collection, ExcessShort, iif(Remarks like '%SHORT%' or Remarks like '%CASH%' or Remarks like '%MC%' or Remarks like '%EXCESS%' or Remarks like '%MANUAL%', Remarks, '' ) as Remarks " +
                "FROM ( " +
                " SELECT TaxPayersName, OrderOfPaymentNum, AmountToBePaid as Billing, TransferredAmount as Collection, 0 as ExcessShort, Remarks, ValidatedDate, MiscID, EncodedDate " +
                " FROM Jo_MISC r " +
                " WHERE ModeOfPayment in @OnlinePaymentChannels " +
                " and DeletedRecord = 0 and CAST(ValidatedDate AS Date)>= CAST(@FromDate AS Date) and CAST(ValidatedDate AS Date) <= CAST(@ToDate AS Date) and ValidatedBy=@UserName " +
                " UNION " +

                " SELECT TaxPayersName, OrderOfPaymentNum, AmountToBePaid as Billing, TransferredAmount as Collection, ExcessShort as ExcessShort, Remarks, (select min(ValidatedDate) from Jo_MISC r2 where r2.RefNum = r.RefNum ) as ValidatedDate, MiscID, EncodedDate " +
                " FROM Jo_MISC r " +
                " WHERE ModeOfPayment not in @OnlinePaymentChannels and RefNum is not null " +
                " and DeletedRecord = 0 and CAST(ValidatedDate AS Date)>= CAST(@FromDate AS Date) and CAST(ValidatedDate AS Date) <= CAST(@ToDate AS Date) and ValidatedBy=@UserName " +
                " UNION " +

                " SELECT TaxPayersName, OrderOfPaymentNum, AmountToBePaid as Billing, TransferredAmount as Collection, ExcessShort as ExcessShort, Remarks, ValidatedDate, MiscID, EncodedDate " +
                " FROM Jo_MISC r " +
                " WHERE ModeOfPayment not in @OnlinePaymentChannels and RefNum is null " +
                " and DeletedRecord = 0 and CAST(ValidatedDate AS Date)>= CAST(@FromDate AS Date) and CAST(ValidatedDate AS Date) <= CAST(@ToDate AS Date) and ValidatedBy=@UserName " +
                ") AS ReportView " +
                "order by ValidatedDate, EncodedDate ",

                new { FromDate = _DateFrom, ToDate = _DateTo, UserName = UserName, OnlinePaymentChannels = RPTGcashPaymaya.E_PAYMENT_CHANNEL }).ToList();
            }
        }

        //public static List<ReportCollection_OccuPermit> Select_Collector_MISC(DateTime _DateFrom, DateTime _DateTo)
        //{
        //    using (SqlConnection conn = DbUtils.getConnection())
        //    {
        //        string UserName = SecurityService.getLoginUser().DisplayName;
        //        return conn.Query<ReportCollection_OccuPermit>(
        //        " SELECT TaxpayersName, OrderOfPaymentNum, AmountToBePaid, TransferredAmount, iif(Remarks like '%SHORT%' or Remarks like '%CASH%' or Remarks like '%MC%' or Remarks like '%EXCESS%', Remarks, '' )" +
        //        " as Remarks  FROM Jo_MISC " +
        //        " where DeletedRecord = 0 and MiscType = 'OCCUPATIONAL PERMIT' or MiscType = 'OVR' or MiscType = 'LIQUOR' or MiscType = 'PTR' or MiscType = 'HEALTH CERTIFICATE' or MiscType = 'TAX CLEARANCE' " +
        //        " and CAST(ValidatedDate AS Date)>= CAST(@FromDate AS Date) and CAST(ValidatedDate AS Date) <= CAST(@ToDate AS Date) and ValidatedBy=@UserName " +
        //        " order by ValidatedDate, EncodedDate ",

        //        new { FromDate = _DateFrom, ToDate = _DateTo, UserName = UserName }).ToList();
        //    }
        //}
    }
}
