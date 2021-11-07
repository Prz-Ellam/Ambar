using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambar.Model.DTO
{
    class PaymentDTO
    {
        public string meter_serial_number;
        public string payment_type;
        public decimal paid;
        public decimal amount_paid;
        public decimal pending_amount;
        public ReceiptDTO receipt_dto;
    }
}
