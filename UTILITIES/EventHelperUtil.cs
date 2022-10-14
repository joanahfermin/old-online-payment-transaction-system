using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SampleRPT1.UTILITIES
{
    internal class EventHelperUtil
    {
        public static void OneDecimalPointOnly(object sender, KeyPressEventArgs e)
        {
            //numeric value only
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
        (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        public static void EnterKeyDown(object sender, KeyEventArgs e, Form form)
        {
            if (e.KeyData == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                form.SelectNextControl(form.ActiveControl, true, true, true, true);
            }
        }

        
    }
}
