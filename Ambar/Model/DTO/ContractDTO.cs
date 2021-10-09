using Cassandra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambar.Model.DTO
{
    class ContractDTO
    {
        private Guid contract_id;
        private string meter_serial_number;
        private int service_number;
        private string state;
        private string city;
        private string suburb;
        private string street;
        private string number;
        private string postal_code;
        private string service;
        private Guid client_id;
        private LocalDate start_period_date;
        private DateTimeOffset creation_date;

        public Guid Contract_ID { get => contract_id; set => contract_id = value; }
        public string Meter_Serial_Number { get => meter_serial_number; set => meter_serial_number = value; }
        public int Service_Number { get => service_number; set => service_number = value; }
        public string State { get => state; set => state = value; }
        public string City { get => city; set => city = value; }
        public string Suburb { get => suburb; set => suburb = value; }
        public string Street { get => street; set => street = value; }
        public string Number { get => number; set => number = value; }
        public string Postal_Code { get => postal_code; set => postal_code = value; }
        public string Service { get => service; set => service = value; }
        public Guid Client_ID { get => client_id; set => client_id = value; }
        public LocalDate Start_Period_Date { get => start_period_date; set => start_period_date = value; }
        public DateTimeOffset Creation_Date { get => creation_date; set => creation_date = value; }
    }
}
