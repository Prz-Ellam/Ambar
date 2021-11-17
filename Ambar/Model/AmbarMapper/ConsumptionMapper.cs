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
    class ConsumptionMapper
    {
        public static ConsumptionDTO CreateDTO(ConsumptionForm entity)
        {
            decimal basicKW = 0;
            decimal intKW = 0;
            decimal surKW = 0;
            NumericUtils.PaymentBreakdown(entity.Kilowatts, ref basicKW, ref intKW, ref surKW);

            ConsumptionDTO result = new ConsumptionDTO()
            {
                Consumption_ID = entity.ID,
                Contract_ID = entity.ContractID,
                Meter_Serial_Number = entity.MeterSerialNumber,
                Service_Number = Convert.ToInt64(entity.ServiceNumber),
                Basic_KW = basicKW,
                Intermediate_KW = intKW,
                Surplus_KW = surKW,
                Total_KW = entity.Kilowatts,
                Year = entity.Period.Year,
                Month = entity.Period.Month,
                Day = DateUtils.ClampDay(entity.Period.Year, entity.Period.Month, entity.ContractStartPeriod.Day)
            };
            return result;
        }
    }
}
