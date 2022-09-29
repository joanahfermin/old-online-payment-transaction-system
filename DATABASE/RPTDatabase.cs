using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper.Contrib.Extensions;
using Dapper;
using Microsoft.Data.SqlClient;
using SampleRPT1.MODEL;

namespace SampleRPT1
{
    internal class RPTDatabase
    {
        /// <summary>
        /// Returns a list of maximum number of rows.
        /// </summary>
        public static List<RealPropertyTax> SelectLatest()
        {
            using (SqlConnection conn = DbUtils.getConnection())
            {
                return conn.Query<RealPropertyTax>($"SELECT TOP {GlobalConstants.LISTVIEW_MAX_ROWS} * FROM Jo_RPT where DeletedRecord != 1 order by RptID ASC").ToList();
            }
        }

        /// <summary>
        /// Returns all records of OR UPLOAD which has attachments to it. 
        /// </summary>
        public static List<RealPropertyTax> SelectForORUpload()
        {
            using (SqlConnection conn = DbUtils.getConnection())
            {
                return conn.Query<RealPropertyTax>($"SELECT TOP 10 * FROM Jo_RPT rpt WHERE Status = 'FOR O.R UPLOAD' AND exists(select 1 from Jo_RPT_Pictures pic where rpt.RptID = pic.RptId and pic.DocumentType = 'Receipt') and SendReceiptReady = 1 and DeletedRecord != 1").ToList();
            }
        }

