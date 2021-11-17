using Ambar.Common;
using Ambar.Model.DTO;
using Ambar.ViewController.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambar.Model.AmbarMapper
{
    class ClientMapper
    {
        public static ClientDTO CreateDTO(ClientForm entity)
        {
            ClientDTO result = new ClientDTO()
            {
                User_ID = entity.ID,
                First_Name = entity.FirstName,
                Father_Last_Name = entity.FatherLastName,
                Mother_Last_Name = entity.MotherLastName,
                Date_Of_Birth = DateUtils.ToLocalDate(entity.DateOfBirth),
                Emails = entity.Emails,
                CURP = entity.CURP,
                Gender = entity.Gender,
                User_Name = entity.Username,
                Password = entity.Password,
            };
            return result;
        }
    }
}
