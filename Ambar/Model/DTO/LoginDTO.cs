using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambar.Model.DTO
{
    class LoginDTO
    {
        protected string user_name;
        protected string password;
        public string User_name { get => user_name; set => user_name = value; }
        public string Password { get => password; set => password = value; }
    }
}
