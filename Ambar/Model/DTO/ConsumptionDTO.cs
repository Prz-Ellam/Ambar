using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambar.Model.DTO
{
    class ConsumptionDTO
    {
        Guid consumption_id;
        Guid contract_id;
        string meter_serial_number;
        long service_number;
        decimal basic_kw;
        decimal intermediate_kw;
        decimal surplus_kw;
        decimal total_kw;
        int year;
        int month;
        int day;

        public Guid Consumption_ID { get => consumption_id; set => consumption_id = value; }
        public string Meter_Serial_Number { get => meter_serial_number; set => meter_serial_number = value; }
        public long Service_Number { get => service_number; set => service_number = value; }
        public decimal Basic_KW { get => basic_kw; set => basic_kw = value; }
        public decimal Intermediate_KW { get => intermediate_kw; set => intermediate_kw = value; }
        public decimal Surplus_KW { get => surplus_kw; set => surplus_kw = value; }
        public decimal Total_KW { get => total_kw; set => total_kw = value; }
        public int Year { get => year; set => year = value; }
        public int Month { get => month; set => month = value; }
        public int Day { get => day; set => day = value; }
        public Guid Contract_ID { get => contract_id; set => contract_id = value; }
    }
}
