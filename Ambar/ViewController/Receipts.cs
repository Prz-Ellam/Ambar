using Ambar.Common;
using Ambar.Model.DAO;
using Ambar.Model.DTO;
using Cassandra;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ambar.ViewController
{
    public partial class Receipts : Form
    {
        ReceiptDAO receiptDAO = new ReceiptDAO();
        DateDAO dateDAO = new DateDAO();
        public Receipts()
        {
            InitializeComponent();
        }

        private void Receipts_Load(object sender, EventArgs e)
        {
            cbService.SelectedIndex = 0;
            dtpYear.MinDate = dateDAO.GetDate();
            dtpPeriodSearch.Value = dateDAO.GetDate();
            label7.Text = dateDAO.GetDate().ToString("MMMM yyyy").ToUpper();
        }

        private void btnGenerateReceipt_Click(object sender, EventArgs e)
        {
            if (cbPeriod.SelectedIndex == -1)
            {
                MessageBox.Show("Error inesperado", "Ambar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DateTime offset = dateDAO.GetDate();
            string serviceType = cbService.SelectedItem.ToString();

            DateTime request = new DateTime(dtpYear.Value.Year, ((ComboBoxItem)cbPeriod.SelectedItem).HiddenValue, 1);
            if (request.Year != offset.Year || request.Month != offset.Month)
            {
                MessageBox.Show("No se pueden emitir recibos fuera del periodo actual de cobro", "Ambar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (serviceType == "Ambos")
            {
                if (request.Month % 2 == 0)
                {
                    GenerateReceipts(request, "Domestico");
                }
                GenerateReceipts(request, "Industrial");
            }
            else
            {
                GenerateReceipts(request, serviceType);
            }

            ClearForm();
            MessageBox.Show("La operación se realizó exitosamente", "Ambar", MessageBoxButtons.OK);
        }

        void ClearForm()
        {
            cbService.SelectedIndex = 0;
            txtFilterID.Clear();
            rbMeterSerialNumber.Checked = true;
        }

        private void DateChange()
        {
            dtpYear.MinDate = dateDAO.GetDate();
            cbPeriod.Items.Clear();
            DateTime offset = dateDAO.GetDate();

            switch (cbService.SelectedIndex)
            {
                case 2:
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
                case 1:
                case 3:
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

        private void cbService_SelectedIndexChanged(object sender, EventArgs e)
        {
            DateChange();
        }

        private void dtpYear_ValueChanged(object sender, EventArgs e)
        {
            DateChange();
        }

        private void btnPDF_Click(object sender, EventArgs e)
        {
            if (txtFilterID.Text == string.Empty)
            {
                return; // ERROR
            }

            if (ofnReceipt.ShowDialog() == DialogResult.OK)
            {
                DateTime request = new DateTime(dtpPeriodSearch.Value.Year, dtpPeriodSearch.Value.Month, 1);
                ContractDAO contractDAO = new ContractDAO();

                ReceiptDTO receipt = new ReceiptDTO();
                if (rbMeterSerialNumber.Checked)
                {
                    string serviceType = contractDAO.FindServiceType(txtFilterID.Text);
                    if (serviceType == null)
                    {
                        return;
                    }
                    if (serviceType == "Domestico" && request.Month % 2 == 1)
                    {
                        request = request.AddMonths(1); // En caso de que fuese enero se pasaria a febrero
                    }
                    receipt = receiptDAO.FindReceipt(request.Year, Convert.ToInt16(request.Month), txtFilterID.Text);
                    if (receipt == null)
                    {
                        return;
                    }
                }
                else if (rbServiceNumber.Checked)
                {
                    long filter;
                    try
                    {
                        filter = Convert.ToInt64(txtFilterID.Text);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Número de servicio no válido", "Ambar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    string serviceType = contractDAO.FindServiceType(filter);
                    if (serviceType == null)
                    {
                        return;
                    }
                    if (serviceType == "Domestico" && request.Month % 2 == 1)
                    {
                        request = request.AddMonths(1); // En caso de que fuese febrero se pasaria a enero
                    }
                    receipt = receiptDAO.FindReceipt(request.Year, Convert.ToInt16(request.Month), filter);
                    if (receipt == null)
                    {
                        return;
                    }
                }
                else
                {
                    // ERROR
                }

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

        private void PrintError(string error)
        {
            pbWarningIcon.Visible = true;
            lblError.Visible = true;
            lblError.Text = error;
        }
       

        private bool GenerateReceipts(DateTime request, string serviceType)
        {
            if (receiptDAO.FindEmission(request.Year, Convert.ToInt16(request.Month), serviceType))
            {
                PrintError("YA SE EMITIERON LOS RECIBOS DE ESTE PERIODO");
                return false;
            }

            // Generar los recibos
            ContractDAO contractDAO = new ContractDAO();
            ConsumptionDAO consumptionDAO = new ConsumptionDAO();

            // Se trae todos los contratos de un determinado servicio
            List<ContractForReceiptDTO> contractsInfo = contractDAO.ReadContractsForReceipt(cbService.SelectedItem.ToString());

            // Encuentra la tarifa del periodo
            RateDAO rateDao = new RateDAO();
            RateForReceiptDTO ratesInfo = rateDao.FindActiveRates(cbService.SelectedItem.ToString(), request.Year,
                Convert.ToInt16(request.Month));
            if (ratesInfo == null)
            {
                PrintError("NO HAY TARIFAS REGISTRADAS PARA ESTE PERIODO");
                return false;
            }

            decimal iva = Convert.ToDecimal(ConfigurationManager.AppSettings["IVA"].ToString(), CultureInfo.InvariantCulture);
            List<ReceiptDTO> receipts = new List<ReceiptDTO>();
            foreach (var contractInfo in contractsInfo)
            {
                if (receiptDAO.ReceiptExists(contractInfo.Meter_Serial_Number, request.Year, Convert.ToInt16(request.Month)))
                {
                    continue; // Ignora si ya tiene un recibo en esa fecha, por seguridad
                }

                // Validar el periodo y validar que no se haya cargado ya el recibo
                LocalDate startContractDate = contractInfo.Start_Period_Date;
                DateTime start = new DateTime(startContractDate.Year, startContractDate.Month, 1);

                if (!DateUtils.NormalizeDates(serviceType, ref start, ref request))
                {
                    MessageBox.Show("Error inesperado", "Ambar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                if (request.Year < start.Year || (request.Year == start.Year && request.Month < start.Month))
                {
                    continue; // Ignora los contratos que aun no empiezan su periodo de cobro
                }

                ConsumptionForReceiptDTO consumption = consumptionDAO.FindConsumption(request.Year,
                    Convert.ToInt16(request.Month), contractInfo.Meter_Serial_Number);
                if (consumption == null)
                {
                    PrintError("NO SE HAN CARGADO TODOS LOS CONSUMOS DE LOS CONTRATOS");
                    return false;
                }

                DateTime prevDate = request;
                if (serviceType == "Domestico")
                {
                    prevDate = request.AddMonths(-2);
                }
                else if (serviceType == "Industrial")
                {
                    prevDate = request.AddMonths(-1);
                }
                else
                {
                    return false; // ERROR
                }
                ReceiptDTO prev = receiptDAO.FindReceipt(prevDate.Year, Convert.ToInt16(prevDate.Month),
                    contractInfo.Meter_Serial_Number);

                ReceiptDTO dto = new ReceiptDTO();
                dto.Receipt_ID = Guid.NewGuid();
                dto.First_Name = contractInfo.First_Name;
                dto.Father_Last_Name = contractInfo.Father_Last_Name;
                dto.Mother_Last_Name = contractInfo.Mother_Last_Name;
                dto.State = contractInfo.State;
                dto.City = contractInfo.City;
                dto.Suburb = contractInfo.Suburb;
                dto.Street = contractInfo.Street;
                dto.Number = contractInfo.Number;
                dto.Postal_Code = contractInfo.Postal_Code;
                dto.Meter_Serial_Number = contractInfo.Meter_Serial_Number;
                dto.Service_Number = contractInfo.Service_Number;
                dto.Service = serviceType;
                dto.Year = consumption.Year;
                dto.Month = consumption.Month;
                dto.Day = consumption.Day; // Ya viene ajustado
                dto.Basic_Level = ratesInfo.Basic_Level;
                dto.Intermediate_Level = ratesInfo.Intermediate_Level;
                dto.Surplus_Level = ratesInfo.Surplus_Level;
                dto.Basic_KW = consumption.Basic_KW;
                dto.Intermediate_KW = consumption.Intermediate_KW;
                dto.Surplus_KW = consumption.Surplus_KW;
                dto.Total_KW = dto.Basic_KW + dto.Intermediate_KW + dto.Surplus_KW;
                dto.Basic_Price = Decimal.Round(dto.Basic_Level * dto.Basic_KW, 2);
                dto.Intermediate_Price = Decimal.Round(dto.Intermediate_Level * dto.Intermediate_KW, 2);
                dto.Surplus_Price = Decimal.Round(dto.Surplus_Level * dto.Surplus_KW, 2);
                dto.Tax = Decimal.Round(dto.Surplus_Price * iva, 2);
                dto.Subtotal_Price = Decimal.Round(dto.Basic_Price + dto.Intermediate_Price + dto.Surplus_Price, 2);

                if (prev == null)
                {
                    dto.Prev_Amount = 0.0m;
                    dto.Prev_Price = 0.0m;
                }
                else
                {
                    dto.Prev_Amount = prev.Amount_Pad;
                    dto.Prev_Price = prev.Total_Price;
                }

                dto.Total_Price = Decimal.Round(dto.Subtotal_Price + dto.Tax + (dto.Prev_Price - dto.Prev_Amount), 2);
                dto.Amount_Pad = 0;
                dto.Pending_Amount = Decimal.Round(dto.Total_Price, 2);

                receipts.Add(dto);
            }

            if (receipts.Count == 0)
            {
                // NO HAY NADA QUE GENERAR
            }

            receiptDAO.GenerateMassiveReceipts(receipts);
            receiptDAO.EmitReceipt(request.Year, Convert.ToInt16(request.Month), serviceType);
            dateDAO.UpdateDate(serviceType);
            label7.Text = dateDAO.GetDate().ToString("MMMM yyyy").ToUpper();
            DateChange();
            return true;
        }
    }
}
