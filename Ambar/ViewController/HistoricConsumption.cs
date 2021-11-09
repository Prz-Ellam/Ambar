using Ambar.Common;
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
    public partial class HistoricConsumption : Form
    {
        ReceiptDAO receiptDAO = new ReceiptDAO();
        ContractDAO contractDAO = new ContractDAO();
        public HistoricConsumption()
        {
            InitializeComponent();
        }

        private void HistoricConsumption_Load(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtFilter.Text == string.Empty)
            {
                MessageBox.Show("No se ha ingresado un filtro", "Ambar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int year = dtpYear.Value.Year;
            string filter = txtFilter.Text;

            List<HistoricConsumptionDTO> historicConsumption;
            if (rbMeterSerialNumber.Checked)
            {
                if (!contractDAO.ContractExists(filter))
                {
                    MessageBox.Show("El número de medidor no existe actualmente", "Ambar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    ClearForm();
                    return;
                }
                if (UserCache.position == "Client" && !contractDAO.IsClientContract(UserCache.id, filter))
                {
                    MessageBox.Show("No se puede tener acceso al numero de medidor", "Ambar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    ClearForm();
                    return;
                }

                historicConsumption = receiptDAO.HistoricConsumption(year, filter);
            }
            else if (rbServiceNumber.Checked)
            {
                if (!contractDAO.ContractExists(Convert.ToInt64(filter)))
                {
                    MessageBox.Show("El número de servicio no existe actualmente", "Ambar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    ClearForm();
                    return;
                }
                if (UserCache.position == "Client" && !contractDAO.IsClientContract(UserCache.id, Convert.ToInt64(filter)))
                {
                    MessageBox.Show("No se puede tener acceso al numero de medidor", "Ambar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    ClearForm();
                    return;
                }

                historicConsumption = receiptDAO.HistoricConsumption(year, Convert.ToInt64(filter));
            }
            else
            {
                MessageBox.Show("Error inesperado", "Ambar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            dtgHistoricConsumption.DataSource = historicConsumption;
        }

        private void btnCSV_Click(object sender, EventArgs e)
        {
            ofnReportCSV.FileName = string.Format("Reporte-General-{0} {1}", dtpYear.Value.Year, DateTime.Now.ToString("yyyy-MM-dd HH.mm.ss"));

            if (ofnReportCSV.ShowDialog() == DialogResult.OK)
            {
                var writer = new StreamWriter(ofnReportCSV.FileName);
                var csvWriter = new CsvWriter(writer, CultureInfo.InvariantCulture);

                IEnumerable<HistoricConsumptionDTO> reports = dtgHistoricConsumption.DataSource as IEnumerable<HistoricConsumptionDTO>;
                if (reports == null)
                {
                    MessageBox.Show("No es posible generar un reporte porque no hay información", "Ambar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                csvWriter.WriteRecords(reports);
                csvWriter.Dispose();
                writer.Close();

                MessageBox.Show("La operación se realizó exitosamente", "Ambar", MessageBoxButtons.OK);
            }
        }

        void ClearForm()
        {
            txtFilter.Clear();
            txtFilter.Focus();
        }

        private void btnPDF_Click(object sender, EventArgs e)
        {
            ofnReportPDF.FileName = string.Format("Historico-{0} {1} {2}", dtpYear.Value.Year, txtFilter.Text, DateTime.Now.ToString("yyyy-MM-dd HH.mm.ss"));

            if (ofnReportPDF.ShowDialog() == DialogResult.OK)
            {

                PdfDocument document = new PdfDocument();
                PdfPage page = document.AddPage();
                XGraphics gfx = XGraphics.FromPdfPage(page);
                XImage logo = XImage.FromFile("../../Resources/Ambar_Logo.png");

                gfx.DrawImage(logo, new XRect(10, 20, 30, 42));

                gfx.DrawString("Ambar", new XFont("Arial", 24, XFontStyle.Bold), XBrushes.Black,
                    new XRect(50, 20, page.Width, page.Height), XStringFormats.TopLeft);
                gfx.DrawString("Consumo Historico", new XFont("Arial", 14), XBrushes.Black,
                    new XRect(50, 50, page.Width, page.Height), XStringFormats.TopLeft);
                gfx.DrawString(DateTime.Now.ToString(), new XFont("Arial", 12), XBrushes.Black,
                    new XRect(10, 25, page.Width - 20, page.Height), XStringFormats.TopRight);
                gfx.DrawLine(new XPen(XColor.FromArgb(255, 0, 0, 0)), new XPoint(10, 70),
                    new XPoint(page.Width - 10, 70));



                gfx.DrawString("Año: ", new XFont("Arial", 12, XFontStyle.Bold), XBrushes.Black, new XPoint(10, 100));
                gfx.DrawString(dtpYear.Value.Year.ToString(), new XFont("Arial", 12), XBrushes.Black, new XPoint(45, 100));

                if (rbMeterSerialNumber.Checked)
                {
                    gfx.DrawString("Numero de Medidor: ", new XFont("Arial", 12, XFontStyle.Bold), XBrushes.Black, new XPoint(10, 120));
                    gfx.DrawString(txtFilter.Text, new XFont("Arial", 12), XBrushes.Black, new XPoint(130, 120));
                }
                else if (rbServiceNumber.Checked)
                {
                    gfx.DrawString("Numero de Servicio: ", new XFont("Arial", 12, XFontStyle.Bold), XBrushes.Black, new XPoint(10, 120));
                    gfx.DrawString(txtFilter.Text, new XFont("Arial", 12), XBrushes.Black, new XPoint(130, 120));
                }
                else
                {
                    // ERROR TODO MURIO
                    return;
                }

                // Table Header
                gfx.DrawString("Año", new XFont("Arial", 10, XFontStyle.Bold), XBrushes.Black, new XPoint(10, 140));
                gfx.DrawString("Mes", new XFont("Arial", 10, XFontStyle.Bold), XBrushes.Black, new XPoint(110, 140));
                gfx.DrawString("Consumo de kW", new XFont("Arial", 10, XFontStyle.Bold), XBrushes.Black, new XPoint(210, 140));
                gfx.DrawString("Importe", new XFont("Arial", 10, XFontStyle.Bold), XBrushes.Black, new XPoint(310, 140));
                gfx.DrawString("Pago", new XFont("Arial", 10, XFontStyle.Bold), XBrushes.Black, new XPoint(410, 140));
                gfx.DrawString("Pendiente de pago", new XFont("Arial", 10, XFontStyle.Bold), XBrushes.Black, new XPoint(510, 140));
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
            for (int y = 160; i < dtgHistoricConsumption.Rows.Count; i++, y += 20)
            {
                if (y >= page.Width - 20)
                {
                    return false;
                }

                for (int j = 0, x = 10; j < dtgHistoricConsumption.Columns.Count; j++, x += 100)
                {
                    gfx.DrawString(dtgHistoricConsumption.Rows[i].Cells[j].Value.ToString(),
                        new XFont("Arial", 10), XBrushes.Black, new XPoint(x, y));
                }
            }

            return true;
        }
    }
}
