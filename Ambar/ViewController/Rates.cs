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

namespace Ambar.ViewController
{
    public partial class Rates : Form
    {
        private RateDAO dao = new RateDAO();

        public Rates()
        {
            InitializeComponent();
        }

        private void Rates_Load(object sender, EventArgs e)
        {
            dtgRates.DataSource = dao.ReadRates();
            cbService.SelectedIndex = 0;
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (txtBasic.Text == string.Empty || txtIntermediate.Text == string.Empty || txtSurplus.Text == string.Empty
                || cbService.SelectedIndex == -1)
            {
                PrintError("TODOS LOS CAMPOS SON OBLIGATORIOS");
                return;
            }

            if (!RegexUtils.IsDecimalNumber(txtBasic.Text) || !RegexUtils.IsDecimalNumber(txtIntermediate.Text) 
                || !RegexUtils.IsDecimalNumber(txtSurplus.Text))
            {
                PrintError("TARIFAS SOLO ACEPTAN NUMEROS DECIMALES");
                return;
            }
            
            RateDTO rate = new RateDTO();
            rate.Basic_Level = Convert.ToDecimal(txtBasic.Text, CultureInfo.InvariantCulture);
            rate.Intermediate_Level = Convert.ToDecimal(txtIntermediate.Text, CultureInfo.InvariantCulture);
            rate.Surplus_Level = Convert.ToDecimal(txtSurplus.Text, CultureInfo.InvariantCulture);
            rate.Year = dtpPeriod.Value.Year;

            short month;
            if (cbService.SelectedIndex == 1)
            {
                // ENERO, MARZO, MAYO, JULIO, SEPTIEMBRE, NOVIEMBRE
                month = Convert.ToInt16(cbPeriod.SelectedIndex * 2 + 1);
            }
            else if (cbService.SelectedIndex == 2)
            {
                month = Convert.ToInt16(cbPeriod.SelectedIndex + 1);
            }
            else
            {
                return;
            }

            rate.Month = month;
            rate.Service = cbService.SelectedItem.ToString();

            dao.Create(rate);

            dtgRates.DataSource = dao.ReadRates();

            ClearForm();
            MessageBox.Show("La operación se realizó exitosamente", "", MessageBoxButtons.OK);
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

                        var studentsCSV = csvReader.GetRecords<RateCSV>();
                        foreach (var student in studentsCSV)
                        {
                            if (student.Basica == string.Empty || student.Intermedia == string.Empty ||
                                student.Excedente == string.Empty || student.Servicio == string.Empty ||
                                student.Anio == string.Empty || student.Mes == string.Empty)
                            {
                                PrintError("TODOS LOS CAMPOS SON OBLIGATORIOS");
                                continue;
                            }

                            if (!RegexUtils.IsDecimalNumber(student.Basica) ||
                                !RegexUtils.IsDecimalNumber(student.Intermedia) ||
                                !RegexUtils.IsDecimalNumber(student.Excedente))
                            {
                                PrintError("TARIFAS SOLO ACEPTAN NUMEROS DECIMALES");
                                continue;
                            }

                            RateDTO rate = new RateDTO();
                            rate.Basic_Level = Convert.ToDecimal(student.Basica, CultureInfo.InvariantCulture);
                            rate.Intermediate_Level = Convert.ToDecimal(student.Intermedia, CultureInfo.InvariantCulture);
                            rate.Surplus_Level = Convert.ToDecimal(student.Excedente, CultureInfo.InvariantCulture);
                            rate.Year = Convert.ToInt32(student.Anio, CultureInfo.InvariantCulture);
                            rate.Service = student.Servicio;
                            if (student.Servicio == "Domestico")
                            {
                                short month = Convert.ToInt16(student.Mes, CultureInfo.InvariantCulture);
                                if (month % 2 == 0)
                                {
                                    month--;
                                }
                                rate.Month = month;
                            }

                            dao.Create(rate);
                        }

                        dtgRates.DataSource = dao.ReadRates();

                        ClearForm();
                        MessageBox.Show("La operación se realizó exitosamente", "", MessageBoxButtons.OK);
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

            switch (cbService.SelectedIndex)
            {
                case 1:
                {
                    cbPeriod.Items.Add("ENERO-FEBRERO");
                    cbPeriod.Items.Add("MARZO-ABRIL");
                    cbPeriod.Items.Add("MAYO-JUNIO");
                    cbPeriod.Items.Add("JULIO-AGOSTO");
                    cbPeriod.Items.Add("SEPTIEMBRE-OCTUBRE");
                    cbPeriod.Items.Add("NOVIEMBRE-DICIEMBRE");
                    break;
                }
                case 2:
                {
                    cbPeriod.Items.Add("ENERO");
                    cbPeriod.Items.Add("FEBRERO");
                    cbPeriod.Items.Add("MARZO");
                    cbPeriod.Items.Add("ABRIL");
                    cbPeriod.Items.Add("MAYO");
                    cbPeriod.Items.Add("JUNIO");
                    cbPeriod.Items.Add("JULIO");
                    cbPeriod.Items.Add("AGOSTO");
                    cbPeriod.Items.Add("SEPTIEMBRE");
                    cbPeriod.Items.Add("OCTUBRE");
                    cbPeriod.Items.Add("NOVIEMBRE");
                    cbPeriod.Items.Add("DICIEMBRE");
                    break;
                }
            }
        }

        private void ClearForm()
        {
            cbService.SelectedIndex = 0;
            dtpPeriod.Value = DateTime.Now;
            txtBasic.Clear();
            txtIntermediate.Clear();
            txtSurplus.Clear();
        }

        private void PrintError(string error)
        {
            pbWarningIcon.Visible = true;
            lblError.Visible = true;
            lblError.Text = error;
        }
     
    }
}
