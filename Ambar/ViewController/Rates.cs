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
            dtgRates.DataSource = rateDAO.ReadRates();
            cbService.SelectedIndex = 0;

            dtpYear.MinDate = dateDAO.GetDate();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            // El sistema deberia dejar que haya tarifas de 0 ?
            if (cbService.SelectedIndex <= 0 || cbPeriod.SelectedIndex == -1)
            {
                MessageBox.Show("Todos los campos son obligatorios", "Ambar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            RateDTO rate = new RateDTO();
            rate.Basic_Level = nudBasic.Value;
            rate.Intermediate_Level = nudIntermediate.Value;
            rate.Surplus_Level = nudSurplus.Value;
            rate.Year = dtpYear.Value.Year;
            rate.Month = Convert.ToInt16(((ComboBoxItem)cbPeriod.SelectedItem).HiddenValue);
            rate.Service = cbService.SelectedItem.ToString();

            rateDAO.Create(rate);

            dtgRates.DataSource = rateDAO.ReadRates();

            ClearForm();
            MessageBox.Show("La operación se realizó exitosamente", "Ambar", MessageBoxButtons.OK);
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

                        dtgRates.DataSource = rateDAO.ReadRates();

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
                            ratesCSV = (from row in dataTable.AsEnumerable() select new RateCSV()
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

                        dtgRates.DataSource = rateDAO.ReadRates();

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

        private void cbService_SelectedIndexChanged(object sender, EventArgs e)
        {
            DateChange();
        }

        private void ClearForm()
        {
            cbService.SelectedIndex = 0;
            dtpYear.Value = dtpYear.MinDate;
            nudBasic.Value = 0;
            nudIntermediate.Value = 0;
            nudSurplus.Value = 0;
        }

        private void dtpPeriod_ValueChanged(object sender, EventArgs e)
        {
            DateChange();
        }

        public void DateChange()
        {
            cbPeriod.Items.Clear();
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

                    string[] bimesters = new string[] { "ENERO-FEBRERO", "MARZO-ABRIL", "MAYO-JUNIO", "JULIO-AGOSTO",
                    "SEPTIEMBRE-OCTUBRE", "NOVIEMBRE-DICIEMBRE" };
                    int[] numbers = new int[] { 2, 4, 6, 8, 10, 12 };

                    for (int i = bimester; i < 6; i++)
                    {
                        cbPeriod.Items.Add(new ComboBoxItem(bimesters[i], numbers[i]));
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

                    string[] months = new string[] { "ENERO", "FEBRERO", "MARZO", "ABRIL", "MAYO", "JUNIO", "JULIO",
                    "AGOSTO", "SEPTIEMBRE", "OCTUBRE", "NOVIEMBRE", "DICIEMBRE" };
                    int[] numbers = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };

                    for (int i = month; i < 12; i++)
                    {
                        cbPeriod.Items.Add(new ComboBoxItem(months[i], numbers[i]));
                    }
                    break;
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

            if (!RegexUtils.IsDecimalNumber(rate.Basica) || !RegexUtils.IsDecimalNumber(rate.Intermedia) ||
                !RegexUtils.IsDecimalNumber(rate.Excedente))
            {
                MessageBox.Show("Tarifas solo aceptan números decimales", "Ambar", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            dto.Basic_Level = Decimal.Round(Convert.ToDecimal(rate.Basica, CultureInfo.InvariantCulture), 3);
            dto.Intermediate_Level = Decimal.Round(Convert.ToDecimal(rate.Intermedia, CultureInfo.InvariantCulture), 3);
            dto.Surplus_Level = Decimal.Round(Convert.ToDecimal(rate.Excedente, CultureInfo.InvariantCulture), 3);
            dto.Year = Convert.ToInt32(rate.Anio, CultureInfo.InvariantCulture);
            dto.Service = rate.Servicio;
            short month = Convert.ToInt16(rate.Mes, CultureInfo.InvariantCulture);
            if (rate.Servicio == "Domestico" && month % 2 == 1)
            {
                month++;
            }
            dto.Month = month;
            return dto;
        }

    }
}