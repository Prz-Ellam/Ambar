using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambar.ViewController.Objects
{
    class RateForm
    {
        private Guid id;
        private string serviceType;
        private int year;
        private int month;
        private decimal basicLevel;
        private decimal intermediateLevel;
        private decimal surplusLevel;

        public string ServiceType { get => serviceType; set => serviceType = value; }
        public decimal BasicLevel { get => basicLevel; set => basicLevel = value; }
        public decimal IntermediateLevel { get => intermediateLevel; set => intermediateLevel = value; }
        public decimal SurplusLevel { get => surplusLevel; set => surplusLevel = value; }
        public Guid ID { get => id; set => id = value; }
        public int Year { get => year; set => year = value; }
        public int Month { get => month; set => month = value; }
    }
}
