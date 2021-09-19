using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cassandra.Mapping;
using Ambar.Model.DTO;

namespace Ambar.Model.DAO
{
    public class UserDAO : CassandraConnection
    {
        public bool Login(string username, string password)
        {
            Connect();
            string query = "SELECT USER_NAME, PASSWORD, POSITION, ENABLED FROM USERS WHERE USER_NAME = '" + username + "';";

            session = cluster.Connect(dbKeyspace);
            IMapper mapper = new Mapper(session);
            UserDTO user;

            try
            {
                user = mapper.First<UserDTO>(query);
            }
            catch (System.InvalidOperationException e)
            {
                return false;
            }

            Disconnect();

            if (user == null)
            {
                return false;
            }
            else if (user.Password != password)
            {
                return false;
            }
            else
            {
                return true;
            }

        }

        public void disableUser(string username)
        {

        }

        public void rememberUser(string username, bool state)
        {
            Connect();
            string query = "UPDATE USERS SET ENABLED = " + state + " WHERE USER_NAME = '" + username + "';";

            Disconnect();
        }

        public void insertUser()
        {

        }

        public string readPassword(string username)
        {
            string query = "SELECT PASSWORD FROM USERS WHERE USER_NAME = '"+ username +"'";

            return null;
        }
        // CRUD
    }
}
