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
    class ContractMapper
    {
        public static ContractDTO CreateDTO(ContractForm entity)
        {
            ContractDTO result = new ContractDTO()
            {
                Contract_ID = entity.ContractID,
                Client_ID = entity.ClientID,
                Meter_Serial_Number = entity.MeterSerialNumber,
                Service_Number = Convert.ToInt64(entity.ServiceNumber),
                State = entity.State,
                City = entity.City,
                Suburb = entity.Suburb,
                Street = entity.Street,
                Number = entity.Number,
                Postal_Code = entity.PostalCode,
                Service = entity.Service,
                First_Name = entity.FirstName,
                Father_Last_Name = entity.FatherLastName,
                Mother_Last_Name = entity.MotherLastName,
                Start_Period_Date = DateUtils.ToLocalDate(entity.StartPeriodDate)
            };
            return result;
        }
    }
}
