using Ambar.Model.DAO;
using Ambar.Model.DTO;
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
        ReceiptDAO dao = new ReceiptDAO();
        public Receipts()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Generar los recibos

            ContractDAO contractDao = new ContractDAO();
            ConsumptionDAO consumptionDAO = new ConsumptionDAO();
            List<ContractForReceiptDTO> contractsInfo = contractDao.ReadContractsForReceipt(cbService.SelectedItem.ToString());
            List<ConsumptionForReceiptDTO> consumptionsInfo = new List<ConsumptionForReceiptDTO>();

            short month;
            if (cbService.SelectedIndex == 1)
            {
                month = Convert.ToInt16(cbPeriod.SelectedIndex * 2 + 1);
            }
            else if (cbService.SelectedIndex == 2)
            {
                month = Convert.ToInt16(cbPeriod.SelectedIndex + 1);
            }
            else
            {
                return;
                // ERROR: No se pudo carga la informacion
            }

            foreach (var contractInfo in contractsInfo)
            {
                ConsumptionForReceiptDTO register;
               
                register = consumptionDAO.FindConsumption(dtpYear.Value.Year, month, contractInfo.Meter_Serial_Number);

                if (register == null)
                {
                    return;
                    // ERROR: NO SE HAN CARGADO LOS CONSUMOS DE TODOS LOS CONTRATOS
                }

                consumptionsInfo.Add(register);
            }

            RateDAO rateDao = new RateDAO();
            RateForReceiptDTO ratesInfo = rateDao.FindActiveRates(cbService.SelectedItem.ToString(), dtpYear.Value.Year, month);
            if (ratesInfo == null)
            {
                // ERROR : No hay tarifa registrada para este periodo
            }

            List<ReceiptDTO> receipts = new List<ReceiptDTO>();
            for (int i = 0; i < contractsInfo.Count; i++)
            {
                ReceiptDTO receipt = new ReceiptDTO();
                receipt.Receipt_ID = Guid.NewGuid();
                receipt.First_Name = contractsInfo[i].First_Name;
                receipt.Father_Last_Name = contractsInfo[i].Father_Last_Name;
                receipt.Mother_Last_Name = contractsInfo[i].Mother_Last_Name;
                receipt.State = contractsInfo[i].State;
                receipt.City = contractsInfo[i].City;
                receipt.Suburb = contractsInfo[i].Suburb;
                receipt.Street = contractsInfo[i].Street;
                receipt.Number = contractsInfo[i].Number;
                receipt.Postal_Code = contractsInfo[i].Postal_Code;
                receipt.Meter_Serial_Number = contractsInfo[i].Meter_Serial_Number;
                receipt.Service_Number = contractsInfo[i].Service_Number;
                receipt.Service = cbService.SelectedItem.ToString();
                receipt.Year = dtpYear.Value.Year;
                receipt.Month = month;
                receipt.Basic_Level = ratesInfo.Basic_Level;
                receipt.Intermediate_Level = ratesInfo.Intermediate_Level;
                receipt.Surplus_Level = ratesInfo.Surplus_Level;
                receipt.Basic_KW = consumptionsInfo[i].Basic_KW;
                receipt.Intermediate_KW = consumptionsInfo[i].Intermediate_KW;
                receipt.Surplus_KW = consumptionsInfo[i].Surplus_KW;
                receipt.Total_KW = receipt.Basic_KW + receipt.Intermediate_KW + receipt.Surplus_KW;
                receipt.Basic_Price = receipt.Basic_Level * receipt.Basic_KW;
                receipt.Intermediate_Price = receipt.Intermediate_Level * receipt.Intermediate_KW;
                receipt.Surplus_Price = receipt.Surplus_Level * receipt.Surplus_KW;
                receipt.Tax = Convert.ToDecimal(ConfigurationManager.AppSettings["IVA"].ToString(), CultureInfo.InvariantCulture);
                receipt.Subtotal_Price = receipt.Basic_Price + receipt.Intermediate_Price + receipt.Surplus_Price;
                receipt.Total_Price = receipt.Subtotal_Price + receipt.Subtotal_Price * receipt.Tax;
                receipt.Amount_Pad = 0;
                receipt.Pending_Amount = receipt.Total_Price;
                receipts.Add(receipt);
            }

            dao.GenerateMassiveReceipts(receipts);

            int a = 5;
            a = 3;
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

        private void Receipts_Load(object sender, EventArgs e)
        {
           
        }

        private void btnPDF_Click(object sender, EventArgs e)
        {
            if (ofnReceipt.ShowDialog() == DialogResult.OK)
            {
                ReceiptDTO receipt = dao.FindReceipt(dtpPeriodSearch.Value.Year, 
                    Convert.ToInt16(dtpPeriodSearch.Value.Month), 
                    txtMeterSerialNumber.Text);

                PdfDocument document = new PdfDocument();
                PdfPage page = document.AddPage();

                XGraphics gfx = XGraphics.FromPdfPage(page);
                XFont font = new XFont("Montserrat", 12);
                XFont titleFont = new XFont("Montserrat", 12, XFontStyle.Bold);
                XFont subtitleFont = new XFont("Montserrat", 14);
                XPen pen = new XPen(XColor.FromArgb(255, 0, 0, 0));
                XImage logo = XImage.FromFile("../../Resources/Ambar_Logo.png");

                //gfx.DrawImage(logo, new XRect(10, 20, 30, 42));

                gfx.DrawString("Ambar", titleFont, XBrushes.Black, new XRect(50, 20, page.Width, page.Height),
                    XStringFormats.TopLeft);
                gfx.DrawString("Recibo", subtitleFont, XBrushes.Black, new XRect(50, 50, page.Width, page.Height),
                    XStringFormats.TopLeft);


                string fullName = "{0} {1} {2}";
                fullName = string.Format(fullName, receipt.Father_Last_Name, receipt.Mother_Last_Name, receipt.First_Name);
                gfx.DrawString(fullName, new XFont("Montserrat", 14, XFontStyle.Bold), XBrushes.Black, new XPoint(10, 120));

                string address = "{0} {1} CP. {2}";
                address = string.Format(address, receipt.Street, receipt.Number, receipt.Postal_Code);
                gfx.DrawString(address, new XFont("Montserrat", 12), XBrushes.Black, new XPoint(10, 140));
                address = "{0} CP. {1}";
                address = string.Format(address, receipt.Suburb, receipt.Postal_Code);
                gfx.DrawString(address, new XFont("Montserrat", 12), XBrushes.Black, new XPoint(10, 160));
                address = "{0}, {1}";
                address = string.Format(address, receipt.City, receipt.State);
                gfx.DrawString(address, new XFont("Montserrat", 12), XBrushes.Black, new XPoint(10, 180));


                gfx.DrawString("NO. DE SERVICIO: ", new XFont("Montserrat", 12, XFontStyle.Bold), XBrushes.Black, new XPoint(10, 190));
                gfx.DrawString(receipt.Service_Number.ToString(), new XFont("Montserrat", 14), XBrushes.Black, new XPoint(30, 120));


                // Table Header
                //gfx.DrawString("Mes", new XFont("Montserrat", 10, XFontStyle.Bold), XBrushes.Black, new XPoint(110, 120));
                //gfx.DrawString("No. de Medidor", new XFont("Montserrat", 10, XFontStyle.Bold), XBrushes.Black, new XPoint(210, 120));
                //gfx.DrawString("Básico", new XFont("Montserrat", 10, XFontStyle.Bold), XBrushes.Black, new XPoint(310, 120));
                //gfx.DrawString("Intermedio", new XFont("Montserrat", 10, XFontStyle.Bold), XBrushes.Black, new XPoint(410, 120));
                //gfx.DrawString("Excedente", new XFont("Montserrat", 10, XFontStyle.Bold), XBrushes.Black, new XPoint(510, 120));


                document.Save(ofnReceipt.FileName);

            }
        }
    }
}
