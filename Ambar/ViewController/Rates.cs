using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Windows.Forms;
using CsvHelper;
using ExcelDataReader;
using Ambar.Model.DAO;
using Ambar.Model.DTO;
using Ambar.Common;
using System.Globalization;
using System.Linq;
using Ambar.ViewController.Objects;
using Ambar.Model.AmbarMapper;

namespace Ambar.ViewController
{
    public partial class Rates : Form
    {
        private RateDAO rateDAO = new RateDAO();
        private DateDAO dateDAO = new DateDAO();

        public Rates()
        {
            InitializeComponent();
        }

        private void Rates_Load(object sender, EventArgs e)
        {
            FillRatesDataGridView();
            cbService.SelectedIndex = 0;
            dtpYear.MinDate = dateDAO.GetDate();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            RateForm rate = FillRate();
            if (!Validate(rate))
            {
                return;
            }

            RateDTO rateDTO = RateMapper.CreateDTO(rate);
            rateDAO.Create(rateDTO);

            string action = "[Tarifas] Fue creada tarifa Mes: " + rate.Month + ", Año: " + rate.Year + ", Servicio" + rate.ServiceType;
            new ActivityDAO().Action(UserCache.id, action);

            FillRatesDataGridView();

            ClearForm();
            MessageBox.Show("La operación se realizó exitosamente", "Ambar", MessageBoxButtons.OK);
        }

        private RateForm FillRate()
        {
            RateForm rate = new RateForm();
            rate.ID = Guid.NewGuid();
            rate.ServiceType = cbService.SelectedItem.ToString();
            rate.Year = dtpYear.Value.Year;
            rate.Month = ((ComboBoxItem)cbPeriod.SelectedItem).HiddenValue;
            rate.BasicLevel = nudBasic.Value;
            rate.IntermediateLevel = nudIntermediate.Value;
            rate.SurplusLevel = nudSurplus.Value;
            return rate;
        }

