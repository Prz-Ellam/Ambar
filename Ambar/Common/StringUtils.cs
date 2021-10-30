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
        public static string GetText(string str) // Elimina todos los whitespaces de un string
        {
            return string.Join(" ", str.Split(new char[0], StringSplitOptions.RemoveEmptyEntries).ToList()
                .Select(w => w.Trim()));
        }

       

    }
}
