using Ambar.Model.DTO;
using Ambar.ViewController.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambar.Model.AmbarMapper
{
    class RateMapper
    {
        public static RateDTO CreateDTO(RateForm entity)
        {
            RateDTO result = new RateDTO()
            {
                Rate_ID = entity.ID,
                Basic_Level = entity.BasicLevel,
                Intermediate_Level = entity.IntermediateLevel,
                Surplus_Level = entity.SurplusLevel,
                Service = entity.ServiceType,
                Year = entity.Year,
                Month = entity.Month
            };
            return result;
        }
    }
}
