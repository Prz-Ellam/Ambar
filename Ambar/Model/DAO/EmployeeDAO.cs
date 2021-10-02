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
            string queryEmp = "INSERT INTO EMPLOYEES(USER_ID, USER_NAME, PASSWORD, CREATION_DATE, MODIFICATION_DATE, " +
                "FIRST_NAME, FATHER_LAST_NAME, MOTHER_LAST_NAME, DATE_OF_BIRTH, RFC, CURP)" + 
                "VALUES(uuid(), ?, ?, toUnixTimestamp(now()), { toUnixTimestamp(now()):'Begin'}, ?, ?, ?, ?, ?, ?);";
            string queryLog = "INSERT INTO EMPLOYEES_LOGIN(USER_NAME, PASSWORD, ENABLED) VALUES(?, ?, true);";
            string queryRem = "INSERT INTO EMPLOYEES_ENABLED(USER_NAME, PASSWORD, ENABLED) VALUES(?, ?, true);";

            var emp = session.Prepare(queryEmp);
            var log = session.Prepare(queryLog);
            var rem = session.Prepare(queryRem);

            var batch = new BatchStatement()
                           .Add(emp.Bind(employee.User_Name, employee.Password, employee.First_Name, employee.Father_Last_Name,
                           employee.Mother_Last_Name, employee.Date_Of_Birth, employee.RFC, employee.CURP))
                           .Add(log.Bind(employee.User_Name, employee.Password))
                           .Add(rem.Bind(employee.User_Name, employee.Password));

            session.Execute(batch);
        }

        public EmployeeDTO Read()
        {
            return null;
        }

        public List<EmployeeDTO> ReadAll()
        {
            string query = "SELECT * FROM EMPLOYEES;";
            session = cluster.Connect(dbKeyspace);
            IMapper mapper = new Mapper(session);

            IEnumerable<EmployeeDTO> employees = mapper.Fetch<EmployeeDTO>(query);

            return employees.ToList();
        }

        public void Update(EmployeeDTO employee, string username)
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

            string queryEmp = string.Format("UPDATE EMPLOYEES SET USER_NAME = '{0}', PASSWORD = '{1}', FIRST_NAME = '{2}', " +
                "FATHER_LAST_NAME = '{3}', MOTHER_LAST_NAME = '{4}', DATE_OF_BIRTH = '{5}', RFC = '{6}', CURP = '{7}' " +
                "WHERE USER_ID = {8};"
                , employee.User_Name, employee.Password, employee.First_Name, employee.Father_Last_Name,
                  employee.Mother_Last_Name, employee.Date_Of_Birth, employee.RFC, employee.CURP, employee.User_ID);

            string queryDelLog = string.Format("DELETE FROM EMPLOYEES_LOGIN WHERE USER_NAME = '{0}';", username);

            string queryLog = string.Format("INSERT INTO EMPLOYEES_LOGIN(USER_NAME, PASSWORD, ENABLED) " +
                "VALUES('{0}', '{1}', {2});", employee.User_Name, employee.Password, enabled);

            string queryDelEnabled = string.Format("DELETE FROM EMPLOYEES_ENABLED WHERE ENABLED = {0} AND USER_NAME = '{1}';",
                enabled, username);

            string queryInEnabled = string.Format("INSERT INTO EMPLOYEES_ENABLED(USER_NAME, PASSWORD, ENABLED) " +
                "VALUES('{0}', '{1}', {2});", employee.User_Name, employee.Password, enabled);

            session.Execute(queryEmp);
            session.Execute(queryDelLog);
            session.Execute(queryLog);
            session.Execute(queryDelEnabled);
            session.Execute(queryInEnabled);

            //var emp = session.Prepare(queryEmp);
            //var delLog = session.Prepare(queryDelLog);
            //var log = session.Prepare(queryLog);
            //var delEnabled = session.Prepare(queryDelEnabled);
            //var InEnabled = session.Prepare(queryInEnabled);
            //
            //var batch = new BatchStatement()
            //              .Add(emp.Bind(employee.User_Name, employee.Password, employee.First_Name, employee.Father_Last_Name,
            //              employee.Mother_Last_Name, employee.Date_Of_Birth, employee.RFC, employee.CURP, employee.User_ID))
            //              .Add(delLog.Bind(username))
            //              .Add(log.Bind(employee.User_Name, employee.Password, enabled))
            //              .Add(delEnabled.Bind(enabled, username))
            //              .Add(InEnabled.Bind(employee.User_Name, employee.Password, enabled));

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

        public void Enabled(string username, bool enabled)
        {
            string query = string.Format("SELECT PASSWORD FROM EMPLOYEES_LOGIN WHERE USER_NAME = " +
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

            string queryLog = string.Format("UPDATE EMPLOYEES_LOGIN SET ENABLED = {0} WHERE USER_NAME = '{1}';",
                enabled, username);
            string queryRem1 = string.Format("DELETE FROM EMPLOYEES_ENABLED WHERE ENABLED = {0} AND USER_NAME = '{1}';",
                !enabled, username);
            string queryRem2 = string.Format("INSERT INTO EMPLOYEES_ENABLED(USER_NAME, PASSWORD, ENABLED) " +
                "VALUES('{0}', '{1}', {2});", username, password, enabled);

            session.Execute(queryLog);
            session.Execute(queryRem1);
            session.Execute(queryRem2);

            //var log = session.Prepare(queryLog);
            //var rem1 = session.Prepare(queryRem1);
            //var rem2 = session.Prepare(queryRem2);
            //
            //var batch = new BatchStatement()
            //              .Add(log.Bind(enabled, username))
            //              .Add(rem1.Bind(enabled, username))
            //              .Add(rem2.Bind(username, password, enabled));
            //
            //session.Execute(batch);
        }


        public (EmployeeLoginDTO, bool) Login(string username, string password)
        {
            string query = string.Format("SELECT USER_NAME, PASSWORD, ENABLED FROM EMPLOYEES_LOGIN WHERE USER_NAME = " +
                "'{0}';", username);

            IMapper mapper = new Mapper(session);
            EmployeeLoginDTO user;

            try
            {
                user = mapper.Single<EmployeeLoginDTO>(query);

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

        public List<string> ReadAllDisable()
        {
            string query = "SELECT USER_NAME FROM EMPLOYEES_ENABLED WHERE ENABLED = false;";

            IMapper mapper = new Mapper(session);
            IEnumerable<string> employeesDisable;

            try
            {
                employeesDisable = mapper.Fetch<string>(query);
            }
            catch (InvalidOperationException e)
            {
                return null;
            }

            return employeesDisable.ToList();
        }

        public bool UserExists(string username)
        {
            string query = string.Format("SELECT COUNT(USER_NAME) FROM EMPLOYEES_LOGIN WHERE USER_NAME = '{0}';", username);

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

    }
}
