using Ambar.Model.DTO;
using PdfSharp.Charting;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambar.Common
{
    class PDFUtils
    {
        public static bool GeneratePDFReceipt(ReceiptDTO receipt, string path)
        {
            PdfDocument document = new PdfDocument();
            PdfPage page = document.AddPage();

            XGraphics gfx = XGraphics.FromPdfPage(page);
            XImage logo = XImage.FromFile("../../Resources/Ambar_Logo.png");
            XImage table1 = XImage.FromFile("../../Resources/Table1.PNG");
            XImage table2 = XImage.FromFile("../../Resources/Table2.PNG");
            XImage grayQuad = XImage.FromFile("../../Resources/Gray_Block.png");

            gfx.DrawImage(logo, new XRect(20, 20, 60, 84));

            gfx.DrawString("Ambar", new XFont("Arial", 20), XBrushes.Black, new XRect(100, 40, page.Width, page.Height),
                XStringFormats.TopLeft);
            gfx.DrawString("Recibo", new XFont("Arial", 20), XBrushes.Black, new XRect(100, 80, page.Width, page.Height),
                XStringFormats.TopLeft);


            DateTime period = new DateTime(receipt.Year, receipt.Month, receipt.Day);
            DateTime start, end;
            if (receipt.Service == "Domestico")
            {
                start = period.AddMonths(-2);
            }
            else if (receipt.Service == "Industrial")
            {
                start = period.AddMonths(-1);
            }
            else
            {
                return false; // ERROR
            }
            end = period.AddDays(-1);

            XFont font = new XFont("Arial", 12);
            XFont fontBold = new XFont("Arial", 12, XFontStyle.Bold);

            gfx.DrawImage(grayQuad, new XRect(30, 120, 350, 90));

            string fullName = "{0} {1} {2}";
            fullName = string.Format(fullName, receipt.Father_Last_Name, receipt.Mother_Last_Name, receipt.First_Name);
            fullName = StringUtils.RemoveDiacritics(fullName).ToUpper();
            gfx.DrawString(fullName, new XFont("Arial", 14, XFontStyle.Bold), XBrushes.Black, new XPoint(40, 140));
            string address = string.Format("{0} {1} CP. {2}", receipt.Street, receipt.Number, receipt.Postal_Code);
            address = StringUtils.RemoveDiacritics(address).ToUpper();
            gfx.DrawString(address, font, XBrushes.Black, new XPoint(40, 160));
            address = string.Format("{0} CP. {1}", receipt.Suburb, receipt.Postal_Code);
            address = StringUtils.RemoveDiacritics(address).ToUpper();
            gfx.DrawString(address, font, XBrushes.Black, new XPoint(40, 180));
            address = string.Format("{0}, {1}", receipt.City, receipt.State);
            gfx.DrawString(address, font, XBrushes.Black, new XPoint(40, 200));



            gfx.DrawImage(grayQuad, new XRect(30, 220, 350, 110));

            gfx.DrawString("NO. DE SERVICIO: ", fontBold, XBrushes.Black, new XPoint(40, 240));
            gfx.DrawString("NO. MEDIDOR: ", fontBold, XBrushes.Black, new XPoint(40, 260));
            gfx.DrawString("PERIODO FACTURADO: ", fontBold, XBrushes.Black, new XPoint(40, 280));
            gfx.DrawString("LÍMITE DE PAGO: ", fontBold, XBrushes.Black, new XPoint(40, 300));
            gfx.DrawString("CORTE A PARTIR: ", fontBold, XBrushes.Black, new XPoint(40, 320));

            gfx.DrawString(receipt.Service_Number.ToString(), font, XBrushes.Black, new XPoint(200, 240));
            gfx.DrawString(receipt.Meter_Serial_Number, font, XBrushes.Black, new XPoint(200, 260));
            string strPeriod = start.ToString("dd MMM yy").ToUpper() + " - " + end.ToString("dd MMM yy").ToUpper();
            gfx.DrawString(strPeriod, font, XBrushes.Black, new XPoint(200, 280));
            DateTime expirationDay = end.AddDays(19);
            gfx.DrawString(expirationDay.ToString("dd MMM yy").ToUpper(), font, XBrushes.Black, new XPoint(200, 300));
            DateTime cutDay = expirationDay.AddDays(1);
            gfx.DrawString(cutDay.ToString("dd MMM yy").ToUpper(), font, XBrushes.Black, new XPoint(200, 320));



            gfx.DrawImage(table1, new XRect(30, 345, 552, 80));

            gfx.DrawString("Energía (kWh)", fontBold, XBrushes.Black, new XPoint(40, 360));
            gfx.DrawString("Total Periodo", fontBold, XBrushes.Black, new XPoint(173, 360));
            gfx.DrawString("Precio (MXN)", fontBold, XBrushes.Black, new XPoint(306, 360));
            gfx.DrawString("Subtotal (MXN)", fontBold, XBrushes.Black, new XPoint(479, 360));

            gfx.DrawString("Básico: ", font, XBrushes.Black, new XPoint(40, 380));
            gfx.DrawString(receipt.Basic_KW.ToString(), font, XBrushes.Black, new XPoint(173, 380));
            gfx.DrawString(receipt.Basic_Level.ToString("0.000"), font, XBrushes.Black, new XPoint(306, 380));
            gfx.DrawString(receipt.Basic_Price.ToString("0.00"), font, XBrushes.Black, new XPoint(479, 380));

            gfx.DrawString("Intermedio: ", font, XBrushes.Black, new XPoint(40, 400));
            gfx.DrawString(receipt.Intermediate_KW.ToString(), font, XBrushes.Black, new XPoint(173, 400));
            gfx.DrawString(receipt.Intermediate_Level.ToString("0.000"), font, XBrushes.Black, new XPoint(306, 400));
            gfx.DrawString(receipt.Intermediate_Price.ToString("0.00"), font, XBrushes.Black, new XPoint(479, 400));

            gfx.DrawString("Excedente: ", font, XBrushes.Black, new XPoint(40, 420));
            gfx.DrawString(receipt.Surplus_KW.ToString(), font, XBrushes.Black, new XPoint(173, 420));
            gfx.DrawString(receipt.Surplus_Level.ToString("0.000"), font, XBrushes.Black, new XPoint(306, 420));
            gfx.DrawString(receipt.Surplus_Price.ToString("0.00"), font, XBrushes.Black, new XPoint(479, 420));

            gfx.DrawString(receipt.Total_KW.ToString(), font, XBrushes.Black, new XPoint(173, 440));
            gfx.DrawString(receipt.Subtotal_Price.ToString("0.00"), font, XBrushes.Black, new XPoint(479, 440));



            gfx.DrawImage(table2, new XRect(30, 485, 250, 140));

            gfx.DrawString("Desglose del importe a pagar", fontBold, XBrushes.Black, new XPoint(40, 500));
            gfx.DrawString("Energía", font, XBrushes.Black, new XPoint(40, 520));
            gfx.DrawString("IVA 16%", font, XBrushes.Black, new XPoint(40, 540));
            gfx.DrawString("Fac. del Periodo", font, XBrushes.Black, new XPoint(40, 560));
            gfx.DrawString("Adeudo Anterior", font, XBrushes.Black, new XPoint(40, 580));
            gfx.DrawString("Su pago", font, XBrushes.Black, new XPoint(40, 600));
            gfx.DrawString("Total", fontBold, XBrushes.Black, new XPoint(40, 620));

            gfx.DrawString(receipt.Subtotal_Price.ToString("0.00"), font, XBrushes.Black, new XPoint(200, 520));
            gfx.DrawString(receipt.Tax.ToString("0.00"), font, XBrushes.Black, new XPoint(200, 540));
            gfx.DrawString((receipt.Subtotal_Price + receipt.Tax).ToString("0.00"), font, XBrushes.Black, new XPoint(200, 560));
            gfx.DrawString(receipt.Prev_Price.ToString("0.00"), font, XBrushes.Black, new XPoint(200, 580));
            gfx.DrawString(receipt.Prev_Amount.ToString("0.00"), font, XBrushes.Black, new XPoint(200, 600));
            gfx.DrawString("$" + receipt.Total_Price.ToString("0.00"), fontBold, XBrushes.Black, new XPoint(200, 620));



            gfx.DrawString("TOTAL A PAGAR", fontBold, XBrushes.Black, new XPoint(400, 40));
            gfx.DrawString("$" + decimal.Truncate(receipt.Total_Price), new XFont("Arial", 24), XBrushes.Black, new XPoint(400, 70));
            string number = NumericUtils.GetNumberString(Convert.ToInt32(decimal.Truncate(receipt.Total_Price)));
            gfx.DrawString("(" + number + " PESOS M.N.)", new XFont("Arial", 8), XBrushes.Black, new XPoint(400, 90));

            gfx.DrawString("TOTAL A PAGAR", fontBold, XBrushes.Black, new XPoint(40, 700));
            gfx.DrawString("$" + decimal.Truncate(receipt.Total_Price), new XFont("Arial", 24), XBrushes.Black, new XPoint(40, 730));
            number = NumericUtils.GetNumberString(Convert.ToInt32(decimal.Truncate(receipt.Total_Price)));
            gfx.DrawString("(" + number + " PESOS M.N.)", new XFont("Arial", 8), XBrushes.Black, new XPoint(40, 750));

            document.Save(path);
            return true;
        }
    }
}
