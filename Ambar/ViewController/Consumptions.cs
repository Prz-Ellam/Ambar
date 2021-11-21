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
using Ambar.ViewController.Objects;
using Ambar.Model.AmbarMapper;

namespace Ambar.ViewController
{
    public partial class Consumptions : Form
    {
        private ConsumptionDAO consumptionDAO = new ConsumptionDAO();
        private ContractDAO contractDAO = new ContractDAO();
        private DateDAO dateDAO = new DateDAO();
        private int dtgPrevIndex = -1;
        public Consumptions()
        {
            InitializeComponent();
        }

        private void Consumos_Load(object sender, EventArgs e)
        {
            FillContractDateGridView();
            FillConsumptionDataGridView();
            dtpPeriod.MinDate = dateDAO.GetDate();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            ConsumptionForm consumption = FillConsumption();
            if (!Validate(consumption))
            {
                return;
            }

            ConsumptionDTO consumptionDTO = ConsumptionMapper.CreateDTO(consumption);
            consumptionDAO.Create(consumptionDTO);

            string action = "[Consumos] Fue creado consumo para: " + consumption.MeterSerialNumber + 
                ", con ID: " + consumption.ID + "Mes: " + consumptionDTO.Month + ", Año: " + consumptionDTO.Year;
            new ActivityDAO().Action(UserCache.id, action);

            FillConsumptionDataGridView();
            ClearForm();
            MessageBox.Show("La operación se realizó exitosamente", "Ambar", MessageBoxButtons.OK);
        }

        private ConsumptionForm FillConsumption()
        {
            var row = dtgContracts.Rows[dtgPrevIndex];
            ConsumptionForm consumption = new ConsumptionForm();
            consumption.ID = Guid.NewGuid();
            consumption.ContractID = Guid.Parse(row.Cells[0].Value.ToString());
            consumption.MeterSerialNumber = StringUtils.GetText(txtMeterSerialNumber.Text);
            consumption.ServiceNumber = row.Cells[2].Value.ToString();
            consumption.ServiceType = row.Cells[9].Value.ToString(); 
            consumption.Kilowatts = nudKilowatts.Value;
            consumption.Period = dtpPeriod.Value;
            consumption.ContractStartPeriod = Convert.ToDateTime(row.Cells[10].Value.ToString());
            return consumption;
        }

