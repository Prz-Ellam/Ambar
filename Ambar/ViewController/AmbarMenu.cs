using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ambar.Common;

namespace Ambar.ViewController
{
    public partial class AmbarMenu : Form
    {
        public AmbarMenu()
        {
            InitializeComponent();
        }

        private void AmbarMenu_Load(object sender, EventArgs e)
        {
            lblPositionLogged.Text = UserCache.position;
            lblUsernameLogged.Text = UserCache.username;

            if (UserCache.position == "Administrator")
            {
                btnClients.Visible = false;
                panelClients.Visible = false;
                btnContracts.Visible = false;
                panelContracts.Visible = false;
                btnConsumptions.Visible = false;
                panelConsumptions.Visible = false;
                btnRates.Visible = false;
                panelRates.Visible = false;
                btnReports.Visible = false;
                panelReports.Visible = false;
            }
            else if (UserCache.position == "Employee")
            {
                btnEmployees.Visible = false;
                panelEmployees.Visible = false;
                btnClients.Location = new Point(btnClients.Location.X, btnClients.Location.Y - 60);
                panelClients.Location = new Point(panelClients.Location.X, panelClients.Location.Y - 60);
                btnContracts.Location = new Point(btnContracts.Location.X, btnContracts.Location.Y - 60);
                panelContracts.Location = new Point(panelContracts.Location.X, panelContracts.Location.Y - 60);
                // -60
            }

        }

        private void openFormChild(object son)
        {
            if (panelStorage.Controls.Count != 0)
            {
                panelStorage.Controls.RemoveAt(0);
            }
            Form fh = son as Form;
            fh.TopLevel = false;
            fh.Dock = DockStyle.Fill;
            panelStorage.Controls.Add(fh);
            panelStorage.Tag = fh;
            fh.Show();
        }

        private void btnEmpleados_Click(object sender, EventArgs e)
        {
            openFormChild(new Employees());
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            openFormChild(new Clients());
        }

        private void btnTarifas_Click(object sender, EventArgs e)
        {
            openFormChild(new Rates());
        }

        private void btnContratos_Click(object sender, EventArgs e)
        {
            openFormChild(new Contracts());
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Form login = new Login();
            login.Show();
            this.Hide();
        }

        private void btnMinimized_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            SubmenuReportes.Visible = !SubmenuReportes.Visible;
            int alpha = (SubmenuReportes.Visible) ? 255 : 0;
            btnReports.BackColor = Color.FromArgb(alpha, 40, 40, 40);
        }

        private void btnConsumos_Click(object sender, EventArgs e)
        {
            openFormChild(new Consumos());
        }

        private void lblUsernameLogged_Click(object sender, EventArgs e)
        {

        }

        private void btnRatesReport_Click(object sender, EventArgs e)
        {
            openFormChild(new RatesReport());
        }

        private void fadeIn_Tick(object sender, EventArgs e)
        {
            if (Opacity < 1)
            {
                Opacity += 0.05f;
            }
        }

        private void btnConsumptionsReport_Click(object sender, EventArgs e)
        {
            openFormChild(new ConsumptionsReport());
        }

        private void btnReceipts_Click(object sender, EventArgs e)
        {
            openFormChild(new Receipts());
        }
    }
}
