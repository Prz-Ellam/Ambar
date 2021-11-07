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
            string queryID = @"INSERT INTO RECEIPT(RECEIPT_ID, FIRST_NAME, FATHER_LAST_NAME, MOTHER_LAST_NAME, STATE, CITY,
                SUBURB, STREET, NUMBER, POSTAL_CODE, SERVICE, METER_SERIAL_NUMBER, SERVICE_NUMBER, YEAR, MONTH, DAY,  
	            BASIC_LEVEL, INTERMEDIATE_LEVEL, SURPLUS_LEVEL, BASIC_KW, INTERMEDIATE_KW, SURPLUS_KW, TOTAL_KW, 
	            BASIC_PRICE, INTERMEDIATE_PRICE, SURPLUS_PRICE, SUBTOTAL_PRICE, TAX, PREV_AMOUNT, PREV_PRICE, TOTAL_PRICE, AMOUNT_PAD, PENDING_AMOUNT) 
                VALUES(?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?); ";
            string queryMeter = @"INSERT INTO RECEIPT_BY_METER_SERIAL_NUMBER(RECEIPT_ID, FIRST_NAME, FATHER_LAST_NAME, MOTHER_LAST_NAME, STATE, CITY,
                SUBURB, STREET, NUMBER, POSTAL_CODE, SERVICE, METER_SERIAL_NUMBER, SERVICE_NUMBER, YEAR, MONTH, DAY,  
	            BASIC_LEVEL, INTERMEDIATE_LEVEL, SURPLUS_LEVEL, BASIC_KW, INTERMEDIATE_KW, SURPLUS_KW, TOTAL_KW, 
	            BASIC_PRICE, INTERMEDIATE_PRICE, SURPLUS_PRICE, SUBTOTAL_PRICE, TAX, PREV_AMOUNT, PREV_PRICE, TOTAL_PRICE, AMOUNT_PAD, PENDING_AMOUNT) 
                VALUES(?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?); ";
            string queryService = @"INSERT INTO RECEIPT_BY_SERVICE_NUMBER(RECEIPT_ID, FIRST_NAME, FATHER_LAST_NAME, MOTHER_LAST_NAME, STATE, CITY,
                SUBURB, STREET, NUMBER, POSTAL_CODE, SERVICE, METER_SERIAL_NUMBER, SERVICE_NUMBER, YEAR, MONTH, DAY, 
	            BASIC_LEVEL, INTERMEDIATE_LEVEL, SURPLUS_LEVEL, BASIC_KW, INTERMEDIATE_KW, SURPLUS_KW, TOTAL_KW, 
	            BASIC_PRICE, INTERMEDIATE_PRICE, SURPLUS_PRICE, SUBTOTAL_PRICE, TAX, PREV_AMOUNT, PREV_PRICE, TOTAL_PRICE, AMOUNT_PAD, PENDING_AMOUNT) 
                VALUES(?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?); ";
            string queryYear = @"INSERT INTO RECEIPT_BY_YEAR(RECEIPT_ID, FIRST_NAME, FATHER_LAST_NAME, MOTHER_LAST_NAME, STATE, CITY,
                SUBURB, STREET, NUMBER, POSTAL_CODE, SERVICE, METER_SERIAL_NUMBER, SERVICE_NUMBER, YEAR, MONTH, DAY, 
	            BASIC_LEVEL, INTERMEDIATE_LEVEL, SURPLUS_LEVEL, BASIC_KW, INTERMEDIATE_KW, SURPLUS_KW, TOTAL_KW, 
	            BASIC_PRICE, INTERMEDIATE_PRICE, SURPLUS_PRICE, SUBTOTAL_PRICE, TAX, PREV_AMOUNT, PREV_PRICE, TOTAL_PRICE, AMOUNT_PAD, PENDING_AMOUNT) 
                VALUES(?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?); ";

            foreach (var receipt in receipts)
            {
                var res1 = session.Prepare(queryID);
                var res2 = session.Prepare(queryMeter);
                var res3 = session.Prepare(queryService);
                var res4 = session.Prepare(queryYear);
                Guid id = Guid.NewGuid();

                var batch = new BatchStatement()
                    .Add(res1.Bind(id, receipt.First_Name, receipt.Father_Last_Name, receipt.Mother_Last_Name, receipt.State,
                    receipt.City, receipt.Suburb, receipt.Street, receipt.Number, receipt.Postal_Code, receipt.Service,
                    receipt.Meter_Serial_Number, receipt.Service_Number, receipt.Year, receipt.Month, receipt.Day,
                    receipt.Basic_Level, receipt.Intermediate_Level,
                    receipt.Surplus_Level, receipt.Basic_KW, receipt.Intermediate_KW, receipt.Surplus_KW, receipt.Total_KW,
                    receipt.Basic_Price, receipt.Intermediate_Price, receipt.Surplus_Price, receipt.Subtotal_Price, receipt.Tax,
                    receipt.Prev_Amount, receipt.Prev_Price, receipt.Total_Price, receipt.Amount_Pad, receipt.Pending_Amount))
                    .Add(res2.Bind(id, receipt.First_Name, receipt.Father_Last_Name, receipt.Mother_Last_Name, receipt.State,
                    receipt.City, receipt.Suburb, receipt.Street, receipt.Number, receipt.Postal_Code, receipt.Service,
                    receipt.Meter_Serial_Number, receipt.Service_Number, receipt.Year, receipt.Month, receipt.Day,
                    receipt.Basic_Level, receipt.Intermediate_Level,
                    receipt.Surplus_Level, receipt.Basic_KW, receipt.Intermediate_KW, receipt.Surplus_KW, receipt.Total_KW,
                    receipt.Basic_Price, receipt.Intermediate_Price, receipt.Surplus_Price, receipt.Subtotal_Price, receipt.Tax,
                    receipt.Prev_Amount, receipt.Prev_Price, receipt.Total_Price, receipt.Amount_Pad, receipt.Pending_Amount))
                    .Add(res3.Bind(id, receipt.First_Name, receipt.Father_Last_Name, receipt.Mother_Last_Name, receipt.State,
                    receipt.City, receipt.Suburb, receipt.Street, receipt.Number, receipt.Postal_Code, receipt.Service,
                    receipt.Meter_Serial_Number, receipt.Service_Number, receipt.Year, receipt.Month, receipt.Day,
                    receipt.Basic_Level, receipt.Intermediate_Level,
                    receipt.Surplus_Level, receipt.Basic_KW, receipt.Intermediate_KW, receipt.Surplus_KW, receipt.Total_KW,
                    receipt.Basic_Price, receipt.Intermediate_Price, receipt.Surplus_Price, receipt.Subtotal_Price, receipt.Tax,
                    receipt.Prev_Amount, receipt.Prev_Price, receipt.Total_Price, receipt.Amount_Pad, receipt.Pending_Amount))
                    .Add(res4.Bind(id, receipt.First_Name, receipt.Father_Last_Name, receipt.Mother_Last_Name, receipt.State,
                    receipt.City, receipt.Suburb, receipt.Street, receipt.Number, receipt.Postal_Code, receipt.Service,
                    receipt.Meter_Serial_Number, receipt.Service_Number, receipt.Year, receipt.Month, receipt.Day,
                    receipt.Basic_Level, receipt.Intermediate_Level,
                    receipt.Surplus_Level, receipt.Basic_KW, receipt.Intermediate_KW, receipt.Surplus_KW, receipt.Total_KW,
                    receipt.Basic_Price, receipt.Intermediate_Price, receipt.Surplus_Price, receipt.Subtotal_Price, receipt.Tax,
                    receipt.Prev_Amount, receipt.Prev_Price, receipt.Total_Price, receipt.Amount_Pad, receipt.Pending_Amount));

                session.Execute(batch);
            }

        }

        public void EmitReceipt(int year, short month, string service)
        {
            string query = "INSERT INTO EMIT_RECEIPT(YEAR, MONTH, SERVICE) VALUES({0}, {1}, '{2}');";
            query = string.Format(query, year, month, service);

            session.Execute(query);
        }

        public bool FindEmission(int year, short month, string service)
        {
            string query = "SELECT COUNT(YEAR) FROM EMIT_RECEIPT WHERE YEAR = {0} AND MONTH = {1} AND SERVICE = '{2}';";
            query = string.Format(query, year, month, service);

            var res = session.Execute(query);
            Int64 count = 0;
            foreach (var row in res)
            {
                count = row.GetValue<Int64>("system.count(year)");
            }

            if (count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool ReceiptExists(string meterSerialNumber, int year, short month)
        {
            string query = "SELECT COUNT(RECEIPT_ID) FROM RECEIPT_BY_METER_SERIAL_NUMBER WHERE " +
                "METER_SERIAL_NUMBER = '{0}' AND YEAR = {1} AND MONTH = {2};";
            query = string.Format(query, meterSerialNumber, year, month);

            var res = session.Execute(query);
            Int64 count = 0;

            foreach (var row in res)
            {
                count = row.GetValue<Int64>("system.count(receipt_id)");
            }

            if (count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public ReceiptDTO FindReceipt(int year, short month, string meterSerialNumber)
        {
            string query = "SELECT RECEIPT_ID, FIRST_NAME, FATHER_LAST_NAME, MOTHER_LAST_NAME, STATE, CITY, " + 
            "SUBURB, STREET, NUMBER, POSTAL_CODE, SERVICE, METER_SERIAL_NUMBER, SERVICE_NUMBER, YEAR, MONTH, DAY, " +
            "BASIC_LEVEL, INTERMEDIATE_LEVEL, SURPLUS_LEVEL, BASIC_KW, INTERMEDIATE_KW, SURPLUS_KW, TOTAL_KW, " +
            "BASIC_PRICE, INTERMEDIATE_PRICE, SURPLUS_PRICE, SUBTOTAL_PRICE, TAX, TOTAL_PRICE, AMOUNT_PAD, PENDING_AMOUNT, " +
            "IS_PAID, PAYMENT_HISTORY, PAYMENT_TYPE_HISTORY " +
            "FROM RECEIPT_BY_METER_SERIAL_NUMBER WHERE METER_SERIAL_NUMBER = '{0}' AND YEAR = {1} AND MONTH = {2};";
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

        public ReceiptDTO FindReceipt(int year, short month, long serviceNumber)
        {
            string query = "SELECT RECEIPT_ID, FIRST_NAME, FATHER_LAST_NAME, MOTHER_LAST_NAME, STATE, CITY, " +
            "SUBURB, STREET, NUMBER, POSTAL_CODE, SERVICE, METER_SERIAL_NUMBER, SERVICE_NUMBER, YEAR, MONTH, DAY, " +
            "BASIC_LEVEL, INTERMEDIATE_LEVEL, SURPLUS_LEVEL, BASIC_KW, INTERMEDIATE_KW, SURPLUS_KW, TOTAL_KW, " +
            "BASIC_PRICE, INTERMEDIATE_PRICE, SURPLUS_PRICE, SUBTOTAL_PRICE, TAX, TOTAL_PRICE, AMOUNT_PAD, PENDING_AMOUNT, " +
            "IS_PAID, PAYMENT_HISTORY, PAYMENT_TYPE_HISTORY " +
            "FROM RECEIPT_BY_SERVICE_NUMBER WHERE SERVICE_NUMBER = {0} AND YEAR = {1} AND MONTH = {2};";
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

        public List<GeneralReportDTO> GeneralReport(int year, short month, string service)
        {
            string query = @"SELECT YEAR, MONTH, SERVICE, AMOUNT_PAD, PENDING_AMOUNT
                FROM RECEIPT_BY_YEAR WHERE YEAR = {0} AND MONTH = {1} AND SERVICE = '{2}' ALLOW FILTERING";
            query = string.Format(query, year, month, service);

            IEnumerable<GeneralReportDTO> dto;
            try
            {
                dto = mapper.Fetch<GeneralReportDTO>(query);
            }
            catch (Exception e)
            {
                return null;
            }

            return dto.ToList();
        }

        public List<GeneralReportDTO> GeneralReport(int year, short month)
        {
            string query = @"SELECT YEAR, MONTH, SERVICE, AMOUNT_PAD, PENDING_AMOUNT
                FROM RECEIPT_BY_YEAR WHERE YEAR = {0} AND MONTH = {1}";
            query = string.Format(query, year, month);

            IEnumerable<GeneralReportDTO> dto;
            try
            {
                dto = mapper.Fetch<GeneralReportDTO>(query);
            }
            catch (Exception e)
            {
                return null;
            }

            return dto.ToList();
        }

        public List<GeneralReportDTO> GeneralReport(int year, string service)
        {
            string query = @"SELECT YEAR, MONTH, SERVICE, AMOUNT_PAD, PENDING_AMOUNT
                FROM RECEIPT_BY_YEAR WHERE YEAR = {0} AND SERVICE = '{1}' ALLOW FILTERING";
            query = string.Format(query, year, service);

            IEnumerable<GeneralReportDTO> dto;
            try
            {
                dto = mapper.Fetch<GeneralReportDTO>(query);
            }
            catch (Exception e)
            {
                return null;
            }

            return dto.ToList();
        }

        public List<GeneralReportDTO> GeneralReport(int year)
        {
            string query = @"SELECT YEAR, MONTH, SERVICE, AMOUNT_PAD, PENDING_AMOUNT
                FROM RECEIPT_BY_YEAR WHERE YEAR = {0}";
            query = string.Format(query, year);

            IEnumerable<GeneralReportDTO> dto;
            try
            {
                dto = mapper.Fetch<GeneralReportDTO>(query);
            }
            catch (Exception e)
            {
                return null;
            }

            return dto.ToList();
        }

        public List<HistoricConsumptionDTO> HistoricConsumption(int year, string meterSerialNumber)
        {
            string query = @"SELECT YEAR, MONTH, SERVICE, TOTAL_KW, TOTAL_PRICE, AMOUNT_PAD, PENDING_AMOUNT
                FROM RECEIPT_BY_METER_SERIAL_NUMBER WHERE METER_SERIAL_NUMBER = '{0}' AND YEAR = {1};";
            query = string.Format(query, meterSerialNumber, year);

            IEnumerable<HistoricConsumptionDTO> dto;
            try
            {
                dto = mapper.Fetch<HistoricConsumptionDTO>(query);
            }
            catch (Exception e)
            {
                return null;
            }

            return dto.ToList();
        }

        public List<HistoricConsumptionDTO> HistoricConsumption(int year, long serviceNumber)
        {
            string query = @"SELECT YEAR, MONTH, SERVICE, TOTAL_KW, TOTAL_PRICE, AMOUNT_PAD, PENDING_AMOUNT
                FROM RECEIPT_BY_SERVICE_NUMBER WHERE SERVICE_NUMBER = {0} AND YEAR = {1};";
            query = string.Format(query, serviceNumber, year);

            IEnumerable<HistoricConsumptionDTO> dto;
            try
            {
                dto = mapper.Fetch<HistoricConsumptionDTO>(query);
            }
            catch (Exception e)
            {
                return null;
            }

            return dto.ToList();
        }

        public void PaidReceipt(ReceiptDTO dto, decimal mount, decimal paid, decimal pending, string paymentType)
        {
            decimal newPaid = paid + mount;
            decimal newPending = pending - mount;
            bool isPaid = (newPending == 0.0m) ? true : false;

            string queryID = @"UPDATE RECEIPT SET AMOUNT_PAD = {0}, PENDING_AMOUNT = {1}, 
                PAYMENT_HISTORY = PAYMENT_HISTORY + {{  toUnixTimestamp(now()) : {2} }}, 
                PAYMENT_TYPE_HISTORY = PAYMENT_TYPE_HISTORY + ['{3}'], IS_PAID = {4} WHERE RECEIPT_ID = {5};";
            queryID = string.Format(queryID, newPaid, newPending, mount, paymentType, isPaid, dto.Receipt_ID);

            string queryMeter = @"UPDATE RECEIPT_BY_METER_SERIAL_NUMBER SET AMOUNT_PAD = {0}, PENDING_AMOUNT = {1}, 
                PAYMENT_HISTORY = PAYMENT_HISTORY + {{  toUnixTimestamp(now()) : {2} }}, 
                PAYMENT_TYPE_HISTORY = PAYMENT_TYPE_HISTORY + ['{3}'], IS_PAID = {4} WHERE METER_SERIAL_NUMBER = '{5}'
                AND YEAR = {6} AND MONTH = {7};";
            queryMeter = string.Format(queryMeter, newPaid, newPending, mount, paymentType, isPaid, 
                dto.Meter_Serial_Number, dto.Year, dto.Month);

            string queryService = @"UPDATE RECEIPT_BY_SERVICE_NUMBER SET AMOUNT_PAD = {0}, PENDING_AMOUNT = {1}, 
                PAYMENT_HISTORY = PAYMENT_HISTORY + {{  toUnixTimestamp(now()) : {2} }}, 
                PAYMENT_TYPE_HISTORY = PAYMENT_TYPE_HISTORY + ['{3}'], IS_PAID = {4} WHERE SERVICE_NUMBER = {5}
                AND YEAR = {6} AND MONTH = {7};";
            queryService = string.Format(queryService, newPaid, newPending, mount, paymentType, isPaid, dto.Service_Number,
                dto.Year, dto.Month);

            string queryYear = @"UPDATE RECEIPT_BY_YEAR SET AMOUNT_PAD = {0}, PENDING_AMOUNT = {1}, 
                PAYMENT_HISTORY = PAYMENT_HISTORY + {{  toUnixTimestamp(now()) : {2} }}, 
                PAYMENT_TYPE_HISTORY = PAYMENT_TYPE_HISTORY + ['{3}'], IS_PAID = {4} WHERE YEAR = {5} AND MONTH = {6} 
                AND SERVICE = '{7}' AND RECEIPT_ID = {8};";
            queryYear = string.Format(queryYear, newPaid, newPending, mount, paymentType, isPaid, dto.Year, dto.Month,
                dto.Service, dto.Receipt_ID);

            session.Execute(queryID);
            session.Execute(queryMeter);
            session.Execute(queryService);
            session.Execute(queryYear);
        }

        public void IsPeriodEmit(int year, short month)
        {

        }

    }
}
