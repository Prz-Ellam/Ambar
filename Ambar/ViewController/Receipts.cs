using Ambar.Common;
using Ambar.Model.DAO;
using Ambar.Model.DTO;
using Ambar.ViewController.Objects;
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
            lblDate.Text = dateDAO.GetDate().ToString("MMMM yyyy").ToUpper();
        }

        private void btnGenerateReceipt_Click(object sender, EventArgs e)
        {
            ReceiptForm massiveReceipt = FillMassiveReceipt();
            if (!Validate(massiveReceipt))
            {
                return;
            }

            bool result = true;
            DateTime request = new DateTime(massiveReceipt.Year, massiveReceipt.Period, 1);
            if (massiveReceipt.ServiceType == "Ambos")
            {
                //if (request.Month % 2 == 0)
                //{
                //    result = GenerateReceipts(request, "Domestico") && result;
                //}
                //result = GenerateReceipts(request, "Industrial") && result;
            }
            else
            {
                result = GenerateReceipts(massiveReceipt);
            }
            
            if (result)
            {
            //    string action = "[Recibos] Fueron emitidos recibos del Mes: " + request.Month +
            //        ", Año: " + request.Year + "Mes: " + request.Month + ", Servicio: " +
            //        serviceType + ", a las: " + DateTime.Now;
            //    new UserRememberDAO().Action(UserCache.id, action);
            //
            //    ClearForm();
            //    MessageBox.Show("La operación se realizó exitosamente", "Ambar", MessageBoxButtons.OK);
            }
        }   

        private ReceiptForm FillMassiveReceipt()
        {
            ReceiptForm massiveReceipt = new ReceiptForm();
            massiveReceipt.ServiceType = cbService.SelectedItem.ToString();
            massiveReceipt.Year = dtpYear.Value.Year;
            massiveReceipt.Period = ((ComboBoxItem)cbPeriod.SelectedItem).HiddenValue;
            return massiveReceipt;
        }

        private bool Validate(ReceiptForm massiveReceipt)
        {
            if (massiveReceipt.ServiceType == "Seleccionar" || massiveReceipt.Period == -1)
            {
                MessageBox.Show("Todos los campos son obligatorios", "Ambar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            DateTime offset = dateDAO.GetDate();
            DateTime request = new DateTime(massiveReceipt.Year, massiveReceipt.Period, 1);
            if (DateUtils.ComparePeriod(request, offset))
            {
                MessageBox.Show("No se pueden emitir recibos fuera del periodo actual de cobro", "Ambar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        void ClearForm()
        {
            cbService.SelectedIndex = 0;
            txtFilterID.Clear();
            rbMeterSerialNumber.Checked = true;
        }

        private void DateChange()
        {
            cbPeriod.Items.Clear();
            cbPeriod.Items.Add(new ComboBoxItem("Seleccionar", -1));

            dtpYear.MinDate = dateDAO.GetDate();
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

                    var bimesters = new[]
                    {
                        new ComboBoxItem("Enero-Febrero", 2), new ComboBoxItem("Marzo-Abril", 4),
                        new ComboBoxItem("Mayo-Junio", 6), new ComboBoxItem("Julio-Agosto", 8),
                        new ComboBoxItem("Septiembre-Octubre", 10), new ComboBoxItem("Noviembre-Diciembre", 12)
                    };

                    for (int i = bimester; i < 6; i++)
                    {
                        cbPeriod.Items.Add(bimesters[i]);
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

                    var months = new[]
                    {
                        new ComboBoxItem("Enero", 1), new ComboBoxItem("Febrero", 2), new ComboBoxItem("Marzo", 3),
                        new ComboBoxItem("Abril", 4), new ComboBoxItem("Mayo", 5), new ComboBoxItem("Junio", 6),
                        new ComboBoxItem("Julio", 7), new ComboBoxItem("Agosto", 8), new ComboBoxItem("Septiembre", 9),
                        new ComboBoxItem("Octubre", 10), new ComboBoxItem("Noviembre", 11), new ComboBoxItem("Diciembre", 12)
                    };

                    for (int i = month; i < 12; i++)
                    {
                        cbPeriod.Items.Add(months[i]);
                    }
                    break;
                }
            }
            cbPeriod.SelectedIndex = 0;
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

            string filter = StringUtils.GetText(txtFilterID.Text);

            if (filter == string.Empty)
            {
                return; // ERROR
            }

            ofnReceipt.FileName = string.Format("{0} {1} {2}", filter, dtpYear.Value.Year, DateTime.Now.ToString("yyyy-MM-dd HH.mm.ss"));

            if (ofnReceipt.ShowDialog() == DialogResult.OK)
            {
                DateTime request = new DateTime(dtpPeriodSearch.Value.Year, dtpPeriodSearch.Value.Month, 1);
                ContractDAO contractDAO = new ContractDAO();

                ReceiptDTO receipt = new ReceiptDTO();
                if (rbMeterSerialNumber.Checked)
                {
                    string serviceType = contractDAO.FindServiceType(filter);
                    if (serviceType == null)
                    {
                        return;
                    }
                    request = DateUtils.FindPeriod(serviceType, request);
                    receipt = receiptDAO.FindReceipt(request.Year, request.Month, filter);
                    if (receipt == null)
                    {
                        return;
                    }
                }
                else if (rbServiceNumber.Checked)
                {
                    long filterNum;
                    try
                    {
                        filterNum = Convert.ToInt64(filter);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Número de servicio no válido", "Ambar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    string serviceType = contractDAO.FindServiceType(filterNum);
                    if (serviceType == null)
                    {
                        return;
                    }
                    request = DateUtils.FindPeriod(serviceType, request);
                    receipt = receiptDAO.FindReceipt(request.Year, request.Month, filterNum);
                    if (receipt == null)
                    {
                        return;
                    }
                }
                else
                {
                    // ERROR
                    return;
                }

                PdfDocument document = new PdfDocument();
                PdfPage page = document.AddPage();

                XGraphics gfx = XGraphics.FromPdfPage(page);
                XPen pen = new XPen(XColor.FromArgb(255, 0, 0, 0));
                XImage logo = XImage.FromFile("../../Resources/Ambar_Logo.png");
                XImage table1 = XImage.FromFile("../../Resources/Table1.PNG");
                XImage table2 = XImage.FromFile("../../Resources/Table2.PNG");

                gfx.DrawImage(logo, new XRect(20, 20, 60, 84));

                gfx.DrawString("Ambar", new XFont("Arial", 14), XBrushes.Black, new XRect(100, 20, page.Width, page.Height),
                    XStringFormats.TopLeft);
                gfx.DrawString("Recibo", new XFont("Arial", 14), XBrushes.Black, new XRect(100, 40, page.Width, page.Height),
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

                // Prueba de escritorio
                DateTime start = new DateTime(receipt.Year, receipt.Month, receipt.Day);
                DateTime end;
                if (receipt.Service == "Domestico")
                {
                    start = start.AddMonths(-1);
                    end = start.AddMonths(1);
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

                XFont font = new XFont("Arial", 12);
                XFont fontBold = new XFont("Arial", 12, XFontStyle.Bold);

                string period = start.ToString("dd MMM yy").ToUpper() + " - " + end.ToString("dd MMM yy").ToUpper();
                gfx.DrawString(period, font, XBrushes.Black, new XPoint(160, 220));

                gfx.DrawString("LÍMITE DE PAGO: ", new XFont("Arial", 12, XFontStyle.Bold), XBrushes.Black, new XPoint(10, 240));
                DateTime expirationDay = end.AddDays(19);
                gfx.DrawString(expirationDay.ToString("dd MMM yy").ToUpper(), font, XBrushes.Black, new XPoint(150, 240));

                gfx.DrawString("CORTE A PARTIR: ", new XFont("Arial", 12, XFontStyle.Bold), XBrushes.Black, new XPoint(10, 260));
                DateTime cutDay = expirationDay.AddDays(1);
                gfx.DrawString(cutDay.ToString("dd MMM yy").ToUpper(), font, XBrushes.Black, new XPoint(150, 260));

                gfx.DrawString("NO. MEDIDOR: ", new XFont("Arial", 12, XFontStyle.Bold), XBrushes.Black, new XPoint(10, 280));
                gfx.DrawString(receipt.Meter_Serial_Number, font, XBrushes.Black, new XPoint(100, 280));

                gfx.DrawImage(table1, new XRect(30, 305, 552, 80));

                gfx.DrawString("Energía (kWh)", fontBold, XBrushes.Black, new XPoint(10, 320));
                gfx.DrawString("Total Periodo", fontBold, XBrushes.Black, new XPoint(120, 320));
                gfx.DrawString("Precio (MXN)", fontBold, XBrushes.Black, new XPoint(200, 320));
                gfx.DrawString("Subtotal (MXN)", fontBold, XBrushes.Black, new XPoint(280, 320));

                gfx.DrawString("Básico: ", fontBold, XBrushes.Black, new XPoint(10, 340));
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


                List<HistoricConsumptionDTO> historicConsumptions;
                if (rbMeterSerialNumber.Checked)
                {
                    historicConsumptions = receiptDAO.HistoricConsumption(txtFilterID.Text);
                }
                else if (rbServiceNumber.Checked)
                {
                    historicConsumptions = receiptDAO.HistoricConsumption(Convert.ToInt64(txtFilterID.Text));
                }
                else
                {
                    return;
                }

                chartHC.Series["HC"].Points.Clear();
                historicConsumptions.Reverse();
                int index = historicConsumptions.FindIndex(o => o.Month == request.Month && o.Year == request.Year);
                historicConsumptions.RemoveRange(0, index + 1);

                int count = (historicConsumptions.Count > 11) ? 11 : historicConsumptions.Count;

                for (int i = 0; i < count; i++) {
                    DateTime d = new DateTime(2010, historicConsumptions[i].Month, 1);
                    chartHC.Series["HC"].Points.AddXY(d.ToString("MMM").ToUpper(), historicConsumptions[i].Total_KW);
                }

                ClearForm();
                MessageBox.Show("La operacion se realizo exitosamente", "Ambar", MessageBoxButtons.OK);
            }
        }

        private bool GenerateReceipts(ReceiptForm receiptsInfo)
        {
            // Validar que no se emitieron ya los recibos de este periodo
            if (receiptDAO.FindEmission(receiptsInfo.Year, receiptsInfo.Period, receiptsInfo.ServiceType))
            {
                MessageBox.Show("Ya se emitieron los recibos de este periodo", "Ambar", MessageBoxButtons.OK);
                return false;
            }

            ContractDAO contractDAO = new ContractDAO();
            RateDAO rateDao = new RateDAO();
            ConsumptionDAO consumptionDAO = new ConsumptionDAO();

            // Se trae todos los contratos de un determinado servicio
            List<ContractDTO> contractsInfo = contractDAO.ReadContractsByService(receiptsInfo.ServiceType);

            // Encuentra la tarifa del periodo de ese servicio
            RateDTO rateInfo = rateDao.FindActiveRates(receiptsInfo);
            if (rateInfo == null)
            {
                MessageBox.Show("No hay tarifas registradas para este periodo", "Ambar", MessageBoxButtons.OK);
                return false;
            }

            decimal iva = Convert.ToDecimal(ConfigurationManager.AppSettings["IVA"].ToString(), CultureInfo.InvariantCulture);
            
            List<ReceiptDTO> receipts = new List<ReceiptDTO>();
            foreach (var contractInfo in contractsInfo)
            {
                if (receiptDAO.ReceiptExists(contractInfo.Meter_Serial_Number, receiptsInfo.Year, receiptsInfo.Period))
                {
                    continue; // Ignora si ya tiene un recibo en esa fecha, por seguridad
                }

                DateTime start = DateUtils.ToDateTime(contractInfo.Start_Period_Date);
                start = DateUtils.FindStartPeriod(receiptsInfo.ServiceType, start);
                DateTime period = new DateTime(receiptsInfo.Year, receiptsInfo.Period, 1);

                if (DateUtils.IsLessPeriod(period, start))
                {
                    MessageBox.Show("No se puede cargar un contrato antes del inicio de periodo de cobro", "Ambar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                ConsumptionDTO consumption = consumptionDAO.FindConsumption(receiptsInfo.Year, receiptsInfo.Period, 
                    contractInfo.Meter_Serial_Number);
                if (consumption == null)
                {
                    MessageBox.Show("No se han cargado todos los consumos de los contratos", "Ambar", MessageBoxButtons.OK);
                    return false;
                }

                DateTime prevPeriod = DateUtils.FindPrevPeriod(receiptsInfo.ServiceType, period);
                ReceiptDTO prev = receiptDAO.FindReceipt(prevPeriod.Year, prevPeriod.Month, contractInfo.Meter_Serial_Number);

                ReceiptDTO dto = new ReceiptDTO();
                dto.Receipt_ID = Guid.NewGuid();
                dto.Contract_ID = contractInfo.Contract_ID;
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
                dto.Service = contractInfo.Service;
                dto.Year = period.Year;
                dto.Month = period.Month;
                dto.Day = consumption.Day;
                dto.Basic_Level = rateInfo.Basic_Level;
                dto.Intermediate_Level = rateInfo.Intermediate_Level;
                dto.Surplus_Level = rateInfo.Surplus_Level;
                dto.Basic_KW = consumption.Basic_KW;
                dto.Intermediate_KW = consumption.Intermediate_KW;
                dto.Surplus_KW = consumption.Surplus_KW;
                dto.Total_KW = dto.Basic_KW + dto.Intermediate_KW + dto.Surplus_KW;
                dto.Basic_Price = decimal.Round(dto.Basic_Level * dto.Basic_KW, 2);
                dto.Intermediate_Price = decimal.Round(dto.Intermediate_Level * dto.Intermediate_KW, 2);
                dto.Surplus_Price = decimal.Round(dto.Surplus_Level * dto.Surplus_KW, 2);
                dto.Subtotal_Price = decimal.Round(dto.Basic_Price + dto.Intermediate_Price + dto.Surplus_Price, 2);
                dto.Tax = decimal.Round(dto.Subtotal_Price * iva, 2);
                dto.Prev_Amount = (prev == null) ? 0.0m : prev.Amount_Paid;
                dto.Prev_Price = (prev == null) ? 0.0m : prev.Total_Price;
                dto.Total_Price = decimal.Round(dto.Subtotal_Price + dto.Tax + (dto.Prev_Price - dto.Prev_Amount), 2);
                dto.Amount_Paid = 0;
                dto.Pending_Amount = decimal.Round(dto.Total_Price, 2);
                dto.Is_Paid = false;
                
                receipts.Add(dto);
            }

            if (receipts.Count == 0)
            {
                // NO HAY NADA QUE GENERAR
            }

            receiptDAO.GenerateMassiveReceipts(receipts);
            receiptDAO.EmitReceipt(receiptsInfo);
            dateDAO.UpdateDate(receiptsInfo.ServiceType);
            lblDate.Text = dateDAO.GetDate().ToString("MMMM yyyy").ToUpper();
            DateChange();
            return true;
        }

    }
}
