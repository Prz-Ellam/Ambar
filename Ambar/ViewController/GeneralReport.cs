using Ambar.Common;
using Ambar.Model.DAO;
using Ambar.Model.DTO;
using Ambar.Properties;
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
    public partial class GeneralReport : Form
    {
        private ReceiptDAO receiptDAO = new ReceiptDAO();
        private DateDAO dateDAO = new DateDAO();
        public GeneralReport()
        {
            InitializeComponent();
        }

        private void GeneralReport_Load(object sender, EventArgs e)
        {
            cbService.SelectedIndex = 0;
        }

        private void cbService_SelectedIndexChanged(object sender, EventArgs e)
        {
            DateChange();
        }

        private void dtpYear_ValueChanged(object sender, EventArgs e)
        {
            DateChange();
        }

        private void DateChange()
        {
            cbPeriod.Items.Clear();

            switch (cbService.SelectedIndex)
            {
                case 0:
                case 1:
                {
                    string[] bimesters = new string[] { "TODOS", "ENERO-FEBRERO", "MARZO-ABRIL", "MAYO-JUNIO", 
                        "JULIO-AGOSTO", "SEPTIEMBRE-OCTUBRE", "NOVIEMBRE-DICIEMBRE" };
                    int[] numbers = new int[] { -1, 1, 3, 5, 7, 9, 11 };

                    for (int i = 0; i < bimesters.Length; i++)
                    {
                        cbPeriod.Items.Add(new ComboBoxItem(bimesters[i], numbers[i]));
                    }

                    cbPeriod.SelectedIndex = 0;
                    break;
                }
                case 2:
                {
                    string[] months = new string[] { "TODOS", "ENERO", "FEBRERO", "MARZO", "ABRIL", "MAYO", "JUNIO", 
                        "JULIO", "AGOSTO", "SEPTIEMBRE", "OCTUBRE", "NOVIEMBRE", "DICIEMBRE" };
                    int[] numbers = new int[] { -1, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };

                    for (int i = 0; i < months.Length; i++)
                    {
                        cbPeriod.Items.Add(new ComboBoxItem(months[i], numbers[i]));
                    }

                    cbPeriod.SelectedIndex = 0;
                    break;
                }
                default:
                {
                    cbPeriod.SelectedIndex = -1;
                    break;
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (cbPeriod.SelectedIndex < 0 || cbService.SelectedIndex < 0)
            {
                MessageBox.Show("No se ha escogido un mes o tipo de servicio", "Ambar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int year = dtpYear.Value.Year;
            short period = Convert.ToInt16(((ComboBoxItem)cbPeriod.SelectedItem).HiddenValue);
            string service = cbService.SelectedItem.ToString();
            List<GeneralReportDTO> generalReport;
            if (service == "Todos")
            {
                if (period == -1)
                {
                    generalReport = receiptDAO.GeneralReport(year);
                }
                else
                {
                    generalReport = receiptDAO.GeneralReport(year, period);
                }
            }
            else
            {
                if (period == -1)
                {
                    generalReport = receiptDAO.GeneralReport(year, service);
                }
                else
                {
                    generalReport = receiptDAO.GeneralReport(year, period, service);
                }
            }

            dtgGeneralReport.DataSource = generalReport;
        }

        private void btnCSV_Click(object sender, EventArgs e)
        {
            ofnReportCSV.FileName = string.Format("Reporte-General-{0} {1}", dtpYear.Value.Year, DateTime.Now.ToString("yyyy-MM-dd HH.mm.ss"));

            if (ofnReportCSV.ShowDialog() == DialogResult.OK)
            {
                var writer = new StreamWriter(ofnReportCSV.FileName);
                var csvWriter = new CsvWriter(writer, CultureInfo.InvariantCulture);

                IEnumerable<GeneralReportDTO> reports = dtgGeneralReport.DataSource as IEnumerable<GeneralReportDTO>;
                if (reports == null)
                {
                    MessageBox.Show("Error inesperado", "Ambar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                csvWriter.WriteRecords(reports);
                csvWriter.Dispose();
                writer.Close();

                MessageBox.Show("La operación se realizó exitosamente", "Ambar", MessageBoxButtons.OK);
            }
        }

        private void btnPDF_Click(object sender, EventArgs e)
        {
            ofnReportPDF.FileName = string.Format("Reporte-General-{0} {1}", dtpYear.Value.Year, DateTime.Now.ToString("yyyy-MM-dd HH.mm.ss"));

            if (ofnReportPDF.ShowDialog() == DialogResult.OK)
            {
                PdfDocument document = new PdfDocument();
                PdfPage page = document.AddPage();
                XGraphics gfx = XGraphics.FromPdfPage(page);
                XImage logo = XImage.FromFile("../../Resources/Ambar_Logo.png");

                gfx.DrawImage(logo, new XRect(10, 20, 30, 42));

                gfx.DrawString("Ambar", new XFont("Arial", 24, XFontStyle.Bold), XBrushes.Black,
                    new XRect(50, 20, page.Width, page.Height), XStringFormats.TopLeft);
                gfx.DrawString("Reporte General", new XFont("Arial", 14), XBrushes.Black,
                    new XRect(50, 50, page.Width, page.Height), XStringFormats.TopLeft);
                gfx.DrawString(DateTime.Now.ToString(), new XFont("Arial", 12), XBrushes.Black,
                    new XRect(10, 25, page.Width - 20, page.Height), XStringFormats.TopRight);
                gfx.DrawLine(new XPen(XColor.FromArgb(255, 0, 0, 0)), new XPoint(10, 70),
                    new XPoint(page.Width - 10, 70));




                gfx.DrawString("Año: ", new XFont("Arial", 12, XFontStyle.Bold), XBrushes.Black, new XPoint(10, 100));
                gfx.DrawString(dtpYear.Value.Year.ToString(), new XFont("Arial", 12), XBrushes.Black, new XPoint(45, 100));

                short month = Convert.ToInt16(((ComboBoxItem)cbPeriod.SelectedItem).HiddenValue);
                string monthStr = (month == -1) ? "Todos" : new DateTime(2010, month, 1).ToString("MMMM").ToUpper();
                gfx.DrawString("Mes: ", new XFont("Arial", 12, XFontStyle.Bold), XBrushes.Black, new XPoint(10, 120));
                gfx.DrawString(monthStr, new XFont("Arial", 12), XBrushes.Black, new XPoint(45, 120));

                gfx.DrawString("Servicio: ", new XFont("Arial", 12, XFontStyle.Bold), XBrushes.Black, new XPoint(10, 140));
                gfx.DrawString(cbService.SelectedItem.ToString(), new XFont("Arial", 12), XBrushes.Black, new XPoint(70, 140));

                // Table Header
                gfx.DrawString("Año", new XFont("Arial", 10, XFontStyle.Bold), XBrushes.Black, new XPoint(10, 160));
                gfx.DrawString("Mes", new XFont("Arial", 10, XFontStyle.Bold), XBrushes.Black, new XPoint(120, 160));
                gfx.DrawString("Servicio", new XFont("Arial", 10, XFontStyle.Bold), XBrushes.Black, new XPoint(230, 160));
                gfx.DrawString("Total Pagado", new XFont("Arial", 10, XFontStyle.Bold), XBrushes.Black, new XPoint(340, 160));
                gfx.DrawString("Pendiente de pago", new XFont("Arial", 10, XFontStyle.Bold), XBrushes.Black, new XPoint(450, 160));
                // 120 TO 160
                FillContentPDF(ref document, ref page, ref gfx);

                document.Save(ofnReportPDF.FileName);

                MessageBox.Show("La operación se realizó exitosamente", "Ambar", MessageBoxButtons.OK);
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
            for (int y = 180; i < dtgGeneralReport.Rows.Count; i++, y += 20)
            {
                if (y >= page.Width - 20)
                {
                    return false;
                }

                for (int j = 0, x = 10; j < dtgGeneralReport.Columns.Count; j++, x += 110)
                {
                    gfx.DrawString(dtgGeneralReport.Rows[i].Cells[j].Value.ToString(),
                        new XFont("Arial", 10), XBrushes.Black, new XPoint(x, y));
                }
            }

            return true;
        }

    }
}
