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
    class EmployeeDAO : CassandraConnection, IEnableable
    {

        public void Create(EmployeeDTO employee)
        {
            string queryID = @"INSERT INTO EMPLOYEES(USER_ID, USER_NAME, PASSWORD, CREATED_AT, MODIFICATE_AT, 
                            FIRST_NAME, FATHER_LAST_NAME, MOTHER_LAST_NAME, DATE_OF_BIRTH, RFC, CURP) 
                            VALUES(uuid(), ?, ?, toUnixTimestamp(now()), [ toUnixTimestamp(now()) ], ?, ?, ?, ?, ?, ?);";
            string queryLog = "INSERT INTO EMPLOYEES_LOGIN(USER_NAME, PASSWORD, ENABLED) VALUES(?, ?, TRUE);";
            string queryEn = "INSERT INTO EMPLOYEES_ENABLED(USER_NAME, ENABLED) VALUES(?, TRUE);";

            var id = session.Prepare(queryID);
            var log = session.Prepare(queryLog);
            var en = session.Prepare(queryEn);

            var batch = new BatchStatement()
                        .Add(id.Bind(employee.User_Name, employee.Password, employee.First_Name, employee.Father_Last_Name,
                        employee.Mother_Last_Name, employee.Date_Of_Birth, employee.RFC, employee.CURP))
                        .Add(log.Bind(employee.User_Name, employee.Password))
                        .Add(en.Bind(employee.User_Name));

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
                    "FATHER_LAST_NAME = '{3}', MOTHER_LAST_NAME = '{4}', DATE_OF_BIRTH = '{5}', RFC = '{6}', CURP = '{7}'," +
                    "MODIFICATE_AT = MODIFICATE_AT + [ toUnixTimestamp(now()) ] " +
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

            bool enabled;
            try
            {
                enabled = mapper.Single<bool>(queryEnabled);
            }
            catch (Exception e)
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

        public List<EmployeeDTO> ReadAll()
        {
            string query = @"SELECT USER_ID, USER_NAME, PASSWORD, CREATED_AT, MODIFICATE_AT, FIRST_NAME, 
                            FATHER_LAST_NAME, MOTHER_LAST_NAME, DATE_OF_BIRTH, RFC, CURP FROM EMPLOYEES;";

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
            string query = @"SELECT USER_NAME, PASSWORD, ENABLED FROM EMPLOYEES_LOGIN WHERE USER_NAME = '{0}' 
                            AND PASSWORD = '{1}';";
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

        public bool EmployeeExists(string username)
        {
            string query = "SELECT COUNT(USER_NAME) FROM EMPLOYEES_LOGIN WHERE USER_NAME = '{0}';";
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

            return isExisting;
        }

    }
}
