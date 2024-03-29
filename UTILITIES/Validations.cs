﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SampleRPT1.UTILITIES
{
    internal class Validations
    {
        /// <summary>
        /// Check if the given error provider have any errors encountered.
        /// </summary>
        public static bool HaveErrors(ErrorProvider ep)
        {
            foreach (Control formControl in ep.ContainerControl.Controls)
                if (formControl is Panel)
                {
                    Panel panel = (Panel)formControl;
                    foreach (Control panelControl in panel.Controls)

                        if (ep.GetError(panelControl) != "")
                            return true;
                }
                else
                {
                    if (ep.GetError(formControl) != "")
                        return true;
                }

            return false;
        }

        public static void ValidateTaxDecFormat(ErrorProvider ep, TextBox tb, string propertyName)
        {
            if (hasExistingError(ep, tb))
            {
                return;
            }
            Regex re = new Regex("^[A|B|C|D|E|F|G]-[0-9]{3}-[0-9]{5}( / [A|B|C|D|E|F|G]-[0-9]{3}-[0-9]{5})*$");
            if (!re.IsMatch(tb.Text.Trim()))
            {
                ep.SetError(tb, $"{propertyName} is not in correct format.");
            }
        }

        //EMAIL ADDRESS FORMAT VALIDATION
        public static void ValidateEmailAddressFormat(ErrorProvider ep, TextBox tb, string propertyName)
        {
            if (hasExistingError(ep, tb))
            {
                return;
            }
            if (tb.Text.Trim() == "")
            {
                return;
            }
            try
            {
                MailAddress m = new MailAddress(tb.Text.Trim());
            }
            catch (FormatException)
            {
                ep.SetError(tb, $"{propertyName} is not a valid email address.");
            }
        }

        //EMAIL ADDRESS FORMAT VALIDATION
        public static bool ValidateEmailAddressFormat(string Value)
        {
            try
            {
                MailAddress m = new MailAddress(Value);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }


        /// <summary>
        /// Validate if a given textbox is not empty
        /// </summary>
        public static void ValidateRequired(ErrorProvider ep, TextBox tb, string propertyName)
        {
            if (hasExistingError(ep, tb))
            {
                return;
            }
            if (tb.Text.Trim() == "")
            {
                ep.SetError(tb, $"{propertyName} is required.");
            }
        }

        /// <summary>
        /// Validate if a given combobox is not empty
        /// </summary>
        public static void ValidateRequired(ErrorProvider ep, ComboBox cb, string propertyName)
        {
            if (hasExistingErrorForBank(ep, cb))
            {
                return;
            }
            if (cb.Text.Trim() == "please")
            {
                ep.SetError(cb, $"{propertyName} is required.");
            }
        }


        /// <summary>
        /// Validate if total amount deposited is 0.
        /// </summary>
        /// <param name="ep"></param>
        /// <param name="tb"></param>
        /// <param name="propertyName"></param>
        public static void ValidateRequiredAmountToPay(ErrorProvider ep, TextBox tb, string propertyName)
        {
            if (hasExistingError(ep, tb))
            {
                return;
            }
            if (tb.Text.Trim() == "0.00")
            {
                ep.SetError(tb, $"{propertyName} is required.");
            }
        }

        /// <summary>
        /// Validate if bank is empty.
        /// </summary>
        public static void ValidateRequiredBank(ErrorProvider ep, ComboBox cb, string propertyName)
        {
            if (hasExistingErrorForBank(ep, cb))
            {
                return;
            }

            if (cb.Text.Trim().ToLower().StartsWith("please"))
            {
                ep.SetError(cb, $"{propertyName} is required.");
            }
        }

        /// <summary>
        /// Validate if a given year is in a correct format.
        /// </summary>
        public static void ValidateYearFormat(ErrorProvider ep, TextBox tb, string propertyName)
        {
            if (hasExistingError(ep, tb))
            {
                return;
            }
            Regex re = new Regex("^[0-9]{4}$");
            if (!re.IsMatch(tb.Text.Trim()))
            {
                ep.SetError(tb, $"{propertyName} is not in correct format.");
            }
        }

        /// <summary>
        /// Validate if a given textbox contains a number between two values
        /// </summary>
        public static void ValidateValueBetween(ErrorProvider ep, TextBox tb, string propertyName, int valueFrom, int valueTo)
        {
            if (hasExistingError(ep, tb))
            {
                return;
            }
            int temp;
            int.TryParse(tb.Text.Trim(), out temp);
            if (temp < valueFrom || temp > valueTo)
            {
                ep.SetError(tb, $"{propertyName} must be between {valueFrom} and {valueTo}.");
            }
        }

        /// <summary>
        /// Check if the given textbox already contains error.
        /// </summary>
        private static bool hasExistingError(ErrorProvider ep, TextBox tb)
        {
            return ep.GetError(tb).Length > 0;
        }

        private static bool hasExistingErrorForBank(ErrorProvider ep, ComboBox tb)
        {
            return ep.GetError(tb).Length > 0;
        }

        ///// <summary>
        ///// Check if a column in listview contains error.
        ///// </summary>
        //private static bool hasExistingError_inLV(ErrorProvider ep, ListView lv)
        //{
        //    foreach (ListView item in lv.Items)
        //    {
        //        string s = item.Items[0].SubItems[3].Text;

        //        if (s == string.Empty)
        //        {
        //            return ep.GetError(lv).Length < 0;
        //        }
        //    }
        //}

        ///// <summary>
        ///// Validate if a column in listview is not empty
        ///// </summary>
        //public static void ValidateRequired_RetrieveName_MiscOccuPerm(ErrorProvider ep, ListView lv, string propertyName)
        //{
        //    if (hasExistingError_inLV(ep, lv))
        //    {
        //        return;
        //    }
        //    if (lv.Text.Trim() == "")
        //    {
        //        ep.SetError(lv, $"{propertyName} is required.");
        //    }
        //}

    }
}
