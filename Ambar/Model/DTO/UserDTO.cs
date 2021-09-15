using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambar.Model.DTO
{
    class UserDTO
    {
        public Guid user_id { get; set; }
        public string user_name { get; set; }
        public string password { get; set; }
        public string position { get; set; }
        public short enabled { get; set; }
        public DateTime creation_Date { get; set; }
        public DateTime modification_date { get; set; }
    }
}
