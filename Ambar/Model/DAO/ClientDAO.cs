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
            foreach (var ls in client.Email)
            {
                query += "'" + ls + "',";
            }
            query = query.Remove(query.Length - 1);
            query += "} WHERE USER_ID = " + uuid;

            session.Execute(query);
        }


        public (ClientLoginDTO, bool) Login(string username, string password)
        {
            return (null, false);
        }

        public void Enabled(string username, bool enabled)
        {
        }


            // CRUD
        }
}
