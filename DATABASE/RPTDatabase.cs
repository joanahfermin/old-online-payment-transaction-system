using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper.Contrib.Extensions;
using Dapper;
using Microsoft.Data.SqlClient;


namespace SampleRPT1
{
    internal class RPTDatabase
    {
        public static List<RealPropertyTax> SelectLatest()
        {
            using (SqlConnection conn = DbUtils.getConnection())
            {
                //Returns the list of records from the database. 
                return conn.Query<RealPropertyTax>($"SELECT TOP {GlobalVariables.LISTVIEW_MAX_ROWS} * FROM JO_z where DeletedRecord != 1 order by RptID ASC").ToList();
            }
        }

        public static List<RealPropertyTax> SelectByTaxDec(string taxdec) //F-084-12122;
        {
            using (SqlConnection conn = DbUtils.getConnection())
            {
                //Returns the list of records from the database. 
                return conn.Query<RealPropertyTax>($"SELECT * FROM JO_z where TaxDec = @TaxDec and DeletedRecord != 1 order by EncodedDate", new { TaxDec = taxdec }).ToList();
            }
        }

        public static List<RealPropertyTax> SelectByDate(DateTime encodedDate)
        {
            using (SqlConnection conn = DbUtils.getConnection())
            {
                //Returns the list of records from the database.         //removing time in date format. 
                return conn.Query<RealPropertyTax>($"SELECT * FROM JO_z WHERE CAST(EncodedDate AS DATE) = CAST(@EncodedDate AS DATE) and DeletedRecord != 1 order by RptID ASC", new { EncodedDate = encodedDate }).ToList();
            }
        }

        public static List<RealPropertyTax> SelectByDateFromTo(DateTime encodedDateFrom, DateTime encodedDateTo)
        {
            using (SqlConnection conn = DbUtils.getConnection())
            {
                //Returns the list of records from the database.         //removing time in date format. 
                return conn.Query<RealPropertyTax>($"SELECT * FROM JO_z WHERE CAST(EncodedDate as DATE) >= CAST(@EncodedDateFrom as DATE) " +
                    $"AND CAST(EncodedDate as DATE) <= CAST(@EncodedDateTo as DATE) and DeletedRecord != 1 order by RptID ASC", 
                    new { EncodedDateFrom = encodedDateFrom, EncodedDateTo = encodedDateTo }).ToList();
            }
        }

        public static List<RealPropertyTax> SelectByDateFromToAndStatus(DateTime encodedDateFrom, DateTime encodedDateTo, List<string> StatusList)
        {
            using (SqlConnection conn = DbUtils.getConnection())
            {
                String query = "SELECT * FROM Jo_Z WHERE CAST(EncodedDate as DATE) >= CAST(@EncodedDateFrom as DATE) " +
                    "AND CAST(EncodedDate as DATE) <= CAST(@EncodedDateTo as DATE) AND Status in @StatusList and DeletedRecord != 1 " +
                    "ORDER BY RptID ASC";
                return conn.Query<RealPropertyTax>(query, new { EncodedDateFrom = encodedDateFrom, EncodedDateTo = encodedDateTo, 
                    StatusList = StatusList }).ToList();
            }
        }

        public static List<RealPropertyTax> SelectByDateAndStatus(DateTime EncodedDate, List<string> StatusList)
        {
            using (SqlConnection conn = DbUtils.getConnection())
            {
                String query = "SELECT * FROM Jo_Z WHERE CAST(EncodedDate AS DATE) = CAST(@EncodedDate AS DATE) AND Status in @StatusList and DeletedRecord != 1 ORDER BY RptID ASC";
                return conn.Query<RealPropertyTax>(query, new { EncodedDate = EncodedDate, StatusList = StatusList }).ToList();
            }
        }

        public static List<RealPropertyTax> SelectByStatus(List<string> StatusList)
        {
            using (SqlConnection conn = DbUtils.getConnection())
            {
                String query = "SELECT TOP 100 * FROM JO_z WHERE Status in @StatusList and DeletedRecord != 1 ORDER BY RptID ASC";
                return conn.Query<RealPropertyTax>(query, new { StatusList = StatusList }).ToList();
            }
        }

