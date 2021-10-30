using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ambar.ViewController;
using Ambar.Model.DAO;
using Ambar.Model.DTO;
using Ambar.Properties;

namespace Ambar
{
    static class Program
    {
        [STAThread]

        // TODO: Si se elimina un empleado o cliente, tambien debe desaparecer del enabling
        // Borrar y actualizar tambien en remember users
        static void Main()
        {
            if (Settings.Default.DateOffset == string.Empty)
            {
                Settings.Default.DateOffset = DateTime.Now.ToString();
                Settings.Default.Save();
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Login());
        }
    }
}
