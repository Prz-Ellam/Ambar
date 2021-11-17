using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambar.Model.DTO
{
    class PaymentDTO
    {
        private Guid receipt_id;
        private string meter_serial_number;
        private long service_number;
        private string service;
        private int year;
        private int month;
        private decimal mount;
        private decimal amount_paid;
        private decimal pending_amount;
        private string payment_type;

        public Guid Receipt_ID { get => receipt_id; set => receipt_id = value; }
        public string Meter_Serial_Number { get => meter_serial_number; set => meter_serial_number = value; }
        public long Service_Number { get => service_number; set => service_number = value; }
        public string Service { get => service; set => service = value; }
        public int Year { get => year; set => year = value; }
        public int Month { get => month; set => month = value; }
        public decimal Mount { get => mount; set => mount = value; }
        public decimal Amount_Paid { get => amount_paid; set => amount_paid = value; }
        public decimal Pending_Amount { get => pending_amount; set => pending_amount = value; }
        public string Payment_Type { get => payment_type; set => payment_type = value; }
    }
}
