﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SampleRPT1
{
    internal class ListViewUtil
    {
        /// <summary>
        /// Returns a list of records form the database to the listview.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="listOfDataClass">list from the database</param>
        /// <param name="listView">kung anong pupuntahan na listview sa system</param>
        /// <param name="propertyNames">data class model</param>
        public static void copyFromListToListview<T>(List<T> listOfDataClass, ListView listView, List<String> propertyNames)
        {
            listView.Items.Clear();

            // foreach (RealPropertyTax rpt in rptList)
            // isa-isahin ang rows ng laman ng database. 
            foreach (T dataClassInstance in listOfDataClass) 
            {
                //ListViewItem item = new ListViewItem(rpt.RptID.ToString());
                ListViewItem item = new ListViewItem(GetPropValue(dataClassInstance, propertyNames[0]));

                //    item.SubItems.Add(rpt.TaxDec?.ToString());
                //    item.SubItems.Add(rpt.PropertyType.ToString());
                //    item.SubItems.Add(rpt.TaxPayerName.ToString());
                //    item.SubItems.Add(rpt.AmountToPay.ToString());
                //    item.SubItems.Add(rpt.AmountTransferred.ToString());
                //    item.SubItems.Add(rpt.Bank.ToString());
                //    item.SubItems.Add(rpt.YearQuarter.ToString());
                //    item.SubItems.Add(rpt.Status.ToString());
                //    item.SubItems.Add(rpt.EncodedBy.ToString());
                //    item.SubItems.Add(rpt.EncodedDate.ToString());
                //    item.SubItems.Add(rpt.SentBy?.ToString());
                //    item.SubItems.Add(rpt.SentDate.ToString());
                //    item.SubItems.Add(rpt.RPTremarks?.ToString());


                //{ "RptID", "TaxDec", "PropertyType", "TaxPayerName", "AmountToPay", "AmountTransferred", "Bank", "YearQuarter", "Status",
                // "EncodedBy", "EncodedDate", "SentBy", "SentDate", "RPTremarks"} );
            for (int i = 1; i < propertyNames.Count; i++)
                {
                    item.SubItems.Add(GetPropValue(dataClassInstance, propertyNames[i]));
                }
                listView.Items.Add(item);
            }
        }

        public static void copyFromListToListview_With_Row_Number<T>(List<T> listOfDataClass, ListView listView, List<String> propertyNames)
        {
            listView.Items.Clear();

            // foreach (RealPropertyTax rpt in rptList)
            // isa-isahin ang rows ng laman ng database. 
            int Row_Number = 1;

            foreach (T dataClassInstance in listOfDataClass)
            {
                //ListViewItem item = new ListViewItem(rpt.RptID.ToString());
                ListViewItem item = new ListViewItem(Row_Number.ToString());

                item.SubItems.Add(GetPropValue(dataClassInstance, propertyNames[0]));

                for (int i = 1; i < propertyNames.Count; i++)
                {
                    item.SubItems.Add(GetPropValue(dataClassInstance, propertyNames[i]));
                }
                listView.Items.Add(item);
                Row_Number++;
            }
        }

        //rpt.TaxDec?.ToString()
        //thousand separator. 
        private static string GetPropValue(object src, string propName)
        {
            object obj = src.GetType().GetProperty(propName).GetValue(src, null);
            if (obj == null)
            {
                return "";
            }
            else
            {
                if (obj is decimal)
                {
                    decimal d = (decimal)obj;
                    return d.ToString("#,##0.00");
                }
                else if (obj is DateTime)
                {
                    DateTime d = (DateTime)obj;
                    return d.ToShortDateString();
                }
                else
                {
                    return obj.ToString();
                }
            }
        }
    }
}
