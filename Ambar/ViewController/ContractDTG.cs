using Ambar.Model.DTO;
using Cassandra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambar.ViewController
{
    class ContractDTG
    {
        private Guid contract_id;
        private string meter_serial_number;
        private long service_number;
        private string state;
        private string city;
        private string suburb;
        private string street;
        private string number;
        private string postal_code;
        private string service;
        private LocalDate start_period_date;

        public Guid Contract_ID { get => contract_id; set => contract_id = value; }
        public string Meter_Serial_Number { get => meter_serial_number; set => meter_serial_number = value; }
        public long Service_Number { get => service_number; set => service_number = value; }
        public string State { get => state; set => state = value; }
        public string City { get => city; set => city = value; }
        public string Suburb { get => suburb; set => suburb = value; }
        public string Street { get => street; set => street = value; }
        public string Number { get => number; set => number = value; }
        public string Postal_Code { get => postal_code; set => postal_code = value; }
        public string Service { get => service; set => service = value; }
        public LocalDate Start_Period_Date { get => start_period_date; set => start_period_date = value; }

        public ContractDTG(ContractDTO dto)
        {
            contract_id = dto.Contract_ID;
            meter_serial_number = dto.Meter_Serial_Number;
            service_number = dto.Service_Number;
            state = dto.State;
            city = dto.City;
            suburb = dto.Suburb;
            street = dto.Street;
            number = dto.Number;
            postal_code = dto.Postal_Code;
            service = dto.Service;
            start_period_date = dto.Start_Period_Date;
        }
    }
}
