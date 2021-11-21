using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambar.Common
{
    class NumericUtils
    {
        public static string GetNumberString(decimal number)
        {
            string numStr;
            number = Math.Truncate(number);

            if (number == 0) numStr = "CERO";
            else if (number == 1) numStr = "UN";
            else if (number == 2) numStr = "DOS";
            else if (number == 3) numStr = "TRES";
            else if (number == 4) numStr = "CUATRO";
            else if (number == 5) numStr = "CINCO";
            else if (number == 6) numStr = "SEIS";
            else if (number == 7) numStr = "SIETE";
            else if (number == 8) numStr = "OCHO";
            else if (number == 9) numStr = "NUEVE";
            else if (number == 10) numStr = "DIEZ";
            else if (number == 11) numStr = "ONCE";
            else if (number == 12) numStr = "DOCE";
            else if (number == 13) numStr = "TRECE";
            else if (number == 14) numStr = "CATORCE";
            else if (number == 15) numStr = "QUINCE";
            else if (number < 20) numStr = "DIECI" + GetNumberString(number - 10);
            else if (number == 20) numStr = "VEINTE";
            else if (number < 30) numStr = "VEINTI" + GetNumberString(number - 20);
            else if (number == 30) numStr = "TREINTA";
            else if (number == 40) numStr = "CUARENTA";
            else if (number == 50) numStr = "CINCUENTA";
            else if (number == 60) numStr = "SESENTA";
            else if (number == 70) numStr = "SETENTA";
            else if (number == 80) numStr = "OCHENTA";
            else if (number == 90) numStr = "NOVENTA";
            else if (number < 100) numStr = GetNumberString(Math.Truncate(number / 10) * 10) + " Y " + GetNumberString(number % 10);
            else if (number == 100) numStr = "CIEN";
            else if (number < 200) numStr = "CIENTO " + GetNumberString(number - 100);
            else if ((number == 200) || (number == 300) || (number == 400) || (number == 600) || (number == 800)) numStr = GetNumberString(Math.Truncate(number / 100)) + "CIENTOS";
            else if (number == 500) numStr = "QUINIENTOS";
            else if (number == 700) numStr = "SETECIENTOS";
            else if (number == 900) numStr = "NOVECIENTOS";
            else if (number < 1000) numStr = GetNumberString(Math.Truncate(number / 100) * 100) + " " + GetNumberString(number % 100);
            else if (number == 1000) numStr = "MIL";
            else if (number < 2000) numStr = "MIL " + GetNumberString(number % 1000);
            else if (number < 1000000)
            {
                numStr = GetNumberString(Math.Truncate(number / 1000)) + " MIL";
                if ((number % 1000) > 0)
                {
                    numStr = numStr + " " + GetNumberString(number % 1000);
                }
            }
            else if (number == 1000000)
            {
                numStr = "UN MILLON";
            }
            else if (number < 2000000)
            {
                numStr = "UN MILLON " + GetNumberString(number % 1000000);
            }
            else if (number < 1000000000000)
            {
                numStr = GetNumberString(Math.Truncate(number / 1000000)) + " MILLONES ";
                if ((number - Math.Truncate(number / 1000000) * 1000000) > 0)
                {
                    numStr = numStr + " " + GetNumberString(number - Math.Truncate(number / 1000000) * 1000000);
                }
            }
            else if (number == 1000000000000) numStr = "UN BILLON";
            else if (number < 2000000000000) numStr = "UN BILLON " + GetNumberString(number - Math.Truncate(number / 1000000000000) * 1000000000000);
            else
            {
                numStr = GetNumberString(Math.Truncate((number / 1000000000000))) + " BILLONES";
                if ((number - Math.Truncate(number / 1000000000000) * 1000000000000) > 0)
                {
                    numStr = numStr + " " + GetNumberString(number - Math.Truncate(number / 1000000000000) * 1000000000000);
                }
            }
            return numStr;
        }
/*
        public static string GetNumberString(int number)
        {
            string numberStr = "";

            if (number == 0)
            {
                numberStr = "CERO";
            }
            if (number > 0 && number < 10000)
            {
                if (number >= 1000)
                {
                    Thousand(ref number, ref numberStr);
                }
                if (number >= 100)
                {
                    Hundred(ref number, ref numberStr);
                }
                if (number >= 10)
                {
                    Teens(ref number, ref numberStr);
                }
                if (number >= 1)
                {
                    Ones(ref number, ref numberStr);
                }
            }
            else
            {
                // No es un numero valido
                return null;
            }

            return numberStr;

        }

        public static void DecTeens(ref int number, ref string numberStr)
        {
            if (number >= 90000)
            {
                numberStr += "NOVENTA";
                number -= 90000;
            }
            else if (number >= 80000)
            {
                numberStr += "OCHENTA MIL";
                number -= 80000;
            }
            else if (number >= 70000)
            {
                numberStr += "SETENTA";
                number -= 70;
            }
            else if (number >= 60000)
            {
                numberStr += "SESENTA";
                number -= 60;
            }
            else if (number >= 50000)
            {
                numberStr += "CINCUENTA";
                number -= 50;
            }
            else if (number >= 40000)
            {
                numberStr += "CUARENTA";
                number -= 40;
            }
            else if (number >= 30000)
            {
                numberStr += "TREINTA";
                number -= 30;
            }
            else if (number > 20000)
            {
                numberStr += "VEINTI";
                number -= 20;
                return;
            }
            else if (number == 20000)
            {
                numberStr += "VEINTE";
                number -= 20;
            }
            else if (number > 15000)
            {
                numberStr += "DIECI";
                number -= 10;
                return;
            }
            else if (number == 15000)
            {
                numberStr += "QUINCE";
                number -= 15;
            }
            else if (number == 14000)
            {
                numberStr += "CATORCE";
                number -= 14;
            }
            else if (number == 13000)
            {
                numberStr += "TRECE";
                number -= 13;
            }
            else if (number == 12000)
            {
                numberStr += "DOCE";
                number -= 12;
            }
            else if (number == 11000)
            {
                numberStr += "ONCE";
                number -= 11;
            }
            else if (number == 10000)
            {
                numberStr += "DIEZ";
                number -= 10;
            }

            if (number != 0)
            {
                numberStr += " Y ";
            }
        }

        public static void Thousand(ref int number, ref string numberStr)
        {
            if (number >= 9000)
            {
                numberStr += "NUEVE MIL";
                number -= 9000;
            }
            else if (number >= 8000)
            {
                numberStr += "OCHO MIL";
                number -= 8000;
            }
            else if (number >= 7000)
            {
                numberStr += "SIETE MIL";
                number -= 7000;
            }
            else if (number >= 6000)
            {
                numberStr += "SEIS MIL";
                number -= 6000;
            }
            else if (number >= 5000)
            {
                numberStr += "CINCO MIL";
                number -= 5000;
            }
            else if (number >= 4000)
            {
                numberStr += "CUATRO MIL";
                number -= 4000;
            }
            else if (number >= 3000)
            {
                numberStr += "TRES MIL";
                number -= 3000;
            }
            else if (number >= 2000)
            {
                numberStr += "DOS MIL";
                number -= 2000;
            }
            else if (number >= 1000)
            {
                numberStr += "MIL";
                number -= 1000;
            }

            if (number != 0)
            {
                numberStr += " ";
            }

        }

        public static void Hundred(ref int number, ref string numberStr)
        {
            if (number >= 900)
            {
                numberStr += "NOVECIENTOS ";
                number -= 900;
            }
            else if (number >= 800)
            {
                numberStr += "OCHOCIENTOS ";
                number -= 800;
            }
            else if (number >= 700)
            {
                numberStr += "SETECIENTOS ";
                number -= 700;
            }
            else if (number >= 600)
            {
                numberStr += "SEISCIENTOS ";
                number -= 600;
            }
            else if (number >= 500)
            {
                numberStr += "QUINIENTOS ";
                number -= 500;
            }
            else if (number >= 400)
            {
                numberStr += "CUATROCIENTOS ";
                number -= 400;
            }
            else if (number >= 300)
            {
                numberStr += "TRESCIENTOS ";
                number -= 300;
            }
            else if (number >= 200)
            {
                numberStr += "DOSCIENTOS ";
                number -= 200;
            }
            else if (number > 100)
            {
                numberStr += "CIENTO ";
                number -= 100;
            }
            else if (number == 100)
            {
                numberStr += "CIEN";
                number -= 100;
            }
        }

        public static void Teens(ref int number, ref string numberStr)
        {
            if (number >= 90)
            {
                numberStr += "NOVENTA";
                number -= 90;
            }
            else if (number >= 80)
            {
                numberStr += "OCHENTA";
                number -= 80;
            }
            else if (number >= 70)
            {
                numberStr += "SETENTA";
                number -= 70;
            }
            else if (number >= 60)
            {
                numberStr += "SESENTA";
                number -= 60;
            }
            else if (number >= 50)
            {
                numberStr += "CINCUENTA";
                number -= 50;
            }
            else if (number >= 40)
            {
                numberStr += "CUARENTA";
                number -= 40;
            }
            else if (number >= 30)
            {
                numberStr += "TREINTA";
                number -= 30;
            }
            else if (number > 20)
            {
                numberStr += "VEINTI";
                number -= 20;
                return;
            }
            else if (number == 20)
            {
                numberStr += "VEINTE";
                number -= 20;
            }
            else if (number > 15)
            {
                numberStr += "DIECI";
                number -= 10;
                return;
            }
            else if (number == 15)
            {
                numberStr += "QUINCE";
                number -= 15;
            }
            else if (number == 14)
            {
                numberStr += "CATORCE";
                number -= 14;
            }
            else if (number == 13)
            {
                numberStr += "TRECE";
                number -= 13;
            }
            else if (number == 12)
            {
                numberStr += "DOCE";
                number -= 12;
            }
            else if (number == 11)
            {
                numberStr += "ONCE";
                number -= 11;
            }
            else if (number == 10)
            {
                numberStr += "DIEZ";
                number -= 10;
            }

            if (number != 0)
            {
                numberStr += " Y ";
            }
        }

        public static void Ones(ref int number, ref string numberStr)
        {
            switch (number)
            {
                case 9:
                    numberStr += "NUEVE";
                    number -= 9;
                    break;
                case 8:
                    numberStr += "OCHO";
                    number -= 8;
                    break;
                case 7:
                    numberStr += "SIETE";
                    number -= 7;
                    break;
                case 6:
                    numberStr += "SEIS";
                    number -= 6;
                    break;
                case 5:
                    numberStr += "CINCO";
                    number -= 5;
                    break;
                case 4:
                    numberStr += "CUATRO";
                    number -= 4;
                    break;
                case 3:
                    numberStr += "TRES";
                    number -= 3;
                    break;
                case 2:
                    numberStr += "DOS";
                    number -= 2;
                    break;
                case 1:
                    numberStr += "UN";
                    number -= 1;
                    break;
            }

        }
*/
        public static void PaymentBreakdown(decimal number, ref decimal kwBasic, ref decimal kwInt, ref decimal kwExc)
        {
            decimal basic = Convert.ToDecimal(ConfigurationManager.AppSettings["Basic_kW"].ToString());
            decimal intermediate = Convert.ToDecimal(ConfigurationManager.AppSettings["Intermediate_kW"].ToString());

            decimal offset = number - basic;

            if (offset <= 0)
            {
                kwBasic = number;
                return;
            }

            kwBasic = basic;
            offset -= intermediate;
            number -= basic;

            if (offset <= 0)
            {
                kwInt = number;
                return;
            }

            kwInt = intermediate;
            number -= intermediate;
            kwExc = number;
        }
    }
}
