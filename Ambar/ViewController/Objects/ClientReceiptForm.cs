using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambar.ViewController.Objects
{
    class ClientReceiptForm
    {
        string meterSerialNumber;
        string serviceType;
        DateTime period;

        public string ServiceType { get => serviceType; set => serviceType = value; }
        public string MeterSerialNumber { get => meterSerialNumber; set => meterSerialNumber = value; }
        public DateTime Period { get => period; set => period = value; }
    }
}
