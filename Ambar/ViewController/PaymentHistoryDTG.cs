using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambar.ViewController
{
    class PaymentHistoryDTG
    {
        DateTimeOffset payment_timestamp;
        decimal payment_mount;
        string payment_type;

        public DateTimeOffset Payment_Timestamp { get => payment_timestamp; set => payment_timestamp = value; }
        public decimal Payment_Mount { get => payment_mount; set => payment_mount = value; }
        public string Payment_Type { get => payment_type; set => payment_type = value; }
    }
}
