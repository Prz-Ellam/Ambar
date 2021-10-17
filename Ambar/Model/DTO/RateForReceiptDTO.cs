using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambar.Model.DTO
{
    class RateForReceiptDTO
    {
        decimal basic_level;
        decimal intermediate_level;
        decimal surplus_level;

        public decimal Basic_Level { get => basic_level; set => basic_level = value; }
        public decimal Intermediate_Level { get => intermediate_level; set => intermediate_level = value; }
        public decimal Surplus_Level { get => surplus_level; set => surplus_level = value; }
    }
}
