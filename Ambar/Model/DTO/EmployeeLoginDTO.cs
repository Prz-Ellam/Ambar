using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambar.Model.DTO
{
    class EmployeeLoginDTO
    {
        private string user_name;
        private string password;
        private bool enabled;
        public string User_name { get => user_name; set => user_name = value; }
        public string Password { get => password; set => password = value; }
        public bool Enabled { get => enabled; set => enabled = value; }
    }
}
