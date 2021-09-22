using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambar.Model.DTO
{
    class RateDTO
    {
        // Fecha
        // Tipo de servicio
        // Monto o porcentual
        private DateTime period;
        private string service;
        private string typeOfRate;
        private decimal basicLevel;
        private decimal intermediateLevel;
        private decimal surplusLevel;
    }
}
