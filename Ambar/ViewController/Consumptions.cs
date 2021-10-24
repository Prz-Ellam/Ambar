using Ambar.Model.DAO;
using Ambar.Model.DTO;
using Cassandra;
using CsvHelper;
using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ambar.ViewController
{
    public partial class Consumptions : Form
    {
        private ConsumptionDAO dao = new ConsumptionDAO();
        public Consumptions()
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
            dtgConsumptions.DataSource = dao.ReadConsumptions();
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

            string serviceType = contractDAO.FindServiceType(txtMeterSerialNumber.Text);
            short month = Convert.ToInt16(dtpPeriod.Value.Month);
            LocalDate startPeriod = contractDAO.FindStartPeriodDate(txtMeterSerialNumber.Text);
            int year = dtpPeriod.Value.Year;

            if (serviceType == "Doméstico" && month % 2 == 0)
            {
                month--;
            }

            if (year < startPeriod.Year || (year == startPeriod.Year && month < startPeriod.Month))
            {
                PrintError("NO SE PUEDE CARGAR UN CONSUMO ANTES DEL INICIO DE PERIODO DE COBRO");
            }

            if (dao.ConsumptionExists(txtMeterSerialNumber.Text, dtpPeriod.Value.Year, month))
            {
                PrintError("YA FUE CARGADO UN CONSUMO EN ESTE PERIODO DE COBRO");
                return;
            }

            if (IsDecimalNumber(txtKilowatts.Text))
            {
                PrintError("KILOWATTS CONSUMIDOS SOLO ACEPTA NUMEROS DECIMALES");
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
            dtgConsumptions.DataSource = dao.ReadConsumptions();

            MessageBox.Show("La operación se realizó exitosamente", "", MessageBoxButtons.OK);
        }

        private void btnMassiveCharge_Click(object sender, EventArgs e)
        {
            if (ofnMassive.ShowDialog() == DialogResult.OK)
            {
                switch (ofnMassive.FilterIndex)
                {
                    case 1: // CSV
                    {
                        var reader = File.OpenText(ofnMassive.FileName);
                        CsvReader csvReader = new CsvReader(reader, CultureInfo.InvariantCulture);

                        var consumptionsCSV = csvReader.GetRecords<dynamic>().ToList();

                        foreach (var consumption in consumptionsCSV)
                        {
                            decimal a = consumption;
                        }


                        break;
                    }
                    case 2: // Excel
                    {
                        FileStream reader = new FileStream(ofnMassive.FileName, FileMode.Open, FileAccess.Read);
                        IExcelDataReader xlsxReader = ExcelReaderFactory.CreateReader(reader);

                        DataSet dataSetXLSX = xlsxReader.AsDataSet(new ExcelDataSetConfiguration()
                        {
                            ConfigureDataTable = (tableReader) => new ExcelDataTableConfiguration()
                            {
                                UseHeaderRow = true
                            }
                        });

                        //dataGridView1.DataSource = dataSetXLSX.Tables[0];

                        reader.Close();
                        break;
                    }
                }
            }
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

        private bool IsDecimalNumber(string number)
        {
            string res = @"(?<=^| )\d+(\.\d+)?(?=$| )|(?<=^| )\.\d+(?=$| )";
            Regex rx = new Regex(res, RegexOptions.Compiled | RegexOptions.IgnoreCase);

            return rx.IsMatch(number);
        }

    }
}
