using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;
using Cassandra;

namespace Ambar.Common
{
    class DateUtils
    {
        public static bool NormalizeDates(string serviceType, ref DateTime start, ref DateTime request)
        {
            if (serviceType == "Domestico")
            {
                start = (start.Month % 2 == 0) ? start.AddMonths(2) : start.AddMonths(3); // Mes que empieza el servicio
                if (request.Month % 2 == 1) request = request.AddMonths(1); // el mes del date time picker 
                return true;
            }
            else if (serviceType == "Industrial")
            {
                start = start.AddMonths(1); // mes que empieza el servicio
                return true;
            }
            else
            {
                return false;
            }
        }
        public static int FindBimester(DateTime date)
        {
            return (date.Month - 1) / 2 + 1;
        }

        public static DateTime ToDateTime(LocalDate date)
        {
            return new DateTime(date.Year, date.Month, date.Day);
        }

        public static LocalDate ToLocalDate(DateTime date)
        {
            return new LocalDate(date.Year, date.Month, date.Day);
        }

        public static int ClampDay(int year, int month, int day)
        {
            int[] daysOfMonths = new int[12] { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
            if (year % 4 == 0 && year % 100 != 0 || year % 400 == 0)
            {
                daysOfMonths[1] = 29;
            }
            return Clamp(day, 1, daysOfMonths[month - 1]);
        }

        public static T Clamp<T>(T val, T min, T max) where T : IComparable<T>
        {
            if (val.CompareTo(min) < 0) return min;
            else if (val.CompareTo(max) > 0) return max;
            else return val;
        }
    }
}
