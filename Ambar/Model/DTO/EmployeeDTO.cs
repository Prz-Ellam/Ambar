using Cassandra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambar.Model.DTO
{
    class EmployeeDTO
    {
        private Guid user_ID;
        private string first_Name;
        private string father_Last_Name;
        private string mother_Last_Name;
        private LocalDate date_Of_Birth;
        private string rfc;
        private string curp;

        public Guid User_ID { get => user_ID; set => user_ID = value; }
        public string First_Name { get => first_Name; set => first_Name = value; }
        public string Father_Last_Name { get => father_Last_Name; set => father_Last_Name = value; }
        public string Mother_Last_Name { get => mother_Last_Name; set => mother_Last_Name = value; }
        public LocalDate Date_Of_Birth { get => date_Of_Birth; set => date_Of_Birth = value; }
        public string RFC { get => rfc; set => rfc = value; }
        public string CURP { get => curp; set => curp = value; }
    }
}
