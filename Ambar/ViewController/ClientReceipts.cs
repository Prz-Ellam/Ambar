using Ambar.Common;
using Ambar.Model.DAO;
using Ambar.Model.DTO;
using Ambar.ViewController.Objects;
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
        int dtgPrevIndex = -1;
        public ClientReceipts()
        {
            InitializeComponent();
        }

        private void ClientReceipts_Load(object sender, EventArgs e)
        {
            FillContractsDataGridView();
        }

        private void FillContractsDataGridView()
        {
            ContractDAO contractDAO = new ContractDAO();
            List<ContractDTO> contracts = contractDAO.ReadClientContracts(UserCache.id);
            List<ContractDTG> dtgContractsList = new List<ContractDTG>();
            foreach (var contract in contracts)
            {
                dtgContractsList.Add(new ContractDTG(contract));
            }
            dtgContracts.DataSource = dtgContractsList;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            ClientReceiptForm clientReceipt = FillClientReceipt();
            if (!Validate(clientReceipt))
            {
                return;
            }

            receipt = receiptDAO.FindReceipt(clientReceipt);
            if (receipt == null)
            {
                MessageBox.Show("No se encontró recibo", "Ambar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            lblImport.Text = receipt.Total_Price.ToString("0.00");
            lblAmountPad.Text = receipt.Amount_Paid.ToString("0.00");
            lblPendingPaid.Text = receipt.Pending_Amount.ToString("0.00");
            lblStatus.Text = string.Format("{0:Pagado;0;No Pagado}", receipt.Is_Paid.GetHashCode());
            nudMount.Maximum = Convert.ToDecimal(receipt.Pending_Amount.ToString("0.00"));
            btnPaid.Enabled = true;
            btnPDF.Enabled = true;
            btnReceipt.Enabled = true;

            List<HistoryDTG> history = new List<HistoryDTG>();
            List<string> paymentTypeHistory = receipt.Payment_Type_History.ToList();
            Dictionary<DateTimeOffset, decimal> paymentHistory = new Dictionary<DateTimeOffset, decimal>(receipt.Payment_History);
            for (int i = 1; i < receipt.Payment_History.Count; i++)
            {
                history.Add(new HistoryDTG(paymentTypeHistory[i], paymentHistory.ElementAt(i).Value));
            }
            dtgHistory.DataSource = history;

            List<HistoricConsumptionDTO> historicConsumptions = receiptDAO.HistoricConsumption(txtMeterSerialNumber.Text);
            chartHC.Visible = true;
            chartHC.Series["HC"].Points.Clear();
            historicConsumptions.Reverse();
            int index = historicConsumptions.FindIndex(o => o.Month == clientReceipt.Period.Month && o.Year == clientReceipt.Period.Year);
            historicConsumptions.RemoveRange(0, index + 1);
            int count = (historicConsumptions.Count > 11) ? 11 : historicConsumptions.Count;
            for (int i = 0; i < count; i++)
            {
                DateTime d = new DateTime(2010, historicConsumptions[i].Month, 1);
                chartHC.Series["HC"].Points.AddXY(d.ToString("MMM").ToUpper(), historicConsumptions[i].Total_KW);
            }

            if (receipt.Is_Paid)
            {
                btnPaid.Enabled = false;
                btnPDF.Enabled = false;
                btnReceipt.Enabled = false;
            }

            DateTime next = DateUtils.FindNextPeriod(clientReceipt.ServiceType, clientReceipt.Period);
            ReceiptDTO nextReceipt = receiptDAO.FindReceipt(next.Year, next.Month, clientReceipt.MeterSerialNumber);
            if (nextReceipt != null)
            {
                MessageBox.Show("No se puede pagar este recibo porque ya fue emitido uno en fechas posteriores", "Ambar", MessageBoxButtons.OK);
                btnPaid.Enabled = false;
            }

        }

        private ClientReceiptForm FillClientReceipt()
        {
            ClientReceiptForm clientReceipt = new ClientReceiptForm();
            clientReceipt.MeterSerialNumber = StringUtils.GetText(txtMeterSerialNumber.Text);
            clientReceipt.Period = dtpPeriod.Value;
            clientReceipt.ServiceType = dtgContracts.Rows[dtgPrevIndex].Cells[9].Value.ToString();
            return clientReceipt;
        }

        private bool Validate(ClientReceiptForm clientReceipt)
        {
            if (clientReceipt.MeterSerialNumber == string.Empty)
            {
                MessageBox.Show("Todos los campos son obligatorios", "Ambar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            ContractDAO contractDAO = new ContractDAO();
            if (!contractDAO.ContractExists(clientReceipt.MeterSerialNumber))
            {
                MessageBox.Show("El número de medidor no existe actualmente", "Ambar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (!contractDAO.IsClientContract(UserCache.id, clientReceipt.MeterSerialNumber))
            {
                MessageBox.Show("No se puede tener acceso al numero de medidor", "Ambar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (clientReceipt.ServiceType != "Domestico" && clientReceipt.ServiceType != "Industrial")
            {
                MessageBox.Show("Tipo de servicio no valido", "Ambar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            clientReceipt.Period = DateUtils.FindPeriod(clientReceipt.ServiceType, clientReceipt.Period);

            return true;
        }

        private void btnPaid_Click(object sender, EventArgs e)
        {
            if (receipt == null)
            {
                MessageBox.Show("Error inesperado", "Ambar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (nudMount.Value == 0.0m)
            {
                MessageBox.Show("No se pueden pagar en 0", "Ambar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string paymentType;
            paymentType = gpPaymentType.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked).Text;

            receiptDAO.PaidReceipt(receipt.Receipt_ID, receipt.Meter_Serial_Number, receipt.Service_Number, 
                receipt.Service, receipt.Year, receipt.Month, nudMount.Value, receipt.Amount_Paid,
                receipt.Pending_Amount, paymentType);

            string action = "[Pago de Recibos] Fue pagado el recibo: " + receipt.Receipt_ID +
                    ", Cantidad: " + nudMount.Value;
            new ActivityDAO().Action(UserCache.id, action);

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
            lblStatus.Text = string.Empty;
            btnPaid.Enabled = false;
            btnPDF.Enabled = false;
            btnReceipt.Enabled = false;
            dtgHistory.DataSource = new List<HistoryDTG>();
            chartHC.Visible = false;
            receipt = null;
            btnSearch.Enabled = false;
            dtgPrevIndex = -1;
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
                        List<PaymentDoc> paymentsCSV;
                        try
                        {
                            reader = File.OpenText(ofnMassive.FileName);
                            csvReader = new CsvReader(reader, CultureInfo.CurrentCulture);
                            paymentsCSV = csvReader.GetRecords<PaymentDoc>().ToList();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("No se pudo abrir el archivo", "Ambar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        List<PaymentDTO> finalPayments = new List<PaymentDTO>();
                        bool isCorrect = true;
                        foreach (var paymentCSV in paymentsCSV)
                        {
                            if (!Validate(paymentCSV, finalPayments))
                            {
                                finalPayments.Clear();
                                isCorrect = false;
                                break;
                            }
                            
                            PaymentDTO payment = FillPayment(paymentCSV);
                            finalPayments.Add(payment);
                        }

                        foreach (var payment in finalPayments)
                        {
                            receiptDAO.PaidReceipt(payment.Receipt_ID, payment.Meter_Serial_Number, payment.Service_Number,
                                payment.Service, payment.Year, payment.Month, payment.Mount, payment.Amount_Paid,
                                payment.Pending_Amount, payment.Payment_Type);
                        }

                        string action = "[Pago de Recibos] Pago masivo de recibos ";
                        new ActivityDAO().Action(UserCache.id, action);

                        ClearForm();
                        if (isCorrect)
                        {
                            ClearForm();
                            MessageBox.Show("La operación se realizó exitosamente", "Ambar", MessageBoxButtons.OK);
                        }

                        reader.Close();
                        break;
                    }
                    case 2:
                    {
                        FileStream reader;
                        IExcelDataReader xlsxReader;
                        DataSet dataSetXLSX;
                        List<PaymentDoc> paymentsCSV;
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
                            paymentsCSV = (from row in dataTable.AsEnumerable()
                                           select new PaymentDoc()
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

                        List<PaymentDTO> finalPayments = new List<PaymentDTO>();
                        bool isCorrect = true;
                        foreach (var paymentCSV in paymentsCSV)
                        {
                            if (!Validate(paymentCSV, finalPayments))
                            {
                                finalPayments.Clear();
                                isCorrect = false;
                                break;
                            }
                            
                            PaymentDTO payment = FillPayment(paymentCSV);
                            finalPayments.Add(payment);
                        }

                        foreach (var payment in finalPayments)
                        {
                            receiptDAO.PaidReceipt(payment.Receipt_ID, payment.Meter_Serial_Number, payment.Service_Number,
                                payment.Service, payment.Year, payment.Month, payment.Mount, payment.Amount_Paid,
                                payment.Pending_Amount, payment.Payment_Type);
                        }

                        string action = "[Pago de Recibos] Pago masivo de recibos ";
                        new ActivityDAO().Action(UserCache.id, action);

                        ClearForm();
                        if (isCorrect)
                        {
                            ClearForm();
                            MessageBox.Show("La operación se realizó exitosamente", "Ambar", MessageBoxButtons.OK);
                        }

                        reader.Close();
                        break;
                    }
                }
            }
        }

        private void btnPDF_Click(object sender, EventArgs e)
        {
            if (ofnReceipt.ShowDialog() == DialogResult.OK)
            {
                PDFUtils.GeneratePDFReceipt(receipt, ofnReceipt.FileName);

                ClearForm();
                MessageBox.Show("La operación se realizó exitosamente", "Ambar", MessageBoxButtons.OK);
            }
        }

        private bool Validate(PaymentDoc payment, List<PaymentDTO> payments)
        {
            ContractDAO contractDAO = new ContractDAO();

            if (payment.Medidor == string.Empty || payment.MetodoDePago == string.Empty || payment.Pago == string.Empty ||
               payment.Anio == string.Empty || payment.Mes == string.Empty)
            {
                MessageBox.Show("Todos los campos son obligatorios", "Ambar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (payment.Medidor.IndexOf('\'') != -1 || payment.MetodoDePago.IndexOf('\'') != -1 || 
                payment.Pago.IndexOf('\'') != -1 || payment.Anio.IndexOf('\'') != -1 || payment.Mes.IndexOf('\'') != -1)
            {
                MessageBox.Show("Caracter \' no valido", "Ambar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Validar que el kilowatt sea correcto
            if (!RegexUtils.IsDecimalNumber(payment.Pago))
            {
                MessageBox.Show("Kilowatts consumidos solo acepta numeros decimales", "Ambar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Validar que mes y anio sean numericos (mes solo 1-12)
            if (!RegexUtils.IsMonthNumber(payment.Mes) || !RegexUtils.IsYearNumber(payment.Anio))
            {
                MessageBox.Show("Fecha con formato incorrecto", "Ambar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (!new ContractDAO().ContractExists(payment.Medidor))
            {
                MessageBox.Show("El número de medidor no existe actualmente", "Ambar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (payment.MetodoDePago != "Efectivo" && payment.MetodoDePago != "Tarjeta de credito" &&
                payment.MetodoDePago != "Tarjeta de debito" && payment.MetodoDePago != "Transferencia bancaria")
            {
                MessageBox.Show("Metodo de pago con formato incorrecto", "Ambar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            string serviceType = contractDAO.FindServiceType(payment.Medidor);
            if (serviceType == null)
            {
                MessageBox.Show("Error inesperado", "Ambar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (serviceType != "Domestico" && serviceType != "Industrial")
            {
                MessageBox.Show("Tipo de servicio no valido", "Ambar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            int year = Convert.ToInt32(payment.Anio);
            int month = Convert.ToInt32(payment.Mes);
            DateTime period = new DateTime(year, month, 1);
            period = DateUtils.FindPeriod(serviceType, period);
            payment.Mes = period.Month.ToString();
            
            receipt = receiptDAO.FindReceipt(period.Year, period.Month, payment.Medidor);
            if (receipt == null)
            {
                MessageBox.Show("No se encontró recibo", "Ambar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (!contractDAO.IsClientContract(UserCache.id, payment.Medidor))
            {
                MessageBox.Show("No se puede tener acceso al numero de medidor", "Ambar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (receipt.Is_Paid)
            {
                MessageBox.Show("Uno de los recibos ya fue pagado", "Ambar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            decimal pago = Convert.ToDecimal(payment.Pago);
            if (pago > receipt.Pending_Amount)
            {
                MessageBox.Show("Un pago excede la cifra del pago pendiente", "Ambar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (pago == 0.00m)
            {
                MessageBox.Show("No se puede pagar en 0", "Ambar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            DateTime next = DateUtils.FindNextPeriod(serviceType, period);
            ReceiptDTO nextReceipt = receiptDAO.FindReceipt(next.Year, next.Month, payment.Medidor);
            if (nextReceipt != null)
            {
                MessageBox.Show("No se puede pagar un recibo porque ya fue emitido otro en fechas posteriores", "Ambar", MessageBoxButtons.OK);
                return false;
            }

            var isMeterSerialNumber = payments.Where(x => x.Meter_Serial_Number == payment.Medidor).FirstOrDefault();
            var isMonth = payments.Where(x => x.Month == Convert.ToInt32(payment.Mes)).FirstOrDefault();
            var isYear = payments.Where(x => x.Year == Convert.ToInt32(payment.Anio)).FirstOrDefault();

            if (isMeterSerialNumber != null && isMonth != null && isYear != null)
            {
                MessageBox.Show("No es posible pagar dos veces el mismo recibo en un archivo", "Ambar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private PaymentDTO FillPayment(PaymentDoc payment)
        {
            PaymentDTO dto = new PaymentDTO();
            dto.Meter_Serial_Number = payment.Medidor;
            dto.Payment_Type = payment.MetodoDePago;
            dto.Mount = Convert.ToDecimal(payment.Pago);
            dto.Year = Convert.ToInt32(payment.Anio);
            dto.Month = Convert.ToInt32(payment.Mes);
            ReceiptDTO receipt = receiptDAO.FindReceipt(dto.Year, dto.Month, dto.Meter_Serial_Number);
            dto.Receipt_ID = receipt.Receipt_ID;
            dto.Service_Number = receipt.Service_Number;
            dto.Service = receipt.Service;
            dto.Amount_Paid = receipt.Amount_Paid;
            dto.Pending_Amount = receipt.Pending_Amount;
            return dto;
        }

        private void dtgContracts_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (dtgPrevIndex == index || index == -1)
            {
                ClearForm();
            }
            else
            {
                txtMeterSerialNumber.Text = dtgContracts.Rows[index].Cells[1].Value.ToString();
                dtgPrevIndex = index;
                btnSearch.Enabled = true;
            }
        }

        private void btnReceipt_Click(object sender, EventArgs e)
        {
            Form form = new ReceiptDisplay(receipt);
            form.ShowDialog();
        }
    }
}