        public static RealPropertyTax SelectByTaxDecAndYear(string TaxDec, string YearQtr)
        {
            using (SqlConnection conn = DbUtils.getConnection())
            {
                return conn.QuerySingleOrDefault<RealPropertyTax>($"SELECT * FROM Jo_Z where TaxDec = @TaxDec and YearQuarter = @YearQtr and DeletedRecord != 1", new { TaxDec = TaxDec, YearQtr = YearQtr });
            }
        }

        public static List<RealPropertyTax> SelectBySameGroup(string TaxDec)
        {
            using (SqlConnection conn = DbUtils.getConnection())
            {
                return conn.Query<RealPropertyTax>($"SELECT * FROM Jo_Z where TaxDec = @TaxDec and DeletedRecord != 1 UNION SELECT * FROM Jo_Z where RefNum in (select RefNum FROM Jo_Z where TaxDec = @TaxDec) and DeletedRecord != 1 " +
                    $"order by RefNum desc, taxdec asc", new { TaxDec = TaxDec }).ToList();
            }
        }

        public static List<RealPropertyTax> SelectBySameGroupReleasing(string TaxDec, List<string> StatusList)
        {
            using (SqlConnection conn = DbUtils.getConnection())
            {
                return conn.Query<RealPropertyTax>($"SELECT * FROM Jo_Z where TaxDec = @TaxDec and DeletedRecord != 1 and Status = @Status UNION SELECT * FROM Jo_Z where RefNum in (select RefNum FROM Jo_Z where TaxDec = @TaxDec) and DeletedRecord != 1 and Status = @Status " +
                    $"order by RefNum desc, taxdec asc", new { TaxDec = TaxDec, Status = StatusList }).ToList();
            }
        }

        public static List<RealPropertyTax> SelectByRefNum(string RefNum)
        {
            using (SqlConnection conn = DbUtils.getConnection())
            {
                return conn.Query<RealPropertyTax>($"SELECT * FROM Jo_Z where RefNum= @RefNum and DeletedRecord != 1 order by RptID ASC", new { RefNum = RefNum }).ToList();
            }
        }

        public static int CountLocation()
        {
            using (SqlConnection conn = DbUtils.getConnection())
            {
                return conn.ExecuteScalar<int>($"SELECT count(*) FROM Jo_Z where LocCode is not null and DeletedRecord != 1");
            }
        }

        public static RealPropertyTax Get(long RPTId)
        {
            using (SqlConnection conn = DbUtils.getConnection())
            {
                return conn.Get<RealPropertyTax>(RPTId);
            }
        }
        public static long Insert(RealPropertyTax modelInstance)
        {
            using (SqlConnection conn = DbUtils.getConnection())
            {
                if (modelInstance.Bank != null)
                {
                    modelInstance.Bank = modelInstance.Bank.ToUpper();
                }
                return conn.Insert<RealPropertyTax>(modelInstance);
            }
        }

        public static long Insert(RealPropertyTaxPayment modelInstance)
        {
            using (SqlConnection conn = DbUtils.getConnection())
            {
                //if (modelInstance.Bank != null)
                //{
                //    modelInstance.Bank = modelInstance.Bank.ToUpper();
                //}
                return conn.Insert<RealPropertyTaxPayment>(modelInstance);
            }
        }

        public static bool Update(RealPropertyTax modelInstance)
        {
            using (SqlConnection conn = DbUtils.getConnection())
            {
                if (modelInstance.Bank != null)
                {
                    modelInstance.Bank = modelInstance.Bank.ToUpper();
                }
                return conn.Update<RealPropertyTax>(modelInstance);
            }
        }

        public static bool Delete(RealPropertyTax modelInstance)
        {
            using (SqlConnection conn = DbUtils.getConnection())
            {
                modelInstance.DeletedRecord = 1;
                return conn.Update<RealPropertyTax>(modelInstance);
            }
        }
    }
}
