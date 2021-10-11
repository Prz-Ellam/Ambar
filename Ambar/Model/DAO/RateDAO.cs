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
    class RateDAO : CassandraConnection
    {
        public void Create(RateDTO rate)
        {
            Guid uuid = Guid.NewGuid();

            string queryRate = "INSERT INTO RATES(RATE_ID, BASIC_LEVEL, INTERMEDIATE_LEVEL, SURPLUS_LEVEL, " +
                "SERVICE, YEAR, MONTH) VALUES(?, ?, ?, ?, ?, ?, ?);";
            string queryYear = "INSERT INTO RATES_BY_YEAR(RATE_ID, BASIC_LEVEL, INTERMEDIATE_LEVEL, SURPLUS_LEVEL, " +
                "SERVICE, YEAR, MONTH) VALUES(?, ?, ?, ?, ?, ?, ?);";

            var rat = session.Prepare(queryRate);
            var year = session.Prepare(queryYear);

            var batch = new BatchStatement()
                           .Add(rat.Bind(uuid, rate.Basic_Level, rate.Intermediate_Level, rate.Surplus_Level, rate.Service,
                           rate.Year, rate.Month))
                           .Add(year.Bind(uuid, rate.Basic_Level, rate.Intermediate_Level, rate.Surplus_Level, rate.Service,
                           rate.Year, rate.Month));

            session.Execute(batch);

            string queryExists = string.Format("SELECT COUNT(YEAR) FROM RATES_ACTIVE " +
                "WHERE YEAR = {0} AND MONTH = {1} AND SERVICE = '{2}';", rate.Year, rate.Month, rate.Service);

            IMapper mapper = new Mapper(session);
            bool exists;

            try
            {
                exists = (mapper.Single<int>(queryExists) != 0) ? true : false;
            }
            catch (System.InvalidOperationException e)
            {
                return;
            }

            string queryAct;
            if (exists)
            {
                queryAct = string.Format("UPDATE RATES_ACTIVE SET BASIC_LEVEL = {0}, INTERMEDIATE_LEVEL = {1}, " +
                    "SURPLUS_LEVEL = {2} WHERE SERVICE = '{3}' AND YEAR = {4} AND MONTH = {5};",
               rate.Basic_Level, rate.Intermediate_Level, rate.Surplus_Level, rate.Service, rate.Year, rate.Month);
            }
            else
            {
                queryAct = string.Format("INSERT INTO RATES_ACTIVE(BASIC_LEVEL, INTERMEDIATE_LEVEL, SURPLUS_LEVEL," +
               " SERVICE, YEAR, MONTH) VALUES({0}, {1}, {2}, '{3}', {4}, {5});",
               rate.Basic_Level, rate.Intermediate_Level, rate.Surplus_Level, rate.Service, rate.Year, rate.Month);
            }
            session.Execute(queryAct);

        }


        public List<RateDTO> ReadByYear(int year)
        {
            string query = string.Format("SELECT * FROM RATES_BY_YEAR WHERE YEAR = {0};", year);

            IMapper mapper = new Mapper(session);
            IEnumerable<RateDTO> rates;

            try
            {
                rates = mapper.Fetch<RateDTO>(query);
            }
            catch (System.InvalidOperationException e)
            {
                return null;
            }

            return rates.ToList();
        }


        public List<RateDTO> ReadAll()
        {
            string query = "SELECT * FROM RATES";

            IMapper mapper = new Mapper(session);
            IEnumerable<RateDTO> rates;

            try
            {
                rates = mapper.Fetch<RateDTO>(query);
            }
            catch (System.InvalidOperationException e)
            {
                return null;
            }

            return rates.ToList();
        }
    }
}
