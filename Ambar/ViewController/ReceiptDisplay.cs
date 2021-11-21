using Ambar.Common;
using Ambar.Model.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ambar.ViewController
{
    partial class ReceiptDisplay : Form
    {
        public ReceiptDisplay(ReceiptDTO dto)
        {
            InitializeComponent();
            if (dto != null)
            {
                FillReceipt(dto);
            }
        }

        private void ReceiptDisplay_Load(object sender, EventArgs e)
        {

        }

        private void FillReceipt(ReceiptDTO receipt)
        {
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
                return; // ERROR
            }
            end = period.AddDays(-1);

            string fullName = "{0} {1} {2}";
            fullName = string.Format(fullName, receipt.Father_Last_Name, receipt.Mother_Last_Name, receipt.First_Name);
            fullName = StringUtils.RemoveDiacritics(fullName).ToUpper();
            lblFullName.Text = fullName;
            string address = string.Format("{0} {1} CP. {2}", receipt.Street, receipt.Number, receipt.Postal_Code);
            address = StringUtils.RemoveDiacritics(address).ToUpper();
            lblAddress1.Text = address;
            address = string.Format("{0} CP. {1}", receipt.Suburb, receipt.Postal_Code);
            address = StringUtils.RemoveDiacritics(address).ToUpper();
            lblAddress2.Text = address;
            address = string.Format("{0}, {1}", receipt.City, receipt.State);
            lblAddress3.Text = address;

            lblServiceNumber.Text =  receipt.Service_Number.ToString();
            lblMeterSerialNumber.Text = receipt.Meter_Serial_Number;
            string strPeriod = start.ToString("dd MMM yy").ToUpper() + " - " + end.ToString("dd MMM yy").ToUpper();
            lblPeriod.Text = strPeriod;
            DateTime expirationDay = end.AddDays(19);
            lblExpiration.Text = expirationDay.ToString("dd MMM yy").ToUpper();
            DateTime cutDay = expirationDay.AddDays(1);
            lblCut.Text = cutDay.ToString("dd MMM yy").ToUpper();

            lblBasicKW.Text = receipt.Basic_KW.ToString();
            lblBasicLevel.Text = receipt.Basic_Level.ToString("0.000");
            lblBasicPrice.Text = receipt.Basic_Price.ToString("0.00");
             
            lblIntermediateKW.Text = receipt.Intermediate_KW.ToString();
            lblIntermediateLevel.Text = receipt.Intermediate_Level.ToString("0.000");
            lblIntermediatePrice.Text = receipt.Intermediate_Price.ToString("0.00");
             
            lblSurplusKW.Text = receipt.Surplus_KW.ToString();
            lblSurplusLevel.Text = receipt.Surplus_Level.ToString("0.000");
            lblSurplusPrice.Text = receipt.Surplus_Price.ToString("0.00");
            
            lblTotalKW.Text = receipt.Total_KW.ToString();
            lblTotalPrice.Text = receipt.Subtotal_Price.ToString("0.00");

            lblEnergia.Text = receipt.Subtotal_Price.ToString("0.00");
            lblIva.Text = receipt.Tax.ToString("0.00");
            lblFacPeriodo.Text = (receipt.Subtotal_Price + receipt.Tax).ToString("0.00");
            lblAdeudoAnt.Text = receipt.Prev_Price.ToString("0.00");
            lblPago.Text = receipt.Prev_Amount.ToString("0.00");
            lblTotal.Text = "$" + receipt.Total_Price.ToString("0.00");

            lblPagoGrande.Text = "$" + decimal.Truncate(receipt.Total_Price);
            string number = NumericUtils.GetNumberString(Convert.ToInt32(receipt.Total_Price));
            lblPagoLetra.Text = "(" + number + " PESOS M.N.)";

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ReceiptDisplay_MouseDown(object sender, MouseEventArgs e)
        {
            WinAPI.ReleaseCapture();
            WinAPI.SendMessage(this.Handle, WinAPI.WM_SYSCOMMAND, 0xf012, 0);
        }
    }
}
