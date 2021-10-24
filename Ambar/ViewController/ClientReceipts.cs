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
            short month = -1;
            month = Convert.ToInt16(cbPeriod.SelectedIndex * 2 + 1);

            ReceiptDTO dto = receiptDAO.FindReceipt(dtpYear.Value.Year, month, txtMeterSerialNumber.Text);

            label1.Text = dto.Total_Price.ToString();
            label2.Text = dto.Amount_Pad.ToString();
            label3.Text = dto.Pending_Amount.ToString();

            int a = 5;
            a = 3;
        }

        private void btnPaid_Click(object sender, EventArgs e)
        {
            receiptDAO.PaidReceipt(Convert.ToDecimal(txtMount.Text), Convert.ToDecimal(label1.Text),
                Convert.ToDecimal(label2.Text), Convert.ToDecimal(label3.Text));
        }
    }
}
