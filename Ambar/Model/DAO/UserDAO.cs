using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cassandra.Mapping;
using Ambar.Model.DTO;
using Cassandra;

namespace Ambar.Model.DAO
{
    public class UserDAO : CassandraConnection
    {

        public UserDTO Login(string username, string password)
        {
            string query = string.Format("SELECT USER_NAME, ENABLED, POSITION, REMEMBER FROM USERS_LOGIN WHERE USER_NAME = '{0}' AND PASSWORD = '{1}';",
                username, password);

            IMapper mapper = new Mapper(session);
            UserDTO user;

            try
            {
                user = mapper.Single<UserDTO>(query);
            }
            catch (System.InvalidOperationException e)
            {
                return null;
            }

            return user;

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

        public void RememberUser(string username, string password, bool state)
        {
            string queryUsers = "UPDATE USERS SET REMEMBER = ? WHERE USER_NAME = ?;";
            string queryLogin = "UPDATE USERS_LOGIN SET REMEMBER = ? WHERE USER_NAME = ? AND PASSWORD = ?;";
            string queryInsertRem = "INSERT INTO PASSWORD_REMEMBER(USER_NAME, PASSWORD, REMEMBER) VALUES(?, ?, ?);";
            string queryDelRem = "DELETE FROM PASSWORD_REMEMBER WHERE USER_NAME = ? AND REMEMBER = ?;";

            var users = session.Prepare(queryUsers);
            var login = session.Prepare(queryLogin);
            var insertRem = session.Prepare(queryInsertRem);
            var delRem = session.Prepare(queryDelRem);

            var batch = new BatchStatement()
                            .Add(users.Bind(state, username))
                            .Add(login.Bind(state, username, password))
                            .Add(insertRem.Bind(username, password, state))
                            .Add(delRem.Bind(username, !state));
            session.Execute(batch);
        }

        public void insertUser()
        {
            Connect();

            Disconnect();
        }

        public (string, bool) ReadPassword(string username)
        {
            string query = string.Format("SELECT PASSWORD FROM PASSWORD_REMEMBER WHERE USER_NAME = '{0}' AND REMEMBER = true;",
                username);

            IMapper mapper = new Mapper(session);
            string password;
            bool enabled;

            try
            {
                password = mapper.Single<string>(query);
                enabled = true;
            }
            catch (System.InvalidOperationException e)
            {
                password = null;
                enabled = false;
            }

            return (password, enabled);
        }

        public bool Exists(string username)
        {

            string query = string.Format("SELECT USER_NAME FROM USERS WHERE USER_NAME = '{0}'", username);

            IMapper mapper = new Mapper(session);
            string user;

            try
            {
                user = mapper.Single<string>(query);
                return true;
            }
            catch (System.InvalidOperationException e)
            {
                return false;
            }
        }

        public void SetEnabled(string username, bool enabled)
        {

            string passwordQuery = string.Format("SELECT PASSWORD FROM USERS WHERE USER_NAME = '{0}'", username);
            IMapper mapper = new Mapper(session);
            string password;

            try
            {
                password = mapper.Single<string>(passwordQuery);
            }
            catch (System.InvalidOperationException e)
            {
                return;
            }

            string queryUsers = "UPDATE USERS SET ENABLED = ? WHERE USER_NAME = ?;";
            string queryLogin = "UPDATE USERS_LOGIN SET ENABLED = ? WHERE USER_NAME = ? AND PASSWORD = ?;";

            var users = session.Prepare(queryUsers);
            var login = session.Prepare(queryLogin);

            var batch = new BatchStatement()
                            .Add(users.Bind(enabled, username))
                            .Add(login.Bind(enabled, username, password));
            session.Execute(batch);
        }

    }
}
