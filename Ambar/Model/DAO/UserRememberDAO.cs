using Cassandra.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambar.Model.DAO
{
    public class UserRememberDAO : CassandraConnection
    {

        public void RememberPassword(string position, string username, string password)
        {
            string query = string.Format("INSERT INTO USERS_REMEMBER(POSITION, USER_NAME, PASSWORD) " +
               "VALUES('{0}', '{1}', '{2}');", position, username, password);
            session.Execute(query);
        }

        public void ForgerPassword(string position, string username)
        {
            string query = string.Format("DELETE FROM USERS_REMEMBER WHERE POSITION = '{0}' " +
                  "AND USER_NAME = '{1}';", position, username);
            session.Execute(query);
        }

        public string ReadPassword(string position, string username)
        {
            string query = string.Format("SELECT PASSWORD FROM USERS_REMEMBER WHERE POSITION = '{0}' AND " +
                "USER_NAME = '{1}'", position, username);

            IMapper mapper = new Mapper(session);
            string password;

            try
            {
                password = mapper.Single<string>(query);
            }
            catch (System.InvalidOperationException e)
            {
                return null;
            }

            return password;
        }

        public List<string> GetRememberUsers(string position)
        {

            string query;
            if (position == null)
            {
                query = "SELECT USER_NAME FROM USERS_REMEMBER";
            }
            else
            {
                query = string.Format("SELECT USER_NAME FROM USERS_REMEMBER WHERE POSITION = '{0}';", position);
            }

            IMapper mapper = new Mapper(session);
            IEnumerable<string> users;

            try
            {
                users = mapper.Fetch<string>(query);
            }
            catch (System.InvalidOperationException e)
            {
                return null;
            }

            return users.ToList();
        }


    }
}
