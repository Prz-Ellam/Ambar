using Ambar.Model.DTO;
using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambar.ViewController
{
    class ConsumptionsReportDTO
    {
        [CsvHelper.Configuration.Attributes.Name("Anio")]
        int year;
        [CsvHelper.Configuration.Attributes.Name("Mes")]
        short month;
        [CsvHelper.Configuration.Attributes.Name("Numero de Medidor")]
        string meter_serial_number;
        [CsvHelper.Configuration.Attributes.Name("Consumo de kW Basico")]
        decimal basic_kw;
        [CsvHelper.Configuration.Attributes.Name("Consumo de kW Intermedio")]
        decimal intermediate_kw;
        [CsvHelper.Configuration.Attributes.Name("Consumo de kW Excedente")]
        decimal surplus_kw;

        [CsvHelper.Configuration.Attributes.Name("Anio")]
        public int Year { get => year; set => year = value; }
        [CsvHelper.Configuration.Attributes.Name("Mes")]
        public short Month { get => month; set => month = value; }
        [CsvHelper.Configuration.Attributes.Name("Numero de Medidor")]
        public string Meter_Serial_Number { get => meter_serial_number; set => meter_serial_number = value; }
        [CsvHelper.Configuration.Attributes.Name("Consumo de kW Basico")]
        public decimal Basic_KW { get => basic_kw; set => basic_kw = value; }
        [CsvHelper.Configuration.Attributes.Name("Consumo de kW Intermedio")]
        public decimal Intermediate_KW { get => intermediate_kw; set => intermediate_kw = value; }
        [CsvHelper.Configuration.Attributes.Name("Consumo de kW Excedente")]
        public decimal Surplus_KW { get => surplus_kw; set => surplus_kw = value; }
    }
}
