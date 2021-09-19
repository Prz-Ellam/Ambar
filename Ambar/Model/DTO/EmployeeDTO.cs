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
        private DateTime date_Of_Brith;
        private string _RFC;
        private string _CURP;

        public Guid User_ID { get => user_ID; set => user_ID = value; }
        public string Name { get => first_Name; set => first_Name = value; }
        public string Father_Last_Name { get => father_Last_Name; set => father_Last_Name = value; }
        public string Mother_Last_Name { get => mother_Last_Name; set => mother_Last_Name = value; }
        public DateTime Date_Of_Brith { get => date_Of_Brith; set => date_Of_Brith = value; }
        public string RFC { get => _RFC; set => _RFC = value; }
        public string CURP { get => _CURP; set => _CURP = value; }
    }
}
