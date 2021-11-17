using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambar.ViewController.Objects
{
    class ClientForm
    {
        private Guid id;
        private string username;
        private string password;
        private string confirmPassword;
        private string firstName;
        private string fatherLastName;
        private string motherLastName;
        private DateTime dateOfBirth;
        private List<string> emails = new List<string>();
        private string curp;
        private string gender;

        public Guid ID { get => id; set => id = value; }
        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }
        public string ConfirmPassword { get => confirmPassword; set => confirmPassword = value; }

        public string FirstName { get => firstName; set => firstName = value; }
        public string FatherLastName { get => fatherLastName; set => fatherLastName = value; }
        public string MotherLastName { get => motherLastName; set => motherLastName = value; }
        public DateTime DateOfBirth { get => dateOfBirth; set => dateOfBirth = value; }
        public List<string> Emails { get => emails; set => emails = value; }
        public string CURP { get => curp; set => curp = value; }
        public string Gender { get => gender; set => gender = value; }
    }
}
