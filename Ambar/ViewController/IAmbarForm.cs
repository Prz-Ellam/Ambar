using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambar.ViewController
{
    public interface IAmbarForm
    {
        void FillDataGridView();
        void PrintError(string error);
        void ClearForm();
    }
}
