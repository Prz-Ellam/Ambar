using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ambar.Model.DAO;
using Ambar.Model.DTO;
using CsvHelper;
using PdfSharp;
using PdfSharp.Drawing;
using PdfSharp.Pdf;

namespace Ambar.ViewController
{
    public partial class RatesReport : Form
    {
        RateDAO rateDAO = new RateDAO();
        public RatesReport()
        {
            InitializeComponent();
        }

        private void RatesReport_Load(object sender, EventArgs e)
        {
            FindRates();
        }

        private void dtpYear_ValueChanged(object sender, EventArgs e)
        {
            FindRates();
        }

        private void btnCSV_Click(object sender, EventArgs e)
        {
            ofnReportCSV.FileName = string.Format("Reporte-Tarifas-{0} {1}", dtpYear.Value.Year, DateTime.Now.ToString("yyyy-MM-dd HH.mm.ss"));

            if (ofnReportCSV.ShowDialog() == DialogResult.OK)
            {
                var writer = new StreamWriter(ofnReportCSV.FileName);
                var csvWriter = new CsvWriter(writer, CultureInfo.InvariantCulture);

                IEnumerable<RatesReportDTO> rates = dtgRatesReport.DataSource as IEnumerable<RatesReportDTO>;
                if (rates == null)
                {
                    MessageBox.Show("Error inesperado", "Ambar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                csvWriter.WriteRecords(rates);
                csvWriter.Dispose();
                writer.Close();

                MessageBox.Show("La operación se realizó exitosamente", "Ambar", MessageBoxButtons.OK);
            }
        }

        private void btnPDF_Click(object sender, EventArgs e)
        {
            ofnReportPDF.FileName = string.Format("Reporte-Tarifas-{0} {1}", dtpYear.Value.Year, DateTime.Now.ToString("yyyy-MM-dd HH.mm.ss"));

            if (ofnReportPDF.ShowDialog() == DialogResult.OK)
            {
                PdfDocument document = new PdfDocument();
                PdfPage page = document.AddPage();
                XGraphics gfx = XGraphics.FromPdfPage(page);
                XImage logo = XImage.FromFile("../../Resources/Ambar_Logo.png");

                gfx.DrawImage(logo, new XRect(10, 20, 30, 42));

                gfx.DrawString("Ambar", new XFont("Arial", 24, XFontStyle.Bold), XBrushes.Black, 
                    new XRect(50, 20, page.Width, page.Height), XStringFormats.TopLeft);
                gfx.DrawString("Reporte de Tárifas", new XFont("Arial", 14), XBrushes.Black, 
                    new XRect(50, 50, page.Width, page.Height), XStringFormats.TopLeft);
                gfx.DrawString(DateTime.Now.ToString(), new XFont("Arial", 12), XBrushes.Black, 
                    new XRect(10, 25, page.Width - 20, page.Height), XStringFormats.TopRight);
                gfx.DrawLine(new XPen(XColor.FromArgb(255, 0, 0, 0)), new XPoint(10, 70), 
                    new XPoint(page.Width - 10, 70));

                gfx.DrawString("Año: ", new XFont("Arial", 12, XFontStyle.Bold), XBrushes.Black, new XPoint(10, 100));
                gfx.DrawString(dtpYear.Value.Year.ToString(), new XFont("Arial", 12), XBrushes.Black, new XPoint(45, 100));

                // Table Header
                gfx.DrawString("Año", new XFont("Arial", 10, XFontStyle.Bold), XBrushes.Black, new XPoint(10, 120));
                gfx.DrawString("Mes", new XFont("Arial", 10, XFontStyle.Bold), XBrushes.Black, new XPoint(120, 120));
                gfx.DrawString("Tárifa Básica", new XFont("Arial", 10, XFontStyle.Bold), XBrushes.Black, new XPoint(230, 120));
                gfx.DrawString("Tárifa Intermedia", new XFont("Arial", 10, XFontStyle.Bold), XBrushes.Black, new XPoint(340, 120));
                gfx.DrawString("Tárifa Excedente", new XFont("Arial", 10, XFontStyle.Bold), XBrushes.Black, new XPoint(450, 120));

                FillContentPDF(ref document, ref page, ref gfx);

                document.Save(ofnReportPDF.FileName);

                MessageBox.Show("La operación se realizó exitosamente", "Ambar", MessageBoxButtons.OK);
            }
        }
        
        private void FillContentPDF(ref PdfDocument document, ref PdfPage page, ref XGraphics gfx)
        {
            int i = 0;
            bool isFinish;
            PdfPage actualPage = page;
            XGraphics actualGfx = gfx;

            do
            {
                isFinish = IterateAbovePage(ref i, ref actualPage, ref actualGfx);

                if (!isFinish)
                {
                    actualPage = document.AddPage();
                    actualGfx = XGraphics.FromPdfPage(actualPage);
                }

            } while (!isFinish);

        }

        private bool IterateAbovePage(ref int i, ref PdfPage page, ref XGraphics gfx)
        {
            // Data Grid View Content
            for (int y = 140; i < dtgRatesReport.Rows.Count; i++, y += 20)
            {
                if (y >= page.Width - 20)
                {
                    return false;
                }

                for (int j = 0, x = 10; j < dtgRatesReport.Columns.Count; j++, x += 110)
                {
                    gfx.DrawString(dtgRatesReport.Rows[i].Cells[j].Value.ToString(), 
                        new XFont("Arial", 10), XBrushes.Black, new XPoint(x, y));
                }
            }

            return true;
        }

        private void FindRates()
        {
            List<RateDTO> rates = rateDAO.ReadRatesByYear(dtpYear.Value.Year);
            List<RatesReportDTO> ratesCSV = new List<RatesReportDTO>();
            foreach (var rate in rates)
            {
                ratesCSV.Add(new RatesReportDTO()
                {
                    Year = rate.Year,
                    Month = rate.Month,
                    Basic_Level = rate.Basic_Level,
                    Intermediate_Level = rate.Intermediate_Level,
                    Surplus_Level = rate.Surplus_Level
                });
            }
            dtgRatesReport.DataSource = ratesCSV;
        }
    }
}
