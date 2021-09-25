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
            string query = string.Format("SELECT USER_NAME, ENABLED, POSITION, REMEMBER FROM USERS_BY_LOGIN WHERE USER_NAME = '{0}' AND PASSWORD = '{1}';",
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

            string queryUser = "INSERT INTO USERS(USER_ID, USER_NAME, PASSWORD, POSITION, ENABLED, REMEMBER) VALUES(?, ?, ?, ?, true, false);";
            string queryUsern = "INSERT INTO USERS_BY_USERNAME(USER_ID, USER_NAME, PASSWORD, POSITION, ENABLED, REMEMBER) VALUES(?, ?, ?, ?, true, false);";
            string queryLogin = "INSERT INTO USERS_BY_LOGIN(USER_ID, USER_NAME, PASSWORD, POSITION, ENABLED, REMEMBER) VALUES(?, ?, ?, ?, true, false);";
            string queryRem = "INSERT INTO USERS_BY_REMEMBER(USER_NAME, PASSWORD, REMEMBER) VALUES(?, ?, false);";

            var user = session.Prepare(queryUser);
            var usern = session.Prepare(queryUsern);
            var login = session.Prepare(queryLogin);
            var rem = session.Prepare(queryRem);
            Guid userID = Guid.NewGuid();

            var batch = new BatchStatement()
                           .Add(user.Bind(userID, username, password, position))
                           .Add(usern.Bind(userID, username, password, position))
                           .Add(login.Bind(userID, username, password, position))
                           .Add(rem.Bind(username, password));
            session.Execute(batch);

            /*
            BEGIN BATCH
            INSERT INTO USERS(USER_ID, USER_NAME, PASSWORD, POSITION, ENABLED, REMEMBER)
            VALUES(c299cf20-b9f8-11eb-ad94-fba2c2fddc37, 'PrzEllam', '123', 'Administrator', true, false);
            INSERT INTO USERS_BY_USERNAME(USER_ID, USER_NAME, PASSWORD, POSITION, ENABLED, REMEMBER)
            VALUES(c299cf20-b9f8-11eb-ad94-fba2c2fddc37, 'PrzEllam', '123', 'Administrator', true, false);
            INSERT INTO USERS_BY_LOGIN(USER_ID, USER_NAME, PASSWORD, POSITION, ENABLED, REMEMBER)
            VALUES(c299cf20-b9f8-11eb-ad94-fba2c2fddc37, 'PrzEllam', '123', 'Administrator', true, false);
            INSERT INTO USERS_BY_REMEMBER(USER_NAME, PASSWORD, REMEMBER)
            VALUES('PrzEllam', '123', false);
            APPLY BATCH;
            */

        }

        public Guid GetUserID(string username)
        {
            string query = string.Format("SELECT USER_ID FROM USERS_BY_USERNAME WHERE USER_NAME = '{0}';", username);

            IMapper mapper = new Mapper(session);
            Guid id;

            id = mapper.Single<Guid>(query);

            return id;
        }

        public void disableUser(string username)
        {
            Connect();

            Disconnect();
        }

        public UserDTO Read(Guid id)
        {
            string query = string.Format("SELECT USER_ID, USER_NAME, PASSWORD, POSITION, ENABLED, REMEMBER FROM USERS WHERE USER_ID = {0};", id);

            IMapper mapper = new Mapper(session);
            UserDTO dto = new UserDTO();
            try
            {
                dto = mapper.Single<UserDTO>(query);
            }
            catch (InvalidOperationException e)
            {
                dto = null;
            }

            return dto;
        }

        public void RememberUser(string username, string password, bool state)
        {

            Guid id = GetUserID(username);

            string queryUsers = "UPDATE USERS SET REMEMBER = ? WHERE USER_ID = ?;";
            string queryUsername = "UPDATE USERS_BY_USERNAME SET REMEMBER = ? WHERE USER_NAME = ?;";
            string queryLogin = "UPDATE USERS_BY_LOGIN SET REMEMBER = ? WHERE USER_NAME = ? AND PASSWORD = ?;";
            string queryInsertRem = "INSERT INTO USERS_BY_REMEMBER(USER_NAME, PASSWORD, REMEMBER) VALUES(?, ?, ?);";
            string queryDelRem = "DELETE FROM USERS_BY_REMEMBER WHERE USER_NAME = ? AND REMEMBER = ?;";

            var users = session.Prepare(queryUsers);
            var usern = session.Prepare(queryUsername);
            var login = session.Prepare(queryLogin);
            var insertRem = session.Prepare(queryInsertRem);
            var delRem = session.Prepare(queryDelRem);

            var batch = new BatchStatement()
                            .Add(users.Bind(state, id))
                            .Add(usern.Bind(state, username))
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
            string query = string.Format("SELECT PASSWORD FROM USERS_BY_REMEMBER WHERE USER_NAME = '{0}' AND REMEMBER = true;",
                username);

            IMapper mapper = new Mapper(session);
            string password;
            bool enabled;

            try
            {
                password = mapper.Single<string>(query);
                enabled = true;
            }
            catch (InvalidOperationException e)
            {
                password = null;
                enabled = false;
            }

            return (password, enabled);
        }

        public bool Exists(string username)
        {

            string query = string.Format("SELECT USER_NAME FROM USERS_BY_USERNAME WHERE USER_NAME = '{0}'", username);

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

            string passwordQuery = string.Format("SELECT PASSWORD FROM USERS_BY_USERNAME WHERE USER_NAME = '{0}'", username);
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

            Guid id = GetUserID(username);

            string queryUsers = "UPDATE USERS SET ENABLED = ? WHERE USER_ID = ?";
            string queryUsersn = "UPDATE USERS_BY_USERNAME SET ENABLED = ? WHERE USER_NAME = ?;";
            string queryLogin = "UPDATE USERS_BY_LOGIN SET ENABLED = ? WHERE USER_NAME = ? AND PASSWORD = ?;";

            var users = session.Prepare(queryUsers);
            var usersn = session.Prepare(queryUsersn);
            var login = session.Prepare(queryLogin);

            var batch = new BatchStatement()
                            .Add(users.Bind(enabled, id))
                            .Add(usersn.Bind(enabled, username))
                            .Add(login.Bind(enabled, username, password));
            session.Execute(batch);
        }

    }
}
