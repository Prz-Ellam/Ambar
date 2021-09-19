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
        // CRUD
        public void Create(EmployeeDTO employee)
        {
            string query = "INSERT INTO EMPLOYEES() VALUES()";
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
