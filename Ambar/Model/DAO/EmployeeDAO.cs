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

        public void Create(EmployeeDTO employee)
        {
            string query = string.Format("INSERT INTO EMPLOYEES(USER_ID, FIRST_NAME, FATHER_LAST_NAME, MOTHER_LAST_NAME, DATE_OF_BIRTH, CURP, RFC, CREATION_DATE, MODIFICATION_DATE) " +
                "VALUES({0},'{1}','{2}','{3}','{4}','{5}','{6}', toUnixTimestamp(now())",
                employee.User_ID, employee.First_Name, employee.Father_Last_Name, employee.Mother_Last_Name, 
                employee.Date_Of_Birth, employee.CURP, employee.RFC);
            query += ", {toUnixTimestamp(now()):'Begin'});";

            session.Execute(query);

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

        public void Update()
        {

        }

        public void Delete()
        {

        }

    }
}
