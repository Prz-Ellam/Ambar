using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambar.Model.DTO
{
    class ContractForReceiptDTO
    {
        string first_name;
        string father_last_name;
        string mother_last_name;
        string state;
        string city;
        string suburb;
        string street;
        string number;
        string postal_code;
        string service;
        string meter_serial_number;
        int service_number;

        public string First_Name { get => first_name; set => first_name = value; }
        public string Father_Last_Name { get => father_last_name; set => father_last_name = value; }
        public string Mother_Last_Name { get => mother_last_name; set => mother_last_name = value; }
        public string State { get => state; set => state = value; }
        public string City { get => city; set => city = value; }
        public string Suburb { get => suburb; set => suburb = value; }
        public string Street { get => street; set => street = value; }
        public string Number { get => number; set => number = value; }
        public string Postal_Code { get => postal_code; set => postal_code = value; }
        public string Service { get => service; set => service = value; }
        public string Meter_Serial_Number { get => meter_serial_number; set => meter_serial_number = value; }
        public int Service_Number { get => service_number; set => service_number = value; }
    }
}
