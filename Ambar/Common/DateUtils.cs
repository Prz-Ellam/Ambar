using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambar.Common
{
    class DateUtils
    {
        public static int FindBimester(DateTime date)
        {
            return (date.Month - 1) / 2 + 1;
        }

    }
}
