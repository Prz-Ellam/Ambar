using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambar.Model.DTO
{
    class AdministratorDTO
    {
		private Guid user_id;
		private string user_name;
		private string password;
		private DateTimeOffset creation_date;
		private Dictionary<DateTimeOffset, string> modification_date;

		public Guid User_ID { get => user_id; set => user_id = value; }
		public string User_Name { get => user_name; set => user_name = value; }
		public string Password { get => password; set => password = value; }
		public DateTimeOffset Creation_Date { get => creation_date; set => creation_date = value; }
		public Dictionary<DateTimeOffset, string> Modification_Date { get => modification_date; set => modification_date = value; }

	}
}
