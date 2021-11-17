using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambar.Model.DAO
{
    interface IEnableable
    {
        void Enabled(string username, bool enabled);
    }
}
