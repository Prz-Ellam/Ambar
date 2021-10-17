using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ambar.Model.DTO;
using Cassandra;
using Cassandra.Mapping;

namespace Ambar.Model.DAO
{
    class EmployeeDAO : CassandraConnection
    {

        public void Create(EmployeeDTO employee)
        {
            string queryEmp = "INSERT INTO EMPLOYEES(USER_ID, USER_NAME, PASSWORD, CREATED_AT, MODIFICATE_AT, " +
                "FIRST_NAME, FATHER_LAST_NAME, MOTHER_LAST_NAME, DATE_OF_BIRTH, RFC, CURP)" + 
                "VALUES(uuid(), ?, ?, toUnixTimestamp(now()), { toUnixTimestamp(now()):'Begin'}, ?, ?, ?, ?, ?, ?);";
            string queryLog = "INSERT INTO EMPLOYEES_LOGIN(USER_NAME, PASSWORD, ENABLED) VALUES(?, ?, true);";
            string queryRem = "INSERT INTO EMPLOYEES_ENABLED(USER_NAME, ENABLED) VALUES(?, true);";

            var emp = session.Prepare(queryEmp);
            var log = session.Prepare(queryLog);
            var rem = session.Prepare(queryRem);

            var batch = new BatchStatement()
                           .Add(emp.Bind(employee.User_Name, employee.Password, employee.First_Name, employee.Father_Last_Name,
                           employee.Mother_Last_Name, employee.Date_Of_Birth, employee.RFC, employee.CURP))
                           .Add(log.Bind(employee.User_Name, employee.Password))
                           .Add(rem.Bind(employee.User_Name));

            session.Execute(batch);
        }

        public void Update(EmployeeDTO employee, string username)
        {
            string query = "SELECT ENABLED FROM EMPLOYEES_LOGIN WHERE USER_NAME = '{0}';";
            query = string.Format(query, username);

            var res = session.Execute(query);
            bool enabled;

            foreach (var row in res)
            {
                enabled = row.GetValue<bool>("enabled");

                string queryEmp = string.Format("UPDATE EMPLOYEES SET USER_NAME = '{0}', PASSWORD = '{1}', FIRST_NAME = '{2}', " +
                    "FATHER_LAST_NAME = '{3}', MOTHER_LAST_NAME = '{4}', DATE_OF_BIRTH = '{5}', RFC = '{6}', CURP = '{7}' " +
                    "WHERE USER_ID = {8};",
                    employee.User_Name, employee.Password, employee.First_Name, employee.Father_Last_Name,
                      employee.Mother_Last_Name, employee.Date_Of_Birth, employee.RFC, employee.CURP, employee.User_ID);

                string queryDLog = string.Format("DELETE FROM EMPLOYEES_LOGIN WHERE USER_NAME = '{0}';", username);
                string queryLog = string.Format("INSERT INTO EMPLOYEES_LOGIN(USER_NAME, PASSWORD, ENABLED) " +
                    "VALUES('{0}', '{1}', {2});", employee.User_Name, employee.Password, enabled);

                string queryDEnabled = string.Format("DELETE FROM EMPLOYEES_ENABLED WHERE ENABLED = {0} AND USER_NAME = '{1}';",
                    enabled, username);
                string queryEnabled = string.Format("INSERT INTO EMPLOYEES_ENABLED(USER_NAME, ENABLED) " +
                    "VALUES('{0}', {1});", employee.User_Name, enabled);

                session.Execute(queryEmp);
                session.Execute(queryDLog);
                session.Execute(queryLog);
                session.Execute(queryDEnabled);
                session.Execute(queryEnabled);
            }
        }

        public void Delete(Guid id, string username)
        {
            string queryEnabled = string.Format("SELECT ENABLED FROM EMPLOYEES_LOGIN WHERE USER_NAME = '{0}';", username);

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

            string queryDel = string.Format("DELETE FROM EMPLOYEES WHERE USER_ID = {0};", id);
            string queryDelLog = string.Format("DELETE FROM EMPLOYEES_LOGIN WHERE USER_NAME = '{0}';", username);
            string queryDelEnabled = string.Format("DELETE FROM EMPLOYEES_ENABLED WHERE ENABLED = {0} AND USER_NAME = '{1}';",
               enabled, username);

            session.Execute(queryDel);
            session.Execute(queryDelLog);
            session.Execute(queryDelEnabled);
        }

        public List<EmployeeDTO> Read()
        {
            string query = "SELECT * FROM EMPLOYEES;";
            session = cluster.Connect(dbKeyspace);
            IEnumerable<EmployeeDTO> employees;

            try
            {
                employees = mapper.Fetch<EmployeeDTO>(query);
            }
            catch (Exception e)
            {
                return null;
            }

            return employees.ToList();
        }

        public void Enabled(string username, bool enabled)
        {
            string queryLog = "UPDATE EMPLOYEES_LOGIN SET ENABLED = {0} WHERE USER_NAME = '{1}';";
            queryLog = string.Format(queryLog, enabled, username);
            string queryRem1 = "DELETE FROM EMPLOYEES_ENABLED WHERE ENABLED = {0} AND USER_NAME = '{1}';";
            queryRem1 = string.Format(queryRem1, !enabled, username);
            string queryRem2 = "INSERT INTO EMPLOYEES_ENABLED(USER_NAME, ENABLED) VALUES('{0}', {1});";
            queryRem2 = string.Format(queryRem2, username, enabled);

            session.Execute(queryLog);
            session.Execute(queryRem1);
            session.Execute(queryRem2);
        }

        public EmployeeLoginDTO Login(string username, string password)
        {
            string query = "SELECT USER_NAME, PASSWORD, ENABLED FROM EMPLOYEES_LOGIN WHERE USER_NAME = '{0}' " +
                "AND PASSWORD = '{1}';";
            query = string.Format(query, username, password);

            EmployeeLoginDTO user;            
            try
            {
                user = mapper.Single<EmployeeLoginDTO>(query);
            }
            catch (Exception e)
            {
                return null;
            }

            return user;
        }

        public List<string> ReadAllDisable()
        {
            string query = "SELECT USER_NAME FROM EMPLOYEES_ENABLED WHERE ENABLED = FALSE;";

            IEnumerable<string> employeesDisable;
            try
            {
                employeesDisable = mapper.Fetch<string>(query);
            }
            catch (Exception e)
            {
                return null;
            }

            return employeesDisable.ToList();
        }

        public bool UserExists(string username)
        {
            string query = "SELECT COUNT(USER_NAME) FROM EMPLOYEES_LOGIN WHERE USER_NAME = '{0}';";
            query = string.Format(query, username);

            var res = session.Execute(query);
            Int64 isExisting = -1;

            foreach (var row in res)
            {
                isExisting = row.GetValue<Int64>("system.count(user_name)");
            }

            if (isExisting > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
