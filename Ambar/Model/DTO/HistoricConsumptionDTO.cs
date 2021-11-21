using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambar.Model.DTO
{
    class HistoricConsumptionDTO
    {
        [CsvHelper.Configuration.Attributes.Name("Año")]
        int year;
        [CsvHelper.Configuration.Attributes.Name("Mes")]
        int month;
        [CsvHelper.Configuration.Attributes.Name("Consumo de kW")]
        decimal total_kw;
        [CsvHelper.Configuration.Attributes.Name("Importe")]
        decimal total_price;
        [CsvHelper.Configuration.Attributes.Name("Pago")]
        decimal amount_paid;
        [CsvHelper.Configuration.Attributes.Name("Pendiente de Pago")]
        decimal pending_amount;

        [CsvHelper.Configuration.Attributes.Name("Año")]
        public int Year { get => year; set => year = value; }
        [CsvHelper.Configuration.Attributes.Name("Mes")]
        public int Month { get => month; set => month = value; }
        [CsvHelper.Configuration.Attributes.Name("Consumo de kW")]
        public decimal Total_KW { get => total_kw; set => total_kw = value; }
        [CsvHelper.Configuration.Attributes.Name("Importe")]
        public decimal Total_Price { get => total_price; set => total_price = value; }
        [CsvHelper.Configuration.Attributes.Name("Pago")]
        public decimal Amount_Paid { get => amount_paid; set => amount_paid = value; }
        [CsvHelper.Configuration.Attributes.Name("Pendiente de Pago")]
        public decimal Pending_Amount { get => pending_amount; set => pending_amount = value; }
    }
}
