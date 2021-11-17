using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambar.ViewController.Objects
{
    class ContractForm
    {
        private Guid contractID;
        private Guid clientID;
        private string firstName;
        private string fatherLastName;
        private string motherLastName;
        private string meterSerialNumber;
        private string serviceNumber;
        private string state;
        private string city;
        private string suburb;
        private string street;
        private string number;
        private string postalCode;
        private string service;
        private DateTime startPeriodDate;

        public Guid ContractID { get => contractID; set => contractID = value; }
        public Guid ClientID { get => clientID; set => clientID = value; }
        public string FirstName { get => firstName; set => firstName = value; }
        public string FatherLastName { get => fatherLastName; set => fatherLastName = value; }
        public string MotherLastName { get => motherLastName; set => motherLastName = value; }
        public string MeterSerialNumber { get => meterSerialNumber; set => meterSerialNumber = value; }
        public string ServiceNumber { get => serviceNumber; set => serviceNumber = value; }
        public string State { get => state; set => state = value; }
        public string City { get => city; set => city = value; }
        public string Suburb { get => suburb; set => suburb = value; }
        public string Street { get => street; set => street = value; }
        public string Number { get => number; set => number = value; }
        public string PostalCode { get => postalCode; set => postalCode = value; }
        public string Service { get => service; set => service = value; }
        public DateTime StartPeriodDate { get => startPeriodDate; set => startPeriodDate = value; }
    }
}
