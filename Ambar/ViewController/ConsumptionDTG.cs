using Ambar.Model.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambar.ViewController
{
    class ConsumptionDTG
    {
        Guid consumption_id;
        string meter_serial_number;
        Int64 service_number;
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

        public ConsumptionDTG(ConsumptionDTO dto)
        {
            consumption_id = dto.Consumption_ID;
            meter_serial_number = dto.Meter_Serial_Number;
            service_number = dto.Service_Number;
            basic_kw = dto.Basic_KW;
            intermediate_kw = dto.Intermediate_KW;
            surplus_kw = dto.Surplus_KW;
            total_kw = dto.Total_KW;
            year = dto.Year;
            month = dto.Month;
            day = dto.Day;
        }
    }
}
