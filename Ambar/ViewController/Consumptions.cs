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
using Ambar.Common;
using Ambar.Properties;

namespace Ambar.ViewController
{
    public partial class Consumptions : Form
    {
        private ConsumptionDAO dao = new ConsumptionDAO();
        private ContractDAO contractDAO = new ContractDAO();
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
            dtpPeriod.MinDate = Convert.ToDateTime(Settings.Default.DateOffset).AddMonths(1);
        }

        private void FillDataGridView()
        {
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (!contractDAO.ContractExists(txtMeterSerialNumber.Text))
            {
                PrintError("EL NUMERO DE MEDIDOR NO EXISTE ACTUALMENTE");
                return;
            }

            string serviceType = contractDAO.FindServiceType(txtMeterSerialNumber.Text);
            short month = Convert.ToInt16(dtpPeriod.Value.Month);

            LocalDate startDate = contractDAO.FindStartPeriodDate(txtMeterSerialNumber.Text);
            int startPeriod;
            int actualPeriod;
            int startYear = startDate.Year;
            int actualYear = dtpPeriod.Value.Year;

            if (serviceType == "Domestico" || serviceType == "Doméstico")
            {
                startPeriod = (startDate.Month - 1) / 2;
                actualPeriod = (month - 1) / 2;
            }
            else if (serviceType == "Industrial")
            {
                startPeriod = startDate.Month - 1;
                actualPeriod = month - 1;
            }
            else
            {
                return; // ERROR
            }

            if (actualYear < startYear || (actualYear == startYear && actualPeriod < startPeriod))
            {
                PrintError("NO SE PUEDE CARGAR UN CONSUMO ANTES DEL INICIO DE PERIODO DE COBRO");
                return;
            }

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
            consumption.Meter_Serial_Number = StringUtils.GetText(txtMeterSerialNumber.Text);
            consumption.Service_Number = contractDAO.ReadServiceNumberByMeterSerialNumber(consumption.Meter_Serial_Number);
            consumption.Total_KW = nudKilowatts.Value;

            decimal kwBasic = 0;
            decimal kwInt = 0;
            decimal kWSur = 0;
            PaymentBreakdown(consumption.Total_KW, ref kwBasic, ref kwInt, ref kWSur);

            consumption.Basic_KW = kwBasic;
            consumption.Intermediate_KW = kwInt;
            consumption.Surplus_KW = kWSur;
            consumption.Day = Convert.ToInt16(startDate.Day);
            consumption.Month = month;
            consumption.Year = dtpPeriod.Value.Year;

            if (consumption.Meter_Serial_Number == string.Empty)
            {
                PrintError("TODOS LOS CAMPOS SON OBLIGATORIOS");
                return;
            }

            dao.Create(consumption);

            dtgConsumptions.DataSource = dao.ReadConsumptions();

            ClearForm();
            MessageBox.Show("La operación se realizó exitosamente", "Ambar", MessageBoxButtons.OK);
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

                        ContractDAO contractDAO = new ContractDAO();
                        var consumptionsCSV = csvReader.GetRecords<ConsumptionCSV>().ToList();
                        List<ConsumptionDTO> finalConsumptions = new List<ConsumptionDTO>();
                        bool isCorrect = true;

                        foreach (var consumptionCSV in consumptionsCSV)
                        {
                            if (consumptionCSV.Medidor == string.Empty || 
                                consumptionCSV.Kilowatts == string.Empty ||
                                consumptionCSV.Anio == string.Empty || 
                                consumptionCSV.Mes == string.Empty)
                            {
                                PrintError("TODOS LOS CAMPOS SON OBLIGATORIOS");
                                finalConsumptions.Clear();
                                isCorrect = false;
                                break;
                            }

                            if (!RegexUtils.IsDecimalNumber(consumptionCSV.Kilowatts))
                            {
                                PrintError("KILOWATTS CONSUMIDOS SOLO ACEPTA NUMEROS DECIMALES");
                                return;
                            }

                            // Validar que mes y anio sean numericos (mes solo 1-12)
                            if (!RegexUtils.IsMonthNumber(consumptionCSV.Mes) ||
                                !RegexUtils.IsYearNumber(consumptionCSV.Anio))
                            {
                                PrintError("FECHA CON FORMATO INCORRECTO");
                                finalConsumptions.Clear();
                                isCorrect = false;
                                break;
                            }

                            if (!contractDAO.ContractExists(consumptionCSV.Medidor))
                            {
                                PrintError("EL NUMERO DE MEDIDOR NO EXISTE ACTUALMENTE");
                                finalConsumptions.Clear();
                                isCorrect = false;
                                return;
                            }

                            string serviceType = contractDAO.FindServiceType(consumptionCSV.Medidor);
                            short month = Convert.ToInt16(consumptionCSV.Mes);

                            LocalDate startDate = contractDAO.FindStartPeriodDate(txtMeterSerialNumber.Text);
                            int startPeriod;
                            int actualPeriod;
                            int startYear = startDate.Year;
                            int actualYear = dtpPeriod.Value.Year;

                            if (serviceType == "Domestico")
                            {
                                startPeriod = (startDate.Month - 1) / 2;
                                actualPeriod = (month - 1) / 2;
                            }
                            else if (serviceType == "Industrial")
                            {
                                startPeriod = startDate.Month - 1;
                                actualPeriod = month - 1;
                            }
                            else
                            {
                                PrintError("ERROR");
                                finalConsumptions.Clear();
                                isCorrect = false;
                                return;
                            }

                            if (actualYear < startYear || (actualYear == startYear && actualPeriod < startPeriod))
                            {
                                PrintError("NO SE PUEDE CARGAR UN CONSUMO ANTES DEL INICIO DE PERIODO DE COBRO");
                                finalConsumptions.Clear();
                                isCorrect = false;
                                return;
                            }

                            if (serviceType == "Doméstico" && month % 2 == 0)
                            {
                                month--;
                            }

                            if (dao.ConsumptionExists(txtMeterSerialNumber.Text, dtpPeriod.Value.Year, month))
                            {
                                PrintError("YA FUE CARGADO UN CONSUMO EN ESTE PERIODO DE COBRO");
                                finalConsumptions.Clear();
                                isCorrect = false;
                                return;
                            }

                            ConsumptionDTO consumption = new ConsumptionDTO();
                            consumption.Consumption_ID = Guid.NewGuid();
                            consumption.Meter_Serial_Number = consumptionCSV.Medidor;
                            consumption.Service_Number = contractDAO.ReadServiceNumberByMeterSerialNumber(consumptionCSV.Medidor);
                            consumption.Total_KW = Convert.ToDecimal(consumptionCSV.Kilowatts);

                            decimal kwBasic = 0;
                            decimal kwInt = 0;
                            decimal kWSur = 0;
                            PaymentBreakdown(consumption.Total_KW, ref kwBasic, ref kwInt, ref kWSur);

                            consumption.Basic_KW = kwBasic;
                            consumption.Intermediate_KW = kwInt;
                            consumption.Surplus_KW = kWSur;
                            consumption.Month = month;
                            consumption.Year = dtpPeriod.Value.Year;

                            finalConsumptions.Add(consumption);
                        }

                        foreach (var consumption in finalConsumptions)
                        {
                            dao.Create(consumption);
                        }
                        dtgConsumptions.DataSource = dao.ReadConsumptions();

                        if (isCorrect)
                        {
                            ClearForm();
                            MessageBox.Show("La operación se realizó exitosamente", "", MessageBoxButtons.OK);
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

        private void ClearForm()
        {
            txtMeterSerialNumber.Clear();
            nudKilowatts.Value = 0;
            dtpPeriod.Value = Convert.ToDateTime(Settings.Default.DateOffset).AddMonths(1);
            pbWarningIcon.Visible = false;
            lblError.Visible = false;
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

        private void dtpPeriod_ValueChanged(object sender, EventArgs e)
        {

        }

    }
}
