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
            Guid uuid = Guid.NewGuid();
            string query = "INSERT INTO CONTRACTS(CONTRACT_ID, METER_SERIAL_NUMBER, SERVICE_NUMBER, STATE, CITY, SUBURB, " +
                "STREET, NUMBER, POSTAL_CODE, SERVICE, CLIENT_ID, CREATION_DATE, START_PERIOD_DATE)" +
                "VALUES(?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, toUnixTimestamp(now()), ?);";
            string queryMeter = "INSERT INTO CONTRACTS_BY_METER_SERIAL_NUMBER(CONTRACT_ID, METER_SERIAL_NUMBER, " +
                "SERVICE_NUMBER, STATE, CITY, SUBURB, STREET, NUMBER, POSTAL_CODE, SERVICE, CLIENT_ID, CREATION_DATE, " +
                "START_PERIOD_DATE)" +
                "VALUES(?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, toUnixTimestamp(now()), ?);";
            string queryContract = "INSERT INTO CLIENT_CONTRACTS(CONTRACT_ID, METER_SERIAL_NUMBER, SERVICE_NUMBER, STATE, " +
                "CITY, SUBURB, STREET, NUMBER, POSTAL_CODE, SERVICE, CLIENT_ID, CREATION_DATE, START_PERIOD_DATE)" +
                "VALUES(?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, toUnixTimestamp(now()), ?);";

            var s = session.Prepare(query);
            var meter = session.Prepare(queryMeter);
            var contr = session.Prepare(queryContract);

            var batch = new BatchStatement()
                           .Add(s.Bind(uuid, contract.Meter_Serial_Number, contract.Service_Number, contract.State, 
                           contract.City, contract.Suburb, contract.Street, contract.Number, contract.Postal_Code,
                           contract.Service, contract.Client_ID, contract.Start_Period_Date))
                           .Add(meter.Bind(uuid, contract.Meter_Serial_Number, contract.Service_Number, contract.State,
                           contract.City, contract.Suburb, contract.Street, contract.Number, contract.Postal_Code,
                           contract.Service, contract.Client_ID, contract.Start_Period_Date))
                           .Add(contr.Bind(uuid, contract.Meter_Serial_Number, contract.Service_Number, contract.State,
                           contract.City, contract.Suburb, contract.Street, contract.Number, contract.Postal_Code,
                           contract.Service, contract.Client_ID, contract.Start_Period_Date));

            session.Execute(batch);
        }

        public List<ContractDTO> ReadClientContracts(Guid clientID)
        {
            string query = string.Format("SELECT * FROM CLIENT_CONTRACTS WHERE CLIENT_ID = {0}", clientID);

            IMapper mapper = new Mapper(session);
            IEnumerable<ContractDTO> contracts;

            try
            {
                contracts = mapper.Fetch<ContractDTO>(query);
            }
            catch (System.InvalidOperationException e)
            {
                return null;
            }

            return contracts.ToList();
        }
    }
}
