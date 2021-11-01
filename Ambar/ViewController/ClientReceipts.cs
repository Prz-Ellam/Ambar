using Ambar.Common;
using Ambar.Model.DAO;
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
    public partial class ClientReceipts : Form
    {
        ReceiptDAO receiptDAO = new ReceiptDAO();
        ReceiptDTO receipt;
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
            if (serviceType == "Domestico" && request.Month % 2 == 0)
            {
                request = request.AddMonths(-1); // En caso de que fuese febrero se pasaria a enero
            }
            receipt = receiptDAO.FindReceipt(request.Year, Convert.ToInt16(request.Month), txtMeterSerialNumber.Text);
            if (receipt == null)
            {
                return;
            }

            lblImport.Text = receipt.Total_Price.ToString("0.00");
            lblAmountPad.Text = receipt.Amount_Pad.ToString("0.00");
            lblPendingPaid.Text = receipt.Pending_Amount.ToString("0.00");
            nudMount.Maximum = Convert.ToDecimal(receipt.Pending_Amount.ToString("0.00"));

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
    }
}
