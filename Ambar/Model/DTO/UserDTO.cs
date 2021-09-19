using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambar.Model.DTO
{
    class UserDTO
    {
        private Guid user_id;
        private string user_name;
        private string password;
        private string position;
        private bool enabled;
        private DateTime creation_Date;
        private DateTime modification_date;

        public Guid UserID { get => user_id; set => user_id = value; }
        public string UserName { get => user_name; set => user_name = value; }
        public string Password { get => password; set => password = value; }
        public string Position { get => position; set => position = value; }
        public bool Enabled { get => enabled; set => enabled = value; }
        public DateTime CreationDate { get => creation_Date; set => creation_Date = value; }
        public DateTime ModificationDate { get => modification_date; set => modification_date = value; }
    }
}
