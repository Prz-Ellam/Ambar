using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ambar.Model.DTO;
using Cassandra;
using Cassandra.Mapping;

namespace Ambar.Model.DAO
{
    class ContractDAO : CassandraConnection
    {
        public void Create(ContractDTO contract)
        {
            string query = "INSERT INTO CONTRACTS(CONTRACT_ID, METER_SERIAL_NUMBER, SERVICE_NUMBER, STATE, CITY, SUBURB, " +
                "STREET, NUMBER, POSTAL_CODE, SERVICE, CLIENT_ID, FIRST_NAME, FATHER_LAST_NAME, MOTHER_LAST_NAME, " +
                "CREATED_AT, START_PERIOD_DATE)" +
                "VALUES(?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, toUnixTimestamp(now()), ?);";
            string queryMeter = "INSERT INTO CONTRACTS_BY_METER_SERIAL_NUMBER(CONTRACT_ID, METER_SERIAL_NUMBER, " +
                "SERVICE_NUMBER, STATE, CITY, SUBURB, STREET, NUMBER, POSTAL_CODE, SERVICE, CLIENT_ID, FIRST_NAME, " +
                "FATHER_LAST_NAME, MOTHER_LAST_NAME, CREATED_AT, START_PERIOD_DATE)" +
                "VALUES(?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, toUnixTimestamp(now()), ?);";
            string queryService = "INSERT INTO CONTRACTS_BY_SERVICE(CONTRACT_ID, METER_SERIAL_NUMBER, " +
                "SERVICE_NUMBER, STATE, CITY, SUBURB, STREET, NUMBER, POSTAL_CODE, SERVICE, CLIENT_ID, FIRST_NAME, " +
                "FATHER_LAST_NAME, MOTHER_LAST_NAME, CREATED_AT, START_PERIOD_DATE)" +
                "VALUES(?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, toUnixTimestamp(now()), ?);";
            string queryClient = "INSERT INTO CLIENT_CONTRACTS(CONTRACT_ID, METER_SERIAL_NUMBER, SERVICE_NUMBER, STATE, " +
                "CITY, SUBURB, STREET, NUMBER, POSTAL_CODE, SERVICE, CLIENT_ID, FIRST_NAME, FATHER_LAST_NAME, " +
                "MOTHER_LAST_NAME, CREATED_AT, START_PERIOD_DATE)" +
                "VALUES(?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, toUnixTimestamp(now()), ?);";

            var contracts = session.Prepare(query);
            var meter = session.Prepare(queryMeter);
            var service = session.Prepare(queryService);
            var client = session.Prepare(queryClient);

            var batch = new BatchStatement()
                           .Add(contracts.Bind(contract.Contract_ID, contract.Meter_Serial_Number, contract.Service_Number, contract.State, 
                           contract.City, contract.Suburb, contract.Street, contract.Number, contract.Postal_Code,
                           contract.Service, contract.Client_ID, contract.First_Name, contract.Father_Last_Name,
                           contract.Mother_Last_Name, contract.Start_Period_Date))
                           .Add(meter.Bind(contract.Contract_ID, contract.Meter_Serial_Number, contract.Service_Number, contract.State,
                           contract.City, contract.Suburb, contract.Street, contract.Number, contract.Postal_Code,
                           contract.Service, contract.Client_ID, contract.First_Name, contract.Father_Last_Name, 
                           contract.Mother_Last_Name, contract.Start_Period_Date))
                           .Add(service.Bind(contract.Contract_ID, contract.Meter_Serial_Number, contract.Service_Number, contract.State,
                           contract.City, contract.Suburb, contract.Street, contract.Number, contract.Postal_Code,
                           contract.Service, contract.Client_ID, contract.First_Name, contract.Father_Last_Name, 
                           contract.Mother_Last_Name, contract.Start_Period_Date))
                           .Add(client.Bind(contract.Contract_ID, contract.Meter_Serial_Number, contract.Service_Number, contract.State,
                           contract.City, contract.Suburb, contract.Street, contract.Number, contract.Postal_Code,
                           contract.Service, contract.Client_ID, contract.First_Name, contract.Father_Last_Name, 
                           contract.Mother_Last_Name, contract.Start_Period_Date));

            session.Execute(batch);
        }

        public void UpdateClientInfo(Guid id, string name, string fatherLastName, string motherLastName)
        {
            string query = "SELECT CONTRACT_ID, METER_SERIAL_NUMBER, SERVICE_NUMBER FROM CLIENT_CONTRACTS WHERE CLIENT_ID = {0};";
            query = string.Format(query, id);

            var res = session.Execute(query);
            foreach (var row in res)
            {
                string meterSerialNumber = row.GetValue<string>("meter_serial_number");
                Guid contractID = row.GetValue<Guid>("contract_id");
                int serviceNumber = row.GetValue<int>("service_number");

                string query1 = "UPDATE CONTRACTS SET FIRST_NAME = '{0}', FATHER_LAST_NAME = '{1}', MOTHER_LAST_NAME = '{2}' " +
                    "WHERE CONTRACT_ID = {3};";
                query1 = string.Format(query1, name, fatherLastName, motherLastName, contractID);
                string query2 = "UPDATE CONTRACTS_BY_SERVICE SET FIRST_NAME = '{0}', FATHER_LAST_NAME = '{1}', " +
                    "MOTHER_LAST_NAME = '{2}' WHERE SERVICE_NUMBER = {3};";
                query2 = string.Format(query2, name, fatherLastName, motherLastName, serviceNumber);
                string query3 = "UPDATE CONTRACTS_BY_METER_SERIAL_NUMBER SET FIRST_NAME = '{0}', FATHER_LAST_NAME = '{1}', " +
                   "MOTHER_LAST_NAME = '{2}' WHERE METER_SERIAL_NUMBER = {3};";
                query3 = string.Format(query3, name, fatherLastName, motherLastName, meterSerialNumber, serviceNumber);
                string query4 = "UPDATE CLIENT_CONTRACTS SET FIRST_NAME = '{0}', FATHER_LAST_NAME = '{1}', " +
                    "MOTHER_LAST_NAME = '{2}' WHERE CLIENT_ID = {3};";
                query4 = string.Format(query4, name, fatherLastName, motherLastName, id);

                session.Execute(query1);
                session.Execute(query2);
                session.Execute(query3);
                session.Execute(query4);
                break;
            }

        }

