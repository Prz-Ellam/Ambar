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

            bool result = false;
            bool domestico = false, industrial = false;
            DateTime request = new DateTime(massiveReceipt.Year, massiveReceipt.Period, 1);

            if (massiveReceipt.ServiceType == "Ambos")
            {
                if (request.Month % 2 == 0)
                {
                    massiveReceipt.ServiceType = "Domestico";
                    domestico = GenerateReceipts(massiveReceipt);
                    if (domestico)
                    {
                        MessageBox.Show("Recibos domesticos emitidos exitosamente", "Ambar", MessageBoxButtons.OK);
                    }
                    else
                    {
                        MessageBox.Show("No se pudieron emitir los recibos domesticos", "Ambar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                massiveReceipt.ServiceType = "Industrial";
                industrial = GenerateReceipts(massiveReceipt);
                if (industrial)
                {
                    MessageBox.Show("Recibos industriales emitidos exitosamente", "Ambar", MessageBoxButtons.OK);
                }
                else
                {
                    MessageBox.Show("No se pudieron emitir los recibos industriales", "Ambar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                result = GenerateReceipts(massiveReceipt);
            }
            
            if (result || (domestico || industrial))
            {
                string serviceType;
                if (result)
                {
                    serviceType = massiveReceipt.ServiceType;
                }
                else
                {
                    if (domestico && industrial)
                    {
                        serviceType = "Ambos";
                    }
                    else if (domestico)
                    {
                        serviceType = "Domestico";
                    }
                    else // Industrial
                    {
                        serviceType = "Industrial";
                    }
                }

                string action = "[Recibos] Fueron emitidos recibos del Mes: " + request.Month +
                    ", Año: " + request.Year + ", Mes: " + request.Month + ", Servicio: " + serviceType;
                new ActivityDAO().Action(UserCache.id, action);

                ClearForm();
                MessageBox.Show("La operación se realizó exitosamente", "Ambar", MessageBoxButtons.OK);
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
            DateTime request = dtpPeriodSearch.Value;

            if (filter == string.Empty)
            {
                MessageBox.Show("Todos los campos son obligatorios", "Ambar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ofnReceipt.FileName = string.Format("{0} {1} {2}", filter, dtpYear.Value.Year, DateTime.Now.ToString("yyyy-MM-dd HH.mm.ss"));

            if (ofnReceipt.ShowDialog() == DialogResult.OK)
            {
                ContractDAO contractDAO = new ContractDAO();
                ReceiptDTO receipt;

                if (rbMeterSerialNumber.Checked)
                {
                    if (filter.IndexOf('\'') != -1)
                    {
                        MessageBox.Show("Caracter \' no valido", "Ambar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (!RegexUtils.ValidateMeterSerialNumber(filter))
                    {
                        MessageBox.Show("Número de medidor no valido", "Ambar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (!contractDAO.ContractExists(filter))
                    {
                        MessageBox.Show("El número de medidor no existe actualmente", "Ambar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    string serviceType = contractDAO.FindServiceType(filter);
                    if (serviceType == null)
                    {
                        MessageBox.Show("Error inesperado", "Ambar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    request = DateUtils.FindPeriod(serviceType, request);
                    receipt = receiptDAO.FindReceipt(request.Year, request.Month, filter);
                    if (receipt == null)
                    {
                        MessageBox.Show("No se encontró recibo", "Ambar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                else if (rbServiceNumber.Checked)
                {
                    long filterNum;
                    if (!long.TryParse(filter, out filterNum) || !RegexUtils.OnlyNumbers(filter))
                    {
                        MessageBox.Show("Número de servicio no valido", "Ambar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (filterNum == 0)
                    {
                        MessageBox.Show("El número de servicio no puede ser 0", "Ambar", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        MessageBox.Show("No se encontró recibo", "Ambar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Error inesperado", "Ambar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                PDFUtils.GeneratePDFReceipt(receipt, ofnReceipt.FileName);

                List<HistoricConsumptionDTO> historicConsumptions;
                if (rbMeterSerialNumber.Checked)
                {
                    historicConsumptions = receiptDAO.HistoricConsumption(filter);
                }
                else if (rbServiceNumber.Checked)
                {
                    historicConsumptions = receiptDAO.HistoricConsumption(Convert.ToInt64(filter));
                }
                else
                {
                    MessageBox.Show("Error inesperado", "Ambar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                chartHC.Series["HC"].Points.Clear();
                historicConsumptions.Reverse();
                int index = historicConsumptions.FindIndex(o => o.Month == request.Month && o.Year == request.Year);
                historicConsumptions.RemoveRange(0, index + 1);
                historicConsumptions.Reverse();

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
                MessageBox.Show("Ya se emitieron los recibos de este periodo", "Ambar", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show("No hay tarifas registradas para este periodo", "Ambar", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    continue;
                }

                ConsumptionDTO consumption = consumptionDAO.FindConsumption(receiptsInfo.Year, receiptsInfo.Period, 
                    contractInfo.Meter_Serial_Number);
                if (consumption == null)
                {
                    MessageBox.Show("No se han cargado todos los consumos de los contratos", "Ambar", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            //if (receipts.Count == 0)
            //{
            //    // NO HAY NADA QUE GENERAR
            //}

            receiptDAO.GenerateMassiveReceipts(receipts);
            receiptDAO.EmitReceipt(receiptsInfo);
            dateDAO.UpdateDate(receiptsInfo.ServiceType);
            lblDate.Text = dateDAO.GetDate().ToString("MMMM yyyy").ToUpper();
            DateChange();
            return true;
        }

    }
}
