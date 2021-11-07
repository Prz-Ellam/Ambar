using Ambar.Common;
using Ambar.Model.DAO;
using Ambar.Model.DTO;
using CsvHelper;
using ExcelDataReader;
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
    public partial class ClientReceipts : Form
    {
        ReceiptDAO receiptDAO = new ReceiptDAO();
        ReceiptDTO receipt;
        DateDAO dateDAO = new DateDAO();
        public ClientReceipts()
        {
            InitializeComponent();
        }

        private void ClientReceipts_Load(object sender, EventArgs e)
        {
            ContractDAO contractDAO = new ContractDAO();
            ClientDAO clientDAO = new ClientDAO();
            dtgContracts.DataSource = contractDAO.ReadClientContracts(clientDAO.FindClientID(UserCache.username));
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            DateTime request = new DateTime(dtpPeriodSearch.Value.Year, dtpPeriodSearch.Value.Month, 1);
            
            ContractDAO contractDAO = new ContractDAO();
            string serviceType = contractDAO.FindServiceType(txtMeterSerialNumber.Text);
            if (serviceType == null)
            {
                return;
            }
            if (serviceType == "Domestico" && request.Month % 2 == 1)
            {
                request = request.AddMonths(1); // En caso de que fuese enero se pasaria a febrero
            }
            receipt = receiptDAO.FindReceipt(request.Year, Convert.ToInt16(request.Month), txtMeterSerialNumber.Text);
            if (receipt == null)
            {
                return;
            }

            lblImport.Text = receipt.Total_Price.ToString("0.00");
            lblAmountPad.Text = receipt.Amount_Pad.ToString("0.00");
            lblPendingPaid.Text = receipt.Pending_Amount.ToString("0.00");
            lblStatus.Text = string.Format("{0:Pagado;0;No Pagado}", receipt.Is_Paid.GetHashCode());
            nudMount.Maximum = Convert.ToDecimal(receipt.Pending_Amount.ToString("0.00"));

            if (receipt.Is_Paid)
            {
                btnPaid.Enabled = false;
            }

            DateTime offset = dateDAO.GetDate();
            if (request.Year != offset.Year || request.Month != offset.Month)
            {
                MessageBox.Show("No se puede pagar un recibo fuera del periodo actual de cobro", "Ambar", MessageBoxButtons.OK);
                return;
            }

        }

        private void btnPaid_Click(object sender, EventArgs e)
        {
            if (nudMount.Value == 0.0m)
            {
                return; // ERROR: No puedes hacer un tramite de nada, no nos hagas perder el tiempo somos una empresa seria
            }

            string paymentType;
            if (rbCash.Checked)
            {
                paymentType = "Efectivo";
            }
            else if (rbDebit.Checked)
            {
                paymentType = "Tarjeta de Debito";
            }
            else if (rbCredit.Checked)
            {
                paymentType = "Tarjeta de Credito";
            }
            else if (rbTransfer.Checked)
            {
                paymentType = "Transferencia Bancaria";
            }
            else
            {
                return; // ERROR
            }

            receiptDAO.PaidReceipt(receipt, nudMount.Value, Convert.ToDecimal(lblAmountPad.Text), 
                Convert.ToDecimal(lblPendingPaid.Text), paymentType);

            ClearForm();
            MessageBox.Show("La operación se realizó exitosamente", "Ambar", MessageBoxButtons.OK);
        }


        private void ClearForm()
        {
            txtMeterSerialNumber.Clear();
            nudMount.Value = 0.0m;
            rbCash.Checked = true;
            lblImport.Text = string.Empty;
            lblAmountPad.Text = string.Empty;
            lblPendingPaid.Text = string.Empty;
        }

        private void btnMassivePaid_Click(object sender, EventArgs e)
        {
            if (ofnMassive.ShowDialog() == DialogResult.OK)
            {
                switch (ofnMassive.FilterIndex)
                {
                    case 1: // CSV
                    {
                        StreamReader reader;
                        CsvReader csvReader;
                        List<PaymentCSV> ratesCSV;
                        try
                        {
                            reader = File.OpenText(ofnMassive.FileName);
                            csvReader = new CsvReader(reader, CultureInfo.CurrentCulture);
                            ratesCSV = csvReader.GetRecords<PaymentCSV>().ToList();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("No se pudo abrir el archivo", "Ambar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }


                        //List<PaymentDTO> finalPayments = new List<PaymentDTO>();
                        //bool isCorrect = true;
                        //foreach (var paymentCSV in finalPayments)
                        //{
                        //    if (!Validate(paymentCSV))
                        //    {
                        //        finalPayments.Clear();
                        //        isCorrect = false;
                        //        break;
                        //    }
                        //
                        //    PaymentDTO consumption = FillPayment(paymentCSV);
                        //    finalPayments.Add(consumption);
                        //}
                        //
                        //foreach (var payment in finalPayments)
                        //{
                        //    receiptDAO.PaidReceipt(payment.receipt_dto, payment.paid, payment.amount_paid,
                        //    payment.pending_amount, payment.payment_type);
                        //}








                        break;
                    }
                    case 2:
                    {
                        FileStream reader;
                        IExcelDataReader xlsxReader;
                        DataSet dataSetXLSX;
                        List<PaymentCSV> consumptionsCSV;
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
                            consumptionsCSV = (from row in dataTable.AsEnumerable()
                                               select new PaymentCSV()
                                               {
                                                   Medidor = row["Numero de Medidor"].ToString(),
                                                   MetodoDePago = row["Metodo de Pago"].ToString(),
                                                   Pago = row["Pago"].ToString(),
                                                   Mes = row["Mes"].ToString(),
                                                   Anio = row["Anio"].ToString()
                                               }).ToList();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("No se pudo abrir el archivo", "Ambar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }











                        break;
                    }
                }
            }
        }

        private void btnPDF_Click(object sender, EventArgs e)
        {
            if (ofnReceipt.ShowDialog() == DialogResult.OK)
            {

                PdfDocument document = new PdfDocument();
                PdfPage page = document.AddPage();

                XGraphics gfx = XGraphics.FromPdfPage(page);
                XFont font = new XFont("Arial", 12);
                XFont titleFont = new XFont("Arial", 12, XFontStyle.Bold);
                XFont subtitleFont = new XFont("Arial", 14);
                XPen pen = new XPen(XColor.FromArgb(255, 0, 0, 0));
                XImage logo = XImage.FromFile("../../Resources/Ambar_Logo.png");

                gfx.DrawImage(logo, new XRect(10, 20, 30, 42));

                gfx.DrawString("Ambar", titleFont, XBrushes.Black, new XRect(50, 20, page.Width, page.Height),
                    XStringFormats.TopLeft);
                gfx.DrawString("Recibo", subtitleFont, XBrushes.Black, new XRect(50, 50, page.Width, page.Height),
                    XStringFormats.TopLeft);


                string fullName = "{0} {1} {2}";
                fullName = string.Format(fullName, receipt.Father_Last_Name, receipt.Mother_Last_Name, receipt.First_Name);
                gfx.DrawString(fullName, new XFont("Arial", 14, XFontStyle.Bold), XBrushes.Black, new XPoint(10, 120));

                string address = "{0} {1} CP. {2}";
                address = string.Format(address, receipt.Street, receipt.Number, receipt.Postal_Code);
                gfx.DrawString(address, new XFont("Arial", 12), XBrushes.Black, new XPoint(10, 140));
                address = "{0} CP. {1}";
                address = string.Format(address, receipt.Suburb, receipt.Postal_Code);
                gfx.DrawString(address, new XFont("Arial", 12), XBrushes.Black, new XPoint(10, 160));
                address = "{0}, {1}";
                address = string.Format(address, receipt.City, receipt.State);
                gfx.DrawString(address, new XFont("Arial", 12), XBrushes.Black, new XPoint(10, 180));


                gfx.DrawString("NO. DE SERVICIO: ", new XFont("Arial", 12, XFontStyle.Bold), XBrushes.Black, new XPoint(10, 200));
                gfx.DrawString(receipt.Service_Number.ToString(), new XFont("Arial", 12), XBrushes.Black, new XPoint(120, 200));

                gfx.DrawString("PERIODO FACTURADO: ", new XFont("Arial", 12, XFontStyle.Bold), XBrushes.Black, new XPoint(10, 220));

                DateTime start = new DateTime(receipt.Year, receipt.Month, receipt.Day);
                DateTime end;
                if (receipt.Service == "Domestico")
                {
                    end = start.AddMonths(2);
                }
                else if (receipt.Service == "Industrial")
                {
                    end = start.AddMonths(1);
                }
                else
                {
                    return; // ERROR
                }
                end = end.AddDays(-1);

                string period = start.ToString("dd MMM yy").ToUpper() + " - " + end.ToString("dd MMM yy").ToUpper();
                gfx.DrawString(period, new XFont("Arial", 12), XBrushes.Black, new XPoint(160, 220));

                gfx.DrawString("LÍMITE DE PAGO: ", new XFont("Arial", 12, XFontStyle.Bold), XBrushes.Black, new XPoint(10, 240));
                DateTime expirationDay = end.AddDays(19);
                gfx.DrawString(expirationDay.ToString("dd MMM yy").ToUpper(), new XFont("Arial", 12), XBrushes.Black, new XPoint(150, 240));

                gfx.DrawString("CORTE A PARTIR: ", new XFont("Arial", 12, XFontStyle.Bold), XBrushes.Black, new XPoint(10, 260));
                DateTime cutDay = expirationDay.AddDays(1);
                gfx.DrawString(cutDay.ToString("dd MMM yy").ToUpper(), new XFont("Arial", 12), XBrushes.Black, new XPoint(150, 260));

                gfx.DrawString("NO. MEDIDOR: ", new XFont("Arial", 12, XFontStyle.Bold), XBrushes.Black, new XPoint(10, 280));
                gfx.DrawString(receipt.Meter_Serial_Number, new XFont("Arial", 12), XBrushes.Black, new XPoint(100, 280));

                gfx.DrawString("Básico: ", new XFont("Arial", 12, XFontStyle.Bold), XBrushes.Black, new XPoint(10, 340));
                gfx.DrawString(receipt.Basic_KW.ToString(), new XFont("Arial", 12), XBrushes.Black, new XPoint(120, 340));
                gfx.DrawString(receipt.Basic_Level.ToString("0.000"), new XFont("Arial", 12), XBrushes.Black, new XPoint(200, 340));
                gfx.DrawString(receipt.Basic_Price.ToString("0.00"), new XFont("Arial", 12), XBrushes.Black, new XPoint(280, 340));

                gfx.DrawString("Intermedio: ", new XFont("Arial", 12, XFontStyle.Bold), XBrushes.Black, new XPoint(10, 360));
                gfx.DrawString(receipt.Intermediate_KW.ToString(), new XFont("Arial", 12), XBrushes.Black, new XPoint(120, 360));
                gfx.DrawString(receipt.Intermediate_Level.ToString("0.000"), new XFont("Arial", 12), XBrushes.Black, new XPoint(200, 360));
                gfx.DrawString(receipt.Intermediate_Price.ToString("0.00"), new XFont("Arial", 12), XBrushes.Black, new XPoint(280, 360));

                gfx.DrawString("Excedente: ", new XFont("Arial", 12, XFontStyle.Bold), XBrushes.Black, new XPoint(10, 380));
                gfx.DrawString(receipt.Surplus_KW.ToString(), new XFont("Arial", 12), XBrushes.Black, new XPoint(120, 380));
                gfx.DrawString(receipt.Surplus_Level.ToString("0.000"), new XFont("Arial", 12), XBrushes.Black, new XPoint(200, 380));
                gfx.DrawString(receipt.Surplus_Price.ToString("0.00"), new XFont("Arial", 12), XBrushes.Black, new XPoint(280, 380));

                gfx.DrawString(receipt.Total_KW.ToString(), new XFont("Arial", 12), XBrushes.Black, new XPoint(120, 400));
                gfx.DrawString(receipt.Subtotal_Price.ToString("0.00"), new XFont("Arial", 12), XBrushes.Black, new XPoint(280, 400));


                gfx.DrawString("Energía", new XFont("Arial", 12), XBrushes.Black, new XPoint(10, 440));
                gfx.DrawString(receipt.Subtotal_Price.ToString("0.00"), new XFont("Arial", 12), XBrushes.Black, new XPoint(120, 440));
                gfx.DrawString("IVA 16%", new XFont("Arial", 12), XBrushes.Black, new XPoint(10, 460));
                gfx.DrawString(receipt.Tax.ToString("0.00"), new XFont("Arial", 12), XBrushes.Black, new XPoint(120, 460));
                gfx.DrawString("Fac. del Periodo", new XFont("Arial", 12), XBrushes.Black, new XPoint(10, 480));
                gfx.DrawString((receipt.Subtotal_Price + receipt.Tax).ToString("0.00"), new XFont("Arial", 12), XBrushes.Black, new XPoint(120, 480));

                gfx.DrawString("Adeudo Anterior", new XFont("Arial", 12), XBrushes.Black, new XPoint(10, 500));
                gfx.DrawString(receipt.Prev_Price.ToString("0.00"), new XFont("Arial", 12), XBrushes.Black, new XPoint(120, 500));

                gfx.DrawString("Su pago", new XFont("Arial", 12), XBrushes.Black, new XPoint(10, 520));
                gfx.DrawString(receipt.Prev_Amount.ToString("0.00"), new XFont("Arial", 12), XBrushes.Black, new XPoint(120, 520));

                gfx.DrawString("Total", new XFont("Arial", 12), XBrushes.Black, new XPoint(10, 540));
                gfx.DrawString("$" + receipt.Total_Price.ToString("0.00"), new XFont("Arial", 12), XBrushes.Black, new XPoint(120, 540));


                gfx.DrawString("TOTAL A PAGAR", new XFont("Arial", 12), XBrushes.Black, new XPoint(360, 40));
                gfx.DrawString("$" + Decimal.Truncate(receipt.Total_Price), new XFont("Arial", 24), XBrushes.Black, new XPoint(360, 70));
                string number = NumericUtils.GetNumberString(Convert.ToInt32(Decimal.Truncate(receipt.Total_Price)));
                gfx.DrawString("(" + number + " PESOS M.N.)", new XFont("Arial", 8), XBrushes.Black, new XPoint(360, 90));

                document.Save(ofnReceipt.FileName);

                ClearForm();
                MessageBox.Show("La operación se realizó exitosamente", "Ambar", MessageBoxButtons.OK);
            }
        }
    }
}
