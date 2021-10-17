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
            if (ofnReportCSV.ShowDialog() == DialogResult.OK)
            {
                var writer = new StreamWriter(ofnReportCSV.FileName);
                var csvWriter = new CsvWriter(writer, CultureInfo.InvariantCulture);

                IEnumerable<ConsumptionsReportCSV> consumptions = (IEnumerable<ConsumptionsReportCSV>)dtgConsumptionsReport.DataSource;
                csvWriter.WriteRecords(consumptions);

                csvWriter.Dispose();
                writer.Close();
            }
        }

        private void btnPDF_Click(object sender, EventArgs e)
        {
            if (ofnReportPDF.ShowDialog() == DialogResult.OK)
            {
                PdfDocument document = new PdfDocument();

                PdfPage page = document.AddPage();

                XGraphics gfx = XGraphics.FromPdfPage(page);
                XFont font = new XFont("Montserrat", 12);
                XFont titleFont = new XFont("Montserrat", 24, XFontStyle.Bold);
                XFont subtitleFont = new XFont("Montserrat", 14);
                XPen pen = new XPen(XColor.FromArgb(255, 0, 0, 0));
                XImage logo = XImage.FromFile("../../Resources/Ambar_Logo.png");

                gfx.DrawImage(logo, new XRect(10, 20, 30, 42));

                gfx.DrawString("Ambar", titleFont, XBrushes.Black, new XRect(50, 20, page.Width, page.Height),
                    XStringFormats.TopLeft);
                gfx.DrawString("Reporte de Consumos", subtitleFont, XBrushes.Black, new XRect(50, 50, page.Width, page.Height),
                    XStringFormats.TopLeft);
                gfx.DrawString(DateTime.Now.ToString(), font, XBrushes.Black, new XRect(10, 25, page.Width - 20, page.Height),
                    XStringFormats.TopRight);
                gfx.DrawLine(pen, new XPoint(10, 70), new XPoint(page.Width - 10, 70));

                string mes = string.Format("{0}", dtpYear.Value.Year);
                gfx.DrawString("Año: ", new XFont("Montserrat", 12, XFontStyle.Bold), XBrushes.Black, new XPoint(10, 100));
                gfx.DrawString(mes, new XFont("Montserrat", 12), XBrushes.Black, new XPoint(45, 100));

                // Table Header
                gfx.DrawString("Año", new XFont("Montserrat", 10, XFontStyle.Bold), XBrushes.Black, new XPoint(10, 120));
                gfx.DrawString("Mes", new XFont("Montserrat", 10, XFontStyle.Bold), XBrushes.Black, new XPoint(110, 120));
                gfx.DrawString("No. de Medidor", new XFont("Montserrat", 10, XFontStyle.Bold), XBrushes.Black, new XPoint(210, 120));
                gfx.DrawString("Básico", new XFont("Montserrat", 10, XFontStyle.Bold), XBrushes.Black, new XPoint(310, 120));
                gfx.DrawString("Intermedio", new XFont("Montserrat", 10, XFontStyle.Bold), XBrushes.Black, new XPoint(410, 120));
                gfx.DrawString("Excedente", new XFont("Montserrat", 10, XFontStyle.Bold), XBrushes.Black, new XPoint(510, 120));

                FillContentPDF(ref document, ref page, ref gfx);

                document.Save(ofnReportPDF.FileName);

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
                        new XFont("Montserrat", 10), XBrushes.Black, new XPoint(x, y));
                }
            }

            return true;
        }

        private void ConsumptionsReport_Load(object sender, EventArgs e)
        {
            List<ConsumptionDTO> rates = dao.ReadByYear(dtpYear.Value.Year);
            List<ConsumptionsReportCSV> ratesCSV = new List<ConsumptionsReportCSV>();
            foreach (var rate in rates)
            {
                ratesCSV.Add(new ConsumptionsReportCSV(rate));
            }

            dtgConsumptionsReport.DataSource = ratesCSV;
        }

        private void dtpYear_ValueChanged(object sender, EventArgs e)
        {
            List<ConsumptionDTO> rates = dao.ReadByYear(dtpYear.Value.Year);
            List<ConsumptionsReportCSV> ratesCSV = new List<ConsumptionsReportCSV>();
            foreach (var rate in rates)
            {
                ratesCSV.Add(new ConsumptionsReportCSV(rate));
            }

            dtgConsumptionsReport.DataSource = ratesCSV;
        }
    }
}
