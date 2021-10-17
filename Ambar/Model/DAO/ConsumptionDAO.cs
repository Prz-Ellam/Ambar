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

        public List<ConsumptionDTO> ReadByYear(int year)
        {
            string query = string.Format("SELECT * FROM CONSUMPTIONS_BY_YEAR WHERE YEAR = {0};", year);

            IEnumerable<ConsumptionDTO> consumptions;
            try
            {
                consumptions = mapper.Fetch<ConsumptionDTO>(query);
            }
            catch (System.InvalidOperationException e)
            {
                return null;
            }

            return consumptions.ToList();
        }

        public bool ConsumptionExists(string meterSerialNumber, int year, short month)
        {
            string query = string.Format("SELECT COUNT(YEAR) FROM CONSUMPTIONS_BY_YEAR WHERE YEAR = {0} AND MONTH = {1} " +
                "AND METER_SERIAL_NUMBER = '{2}';", year, month, meterSerialNumber);

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

        public ConsumptionForReceiptDTO GetConsumptions(int year, short month, string meterSerialNumber)
        {
            string query = string.Format("SELECT BASIC_KW, INTERMEDIATE_KW, SURPLUS_KW FROM CONSUMPTIONS_BY_YEAR WHERE " +
                "YEAR = {0} AND MONTH = {1} AND METER_SERIAL_NUMBER = '{2}';", year, month, meterSerialNumber);

            ConsumptionForReceiptDTO consumptions;
            try
            {
                consumptions = mapper.Single<ConsumptionForReceiptDTO>(query);
            }
            catch (System.InvalidOperationException e)
            {
                return null;
            }

            return consumptions;
        }


    }
}
