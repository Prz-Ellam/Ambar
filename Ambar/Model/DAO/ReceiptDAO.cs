using Ambar.Model.DTO;
using Ambar.ViewController.Objects;
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
        public void GenerateMassiveReceipts(List<ReceiptDTO> receipts)
        {
            string queryID = @"INSERT INTO RECEIPT(RECEIPT_ID, CONTRACT_ID, FIRST_NAME, FATHER_LAST_NAME, MOTHER_LAST_NAME, STATE, CITY,
                SUBURB, STREET, NUMBER, POSTAL_CODE, SERVICE, METER_SERIAL_NUMBER, SERVICE_NUMBER, YEAR, MONTH, DAY,  
	            BASIC_LEVEL, INTERMEDIATE_LEVEL, SURPLUS_LEVEL, BASIC_KW, INTERMEDIATE_KW, SURPLUS_KW, TOTAL_KW, 
	            BASIC_PRICE, INTERMEDIATE_PRICE, SURPLUS_PRICE, SUBTOTAL_PRICE, TAX, PREV_AMOUNT, PREV_PRICE, TOTAL_PRICE, AMOUNT_PAID, PENDING_AMOUNT, 
                PAYMENT_HISTORY, PAYMENT_TYPE_HISTORY, IS_PAID) 
                VALUES(?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, 
                ?, ?, { toUnixTimestamp(now()) : 0 }, ['Default'], ?); ";
            string queryMeter = @"INSERT INTO RECEIPT_BY_METER_SERIAL_NUMBER(RECEIPT_ID, CONTRACT_ID, FIRST_NAME, FATHER_LAST_NAME, MOTHER_LAST_NAME, STATE, CITY,
                SUBURB, STREET, NUMBER, POSTAL_CODE, SERVICE, METER_SERIAL_NUMBER, SERVICE_NUMBER, YEAR, MONTH, DAY,  
	            BASIC_LEVEL, INTERMEDIATE_LEVEL, SURPLUS_LEVEL, BASIC_KW, INTERMEDIATE_KW, SURPLUS_KW, TOTAL_KW, 
	            BASIC_PRICE, INTERMEDIATE_PRICE, SURPLUS_PRICE, SUBTOTAL_PRICE, TAX, PREV_AMOUNT, PREV_PRICE, TOTAL_PRICE, AMOUNT_PAID, PENDING_AMOUNT, 
                PAYMENT_HISTORY, PAYMENT_TYPE_HISTORY, IS_PAID) 
                VALUES(?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, 
                ?, ?, { toUnixTimestamp(now()) : 0 }, ['Default'], ?); ";
            string queryService = @"INSERT INTO RECEIPT_BY_SERVICE_NUMBER(RECEIPT_ID, CONTRACT_ID, FIRST_NAME, FATHER_LAST_NAME, MOTHER_LAST_NAME, STATE, CITY,
                SUBURB, STREET, NUMBER, POSTAL_CODE, SERVICE, METER_SERIAL_NUMBER, SERVICE_NUMBER, YEAR, MONTH, DAY, 
	            BASIC_LEVEL, INTERMEDIATE_LEVEL, SURPLUS_LEVEL, BASIC_KW, INTERMEDIATE_KW, SURPLUS_KW, TOTAL_KW, 
	            BASIC_PRICE, INTERMEDIATE_PRICE, SURPLUS_PRICE, SUBTOTAL_PRICE, TAX, PREV_AMOUNT, PREV_PRICE, TOTAL_PRICE, AMOUNT_PAID, PENDING_AMOUNT, 
                PAYMENT_HISTORY, PAYMENT_TYPE_HISTORY, IS_PAID) 
                VALUES(?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, 
                ?, ?, { toUnixTimestamp(now()) : 0 }, ['Default'], ?); ";
            string queryYear = @"INSERT INTO RECEIPT_BY_YEAR(RECEIPT_ID, CONTRACT_ID, FIRST_NAME, FATHER_LAST_NAME, MOTHER_LAST_NAME, STATE, CITY,
                SUBURB, STREET, NUMBER, POSTAL_CODE, SERVICE, METER_SERIAL_NUMBER, SERVICE_NUMBER, YEAR, MONTH, DAY, 
	            BASIC_LEVEL, INTERMEDIATE_LEVEL, SURPLUS_LEVEL, BASIC_KW, INTERMEDIATE_KW, SURPLUS_KW, TOTAL_KW, 
	            BASIC_PRICE, INTERMEDIATE_PRICE, SURPLUS_PRICE, SUBTOTAL_PRICE, TAX, PREV_AMOUNT, PREV_PRICE, TOTAL_PRICE, AMOUNT_PAID, PENDING_AMOUNT,
                PAYMENT_HISTORY, PAYMENT_TYPE_HISTORY, IS_PAID) 
                VALUES(?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, 
                ?, ?, { toUnixTimestamp(now()) : 0 }, ['Default'], ?); ";

            foreach (var receipt in receipts)
            {
                var res1 = session.Prepare(queryID);
                var res2 = session.Prepare(queryMeter);
                var res3 = session.Prepare(queryService);
                var res4 = session.Prepare(queryYear);

                var batch = new BatchStatement()
                    .Add(res1.Bind(receipt.Receipt_ID, receipt.Contract_ID, receipt.First_Name, receipt.Father_Last_Name, receipt.Mother_Last_Name, receipt.State,
                    receipt.City, receipt.Suburb, receipt.Street, receipt.Number, receipt.Postal_Code, receipt.Service,
                    receipt.Meter_Serial_Number, receipt.Service_Number, receipt.Year, receipt.Month, receipt.Day,
                    receipt.Basic_Level, receipt.Intermediate_Level,
                    receipt.Surplus_Level, receipt.Basic_KW, receipt.Intermediate_KW, receipt.Surplus_KW, receipt.Total_KW,
                    receipt.Basic_Price, receipt.Intermediate_Price, receipt.Surplus_Price, receipt.Subtotal_Price, receipt.Tax,
                    receipt.Prev_Amount, receipt.Prev_Price, receipt.Total_Price, receipt.Amount_Paid, receipt.Pending_Amount, receipt.Is_Paid))
                    .Add(res2.Bind(receipt.Receipt_ID, receipt.Contract_ID, receipt.First_Name, receipt.Father_Last_Name, receipt.Mother_Last_Name, receipt.State,
                    receipt.City, receipt.Suburb, receipt.Street, receipt.Number, receipt.Postal_Code, receipt.Service,
                    receipt.Meter_Serial_Number, receipt.Service_Number, receipt.Year, receipt.Month, receipt.Day,
                    receipt.Basic_Level, receipt.Intermediate_Level,
                    receipt.Surplus_Level, receipt.Basic_KW, receipt.Intermediate_KW, receipt.Surplus_KW, receipt.Total_KW,
                    receipt.Basic_Price, receipt.Intermediate_Price, receipt.Surplus_Price, receipt.Subtotal_Price, receipt.Tax,
                    receipt.Prev_Amount, receipt.Prev_Price, receipt.Total_Price, receipt.Amount_Paid, receipt.Pending_Amount, receipt.Is_Paid))
                    .Add(res3.Bind(receipt.Receipt_ID, receipt.Contract_ID, receipt.First_Name, receipt.Father_Last_Name, receipt.Mother_Last_Name, receipt.State,
                    receipt.City, receipt.Suburb, receipt.Street, receipt.Number, receipt.Postal_Code, receipt.Service,
                    receipt.Meter_Serial_Number, receipt.Service_Number, receipt.Year, receipt.Month, receipt.Day,
                    receipt.Basic_Level, receipt.Intermediate_Level,
                    receipt.Surplus_Level, receipt.Basic_KW, receipt.Intermediate_KW, receipt.Surplus_KW, receipt.Total_KW,
                    receipt.Basic_Price, receipt.Intermediate_Price, receipt.Surplus_Price, receipt.Subtotal_Price, receipt.Tax,
                    receipt.Prev_Amount, receipt.Prev_Price, receipt.Total_Price, receipt.Amount_Paid, receipt.Pending_Amount, receipt.Is_Paid))
                    .Add(res4.Bind(receipt.Receipt_ID, receipt.Contract_ID, receipt.First_Name, receipt.Father_Last_Name, receipt.Mother_Last_Name, receipt.State,
                    receipt.City, receipt.Suburb, receipt.Street, receipt.Number, receipt.Postal_Code, receipt.Service,
                    receipt.Meter_Serial_Number, receipt.Service_Number, receipt.Year, receipt.Month, receipt.Day,
                    receipt.Basic_Level, receipt.Intermediate_Level,
                    receipt.Surplus_Level, receipt.Basic_KW, receipt.Intermediate_KW, receipt.Surplus_KW, receipt.Total_KW,
                    receipt.Basic_Price, receipt.Intermediate_Price, receipt.Surplus_Price, receipt.Subtotal_Price, receipt.Tax,
                    receipt.Prev_Amount, receipt.Prev_Price, receipt.Total_Price, receipt.Amount_Paid, receipt.Pending_Amount, receipt.Is_Paid));

                session.Execute(batch);
            }

        }

        public void EmitReceipt(int year, int month, string service)
        {
            string query = "INSERT INTO EMIT_RECEIPT(YEAR, MONTH, SERVICE) VALUES({0}, {1}, '{2}');";
            query = string.Format(query, year, month, service);

            session.Execute(query);
        }

        public void EmitReceipt(ReceiptForm receipt)
        {
            string query = "INSERT INTO EMIT_RECEIPT(YEAR, MONTH, SERVICE) VALUES({0}, {1}, '{2}');";
            query = string.Format(query, receipt.Year, receipt.Period, receipt.ServiceType);

            session.Execute(query);
        }

        public bool FindEmission(int year, int month, string service)
        {
            string query = "SELECT COUNT(YEAR) FROM EMIT_RECEIPT WHERE YEAR = {0} AND MONTH = {1} AND SERVICE = '{2}';";
            query = string.Format(query, year, month, service);

            var res = session.Execute(query);
            long count = 0;
            foreach (var row in res)
            {
                count = row.GetValue<long>("system.count(year)");
            }

            return (count > 0) ? true : false;
        }

        public bool ReceiptExists(string meterSerialNumber, int year, int month)
        {
            string query = @"SELECT COUNT(RECEIPT_ID) FROM RECEIPT_BY_METER_SERIAL_NUMBER WHERE 
                            METER_SERIAL_NUMBER = '{0}' AND YEAR = {1} AND MONTH = {2};";
            query = string.Format(query, meterSerialNumber, year, month);

            var res = session.Execute(query);
            long count = 0;
            foreach (var row in res)
            {
                count = row.GetValue<long>("system.count(receipt_id)");
            }

            return (count > 0) ? true : false;
        }

        public ReceiptDTO FindReceipt(ClientReceiptForm clientReceipt)
        {
            string query = "SELECT RECEIPT_ID, FIRST_NAME, FATHER_LAST_NAME, MOTHER_LAST_NAME, STATE, CITY, " +
            "SUBURB, STREET, NUMBER, POSTAL_CODE, SERVICE, METER_SERIAL_NUMBER, SERVICE_NUMBER, YEAR, MONTH, DAY, " +
            "BASIC_LEVEL, INTERMEDIATE_LEVEL, SURPLUS_LEVEL, BASIC_KW, INTERMEDIATE_KW, SURPLUS_KW, TOTAL_KW, " +
            "BASIC_PRICE, INTERMEDIATE_PRICE, SURPLUS_PRICE, SUBTOTAL_PRICE, TAX, TOTAL_PRICE, AMOUNT_PAID, PENDING_AMOUNT, " +
            "IS_PAID, PAYMENT_HISTORY, PAYMENT_TYPE_HISTORY, PREV_AMOUNT, PREV_PRICE " +
            "FROM RECEIPT_BY_METER_SERIAL_NUMBER WHERE METER_SERIAL_NUMBER = '{0}' AND YEAR = {1} AND MONTH = {2};";
            query = string.Format(query, clientReceipt.MeterSerialNumber, clientReceipt.Period.Year, clientReceipt.Period.Month);

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

        public ReceiptDTO FindReceipt(int year, int month, string meterSerialNumber)
        {
            string query = "SELECT RECEIPT_ID, FIRST_NAME, FATHER_LAST_NAME, MOTHER_LAST_NAME, STATE, CITY, " + 
            "SUBURB, STREET, NUMBER, POSTAL_CODE, SERVICE, METER_SERIAL_NUMBER, SERVICE_NUMBER, YEAR, MONTH, DAY, " +
            "BASIC_LEVEL, INTERMEDIATE_LEVEL, SURPLUS_LEVEL, BASIC_KW, INTERMEDIATE_KW, SURPLUS_KW, TOTAL_KW, " +
            "BASIC_PRICE, INTERMEDIATE_PRICE, SURPLUS_PRICE, SUBTOTAL_PRICE, TAX, TOTAL_PRICE, AMOUNT_PAID, PENDING_AMOUNT, " +
            "IS_PAID, PAYMENT_HISTORY, PAYMENT_TYPE_HISTORY, PREV_AMOUNT, PREV_PRICE " +
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

        public ReceiptDTO FindReceipt(int year, int month, long serviceNumber)
        {
            string query = "SELECT RECEIPT_ID, FIRST_NAME, FATHER_LAST_NAME, MOTHER_LAST_NAME, STATE, CITY, " +
            "SUBURB, STREET, NUMBER, POSTAL_CODE, SERVICE, METER_SERIAL_NUMBER, SERVICE_NUMBER, YEAR, MONTH, DAY, " +
            "BASIC_LEVEL, INTERMEDIATE_LEVEL, SURPLUS_LEVEL, BASIC_KW, INTERMEDIATE_KW, SURPLUS_KW, TOTAL_KW, " +
            "BASIC_PRICE, INTERMEDIATE_PRICE, SURPLUS_PRICE, SUBTOTAL_PRICE, TAX, TOTAL_PRICE, AMOUNT_PAID, PENDING_AMOUNT, " +
            "IS_PAID, PAYMENT_HISTORY, PAYMENT_TYPE_HISTORY, PREV_AMOUNT, PREV_PRICE " +
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

        public List<GeneralReportDTO> GeneralReport(int year, int month, string service)
        {
            string query = @"SELECT YEAR, MONTH, SERVICE, AMOUNT_PAID, PENDING_AMOUNT
                FROM RECEIPT_BY_YEAR WHERE YEAR = {0} AND MONTH = {1} AND SERVICE = '{2}';";
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

        public List<GeneralReportDTO> GeneralReport(int year, int month)
        {
            string query = @"SELECT YEAR, MONTH, SERVICE, AMOUNT_PAID, PENDING_AMOUNT FROM RECEIPT_BY_YEAR 
                            WHERE YEAR = {0} AND MONTH = {1}";
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
            string query = @"SELECT YEAR, MONTH, SERVICE, AMOUNT_PAID, PENDING_AMOUNT FROM RECEIPT_BY_YEAR 
                            WHERE YEAR = {0} AND SERVICE = '{1}' ALLOW FILTERING";
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
            string query = @"SELECT YEAR, MONTH, SERVICE, AMOUNT_PAID, PENDING_AMOUNT FROM RECEIPT_BY_YEAR 
                            WHERE YEAR = {0}";
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
            string query = @"SELECT YEAR, MONTH, SERVICE, TOTAL_KW, TOTAL_PRICE, AMOUNT_PAID, PENDING_AMOUNT
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
            string query = @"SELECT YEAR, MONTH, SERVICE, TOTAL_KW, TOTAL_PRICE, AMOUNT_PAID, PENDING_AMOUNT
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

        public List<HistoricConsumptionDTO> HistoricConsumption(long serviceNumber)
        {
            string query = @"SELECT YEAR, MONTH, SERVICE, TOTAL_KW, TOTAL_PRICE, AMOUNT_PAID, PENDING_AMOUNT
                FROM RECEIPT_BY_SERVICE_NUMBER WHERE SERVICE_NUMBER = {0};";
            query = string.Format(query, serviceNumber);

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

        public List<HistoricConsumptionDTO> HistoricConsumption(string meterSerialNumber)
        {
            string query = @"SELECT YEAR, MONTH, SERVICE, TOTAL_KW, TOTAL_PRICE, AMOUNT_PAID, PENDING_AMOUNT
                FROM RECEIPT_BY_METER_SERIAL_NUMBER WHERE METER_SERIAL_NUMBER = '{0}';";
            query = string.Format(query, meterSerialNumber);

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

        public void PaidReceipt(Guid id, string meterSerialNumber, long serviceNumber, string service, int year,
            int month, decimal mount, decimal paid, decimal pending, string paymentType)
        {
            decimal newPaid = paid + mount;
            decimal newPending = pending - mount;
            bool isPaid = (newPending == 0.0m) ? true : false;

            string queryID = @"UPDATE RECEIPT SET AMOUNT_PAID = {0}, PENDING_AMOUNT = {1}, 
                PAYMENT_HISTORY = PAYMENT_HISTORY + {{  toUnixTimestamp(now()) : {2} }}, 
                PAYMENT_TYPE_HISTORY = PAYMENT_TYPE_HISTORY + ['{3}'], IS_PAID = {4} WHERE RECEIPT_ID = {5};";
            queryID = string.Format(queryID, newPaid, newPending, mount, paymentType, isPaid, id);

            string queryMeter = @"UPDATE RECEIPT_BY_METER_SERIAL_NUMBER SET AMOUNT_PAID = {0}, PENDING_AMOUNT = {1}, 
                PAYMENT_HISTORY = PAYMENT_HISTORY + {{  toUnixTimestamp(now()) : {2} }}, 
                PAYMENT_TYPE_HISTORY = PAYMENT_TYPE_HISTORY + ['{3}'], IS_PAID = {4} WHERE METER_SERIAL_NUMBER = '{5}'
                AND YEAR = {6} AND MONTH = {7};";
            queryMeter = string.Format(queryMeter, newPaid, newPending, mount, paymentType, isPaid, 
                meterSerialNumber, year, month);

            string queryService = @"UPDATE RECEIPT_BY_SERVICE_NUMBER SET AMOUNT_PAID = {0}, PENDING_AMOUNT = {1}, 
                PAYMENT_HISTORY = PAYMENT_HISTORY + {{  toUnixTimestamp(now()) : {2} }}, 
                PAYMENT_TYPE_HISTORY = PAYMENT_TYPE_HISTORY + ['{3}'], IS_PAID = {4} WHERE SERVICE_NUMBER = {5}
                AND YEAR = {6} AND MONTH = {7};";
            queryService = string.Format(queryService, newPaid, newPending, mount, paymentType, isPaid, serviceNumber,
                year, month);

            string queryYear = @"UPDATE RECEIPT_BY_YEAR SET AMOUNT_PAID = {0}, PENDING_AMOUNT = {1}, 
                PAYMENT_HISTORY = PAYMENT_HISTORY + {{  toUnixTimestamp(now()) : {2} }}, 
                PAYMENT_TYPE_HISTORY = PAYMENT_TYPE_HISTORY + ['{3}'], IS_PAID = {4} WHERE YEAR = {5} AND MONTH = {6} 
                AND SERVICE = '{7}' AND RECEIPT_ID = {8};";
            queryYear = string.Format(queryYear, newPaid, newPending, mount, paymentType, isPaid, year, month,
                service, id);

            session.Execute(queryID);
            session.Execute(queryMeter);
            session.Execute(queryService);
            session.Execute(queryYear);
        }

        public void UpdateClientInfo(string meterSerialNumber, long serviceNumber, string name, string fatherLastName, string motherLastName)
        {
            string query = @"SELECT RECEIPT_ID, YEAR, MONTH, SERVICE FROM RECEIPT_BY_METER_SERIAL_NUMBER WHERE 
                            METER_SERIAL_NUMBER = '{0}';";
            query = string.Format(query, meterSerialNumber);

            var res = session.Execute(query);
            foreach (var row in res)
            {
                Guid receiptID = row.GetValue<Guid>("receipt_id");
                int year = row.GetValue<int>("year");
                short month = row.GetValue<short>("month");
                string service = row.GetValue<string>("service");

                string query1 = @"UPDATE RECEIPT SET FIRST_NAME = '{0}', FATHER_LAST_NAME = '{1}', MOTHER_LAST_NAME = '{2}'
                                WHERE RECEIPT_ID = {3};";
                query1 = string.Format(query1, name, fatherLastName, motherLastName, receiptID);
                string query2 = @"UPDATE RECEIPT_BY_METER_SERIAL_NUMBER SET FIRST_NAME = '{0}', FATHER_LAST_NAME = '{1}', MOTHER_LAST_NAME = '{2}'
                                 WHERE METER_SERIAL_NUMBER = '{3}' AND YEAR = {4} AND MONTH = {5};";
                query2 = string.Format(query2, name, fatherLastName, motherLastName, meterSerialNumber, year, month);
                string query3 = @"UPDATE RECEIPT_BY_SERVICE_NUMBER SET FIRST_NAME = '{0}', FATHER_LAST_NAME = '{1}', MOTHER_LAST_NAME = '{2}'
                                WHERE SERVICE_NUMBER = {3} AND YEAR = {4} AND MONTH = {5};";
                query3 = string.Format(query3, name, fatherLastName, motherLastName, serviceNumber, year, month);
                string query4 = @"UPDATE RECEIPT_BY_YEAR SET FIRST_NAME = '{0}', FATHER_LAST_NAME = '{1}', MOTHER_LAST_NAME = '{2}'
                                WHERE YEAR = {3} AND MONTH = {4} AND SERVICE = '{5}' AND RECEIPT_ID = {6};";
                query4 = string.Format(query4, name, fatherLastName, motherLastName, year, month, service, receiptID);

                session.Execute(query1);
                session.Execute(query2);
                session.Execute(query3);
                session.Execute(query4);
            }
        }

    }
}
