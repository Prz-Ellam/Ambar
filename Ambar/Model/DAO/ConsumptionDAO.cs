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
    class ConsumptionDAO : CassandraConnection
    {
        public void Create(ConsumptionDTO dto)
        {
            string queryCon = "INSERT INTO CONSUMPTIONS(CONSUMPTION_ID, CONTRACT_ID, METER_SERIAL_NUMBER, SERVICE_NUMBER, BASIC_KW, " +
                "INTERMEDIATE_KW, SURPLUS_KW, TOTAL_KW, YEAR, MONTH, DAY) VALUES(?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)";
            string queryYear = "INSERT INTO CONSUMPTIONS_BY_YEAR(CONSUMPTION_ID, CONTRACT_ID, METER_SERIAL_NUMBER, SERVICE_NUMBER, " +
                "BASIC_KW, INTERMEDIATE_KW, SURPLUS_KW, TOTAL_KW, YEAR, MONTH, DAY) VALUES(?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)";
            string queryMeter = "INSERT INTO CONSUMPTIONS_BY_METER_SERIAL_NUMBER(CONSUMPTION_ID, CONTRACT_ID, METER_SERIAL_NUMBER, " +
                "SERVICE_NUMBER, BASIC_KW, INTERMEDIATE_KW, SURPLUS_KW, TOTAL_KW, YEAR, MONTH, DAY) " +
                "VALUES(?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)";
            string queryService = "INSERT INTO CONSUMPTIONS_BY_SERVICE_NUMBER(CONSUMPTION_ID, CONTRACT_ID, METER_SERIAL_NUMBER, " +
                "SERVICE_NUMBER, BASIC_KW, INTERMEDIATE_KW, SURPLUS_KW, TOTAL_KW, YEAR, MONTH, DAY) " +
                "VALUES(?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)";

            var con = session.Prepare(queryCon);
            var year = session.Prepare(queryYear);
            var meter = session.Prepare(queryMeter);
            var service = session.Prepare(queryService);

            var batch = new BatchStatement()
                        .Add(con.Bind(dto.Consumption_ID, dto.Contract_ID, dto.Meter_Serial_Number, dto.Service_Number, dto.Basic_KW,
                        dto.Intermediate_KW, dto.Surplus_KW, dto.Total_KW, dto.Year, dto.Month, dto.Day))
                        .Add(year.Bind(dto.Consumption_ID, dto.Contract_ID, dto.Meter_Serial_Number, dto.Service_Number, dto.Basic_KW,
                        dto.Intermediate_KW, dto.Surplus_KW, dto.Total_KW, dto.Year, dto.Month, dto.Day))
                        .Add(meter.Bind(dto.Consumption_ID, dto.Contract_ID, dto.Meter_Serial_Number, dto.Service_Number, dto.Basic_KW,
                        dto.Intermediate_KW, dto.Surplus_KW, dto.Total_KW, dto.Year, dto.Month, dto.Day))
                        .Add(service.Bind(dto.Consumption_ID, dto.Contract_ID, dto.Meter_Serial_Number, dto.Service_Number, dto.Basic_KW,
                        dto.Intermediate_KW, dto.Surplus_KW, dto.Total_KW, dto.Year, dto.Month, dto.Day));

            session.Execute(batch);
        }

        public List<ConsumptionDTO> ReadConsumptions()
        {
            string query = "SELECT CONSUMPTION_ID, METER_SERIAL_NUMBER, SERVICE_NUMBER, BASIC_KW, INTERMEDIATE_KW, " +
                "SURPLUS_KW, TOTAL_KW, YEAR, MONTH, DAY FROM CONSUMPTIONS;";

            IEnumerable<ConsumptionDTO> rates;
            try
            {
                rates = mapper.Fetch<ConsumptionDTO>(query);
            }
            catch (Exception e)
            {
                return null;
            }

            return rates.ToList();
        }

        public List<ConsumptionDTO> ReadConsumptionsByYear(int year)
        {
            string query = string.Format("SELECT CONSUMPTION_ID, METER_SERIAL_NUMBER, SERVICE_NUMBER, BASIC_KW, " +
                "INTERMEDIATE_KW, SURPLUS_KW, TOTAL_KW, YEAR, MONTH FROM CONSUMPTIONS_BY_YEAR WHERE YEAR = {0};", year);

            IEnumerable<ConsumptionDTO> consumptions;
            try
            {
                consumptions = mapper.Fetch<ConsumptionDTO>(query);
            }
            catch (Exception e)
            {
                return null;
            }

            return consumptions.ToList();
        }

        public bool ConsumptionExists(string meterSerialNumber, int year, int month)
        {
            string query = "SELECT COUNT(YEAR) FROM CONSUMPTIONS_BY_METER_SERIAL_NUMBER" +
                " WHERE METER_SERIAL_NUMBER = '{0}' AND YEAR = {1} AND MONTH = {2};";
            query = string.Format(query, meterSerialNumber, year, month);

            var res = session.Execute(query);
            long count = 0;
            foreach (var row in res)
            {
                count = row.GetValue<long>("system.count(year)");
            }

            return (count > 0) ? true : false;
        }

        public ConsumptionDTO FindConsumption(int year, int month, string meterSerialNumber)
        {
            string query = @"SELECT CONSUMPTION_ID, CONTRACT_ID, METER_SERIAL_NUMBER, SERVICE_NUMBER, BASIC_KW, 
                            INTERMEDIATE_KW, SURPLUS_KW, YEAR, MONTH, DAY FROM CONSUMPTIONS_BY_YEAR 
                            WHERE YEAR = {0} AND MONTH = {1} AND METER_SERIAL_NUMBER = '{2}';";
            query = string.Format(query, year, month, meterSerialNumber);

            ConsumptionDTO consumptions;
            try
            {
                consumptions = mapper.Single<ConsumptionDTO>(query);
            }
            catch (Exception e)
            {
                return null;
            }

            return consumptions;
        }


    }
}
