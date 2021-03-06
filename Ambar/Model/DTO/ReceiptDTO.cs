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
        Guid contract_id;
		string first_name;
		string father_last_name;
		string mother_last_name;
		string state;
		string city;
		string suburb;
		string street;
		string number;
		string postal_code;
        string service;
        string meter_serial_number;
		long service_number;
		int year;
		int month;
        int day;
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
        decimal prev_price;
        decimal prev_amount;
        decimal total_price;
        decimal amount_paid;
		decimal pending_amount;
        IDictionary<DateTimeOffset, decimal> payment_history;
        IEnumerable<string> payment_type_history;
        bool is_paid;

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
        public int Month { get => month; set => month = value; }
        public int Day { get => day; set => day = value; }
        public decimal Total_Price { get => total_price; set => total_price = value; }
        public decimal Basic_Price { get => basic_price; set => basic_price = value; }
        public decimal Intermediate_Price { get => intermediate_price; set => intermediate_price = value; }
        public decimal Surplus_Price { get => surplus_price; set => surplus_price = value; }
        public decimal Basic_Level { get => basic_level; set => basic_level = value; }
        public decimal Intermediate_Level { get => intermediate_level; set => intermediate_level = value; }
        public decimal Surplus_Level { get => surplus_level; set => surplus_level = value; }
        public decimal Subtotal_Price { get => subtotal_price; set => subtotal_price = value; }
        public decimal Tax { get => tax; set => tax = value; }
        public decimal Amount_Paid { get => amount_paid; set => amount_paid = value; }
        public decimal Pending_Amount { get => pending_amount; set => pending_amount = value; }
        public decimal Basic_KW { get => basic_kw; set => basic_kw = value; }
        public decimal Intermediate_KW { get => intermediate_kw; set => intermediate_kw = value; }
        public decimal Surplus_KW { get => surplus_kw; set => surplus_kw = value; }
        public string Service { get => service; set => service = value; }
        public decimal Total_KW { get => total_kw; set => total_kw = value; }
        public bool Is_Paid { get => is_paid; set => is_paid = value; }
        public decimal Prev_Price { get => prev_price; set => prev_price = value; }
        public decimal Prev_Amount { get => prev_amount; set => prev_amount = value; }
        public Guid Contract_ID { get => contract_id; set => contract_id = value; }
        public IDictionary<DateTimeOffset, decimal> Payment_History { get => payment_history; set => payment_history = value; }
        public IEnumerable<string> Payment_Type_History { get => payment_type_history; set => payment_type_history = value; }
    }
}
