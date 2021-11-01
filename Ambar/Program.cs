using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ambar.ViewController;
using Ambar.Model.DAO;
using Ambar.Model.DTO;
using Ambar.Properties;
using System.IO;

namespace Ambar
{
    static class Program
    {
        [STAThread]

        // TODO: Si se elimina un empleado o cliente, tambien debe desaparecer del enabling
        // Borrar y actualizar tambien en remember users
        static void Main()
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("es-US");

            //new TestDAO().Restart();

            DateDAO dateDAO = new DateDAO();
            if (!dateDAO.DateExists())
            {
                dateDAO.Create();
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Login());
        }
    }
}
