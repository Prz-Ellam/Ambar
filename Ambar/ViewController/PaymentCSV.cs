using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambar.ViewController
{
    class PaymentCSV
    {
        [CsvHelper.Configuration.Attributes.Name("Numero de Medidor")]
        public string Medidor { get; set; }
        [CsvHelper.Configuration.Attributes.Name("Metodo de Pago")]
        public string MetodoDePago { get; set; }
        [CsvHelper.Configuration.Attributes.Name("Pago")]
        public string Pago { get; set; }
        [CsvHelper.Configuration.Attributes.Name("Mes")]
        public string Mes { get; set; }
        [CsvHelper.Configuration.Attributes.Name("Anio")]
        public string Anio { get; set; }
    }
}
