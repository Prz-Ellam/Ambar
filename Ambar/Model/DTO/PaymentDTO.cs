using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambar.Model.DTO
{
    class PaymentDTO
    {
        private string meter_serial_number;
        private string payment_type;
        private decimal paid;
        private decimal amount_paid;
        private decimal pending_amount;
        private ReceiptDTO receipt_dto;

        public string Meter_Serial_Number { get => meter_serial_number; set => meter_serial_number = value; }
        public string Payment_Type { get => payment_type; set => payment_type = value; }
        public decimal Paid { get => paid; set => paid = value; }
        public decimal Amount_Paid { get => amount_paid; set => amount_paid = value; }
        public decimal Pending_Amount { get => pending_amount; set => pending_amount = value; }
        internal ReceiptDTO Receipt_DTO { get => receipt_dto; set => receipt_dto = value; }
    }
}
