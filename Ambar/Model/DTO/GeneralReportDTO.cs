using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambar.Model.DTO
{
    class GeneralReportDTO
    {
        int year;
        short month;
        string service;
        decimal amount_pad;
        decimal pending_amount;

        public int Year { get => year; set => year = value; }
        public short Month { get => month; set => month = value; }
        public string Service { get => service; set => service = value; }
        public decimal Amount_Pad { get => amount_pad; set => amount_pad = value; }
        public decimal Pending_Amount { get => pending_amount; set => pending_amount = value; }
    }
}
