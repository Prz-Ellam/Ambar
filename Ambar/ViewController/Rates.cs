using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ambar.Model.DAO;
using Ambar.Model.DTO;

namespace Ambar.ViewController
{
    public partial class Rates : Form
    {
        private RateDAO dao = new RateDAO();

        public Rates()
        {
            InitializeComponent();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (txtBasic.Text == string.Empty || txtIntermediate.Text == string.Empty || txtSurplus.Text == string.Empty
                || cbService.SelectedIndex == -1)
            {
                PrintError("TODOS LOS CAMPOS SON OBLIGATORIOS");
                return;
            }

            //Regex r = new Regex("^[0-9]+$");
            //Regex r = new Regex(@"^\d+\.?\d*$");
            //if (r.IsMatch(txtBasic.Text) && r.IsMatch(txtIntermediate.Text) && r.IsMatch(txtSurplus.Text))
            //{
            //    PrintError("SOLO SE ACEPTAN CARACTERES NUMERICOS");
            //    return;
            //}
            
            RateDTO rate = new RateDTO();
            rate.Basic_Level = Convert.ToDecimal(txtBasic.Text);
            rate.Intermediate_Level = Convert.ToDecimal(txtIntermediate.Text);
            rate.Surplus_Level = Convert.ToDecimal(txtSurplus.Text);
            rate.Year = dtpPeriod.Value.Year;
            rate.Month = Convert.ToInt16(dtpPeriod.Value.Month);
            rate.Service = cbService.SelectedItem.ToString();

            dao.Create(rate);

            dgvRates.DataSource = dao.ReadAll();

            ClearForm();
        }

        private void btnMasiveCharge_Click(object sender, EventArgs e)
        {
            // Read from Excel or CSV
        }

        private void ClearForm()
        {
            cbService.SelectedIndex = -1;
            txtBasic.Clear();
            txtIntermediate.Clear();
            txtSurplus.Clear();
        }

        private void Rates_Load(object sender, EventArgs e)
        {
            dgvRates.DataSource = dao.ReadAll();
        }

        private void PrintError(string error)
        {
            pbWarningIcon.Visible = true;
            lblError.Visible = true;
            lblError.Text = error;
        }
    }
}
