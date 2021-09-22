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

        private static UserDAO instance;

        private UserDAO()
        {
            Connect();
        }

        public static UserDAO GetInstance()
        {
            if (instance == null)
            {
                instance = new UserDAO();
            }
            return instance;
        }

        public bool Login(string username, string password)
        {
            string query = "SELECT USER_NAME, PASSWORD, POSITION, ENABLED FROM USERS WHERE USER_NAME = '" + username + "';";

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

        public void Create(string username, string password, string position)
        {
            string query = String.Format(
            "INSERT INTO USERS(USER_ID, USER_NAME, PASSWORD, POSITION, ENABLED, REMEMBER, CREATION_DATE, MODIFICATION_DATE) " +
            "VALUES(uuid(), '{0}', '{1}', '{2}', true, false, toUnixTimestamp(now()), toUnixTimestamp(now()));",
            username, password, position);

            Connect();

            session.Execute(query);

        }

        public Guid GetUserID(string username)
        {
            string query = "SELECT USER_ID FROM USERS WHERE USER_NAME = '" + username + "';";

            IMapper mapper = new Mapper(session);
            Guid id;

            id = mapper.First<Guid>(query);

            return id;

        }

        public void disableUser(string username)
        {
            Connect();

            Disconnect();
        }

        public void rememberUser(string username, bool state)
        {
            string query = "UPDATE USERS SET ENABLED = " + state + " WHERE USER_NAME = '" + username + "';";

        }

        public void insertUser()
        {
            Connect();

            Disconnect();
        }

        public string readPassword(string username)
        {
            string query = "SELECT PASSWORD FROM USERS WHERE USER_NAME = '" + username + "'";

            IMapper mapper = new Mapper(session);
            string password;

            try
            {
                password= mapper.First<string>(query);
            }
            catch (System.InvalidOperationException e)
            {
                password = "";
            }

            return password;
        }
        // CRUD
    }
}