        private bool Validate(RateForm rate)
        {
            if (rate.Month == -1 || rate.ServiceType == "Seleccionar")
            {
                MessageBox.Show("Todos los campos son obligatorios", "Ambar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void ClearForm()
        {
            cbService.SelectedIndex = 0;
            dtpYear.Value = dtpYear.MinDate;
            nudBasic.Value = 0;
            nudIntermediate.Value = 0;
            nudSurplus.Value = 0;
        }

        private void cbService_SelectedIndexChanged(object sender, EventArgs e)
        {
            DateChange();
        }

        private void dtpPeriod_ValueChanged(object sender, EventArgs e)
        {
            DateChange();
        }

        public void DateChange()
        {
            cbPeriod.Items.Clear();
            cbPeriod.Items.Add(new ComboBoxItem("Seleccionar", -1));

            DateTime offset = dateDAO.GetDate();
            switch (cbService.SelectedIndex)
            {
                case 1:
                {
                    int bimester = 0;
                    if (dtpYear.Value.Year == offset.Year)
                    {
                        bimester = DateUtils.FindBimester(offset) - 1;
                    }

                    var bimesters = new[]
                    {
                        new ComboBoxItem("Enero-Febrero", 2), new ComboBoxItem("Marzo-Abril", 4),
                        new ComboBoxItem("Mayo-Junio", 6), new ComboBoxItem("Julio-Agosto", 8),
                        new ComboBoxItem("Septiembre-Octubre", 10), new ComboBoxItem("Noviembre-Diciembre", 12)
                    };

                    for (int i = bimester; i < 6; i++)
                    {
                        cbPeriod.Items.Add(bimesters[i]);
                    }
                    break;
                }
                case 2:
                {
                    int month = 0;
                    if (dtpYear.Value.Year == offset.Year)
                    {
                        month = offset.Month - 1;
                    }

                    var months = new[]
                    {
                        new ComboBoxItem("Enero", 1), new ComboBoxItem("Febrero", 2), new ComboBoxItem("Marzo", 3), 
                        new ComboBoxItem("Abril", 4), new ComboBoxItem("Mayo", 5), new ComboBoxItem("Junio", 6), 
                        new ComboBoxItem("Julio", 7), new ComboBoxItem("Agosto", 8), new ComboBoxItem("Septiembre", 9), 
                        new ComboBoxItem("Octubre", 10), new ComboBoxItem("Noviembre", 11), new ComboBoxItem("Diciembre", 12)
                    };

                    for (int i = month; i < 12; i++)
                    {
                        cbPeriod.Items.Add(months[i]);
                    }
                    break;
                }
            }
            cbPeriod.SelectedIndex = 0;
        }

        private void btnMasiveCharge_Click(object sender, EventArgs e)
        {
            if (ofnMassive.ShowDialog() == DialogResult.OK)
            {
                switch (ofnMassive.FilterIndex)
                {
                    case 1: // CSV
                    {
                        StreamReader reader;
                        CsvReader csvReader;
                        List<RateCSV> ratesCSV;
                        try
                        {
                            reader = File.OpenText(ofnMassive.FileName);
                            csvReader = new CsvReader(reader, CultureInfo.CurrentCulture);
                            ratesCSV = csvReader.GetRecords<RateCSV>().ToList();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("No se pudo abrir el archivo", "Ambar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        List<RateDTO> finalRates = new List<RateDTO>();
                        bool isCorrect = true;
                        foreach (var rateCSV in ratesCSV)
                        {
                            if (!Validate(rateCSV))
                            {
                                finalRates.Clear();
                                isCorrect = false;
                                break;
                            }

                            RateDTO rate = FillRate(rateCSV);

                            finalRates.Add(rate);
                        }

                        foreach (var rate in finalRates)
                        {
                            rateDAO.Create(rate);
                        }
                        string action = "[Tarifas] Carga masiva de tarifas";
                        new ActivityDAO().Action(UserCache.id, action);

                        FillRatesDataGridView();

                        if (isCorrect)
                        {
                            ClearForm();
                            MessageBox.Show("La operación se realizó exitosamente", "Ambar", MessageBoxButtons.OK);
                        }
                        reader.Close();
                        break;
                    }
                    case 2: // Excel
                    {
                        FileStream reader;
                        IExcelDataReader xlsxReader;
                        DataSet dataSetXLSX;
                        List<RateCSV> ratesCSV;
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
                            ratesCSV = (from row in dataTable.AsEnumerable()
                                        select new RateCSV()
                                        {
                                            Basica = row["Tarifa Basica"].ToString(),
                                            Intermedia = row["Tarifa Intermedia"].ToString(),
                                            Excedente = row["Tarifa Excedente"].ToString(),
                                            Mes = row["Mes"].ToString(),
                                            Anio = row["Anio"].ToString(),
                                            Servicio = row["Servicio"].ToString()
                                        }).ToList();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("No se pudo abrir el archivo", "Ambar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        List<RateDTO> finalRates = new List<RateDTO>();
                        bool isCorrect = true;
                        foreach (var rateCSV in ratesCSV)
                        {
                            if (!Validate(rateCSV))
                            {
                                finalRates.Clear();
                                isCorrect = false;
                                break;
                            }
                            RateDTO rate = FillRate(rateCSV);

                            finalRates.Add(rate);
                        }

                        foreach (var rate in finalRates)
                        {
                            rateDAO.Create(rate);
                        }

                        string action = "[Tarifas] Carga masiva de tarifas";
                        new ActivityDAO().Action(UserCache.id, action);

                        FillRatesDataGridView();

                        if (isCorrect)
                        {
                            ClearForm();
                            MessageBox.Show("La operación se realizó exitosamente", "Ambar", MessageBoxButtons.OK);
                        }

                        reader.Close();
                        break;
                    }
                }
            }
        }

        private bool Validate(RateCSV rate)
        {
            if (rate.Basica == string.Empty || rate.Intermedia == string.Empty || rate.Excedente == string.Empty || 
                rate.Servicio == string.Empty || rate.Anio == string.Empty || rate.Mes == string.Empty)
            {
                MessageBox.Show("Todos los campos son obligatorios", "Ambar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (rate.Basica.IndexOf('\'') != -1 || rate.Intermedia.IndexOf('\'') != -1 || rate.Excedente.IndexOf('\'') != -1 ||
               rate.Servicio.IndexOf('\'') != -1 || rate.Anio.IndexOf('\'') != -1 || rate.Mes.IndexOf('\'') != -1)
            {
                MessageBox.Show("Caracter \' no valido", "Ambar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (!RegexUtils.IsDecimalNumber(rate.Basica) || !RegexUtils.IsDecimalNumber(rate.Intermedia) ||
                !RegexUtils.IsDecimalNumber(rate.Excedente))
            {
                MessageBox.Show("Tarifas solo aceptan números decimales", "Ambar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            decimal basic = Convert.ToDecimal(rate.Basica);
            decimal intermediate = Convert.ToDecimal(rate.Intermedia);
            decimal surplus = Convert.ToDecimal(rate.Excedente);
            if (basic > 1000 || intermediate > 1000 || surplus > 1000)
            {
                MessageBox.Show("Tarifas fuera de rango", "Ambar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Validar que mes y anio sean numericos (mes solo 1-12)
            if (!RegexUtils.IsMonthNumber(rate.Mes) || !RegexUtils.IsYearNumber(rate.Anio))
            {
                MessageBox.Show("Fecha con formato incorrecto", "Ambar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (rate.Servicio != "Domestico" && rate.Servicio != "Industrial")
            {
                MessageBox.Show("Servicio con formato incorrecto", "Ambar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private RateDTO FillRate(RateCSV rate)
        {
            RateDTO dto = new RateDTO();
            dto.Rate_ID = Guid.NewGuid();
            dto.Basic_Level = decimal.Round(Convert.ToDecimal(rate.Basica, CultureInfo.InvariantCulture), 3);
            dto.Intermediate_Level = decimal.Round(Convert.ToDecimal(rate.Intermedia, CultureInfo.InvariantCulture), 3);
            dto.Surplus_Level = decimal.Round(Convert.ToDecimal(rate.Excedente, CultureInfo.InvariantCulture), 3);
            dto.Year = Convert.ToInt32(rate.Anio, CultureInfo.InvariantCulture);
            dto.Service = rate.Servicio;
            int month = Convert.ToInt32(rate.Mes, CultureInfo.InvariantCulture);
            if (rate.Servicio == "Domestico" && month % 2 == 1)
            {
                month++;
            }
            dto.Month = month;
            return dto;
        }

        private void FillRatesDataGridView()
        {
            List<RateDTO> rates = rateDAO.ReadRates();
            rates = rates.OrderBy(order => order.Service).
                ThenBy(order => order.Year).
                ThenBy(order => order.Month).ToList();
            dtgRates.DataSource = rates;
        }

    }
}