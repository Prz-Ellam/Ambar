using Ambar.Model.DTO;
using Cassandra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambar.ViewController
{
    class EmployeeDTG
    {
        private Guid user_id;
        private string user_name;
        private string password;
        private string first_name;
        private string father_last_name;
        private string mother_last_name;
        private LocalDate date_of_birth;
        private string rfc;
        private string curp;

        public EmployeeDTG(EmployeeDTO dto)
        {
            user_id = dto.User_ID;
            user_name = dto.User_Name;
            password = dto.Password;
            first_name = dto.First_Name;
            father_last_name = dto.Father_Last_Name;
            mother_last_name = dto.Mother_Last_Name;
            date_of_birth = dto.Date_Of_Birth;
            rfc = dto.RFC;
            curp = dto.CURP;
        }

        public Guid User_ID { get => user_id; set => user_id = value; }
        public string User_Name { get => user_name; set => user_name = value; }
        public string Password { get => password; set => password = value; }
        public string First_Name { get => first_name; set => first_name = value; }
        public string Father_Last_Name { get => father_last_name; set => father_last_name = value; }
        public string Mother_Last_Name { get => mother_last_name; set => mother_last_name = value; }
        public LocalDate Date_Of_Birth { get => date_of_birth; set => date_of_birth = value; }
        public string RFC { get => rfc; set => rfc = value; }
        public string CURP { get => curp; set => curp = value; }
    }
}
