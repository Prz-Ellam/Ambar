using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambar.Model.DTO
{
    class EmployeeLoginDTO : LoginDTO
    {
        private bool enabled;
        public bool Enabled { get => enabled; set => enabled = value; }
    }
}
