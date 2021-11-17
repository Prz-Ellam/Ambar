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
            string query = "INSERT INTO USERS_REMEMBER(POSITION, USER_NAME, PASSWORD) " +
                "VALUES('{0}', '{1}', '{2}');";
            query = string.Format(query, position, username, password);
            session.Execute(query);
        }

        public void ForgerPassword(string position, string username)
        {
            string query = "DELETE FROM USERS_REMEMBER WHERE POSITION = '{0}' AND USER_NAME = '{1}';";
            query = string.Format(query, position, username);
            session.Execute(query);
        }

        public string ReadPassword(string position, string username)
        {
            string query = "SELECT PASSWORD FROM USERS_REMEMBER WHERE POSITION = '{0}' AND USER_NAME = '{1}'";
            query = string.Format(query, position, username);

            string password = null;
            var res = session.Execute(query);

            foreach(var row in res)
            {
                password = row.GetValue<string>("password");
            }

            return password;
        }

        public List<string> GetRememberUsers(string position)
        {
            string query;
            if (position == null)
            {
                query = "SELECT USER_NAME FROM USERS_REMEMBER;";
            }
            else
            {
                query = "SELECT USER_NAME FROM USERS_REMEMBER WHERE POSITION = '{0}';";
                query = string.Format(query, position);
            }

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

        public void UpdateRememberUser(string position, string oldUsername, string newUsername, string password)
        {
            ForgerPassword(position, oldUsername);
            RememberPassword(position, newUsername, password);
        }

        public bool RememberUserExists(string position, string username)
        {
            string query = "SELECT COUNT(USER_NAME) FROM USERS_REMEMBER WHERE POSITION = '{0}' AND USER_NAME = '{1}';";
            query = string.Format(query, position, username);

            var res = session.Execute(query);
            foreach(var row in res)
            {
                Int64 count = row.GetValue<Int64>("system.count(user_name)");

                if (count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }

        public Guid GetUserID(string position, string username)
        {
            string query;
            switch (position)
            {
                case "Administrator":
                {
                    query = "SELECT USER_ID FROM ADMINISTRATORS WHERE USER_NAME = '{0}' ALLOW FILTERING;";
                    break;
                }
                case "Employee":
                {
                    query = "SELECT USER_ID FROM EMPLOYEES WHERE USER_NAME = '{0}' ALLOW FILTERING;";
                    break;
                }
                case "Client":
                {
                    query = "SELECT USER_ID FROM CLIENTS WHERE USER_NAME = '{0}' ALLOW FILTERING;";
                    break;
                }
                default:
                {
                    return Guid.Empty;
                }
            }
            query = string.Format(query, username);

            Guid id;
            try
            {
                id = mapper.Single<Guid>(query);
            }
            catch (Exception e)
            {
                return Guid.Empty;
            }

            return id;
        }

        public void Action(Guid id, string action)
        {
            string query = @"INSERT INTO ACTIVITY(ACTIVITY_ID, USER_ID, ACTION, OFFSET) VALUES({0}, {1}, '{2}', 
                            toUnixTimestamp(now()));";
            query = string.Format(query, Guid.NewGuid(), id, action);
            session.Execute(query);
        }

    }
}
