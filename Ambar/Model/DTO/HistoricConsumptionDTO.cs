using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambar.Model.DTO
{
    class HistoricConsumptionDTO
    {
        int year;
        short month;
        decimal total_kw;
        decimal total_price;
        decimal amount_pad;
        decimal pending_amount;

        public int Year { get => year; set => year = value; }
        public short Month { get => month; set => month = value; }
        public decimal Total_KW { get => total_kw; set => total_kw = value; }
        public decimal Total_Price { get => total_price; set => total_price = value; }
        public decimal Amount_Pad { get => amount_pad; set => amount_pad = value; }
        public decimal Pending_Amount { get => pending_amount; set => pending_amount = value; }
    }
}
