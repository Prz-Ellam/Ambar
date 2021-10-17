using Ambar.Model.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambar.ViewController
{
    class ConsumptionsReportCSV
    {
        int year;
        short month;
        string meter_serial_number;
        decimal basic_kw;
        decimal intermediate_kw;
        decimal surplus_kw;

        public ConsumptionsReportCSV(ConsumptionDTO dto)
        {
            year = dto.Year;
            month = dto.Month;
            meter_serial_number = dto.Meter_Serial_Number;
            basic_kw = dto.Basic_KW;
            intermediate_kw = dto.Intermediate_KW;
            surplus_kw = dto.Surplus_KW;
        }

        public int Year { get => year; set => year = value; }
        public short Month { get => month; set => month = value; }
        public string Meter_Serial_Number { get => meter_serial_number; set => meter_serial_number = value; }
        public decimal Basic_KW { get => basic_kw; set => basic_kw = value; }
        public decimal Intermediate_KW { get => intermediate_kw; set => intermediate_kw = value; }
        public decimal Surplus_KW { get => surplus_kw; set => surplus_kw = value; }
    }
}
