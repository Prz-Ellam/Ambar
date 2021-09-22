using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ambar.Model.DTO;
using Cassandra.Mapping;

namespace Ambar.Model.DAO
{
    class EmployeeDAO : CassandraConnection
    {

        private static EmployeeDAO instance;

        private EmployeeDAO()
        {
            Connect();
        }

        public static EmployeeDAO GetInstance()
        {
            if (instance == null)
            {
                instance = new EmployeeDAO();
            }
            return instance;
        }

        public void Create(EmployeeDTO employee, Guid userID)
        {
            string query = String.Format("INSERT INTO EMPLOYEES(USER_ID, NAME, FATHER_LAST_NAME, MOTHER_LAST_NAME, DATE_OF_BIRTH, CURP, RFC) " +
                "VALUES({0},'{1}','{2}','{3}','{4}','{5}','{6}')", userID, employee.Name, employee.Father_Last_Name,
                employee.Mother_Last_Name, employee.Date_Of_Brith.ToString("yyyy-MM-dd HH:mm:ss") + "+0000", employee.CURP, employee.RFC);

            session.Execute(query);

        }

        public EmployeeDTO Read()
        {
            return null;
        }

        public List<EmployeeDTO> ReadAll()
        {
            Connect();
            string query = "SELECT * FROM EMPLOYEES;";
            session = cluster.Connect(dbKeyspace);
            IMapper mapper = new Mapper(session);

            IEnumerable<EmployeeDTO> employees = mapper.Fetch<EmployeeDTO>(query);
            Disconnect();

            return employees.ToList();
        }

        public void Update()
        {

        }

        public void Delete()
        {

        }

    }
}
