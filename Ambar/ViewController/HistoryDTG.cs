using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambar.ViewController
{
    class HistoryDTG
    {
        private string paymentType;
        private decimal mount;

        public string PaymentType { get => paymentType; set => paymentType = value; }
        public decimal Mount { get => mount; set => mount = value; }

        public HistoryDTG(string paymentType, decimal mount)
        {
            this.paymentType = paymentType;
            this.mount = mount;
        }
    }
}
