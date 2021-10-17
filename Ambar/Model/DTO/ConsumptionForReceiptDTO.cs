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

        public decimal Basic_KW { get => basic_kw; set => basic_kw = value; }
        public decimal Intermediate_KW { get => intermediate_kw; set => intermediate_kw = value; }
        public decimal Surplus_KW { get => surplus_kw; set => surplus_kw = value; }
    }
}
