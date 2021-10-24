using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ambar.Common
{
    class StringUtils
    {
        public static string GetText(string str)
        {
            string text = str;
            if (text == "") return "";
            int index0 = (int)FindFirstNotOf(text, " ");
            text = text.Remove(0, index0);
            int index1 = (int)FindLastNotOf(text, " ");
            int count = text.Length - index1 - 1;
            text = text.Remove(index1 + 1, count);

            return text;
        }

        public static string GetText(TextBox textBox)
        {
            string text = textBox.Text;
            if (text == "") return "";
            int index0 = (int)FindFirstNotOf(text, " ");
            text = text.Remove(0, index0);
            int index1 = (int)FindLastNotOf(text, " ");
            int count = text.Length - index1 - 1;
            text = text.Remove(index1 + 1, count);

            return text;
        }

        public static int? FindFirstNotOf(string source, string chars)
        {
            if (source == null) throw new ArgumentNullException("source");
            if (chars == null) throw new ArgumentNullException("chars");
            if (source.Length == 0) return null;
            if (chars.Length == 0) return 0;

            for (int i = 0; i < source.Length; i++)
            {
                if (chars.IndexOf(source[i]) == -1) return i;
            }
            return null;
        }

        public static int? FindLastNotOf(string source, string chars)
        {
            if (source == null) throw new ArgumentNullException("source");
            if (chars == null) throw new ArgumentNullException("chars");
            if (source.Length == 0) return null;
            if (chars.Length == 0) return source.Length - 1;

            for (int i = source.Length - 1; i >= 0; i--)
            {
                if (chars.IndexOf(source[i]) == -1) return i;
            }
            return null;
        }
    }
}
