using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambar.Model.DTO
{
    class ConsumptionForReceiptDTO
    {
        decimal basic_kw;
        decimal intermediate_kw;
        decimal surplus_kw;
        int year;
        short month;
        short day;

        public decimal Basic_KW { get => basic_kw; set => basic_kw = value; }
        public decimal Intermediate_KW { get => intermediate_kw; set => intermediate_kw = value; }
        public decimal Surplus_KW { get => surplus_kw; set => surplus_kw = value; }
        public int Year { get => year; set => year = value; }
        public short Month { get => month; set => month = value; }
        public short Day { get => day; set => day = value; }
    }
}
