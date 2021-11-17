using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambar.Model.DTO
{
    class RateDTO
    {
        private Guid rate_id;
        private decimal basic_level;
        private decimal intermediate_level;
        private decimal surplus_level;
        private string service;
        private int year;
        private int month;

        public Guid Rate_ID { get => rate_id; set => rate_id = value; }
        public decimal Basic_Level { get => basic_level; set => basic_level = value; }
        public decimal Intermediate_Level { get => intermediate_level; set => intermediate_level = value; }
        public decimal Surplus_Level { get => surplus_level; set => surplus_level = value; }
        public string Service { get => service; set => service = value; }
        public int Year { get => year; set => year = value; }
        public int Month { get => month; set => month = value; }
    }
}
