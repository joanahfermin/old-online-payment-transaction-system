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

        public static long Insert(MiscelleneousOccuPermit modelInstance)
        {
            using (SqlConnection conn = DbUtils.getConnection())
            {
                RPTUser loginUser = SecurityService.getLoginUser();
                ////Kada galaw sa record, populate yung last 4 columns sa Jo_RPT table.
                //modelInstance.CreatedBy = loginUser.DisplayName;
                //modelInstance.CreatedDate = DateTime.Now;
                //modelInstance.LastUpdateBy = loginUser.DisplayName;
                //modelInstance.LastUpdateDate = DateTime.Now;

                //lilinisin yung bank.
                //BeforeInsertOrUpdate(modelInstance);

                //Insert record in Jo_RPT.
                long result = conn.Insert<MiscelleneousOccuPermit>(modelInstance);

                //Insert record in Jo_RPT_Audit.
                //AfterInsertOrUpdateOrDelete(conn, modelInstance, "INSERT");

                return result;
            }
        }
    }
}