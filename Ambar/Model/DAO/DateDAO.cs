using Cassandra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambar.Model.DAO
{
    class DateDAO : CassandraConnection
    {
        public bool DateExists()
        {
            string query = "SELECT COUNT(ID) FROM DATES;";

            var res = session.Execute(query);
            Int64 count = 0;

            foreach (var row in res)
            {
                count = row.GetValue<Int64>("system.count(id)");
            }

            if (count < 1)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public void Create()
        {
            string query = "INSERT INTO DATES(ID, INITIAL, ACTUAL_DATE) VALUES(0, true, '{0}');";
            DateTime auxDate = DateTime.Now.AddMonths(1);
            LocalDate date = new LocalDate(auxDate.Year, auxDate.Month, 1);
            query = string.Format(query, date);

            session.Execute(query);
        }

        public void UpdateDate(string serviceType) // No pasar nunca un mes 11
        {
            DateTime actualDate = GetDate();
            if (actualDate.Month % 2 == 0)
            {
                actualDate.AddMonths(-1);
            }

            string bimester = "SELECT COUNT(YEAR) FROM EMIT_RECEIPT WHERE YEAR = {0} AND MONTH = {1} AND SERVICE = 'Domestico';";
            bimester = string.Format(bimester, actualDate.Year, actualDate.Month);

            string month1 = "SELECT COUNT(YEAR) FROM EMIT_RECEIPT WHERE YEAR = {0} AND MONTH = {1} AND SERVICE = 'Industrial';";
            month1 = string.Format(month1, actualDate.Year, actualDate.Month);

            string month2 = "SELECT COUNT(YEAR) FROM EMIT_RECEIPT WHERE YEAR = {0} AND MONTH = {1} AND SERVICE = 'Industrial';";
            month2 = string.Format(month2, actualDate.Year, actualDate.Month + 1);

            bool isExisting1, isExisting2, isExisting3;
            try
            {
                isExisting1 = (mapper.Single<int>(bimester) != 0) ? true : false;
                isExisting2 = (mapper.Single<int>(month1) != 0) ? true : false;
                isExisting3 = (mapper.Single<int>(month2) != 0) ? true : false;
            }
            catch (Exception e)
            {
                return;
            }

            bool type = (serviceType == "Domestico") ? false : true;


            if ((!isExisting1 && isExisting2 && !isExisting3 ||
                isExisting2 && !isExisting3 && type ||
                isExisting1 && isExisting2 && isExisting3))
            {

                string query = "UPDATE DATES SET ACTUAL_DATE = '{0}', INITIAL = false WHERE ID = 0;";
                query = string.Format(query, actualDate.AddMonths(1).ToString("yyyy-MM-dd"));

                session.Execute(query);
            }
        }

        public void DisableInitial()
        {
            string query = "UPDATE DATES SET INITIAL = false WHERE ID = 0;";
            session.Execute(query);
        }

        public DateTime GetDate()
        {
            string query = "SELECT ACTUAL_DATE FROM DATES WHERE ID = 0;";

            LocalDate date;
            try
            {
                date = mapper.Single<LocalDate>(query);
            }
            catch (Exception e)
            {
                return DateTime.MinValue;
            }

            return new DateTime(date.Year, date.Month, date.Day);
        }

        public bool GetInitial()
        {
            string query = "SELECT INITIAL FROM DATES WHERE ID = 0;";

            bool date;
            try
            {
                date = mapper.Single<bool>(query);
            }
            catch (Exception e)
            {
                return true;
            }

            return date;
        }

    }
}