        /// <summary>
        /// Returns all records of ASSESSMENT PRINTED which has attachments to it. 
        /// </summary>
        public static List<RealPropertyTax> SelectAssessmentSendEmail()
        {
            using (SqlConnection conn = DbUtils.getConnection())
            {
                return conn.Query<RealPropertyTax>($"SELECT TOP 10 * FROM Jo_RPT rpt WHERE Status = 'ASSESSMENT PRINTED' AND exists(select 1 from Jo_RPT_Pictures pic where rpt.RptID = pic.RptId and pic.DocumentType = 'Assessment') and SendAssessmentReady = 1 and DeletedRecord != 1").ToList();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public static List<RealPropertyTax> SelectReadyForORUpload()
        {
            using (SqlConnection conn = DbUtils.getConnection())
            {
                return conn.Query<RealPropertyTax>($"SELECT TOP 200 * FROM Jo_RPT rpt WHERE Status = 'FOR O.R UPLOAD' AND exists(select 1 from Jo_RPT_Pictures pic where rpt.RptID = pic.RptId and pic.DocumentType = 'Receipt') and SendReceiptReady = 0 and DeletedRecord != 1").ToList();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public static List<RealPropertyTax> SelectReadyAssessmentSendEmail()
        {
            using (SqlConnection conn = DbUtils.getConnection())
            {
                return conn.Query<RealPropertyTax>($"SELECT TOP 200 * FROM Jo_RPT rpt WHERE Status = 'ASSESSMENT PRINTED' AND exists(select 1 from Jo_RPT_Pictures pic where rpt.RptID = pic.RptId and pic.DocumentType = 'Assessment') and SendAssessmentReady = 0 and DeletedRecord != 1").ToList();
            }
        }

        /// <summary>
        /// Returns a list of records based on taxdec.
        /// </summary>
        public static List<RealPropertyTax> SelectByTaxDec(string taxdec) //F-084-12122;
        {
            using (SqlConnection conn = DbUtils.getConnection())
            { 
                return conn.Query<RealPropertyTax>($"SELECT TOP {GlobalConstants.LISTVIEW_MAX_ROWS} * FROM Jo_RPT where TaxDec = @TaxDec and DeletedRecord != 1 order by EncodedDate", new { TaxDec = taxdec }).ToList();
            }
        }

        /// <summary>
        /// Returns a list of records based on date range and status.
        /// </summary>
        public static List<RealPropertyTax> SelectByDateFromToAndStatus(DateTime encodedDateFrom, DateTime encodedDateTo, List<string> StatusList)
        {
            using (SqlConnection conn = DbUtils.getConnection())
            {
                String query = $"SELECT TOP {GlobalConstants.LISTVIEW_MAX_ROWS} * FROM Jo_RPT WHERE CAST(EncodedDate as DATE) >= CAST(@EncodedDateFrom as DATE) " +
                    "AND CAST(EncodedDate as DATE) <= CAST(@EncodedDateTo as DATE) AND Status in @StatusList and DeletedRecord != 1 " +
                    "ORDER BY RptID ASC";
                return conn.Query<RealPropertyTax>(query, new { EncodedDateFrom = encodedDateFrom, EncodedDateTo = encodedDateTo, 
                    StatusList = StatusList }).ToList();
            }
        }

        /// <summary>
        /// Returns a list of records based on date range, status and paymentchannel.
        /// </summary>
        public static List<RealPropertyTax> SelectByDateFromToAndStatusAndPaymentChannel(DateTime encodedDateFrom, DateTime encodedDateTo, List<string> StatusList, List<string> PaymentChannelList)
        {
            using (SqlConnection conn = DbUtils.getConnection())
            {
                String query = $"SELECT TOP {GlobalConstants.LISTVIEW_MAX_ROWS} * FROM Jo_RPT WHERE CAST(EncodedDate as DATE) >= CAST(@EncodedDateFrom as DATE) " +
                    "AND CAST(EncodedDate as DATE) <= CAST(@EncodedDateTo as DATE) AND Status in @StatusList AND Bank in @PaymentChannelList AND DeletedRecord != 1 " +
                    "ORDER BY RptID ASC";
                return conn.Query<RealPropertyTax>(query, new
                {
                    EncodedDateFrom = encodedDateFrom,
                    EncodedDateTo = encodedDateTo,
                    StatusList = StatusList,
                    PaymentChannelList = PaymentChannelList
                }).ToList();
            }
        }

        /// <summary>
        /// Returns a list of records based on date range, status and encodedby.
        /// </summary>
        public static List<RealPropertyTax> SelectByDateFromToAndStatusAndEncodedBy(DateTime encodedDateFrom, DateTime encodedDateTo, List<string> StatusList, List<string> EncodedBy)
        {
            using (SqlConnection conn = DbUtils.getConnection())
            {
                String query = $"SELECT TOP {GlobalConstants.LISTVIEW_MAX_ROWS} * FROM Jo_RPT WHERE CAST(EncodedDate as DATE) >= CAST(@EncodedDateFrom as DATE) " +
                    "AND CAST(EncodedDate as DATE) <= CAST(@EncodedDateTo as DATE) AND Status in @StatusList AND EncodedBy in @EncodedBy AND DeletedRecord != 1 " +
                    "ORDER BY RptID ASC";
                return conn.Query<RealPropertyTax>(query, new
                {
                    EncodedDateFrom = encodedDateFrom,
                    EncodedDateTo = encodedDateTo,
                    StatusList = StatusList,
                    EncodedBy = EncodedBy
                }).ToList();
            }
        }

        //THIS MIGHT BE USEFUL LATER.
        /// <summary>
        /// Returns a list of records based on status and encodedby.
        /// </summary>
        public static List<RealPropertyTax> SelectByStatusAndEncodedBy(List<string> StatusList, List<string> PaymentChannelList)
        {
            using (SqlConnection conn = DbUtils.getConnection())
            {
                String query = $"SELECT TOP {GlobalConstants.LISTVIEW_MAX_ROWS} * FROM Jo_RPT WHERE Status in @StatusList and Bank in @PaymentChannelList and DeletedRecord != 1 ORDER BY RptID ASC";
                return conn.Query<RealPropertyTax>(query, new { StatusList = StatusList, PaymentChannelList = PaymentChannelList }).ToList();
            }
        }

        /// <summary>
        /// Returns a list of records based on selected status.
        /// </summary>
        public static List<RealPropertyTax> SelectByStatus(List<string> StatusList)
        {
            using (SqlConnection conn = DbUtils.getConnection())
            {
                String query = $"SELECT TOP {GlobalConstants.LISTVIEW_MAX_ROWS} * FROM Jo_RPT WHERE Status in @StatusList and DeletedRecord != 1 ORDER BY RptID ASC";
                return conn.Query<RealPropertyTax>(query, new { StatusList = StatusList }).ToList();
            }
        }

        /// <summary>
        /// Returns a list of records based on taxdec and year/quarter.
        /// </summary>
        public static RealPropertyTax SelectByTaxDecAndYear(string TaxDec, string YearQtr)
        {
            using (SqlConnection conn = DbUtils.getConnection())
            {
                return conn.QuerySingleOrDefault<RealPropertyTax>($"SELECT * FROM Jo_RPT where TaxDec = @TaxDec and YearQuarter = @YearQtr and DeletedRecord != 1", new { TaxDec = TaxDec, YearQtr = YearQtr });
            }
        }

        /// <summary>
        /// Returns a list of records of tax dec based on reference number.
        /// </summary>
        public static List<RealPropertyTax> SelectBySameGroup(string TaxDec)
        {
            using (SqlConnection conn = DbUtils.getConnection())
            {
                return conn.Query<RealPropertyTax>($"SELECT TOP {GlobalConstants.LISTVIEW_MAX_ROWS} * FROM Jo_RPT where TaxDec = @TaxDec and DeletedRecord != 1 UNION SELECT * FROM Jo_RPT where RefNum in (select RefNum FROM Jo_RPT where TaxDec = @TaxDec) and DeletedRecord != 1 " +
                    $"order by RefNum desc, taxdec asc", new { TaxDec = TaxDec }).ToList();
            }
        }

        public static List<RealPropertyTax> SelectBySameGroup2(string TaxDec)
        {
            using (SqlConnection conn = DbUtils.getConnection())
            {
                return conn.Query<RealPropertyTax>($"SELECT TOP {GlobalConstants.LISTVIEW_MAX_ROWS} * FROM Jo_RPT where TaxDec = @TaxDec and DeletedRecord != 1 UNION SELECT * FROM Jo_RPT where RefNum in (select RefNum FROM Jo_RPT where TaxDec = @TaxDec) and DeletedRecord != 1 " +
                    $"order by YearQuarter asc, taxdec asc", new { TaxDec = TaxDec }).ToList();
            }
        }

        /// <summary>
        /// Returns a list of records based on taxdec and status: FOR OR RELEASE.
        /// </summary>
        public static List<RealPropertyTax> SelectBySameGroupReleasing(string TaxDec, List<string> StatusList)
        {
            using (SqlConnection conn = DbUtils.getConnection())
            {
                return conn.Query<RealPropertyTax>($"SELECT TOP {GlobalConstants.LISTVIEW_MAX_ROWS} * FROM Jo_RPT where TaxDec = @TaxDec and DeletedRecord != 1 and Status = @Status UNION SELECT * FROM Jo_RPT where RefNum in (select RefNum FROM Jo_RPT where TaxDec = @TaxDec) and DeletedRecord != 1 and Status = @Status " +
                    $"order by RefNum desc, taxdec asc", new { TaxDec = TaxDec, Status = StatusList }).ToList();
            }
        }

        /// <summary>
        /// Returns a list of records on reference number.
        /// </summary>
        public static List<RealPropertyTax> SelectByRefNum(string RefNum)
        {
            using (SqlConnection conn = DbUtils.getConnection())
            {
                return conn.Query<RealPropertyTax>($"SELECT TOP {GlobalConstants.LISTVIEW_MAX_ROWS} * FROM Jo_RPT where RefNum= @RefNum and DeletedRecord != 1 order by RptID ASC", new { RefNum = RefNum }).ToList();
            }
        }

        /// <summary>
        /// Returns a list of records based on location code.
        /// </summary>
        public static int CountLocation()
        {
            using (SqlConnection conn = DbUtils.getConnection())
            {
                return conn.ExecuteScalar<int>($"SELECT count(*) FROM Jo_RPT where LocCode is not null and DeletedRecord != 1");
            }
        }

        /// <summary>
        /// Gets the entire row depending on the RPTId.
        /// </summary>
        public static RealPropertyTax Get(long RPTId)
        {
            using (SqlConnection conn = DbUtils.getConnection())
            {
                return conn.Get<RealPropertyTax>(RPTId);
            }
        }

        /// <summary>
        /// Inserts data to the database.
        /// </summary>
        public static long Insert(RealPropertyTax modelInstance)
        {
            using (SqlConnection conn = DbUtils.getConnection())
            {
                modelInstance.CreatedBy = GlobalVariables.RPTUSER.DisplayName;
                modelInstance.CreatedDate = DateTime.Now;
                modelInstance.LastUpdateBy = GlobalVariables.RPTUSER.DisplayName;
                modelInstance.LastUpdateDate = DateTime.Now;
                BeforeInsertOrUpdate(modelInstance);
                long result = conn.Insert<RealPropertyTax>(modelInstance);
                AfterInsertOrUpdateOrDelete(conn, modelInstance, "INSERT");
                return result;
            }
        }

        /// <summary>
        /// Setting please select a bank to a null when inserting or updating record.
        /// </summary>
        private static void BeforeInsertOrUpdate(RealPropertyTax modelInstance)
        {
            if (modelInstance.Bank != null)
            {
                if (modelInstance.Bank.Trim().ToLower().StartsWith("please"))
                {
                    modelInstance.Bank = "";
                }
                modelInstance.Bank = modelInstance.Bank.ToUpper();

                if (modelInstance.Bank != string.Empty)
                {
                   RPTBank newBank = RPTBankDatabase.SelectByBankName(modelInstance.Bank);

                    if (newBank == null)
                    {
                        newBank = new RPTBank();

                        newBank.BankName = modelInstance.Bank;
                        RPTBankDatabase.Insert(newBank);
                    }
                }
            }
        }

        /// <summary>
        /// Updates entire row in the database. 
        /// </summary>
        public static bool Update(RealPropertyTax modelInstance)
        {
            using (SqlConnection conn = DbUtils.getConnection())
            {
                modelInstance.LastUpdateBy = GlobalVariables.RPTUSER.DisplayName;
                modelInstance.LastUpdateDate = DateTime.Now;
                BeforeInsertOrUpdate(modelInstance);
                bool result = conn.Update<RealPropertyTax>(modelInstance);
                AfterInsertOrUpdateOrDelete(conn, modelInstance, "UPDATE");
                return result;
            }
        }

        /// <summary>
        /// Tagging of deleted record in the database.
        /// </summary>
        public static bool Delete(RealPropertyTax modelInstance)
        {
            using (SqlConnection conn = DbUtils.getConnection())
            {
                modelInstance.DeletedRecord = 1;
                modelInstance.LastUpdateBy = GlobalVariables.RPTUSER.DisplayName;
                modelInstance.LastUpdateDate = DateTime.Now;
                bool result = conn.Update<RealPropertyTax>(modelInstance);
                AfterInsertOrUpdateOrDelete(conn, modelInstance, "DELETE");
                return result;
            }
        }

        private static void AfterInsertOrUpdateOrDelete(SqlConnection conn, RealPropertyTax rpt, String action)
        {
            RealPropertyTaxAudit audit = new RealPropertyTaxAudit();
            copyRptToAudit(rpt, audit);
            audit.Action = action;
            conn.Insert<RealPropertyTaxAudit>(audit);
        }

        public static List<RealPropertyTaxAudit> SelectAudits(long RptID)
        {
            using (SqlConnection conn = DbUtils.getConnection())
            {
                return conn.Query<RealPropertyTaxAudit>($"SELECT * FROM Jo_RPT_Audit where RptID = @RptID order by AuditID desc", new { RptID = RptID }).ToList();
            }
        }

        public static void Revert(RealPropertyTaxAudit audit)
        {
            using (SqlConnection conn = DbUtils.getConnection())
            {
                RealPropertyTax rpt = Get(audit.RptID);
                copyAuditToRpt(audit, rpt);

                rpt.LastUpdateBy = GlobalVariables.RPTUSER.DisplayName;
                rpt.LastUpdateDate = DateTime.Now;
                conn.Update<RealPropertyTax>(rpt);
                AfterInsertOrUpdateOrDelete(conn, rpt, "REVERT");
            }
        }

        private static void copyRptToAudit(RealPropertyTax rpt, RealPropertyTaxAudit audit)
        {
            var rptProperties = typeof(RealPropertyTax).GetProperties();
            var auditProperties = typeof(RealPropertyTaxAudit).GetProperties();
            foreach (var rptProperty in rptProperties)
            {
                foreach (var auditProperty in auditProperties)
                {
                    if (rptProperty.Name == auditProperty.Name)
                    {
                        auditProperty.SetValue(audit, rptProperty.GetValue(rpt));
                        break;
                    }
                }
            }
        }

        private static void copyAuditToRpt(RealPropertyTaxAudit audit, RealPropertyTax rpt)
        {
            var rptProperties = typeof(RealPropertyTax).GetProperties();
            var auditProperties = typeof(RealPropertyTaxAudit).GetProperties();
            foreach (var rptProperty in rptProperties)
            {
                foreach (var auditProperty in auditProperties)
                {
                    if (rptProperty.Name == auditProperty.Name)
                    {
                        rptProperty.SetValue(rpt, auditProperty.GetValue(audit));
                        break;
                    }
                }
            }
        }
    }
}
