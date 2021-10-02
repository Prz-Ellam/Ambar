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
using Cassandra;

namespace Ambar.ViewController
{
    public partial class Clients : Form
    {
        ClientDAO dao = new ClientDAO();
        string originalUsername;
        Guid originalID;

        int dgvPrevIndex = -1;
        int lbPrevIndex = -1;

        public Clients()
        {
            InitializeComponent();
        }

        private void Clients_Load(object sender, EventArgs e)
        {
            
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (txtFirstName.Text == string.Empty || txtFatherLastName.Text == string.Empty ||
                txtMotherLastName.Text == string.Empty || txtCURP.Text == string.Empty ||
                cbEmails.Items.Count <= 0 || txtUsername.Text == string.Empty || 
                txtPassword.Text == string.Empty || txtConfirmPassword.Text == string.Empty)
            {
                PrintError("TODOS LOS CAMPOS SON OBLIGATORIOS");
                return;
            }

            if (txtPassword.Text != txtConfirmPassword.Text)
            {
                PrintError("VERIFICAR CONTRASEÑA");
                return;
            }

            if (!VerifyCURP(txtCURP.Text))
            {
                PrintError("VERIFICAR CURP");
                return;
            }

            // Objeto de transferencia de datos para la creacion de los datos del cliente
            ClientDTO client = new ClientDTO();
            client.First_Name = txtFirstName.Text;
            client.Father_Last_Name = txtFatherLastName.Text;
            client.Mother_Last_Name = txtMotherLastName.Text;
            client.CURP = txtCURP.Text;
            for (int i = 0; i < cbEmails.Items.Count; i++)
            {
                client.Email.Add(cbEmails.Items[i].ToString());
            }
            client.Date_Of_Birth = new LocalDate(dtpDateOfBirth.Value.Year, dtpDateOfBirth.Value.Month, dtpDateOfBirth.Value.Day);
            client.Gender = cbGender.Text;
            client.User_Name = txtUsername.Text;
            client.Password = txtPassword.Text;

            dao.Create(client);

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtFirstName.Text == string.Empty || txtFatherLastName.Text == string.Empty ||
               txtMotherLastName.Text == string.Empty || txtCURP.Text == string.Empty ||
               cbEmails.Items.Count <= 0 || txtUsername.Text == string.Empty || 
               txtPassword.Text == string.Empty || txtConfirmPassword.Text == string.Empty)
            {
                PrintError("TODOS LOS CAMPOS SON OBLIGATORIOS");
                return;
            }

            if (txtPassword.Text != txtConfirmPassword.Text)
            {
                PrintError("VERIFICAR CONTRASEÑA");
                return;
            }

            if (!VerifyCURP(txtCURP.Text))
            {
                PrintError("VERIFICAR CURP");
                return;
            }

            ClientDTO client = new ClientDTO();
            client.User_ID = originalID;
            client.First_Name = txtFirstName.Text;
            client.Father_Last_Name = txtFatherLastName.Text;
            client.Mother_Last_Name = txtMotherLastName.Text;
            client.CURP = txtCURP.Text;
            for (int i = 0; i < cbEmails.Items.Count; i++)
            {
                client.Email.Add(cbEmails.Items[i].ToString());
            }
            client.Date_Of_Birth = new LocalDate(dtpDateOfBirth.Value.Year, dtpDateOfBirth.Value.Month, dtpDateOfBirth.Value.Day);
            client.Gender = cbGender.Text;
            client.User_Name = txtUsername.Text;
            client.Password = txtPassword.Text;


        }

        private void cbEmails_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (cbEmails.FindString(cbEmails.Text) == -1)
                {
                    cbEmails.Items.Add(cbEmails.Text);
                }
                cbEmails.Text = "";
            }
        }

        private void PrintError(string error)
        {
            pbWarningIcon.Visible = true;
            lblError.Visible = true;
            lblError.Text = error;
        }

        private bool VerifyCURP(string curp)
        {
            string res = @"^([A-Z][AEIOUX][A-Z]{2}\d{2}(?:0[1-9]|1[0-2])(?:0[1-9]|[12]\d|3[01])[HM](?:AS|B[CS]|C[CLMSH]|D[FG]|G[TR]|HG|JC|M[CNS]|N[ETL]|OC|PL|Q[TR]|S[PLR]|T[CSL]|VZ|YN|ZS)[B-DF-HJ-NP-TV-Z]{3}[A-Z\d])(\d)$";
            Regex rx = new Regex(res, RegexOptions.Compiled | RegexOptions.IgnoreCase);

            return rx.IsMatch(curp);
        }

        private void lbDisableEmployees_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (lbPrevIndex == lbDisableEmployees.SelectedIndex)
            {
                txtDisable.Clear();
                btnEnabling.Enabled = false;
                lbPrevIndex = -1;
                lbDisableEmployees.ClearSelected();
                return;
            }
            else
            {
                txtDisable.Text = lbDisableEmployees.Items[lbDisableEmployees.SelectedIndex].ToString();
                btnEnabling.Enabled = true;
                lbPrevIndex = lbDisableEmployees.SelectedIndex;
            }
        }

        private void dgvClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (dgvPrevIndex == index)
            {
                //ClearForm();
                dgvPrevIndex = -1;
                return;
            }
            else
            {
                //originalID = (Guid)dgvEmpleados.Rows[index].Cells[0].Value;
                //txt.Text = dgvEmpleados.Rows[index].Cells[5].Value.ToString();
                //txtFatherLastName.Text = dgvEmpleados.Rows[index].Cells[6].Value.ToString();
                //txtMotherLastName.Text = dgvEmpleados.Rows[index].Cells[7].Value.ToString();
                //dtpDateOfBirth.Value = Convert.ToDateTime(dgvEmpleados.Rows[index].Cells[8].Value.ToString());
                //txtRFC.Text = dgvEmpleados.Rows[index].Cells[9].Value.ToString();
                //txtCURP.Text = dgvEmpleados.Rows[index].Cells[10].Value.ToString();
                //txtUsername.Text = originalUsername = dgvEmpleados.Rows[index].Cells[1].Value.ToString();
                //txtPassword.Text = dgvEmpleados.Rows[index].Cells[2].Value.ToString();
                //txtConfirmPassword.Text = dgvEmpleados.Rows[index].Cells[2].Value.ToString();
                //btnAccept.Enabled = false;
                //btnUpdate.Enabled = true;
                //btnDelete.Enabled = true;
            }

            dgvPrevIndex = index;
        }
    }
}
