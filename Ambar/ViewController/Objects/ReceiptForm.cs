using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambar.ViewController.Objects
{
    class ReceiptForm
    {
        string serviceType;
        int year;
        int period;

        public string ServiceType { get => serviceType; set => serviceType = value; }
        public int Period { get => period; set => period = value; }
        public int Year { get => year; set => year = value; }
    }
}
