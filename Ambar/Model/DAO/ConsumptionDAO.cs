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
            string queryCon = "INSERT INTO CONSUMPTIONS(CONSUMPTION_ID, METER_SERIAL_NUMBER, SERVICE_NUMBER, BASIC_KW, " +
                "INTERMEDIATE_KW, SURPLUS_KW, TOTAL_KW, YEAR, MONTH) VALUES(?, ?, ?, ?, ?, ?, ?, ?, ?)";
            string queryYear = "INSERT INTO CONSUMPTIONS_BY_YEAR(CONSUMPTION_ID, METER_SERIAL_NUMBER, SERVICE_NUMBER, " +
                "BASIC_KW, INTERMEDIATE_KW, SURPLUS_KW, TOTAL_KW, YEAR, MONTH) VALUES(?, ?, ?, ?, ?, ?, ?, ?, ?)";
            string queryMeter = "INSERT INTO CONSUMPTIONS_BY_METER_SERIAL_NUMBER(CONSUMPTION_ID, METER_SERIAL_NUMBER, " +
                "SERVICE_NUMBER, BASIC_KW, INTERMEDIATE_KW, SURPLUS_KW, TOTAL_KW, YEAR, MONTH) " +
                "VALUES(?, ?, ?, ?, ?, ?, ?, ?, ?)";
            string queryService = "INSERT INTO CONSUMPTIONS_BY_SERVICE_NUMBER(CONSUMPTION_ID, METER_SERIAL_NUMBER, " +
                "SERVICE_NUMBER, BASIC_KW, INTERMEDIATE_KW, SURPLUS_KW, TOTAL_KW, YEAR, MONTH) " +
                "VALUES(?, ?, ?, ?, ?, ?, ?, ?, ?)";

            var con = session.Prepare(queryCon);
            var year = session.Prepare(queryYear);
            var meter = session.Prepare(queryMeter);
            var service = session.Prepare(queryService);

            var batch = new BatchStatement()
                           .Add(con.Bind(dto.Consumption_ID, dto.Meter_Serial_Number, dto.Service_Number, dto.Basic_KW,
                           dto.Intermediate_KW, dto.Surplus_KW, dto.Total_KW, dto.Year, dto.Month))
                           .Add(year.Bind(dto.Consumption_ID, dto.Meter_Serial_Number, dto.Service_Number, dto.Basic_KW,
                           dto.Intermediate_KW, dto.Surplus_KW, dto.Total_KW, dto.Year, dto.Month))
                           .Add(meter.Bind(dto.Consumption_ID, dto.Meter_Serial_Number, dto.Service_Number, dto.Basic_KW,
                           dto.Intermediate_KW, dto.Surplus_KW, dto.Total_KW, dto.Year, dto.Month))
                           .Add(service.Bind(dto.Consumption_ID, dto.Meter_Serial_Number, dto.Service_Number, dto.Basic_KW,
                           dto.Intermediate_KW, dto.Surplus_KW, dto.Total_KW, dto.Year, dto.Month));

            session.Execute(batch);
        }

        public List<ConsumptionDTO> ReadConsumptions()
        {
            string query = "SELECT CONSUMPTION_ID, METER_SERIAL_NUMBER, SERVICE_NUMBER, BASIC_KW, INTERMEDIATE_KW, " +
                "SURPLUS_KW, TOTAL_KW, YEAR, MONTH FROM CONSUMPTIONS;";

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

        public bool ConsumptionExists(string meterSerialNumber, int year, short month)
        {
            string query = "SELECT COUNT(YEAR) FROM CONSUMPTIONS_BY_METER_SERIAL_NUMBER" +
                " WHERE METER_SERIAL_NUMBER = '{0}' AND YEAR = {1} AND MONTH = {2};";
            query = string.Format(query, meterSerialNumber, year, month);

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

        public ConsumptionForReceiptDTO FindConsumption(int year, short month, string meterSerialNumber)
        {
            string query = string.Format("SELECT BASIC_KW, INTERMEDIATE_KW, SURPLUS_KW FROM CONSUMPTIONS_BY_YEAR WHERE " +
                "YEAR = {0} AND MONTH = {1} AND METER_SERIAL_NUMBER = '{2}';", year, month, meterSerialNumber);

            ConsumptionForReceiptDTO consumptions;
            try
            {
                consumptions = mapper.Single<ConsumptionForReceiptDTO>(query);
            }
            catch (Exception e)
            {
                return null;
            }

            return consumptions;
        }


    }
}
