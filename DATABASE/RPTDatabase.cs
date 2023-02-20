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

        public static List<RealPropertyTax> SelectSQL(string sql)
        {
            using (SqlConnection conn = DbUtils.getConnection())
            {
                return conn.Query<RealPropertyTax>(sql).ToList();
            }
        }


        /// <summary>
        /// Returns all records of OR UPLOAD which has attachments to it. 
        /// </summary>
        public static List<RealPropertyTax> SelectForORUpload()
        {
            using (SqlConnection conn = DbUtils.getConnection())
            {
                return conn.Query<RealPropertyTax>($"SELECT TOP 10 * FROM Jo_RPT rpt WHERE Status = 'FOR O.R UPLOAD' AND exists(select 1 from Jo_RPT_Pictures pic where rpt.RptID = pic.RptId and pic.DocumentType = 'Receipt') and SendReceiptReady = 1 and DeletedRecord != 1 order by ORConfirmDate asc, ORAttachedDate asc").ToList();
            }
        }

        public static int EmailSendingCount()
        {
            using (SqlConnection conn = DbUtils.getConnection())
            {
                return conn.ExecuteScalar<int>($"SELECT count(*) FROM Jo_RPT rpt WHERE Status = 'FOR O.R UPLOAD' AND exists(select 1 from Jo_RPT_Pictures pic where rpt.RptID = pic.RptId and pic.DocumentType = 'Receipt') and SendReceiptReady = 1 and DeletedRecord != 1");
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
                return conn.Query<RealPropertyTax>($"SELECT * FROM Jo_RPT rpt WHERE Status = 'FOR O.R UPLOAD' AND exists(select 1 from Jo_RPT_Pictures pic where rpt.RptID = pic.RptId and pic.DocumentType = 'Receipt') and SendReceiptReady = 0 and DeletedRecord != 1 order by UploadedBy asc, ORAttachedDate asc").ToList();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public static List<RealPropertyTax> SelectReadyAssessmentSendEmail()
        {
            using (SqlConnection conn = DbUtils.getConnection())
            {
                return conn.Query<RealPropertyTax>($"SELECT * FROM Jo_RPT rpt WHERE Status = 'ASSESSMENT PRINTED' AND exists(select 1 from Jo_RPT_Pictures pic where rpt.RptID = pic.RptId and pic.DocumentType = 'Assessment') and SendAssessmentReady = 0 and DeletedRecord != 1").ToList();
            }
        }

        /// <summary>
        /// Returns a list records based on uploaded date - for OR RELEASING FILTER.
        /// </summary>
        /// <param name="UploadedDateFrom"></param>
        /// <param name="UploadedDateTo"></param>
        /// <param name="Status"></param>
        /// <returns></returns>
        public static List<RealPropertyTax> SelectByDateFromToAndStatusUploadedBy(DateTime UploadedDateFrom, DateTime UploadedDateTo, string Status)
        {
            using (SqlConnection conn = DbUtils.getConnection())
            {
                String query = $"SELECT TOP {GlobalConstants.LISTVIEW_MAX_ROWS} * FROM Jo_RPT WHERE CAST(UploadedDate as DATE) >= CAST(@UploadedDateFrom as DATE) " +
                    "AND CAST(UploadedDate as DATE) <= CAST(@UploadedDateTo as DATE) AND Status = @Status and DeletedRecord != 1 " +
                    "ORDER BY RptID ASC";
                return conn.Query<RealPropertyTax>(query, new
                {
                    UploadedDateFrom = UploadedDateFrom,
                    UploadedDateTo = UploadedDateTo,
                    Status = Status
                }).ToList();
            }
        }

        /// <summary>
        /// Returns a list of records based on date range and status.
        /// </summary>
        public static List<RealPropertyTax> SelectByDateFromToAndStatus(DateTime encodedDateFrom, DateTime encodedDateTo, string Status)
        {
            using (SqlConnection conn = DbUtils.getConnection())
            {
                String query = $"SELECT /*TOP {GlobalConstants.LISTVIEW_MAX_ROWS}*/ * FROM Jo_RPT WHERE CAST(EncodedDate as DATE) >= CAST(@EncodedDateFrom as DATE) " +
                    "AND CAST(EncodedDate as DATE) <= CAST(@EncodedDateTo as DATE) AND Status = @Status and DeletedRecord != 1 " +
                    //"ORDER BY RptID ASC";
                    "ORDER BY EncodedDate ASC";
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
                String query = $"SELECT /*TOP {GlobalConstants.LISTVIEW_MAX_ROWS}*/ * FROM Jo_RPT WHERE CAST(EncodedDate as DATE) >= CAST(@EncodedDateFrom as DATE) " +
                    "AND CAST(EncodedDate as DATE) <= CAST(@EncodedDateTo as DATE) AND Status = @Status AND Bank in @BankList AND DeletedRecord != 1 " +
                //"ORDER BY EncodedDate asc";
                "ORDER BY PaymentDate asc";
                return conn.Query<RealPropertyTax>(query, new
                {
                    EncodedDateFrom = encodedDateFrom,
                    EncodedDateTo = encodedDateTo,
                    Status = Status,
                    BankList = BankList
                }).ToList();
            }
        }

        public static List<RealPropertyTax> SelectByDateFromToAndStatusAndPaymentChannelForValidation(DateTime encodedDateFrom, DateTime encodedDateTo, string Status, List<string> BankList)
        {
            using (SqlConnection conn = DbUtils.getConnection())
            {
                String query = $"SELECT * FROM Jo_RPT WHERE CAST(VerifiedDate as DATE) >= CAST(@EncodedDateFrom as DATE) " +
                    "AND CAST(VerifiedDate as DATE) <= CAST(@EncodedDateTo as DATE) AND Status = @Status AND Bank in @BankList AND DeletedRecord != 1 " +
                    "ORDER BY VerifiedDate asc";
                return conn.Query<RealPropertyTax>(query, new
                {
                    EncodedDateFrom = encodedDateFrom,
                    EncodedDateTo = encodedDateTo,
                    Status = Status,
                    BankList = BankList
                }).ToList();
            }
        }

        public static List<RealPropertyTax> SelectByDateFromToAndStatusAndPaymentChannelAndValidatedBy(DateTime encodedDateFrom, DateTime encodedDateTo, string Status, List<string> BankList, string ValidatedBy)
        {
            using (SqlConnection conn = DbUtils.getConnection())
            {
                String query = $"SELECT * FROM Jo_RPT WHERE CAST(ValidatedDate as DATE) >= CAST(@EncodedDateFrom as DATE) " +
                    "AND CAST(ValidatedDate as DATE) <= CAST(@EncodedDateTo as DATE) AND Status = @Status AND Bank in @BankList AND ValidatedBy = @ValidatedBy and DeletedRecord != 1 " +
                    "ORDER BY ValidatedDate ASC";
                return conn.Query<RealPropertyTax>(query, new
                {
                    EncodedDateFrom = encodedDateFrom,
                    EncodedDateTo = encodedDateTo,
                    Status = Status,
                    BankList = BankList,
                    ValidatedBy = ValidatedBy

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
                String query = $"SELECT /*TOP {GlobalConstants.LISTVIEW_MAX_ROWS}*/ * FROM Jo_RPT WHERE CAST(EncodedDate as DATE) >= CAST(@EncodedDateFrom as DATE) " +
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
                String query = $"SELECT TOP {GlobalConstants.LISTVIEW_MAX_ROWS} * FROM Jo_RPT WHERE Status = @Status and DeletedRecord != 1 ORDER BY EncodedDate ASC";
                return conn.Query<RealPropertyTax>(query, new { Status = Status }).ToList();
            }
        }

        /// <summary>
        /// Returns a list of records based on taxdec and year/quarter.
        /// </summary>
        public static RealPropertyTax SelectByTaxDecAndYear(string TaxDec, string Year, string Qtr)
        {
            using (SqlConnection conn = DbUtils.getConnection())
            {
                return conn.QuerySingleOrDefault<RealPropertyTax>($"SELECT * FROM Jo_RPT where TaxDec = @TaxDec and YearQuarter = @Year and Quarter = @Qtr and DeletedRecord != 1 and DuplicateRecord = 0", new { TaxDec = TaxDec, Year = Year, Qtr = Qtr });
            }
        }

        /// <summary>
        /// Returns a list of records of tax dec based on reference number.
        /// </summary>
        public static List<RealPropertyTax> SelectBySameGroup(string TaxDec)
        {
            using (SqlConnection conn = DbUtils.getConnection())
            {
                return conn.Query<RealPropertyTax>($"select * FROM Jo_RPT where RequestingParty = @RequestingParty and DeletedRecord != 1 union SELECT * FROM Jo_RPT where TaxDec LIKE @TaxDec and DeletedRecord != 1 UNION SELECT * FROM Jo_RPT where RefNum in (select RefNum FROM Jo_RPT where TaxDec LIKE @TaxDec) and DeletedRecord != 1 " +
                    $"order by RefNum desc, EncodedDate asc", new { TaxDec = "%" + TaxDec + "%" , RequestingParty = TaxDec }).ToList();
            }
        }

        public static List<RealPropertyTax> SelectByRefNumAndReqParty(string RefNum, string ReqParty)
        {
            using (SqlConnection conn = DbUtils.getConnection())
            {
                return conn.Query<RealPropertyTax>($"SELECT * FROM Jo_RPT where RefNum = @RefNum and DeletedRecord != 1 and RequestingParty = @ReqParty " +
                    $"order by RefNum desc, EncodedDate asc", new { RefNum = RefNum, ReqParty = ReqParty }).ToList();
            }
        }

        public static List<RealPropertyTax> SelectByEncodedDate(string TaxDec)
        {
            using (SqlConnection conn = DbUtils.getConnection())
            {
                return conn.Query<RealPropertyTax>($"select * FROM Jo_RPT where RequestingParty = @RequestingParty and DeletedRecord != 1 union SELECT * FROM Jo_RPT where TaxDec LIKE @TaxDec and DeletedRecord != 1 UNION SELECT * FROM Jo_RPT where RefNum in (select RefNum FROM Jo_RPT where TaxDec LIKE @TaxDec) and DeletedRecord != 1 " +
                    $"order by RefNum desc, EncodedDate asc", new { TaxDec = "%" + TaxDec + "%" , RequestingParty = TaxDec }).ToList();
            }
        }

        public static List<RealPropertyTax> SelectByVerifiedDate(string TaxDec)
        {
            using (SqlConnection conn = DbUtils.getConnection())
            {
                return conn.Query<RealPropertyTax>($"select * FROM Jo_RPT where RequestingParty = @RequestingParty and DeletedRecord != 1 union SELECT * FROM Jo_RPT where TaxDec LIKE @TaxDec and status = @FORPAYMENTVALIDATION and DeletedRecord != 1 UNION SELECT * FROM Jo_RPT where RefNum in (select RefNum FROM Jo_RPT where TaxDec LIKE @TaxDec) and DeletedRecord != 1 AND status = @FORPAYMENTVALIDATION" +
                    $" order by RefNum desc, VerifiedDate asc", new { TaxDec = "%" + TaxDec + "%", FORPAYMENTVALIDATION = RPTStatus.PAYMENT_VALIDATION, RequestingParty = TaxDec }).ToList();
            }
        }

        //public static List<RealPropertyTax> SelectByTaxDecAndEmail(string TaxDec)
        //{
        //    using (SqlConnection conn = DbUtils.getConnection())
        //    {
        //        return conn.Query<RealPropertyTax>($"SELECT /*TOP {GlobalConstants.LISTVIEW_MAX_ROWS}*/ * FROM Jo_RPT where TaxDec = @TaxDec and DeletedRecord != 1 UNION SELECT * FROM Jo_RPT where RequestingParty in (select RequestingParty FROM Jo_RPT where TaxDec = @TaxDec) and DeletedRecord != 1 " +
        //            $"order by RequestingParty desc, UploadedDate asc", new { TaxDec = TaxDec }).ToList();
        //    }
        //}

        /// <summary>
        /// Returns a list of records based on taxdec and status: FOR OR RELEASE.
        /// </summary>
        //public static List<RealPropertyTax> SelectBySameGroupReleasing(string TaxDec, List<string> StatusList)
        //{
        //    using (SqlConnection conn = DbUtils.getConnection())
        //    {
        //        return conn.Query<RealPropertyTax>($"SELECT TOP {GlobalConstants.LISTVIEW_MAX_ROWS} * FROM Jo_RPT where TaxDec = @TaxDec and DeletedRecord != 1 and Status = @Status UNION SELECT * FROM Jo_RPT where RefNum in (select RefNum FROM Jo_RPT where TaxDec = @TaxDec) and DeletedRecord != 1 and Status = @Status " +
        //            $"order by RefNum desc, taxdec asc", new { TaxDec = TaxDec, Status = StatusList }).ToList();
        //    }
        //}

        public static List<RealPropertyTax> SelectBySameEmailAddressReleasing(string TaxDec, List<string> StatusList)
        {
            using (SqlConnection conn = DbUtils.getConnection())
            {
                return conn.Query<RealPropertyTax>($"SELECT TOP {GlobalConstants.LISTVIEW_MAX_ROWS} * FROM Jo_RPT where TaxDec like @TaxDec and DeletedRecord != 1 and Status in @Status UNION SELECT * FROM Jo_RPT where RequestingParty in (select RequestingParty FROM Jo_RPT where TaxDec like @TaxDec) and DeletedRecord != 1 and Status in @Status " +
                    $"order by ValidatedDate desc", new { TaxDec = "%" + TaxDec + "%", Status = StatusList }).ToList();
           
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

        public static List<RealPropertyTax> SelectByRefNumAndORUpload(string RefNum)
        {
            using (SqlConnection conn = DbUtils.getConnection())
            {
                return conn.Query<RealPropertyTax>($"SELECT TOP {GlobalConstants.LISTVIEW_MAX_ROWS} * FROM Jo_RPT where RefNum= @RefNum and Status= @Status and DeletedRecord != 1 order by RptID ASC", new { RefNum = RefNum, Status = RPTStatus.OR_UPLOAD }).ToList();
            }
        }

        public static List<RealPropertyTax> SelectByRefNumAndEmail(string RefNum, string RequestingParty)
        {
            using (SqlConnection conn = DbUtils.getConnection())
            {
                return conn.Query<RealPropertyTax>($"SELECT TOP {GlobalConstants.LISTVIEW_MAX_ROWS} * FROM Jo_RPT where RefNum= @RefNum and Status= @Status and RequestingParty= @RequestingParty and DeletedRecord != 1 order by RptID ASC", new { RefNum = RefNum, RequestingParty = RequestingParty, Status = RPTStatus.OR_UPLOAD }).ToList();
            }
        }

        public static List<RealPropertyTax> SelectByLocationCode(string LocCode)
        {
            using (SqlConnection conn = DbUtils.getConnection())
            {
                return conn.Query<RealPropertyTax>($"SELECT /*TOP {GlobalConstants.LISTVIEW_MAX_ROWS}*/ * FROM Jo_RPT where LocCode= @LocCode and Status= @Status and DeletedRecord != 1 order by /*ValidatedDate desc*/ ORConfirmDate desc, ORAttachedDate asc", new { LocCode = LocCode, Status = RPTStatus.OR_PICKUP }).ToList();
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
                        newBank.isEBank = false;
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
        public static List<RealPropertyTax> SelectByDateFromToAndStatusAndUploadedDate(DateTime validatedDateFrom, DateTime validatedDateTo, string Status)
        {
            using (SqlConnection conn = DbUtils.getConnection())
            {
                String query = $"SELECT * FROM Jo_RPT WHERE CAST(ValidatedDate as DATE) >= CAST(@validatedDateFrom as DATE) " +
                    "AND CAST(ValidatedDate as DATE) <= CAST(@validatedDateTo as DATE) AND Status = @Status AND DeletedRecord != 1 " +
                    "ORDER BY ValidatedDate ASC";
                return conn.Query<RealPropertyTax>(query, new
                {
                    ValidatedDateFrom = validatedDateFrom,
                    ValidatedDateTo = validatedDateTo,
                    Status = Status,
                    //UploadedDate = UploadedDate
                }).ToList();
            }
        }

        /// <summary>
        /// Returns a list of records based on date range, status and validated date. status: for o.r upload status.
        /// 
        /// </summary>
        public static List<RealPropertyTax> SelectByDateFromToAndStatusAndValidatedDate(DateTime encodedDateFrom, DateTime encodedDateTo, string Status)
        {
            using (SqlConnection conn = DbUtils.getConnection())
            {
                String query = $"SELECT /*TOP {GlobalConstants.LISTVIEW_MAX_ROWS} */* FROM Jo_RPT WHERE CAST(ValidatedDate as DATE) >= CAST(@EncodedDateFrom as DATE) " +
                    "AND CAST(ValidatedDate as DATE) <= CAST(@EncodedDateTo as DATE) AND Status = @Status AND DeletedRecord != 1 " +
                    "ORDER BY ValidatedDate asc";
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
                String query = $"SELECT /*TOP {GlobalConstants.LISTVIEW_MAX_ROWS}*/ * FROM Jo_RPT WHERE CAST(VerifiedDate as DATE) >= CAST(@EncodedDateFrom as DATE) " +
                    "AND CAST(VerifiedDate as DATE) <= CAST(@EncodedDateTo as DATE) AND Status = @Status AND DeletedRecord != 1 " +
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
            string UploadedBy = rpt.UploadedBy;

            if (UploadedBy == null)
            {
                UploadedBy = SecurityService.getLoginUser().DisplayName;
            }
            rpt.Status = RPTStatus.OR_PICKUP;
            rpt.UploadedDate = DateTime.Now;
            rpt.UploadedBy = UploadedBy;

            RPTDatabase.Update(rpt);
        }

        public static RealPropertyTax SearchByTagReceipt(TagReceipt tagReceipt)
        {
            using (SqlConnection conn = DbUtils.getConnection())
            {
                return conn.QuerySingleOrDefault<RealPropertyTax>($"SELECT * FROM Jo_RPT where TaxDec = @TaxDec and YearQuarter = @YearQtr and Quarter = @Quarter " +
                    $"and TotalAmountTransferred = @TotalAmountTransferred and DeletedRecord != 1 and Status = @Status", 
                    new { TaxDec = tagReceipt.RefNo, YearQtr = tagReceipt.TaxYear, Quarter = tagReceipt.Quarter, 
                        TotalAmountTransferred = tagReceipt.ORAmount, Status = RPTStatus.PAYMENT_VALIDATION});
            }
        }

        public static string GetAdvancePickExistingSequence(String LocCodePrefix, String RequestingParty)
        {
            using (SqlConnection conn = DbUtils.getConnection())
            {
                String LocCodePattern = LocCodePrefix + "%";
                return conn.ExecuteScalar<string>($"select top 1 LocCode from Jo_RPT Where LocCode like @LocCodePattern and RequestingParty=@RequestingParty and Status = @Status and DeletedRecord != 1", new { LocCodePattern = LocCodePattern, RequestingParty = RequestingParty, Status = RPTStatus.OR_PICKUP });
            }
        }

        public static int GetAdvancePickUpLocCodeSequence(String LocCodePrefix)
        {
            using (SqlConnection conn = DbUtils.getConnection())
            {
                String LocCodePattern = LocCodePrefix + "%";
                int currentMaxSequence = conn.ExecuteScalar<int>($"SELECT COALESCE(max (CAST(ltrim(rtrim(substring(LocCode, len(@LocCodePrefix)+1, len(LocCode)-len(@LocCodePrefix) )))AS INT)),0) from Jo_RPT Where LocCode like @LocCodePattern and DeletedRecord != 1", new { LocCodePrefix = LocCodePrefix, LocCodePattern = LocCodePattern });
                return currentMaxSequence + 1;
            }
        }

        public static string SelectByPropertyName(string tdn)
        {
            using (SqlConnection conn = DbUtils.getConnectionToMISCReportV())
            {
                return conn.QuerySingleOrDefault<string>($"SELECT TOP (1) [ONAME] FROM V_TaxBills where pstdn = @tdn order by billdate desc", new { tdn = tdn });
            }
        }

        public static List<RealPropertyTax> SelectBy_TaxDec_Year_Quarter(string TaxDec, string Year, string Quarter)
        {
            using (SqlConnection conn = DbUtils.getConnection())
            {
                return conn.Query<RealPropertyTax>($"SELECT * FROM Jo_RPT where TaxDec = @TaxDec and YearQuarter = @YearQtr and Quarter = @Quarter and DeletedRecord != 1 and DuplicateRecord = 0", new { TaxDec = TaxDec, YearQtr = Year, Quarter = Quarter }).ToList();
            }
        }
    }
}
