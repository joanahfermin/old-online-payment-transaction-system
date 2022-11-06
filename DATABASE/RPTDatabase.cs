using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper.Contrib.Extensions;
using Dapper;
using Microsoft.Data.SqlClient;
using SampleRPT1.MODEL;
using SampleRPT1.Service;

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
        public static List<RealPropertyTax> SelectByDateFromToAndStatus(DateTime encodedDateFrom, DateTime encodedDateTo, string Status)
        {
            using (SqlConnection conn = DbUtils.getConnection())
            {
                String query = $"SELECT TOP {GlobalConstants.LISTVIEW_MAX_ROWS} * FROM Jo_RPT WHERE CAST(EncodedDate as DATE) >= CAST(@EncodedDateFrom as DATE) " +
                    "AND CAST(EncodedDate as DATE) <= CAST(@EncodedDateTo as DATE) AND Status = @Status and DeletedRecord != 1 " +
                    "ORDER BY RptID ASC";
                return conn.Query<RealPropertyTax>(query, new { EncodedDateFrom = encodedDateFrom, EncodedDateTo = encodedDateTo, 
                    Status = Status }).ToList();
            }
        }

        /// <summary>
        /// Returns a list of records based on date range, status and paymentchannel.
        /// </summary>
        public static List<RealPropertyTax> SelectByDateFromToAndStatusAndPaymentChannel(DateTime encodedDateFrom, DateTime encodedDateTo, string Status, List<string> BankList)
        {
            using (SqlConnection conn = DbUtils.getConnection())
            {
                String query = $"SELECT TOP {GlobalConstants.LISTVIEW_MAX_ROWS} * FROM Jo_RPT WHERE CAST(EncodedDate as DATE) >= CAST(@EncodedDateFrom as DATE) " +
                    "AND CAST(EncodedDate as DATE) <= CAST(@EncodedDateTo as DATE) AND Status = @Status AND Bank in @BankList AND DeletedRecord != 1 " +
                    "ORDER BY BilledDate asc";
                return conn.Query<RealPropertyTax>(query, new
                {
                    EncodedDateFrom = encodedDateFrom,
                    EncodedDateTo = encodedDateTo,
                    Status = Status,
                    BankList = BankList
                }).ToList();
            }
        }

        /// <summary>
        /// Returns a list of records based on date range, status and encodedby.
        /// </summary>
        public static List<RealPropertyTax> SelectByDateFromToAndStatusAndEncodedBy(DateTime encodedDateFrom, DateTime encodedDateTo, string Status, string EncodedBy)
        {
            using (SqlConnection conn = DbUtils.getConnection())
            {
                String query = $"SELECT TOP {GlobalConstants.LISTVIEW_MAX_ROWS} * FROM Jo_RPT WHERE CAST(EncodedDate as DATE) >= CAST(@EncodedDateFrom as DATE) " +
                    "AND CAST(EncodedDate as DATE) <= CAST(@EncodedDateTo as DATE) AND Status = @Status AND EncodedBy = @EncodedBy AND DeletedRecord != 1 " +
                    "ORDER BY RptID ASC";
                return conn.Query<RealPropertyTax>(query, new
                {
                    EncodedDateFrom = encodedDateFrom,
                    EncodedDateTo = encodedDateTo,
                    Status = Status,
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
        public static List<RealPropertyTax> SelectByStatus(string Status)
        {
            using (SqlConnection conn = DbUtils.getConnection())
            {
                String query = $"SELECT TOP {GlobalConstants.LISTVIEW_MAX_ROWS} * FROM Jo_RPT WHERE Status = @Status and DeletedRecord != 1 ORDER BY RptID ASC";
                return conn.Query<RealPropertyTax>(query, new { Status = Status }).ToList();
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

        public static List<RealPropertyTax> SelectByLocationCode(string LocCode)
        {
            using (SqlConnection conn = DbUtils.getConnection())
            {
                return conn.Query<RealPropertyTax>($"SELECT TOP {GlobalConstants.LISTVIEW_MAX_ROWS} * FROM Jo_RPT where LocCode= @LocCode and DeletedRecord != 1 order by RptID ASC", new { LocCode = LocCode }).ToList();
            }
        }

        /// <summary>
        /// Returns a list of records based on location code.
        /// </summary>
        public static int CountLocationReg()
        {
            using (SqlConnection conn = DbUtils.getConnection())
            {
                return conn.ExecuteScalar<int>($"SELECT count(*) FROM Jo_RPT where LocCode is not null and Bank not in @E_CHANNEL and DeletedRecord != 1", new { E_CHANNEL = RPTGcashPaymaya.E_PAYMENT_CHANNEL});
            }
        }

        public static int CountLocationElec()
        {
            using (SqlConnection conn = DbUtils.getConnection())
            {
                return conn.ExecuteScalar<int>($"SELECT count(*) FROM Jo_RPT where LocCode is not null and Bank in @E_CHANNEL and DeletedRecord != 1", new { E_CHANNEL = RPTGcashPaymaya.E_PAYMENT_CHANNEL });
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
                RPTUser loginUser = SecurityService.getLoginUser();
                //Kada galaw sa record, populate yung last 4 columns sa Jo_RPT table.
                modelInstance.CreatedBy = loginUser.DisplayName;
                modelInstance.CreatedDate = DateTime.Now;
                modelInstance.LastUpdateBy = loginUser.DisplayName;
                modelInstance.LastUpdateDate = DateTime.Now;

                //lilinisin yung bank.
                BeforeInsertOrUpdate(modelInstance);

                //Insert record in Jo_RPT.
                long result = conn.Insert<RealPropertyTax>(modelInstance);

                //Insert record in Jo_RPT_Audit.
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
                modelInstance.LastUpdateBy = SecurityService.getLoginUser().DisplayName;
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
                modelInstance.LastUpdateBy = SecurityService.getLoginUser().DisplayName;
                modelInstance.LastUpdateDate = DateTime.Now;
                bool result = conn.Update<RealPropertyTax>(modelInstance);
                AfterInsertOrUpdateOrDelete(conn, modelInstance, "DELETE");
                return result;
            }
        }

        private static void AfterInsertOrUpdateOrDelete(SqlConnection conn, RealPropertyTax rpt, String action)
        {
            //Create audit object.
            RealPropertyTaxAudit audit = new RealPropertyTaxAudit();

            //copy the whole record to audit object.
            copyRptToAudit(rpt, audit);

            //populates action.
            audit.Action = action;

            //Insert audit sa Jo_RPT_Audit.
            conn.Insert<RealPropertyTaxAudit>(audit);
        }

        /// <summary>
        /// copy the entire row from Jo_RPT to Jo_RPT_Audit.
        /// </summary>
        private static void copyRptToAudit(RealPropertyTax rpt, RealPropertyTaxAudit audit)
        {
            //kukunin pa lang yung lahat ng property from RealPropertyTax at RealPropertyTaxAudit.
            var rptProperties = typeof(RealPropertyTax).GetProperties();
            var auditProperties = typeof(RealPropertyTaxAudit).GetProperties();

            //rptProperties = [RptID, TaxDec, TaxPayerName...]
            //auditProperties = [AuditID, Action, RptID, TaxDec, TaxPayerName...]

            foreach (var rptProperty in rptProperties)
            {
                foreach (var auditProperty in auditProperties)
                {
                    if (rptProperty.Name == auditProperty.Name)
                    {
                        //kung ano makukuha nyang value sa param rpt, ita-transfer nya sa param audit.
                        auditProperty.SetValue(audit, rptProperty.GetValue(rpt));

                        break;
                    }
                }
            }
        }

        /// <summary>
        /// return a list of record from rpt_audit.
        /// </summary>
        public static List<RealPropertyTaxAudit> SelectAudits(long RptID)
        {
            using (SqlConnection conn = DbUtils.getConnection())
            {
                return conn.Query<RealPropertyTaxAudit>($"SELECT * FROM Jo_RPT_Audit where RptID = @RptID order by AuditID desc", new { RptID = RptID }).ToList();
            }
        }

        /// <summary>
        /// Restore from previous status.
        /// </summary>
        public static void Revert(RealPropertyTaxAudit audit)
        {
            using (SqlConnection conn = DbUtils.getConnection())
            {
                RealPropertyTax rpt = Get(audit.RptID);
                copyAuditToRpt(audit, rpt);

                rpt.LastUpdateBy = SecurityService.getLoginUser().DisplayName;
                rpt.LastUpdateDate = DateTime.Now;
                conn.Update<RealPropertyTax>(rpt);
                AfterInsertOrUpdateOrDelete(conn, rpt, "REVERT");
            }
        }

        /// <summary>
        /// copy the entire row from Jo_RPT_Audit to Jo_RPT.
        /// </summary>
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

        /// <summary>
        /// Returns a list of records based on date range, status and uploaded date for LOVE'S FILTER: for o.r pickup status.
        /// </summary>
        public static List<RealPropertyTax> SelectByDateFromToAndStatusAndUploadedDate(DateTime encodedDateFrom, DateTime encodedDateTo, string Status)
        {
            using (SqlConnection conn = DbUtils.getConnection())
            {
                String query = $"SELECT TOP {GlobalConstants.LISTVIEW_MAX_ROWS} * FROM Jo_RPT WHERE CAST(UploadedDate as DATE) >= CAST(@EncodedDateFrom as DATE) " +
                    "AND CAST(UploadedDate as DATE) <= CAST(@EncodedDateTo as DATE) AND Status = @Status AND DeletedRecord != 1 " +
                    "ORDER BY ValidatedDate ASC";
                return conn.Query<RealPropertyTax>(query, new
                {
                    EncodedDateFrom = encodedDateFrom,
                    EncodedDateTo = encodedDateTo,
                    Status = Status,
                    //UploadedDate = UploadedDate
                }).ToList();
            }
        }

        /// <summary>
        /// Returns a list of records based on date range, status and validated date. status: for o.r upload status.
        /// ISAMA ANG UPLOADEDBY FROM ATTACHPICTURE TABLE
        /// 
        /// </summary>
        public static List<RealPropertyTax> SelectByDateFromToAndStatusAndValidatedDate(DateTime encodedDateFrom, DateTime encodedDateTo, string Status)
        {
            using (SqlConnection conn = DbUtils.getConnection())
            {
                String query = $"SELECT TOP {GlobalConstants.LISTVIEW_MAX_ROWS} * FROM Jo_RPT WHERE CAST(UploadedDate as DATE) >= CAST(@EncodedDateFrom as DATE) " +
                    "AND CAST(UploadedDate as DATE) <= CAST(@EncodedDateTo as DATE) AND Status = @Status AND DeletedRecord != 1 " +
                    "ORDER BY ValidatedDate desc";
                return conn.Query<RealPropertyTax>(query, new
                {
                    EncodedDateFrom = encodedDateFrom,
                    EncodedDateTo = encodedDateTo,
                    Status = Status,
                }).ToList();
            }
        }


        public static List<RealPropertyTax> SelectByDateFromToAndStatusAndVerifiedDate(DateTime encodedDateFrom, DateTime encodedDateTo, string Status)
        {
            using (SqlConnection conn = DbUtils.getConnection())
            {
                String query = $"SELECT TOP {GlobalConstants.LISTVIEW_MAX_ROWS} * FROM Jo_RPT WHERE CAST(UploadedDate as DATE) >= CAST(@EncodedDateFrom as DATE) " +
                    "AND CAST(UploadedDate as DATE) <= CAST(@EncodedDateTo as DATE) AND Status = @Status AND DeletedRecord != 1 " +
                    "ORDER BY VerifiedDate desc";
                return conn.Query<RealPropertyTax>(query, new
                {
                    EncodedDateFrom = encodedDateFrom,
                    EncodedDateTo = encodedDateTo,
                    Status = Status,
                }).ToList();
            }
        }
        
        //changes status to FOR OR PICK UP when one record shares same reference number to other records and not e-payments.
        public static void ChangeStatusForORPickUp(RealPropertyTax rpt)
        {
            if (!RPTGcashPaymaya.E_PAYMENT_CHANNEL.Contains(rpt.Bank))
            {
                string LocCode = LocationCodeUtil.GetNextLocationCode_RegPayment();
                string UploadedBy = rpt.UploadedBy;

                if (rpt.RefNum != null && rpt.RefNum.Length > 0)
                {
                    List<RealPropertyTax> rptList = RPTDatabase.SelectByRefNum(rpt.RefNum);

                    foreach (var item in rptList)
                    {
                        item.LocCode = LocCode;
                        item.UploadedBy = UploadedBy;
                        item.Status = RPTStatus.OR_PICKUP;
                        item.UploadedDate = DateTime.Now;

                        RPTDatabase.Update(item);
                    }
                }
                else
                {
                    rpt.LocCode = LocCode;

                    rpt.Status = RPTStatus.OR_PICKUP;
                    rpt.UploadedDate = DateTime.Now;

                    RPTDatabase.Update(rpt);
                }
            }

            else
            {
                rpt.LocCode = LocationCodeUtil.GetNextLocationCode_EPayment();

                rpt.Status = RPTStatus.OR_PICKUP;
                rpt.UploadedDate = DateTime.Now;

                RPTDatabase.Update(rpt);
            }
        }
    }
}
