using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambar.ViewController.Objects
{
    class ConsumptionForm
    {
        Guid id;
        Guid contractID;
        string meterSerialNumber;
        string serviceNumber;
        string serviceType;
        decimal kilowatts;
        public DateTime period;
        public DateTime contractStartPeriod;

        public Guid ID { get => id; set => id = value; }
        public string MeterSerialNumber { get => meterSerialNumber; set => meterSerialNumber = value; }
        public string ServiceNumber { get => serviceNumber; set => serviceNumber = value; }
        public decimal Kilowatts { get => kilowatts; set => kilowatts = value; }
        public DateTime Period { get => period; set => period = value; }
        public string ServiceType { get => serviceType; set => serviceType = value; }
        public DateTime ContractStartPeriod { get => contractStartPeriod; set => contractStartPeriod = value; }
        public Guid ContractID { get => contractID; set => contractID = value; }
    }
}
