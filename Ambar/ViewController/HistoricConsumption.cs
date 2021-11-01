using Ambar.Model.DAO;
using Ambar.Model.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ambar.ViewController
{
    public partial class HistoricConsumption : Form
    {
        ReceiptDAO receiptDAO = new ReceiptDAO();
        public HistoricConsumption()
        {
            InitializeComponent();
        }

        private void HistoricConsumption_Load(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            int year = dtpYear.Value.Year;
            string filter = txtFilter.Text;

            List<HistoricConsumptionDTO> historicConsumption;
            if (rbMeterSerialNumber.Checked)
            {
                historicConsumption = receiptDAO.HistoricConsumption(year, filter);
            }
            else if (rbServiceNumber.Checked)
            {
                historicConsumption = receiptDAO.HistoricConsumption(year, Convert.ToInt32(filter));
            }
            else
            {
                // ERROR: Todo murio
                return;
            }

            dtgHistoricConsumption.DataSource = historicConsumption;
        }
    }
}
