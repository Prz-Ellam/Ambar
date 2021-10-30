using Ambar.Common;
using Ambar.Model.DAO;
using Ambar.Model.DTO;
using Ambar.Properties;
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
        public Receipts()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Generar los recibos
            ContractDAO contractDAO = new ContractDAO();
            ConsumptionDAO consumptionDAO = new ConsumptionDAO();
            List<ContractForReceiptDTO> contractsInfo = contractDAO.ReadContractsForReceipt(cbService.SelectedItem.ToString());

            int actualYear = dtpYear.Value.Year;
            short month;

            month = Convert.ToInt16(((ComboBoxItem)cbPeriod.SelectedItem).HiddenValue);

            RateDAO rateDao = new RateDAO();
            RateForReceiptDTO ratesInfo = rateDao.FindActiveRates(cbService.SelectedItem.ToString(), dtpYear.Value.Year, month);
            if (ratesInfo == null)
            {
                PrintError("NO HAY TARIFAS REGISTRADAS PARA ESTE PERIODO");
                // ERROR : No hay tarifa registrada para este periodo
            }

            List<ReceiptDTO> receipts = new List<ReceiptDTO>();
            foreach (var contractInfo in contractsInfo)
            {
                if (receiptDAO.ReceiptExists(contractInfo.Meter_Serial_Number, actualYear, month))
                {
                    continue; // Ignora si ya tiene un recibo en esa fecha
                }

                ConsumptionForReceiptDTO register;

                // Validar el periodo y validar que no se haya cargado ya el recibo
                LocalDate startDate = contractInfo.Start_Period_Date;
                int startPeriod;
                int actualPeriod;
                int startYear = startDate.Year;
                string serviceType = cbService.SelectedItem.ToString();

                if (serviceType == "Domestico" || serviceType == "Doméstico")
                {
                    startPeriod = (startDate.Month - 1) / 2;
                    actualPeriod = (month - 1) / 2;
                }
                else if (serviceType == "Industrial")
                {
                    startPeriod = startDate.Month - 1;
                    actualPeriod = month - 1;
                }
                else
                {
                    return; // ERROR (Esto no deberia ocurrir nunca)
                }

                if (actualYear < startYear || (actualYear == startYear && actualPeriod < startPeriod))
                {
                    continue; // Ignora los contratos que aun no empiezan su periodo de cobro
                }

                register = consumptionDAO.FindConsumption(dtpYear.Value.Year, month, contractInfo.Meter_Serial_Number);

                if (register == null)
                {
                    PrintError("NO SE HAN CARGADO TODOS LOS CONSUMOS DE LOS CONTRATOS");
                    // return;
                    // ERROR: NO SE HAN CARGADO LOS CONSUMOS DE TODOS LOS CONTRATOS
                }

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
                dto.Service = cbService.SelectedItem.ToString();
                dto.Year = actualYear;
                dto.Month = month;
                dto.Basic_Level = ratesInfo.Basic_Level;
                dto.Intermediate_Level = ratesInfo.Intermediate_Level;
                dto.Surplus_Level = ratesInfo.Surplus_Level;
                dto.Basic_KW = register.Basic_KW;
                dto.Intermediate_KW = register.Intermediate_KW;
                dto.Surplus_KW = register.Surplus_KW;
                dto.Total_KW = dto.Basic_KW + dto.Intermediate_KW + dto.Surplus_KW;
                dto.Basic_Price = dto.Basic_Level * dto.Basic_KW;
                dto.Intermediate_Price = dto.Intermediate_Level * dto.Intermediate_KW;
                dto.Surplus_Price = dto.Surplus_Level * dto.Surplus_KW;
                dto.Tax = Convert.ToDecimal(ConfigurationManager.AppSettings["IVA"].ToString(), CultureInfo.InvariantCulture);
                dto.Subtotal_Price = dto.Basic_Price + dto.Intermediate_Price + dto.Surplus_Price;
                dto.Total_Price = dto.Subtotal_Price + dto.Subtotal_Price * dto.Tax;
                dto.Amount_Pad = 0;
                dto.Pending_Amount = dto.Total_Price;

                receipts.Add(dto);
            }

            if (receipts.Count == 0)
            {
                // NO HAY NADA QUE GENERAR
                return;
            }

            receiptDAO.GenerateMassiveReceipts(receipts);

            ClearForm();
            MessageBox.Show("La operación se realizó exitosamente", "Ambar", MessageBoxButtons.OK);

            int a = 5;
            a = 3;
        }

        void ClearForm()
        {
            cbService.SelectedIndex = 0;
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

        private void Receipts_Load(object sender, EventArgs e)
        {
            cbService.SelectedIndex = 0;
            dtpYear.MinDate = Convert.ToDateTime(Settings.Default.DateOffset).AddMonths(1);
        }

        private void btnPDF_Click(object sender, EventArgs e)
        {
            if (ofnReceipt.ShowDialog() == DialogResult.OK)
            {
                ReceiptDTO receipt = receiptDAO.FindReceipt(dtpPeriodSearch.Value.Year, 
                    Convert.ToInt16(dtpPeriodSearch.Value.Month), 
                    txtMeterSerialNumber.Text);

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
                gfx.DrawString(receipt.Service_Number.ToString(), new XFont("Arial", 14), XBrushes.Black, new XPoint(120, 200));

                gfx.DrawString("PERIODO FACTURADO: ", new XFont("Arial", 12, XFontStyle.Bold), XBrushes.Black, new XPoint(10, 220));
                //DateTime start = new DateTime(1, receipt.Month, receipt.Year);
                //DateTime end = start.AddMonths(2);

                gfx.DrawString("Básico: ", new XFont("Arial", 12, XFontStyle.Bold), XBrushes.Black, new XPoint(10, 280));
                gfx.DrawString(receipt.Basic_KW.ToString(), new XFont("Arial", 12), XBrushes.Black, new XPoint(120, 280));
                gfx.DrawString(receipt.Basic_Level.ToString("0.000"), new XFont("Arial", 12), XBrushes.Black, new XPoint(200, 280));
                gfx.DrawString(receipt.Basic_Price.ToString("0.00"), new XFont("Arial", 12), XBrushes.Black, new XPoint(280, 280));

                gfx.DrawString("Intermedio: ", new XFont("Arial", 12, XFontStyle.Bold), XBrushes.Black, new XPoint(10, 300));
                gfx.DrawString(receipt.Intermediate_KW.ToString(), new XFont("Arial", 12), XBrushes.Black, new XPoint(120, 300));
                gfx.DrawString(receipt.Intermediate_Level.ToString("0.000"), new XFont("Arial", 12), XBrushes.Black, new XPoint(200, 300));
                gfx.DrawString(receipt.Intermediate_Price.ToString("0.00"), new XFont("Arial", 12), XBrushes.Black, new XPoint(280, 300));

                gfx.DrawString("Excedente: ", new XFont("Arial", 12, XFontStyle.Bold), XBrushes.Black, new XPoint(10, 320));
                gfx.DrawString(receipt.Surplus_KW.ToString(), new XFont("Arial", 12), XBrushes.Black, new XPoint(120, 320));
                gfx.DrawString(receipt.Surplus_Level.ToString("0.000"), new XFont("Arial", 12), XBrushes.Black, new XPoint(200, 320));
                gfx.DrawString(receipt.Surplus_Price.ToString("0.00"), new XFont("Arial", 12), XBrushes.Black, new XPoint(280, 320));

                gfx.DrawString(receipt.Total_KW.ToString(), new XFont("Arial", 12), XBrushes.Black, new XPoint(120, 340));
                gfx.DrawString(receipt.Subtotal_Price.ToString("0.00"), new XFont("Arial", 12), XBrushes.Black, new XPoint(280, 340));


                gfx.DrawString("Energía", new XFont("Arial", 12), XBrushes.Black, new XPoint(10, 400));
                gfx.DrawString(receipt.Subtotal_Price.ToString("0.00"), new XFont("Arial", 12), XBrushes.Black, new XPoint(120, 400));
                gfx.DrawString("IVA 16%", new XFont("Arial", 12), XBrushes.Black, new XPoint(10, 420));
                gfx.DrawString((receipt.Subtotal_Price * receipt.Tax).ToString("0.00"), new XFont("Arial", 12), XBrushes.Black, new XPoint(120, 420));
                gfx.DrawString("Fac. del Periodo", new XFont("Arial", 12), XBrushes.Black, new XPoint(10, 440));
                gfx.DrawString("Total", new XFont("Arial", 12), XBrushes.Black, new XPoint(10, 460));
                gfx.DrawString("$" + receipt.Total_Price.ToString("0.00"), new XFont("Arial", 12), XBrushes.Black, new XPoint(120, 460));


                gfx.DrawString("TOTAL A PAGAR", new XFont("Arial", 12), XBrushes.Black, new XPoint(360, 40));
                gfx.DrawString("$" + Decimal.Truncate(receipt.Total_Price), new XFont("Arial", 24), XBrushes.Black, new XPoint(360, 70));
                string number = GetNumberString(Convert.ToInt32(Decimal.Truncate(receipt.Total_Price)));
                gfx.DrawString("(" + number + " PESOS M.N.)", new XFont("Arial", 8), XBrushes.Black, new XPoint(360, 90));
                // gfx.DrawString()
                // Table Header
                //gfx.DrawString("Mes", new XFont("Montserrat", 10, XFontStyle.Bold), XBrushes.Black, new XPoint(110, 120));
                //gfx.DrawString("No. de Medidor", new XFont("Montserrat", 10, XFontStyle.Bold), XBrushes.Black, new XPoint(210, 120));
                //gfx.DrawString("Básico", new XFont("Montserrat", 10, XFontStyle.Bold), XBrushes.Black, new XPoint(310, 120));
                //gfx.DrawString("Intermedio", new XFont("Montserrat", 10, XFontStyle.Bold), XBrushes.Black, new XPoint(410, 120));
                //gfx.DrawString("Excedente", new XFont("Montserrat", 10, XFontStyle.Bold), XBrushes.Black, new XPoint(510, 120));


                document.Save(ofnReceipt.FileName);

            }
        }

        private void PrintError(string error)
        {
            pbWarningIcon.Visible = true;
            lblError.Visible = true;
            lblError.Text = error;
        }



        private string GetNumberString(int number)
        {
            string numberStr = "";

            if (number == 0)
            {
                numberStr = "CERO";
            }
            if (number > 0 && number < 10000)
            {
                if (number >= 1000)
                {
                    Thousand(ref number, ref numberStr);
                }
                if (number >= 100)
                {
                    Hundred(ref number, ref numberStr);
                }
                if (number >= 10)
                {
                    Teens(ref number, ref numberStr);
                }
                if (number >= 1)
                {
                    Ones(ref number, ref numberStr);
                }
            }
            else
            {
                // No es un numero valido
                return null;
            }

            return numberStr;

        }

        private void Thousand(ref int number, ref string numberStr)
        {
            if (number >= 9000)
            {
                numberStr += "NUEVE MIL";
                number -= 9000;
            }
            else if (number >= 8000)
            {
                numberStr += "OCHO MIL";
                number -= 8000;
            }
            else if (number >= 7000)
            {
                numberStr += "SIETE MIL";
                number -= 7000;
            }
            else if (number >= 6000)
            {
                numberStr += "SEIS MIL";
                number -= 6000;
            }
            else if (number >= 5000)
            {
                numberStr += "CINCO MIL";
                number -= 5000;
            }
            else if (number >= 4000)
            {
                numberStr += "CUATRO MIL";
                number -= 4000;
            }
            else if (number >= 3000)
            {
                numberStr += "TRES MIL";
                number -= 3000;
            }
            else if (number >= 2000)
            {
                numberStr += "DOS MIL";
                number -= 2000;
            }
            else if (number >= 1000)
            {
                numberStr += "MIL";
                number -= 1000;
            }

            if (number != 0)
            {
                numberStr += " ";
            }

        }

        private void Hundred(ref int number, ref string numberStr)
        {
            if (number >= 900)
            {
                numberStr += "NOVECIENTOS ";
                number -= 900;
            }
            else if (number >= 800)
            {
                numberStr += "OCHOCIENTOS ";
                number -= 800;
            }
            else if (number >= 700)
            {
                numberStr += "SETECIENTOS ";
                number -= 700;
            }
            else if (number >= 600)
            {
                numberStr += "SEISCIENTOS ";
                number -= 600;
            }
            else if (number >= 500)
            {
                numberStr += "QUINIENTOS ";
                number -= 500;
            }
            else if (number >= 400)
            {
                numberStr += "CUATROCIENTOS ";
                number -= 400;
            }
            else if (number >= 300)
            {
                numberStr += "TRESCIENTOS ";
                number -= 300;
            }
            else if (number >= 200)
            {
                numberStr += "DOSCIENTOS ";
                number -= 200;
            }
            else if (number > 100)
            {
                numberStr += "CIENTO ";
                number -= 100;
            }
            else if (number == 100)
            {
                numberStr += "CIEN";
                number -= 100;
            }
        }

        private void Teens(ref int number, ref string numberStr)
        {
            if (number >= 90)
            {
                numberStr += "NOVENTA";
                number -= 90;
            }
            else if (number >= 80)
            {
                numberStr += "OCHENTA";
                number -= 80;
            }
            else if (number >= 70)
            {
                numberStr += "SETENTA";
                number -= 70;
            }
            else if (number >= 60)
            {
                numberStr += "SESENTA";
                number -= 60;
            }
            else if (number >= 50)
            {
                numberStr += "CINCUENTA";
                number -= 50;
            }
            else if (number >= 40)
            {
                numberStr += "CUARENTA";
                number -= 40;
            }
            else if (number >= 30)
            {
                numberStr += "TREINTA";
                number -= 30;
            }
            else if (number > 20)
            {
                numberStr += "VEINTI";
                number -= 20;
                return;
            }
            else if (number == 20)
            {
                numberStr += "VEINTE";
                number -= 20;
            }
            else if (number > 15)
            {
                numberStr += "DIECI";
                number -= 10;
                return;
            }
            else if (number == 15)
            {
                numberStr += "QUINCE";
                number -= 15;
            }
            else if (number == 14)
            {
                numberStr += "CATORCE";
                number -= 14;
            }
            else if (number == 13)
            {
                numberStr += "TRECE";
                number -= 13;
            }
            else if (number == 12)
            {
                numberStr += "DOCE";
                number -= 12;
            }
            else if (number == 11)
            {
                numberStr += "ONCE";
                number -= 11;
            }
            else if (number == 10)
            {
                numberStr += "DIEZ";
                number -= 10;
            }

            if (number != 0)
            {
                numberStr += " Y ";
            }
        }

        private void Ones(ref int number, ref string numberStr)
        {
            switch (number)
            {
                case 9:
                    numberStr += "NUEVE";
                    number -= 9;
                    break;
                case 8:
                    numberStr += "OCHO";
                    number -= 8;
                    break;
                case 7:
                    numberStr += "SIETE";
                    number -= 7;
                    break;
                case 6:
                    numberStr += "SEIS";
                    number -= 6;
                    break;
                case 5:
                    numberStr += "CINCO";
                    number -= 5;
                    break;
                case 4:
                    numberStr += "CUATRO";
                    number -= 4;
                    break;
                case 3:
                    numberStr += "TRES";
                    number -= 3;
                    break;
                case 2:
                    numberStr += "DOS";
                    number -= 2;
                    break;
                case 1:
                    numberStr += "UN";
                    number -= 20;
                    break;
            }

        }

        private void dtpYear_ValueChanged(object sender, EventArgs e)
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
