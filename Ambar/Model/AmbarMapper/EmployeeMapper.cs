using Ambar.Common;
using Ambar.Model.DTO;
using Ambar.ViewController;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambar.Model.AmbarMapper
{
    class EmployeeMapper
    {
        public static EmployeeDTO CreateDTO(EmployeeForm entity)
        {
            EmployeeDTO result = new EmployeeDTO()
            {
                User_ID = entity.ID,
                First_Name = entity.FirstName,
                Father_Last_Name = entity.FatherLastName,
                Mother_Last_Name = entity.MotherLastName,
                Date_Of_Birth = DateUtils.ToLocalDate(entity.DateOfBirth),
                RFC = entity.RFC,
                CURP = entity.CURP,
                User_Name = entity.Username,
                Password = entity.Password,
            };
            return result;
        }
    }
}
