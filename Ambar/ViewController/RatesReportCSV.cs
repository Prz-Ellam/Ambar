using Ambar.Model.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambar.ViewController
{
    class RatesReportCSV
    {
        private int year;
        private short month;
        private decimal basic_level;
        private decimal intermediate_level;
        private decimal surplus_level;

        [CsvHelper.Configuration.Attributes.Name("Año")]
        public int Year { get => year; set => year = value; }
        [CsvHelper.Configuration.Attributes.Name("Mes")]
        public short Month { get => month; set => month = value; }
        [CsvHelper.Configuration.Attributes.Name("Tárifa Básica")]
        public decimal Basic_Level { get => basic_level; set => basic_level = value; }
        [CsvHelper.Configuration.Attributes.Name("Tárifa Intermedia")]
        public decimal Intermediate_Level { get => intermediate_level; set => intermediate_level = value; }
        [CsvHelper.Configuration.Attributes.Name("Tárifa Exedente")]
        public decimal Surplus_Level { get => surplus_level; set => surplus_level = value; }

        public RatesReportCSV(RateDTO dto)
        {
            year = dto.Year;
            month = dto.Month;
            basic_level = dto.Basic_Level;
            intermediate_level = dto.Intermediate_Level;
            surplus_level = dto.Surplus_Level;
        }
    }
}
