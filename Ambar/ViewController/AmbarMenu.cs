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
            PositionPermissions();
        }

        private void PositionPermissions()
        {
            switch (UserCache.position)
            {
                case "Administrator":
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
                    btnReceipts.Visible = false;
                    panelReceipts.Visible = false;
                    break;
                }
                case "Employee":
                {
                    btnEmployees.Visible = false;
                    panelEmployees.Visible = false;
                    btnClients.Location = new Point(btnClients.Location.X, btnClients.Location.Y - 60);
                    panelClients.Location = new Point(panelClients.Location.X, panelClients.Location.Y - 60);
                    btnContracts.Location = new Point(btnContracts.Location.X, btnContracts.Location.Y - 60);
                    panelContracts.Location = new Point(panelContracts.Location.X, panelContracts.Location.Y - 60);
                    btnConsumptions.Location = new Point(btnConsumptions.Location.X, btnConsumptions.Location.Y - 60);
                    panelConsumptions.Location = new Point(panelConsumptions.Location.X, panelConsumptions.Location.Y - 60);
                    btnRates.Location = new Point(btnRates.Location.X, btnRates.Location.Y - 60);
                    panelRates.Location = new Point(panelRates.Location.X, panelRates.Location.Y - 60);
                    btnReceipts.Location = new Point(btnReceipts.Location.X, btnReceipts.Location.Y - 60);
                    panelReceipts.Location = new Point(panelReceipts.Location.X, panelReceipts.Location.Y - 60);
                    btnReports.Location = new Point(btnReports.Location.X, btnReports.Location.Y - 60);
                    panelReports.Location = new Point(panelReports.Location.X, panelReports.Location.Y - 60);
                    panelSubmenuReports.Location = new Point(panelSubmenuReports.Location.X, panelSubmenuReports.Location.Y - 60);
                    break;
                }
                case "Client":
                {
                    btnEmployees.Visible = false;
                    panelEmployees.Visible = false;
                    btnClients.Visible = false;
                    panelClients.Visible = false;
                    btnContracts.Visible = false;
                    panelContracts.Visible = false;
                    btnRates.Visible = false;
                    panelRates.Visible = false;
                    btnConsumptions.Visible = false;
                    panelConsumptions.Visible = false;
                    btnGeneralReport.Visible = false;
                    panelGeneralReport.Visible = false;
                    btnRatesReport.Visible = false;
                    panelRatesReport.Visible = false;
                    btnConsumptionsReport.Visible = false;
                    panelConsumptionsReport.Visible = false;
                    btnReceipts.Location = new Point(btnReceipts.Location.X, btnReceipts.Location.Y - 244);
                    panelReceipts.Location = new Point(panelReceipts.Location.X, panelReceipts.Location.Y - 244);
                    btnReports.Location = new Point(btnReports.Location.X, btnReports.Location.Y - 244);
                    panelReports.Location = new Point(panelReports.Location.X, panelReports.Location.Y - 244);
                    panelSubmenuReports.Location = new Point(panelSubmenuReports.Location.X, panelSubmenuReports.Location.Y - 244);
                    btnHistoricConsumption.Location = new Point(btnHistoricConsumption.Location.X, 0);
                    panelHistoricConsumption.Location = new Point(panelHistoricConsumption.Location.X, 0);
                    break;
                }
                default:
                {
                    break;
                }
            }
        }

        private void OpenFormChild(object son)
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

        private void btnEmployees_Click(object sender, EventArgs e)
        {
            OpenFormChild(new Employees());
        }

        private void btnClients_Click(object sender, EventArgs e)
        {
            OpenFormChild(new Clients());
        }

        private void btnContracts_Click(object sender, EventArgs e)
        {
            OpenFormChild(new Contracts());
        }

        private void btnRates_Click(object sender, EventArgs e)
        {
            OpenFormChild(new Rates());
        }

        private void btnConsumptions_Click(object sender, EventArgs e)
        {
            OpenFormChild(new Consumptions());
        }

        private void btnReceipts_Click(object sender, EventArgs e)
        {
            switch (UserCache.position)
            {
                case "Employee":
                {
                    OpenFormChild(new Receipts());
                    break;
                }
                case "Client":
                {
                    OpenFormChild(new ClientReceipts());
                    break;
                }
                default:
                {
                    break;
                }
            }
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            panelSubmenuReports.Visible = !panelSubmenuReports.Visible;
            int alpha = (panelSubmenuReports.Visible) ? 255 : 0;
            btnReports.BackColor = Color.FromArgb(alpha, 40, 40, 40);
        }

        private void btnGeneralReport_Click(object sender, EventArgs e)
        {
            OpenFormChild(new GeneralReport());
        }

        private void btnHistoricConsumption_Click(object sender, EventArgs e)
        {
            OpenFormChild(new HistoricConsumption());
        }

        private void btnRatesReport_Click(object sender, EventArgs e)
        {
            OpenFormChild(new RatesReport());
        }

        private void btnConsumptionsReport_Click(object sender, EventArgs e)
        {
            OpenFormChild(new ConsumptionsReport());
        }

        private void fadeIn_Tick(object sender, EventArgs e)
        {
            Opacity = Opacity + 0.05f % 1;
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

    }
}
