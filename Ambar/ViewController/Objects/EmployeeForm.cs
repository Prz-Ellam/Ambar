using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambar.ViewController
{
    class EmployeeForm
    {
        private Guid id;
        private string firstName;
        private string fatherLastName;
        private string motherLastName;
        private DateTime dateOfBirth;
        private string rfc;
        private string curp;
        private string username;
        private string password;
        private string confirmPassword;

        public Guid ID { get => id; set => id = value; }
        public string FirstName { get => firstName; set => firstName = value; }
        public string FatherLastName { get => fatherLastName; set => fatherLastName = value; }
        public string MotherLastName { get => motherLastName; set => motherLastName = value; }
        public DateTime DateOfBirth { get => dateOfBirth; set => dateOfBirth = value; }
        public string RFC { get => rfc; set => rfc = value; }
        public string CURP { get => curp; set => curp = value; }
        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }
        public string ConfirmPassword { get => confirmPassword; set => confirmPassword = value; }
    }
}