        public List<ContractDTO> ReadContracts()
        {
            string query = string.Format("SELECT CONTRACT_ID, METER_SERIAL_NUMBER, SERVICE_NUMBER, STATE, CITY, SUBURB, " +
                "STREET, NUMBER, POSTAL_CODE, SERVICE, CLIENT_ID, FIRST_NAME, FATHER_LAST_NAME, MOTHER_LAST_NAME, " +
                "CREATED_AT, START_PERIOD_DATE, CREATED_AT FROM CLIENT_CONTRACTS;");

            IEnumerable<ContractDTO> contracts;
            try
            {
                contracts = mapper.Fetch<ContractDTO>(query);
            }
            catch (Exception e)
            {
                return null;
            }

            return contracts.ToList();
        }

        public List<ContractDTO> ReadClientContracts(Guid clientID)
        {
            string query = string.Format("SELECT CONTRACT_ID, METER_SERIAL_NUMBER, SERVICE_NUMBER, STATE, CITY, SUBURB, " +
                "STREET, NUMBER, POSTAL_CODE, SERVICE, CLIENT_ID, FIRST_NAME, FATHER_LAST_NAME, MOTHER_LAST_NAME, " +
                "CREATED_AT, START_PERIOD_DATE, CREATED_AT FROM CLIENT_CONTRACTS WHERE CLIENT_ID = {0}", clientID);

            IEnumerable<ContractDTO> contracts;
            try
            {
                contracts = mapper.Fetch<ContractDTO>(query);
            }
            catch (Exception e)
            {
                return null;
            }

            return contracts.ToList();
        }

        public bool ContractExists(string meterSerialNumber, int serviceNumber)
        {
            string query = "SELECT COUNT(METER_SERIAL_NUMBER) FROM CONTRACTS_BY_METER_SERIAL_NUMBER WHERE " +
                "METER_SERIAL_NUMBER = '{0}' AND SERVICE_NUMBER = {1};";
            query = string.Format(query, meterSerialNumber, serviceNumber);

            var res = session.Execute(query);
            Int64 count = 0;
            foreach (var row in res)
            {
                count = row.GetValue<Int64>("system.count(meter_serial_number)");
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

        public bool ContractExists(string meterSerialNumber)
        {
            string query = "SELECT COUNT(METER_SERIAL_NUMBER) FROM CONTRACTS_BY_METER_SERIAL_NUMBER WHERE " +
                "METER_SERIAL_NUMBER = '{0}';";
            query = string.Format(query, meterSerialNumber);

            var res = session.Execute(query);
            Int64 count = 0;
            foreach (var row in res)
            {
                count = row.GetValue<Int64>("system.count(meter_serial_number)");
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

        public string FindServiceType(string meterSerialNumber)
        {
            string query = "SELECT SERVICE FROM CONTRACTS_BY_METER_SERIAL_NUMBER WHERE METER_SERIAL_NUMBER = '{0}';";
            query = string.Format(query, meterSerialNumber);
            string serviceType;

            try
            {
                serviceType = mapper.Single<string>(query);
            }
            catch (Exception e)
            {
                return null;
            }

            return serviceType;
        }

        public LocalDate FindStartPeriodDate(string meterSerialNumber)
        {
            string query = "SELECT START_PERIOD_DATE FROM CONTRACTS_BY_METER_SERIAL_NUMBER WHERE METER_SERIAL_NUMBER = '{0}';";
            query = string.Format(query, meterSerialNumber);
            LocalDate startPeriod = null;

            try
            {
                startPeriod = mapper.Single<LocalDate>(query);
            }
            catch (Exception e)
            {
                return null;
            }

            return startPeriod;
        }

        public int ReadServiceNumberByMeterSerialNumber(string meterSerialNumber)
        {
            string query = string.Format("SELECT SERVICE_NUMBER FROM CONTRACTS_BY_METER_SERIAL_NUMBER WHERE METER_SERIAL_NUMBER = '{0}'",
                meterSerialNumber);

            int serviceNumber;
            try
            {
                serviceNumber = mapper.Single<int>(query);
            }
            catch (System.InvalidOperationException e)
            {
                return -1;
            }

            return serviceNumber;
        }

        public List<ContractForReceiptDTO> ReadContractsForReceipt(string service)
        {
            string query = "SELECT FIRST_NAME, FATHER_LAST_NAME, MOTHER_LAST_NAME, STATE, CITY, SUBURB, STREET, NUMBER, " +
                "POSTAL_CODE, SERVICE, METER_SERIAL_NUMBER, SERVICE_NUMBER FROM CONTRACTS_BY_SERVICE WHERE SERVICE = '{0}'";
            query = string.Format(query, service);

            IEnumerable<ContractForReceiptDTO> contracts;
            try
            {
                contracts = mapper.Fetch<ContractForReceiptDTO>(query);
            }
            catch (Exception e)
            {
                return null;
            }

            return contracts.ToList();
        }


    }
}
