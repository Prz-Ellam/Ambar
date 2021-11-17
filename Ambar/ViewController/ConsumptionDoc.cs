using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambar.ViewController
{
    class ConsumptionDoc
    {
        [CsvHelper.Configuration.Attributes.Name("Numero de Medidor")]
        public string Medidor { get; set; }
        [CsvHelper.Configuration.Attributes.Name("Kilowatts")]
        public string Kilowatts { get; set; }
        [CsvHelper.Configuration.Attributes.Name("Anio")]
        public string Anio { get; set; }
        [CsvHelper.Configuration.Attributes.Name("Mes")]
        public string Mes { get; set; }
    }
}