        private bool Validate(ConsumptionForm consumption)
        {
            if (consumption.MeterSerialNumber == string.Empty)
            {
                MessageBox.Show("Todos los campos son obligatorios", "Ambar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (!contractDAO.ContractExists(consumption.MeterSerialNumber))
            {
                MessageBox.Show("El número de medidor no existe actualmente", "Ambar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (consumption.ServiceType != "Domestico" && consumption.ServiceType != "Industrial")
            {
                MessageBox.Show("Tipo de servicio no valido", "Ambar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            consumption.ContractStartPeriod = DateUtils.FindStartPeriod(consumption.ServiceType, consumption.ContractStartPeriod);
            consumption.Period = DateUtils.FindPeriod(consumption.ServiceType, consumption.Period);

            if (DateUtils.IsLessPeriod(consumption.Period, consumption.ContractStartPeriod))
            {
                MessageBox.Show("No se puede cargar un consumo antes del inicio de periodo de cobro", "Ambar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            DateTime offset = dateDAO.GetDate();
            if (DateUtils.ComparePeriod(consumption.Period, offset))
            {
                MessageBox.Show("No se puede cargar un consumo fuera del periodo actual de cobro", "Ambar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (consumptionDAO.ConsumptionExists(consumption.MeterSerialNumber, consumption.Period.Year, consumption.Period.Month))
            {
                MessageBox.Show("Ya fue cargado un consumo en este periodo de cobro", "Ambar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
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
                        List<ConsumptionDoc> consumptionsCSV;
                        try
                        {
                            reader = File.OpenText(ofnMassive.FileName);
                            csvReader = new CsvReader(reader, CultureInfo.CurrentCulture);
                            consumptionsCSV = csvReader.GetRecords<ConsumptionDoc>().ToList();
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
                        string action = "[Consumos] Carga masiva de consumo";
                        new ActivityDAO().Action(UserCache.id, action);

                        FillConsumptionDataGridView();

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
                        List<ConsumptionDoc> consumptionsCSV;
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
                                               select new ConsumptionDoc()
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

                        string action = "[Consumos] Carga masiva de consumos";
                        new ActivityDAO().Action(UserCache.id, action);

                        FillConsumptionDataGridView();

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

        private bool Validate(ConsumptionDoc consumption, List<ConsumptionDTO> consumptions)
        {
            if (consumption.Medidor == string.Empty || consumption.Kilowatts == string.Empty ||
                consumption.Anio == string.Empty || consumption.Mes == string.Empty)
            {
                MessageBox.Show("Todos los campos son obligatorios", "Ambar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (consumption.Medidor.IndexOf('\'') != -1 || consumption.Kilowatts.IndexOf('\'') != -1 ||
                consumption.Anio.IndexOf('\'') != -1 || consumption.Mes.IndexOf('\'') != -1)
            {
                MessageBox.Show("Caracter \' no valido", "Ambar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Validar que el kilowatt sea correcto
            if (!RegexUtils.IsDecimalNumber(consumption.Kilowatts))
            {
                MessageBox.Show("Kilowatts consumidos solo acepta numeros decimales", "Ambar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            decimal kilowatts = Convert.ToDecimal(consumption.Kilowatts);
            if (kilowatts > 1000000)
            {
                MessageBox.Show("Consumo fuera de rango", "Ambar", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            if (serviceType == null)
            {
                MessageBox.Show("Error inesperado", "Ambar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (serviceType != "Domestico" && serviceType != "Industrial")
            {
                MessageBox.Show("Tipo de servicio no valido", "Ambar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            int year = Convert.ToInt32(consumption.Anio);
            int month = Convert.ToInt32(consumption.Mes);

            LocalDate startContractDate = contractDAO.FindStartPeriodDate(consumption.Medidor);
            DateTime startPeriod = DateUtils.ToDateTime(startContractDate);
            startPeriod = DateUtils.FindStartPeriod(serviceType, startPeriod);
            DateTime period = new DateTime(year, month, 1);
            period = DateUtils.FindPeriod(serviceType, period);

            if (DateUtils.IsLessPeriod(period, startPeriod))
            {
                MessageBox.Show("No se puede cargar un consumo antes del inicio de periodo de cobro", "Ambar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            DateTime offset = dateDAO.GetDate();
            if (DateUtils.ComparePeriod(period, offset))
            {
                MessageBox.Show("No se puede cargar un consumo fuera del periodo actual de cobro", "Ambar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (consumptionDAO.ConsumptionExists(consumption.Medidor, period.Year, period.Month))
            {
                MessageBox.Show("Ya fue cargado un consumo en este periodo de cobro", "Ambar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            var isMeterSerialNumber = consumptions.Where(x => x.Meter_Serial_Number == consumption.Medidor).FirstOrDefault();
            var isMonth = consumptions.Where(x => x.Month == Convert.ToInt32(consumption.Mes)).FirstOrDefault();
            var isYear = consumptions.Where(x => x.Year == Convert.ToInt32(consumption.Anio)).FirstOrDefault();

            if (isMeterSerialNumber != null && isMonth != null && isYear != null)
            {
                MessageBox.Show("Un consumo es cargado dos o más veces en el mismo periodo de cobro", "Ambar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private ConsumptionDTO FillConsumption(ConsumptionDoc consumption)
        {
            ConsumptionDTO dto = new ConsumptionDTO();
            dto.Consumption_ID = Guid.NewGuid();
            dto.Contract_ID = contractDAO.ReadContractIDByMeterSerialNumber(consumption.Medidor);
            dto.Meter_Serial_Number = consumption.Medidor;
            dto.Service_Number = contractDAO.ReadServiceNumberByMeterSerialNumber(consumption.Medidor);
            dto.Total_KW = Convert.ToDecimal(consumption.Kilowatts);

            decimal kwBasic = 0;
            decimal kwInt = 0;
            decimal kWSur = 0;
            NumericUtils.PaymentBreakdown(dto.Total_KW, ref kwBasic, ref kwInt, ref kWSur);

            dto.Basic_KW = kwBasic;
            dto.Intermediate_KW = kwInt;
            dto.Surplus_KW = kWSur;
            dto.Month = Convert.ToInt32(consumption.Mes);
            dto.Year = Convert.ToInt32(consumption.Anio);
            LocalDate date = contractDAO.ReadStartPeriodByMeterSerialNumber(consumption.Medidor);
            dto.Day = DateUtils.ClampDay(dto.Year, dto.Month, date.Day);

            return dto;
        }

        private void ClearForm()
        {
            txtMeterSerialNumber.Clear();
            nudKilowatts.Value = 0;
            dtpPeriod.Value = dtpPeriod.MinDate;
            btnAccept.Enabled = false;
            dtgPrevIndex = -1;
        }

        private void dtgContracts_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (dtgPrevIndex == index || index == -1)
            {
                ClearForm();
            }
            else
            {
                txtMeterSerialNumber.Text = dtgContracts.Rows[index].Cells[1].Value.ToString();
                btnAccept.Enabled = true;
                dtgPrevIndex = index;
            }
        }

        private void FillConsumptionDataGridView()
        {
            List<ConsumptionDTO> consumptions = consumptionDAO.ReadConsumptions();
            List<ConsumptionDTG> dtgConsumptionsList = new List<ConsumptionDTG>();
            foreach (var consumption in consumptions)
            {
                dtgConsumptionsList.Add(new ConsumptionDTG(consumption));
            }
            dtgConsumptionsList = dtgConsumptionsList.OrderBy(order => order.Service_Number).
                ThenBy(order => order.Year).
                ThenBy(order => order.Month).ToList();
            dtgConsumptions.DataSource = dtgConsumptionsList;
        }

        private void FillContractDateGridView()
        {
            List<ContractDTO> contracts = contractDAO.ReadContracts();
            List<ContractDTG> dtgContractsList = new List<ContractDTG>();
            foreach (var contract in contracts)
            {
                dtgContractsList.Add(new ContractDTG(contract));
            }
            dtgContracts.DataSource = dtgContractsList;
        }

    }
}
