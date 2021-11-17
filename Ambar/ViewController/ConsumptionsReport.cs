using Ambar.Model.DAO;
using Ambar.Model.DTO;
using CsvHelper;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
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

namespace Ambar.ViewController
{
    public partial class ConsumptionsReport : Form
    {

        ConsumptionDAO dao = new ConsumptionDAO();
        public ConsumptionsReport()
        {
            InitializeComponent();
        }

        private void btnCSV_Click(object sender, EventArgs e)
        {
            ofnReportCSV.FileName = string.Format("Reporte-Consumos-{0} {1}", dtpYear.Value.Year, DateTime.Now.ToString("yyyy-MM-dd HH.mm.ss"));

            if (ofnReportCSV.ShowDialog() == DialogResult.OK)
            {
                var writer = new StreamWriter(ofnReportCSV.FileName);
                var csvWriter = new CsvWriter(writer, CultureInfo.InvariantCulture);

                IEnumerable<ConsumptionsReportDTO> consumptions = dtgConsumptionsReport.DataSource as IEnumerable<ConsumptionsReportDTO>;
                if (consumptions == null)
                {
                    MessageBox.Show("Error inesperado", "Ambar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                csvWriter.WriteRecords(consumptions);
                csvWriter.Dispose();
                writer.Close();
            }
        }

        private void btnPDF_Click(object sender, EventArgs e)
        {
            ofnReportPDF.FileName = string.Format("Reporte-Consumos-{0} {1}", dtpYear.Value.Year, DateTime.Now.ToString("yyyy-MM-dd HH.mm.ss"));

            if (ofnReportPDF.ShowDialog() == DialogResult.OK)
            {
                PdfDocument document = new PdfDocument();
                PdfPage page = document.AddPage();
                XGraphics gfx = XGraphics.FromPdfPage(page);
                XImage logo = XImage.FromFile("../../Resources/Ambar_Logo.png");

                gfx.DrawImage(logo, new XRect(10, 20, 30, 42));

                gfx.DrawString("Ambar", new XFont("Arial", 24, XFontStyle.Bold), XBrushes.Black,
                    new XRect(50, 20, page.Width, page.Height), XStringFormats.TopLeft);
                gfx.DrawString("Reporte de Consumos", new XFont("Arial", 14), XBrushes.Black,
                    new XRect(50, 50, page.Width, page.Height), XStringFormats.TopLeft);
                gfx.DrawString(DateTime.Now.ToString(), new XFont("Arial", 12), XBrushes.Black,
                    new XRect(10, 25, page.Width - 20, page.Height), XStringFormats.TopRight);
                gfx.DrawLine(new XPen(XColor.FromArgb(255, 0, 0, 0)), new XPoint(10, 70),
                    new XPoint(page.Width - 10, 70));

                gfx.DrawString("Año: ", new XFont("Arial", 12, XFontStyle.Bold), XBrushes.Black, new XPoint(10, 100));
                gfx.DrawString(dtpYear.Value.Year.ToString(), new XFont("Arial", 12), XBrushes.Black, new XPoint(45, 100));

                // Table Header
                gfx.DrawString("Año", new XFont("Arial", 10, XFontStyle.Bold), XBrushes.Black, new XPoint(10, 120));
                gfx.DrawString("Mes", new XFont("Arial", 10, XFontStyle.Bold), XBrushes.Black, new XPoint(110, 120));
                gfx.DrawString("No. de Medidor", new XFont("Arial", 10, XFontStyle.Bold), XBrushes.Black, new XPoint(210, 120));
                gfx.DrawString("Básico", new XFont("Arial", 10, XFontStyle.Bold), XBrushes.Black, new XPoint(310, 120));
                gfx.DrawString("Intermedio", new XFont("Arial", 10, XFontStyle.Bold), XBrushes.Black, new XPoint(410, 120));
                gfx.DrawString("Excedente", new XFont("Arial", 10, XFontStyle.Bold), XBrushes.Black, new XPoint(510, 120));

                FillContentPDF(ref document, ref page, ref gfx);

                document.Save(ofnReportPDF.FileName);

                MessageBox.Show("La operación se realizó éxitosamente", "Ambar", MessageBoxButtons.OK);
            }
        }

        private void FillContentPDF(ref PdfDocument document, ref PdfPage page, ref XGraphics gfx)
        {
            int i = 0;
            bool isFinish = false;
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
            for (int y = 140; i < dtgConsumptionsReport.Rows.Count; i++, y += 20)
            {
                if (y >= page.Width - 20)
                {
                    return false;
                }

                for (int j = 0, x = 10; j < dtgConsumptionsReport.Columns.Count; j++, x += 100)
                {
                    gfx.DrawString(dtgConsumptionsReport.Rows[i].Cells[j].Value.ToString(),
                        new XFont("Arial", 10), XBrushes.Black, new XPoint(x, y));
                }
            }

            return true;
        }

        private void ConsumptionsReport_Load(object sender, EventArgs e)
        {
            FindConsumptions();
        }

        private void dtpYear_ValueChanged(object sender, EventArgs e)
        {
            FindConsumptions();
        }

        private void FindConsumptions()
        {
            List<ConsumptionDTO> consumptions = dao.ReadConsumptionsByYear(dtpYear.Value.Year);
            List<ConsumptionsReportDTO> ratesCSV = new List<ConsumptionsReportDTO>();
            foreach (var consumption in consumptions)
            {
                ratesCSV.Add(new ConsumptionsReportDTO()
                {
                    Year = consumption.Year,
                    Month = consumption.Month,
                    Meter_Serial_Number = consumption.Meter_Serial_Number,
                    Basic_KW = consumption.Basic_KW,
                    Intermediate_KW = consumption.Intermediate_KW,
                    Surplus_KW = consumption.Surplus_KW
                });
            }
            dtgConsumptionsReport.DataSource = ratesCSV;
        }
    }
}
