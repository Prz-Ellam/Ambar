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
    class ClientDAO : CassandraConnection, IEnableable
    {
        public void Create(ClientDTO client)
        {
            string queryEmp = "INSERT INTO CLIENTS(USER_ID, USER_NAME, PASSWORD, CREATED_AT, MODIFICATE_AT, " +
               "FIRST_NAME, FATHER_LAST_NAME, MOTHER_LAST_NAME, DATE_OF_BIRTH, CURP, GENDER)" +
               "VALUES(?, ?, ?, toUnixTimestamp(now()), [ toUnixTimestamp(now()) ], ?, ?, ?, ?, ?, ?);";
            string queryLog = "INSERT INTO CLIENTS_LOGIN(USER_NAME, PASSWORD, ENABLED) VALUES(?, ?, true);";
            string queryRem = "INSERT INTO CLIENTS_ENABLED(USER_NAME, ENABLED) VALUES(?, true);";

            var emp = session.Prepare(queryEmp);
            var log = session.Prepare(queryLog);
            var rem = session.Prepare(queryRem);

            var batch = new BatchStatement()
                           .Add(emp.Bind(client.User_ID, client.User_Name, client.Password, client.First_Name, client.Father_Last_Name,
                           client.Mother_Last_Name, client.Date_Of_Birth, client.CURP, client.Gender))
                           .Add(log.Bind(client.User_Name, client.Password))
                           .Add(rem.Bind(client.User_Name));

            session.Execute(batch);

            string query = "UPDATE CLIENTS SET EMAILS = {";
            foreach (var ls in client.Emails)
            {
                query += "'" + ls + "',";
            }
            query = query.Remove(query.Length - 1);
            query += "} WHERE USER_ID = " + client.User_ID;

            session.Execute(query);
        }

        public void Update(ClientDTO client, string username)
        {
            string queryEnabled = string.Format("SELECT ENABLED FROM CLIENTS_LOGIN WHERE USER_NAME = '{0}';", username);

            bool enabled;
            try
            {
                enabled = mapper.Single<bool>(queryEnabled);
            }
            catch (Exception e)
            {
                return;
            }

            string queryEmp = string.Format("UPDATE CLIENTS SET USER_NAME = '{0}', PASSWORD = '{1}', FIRST_NAME = '{2}', " +
                "FATHER_LAST_NAME = '{3}', MOTHER_LAST_NAME = '{4}', DATE_OF_BIRTH = '{5}', CURP = '{6}', GENDER = '{7}'," +
                "MODIFICATE_AT = MODIFICATE_AT + [ toUnixTimestamp(now()) ] WHERE USER_ID = {8};",
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

            string queryDelEnabled = "DELETE FROM CLIENTS_ENABLED WHERE ENABLED = {0} AND USER_NAME = '{1}';";
            queryDelEnabled = string.Format(queryDelEnabled, enabled, username);
            string queryInEnabled = "INSERT INTO CLIENTS_ENABLED(USER_NAME, ENABLED) VALUES('{0}', {1});";
            queryInEnabled = string.Format(queryInEnabled, client.User_Name, enabled);

            session.Execute(queryEmp);
            session.Execute(queryEmails);
            session.Execute(queryDelLog);
            session.Execute(queryLog);
            session.Execute(queryDelEnabled);
            session.Execute(queryInEnabled);

            new ContractDAO().UpdateClientInfo(client.User_ID, client.First_Name, client.Father_Last_Name, client.Mother_Last_Name);
        }

        public void Delete(Guid id, string username)
        {
            string queryEnabled = string.Format("SELECT ENABLED FROM CLIENTS_LOGIN WHERE USER_NAME = '{0}';", username);

            bool enabled;
            try
            {
                enabled = mapper.Single<bool>(queryEnabled);
            }
            catch (Exception e)
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
            string query = "SELECT USER_ID, USER_NAME, PASSWORD, CREATED_AT, MODIFICATE_AT, FIRST_NAME, FATHER_LAST_NAME," +
                "MOTHER_LAST_NAME, DATE_OF_BIRTH, EMAILS, CURP, GENDER FROM CLIENTS;";

            IEnumerable<ClientDTO> clients = mapper.Fetch<ClientDTO>(query);

            return clients.ToList();
        }

        public List<string> ReadAllDisable()
        {
            string query = "SELECT USER_NAME FROM CLIENTS_ENABLED WHERE ENABLED = FALSE;";

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


        public ClientLoginDTO Login(string username, string password)
        {
            string query = string.Format("SELECT USER_NAME, PASSWORD, ENABLED FROM CLIENTS_LOGIN WHERE USER_NAME = " +
            "'{0}' AND PASSWORD = '{1}';", username, password);

            ClientLoginDTO user;
            try
            {
                user = mapper.Single<ClientLoginDTO>(query);
            }
            catch (System.InvalidOperationException e)
            {
                return null;
            }

            return user;
        }

        public void Enabled(string username, bool enabled)
        {
            string queryLog = string.Format("UPDATE CLIENTS_LOGIN SET ENABLED = {0} WHERE USER_NAME = '{1}';",
                enabled, username);
            string queryRem1 = string.Format("DELETE FROM CLIENTS_ENABLED WHERE ENABLED = {0} AND USER_NAME = '{1}';",
                !enabled, username);
            string queryRem2 = string.Format("INSERT INTO CLIENTS_ENABLED(USER_NAME, ENABLED) " +
                "VALUES('{0}', {1});", username, enabled);

            session.Execute(queryLog);
            session.Execute(queryRem1);
            session.Execute(queryRem2);
        }

        public bool UserExists(string username)
        {
            string query1 = "SELECT COUNT(USER_NAME) FROM CLIENTS_LOGIN WHERE USER_NAME = '{0}';";
            query1 = string.Format(query1, username);
            string query2 = "SELECT COUNT(USER_NAME) FROM EMPLOYEES_LOGIN WHERE USER_NAME = '{0}';";
            query2 = string.Format(query2, username);
            string query3 = "SELECT COUNT(USER_NAME) FROM ADMINISTRATORS_LOGIN WHERE USER_NAME = '{0}';";
            query3 = string.Format(query3, username);

            bool isExisting1, isExisting2, isExisting3;
            try
            {
                isExisting1 = (mapper.Single<int>(query1) != 0) ? true : false;
                isExisting2 = (mapper.Single<int>(query2) != 0) ? true : false;
                isExisting3 = (mapper.Single<int>(query3) != 0) ? true : false;
            }
            catch (Exception e)
            {
                 return false;
            }

            return (isExisting1 || isExisting2 || isExisting3);
        }

        public bool ClientExists(string username)
        {
            string query = "SELECT COUNT(USER_NAME) FROM CLIENTS_LOGIN WHERE USER_NAME = '{0}';";
            query = string.Format(query, username);

            bool isExisting;
            try
            {
                isExisting = (mapper.Single<int>(query) != 0) ? true : false;
            }
            catch (Exception e)
            {
                return false;
            }

            return (isExisting);
        }

        public Dictionary<string, Guid> ReadAllUsernames()
        {
            string query = "SELECT USER_ID, USER_NAME FROM CLIENTS;";

            Dictionary<string, Guid> clients = new Dictionary<string, Guid>();
            var rs = session.Execute(query);
            foreach (var row in rs)
            {
                clients.Add(row.GetValue<string>("user_name"), row.GetValue<Guid>("user_id"));
            }

            return clients;
        }

    }
}
