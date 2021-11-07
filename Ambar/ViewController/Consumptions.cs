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
        private ConsumptionDAO consumptionDAO = new ConsumptionDAO();
        private ContractDAO contractDAO = new ContractDAO();
        private DateDAO dateDAO = new DateDAO();
        public Consumptions()
        {
            InitializeComponent();
        }

        private void Consumos_Load(object sender, EventArgs e)
        {
            List<ContractDTO> contracts = contractDAO.ReadContracts();
            List<ContractDTG> dtgContractsList = new List<ContractDTG>();
            foreach (var contract in contracts)
            {
                dtgContractsList.Add(new ContractDTG(contract));
            }
            dtgContracts.DataSource = dtgContractsList;
            dtgConsumptions.DataSource = consumptionDAO.ReadConsumptions();
            dtpPeriod.MinDate = dateDAO.GetDate();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            ConsumptionDTO consumption = new ConsumptionDTO();
            consumption.Consumption_ID = Guid.NewGuid();
            consumption.Meter_Serial_Number = StringUtils.GetText(txtMeterSerialNumber.Text);
            consumption.Total_KW = nudKilowatts.Value;

            if (consumption.Meter_Serial_Number == string.Empty)
            {
                MessageBox.Show("Todos los campos son obligatorios", "Ambar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!contractDAO.ContractExists(consumption.Meter_Serial_Number))
            {
                MessageBox.Show("El número de medidor no existe actualmente", "Ambar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            consumption.Service_Number = contractDAO.ReadServiceNumberByMeterSerialNumber(consumption.Meter_Serial_Number);
            string serviceType = contractDAO.FindServiceType(consumption.Meter_Serial_Number);

            LocalDate startContractDate = contractDAO.FindStartPeriodDate(consumption.Meter_Serial_Number);
            DateTime start = new DateTime(startContractDate.Year, startContractDate.Month, 1);
            DateTime request = new DateTime(dtpPeriod.Value.Year, dtpPeriod.Value.Month, 1);

            if (!DateUtils.NormalizeDates(serviceType, ref start, ref request))
            {
                MessageBox.Show("Error inesperado", "Ambar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (request.Year < start.Year || (request.Year == start.Year && request.Month < start.Month))
            {
                MessageBox.Show("No se puede cargar un consumo antes del inicio de periodo de cobro", "Ambar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DateTime offset = dateDAO.GetDate();
            if (request.Year != offset.Year || request.Month != offset.Month)
            {
                MessageBox.Show("No se puede cargar un consumo fuera del periodo actual de cobro", "Ambar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (consumptionDAO.ConsumptionExists(txtMeterSerialNumber.Text, request.Year, Convert.ToInt16(request.Month)))
            {
                MessageBox.Show("Ya fue cargado un consumo en este periodo de cobro", "Ambar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            decimal kwBasic = 0;
            decimal kwInt = 0;
            decimal kWSur = 0;
            PaymentBreakdown(consumption.Total_KW, ref kwBasic, ref kwInt, ref kWSur);

            consumption.Basic_KW = kwBasic;
            consumption.Intermediate_KW = kwInt;
            consumption.Surplus_KW = kWSur;

            consumption.Day = Convert.ToInt16(DateUtils.ClampDay(startContractDate.Year, startContractDate.Month, startContractDate.Day));
            consumption.Month = Convert.ToInt16(request.Month);
            consumption.Year = request.Year;

            consumptionDAO.Create(consumption);
            dtgConsumptions.DataSource = consumptionDAO.ReadConsumptions();

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
                        StreamReader reader;
                        CsvReader csvReader;
                        List<ConsumptionCSV> consumptionsCSV;
                        try
                        {
                            reader = File.OpenText(ofnMassive.FileName);
                            csvReader = new CsvReader(reader, CultureInfo.CurrentCulture);
                            consumptionsCSV = csvReader.GetRecords<ConsumptionCSV>().ToList();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("No se pudo abrir el archivo", "Ambar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        List<ConsumptionDTO> finalConsumptions = new List<ConsumptionDTO>();
                        bool isCorrect = true;
                        foreach (var consumptionCSV in consumptionsCSV)
                        {
                            if (!Validate(consumptionCSV, finalConsumptions))
                            {
                                finalConsumptions.Clear();
                                isCorrect = false;
                                break;
                            }

                            ConsumptionDTO consumption = FillConsumption(consumptionCSV);
                            finalConsumptions.Add(consumption);
                        }

                        foreach (var consumption in finalConsumptions)
                        {
                            consumptionDAO.Create(consumption);
                        }

                        dtgConsumptions.DataSource = consumptionDAO.ReadConsumptions();

                        if (isCorrect)
                        {
                            ClearForm();
                            MessageBox.Show("La operación se realizó exitosamente", "", MessageBoxButtons.OK);
                        }
                        reader.Close();
                        break;
                    }
                    case 2: // Excel
                    {
                        FileStream reader;
                        IExcelDataReader xlsxReader;
                        DataSet dataSetXLSX;
                        List<ConsumptionCSV> consumptionsCSV;
                        try
                        {
                            reader = new FileStream(ofnMassive.FileName, FileMode.Open, FileAccess.Read);
                            xlsxReader = ExcelReaderFactory.CreateReader(reader);

                            dataSetXLSX = xlsxReader.AsDataSet(new ExcelDataSetConfiguration()
                            {
                                ConfigureDataTable = (tableReader) => new ExcelDataTableConfiguration()
                                {
                                    UseHeaderRow = true
                                }
                            });

                            var dataTable = dataSetXLSX.Tables[0];
                            consumptionsCSV = (from row in dataTable.AsEnumerable()
                                               select new ConsumptionCSV()
                                               {
                                                   Medidor = row["Numero de Medidor"].ToString(),
                                                   Kilowatts = row["Kilowatts"].ToString(),
                                                   Mes = row["Mes"].ToString(),
                                                   Anio = row["Anio"].ToString()
                                               }).ToList();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("No se pudo abrir el archivo", "Ambar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        List<ConsumptionDTO> finalConsumptions = new List<ConsumptionDTO>();
                        bool isCorrect = true;
                        foreach (var consumptionCSV in consumptionsCSV)
                        {
                            if (!Validate(consumptionCSV, finalConsumptions))
                            {
                                finalConsumptions.Clear();
                                isCorrect = false;
                                break;
                            }

                            ConsumptionDTO consumption = FillConsumption(consumptionCSV);
                            finalConsumptions.Add(consumption);
                        }

                        foreach (var consumption in finalConsumptions)
                        {
                            consumptionDAO.Create(consumption);
                        }

                        dtgConsumptions.DataSource = consumptionDAO.ReadConsumptions();

                        if (isCorrect)
                        {
                            ClearForm();
                            MessageBox.Show("La operación se realizó exitosamente", "", MessageBoxButtons.OK);
                        }
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
            dtpPeriod.Value = dtpPeriod.MinDate;
            pbWarningIcon.Visible = false;
            lblError.Visible = false;
        }

        private void PaymentBreakdown(decimal value, ref decimal kwBasic, ref decimal kwInt, ref decimal kwExc)
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

        private bool Validate(ConsumptionCSV consumption, List<ConsumptionDTO> consumptions)
        {
            if (consumption.Medidor == string.Empty || consumption.Kilowatts == string.Empty ||
                consumption.Anio == string.Empty || consumption.Mes == string.Empty)
            {
                MessageBox.Show("Todos los campos son obligatorios", "Ambar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Validar que el kilowatt sea correcto
            if (!RegexUtils.IsDecimalNumber(consumption.Kilowatts))
            {
                MessageBox.Show("Kilowatts consumidos solo acepta numeros decimales", "Ambar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Validar que mes y anio sean numericos (mes solo 1-12)
            if (!RegexUtils.IsMonthNumber(consumption.Mes) || !RegexUtils.IsYearNumber(consumption.Anio))
            {
                MessageBox.Show("Fecha con formato incorrecto", "Ambar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (!contractDAO.ContractExists(consumption.Medidor))
            {
                MessageBox.Show("El número de medidor no existe actualmente", "Ambar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            string serviceType = contractDAO.FindServiceType(consumption.Medidor);
            int year = Convert.ToInt32(consumption.Anio);
            short month = Convert.ToInt16(consumption.Mes);

            LocalDate startContractDate = contractDAO.FindStartPeriodDate(consumption.Medidor);

            DateTime start = new DateTime(startContractDate.Year, startContractDate.Month, 1);
            DateTime request = new DateTime(year, month, 1);

            if (!DateUtils.NormalizeDates(serviceType, ref start, ref request))
            {
                MessageBox.Show("Error inesperado", "Ambar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (request.Year < start.Year || (request.Year == start.Year && request.Month < start.Month))
            {
                MessageBox.Show("No se puede cargar un consumo antes del inicio del periodo de cobro", "Ambar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            DateTime offset = dateDAO.GetDate();
            if (request.Year != offset.Year || request.Month != offset.Month)
            {
                MessageBox.Show("No se puede cargar un consumo fuera del periodo actual de cobro", "Ambar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (consumptionDAO.ConsumptionExists(consumption.Medidor, request.Year, Convert.ToInt16(request.Month)))
            {
                MessageBox.Show("Ya fue cargado un consumo en este periodo de cobro", "Ambar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            var one = consumptions.Where(x => x.Meter_Serial_Number == consumption.Medidor).FirstOrDefault();
            var two = consumptions.Where(x => x.Month == Convert.ToInt16(consumption.Mes)).FirstOrDefault();
            var three = consumptions.Where(x => x.Year == Convert.ToInt32(consumption.Anio)).FirstOrDefault();

            if (one != null && two != null && three != null)
            {
                MessageBox.Show("Un consumo es cargado dos o más veces en el mismo periodo de cobro", "Ambar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private ConsumptionDTO FillConsumption(ConsumptionCSV consumption)
        {
            ConsumptionDTO dto = new ConsumptionDTO();
            dto.Consumption_ID = Guid.NewGuid();
            dto.Meter_Serial_Number = consumption.Medidor;
            dto.Service_Number = contractDAO.ReadServiceNumberByMeterSerialNumber(consumption.Medidor);
            dto.Total_KW = Convert.ToDecimal(consumption.Kilowatts);

            decimal kwBasic = 0;
            decimal kwInt = 0;
            decimal kWSur = 0;
            PaymentBreakdown(dto.Total_KW, ref kwBasic, ref kwInt, ref kWSur);

            dto.Basic_KW = kwBasic;
            dto.Intermediate_KW = kwInt;
            dto.Surplus_KW = kWSur;
            dto.Month = Convert.ToInt16(consumption.Mes);
            dto.Year = Convert.ToInt32(consumption.Anio);
            return dto;
        }

    }
}
