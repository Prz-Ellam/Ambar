using Ambar.Model.DAO;
using Ambar.Model.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ambar.ViewController
{
    public partial class Consumos : Form
    {
        private ConsumptionDAO dao = new ConsumptionDAO();
        public Consumos()
        {
            InitializeComponent();
        }

        private void Consumos_Load(object sender, EventArgs e)
        {
            ContractDAO contractDAO = new ContractDAO();
            List<ContractDTO> contracts = contractDAO.ReadContracts();
            List<ContractDTG> dtgContracts = new List<ContractDTG>();
            foreach (var contract in contracts)
            {
                dtgContracts.Add(new ContractDTG(contract));
            }
            this.dtgContracts.DataSource = dtgContracts;
        }

        private void FillDataGridView()
        {
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (txtMeterSerialNumber.Text == string.Empty || txtKilowatts.Text == string.Empty)
            {
                PrintError("TODOS LOS CAMPOS SON OBLIGATORIOS");
                return;
            }

            ContractDAO contractDAO = new ContractDAO();

            if (!contractDAO.ContractExists(txtMeterSerialNumber.Text))
            {
                PrintError("EL NUMERO DE MEDIDOR NO EXISTE ACTUALMENTE");
                return;
            }

            string serviceType = contractDAO.FindServiceType(Convert.ToInt32(txtMeterSerialNumber.Text));
            short month = Convert.ToInt16(dtpPeriod.Value.Month);

            if (serviceType == "Doméstico" && month % 2 == 0)
            {
                month--;
            }

            if (dao.ConsumptionExists(txtMeterSerialNumber.Text, dtpPeriod.Value.Year, month))
            {
                PrintError("YA FUE CARGADO UN CONSUMO EN ESTE PERIODO DE COBRO");
                return;
            }

            ConsumptionDTO consumption = new ConsumptionDTO();
            consumption.Consumption_ID = Guid.NewGuid();
            consumption.Meter_Serial_Number = txtMeterSerialNumber.Text;
            consumption.Service_Number = contractDAO.ReadServiceNumberByMeterSerialNumber(consumption.Meter_Serial_Number);
            consumption.Total_KW = Convert.ToDecimal(txtKilowatts.Text);

            decimal kwBasic = 0;
            decimal kwInt = 0;
            decimal kWSur = 0;
            PaymentBreakdown(consumption.Total_KW, ref kwBasic, ref kwInt, ref kWSur);

            consumption.Basic_KW = kwBasic;
            consumption.Intermediate_KW = kwInt;
            consumption.Surplus_KW = kWSur;

            consumption.Month = month;
            consumption.Year = dtpPeriod.Value.Year;

            dao.Create(consumption);
            MessageBox.Show("La operación se realizó exitosamente", "", MessageBoxButtons.OK);

        }

        static void PaymentBreakdown(decimal value, ref decimal kwBasic, ref decimal kwInt, ref decimal kwExc)
        {
            decimal basic = Convert.ToDecimal(ConfigurationManager.AppSettings["Basic_kW"].ToString());
            decimal intermediate = Convert.ToDecimal(ConfigurationManager.AppSettings["Intermediate_kW"].ToString());

            decimal offset = value - basic;

            if (offset <= 0)
            {
                kwBasic = value;
                return;
            }

            kwBasic = basic;
            offset -= intermediate;
            value -= basic;

            if (offset <= 0)
            {
                kwInt = value;
                return;
            }

            kwInt = intermediate;
            value -= intermediate;
            kwExc = value;

        }

        private void PrintError(string error)
        {
            pbWarningIcon.Visible = true;
            lblError.Visible = true;
            lblError.Text = error;
        }

    }
}
