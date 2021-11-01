using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambar.Model.DTO
{
    class ReceiptDTO
    {
		Guid receipt_id;
		string first_name;
		string father_last_name;
		string mother_last_name;
		string state;
		string city;
		string suburb;
		string street;
		string number;
		string postal_code;
		string meter_serial_number;
		long service_number;
        string service;
		int year;
		short month;
        short day;
        decimal basic_level;
        decimal intermediate_level;
        decimal surplus_level;
        decimal basic_kw;
        decimal intermediate_kw;
        decimal surplus_kw;
        decimal total_kw;
		decimal basic_price;
		decimal intermediate_price;
		decimal surplus_price;
		decimal subtotal_price;
		decimal tax;
        decimal total_price;
        decimal amount_pad;
		decimal pending_amount;
        //IDictionary<string, decimal> payment_history;

        public Guid Receipt_ID { get => receipt_id; set => receipt_id = value; }
        public string First_Name { get => first_name; set => first_name = value; }
        public string Father_Last_Name { get => father_last_name; set => father_last_name = value; }
        public string Mother_Last_Name { get => mother_last_name; set => mother_last_name = value; }
        public string State { get => state; set => state = value; }
        public string City { get => city; set => city = value; }
        public string Suburb { get => suburb; set => suburb = value; }
        public string Street { get => street; set => street = value; }
        public string Number { get => number; set => number = value; }
        public string Postal_Code { get => postal_code; set => postal_code = value; }
        public string Meter_Serial_Number { get => meter_serial_number; set => meter_serial_number = value; }
        public long Service_Number { get => service_number; set => service_number = value; }
        public int Year { get => year; set => year = value; }
        public short Month { get => month; set => month = value; }
        public decimal Total_Price { get => total_price; set => total_price = value; }
        public decimal Basic_Price { get => basic_price; set => basic_price = value; }
        public decimal Intermediate_Price { get => intermediate_price; set => intermediate_price = value; }
        public decimal Surplus_Price { get => surplus_price; set => surplus_price = value; }
        public decimal Basic_Level { get => basic_level; set => basic_level = value; }
        public decimal Intermediate_Level { get => intermediate_level; set => intermediate_level = value; }
        public decimal Surplus_Level { get => surplus_level; set => surplus_level = value; }
        public decimal Subtotal_Price { get => subtotal_price; set => subtotal_price = value; }
        public decimal Tax { get => tax; set => tax = value; }
        public decimal Amount_Pad { get => amount_pad; set => amount_pad = value; }
        public decimal Pending_Amount { get => pending_amount; set => pending_amount = value; }
        public decimal Basic_KW { get => basic_kw; set => basic_kw = value; }
        public decimal Intermediate_KW { get => intermediate_kw; set => intermediate_kw = value; }
        public decimal Surplus_KW { get => surplus_kw; set => surplus_kw = value; }
        public string Service { get => service; set => service = value; }
       // public IDictionary<string, decimal> Payment_History { get => payment_history; set => payment_history = value; }
        public decimal Total_KW { get => total_kw; set => total_kw = value; }
        public short Day { get => day; set => day = value; }
    }
}
