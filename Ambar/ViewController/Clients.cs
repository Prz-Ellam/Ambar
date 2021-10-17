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
        ClientDAO clientDao = new ClientDAO();
        UserRememberDAO userRemember = new UserRememberDAO();
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
            FillDataGridView();
            FillDisableUsers();
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

            if (clientDao.UserExists(txtUsername.Text))
            {
                PrintError("EL NOMBRE DE USUARIO YA EXISTE");
                return;
            }

            // Objeto de transferencia de datos para la creacion de los datos del cliente
            ClientDTO client = new ClientDTO();
            client.User_ID = Guid.NewGuid();
            client.First_Name = txtFirstName.Text;
            client.Father_Last_Name = txtFatherLastName.Text;
            client.Mother_Last_Name = txtMotherLastName.Text;
            client.CURP = txtCURP.Text;

            List<string> emailsAux = new List<string>();
            for (int i = 0; i < cbEmails.Items.Count; i++)
            {
                emailsAux.Add(cbEmails.Items[i].ToString());
            }
            client.Emails = emailsAux.AsEnumerable<string>();

            client.Date_Of_Birth = new LocalDate(dtpDateOfBirth.Value.Year, dtpDateOfBirth.Value.Month, dtpDateOfBirth.Value.Day);
            client.Gender = cbGender.Text;
            client.User_Name = txtUsername.Text;
            client.Password = txtPassword.Text;

            clientDao.Create(client);

            FillDataGridView();

            ClearForm();
            MessageBox.Show("La operación se realizó exitosamente", "", MessageBoxButtons.OK);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (btnAccept.Enabled == true)
            {
                return;
            }

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

            if (!VerifyEmails())
            {
                PrintError("VERIFICAR EMAILS");
                return;
            }

            if (clientDao.UserExists(txtUsername.Text) && originalUsername != txtUsername.Text)
            {
                PrintError("EL NOMBRE DE USUARIO YA EXISTE");
                return;
            }

            ClientDTO client = new ClientDTO();
            client.User_ID = originalID;
            client.First_Name = txtFirstName.Text;
            client.Father_Last_Name = txtFatherLastName.Text;
            client.Mother_Last_Name = txtMotherLastName.Text;
            client.CURP = txtCURP.Text;

            List<string> emailsAux = new List<string>();
            for (int i = 0; i < cbEmails.Items.Count; i++)
            {
                emailsAux.Add(cbEmails.Items[i].ToString());
            }
            client.Emails = emailsAux.AsEnumerable<string>();

            client.Date_Of_Birth = new LocalDate(dtpDateOfBirth.Value.Year, dtpDateOfBirth.Value.Month, dtpDateOfBirth.Value.Day);
            client.Gender = cbGender.Text;
            client.User_Name = txtUsername.Text;
            client.Password = txtPassword.Text;

            clientDao.Update(client, originalUsername);
            userRemember.UpdateRememberUser("Client", originalUsername, client.User_Name, client.Password);

            FillDataGridView();

            ClearForm();
            MessageBox.Show("La operación se realizó exitosamente", "", MessageBoxButtons.OK);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (btnAccept.Enabled)
            {
                return;
            }

            DialogResult res = MessageBox.Show("¿Está seguro que desea realizar esta acción?", "ADVERTENCIA",
               MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (res == DialogResult.Yes)
            {
                clientDao.Delete(originalID, originalUsername);
                userRemember.ForgerPassword("Client", originalUsername);

                FillDataGridView();

                ClearForm();
                MessageBox.Show("La operación se realizó exitosamente", "", MessageBoxButtons.OK);
            }
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

        private bool VerifyEmails()
        {
            string res = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            Regex rx = new Regex(res, RegexOptions.Compiled | RegexOptions.IgnoreCase);

            for (int i = 0; i < cbEmails.Items.Count; i++)
            {
                if (!rx.IsMatch(cbEmails.Items[i].ToString())) {
                    return false;
                }
            }
            return true;
        }

        private void ClearForm()
        {
            txtFirstName.Clear();
            txtFatherLastName.Clear();
            txtMotherLastName.Clear();
            dtpDateOfBirth.Value = DateTime.Now;
            cbEmails.Items.Clear();
            txtCURP.Clear();
            cbGender.SelectedIndex = -1;
            txtUsername.Clear();
            txtPassword.Clear();
            txtConfirmPassword.Clear();
            btnAccept.Enabled = true;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
            pbWarningIcon.Visible = false;
            lblError.Visible = false;
        }

        private void btnEnabling_Click(object sender, EventArgs e)
        {
            clientDao.Enabled(txtDisable.Text, true);

            ClearDisableUsers();

            lbDisableClients.Items.Clear();
            FillDisableUsers();
        }

        private void lbDisableClients_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbPrevIndex == lbDisableClients.SelectedIndex)
            {
                ClearDisableUsers();
                return;
            }
            else
            {
                txtDisable.Text = lbDisableClients.Items[lbDisableClients.SelectedIndex].ToString();
                btnEnabling.Enabled = true;
                lbPrevIndex = lbDisableClients.SelectedIndex;
            }
        }

        private void FillDataGridView()
        {
            List<ClientDTO> clients = clientDao.ReadAll();
            List<ClientDTG> dtgClients = new List<ClientDTG>();
            foreach (var client in clients)
            {
                dtgClients.Add(new ClientDTG(client));
            }
            this.dtgClients.DataSource = dtgClients;
            this.dtgClients.Columns["Emails"].Visible = false;
        }

        public void ClearDisableUsers()
        {
            txtDisable.Clear();
            btnEnabling.Enabled = false;
            lbPrevIndex = -1;
            lbDisableClients.ClearSelected();
        }

        private void dtgClients_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (dgvPrevIndex == index)
            {
                ClearForm();
                dtgEmails.Rows.Clear();
                cbEmails.Items.Clear();
                dgvPrevIndex = -1;
                return;
            }
            else
            {
                originalID = (Guid)dtgClients.Rows[index].Cells[0].Value;
                txtUsername.Text = originalUsername = dtgClients.Rows[index].Cells[1].Value.ToString();
                txtPassword.Text = dtgClients.Rows[index].Cells[2].Value.ToString();
                txtConfirmPassword.Text = dtgClients.Rows[index].Cells[2].Value.ToString();

                txtFirstName.Text = dtgClients.Rows[index].Cells[3].Value.ToString();
                txtFatherLastName.Text = dtgClients.Rows[index].Cells[4].Value.ToString();
                txtMotherLastName.Text = dtgClients.Rows[index].Cells[5].Value.ToString();
                dtpDateOfBirth.Value = Convert.ToDateTime(dtgClients.Rows[index].Cells[7].Value.ToString());
                txtCURP.Text = dtgClients.Rows[index].Cells[8].Value.ToString();
                cbGender.SelectedIndex = cbGender.FindString(dtgClients.Rows[index].Cells[9].Value.ToString());

                dtgEmails.Rows.Clear();
                cbEmails.Items.Clear();
                IEnumerable<string> emails = (IEnumerable<string>)dtgClients.Rows[index].Cells[6].Value;
                foreach (var email in emails.ToList())
                {
                    dtgEmails.Rows.Add(email);
                    cbEmails.Items.Add(email);
                }

                btnAccept.Enabled = false;
                btnUpdate.Enabled = true;
                btnDelete.Enabled = true;
            }

            dgvPrevIndex = index;
        }

        public void FillDisableUsers()
        {
            List<string> names = clientDao.ReadAllDisable();
            foreach (var name in names)
            {
                lbDisableClients.Items.Add(name);
            }
        }
    }
}
