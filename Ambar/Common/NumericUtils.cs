using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambar.Common
{
    class NumericUtils
    {
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
                    number -= 20;
                    break;
            }

        }
    }
}
