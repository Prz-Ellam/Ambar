using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambar.Model.DAO
{
    class ActivityDAO : CassandraConnection
    {
        public void Action(Guid id, string action)
        {
            string query = @"INSERT INTO ACTIVITY(ACTIVITY_ID, USER_ID, ACTION, OFFSET) VALUES({0}, {1}, '{2}', 
                            toUnixTimestamp(now()));";
            query = string.Format(query, Guid.NewGuid(), id, action);
            session.Execute(query);
        }
    }
}
