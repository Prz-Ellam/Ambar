using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambar.Common
{
    class UserCache
    {
        public static Guid id { get; set; }
        public static string username { get; set; }
        public static string position { get; set; }

        public static DateTime offset { get; set; }

    }
}
