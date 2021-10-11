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

        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (txtBasic.Text == string.Empty || txtIntermediate.Text == string.Empty || txtSurplus.Text == string.Empty
                || cbService.SelectedIndex == -1)
            {
                PrintError("TODOS LOS CAMPOS SON OBLIGATORIOS");
                return;
            }

            //Regex r = new Regex("^[0-9]+$");
            //Regex r = new Regex(@"^\d+\.?\d*$");
            //if (r.IsMatch(txtBasic.Text) && r.IsMatch(txtIntermediate.Text) && r.IsMatch(txtSurplus.Text))
            //{
            //    PrintError("SOLO SE ACEPTAN CARACTERES NUMERICOS");
            //    return;
            //}
            
            RateDTO rate = new RateDTO();
            rate.Basic_Level = Convert.ToDecimal(txtBasic.Text);
            rate.Intermediate_Level = Convert.ToDecimal(txtIntermediate.Text);
            rate.Surplus_Level = Convert.ToDecimal(txtSurplus.Text);
            rate.Year = dtpPeriod.Value.Year;
            rate.Month = Convert.ToInt16(dtpPeriod.Value.Month);
            rate.Service = cbService.SelectedItem.ToString();

            dao.Create(rate);

            dtgRates.DataSource = dao.ReadAll();

            ClearForm();
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

                        dataGridView1.DataSource = dataSetXLSX.Tables[0];

                        reader.Close();
                        break;
                    }
                }

            }

        }

        private void ClearForm()
        {
            cbService.SelectedIndex = -1;
            dtpPeriod.Value = DateTime.Now;
            txtBasic.Clear();
            txtIntermediate.Clear();
            txtSurplus.Clear();
        }

        private void Rates_Load(object sender, EventArgs e)
        {
            dtgRates.DataSource = dao.ReadAll();
        }

        private void PrintError(string error)
        {
            pbWarningIcon.Visible = true;
            lblError.Visible = true;
            lblError.Text = error;
        }
    }
}
