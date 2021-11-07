using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambar.Model.DTO
{
    class GeneralReportDTO
    {
        [CsvHelper.Configuration.Attributes.Name("Año")]
        int year;
        [CsvHelper.Configuration.Attributes.Name("Mes")]
        short month;
        [CsvHelper.Configuration.Attributes.Name("Tipo de Servicio")]
        string service;
        [CsvHelper.Configuration.Attributes.Name("Total Pagado")]
        decimal amount_pad;
        [CsvHelper.Configuration.Attributes.Name("Total Pendiente de Pago")]
        decimal pending_amount;

        [CsvHelper.Configuration.Attributes.Name("Año")]
        public int Year { get => year; set => year = value; }
        [CsvHelper.Configuration.Attributes.Name("Mes")]
        public short Month { get => month; set => month = value; }
        [CsvHelper.Configuration.Attributes.Name("Tipo de Servicio")]
        public string Service { get => service; set => service = value; }
        [CsvHelper.Configuration.Attributes.Name("Total Pagado")]
        public decimal Amount_Pad { get => amount_pad; set => amount_pad = value; }
        [CsvHelper.Configuration.Attributes.Name("Total Pendiente de Pago")]
        public decimal Pending_Amount { get => pending_amount; set => pending_amount = value; }
    }
}
