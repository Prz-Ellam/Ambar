using Cassandra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambar.Model.DTO
{
    class ClientDTO
    {
        private Guid user_id;
        private string user_name;
        private string password;
        private DateTimeOffset creation_date;
        private Dictionary<DateTimeOffset, string> modification_date;
        private string first_name;
        private string father_last_name;
        private string mother_last_name;
        private LocalDate date_of_birth;
        private List<string> email = new List<string>();
        private string curp;
        private string gender;

        public Guid User_ID { get => user_id; set => user_id = value; }
        public string User_Name { get => user_name; set => user_name = value; }
        public string Password { get => password; set => password = value; }
        public DateTimeOffset Creation_date { get => creation_date; set => creation_date = value; }
        public Dictionary<DateTimeOffset, string> Modification_date { get => modification_date; set => modification_date = value; }
        public string First_Name { get => first_name; set => first_name = value; }
        public string Father_Last_Name { get => father_last_name; set => father_last_name = value; }
        public string Mother_Last_Name { get => mother_last_name; set => mother_last_name = value; }
        public LocalDate Date_Of_Birth { get => date_of_birth; set => date_of_birth = value; }
        public List<string> Email { get => email; set => email = value; }
        public string CURP { get => curp; set => curp = value; }
        public string Gender { get => gender; set => gender = value; }
    }
}
