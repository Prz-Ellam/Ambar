using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambar.Model.DTO
{
    public class UserDTO
    {
        private Guid user_id;
        private string user_name;
        private string password;
        private string position;
        private bool enabled;

        public Guid User_ID { get => user_id; set => user_id = value; }
        public string User_Name { get => user_name; set => user_name = value; }
        public string Password { get => password; set => password = value; }
        public string Position { get => position; set => position = value; }
        public bool Enabled { get => enabled; set => enabled = value; }
    }
}
