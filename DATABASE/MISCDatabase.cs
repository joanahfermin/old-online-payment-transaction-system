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
using SampleRPT1.UTILITIES;

namespace SampleRPT1
{
    internal class MISCDatabase
    {
        private static List<MiscelleneousTax> allmisc = new List<MiscelleneousTax>();

        public static MiscelleneousTax Get(long MiscID)
        {
            using (SqlConnection conn = DbUtils.getConnection())
            {
                return conn.Get<MiscelleneousTax>(MiscID);
            }
        }

        public static void InsertMisc(MiscelleneousTax modelInstance)
        {
            using (SqlConnection conn = DbUtils.getConnection())
            {
                conn.Insert<MiscelleneousTax>(modelInstance);
            }
        }

        /// <summary>
        /// Updates entire row in the database. 
        /// </summary>
        public static bool UpdateMisc(MiscelleneousTax modelInstance)
        {
            using (SqlConnection conn = DbUtils.getConnection())
            {
                bool result = conn.Update<MiscelleneousTax>(modelInstance);
                return result;
            }
        }

        //DISPLAY RECORDS BASED ON MISC TYPE COMBOBOX.
        public static List<MiscelleneousTax> SelectLatest(string miscType)
        {
            using (SqlConnection conn = DbUtils.getConnection())
            {
                String query = $"SELECT * FROM Jo_MISC WHERE MiscType = @miscType order by MiscID asc";
                return conn.Query<MiscelleneousTax>(query, new { MiscType = miscType }).ToList();
            }
        }

        public static List<MiscelleneousTax> Search(string MiscType, string SearchString)
        {
            using (SqlConnection conn = DbUtils.getConnection())
            {
                string query = null;
                if (MiscType == Misc_Type.OCCUPATIONAL_PERMIT)
                {
                    query = $"SELECT * FROM Jo_MISC WHERE OrderOfPaymentNum LIKE @SearchString OR OPATrackingNum LIKE @SearchString order by MiscID asc";
                }
                else if (MiscType == Misc_Type.PTR)
                {
                    query = $"SELECT * FROM Jo_MISC WHERE PRC_IBP_No LIKE @SearchString OR TaxpayersName LIKE @SearchString order by MiscID asc";
                }
                // default
                else // if (MiscType == Misc_Type.TAX_CLEARANCE || MiscType == Misc_Type.HEALTH_CERTIFICATE)
                {
                    query = $"SELECT * FROM Jo_MISC WHERE TaxpayersName LIKE @SearchString order by MiscID asc";

                }
                return conn.Query<MiscelleneousTax>(query, new { SearchString = "%" + SearchString + "%"}).ToList();
            }
        }

        public static MiscelleneousTax SelectByOPAtrackingAndOPNum(string OPA_Tracking, string OP_Num)
        {
            using (SqlConnection conn = DbUtils.getConnection())
            {
                return conn.QuerySingleOrDefault<MiscelleneousTax>($"SELECT * FROM Jo_MISC where OPATrackingNum = @OPA_Tracking or OrderOfPaymentNum = @OP_Num", new { OPA_Tracking = OPA_Tracking, OP_Num = OP_Num });
            }
        }

