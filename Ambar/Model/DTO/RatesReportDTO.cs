using Ambar.Model.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambar.ViewController
{
    class RatesReportDTO
    {
        [CsvHelper.Configuration.Attributes.Name("Anio")]
        private int year;
        [CsvHelper.Configuration.Attributes.Name("Mes")]
        private int month;
        [CsvHelper.Configuration.Attributes.Name("Tarifa Basica")]
        private decimal basic_level;
        [CsvHelper.Configuration.Attributes.Name("Tarifa Intermedia")]
        private decimal intermediate_level;
        [CsvHelper.Configuration.Attributes.Name("Tarifa Excedente")]
        private decimal surplus_level;

        [CsvHelper.Configuration.Attributes.Name("Anio")]
        public int Year { get => year; set => year = value; }
        [CsvHelper.Configuration.Attributes.Name("Mes")]
        public int Month { get => month; set => month = value; }
        [CsvHelper.Configuration.Attributes.Name("Tarifa Basica")]
        public decimal Basic_Level { get => basic_level; set => basic_level = value; }
        [CsvHelper.Configuration.Attributes.Name("Tarifa Intermedia")]
        public decimal Intermediate_Level { get => intermediate_level; set => intermediate_level = value; }
        [CsvHelper.Configuration.Attributes.Name("Tarifa Excedente")]
        public decimal Surplus_Level { get => surplus_level; set => surplus_level = value; }

    }
}
