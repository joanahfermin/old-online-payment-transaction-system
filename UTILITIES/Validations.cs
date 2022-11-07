using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        /// Validate if a given textbox contains a number
        /// </summary>
        public static void ValidateNumber(ErrorProvider ep, TextBox tb, string propertyName)
        {
            if (hasExistingError(ep, tb))
            {
                return;
            }
            long temp;
            if (!long.TryParse(tb.Text.Trim(), out temp))
            {
                ep.SetError(tb, $"{propertyName} must be numeric.");
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
    }
}
