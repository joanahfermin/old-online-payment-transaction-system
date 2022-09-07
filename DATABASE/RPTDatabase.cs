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
        /// <summary>
        /// Returns a list of maximum number of rows.
        /// </summary>
        /// <returns></returns>
        public static List<RealPropertyTax> SelectLatest()
        {
            using (SqlConnection conn = DbUtils.getConnection())
            {
                return conn.Query<RealPropertyTax>($"SELECT TOP {GlobalConstants.LISTVIEW_MAX_ROWS} * FROM Jo_RPT where DeletedRecord != 1 order by RptID ASC").ToList();
            }
        }

        /// <summary>
        /// Returns a list of records based on taxdec.
        /// </summary>
        /// <param name="taxdec"></param>
        /// <returns></returns>
        public static List<RealPropertyTax> SelectByTaxDec(string taxdec) //F-084-12122;
        {
            using (SqlConnection conn = DbUtils.getConnection())
            { 
                return conn.Query<RealPropertyTax>($"SELECT TOP {GlobalConstants.LISTVIEW_MAX_ROWS} * FROM Jo_RPT where TaxDec = @TaxDec and DeletedRecord != 1 order by EncodedDate", new { TaxDec = taxdec }).ToList();
            }
        }

        //HINDI GINAGAMIT?
        /// <summary>
        /// Returns a list of records based on date.
        /// </summary>
        /// <param name="encodedDate"></param>
        /// <returns></returns>
        public static List<RealPropertyTax> SelectByDate(DateTime encodedDate)
        {
            using (SqlConnection conn = DbUtils.getConnection())
            {
                //Returns the list of records from the database.         //removing time in date format. 
                return conn.Query<RealPropertyTax>($"SELECT TOP {GlobalConstants.LISTVIEW_MAX_ROWS} * FROM Jo_RPT WHERE CAST(EncodedDate AS DATE) = CAST(@EncodedDate AS DATE) and DeletedRecord != 1 order by RptID ASC", new { EncodedDate = encodedDate }).ToList();
            }
        }

        /// Returns a list of records based on date range.
        public static List<RealPropertyTax> SelectByDateFromTo(DateTime encodedDateFrom, DateTime encodedDateTo)
        {
            using (SqlConnection conn = DbUtils.getConnection())
            {
                //Returns the list of records from the database.         //removing time in date format. 
                return conn.Query<RealPropertyTax>($"SELECT TOP {GlobalConstants.LISTVIEW_MAX_ROWS} * FROM Jo_RPT WHERE CAST(EncodedDate as DATE) >= CAST(@EncodedDateFrom as DATE) " +
                    $"AND CAST(EncodedDate as DATE) <= CAST(@EncodedDateTo as DATE) and DeletedRecord != 1 order by RptID ASC", 
                    new { EncodedDateFrom = encodedDateFrom, EncodedDateTo = encodedDateTo }).ToList();
            }
        }

        /// <summary>
        /// Returns a list of records based on date range and status.
        /// </summary>
        /// <param name="encodedDateFrom"></param>
        /// <param name="encodedDateTo"></param>
        /// <param name="StatusList"></param>
        /// <returns></returns>
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
        /// <param name="encodedDateFrom"></param>
        /// <param name="encodedDateTo"></param>
        /// <param name="StatusList"></param>
        /// <param name="PaymentChannelList"></param>
        /// <returns></returns>
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

        //HINDI GINAGAMIT?
        /// <summary>
        /// Returns a list of records based on date range and paymentchannel.
        /// </summary>
        /// <param name="StatusList"></param>
        /// <param name="PaymentChannelList"></param>
        /// <returns></returns>
        public static List<RealPropertyTax> SelectByStatusAndPaymentChannel(List<string> StatusList, List<string> PaymentChannelList)
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
        /// <param name="StatusList"></param>
        /// <returns></returns>
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
        /// <param name="TaxDec"></param>
        /// <param name="YearQtr"></param>
        /// <returns></returns>
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
        /// <param name="TaxDec"></param>
        /// <returns></returns>
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
        /// <param name="TaxDec"></param>
        /// <param name="StatusList"></param>
        /// <returns></returns>
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
        /// <param name="RefNum"></param>
        /// <returns></returns>
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
        /// <returns></returns>
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
        /// <param name="RPTId"></param>
        /// <returns></returns>
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
        /// <param name="modelInstance"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Updates entire row in the database. 
        /// </summary>
        /// <param name="modelInstance"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Tagging of deleted record in the database.
        /// </summary>
        /// <param name="modelInstance"></param>
        /// <returns></returns>
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
