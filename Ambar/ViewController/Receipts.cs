using Ambar.Model.DAO;
using Ambar.Model.DTO;
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
        public Receipts()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Generar los recibos

            ContractDAO contractDao = new ContractDAO();
            ConsumptionDAO consumptionDAO = new ConsumptionDAO();
            List<ContractForReceiptDTO> contractsInfo = contractDao.ReadContractsForReceipt();
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
               
                register = consumptionDAO.GetConsumptions(dtpYear.Value.Year, month, contractInfo.Meter_Serial_Number);

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
                receipt.Father_Last_Mame = contractsInfo[i].Father_Last_Name;
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
                receipt.Basic_Price = receipt.Basic_Level * receipt.Basic_KW;
                receipt.Intermediate_Price = receipt.Intermediate_Level * receipt.Intermediate_KW;
                receipt.Surplus_Price = receipt.Surplus_Level * receipt.Surplus_KW;
                receipt.Tax = Convert.ToDecimal(ConfigurationManager.AppSettings["IVA"].ToString(), CultureInfo.InvariantCulture);
                receipt.Subtotal_Price = receipt.Basic_Price + receipt.Intermediate_Price + receipt.Surplus_Price;
                receipt.Total_Price = receipt.Subtotal_Price + receipt.Subtotal_Price * receipt.Tax;
                receipt.Amount_Pad = 0;
                receipt.Pending_Amount = receipt.Total_Price;
            }



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
    }
}
