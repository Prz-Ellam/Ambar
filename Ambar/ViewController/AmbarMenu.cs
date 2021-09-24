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
            lblPositionLogged.Text = UserCache.position;
            lblUsernameLogged.Text = UserCache.username;
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
            openFormChild(new Contratos());
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
            btnReportes.BackColor = Color.FromArgb(alpha, 40, 40, 40);
        }

        private void btnConsumos_Click(object sender, EventArgs e)
        {
            openFormChild(new Consumos());
        }

        private void lblUsernameLogged_Click(object sender, EventArgs e)
        {

        }
    }
}
