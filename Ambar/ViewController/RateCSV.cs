using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambar.ViewController
{
    class RateCSV
    {
        [CsvHelper.Configuration.Attributes.Name("Tarifa Basica")]
        public string Basica { get; set; }
        [CsvHelper.Configuration.Attributes.Name("Tarifa Intermedia")]
        public string Intermedia { get; set; }
        [CsvHelper.Configuration.Attributes.Name("Tarifa Excedente")]
        public string Excedente { get; set; }
        [CsvHelper.Configuration.Attributes.Name("Mes")]
        public string Mes { get; set; }
        [CsvHelper.Configuration.Attributes.Name("Anio")]
        public string Anio { get; set; }
        [CsvHelper.Configuration.Attributes.Name("Servicio")]
        public string Servicio { get; set; }
    }
}
