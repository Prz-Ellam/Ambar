using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using CsvHelper;
using ExcelDataReader;
using Ambar.Model.DAO;
using Ambar.Model.DTO;
using Ambar.Common;
using System.Globalization;
using Ambar.Properties;

namespace Ambar.ViewController
{
    public partial class Rates : Form
    {
        private RateDAO rateDAO = new RateDAO();

        public Rates()
        {
            InitializeComponent();
        }

        private void Rates_Load(object sender, EventArgs e)
        {
            dtgRates.DataSource = rateDAO.ReadRates();
            cbService.SelectedIndex = 0;
            dtpYear.MinDate = Convert.ToDateTime(Settings.Default.DateOffset).AddMonths(1);
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            // El sistema deberia dejar que haya tarifas de 0 ?
            if (cbService.SelectedIndex <= 0 ||
                cbPeriod.SelectedIndex == -1)
            {
                PrintError("TODOS LOS CAMPOS SON OBLIGATORIOS");
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
                        var reader = File.OpenText(ofnMassive.FileName);
                        CsvReader csvReader = new CsvReader(reader, CultureInfo.CurrentCulture);

                        var ratesCSV = csvReader.GetRecords<RateCSV>();
                        List<RateDTO> finalRates = new List<RateDTO>();
                        bool isCorrect = true;
                        foreach (var rateCSV in ratesCSV)
                        {
                            if (rateCSV.Basica == string.Empty || rateCSV.Intermedia == string.Empty ||
                                rateCSV.Excedente == string.Empty || rateCSV.Servicio == string.Empty ||
                                rateCSV.Anio == string.Empty || rateCSV.Mes == string.Empty)
                            {
                                PrintError("TODOS LOS CAMPOS SON OBLIGATORIOS");
                                finalRates.Clear();
                                isCorrect = false;
                                break;
                            }

                            if (!RegexUtils.IsDecimalNumber(rateCSV.Basica) ||
                                !RegexUtils.IsDecimalNumber(rateCSV.Intermedia) ||
                                !RegexUtils.IsDecimalNumber(rateCSV.Excedente))
                            {
                                PrintError("TARIFAS SOLO ACEPTAN NUMEROS DECIMALES");
                                finalRates.Clear();
                                isCorrect = false;
                                break;
                            }

                            // Validar que mes y anio sean numericos (mes solo 1-12)
                            if (!RegexUtils.IsMonthNumber(rateCSV.Mes) ||
                                !RegexUtils.IsYearNumber(rateCSV.Anio))
                            {
                                PrintError("FECHA CON FORMATO INCORRECTO");
                                finalRates.Clear();
                                isCorrect = false;
                                break;
                            }

                            RateDTO rate = new RateDTO();
                            rate.Basic_Level = Convert.ToDecimal(rateCSV.Basica, CultureInfo.InvariantCulture);
                            rate.Intermediate_Level = Convert.ToDecimal(rateCSV.Intermedia, CultureInfo.InvariantCulture);
                            rate.Surplus_Level = Convert.ToDecimal(rateCSV.Excedente, CultureInfo.InvariantCulture);
                            rate.Year = Convert.ToInt32(rateCSV.Anio, CultureInfo.InvariantCulture);
                            rate.Service = rateCSV.Servicio;
                            if (rateCSV.Servicio == "Domestico")
                            {
                                short month = Convert.ToInt16(rateCSV.Mes, CultureInfo.InvariantCulture);
                                if (month % 2 == 0)
                                {
                                    month--;
                                }
                                rate.Month = month;
                            }

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

        private void cbService_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbPeriod.Items.Clear();
            DateTime offset = Convert.ToDateTime(Settings.Default.DateOffset).AddMonths(1);

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
                    int[] numbers = new int[] { 1, 3, 5, 7, 9, 11 };

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

        private void ClearForm()
        {
            cbService.SelectedIndex = 0;
            dtpYear.Value = Convert.ToDateTime(Settings.Default.DateOffset).AddMonths(1);
            nudBasic.Value = 0;
            nudIntermediate.Value = 0;
            nudSurplus.Value = 0;
        }

        private void PrintError(string error)
        {
            pbWarningIcon.Visible = true;
            lblError.Visible = true;
            lblError.Text = error;
        }

        private void dtpPeriod_ValueChanged(object sender, EventArgs e)
        {
            cbPeriod.Items.Clear();
            DateTime offset = Convert.ToDateTime(Settings.Default.DateOffset).AddMonths(1);

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
                    int[] numbers = new int[] { 1, 3, 5, 7, 9, 11 };

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
    }
}