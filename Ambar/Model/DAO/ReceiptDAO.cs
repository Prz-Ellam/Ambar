using Ambar.Model.DTO;
using Cassandra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambar.Model.DAO
{
    class ReceiptDAO : CassandraConnection
    {
        public void GenerateReceipts(int positionCode, short month, int year)
        {


        }

        public void GenerateMassiveReceipts(List<ReceiptDTO> receipts)
        {
            string query1 = "INSERT INTO RECEIPT(RECEIPT_ID, FIRST_NAME, FATHER_LAST_NAME, MOTHER_LAST_NAME, STATE, CITY, " +
                "SUBURB, STREET, NUMBER, POSTAL_CODE, SERVICE, METER_SERIAL_NUMBER, SERVICE_NUMBER, YEAR, MONTH, " +
	            "BASIC_LEVEL, INTERMEDIATE_LEVEL, SURPLUS_LEVEL, BASIC_KW, INTERMEDIATE_KW, SURPLUS_KW, TOTAL_KW, " +
	            "BASIC_PRICE, INTERMEDIATE_PRICE, SURPLUS_PRICE, SUBTOTAL_PRICE, TAX, TOTAL_PRICE, AMOUNT_PAD, PENDING_AMOUNT) " +
                "VALUES(?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?); ";
            string query2 = "INSERT INTO RECEIPT_BY_METER_SERIAL_NUMBER(RECEIPT_ID, FIRST_NAME, FATHER_LAST_NAME, MOTHER_LAST_NAME, STATE, CITY, " +
               "SUBURB, STREET, NUMBER, POSTAL_CODE, SERVICE, METER_SERIAL_NUMBER, SERVICE_NUMBER, YEAR, MONTH, " +
               "BASIC_LEVEL, INTERMEDIATE_LEVEL, SURPLUS_LEVEL, BASIC_KW, INTERMEDIATE_KW, SURPLUS_KW, TOTAL_KW, " +
               "BASIC_PRICE, INTERMEDIATE_PRICE, SURPLUS_PRICE, SUBTOTAL_PRICE, TAX, TOTAL_PRICE, AMOUNT_PAD, PENDING_AMOUNT) " +
               "VALUES(?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?); ";
            string query3 = "INSERT INTO RECEIPT_BY_SERVICE_NUMBER(RECEIPT_ID, FIRST_NAME, FATHER_LAST_NAME, MOTHER_LAST_NAME, STATE, CITY, " +
               "SUBURB, STREET, NUMBER, POSTAL_CODE, SERVICE, METER_SERIAL_NUMBER, SERVICE_NUMBER, YEAR, MONTH, " +
               "BASIC_LEVEL, INTERMEDIATE_LEVEL, SURPLUS_LEVEL, BASIC_KW, INTERMEDIATE_KW, SURPLUS_KW, TOTAL_KW, " +
               "BASIC_PRICE, INTERMEDIATE_PRICE, SURPLUS_PRICE, SUBTOTAL_PRICE, TAX, TOTAL_PRICE, AMOUNT_PAD, PENDING_AMOUNT) " +
               "VALUES(?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?); ";
            string query4 = "INSERT INTO RECEIPT_BY_YEAR(RECEIPT_ID, FIRST_NAME, FATHER_LAST_NAME, MOTHER_LAST_NAME, STATE, CITY, " +
              "SUBURB, STREET, NUMBER, POSTAL_CODE, SERVICE, METER_SERIAL_NUMBER, SERVICE_NUMBER, YEAR, MONTH, " +
              "BASIC_LEVEL, INTERMEDIATE_LEVEL, SURPLUS_LEVEL, BASIC_KW, INTERMEDIATE_KW, SURPLUS_KW, TOTAL_KW, " +
              "BASIC_PRICE, INTERMEDIATE_PRICE, SURPLUS_PRICE, SUBTOTAL_PRICE, TAX, TOTAL_PRICE, AMOUNT_PAD, PENDING_AMOUNT) " +
              "VALUES(?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?); ";

            foreach (var receipt in receipts)
            {
                var res1 = session.Prepare(query1);
                var res2 = session.Prepare(query2);
                var res3 = session.Prepare(query3);
                var res4 = session.Prepare(query4);
                Guid id = Guid.NewGuid();

                var batch = new BatchStatement()
                    .Add(res1.Bind(id, receipt.First_Name, receipt.Father_Last_Name, receipt.Mother_Last_Name, receipt.State,
                    receipt.City, receipt.Suburb, receipt.Street, receipt.Number, receipt.Postal_Code, receipt.Service, 
                    receipt.Meter_Serial_Number, receipt.Service_Number, receipt.Year, receipt.Month, receipt.Basic_Level,
                    receipt.Intermediate_Level, receipt.Surplus_Level, receipt.Basic_KW, receipt.Intermediate_KW,
                    receipt.Surplus_KW, receipt.Total_KW, receipt.Basic_Price, receipt.Intermediate_Price, receipt.Surplus_Price, 
                    receipt.Subtotal_Price, receipt.Tax, receipt.Total_Price, receipt.Amount_Pad, receipt.Pending_Amount))
                    .Add(res2.Bind(id, receipt.First_Name, receipt.Father_Last_Name, receipt.Mother_Last_Name, receipt.State,
                    receipt.City, receipt.Suburb, receipt.Street, receipt.Number, receipt.Postal_Code, receipt.Service,
                    receipt.Meter_Serial_Number, receipt.Service_Number, receipt.Year, receipt.Month, receipt.Basic_Level,
                    receipt.Intermediate_Level, receipt.Surplus_Level, receipt.Basic_KW, receipt.Intermediate_KW,
                    receipt.Surplus_KW, receipt.Total_KW, receipt.Basic_Price, receipt.Intermediate_Price, receipt.Surplus_Price,
                    receipt.Subtotal_Price, receipt.Tax, receipt.Total_Price, receipt.Amount_Pad, receipt.Pending_Amount))
                    .Add(res3.Bind(id, receipt.First_Name, receipt.Father_Last_Name, receipt.Mother_Last_Name, receipt.State,
                    receipt.City, receipt.Suburb, receipt.Street, receipt.Number, receipt.Postal_Code, receipt.Service,
                    receipt.Meter_Serial_Number, receipt.Service_Number, receipt.Year, receipt.Month, receipt.Basic_Level,
                    receipt.Intermediate_Level, receipt.Surplus_Level, receipt.Basic_KW, receipt.Intermediate_KW,
                    receipt.Surplus_KW, receipt.Total_KW, receipt.Basic_Price, receipt.Intermediate_Price, receipt.Surplus_Price,
                    receipt.Subtotal_Price, receipt.Tax, receipt.Total_Price, receipt.Amount_Pad, receipt.Pending_Amount))
                    .Add(res4.Bind(id, receipt.First_Name, receipt.Father_Last_Name, receipt.Mother_Last_Name, receipt.State,
                    receipt.City, receipt.Suburb, receipt.Street, receipt.Number, receipt.Postal_Code, receipt.Service,
                    receipt.Meter_Serial_Number, receipt.Service_Number, receipt.Year, receipt.Month, receipt.Basic_Level,
                    receipt.Intermediate_Level, receipt.Surplus_Level, receipt.Basic_KW, receipt.Intermediate_KW,
                    receipt.Surplus_KW, receipt.Total_KW, receipt.Basic_Price, receipt.Intermediate_Price, receipt.Surplus_Price,
                    receipt.Subtotal_Price, receipt.Tax, receipt.Total_Price, receipt.Amount_Pad, receipt.Pending_Amount));

                session.Execute(batch);

            }


        }

        public ReceiptDTO FindReceipt(int year, short month, string meterSerialNumber)
        {
            string query = "SELECT RECEIPT_ID, FIRST_NAME, FATHER_LAST_NAME, MOTHER_LAST_NAME, STATE, CITY, " + 
            "SUBURB, STREET, NUMBER, POSTAL_CODE, SERVICE, METER_SERIAL_NUMBER, SERVICE_NUMBER, YEAR, MONTH, DAY, " +
            "BASIC_LEVEL, INTERMEDIATE_LEVEL, SURPLUS_LEVEL, BASIC_KW, INTERMEDIATE_KW, SURPLUS_KW, TOTAL_KW, " +
            "BASIC_PRICE, INTERMEDIATE_PRICE, SURPLUS_PRICE, SUBTOTAL_PRICE, TAX, TOTAL_PRICE, AMOUNT_PAD, PENDING_AMOUNT, " +
            "IS_PAID, PAYMENT_HISTORY, PAYMENT_TYPE_HISTORY " +
            "FROM RECEIPT_BY_METER_SERIAL_NUMBER WHERE METER_SERIAL_NUMBER = '{0}' AND YEAR = {1} " +
                "AND MONTH = {2};";
            query = string.Format(query, meterSerialNumber, year, month);
            ReceiptDTO dto;

            try
            {
                dto = mapper.Single<ReceiptDTO>(query);
            }
            catch (Exception e)
            {
                return null;
            }

            return dto;
        }

        public ReceiptDTO FindReceipt(int year, short month, int serviceNumber)
        {
            string query = "SELECT * FROM RECEIPT_BY_SERVICE_NUMBER WHERE METER_SERIAL_NUMBER = '{0}' AND YEAR = {1} " +
                "AND MONTH = {2};";
            query = string.Format(query, serviceNumber, year, month);
            ReceiptDTO dto;

            try
            {
                dto = mapper.Single<ReceiptDTO>(query);
            }
            catch (Exception e)
            {
                return null;
            }

            return dto;
        }

        public List<ReceiptDTO> HistoricConsumption(int year, string meterSerialNumber)
        {
            string query = "SELECT YEAR, MONTH, SERVICE, TOTAL_KW, TOTAL_PRICE, AMOUNT_PAID, PENDING_AMOUNT" +
                " FROM RECEIPT_BY_METER_SERIAL_NUMBER WHERE METER_SERIAL_NUMBER = '{0}' AND YEAR = {1};";
            return null;
        }

        public List<ReceiptDTO> HistoricConsumption(int year, int serviceNumber)
        {
            string query = "SELECT YEAR, MONTH, SERVICE, TOTAL_KW, TOTAL_PRICE, AMOUNT_PAID, PENDING_AMOUNT" +
                " FROM RECEIPT_BY_SERVICE_NUMBER WHERE SERVICE_NUMBER = {0} AND YEAR = {1};";
            return null;
        }

        public void PaidReceipt(decimal mount, decimal total, decimal paid, decimal pending)
        {
            decimal newPaid = paid + mount;
            decimal newPending = pending - mount;

            int a = 5;
            a = 3;
        }


    }
}
