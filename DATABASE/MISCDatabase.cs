using System;
using System.Collections.Generic;
//using System.Data.SqlClient;
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
    internal class MISCDatabase
    {
        public static MiscelleneousOccuPermit Get(long MiscID)
        {
            using (SqlConnection conn = DbUtils.getConnection())
            {
                return conn.Get<MiscelleneousOccuPermit>(MiscID);
            }
        }

        public static void InsertMisc(MiscelleneousOccuPermit modelInstance)
        {
            using (SqlConnection conn = DbUtils.getConnection())
            {
                conn.Insert<MiscelleneousOccuPermit>(modelInstance);
            }
        }

        /// <summary>
        /// Updates entire row in the database. 
        /// </summary>
        public static bool UpdateMisc(MiscelleneousOccuPermit modelInstance)
        {
            using (SqlConnection conn = DbUtils.getConnection())
            {
                bool result = conn.Update<MiscelleneousOccuPermit>(modelInstance);
                return result;
            }
        }

        //DISPLAY RECORDS BASED ON MISC TYPE COMBOBOX.
        public static List<MiscelleneousOccuPermit> SelectLatest(string miscType)
        {
            using (SqlConnection conn = DbUtils.getConnection())
            {
                String query = $"SELECT * FROM Jo_MISC WHERE MiscType = @miscType order by MiscID asc";
                return conn.Query<MiscelleneousOccuPermit>(query, new { MiscType = miscType }).ToList();
            }
        }

        public static List<MiscelleneousOccuPermit> SearchOccuPermitRecord(string occuPermitRecord)
        {
            using (SqlConnection conn = DbUtils.getConnection())
            {
                String query = $"SELECT * FROM Jo_MISC WHERE OrderOfPaymentNum LIKE @occuPermitRecord OR OPATrackingNum LIKE @occuPermitRecord order by MiscID asc";
                return conn.Query<MiscelleneousOccuPermit>(query, new { occuPermitRecord = "%" + occuPermitRecord + "%", OPATrackingNum = "%" + occuPermitRecord + "%", }).ToList();
            }
        }

        public static MiscelleneousOccuPermit SelectByOPAtrackingAndOPNum(string OPA_Tracking, string OP_Num)
        {
            using (SqlConnection conn = DbUtils.getConnection())
            {
                return conn.QuerySingleOrDefault<MiscelleneousOccuPermit>($"SELECT * FROM Jo_MISC where OPATrackingNum = @OPA_Tracking or OrderOfPaymentNum = @OP_Num", new { OPA_Tracking = OPA_Tracking, OP_Num = OP_Num });
            }
        }

        private static void AfterInsertOrUpdateOrDelete(SqlConnection conn, MiscelleneousOccuPermit misc, String action)
        {
            //Create audit object.
            MiscOccuPermit_Audit audit = new MiscOccuPermit_Audit();

            //copy the whole record to audit object.
            copyRptToAudit(misc, audit);

            //populates action.
            audit.Action = action;

            //Insert audit sa Jo_RPT_Audit.
            conn.Insert<MiscOccuPermit_Audit>(audit);
        }

        /// <summary>
        /// copy the entire row from Jo_RPT to Jo_RPT_Audit.
        /// </summary>
        private static void copyRptToAudit(MiscelleneousOccuPermit misc, MiscOccuPermit_Audit audit)
        {
            //kukunin pa lang yung lahat ng property from RealPropertyTax at RealPropertyTaxAudit.
            var miscProperties = typeof(MiscelleneousOccuPermit).GetProperties();
            var auditProperties = typeof(MiscOccuPermit_Audit).GetProperties();

            foreach (var miscProperty in miscProperties)
            {
                foreach (var auditProperty in auditProperties)
                {
                    if (miscProperty.Name == auditProperty.Name)
                    {
                        //kung ano makukuha nyang value sa param rpt, ita-transfer nya sa param audit.
                        auditProperty.SetValue(audit, miscProperty.GetValue(misc));
                        break;
                    }
                }
            }
        }

        public static long Insert(MiscelleneousOccuPermit modelInstance)
        {
            using (SqlConnection conn = DbUtils.getConnection())
            {
                RPTUser loginUser = SecurityService.getLoginUser();

                ////Kada galaw sa record, populate yung last 4 columns sa Jo_RPT table.
                modelInstance.LastUpdateBy = loginUser.DisplayName;
                modelInstance.LastUpdateDate = DateTime.Now;

                //Insert record in Jo_RPT.
                long result = conn.Insert<MiscelleneousOccuPermit>(modelInstance);

                //Insert record in Jo_RPT_Audit.
                AfterInsertOrUpdateOrDelete(conn, modelInstance, "INSERT");

                return result;
            }
        }

        /// <summary>
        /// Updates entire row in the database. 
        /// </summary>
        public static bool Update(MiscelleneousOccuPermit modelInstance)
        {
            using (SqlConnection conn = DbUtils.getConnection())
            {
                modelInstance.LastUpdateBy = SecurityService.getLoginUser().DisplayName;
                modelInstance.LastUpdateDate = DateTime.Now;

                bool result = conn.Update<MiscelleneousOccuPermit>(modelInstance);

                AfterInsertOrUpdateOrDelete(conn, modelInstance, "UPDATE");
                return result;
            }
        }

        /// <summary>
        /// Tagging of deleted record in the database.
        /// </summary>
        public static bool Delete(MiscelleneousOccuPermit modelInstance)
        {
            using (SqlConnection conn = DbUtils.getConnection())
            {
                modelInstance.DeletedRecord = 1;
                modelInstance.LastUpdateBy = SecurityService.getLoginUser().DisplayName;
                modelInstance.LastUpdateDate = DateTime.Now;

                bool result = conn.Update<MiscelleneousOccuPermit>(modelInstance);

                AfterInsertOrUpdateOrDelete(conn, modelInstance, "DELETE");

                return result;
            }
        }


        public static List<MiscelleneousOccuPermit> SelectByDateFromToAndStatusAndPaymentChannelForVerification(DateTime paymentDateFrom, DateTime paymentDateTo, string Status, List<string> BankList)
        {
            using (SqlConnection conn = DbUtils.getConnection())
            {
                String query = $"SELECT * FROM Jo_MISC WHERE CAST(PaymentDate as DATE) >= CAST(@PaymentDateFrom as DATE) " +
                    "AND CAST(PaymentDate as DATE) <= CAST(@PaymentDateTo as DATE) AND Status = @Status AND ModeOfPayment in @BankList AND DeletedRecord != 1 " +
                "ORDER BY PaymentDate asc";
                return conn.Query<MiscelleneousOccuPermit>(query, new
                {
                    PaymentDateFrom = paymentDateFrom,
                    PaymentDateTo = paymentDateTo,
                    Status = Status,
                    BankList = BankList
                }).ToList();
            }
        }

        public static List<MiscelleneousOccuPermit> SelectByDateFromToAndStatusAndPaymentChannelForValidation(DateTime verifiedDateFrom, DateTime verifiedDateTo, string Status, List<string> BankList)
        {
            using (SqlConnection conn = DbUtils.getConnection())
            {
                String query = $"SELECT * FROM Jo_MISC WHERE CAST(VerifiedDate as DATE) >= CAST(@VerifiedDateFrom as DATE) " +
                    "AND CAST(VerifiedDate as DATE) <= CAST(@VerifiedDateTo as DATE) AND Status = @Status AND ModeOfPayment in @BankList AND DeletedRecord != 1 " +
                "ORDER BY VerifiedDate asc";
                return conn.Query<MiscelleneousOccuPermit>(query, new
                {
                    VerifiedDateFrom = verifiedDateFrom,
                    VerifiedDateTo = verifiedDateTo,
                    Status = Status,
                    BankList = BankList
                }).ToList();
            }
        }

        public static List<MiscelleneousOccuPermit> SelectByDateFromToAndStatusAndForTransmittal(DateTime validatedDateFrom, DateTime validatedDateTo, string Status)
        {
            using (SqlConnection conn = DbUtils.getConnection())
            {
                String query = $"SELECT * FROM Jo_MISC WHERE CAST(ValidatedDate as DATE) >= CAST(@ValidatedDateFrom as DATE) " +
                    "AND CAST(ValidatedDate as DATE) <= CAST(@ValidatedDateTo as DATE) AND Status = @Status AND DeletedRecord != 1 " +
                "ORDER BY ValidatedDate asc";
                return conn.Query<MiscelleneousOccuPermit>(query, new
                {
                    ValidatedDateFrom = validatedDateFrom,
                    ValidatedDateTo = validatedDateTo,
                    Status = Status,
                }).ToList();
            }
        }

        public static List<MiscelleneousOccuPermit> SelectByDateFromToAndStatusAndTransmitted(DateTime transmittedDateFrom, DateTime transmittedDateTo, string Status)
        {
            using (SqlConnection conn = DbUtils.getConnection())
            {
                String query = $"SELECT * FROM Jo_MISC WHERE CAST(TransmittedDate as DATE) >= CAST(@TransmittedDateFrom as DATE) " +
                    "AND CAST(TransmittedDate as DATE) <= CAST(@TransmittedDateTo as DATE) AND Status = @Status AND DeletedRecord != 1 " +
                "ORDER BY TransmittedDate asc";
                return conn.Query<MiscelleneousOccuPermit>(query, new
                {
                    TransmittedDateFrom = transmittedDateFrom,
                    TransmittedDateTo = transmittedDateTo,
                    Status = Status,
                }).ToList();
            }
        }

        public static List<MiscelleneousOccuPermit> SelectByStatus(string Status)
        {
            using (SqlConnection conn = DbUtils.getConnection())
            {
                String query = $"SELECT * FROM Jo_MISC WHERE Status = @Status and DeletedRecord != 1 ORDER BY EncodedDate ASC";
                return conn.Query<MiscelleneousOccuPermit>(query, new { Status = Status }).ToList();
            }
        }

        /// <summary>
        /// return a list of record from misc_audit.
        /// </summary>
        public static List<MiscOccuPermit_Audit> SelectAudits(long MiscID)
        {
            using (SqlConnection conn = DbUtils.getConnection())
            {
                return conn.Query<MiscOccuPermit_Audit>($"SELECT * FROM Jo_MISC_Audit where MiscID = @MiscID order by AuditID asc", new { MiscID = MiscID }).ToList();
            }
        }

        /// <summary>
        /// Restore from previous status.
        /// </summary>
        public static void Revert(MiscOccuPermit_Audit audit)
        {
            using (SqlConnection conn = DbUtils.getConnection())
            {
                MiscelleneousOccuPermit misc = Get(audit.MiscID);
                copyAuditToMisc(audit, misc);

                misc.LastUpdateBy = SecurityService.getLoginUser().DisplayName;
                misc.LastUpdateDate = DateTime.Now;
                conn.Update<MiscelleneousOccuPermit>(misc);
                AfterInsertOrUpdateOrDelete(conn, misc, "REVERT");
            }
        }

        /// <summary>
        /// copy the entire row from Jo_RPT_Audit to Jo_RPT.
        /// </summary>
        private static void copyAuditToMisc(MiscOccuPermit_Audit audit, MiscelleneousOccuPermit misc)
        {
            var miscProperties = typeof(MiscelleneousOccuPermit).GetProperties();
            var auditProperties = typeof(MiscOccuPermit_Audit).GetProperties();
            foreach (var miscProperty in miscProperties)
            {
                foreach (var auditProperty in auditProperties)
                {
                    if (miscProperty.Name == auditProperty.Name)
                    {
                        miscProperty.SetValue(misc, auditProperty.GetValue(audit));
                        break;
                    }
                }
            }
        }

        public static string SelectBy_TaxpayerName(string OPNumber)
        {
            using (SqlConnection conn = DbUtils.getConnectionToMISCReportV_OccuPerm_Name())
            {
                //return conn.QuerySingleOrDefault<string>($"SELECT TOP (1) [BillNumber] FROM [TaxpayerLName] where BillNumber = @OPNumber order by billdate desc", new { OPNumber = OPNumber });
                return conn.QuerySingleOrDefault<string>($"SELECT TOP (1) [TaxpayerLName] FROM MiscDetailsBillingSTAGE where BillNumber = @OPNumber", new { OPNumber = OPNumber });

            }
        }
    }
}