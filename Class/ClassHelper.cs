using System;
using System.Globalization;
using System.Windows.Forms;

namespace DeteksiHama.Class
{
    static class ClassHelper
    {
        public static void ClearTextBox(Control ctrl)
        {
            foreach (Control c in ctrl.Controls)
            {
                var textBox = c as TextBox;
                if (textBox != null)
                {
                    textBox.Clear();
                }
                if (c.HasChildren)
                {
                    ClearTextBox(c);
                }
            }
        }

        public static void SetReadOnlyOnTextBox(Control ctrl, bool readOnly)
        {
            if (ctrl is TextBoxBase)
                ((TextBoxBase)ctrl).ReadOnly = readOnly;
            foreach (Control control in ctrl.Controls)
                SetReadOnlyOnTextBox(control, readOnly);
        }

        public static string[] ToStringArray(this int[] intArray)
        {
            return Array.ConvertAll(intArray, intParameter => intParameter.ToString(CultureInfo.InvariantCulture));
        }

        public static int[] ToIntArray(this string[] strArray)
        {
            return Array.ConvertAll(strArray, intParameter => int.Parse(intParameter.ToString(CultureInfo.InvariantCulture)));
        }
    }
}
