using Cassandra.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ambar.Model.DTO;
using Cassandra;

namespace Ambar.Model.DAO
{
    class ClientDAO : CassandraConnection
    {

        public void Create(ClientDTO client)
        {
            Guid uuid = Guid.NewGuid();
            string queryEmp = "INSERT INTO CLIENTS(USER_ID, USER_NAME, PASSWORD, CREATION_DATE, MODIFICATION_DATE, " +
               "FIRST_NAME, FATHER_LAST_NAME, MOTHER_LAST_NAME, DATE_OF_BIRTH, CURP, GENDER)" +
               "VALUES(?, ?, ?, toUnixTimestamp(now()), { toUnixTimestamp(now()):'Begin'}, ?, ?, ?, ?, ?, ?);";
            string queryLog = "INSERT INTO CLIENTS_LOGIN(USER_NAME, PASSWORD, ENABLED) VALUES(?, ?, true);";
            string queryRem = "INSERT INTO CLIENTS_ENABLED(USER_NAME, PASSWORD, ENABLED) VALUES(?, ?, true);";

            var emp = session.Prepare(queryEmp);
            var log = session.Prepare(queryLog);
            var rem = session.Prepare(queryRem);

            var batch = new BatchStatement()
                           .Add(emp.Bind(uuid, client.User_Name, client.Password, client.First_Name, client.Father_Last_Name,
                           client.Mother_Last_Name, client.Date_Of_Birth, client.CURP, client.Gender))
                           .Add(log.Bind(client.User_Name, client.Password))
                           .Add(rem.Bind(client.User_Name, client.Password));

            session.Execute(batch);

            string query = "UPDATE CLIENTS SET EMAILS = {";
            foreach (var ls in client.Emails)
            {
                query += "'" + ls + "',";
            }
            query = query.Remove(query.Length - 1);
            query += "} WHERE USER_ID = " + uuid;

            session.Execute(query);
        }

        public void Update(ClientDTO client, string username)
        {
            string queryEnabled = string.Format("SELECT ENABLED FROM CLIENTS_LOGIN WHERE USER_NAME = '{0}';", username);

            IMapper mapper = new Mapper(session);
            bool enabled;

            try
            {
                enabled = mapper.Single<bool>(queryEnabled);
            }
            catch (System.InvalidOperationException e)
            {
                return;
            }

            string queryEmp = string.Format("UPDATE CLIENTS SET USER_NAME = '{0}', PASSWORD = '{1}', FIRST_NAME = '{2}', " +
                "FATHER_LAST_NAME = '{3}', MOTHER_LAST_NAME = '{4}', DATE_OF_BIRTH = '{5}', CURP = '{6}', GENDER = '{7}' " +
                "WHERE USER_ID = {8};",
                  client.User_Name, client.Password, client.First_Name, client.Father_Last_Name, client.Mother_Last_Name, 
                  client.Date_Of_Birth, client.CURP, client.Gender, client.User_ID);

            string queryEmails = "UPDATE CLIENTS SET EMAILS = {";
            foreach (var email in client.Emails)
            {
                queryEmails += "'" + email + "',";
            }
            queryEmails = queryEmails.Remove(queryEmails.Length - 1);
            queryEmails += "} WHERE USER_ID = " + client.User_ID;

            string queryDelLog = string.Format("DELETE FROM CLIENTS_LOGIN WHERE USER_NAME = '{0}';", username);

            string queryLog = string.Format("INSERT INTO CLIENTS_LOGIN(USER_NAME, PASSWORD, ENABLED) " +
                "VALUES('{0}', '{1}', {2});", client.User_Name, client.Password, enabled);

            string queryDelEnabled = string.Format("DELETE FROM CLIENTS_ENABLED WHERE ENABLED = {0} AND USER_NAME = '{1}';",
                enabled, username);

            string queryInEnabled = string.Format("INSERT INTO CLIENTS_ENABLED(USER_NAME, PASSWORD, ENABLED) " +
                "VALUES('{0}', '{1}', {2});", client.User_Name, client.Password, enabled);

            session.Execute(queryEmp);
            session.Execute(queryEmails);
            session.Execute(queryDelLog);
            session.Execute(queryLog);
            session.Execute(queryDelEnabled);
            session.Execute(queryInEnabled);
        }

