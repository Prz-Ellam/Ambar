using System;
using System.Collections.Generic;
using System.Globalization;
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

            string queryExists = "SELECT COUNT(YEAR) FROM RATES_ACTIVE WHERE YEAR = {0} AND MONTH = {1} AND SERVICE = '{2}';";
            queryExists = string.Format(queryExists, rate.Year, rate.Month, rate.Service);

            bool exists;

            try
            {
                exists = (mapper.Single<int>(queryExists) != 0) ? true : false;
            }
            catch (Exception e)
            {
                return;
            }

            string queryAct;
            if (exists)
            {
                queryAct = string.Format(CultureInfo.InvariantCulture,
                    "UPDATE RATES_ACTIVE SET BASIC_LEVEL = {0}, INTERMEDIATE_LEVEL = {1}, " +
                    "SURPLUS_LEVEL = {2} WHERE SERVICE = '{3}' AND YEAR = {4} AND MONTH = {5};",
               rate.Basic_Level, rate.Intermediate_Level, rate.Surplus_Level, rate.Service, rate.Year, rate.Month);
            }
            else
            {
                queryAct = string.Format(CultureInfo.InvariantCulture, 
                    "INSERT INTO RATES_ACTIVE(BASIC_LEVEL, INTERMEDIATE_LEVEL, SURPLUS_LEVEL," +
               " SERVICE, YEAR, MONTH) VALUES({0}, {1}, {2}, '{3}', {4}, {5});",
               rate.Basic_Level, rate.Intermediate_Level, rate.Surplus_Level, rate.Service, rate.Year, rate.Month);
            }
            session.Execute(queryAct);

        }

        public RateForReceiptDTO FindActiveRates(string service, int year, short month)
        {
            if (service == "Doméstico")
                service = "Domestico";

            string query = "SELECT BASIC_LEVEL, INTERMEDIATE_LEVEL, SURPLUS_LEVEL FROM RATES_ACTIVE WHERE YEAR = {0} " +
                "AND MONTH = {1} AND SERVICE = '{2}';";
            query = string.Format(query, year, month, service);

            RateForReceiptDTO rateActive;
            try
            {
                rateActive = mapper.Single<RateForReceiptDTO>(query);
            }
            catch (Exception e)
            {
                return null;
            }

            return rateActive;
        }


        public List<RateDTO> ReadRates()
        {
            string query = "SELECT RATE_ID, BASIC_LEVEL, INTERMEDIATE_LEVEL, SURPLUS_LEVEL, SERVICE, YEAR, MONTH FROM RATES";

            IEnumerable<RateDTO> rates;
            try
            {
                rates = mapper.Fetch<RateDTO>(query);
            }
            catch (Exception e)
            {
                return null;
            }

            return rates.ToList();
        }

        public List<RateDTO> ReadRatesByYear(int year)
        {
            string query = "SELECT RATE_ID, BASIC_LEVEL, INTERMEDIATE_LEVEL, SURPLUS_LEVEL, SERVICE, YEAR, MONTH FROM " +
                "RATES_BY_YEAR WHERE YEAR = {0};";
            query = string.Format(query, year);

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
