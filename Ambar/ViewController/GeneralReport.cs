using Ambar.Common;
using Ambar.Model.DAO;
using Ambar.Model.DTO;
using Ambar.Properties;
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
    public partial class GeneralReport : Form
    {
        private ReceiptDAO receiptDAO = new ReceiptDAO();
        private DateDAO dateDAO = new DateDAO();
        public GeneralReport()
        {
            InitializeComponent();
        }

        private void GeneralReport_Load(object sender, EventArgs e)
        {
            cbService.SelectedIndex = 0;
        }

        private void cbService_SelectedIndexChanged(object sender, EventArgs e)
        {
            DateChange();
        }

        private void dtpYear_ValueChanged(object sender, EventArgs e)
        {
            DateChange();
        }

        private void DateChange()
        {
            cbPeriod.Items.Clear();

            switch (cbService.SelectedIndex)
            {
                case 1:
                {
                    string[] bimesters = new string[] { "TODOS", "ENERO-FEBRERO", "MARZO-ABRIL", "MAYO-JUNIO", 
                        "JULIO-AGOSTO", "SEPTIEMBRE-OCTUBRE", "NOVIEMBRE-DICIEMBRE" };
                    int[] numbers = new int[] { -1, 1, 3, 5, 7, 9, 11 };

                    for (int i = 0; i < bimesters.Length; i++)
                    {
                        cbPeriod.Items.Add(new ComboBoxItem(bimesters[i], numbers[i]));
                    }

                    cbPeriod.SelectedIndex = 0;
                    break;
                }
                case 2:
                {
                    string[] months = new string[] { "TODOS", "ENERO", "FEBRERO", "MARZO", "ABRIL", "MAYO", "JUNIO", 
                        "JULIO", "AGOSTO", "SEPTIEMBRE", "OCTUBRE", "NOVIEMBRE", "DICIEMBRE" };
                    int[] numbers = new int[] { -1, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };

                    for (int i = 0; i < months.Length; i++)
                    {
                        cbPeriod.Items.Add(new ComboBoxItem(months[i], numbers[i]));
                    }

                    cbPeriod.SelectedIndex = 0;
                    break;
                }
                default:
                {
                    cbPeriod.SelectedIndex = -1;
                    break;
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (cbPeriod.SelectedIndex < 1 || cbService.SelectedIndex < 1)
            {
                // ERROR
            }

            int year = dtpYear.Value.Year;
            short period = Convert.ToInt16(((ComboBoxItem)cbPeriod.SelectedItem).HiddenValue);
            string service = cbService.SelectedItem.ToString();
            List<GeneralReportDTO> generalReport;
            if (period == -1)
            {
                generalReport = receiptDAO.GeneralReport(year, service);
            }
            else
            {
                generalReport = receiptDAO.GeneralReport(year, period, service);
            }

            dtgGeneralReport.DataSource = generalReport;
        }
    }
}