        public void Delete(Guid id, string username)
        {
            string queryEnabled = string.Format("SELECT ENABLED FROM CLIENTS_LOGIN WHERE USER_NAME = '{0}';", username);

            IMapper mapper = new Mapper(session);
            bool enabled;

            try
            {
                enabled = mapper.Single<bool>(queryEnabled);
            }
            catch (System.InvalidOperationException e)
            {
                return;
            }

            string queryDel = string.Format("DELETE FROM CLIENTS WHERE USER_ID = {0};", id);
            string queryDelLog = string.Format("DELETE FROM CLIENTS_LOGIN WHERE USER_NAME = '{0}';", username);
            string queryDelEnabled = string.Format("DELETE FROM CLIENTS_ENABLED WHERE ENABLED = {0} AND USER_NAME = '{1}';",
               enabled, username);

            session.Execute(queryDel);
            session.Execute(queryDelLog);
            session.Execute(queryDelEnabled);
        }

        public List<ClientDTO> ReadAll()
        {
            string query = "SELECT * FROM CLIENTS;";
            session = cluster.Connect(dbKeyspace);
            IMapper mapper = new Mapper(session);

            IEnumerable<ClientDTO> clients = mapper.Fetch<ClientDTO>(query);

            return clients.ToList();
        }

        public List<string> ReadAllDisable()
        {
            string query = "SELECT USER_NAME FROM CLIENTS_ENABLED WHERE ENABLED = false;";

            IMapper mapper = new Mapper(session);
            IEnumerable<string> clientsDisable;

            try
            {
                clientsDisable = mapper.Fetch<string>(query);
            }
            catch (InvalidOperationException e)
            {
                return null;
            }

            return clientsDisable.ToList();
        }


        public (ClientLoginDTO, bool) Login(string username, string password)
        {
            string query = string.Format("SELECT USER_NAME, PASSWORD, ENABLED FROM CLIENTS_LOGIN WHERE USER_NAME = " +
            "'{0}';", username);

            IMapper mapper = new Mapper(session);
            ClientLoginDTO user;

            try
            {
                user = mapper.Single<ClientLoginDTO>(query);

                if (user.Password != password)
                {
                    return (null, true);
                }

            }
            catch (System.InvalidOperationException e)
            {
                return (null, false);
            }

            return (user, true);
        }

        public void Enabled(string username, bool enabled)
        {
            string query = string.Format("SELECT PASSWORD FROM CLIENTS_LOGIN WHERE USER_NAME = " +
                "'{0}';", username);

            IMapper mapper = new Mapper(session);
            string password;

            try
            {
                password = mapper.Single<string>(query);
            }
            catch (System.InvalidOperationException e)
            {
                return;
            }

            string queryLog = string.Format("UPDATE CLIENTS_LOGIN SET ENABLED = {0} WHERE USER_NAME = '{1}';",
                enabled, username);
            string queryRem1 = string.Format("DELETE FROM CLIENTS_ENABLED WHERE ENABLED = {0} AND USER_NAME = '{1}';",
                !enabled, username);
            string queryRem2 = string.Format("INSERT INTO CLIENTS_ENABLED(USER_NAME, PASSWORD, ENABLED) " +
                "VALUES('{0}', '{1}', {2});", username, password, enabled);

            session.Execute(queryLog);
            session.Execute(queryRem1);
            session.Execute(queryRem2);
        }

        public bool UserExists(string username)
        {
            string query = string.Format("SELECT COUNT(USER_NAME) FROM CLIENTS_LOGIN WHERE USER_NAME = '{0}';", username);

            IMapper mapper = new Mapper(session);
            bool isExisting;

            try
            {
                isExisting = (mapper.Single<int>(query) != 0) ? true : false;
            }
            catch (Exception e)
            {
                isExisting = false;
            }

            return isExisting;
        }

        public Dictionary<string, Guid> ReadAllUsernames()
        {
            string query = "SELECT USER_ID, USER_NAME FROM CLIENTS;";
            session = cluster.Connect(dbKeyspace);

            Dictionary<string, Guid> clients = new Dictionary<string, Guid>();
            var rs = session.Execute(query);
            foreach(var row in rs)
            {
                clients.Add(row.GetValue<string>("user_name"), row.GetValue<Guid>("user_id"));
            }

            return clients;
        }

            // CRUD
        }
}