        private static void AfterInsertOrUpdateOrDelete(SqlConnection conn, MiscelleneousTax misc, String action)
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
        private static void copyRptToAudit(MiscelleneousTax misc, MiscOccuPermit_Audit audit)
        {
            //kukunin pa lang yung lahat ng property from RealPropertyTax at RealPropertyTaxAudit.
            var miscProperties = typeof(MiscelleneousTax).GetProperties();
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

        public static long Insert(MiscelleneousTax modelInstance)
        {
            using (SqlConnection conn = DbUtils.getConnection())
            {
                RPTUser loginUser = SecurityService.getLoginUser();

                ////Kada galaw sa record, populate yung last 4 columns sa Jo_RPT table.
                modelInstance.LastUpdateBy = loginUser.DisplayName;
                modelInstance.LastUpdateDate = DateTime.Now;

                //Insert record in Jo_RPT.
                long result = conn.Insert<MiscelleneousTax>(modelInstance);

                //Insert record in Jo_RPT_Audit.
                AfterInsertOrUpdateOrDelete(conn, modelInstance, "INSERT");

                return result;
            }
        }

        /// <summary>
        /// Updates entire row in the database. 
        /// </summary>
        public static bool Update(MiscelleneousTax modelInstance)
        {
            using (SqlConnection conn = DbUtils.getConnection())
            {
                modelInstance.LastUpdateBy = SecurityService.getLoginUser().DisplayName;
                modelInstance.LastUpdateDate = DateTime.Now;

                bool result = conn.Update<MiscelleneousTax>(modelInstance);

                AfterInsertOrUpdateOrDelete(conn, modelInstance, "UPDATE");
                return result;
            }
        }

        /// <summary>
        /// Tagging of deleted record in the database.
        /// </summary>
        public static bool Delete(MiscelleneousTax modelInstance)
        {
            using (SqlConnection conn = DbUtils.getConnection())
            {
                modelInstance.DeletedRecord = 1;
                modelInstance.LastUpdateBy = SecurityService.getLoginUser().DisplayName;
                modelInstance.LastUpdateDate = DateTime.Now;

                bool result = conn.Update<MiscelleneousTax>(modelInstance);

                AfterInsertOrUpdateOrDelete(conn, modelInstance, "DELETE");

                return result;
            }
        }


        public static List<MiscelleneousTax> SelectByDateFromToAndStatusAndPaymentChannelForVerification(DateTime paymentDateFrom, DateTime paymentDateTo, string MiscType, string Status, List<string> BankList)
        {
            using (SqlConnection conn = DbUtils.getConnection())
            {
                String query = $"SELECT * FROM Jo_MISC WHERE CAST(PaymentDate as DATE) >= CAST(@PaymentDateFrom as DATE) " +
                    "AND CAST(PaymentDate as DATE) <= CAST(@PaymentDateTo as DATE) AND Status = @Status AND MiscType = @MiscType AND ModeOfPayment in @BankList AND DeletedRecord != 1 " +
                "ORDER BY PaymentDate asc";
                return conn.Query<MiscelleneousTax>(query, new
                {
                    PaymentDateFrom = paymentDateFrom,
                    PaymentDateTo = paymentDateTo,
                    Status = Status,
                    MiscType = MiscType,
                    BankList = BankList
                }).ToList();
            }
        }

        public static List<MiscelleneousTax> SelectByDateFromToAndStatusAndPaymentChannelForValidation(DateTime verifiedDateFrom, DateTime verifiedDateTo, string MiscType, string Status, List<string> BankList)
        {
            using (SqlConnection conn = DbUtils.getConnection())
            {
                String query = $"SELECT * FROM Jo_MISC WHERE CAST(VerifiedDate as DATE) >= CAST(@VerifiedDateFrom as DATE) " +
                    "AND CAST(VerifiedDate as DATE) <= CAST(@VerifiedDateTo as DATE) AND Status = @Status AND MiscType = @MiscType AND ModeOfPayment in @BankList AND DeletedRecord != 1 " +
                "ORDER BY VerifiedDate asc";
                return conn.Query<MiscelleneousTax>(query, new
                {
                    VerifiedDateFrom = verifiedDateFrom,
                    VerifiedDateTo = verifiedDateTo,
                    Status = Status,
                    MiscType = MiscType,
                    BankList = BankList
                }).ToList();
            }
        }

        public static List<MiscelleneousTax> SelectByDateFromToAndStatusAndForTransmittal(DateTime validatedDateFrom, DateTime validatedDateTo, string MiscType, string Status)
        {
            using (SqlConnection conn = DbUtils.getConnection())
            {
                String query = $"SELECT * FROM Jo_MISC WHERE CAST(ValidatedDate as DATE) >= CAST(@ValidatedDateFrom as DATE) " +
                    "AND CAST(ValidatedDate as DATE) <= CAST(@ValidatedDateTo as DATE) AND Status = @Status AND MiscType = @MiscType AND DeletedRecord != 1 " +
                "ORDER BY ValidatedDate asc";
                return conn.Query<MiscelleneousTax>(query, new
                {
                    ValidatedDateFrom = validatedDateFrom,
                    ValidatedDateTo = validatedDateTo,
                    Status = Status,
                    MiscType = MiscType,
                }).ToList();
            }
        }

        public static List<MiscelleneousTax> SelectByDateFromToAndStatusAndTransmitted(DateTime transmittedDateFrom, DateTime transmittedDateTo, string MiscType, string Status)
        {
            using (SqlConnection conn = DbUtils.getConnection())
            {
                String query = $"SELECT * FROM Jo_MISC WHERE CAST(TransmittedDate as DATE) >= CAST(@TransmittedDateFrom as DATE) " +
                    "AND CAST(TransmittedDate as DATE) <= CAST(@TransmittedDateTo as DATE) AND Status = @Status AND MiscType = @MiscType AND DeletedRecord != 1 " +
                "ORDER BY TransmittedDate asc";
                return conn.Query<MiscelleneousTax>(query, new
                {
                    TransmittedDateFrom = transmittedDateFrom,
                    TransmittedDateTo = transmittedDateTo,
                    Status = Status,
                    MiscType = MiscType,
                }).ToList();
            }
        }

        public static List<MiscelleneousTax> SelectByStatus(string MiscType, string Status)
        {
            using (SqlConnection conn = DbUtils.getConnection())
            {
                String query = $"SELECT * FROM Jo_MISC WHERE Status = @Status AND MiscType = @MiscType and DeletedRecord != 1 ORDER BY EncodedDate desc";
                return conn.Query<MiscelleneousTax>(query, new { Status = Status, MiscType = MiscType }).ToList();
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
                MiscelleneousTax misc = Get(audit.MiscID);
                copyAuditToMisc(audit, misc);

                misc.LastUpdateBy = SecurityService.getLoginUser().DisplayName;
                misc.LastUpdateDate = DateTime.Now;
                conn.Update<MiscelleneousTax>(misc);
                AfterInsertOrUpdateOrDelete(conn, misc, "REVERT");
            }
        }

        /// <summary>
        /// copy the entire row from Jo_RPT_Audit to Jo_RPT.
        /// </summary>
        private static void copyAuditToMisc(MiscOccuPermit_Audit audit, MiscelleneousTax misc)
        {
            var miscProperties = typeof(MiscelleneousTax).GetProperties();
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

        public static void CreateMisc(MiscelleneousTax misc)
        {
            allmisc.Add(misc);
        }

        public static List<Misc_OccuPermit_TagName> SelectBy_TaxpayerName_Bulk(List<string> OPNumber_List)
        {
            using (SqlConnection conn = DbUtils.getConnectionToMISCReportV_OccuPerm_Name())
            {
                return conn.Query<Misc_OccuPermit_TagName>($"SELECT * FROM MiscDetailsBillingSTAGE where BillNumber in @OPNumber_List", new { OPNumber_List = OPNumber_List }).ToList();

            }
        }
    }
}