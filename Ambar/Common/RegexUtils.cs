using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Ambar.Common
{
    class RegexUtils
    {
        public static bool VerifyCURP(string curp)
        {
            string res = @"^([A-Z][AEIOUX][A-Z]{2}\d{2}(?:0[1-9]|1[0-2])(?:0[1-9]|[12]\d|3[01])[HM](?:AS|B[CS]|C[CLMSH]|D[FG]|G[TR]|HG|JC|M[CNS]|N[ETL]|OC|PL|Q[TR]|S[PLR]|T[CSL]|VZ|YN|ZS)[B-DF-HJ-NP-TV-Z]{3}[A-Z\d])(\d)$";
            Regex rx = new Regex(res, RegexOptions.Compiled | RegexOptions.IgnoreCase);
            return rx.IsMatch(curp);
        }

        public static bool VerifyRFC(string rfc)
        {
            string res = @"^([A-ZÑ&]{3,4}) ?(?:- ?)?(\d{2}(?:0[1-9]|1[0-2])(?:0[1-9]|[12]\d|3[01])) ?(?:- ?)?([A-Z\d]{2})([A\d])$";
            Regex rx = new Regex(res, RegexOptions.Compiled | RegexOptions.IgnoreCase);
            return rx.IsMatch(rfc);
        }

        public static bool OnlyNumbers(string curp)
        {
            string res = @"^[0-9]+$";
            Regex rx = new Regex(res, RegexOptions.Compiled | RegexOptions.IgnoreCase);
            return rx.IsMatch(curp);
        }

        public static bool IsDecimalNumber(string number)
        {
            string res = @"(?<=^| )\d+(\.\d+)?(?=$| )|(?<=^| )\.\d+(?=$| )";
            Regex rx = new Regex(res, RegexOptions.Compiled | RegexOptions.IgnoreCase);
            return rx.IsMatch(number);
        }

        public static bool IsMonthNumber(string number)
        {
            string res = "^(0?[1-9]|1[012])$"; // 1-12
            Regex rx = new Regex(res, RegexOptions.Compiled | RegexOptions.IgnoreCase);
            return rx.IsMatch(number);
        }

        public static bool IsYearNumber(string number)
        {
            string res = @"^(19|20)\d{2}$"; // 1900-2099
            Regex rx = new Regex(res, RegexOptions.Compiled | RegexOptions.IgnoreCase);
            return rx.IsMatch(number);
        }

        public static bool VerifyEmail(string emails)
        {
            string res = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            Regex rx = new Regex(res, RegexOptions.Compiled | RegexOptions.IgnoreCase);
            return rx.IsMatch(emails);
        }
    }
}
