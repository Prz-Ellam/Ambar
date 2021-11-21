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
using Ambar.Common;
using Cassandra;
using Ambar.ViewController.Objects;
using Ambar.Model.AmbarMapper;

namespace Ambar.ViewController
{
    public partial class Clients : Form
    {
        ClientDAO clientDAO = new ClientDAO();
        UserRememberDAO userRemember = new UserRememberDAO();

        string originalUsername;
        Guid originalID;

        int dgvPrevIndex = -1;
        int lbPrevIndex = -1;
        int cbPrevIndex = -1;

        public Clients()
        {
            InitializeComponent();
        }

        private void Clients_Load(object sender, EventArgs e)
        {
            FillDataGridView();
            FillDisableUsers();
            cbGender.SelectedIndex = 0;
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (btnUpdate.Enabled || btnDelete.Enabled)
            {
                return;
            }

            // Objeto de transferencia de datos para la creacion de los datos del cliente
            ClientForm client = FillClient(Operations.Create);
            if (!Validate(client, Operations.Create))
            {
                return;
            }

            ClientDTO clientDTO = ClientMapper.CreateDTO(client);
            clientDAO.Create(clientDTO);

            string action = "[Cliente] Fue creado: " + client.Username + ", con ID: " + client.ID;
            new ActivityDAO().Action(UserCache.id, action);

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

            ClientForm client = FillClient(Operations.Update);
            if (!Validate(client, Operations.Update))
            {
                return;
            }

            ClientDTO clientDTO = ClientMapper.CreateDTO(client);
            clientDAO.Update(clientDTO, originalUsername);
            if (userRemember.RememberUserExists("Client", originalUsername))
            {
                userRemember.UpdateRememberUser("Client", originalUsername, client.Username, client.Password);
            }

            string action = "[Cliente] Fue modificado: " + originalUsername + ", por " + client.Username + ", con ID: " + client.ID;
            new ActivityDAO().Action(UserCache.id, action);

            FillDataGridView();
            FillDisableUsers();
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

                if (new ContractDAO().IsClientContractExists(originalID))
                {
                    MessageBox.Show("No se puede borrar cliente porque posee un contrato", "Ambar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                clientDAO.Delete(originalID, originalUsername);
                if (userRemember.RememberUserExists("Client", originalUsername))
                {
                    userRemember.ForgerPassword("Client", originalUsername);
                }

                string action = "[Cliente] Fue eliminado: " + originalUsername + ", con ID: " + originalID;
                new ActivityDAO().Action(UserCache.id, action);

                FillDataGridView();
                FillDisableUsers();
                ClearForm();
                MessageBox.Show("La operación se realizó exitosamente", "Ambar", MessageBoxButtons.OK);
            }
        }

        private void btnEnabling_Click(object sender, EventArgs e)
        {
            if (txtDisable.Text == string.Empty)
            {
                return;
            }
            clientDAO.Enabled(txtDisable.Text, true);
            ClearDisableUsers();
            FillDisableUsers();
            MessageBox.Show("La operación se realizó exitosamente", "Ambar", MessageBoxButtons.OK);
        }

        private ClientForm FillClient(Operations operationCode)
        {
            ClientForm client = new ClientForm();
            client.ID = (operationCode == Operations.Update) ? originalID : Guid.NewGuid();
            client.FirstName = StringUtils.GetText(txtFirstName.Text);
            client.FatherLastName = StringUtils.GetText(txtFatherLastName.Text);
            client.MotherLastName = StringUtils.GetText(txtMotherLastName.Text);
            client.CURP = StringUtils.GetText(txtCURP.Text);
            for (int i = 0; i < cbEmails.Items.Count; i++)
            {
                client.Emails.Add(StringUtils.GetText(cbEmails.Items[i].ToString()));
            }
            client.DateOfBirth = dtpDateOfBirth.Value;
            client.Gender = cbGender.Text;
            client.Username = StringUtils.GetText(txtUsername.Text);
            client.Password = StringUtils.GetText(txtPassword.Text);
            client.ConfirmPassword = StringUtils.GetText(txtConfirmPassword.Text);
            return client;
        }

        private bool Validate(ClientForm client, Operations operationCode)
        {
            if (client.FirstName == string.Empty || client.FatherLastName == string.Empty ||
                client.MotherLastName == string.Empty || client.CURP == string.Empty ||
                client.Emails.Count() <= 0 || client.Username == string.Empty || client.Gender == "Seleccionar" ||
                client.Password == string.Empty || client.ConfirmPassword == string.Empty)
            {
                MessageBox.Show("Todos los campos son obligatorios", "Ambar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (client.FirstName.IndexOf('\'') != -1 || client.FatherLastName.IndexOf('\'') != -1 ||
                client.MotherLastName.IndexOf('\'') != -1 || client.CURP.IndexOf('\'') != -1 || client.Username.IndexOf('\'') != -1 || 
                client.Password.IndexOf('\'') != -1 || client.ConfirmPassword.IndexOf('\'') != -1)
            {
                MessageBox.Show("Caracter \' no valido", "Ambar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            foreach (var email in client.Emails)
            {
                if (email.IndexOf('\'') != -1)
                {
                    MessageBox.Show("Caracter \' no valido", "Ambar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            if (client.Password != client.ConfirmPassword)
            {
                MessageBox.Show("Verificar contraseña", "Ambar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (!RegexUtils.ValidateName(client.FirstName) || !RegexUtils.ValidateName(client.FatherLastName)
                || !RegexUtils.ValidateName(client.MotherLastName))
            {
                MessageBox.Show("Nombre y/o Apellidos no validos", "Ambar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (!RegexUtils.ValidateUsername(client.Username))
            {
                MessageBox.Show("Nombre de usuario no valido", "Ambar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (!RegexUtils.VerifyCURP(client.CURP))
            {
                MessageBox.Show("Verificar curp", "Ambar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (client.DateOfBirth > DateTime.Now)
            {
                MessageBox.Show("Fecha de nacimiento no valida", "Ambar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            for (int i = 0; i < cbEmails.Items.Count; i++)
            {
                if (!RegexUtils.VerifyEmail(cbEmails.Items[i].ToString()))
                {
                    MessageBox.Show("Verificar emails", "Ambar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            bool userExists = clientDAO.UserExists(client.Username);
            if (userExists && operationCode != Operations.Update || userExists && originalUsername != client.Username)
            {
                MessageBox.Show("El nombre de usuario ya existe", "Ambar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void ClearForm()
        {
            txtFirstName.Clear();
            txtFirstName.Focus();
            txtFatherLastName.Clear();
            txtMotherLastName.Clear();
            dtpDateOfBirth.Value = DateTime.Now;
            cbEmails.Items.Clear();
            txtCURP.Clear();
            cbGender.SelectedIndex = 0;
            txtUsername.Clear();
            txtPassword.Clear();
            txtConfirmPassword.Clear();
            btnAccept.Enabled = true;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
            dgvPrevIndex = -1;
            dtgEmails.Rows.Clear();
        }

        private void FillDataGridView()
        {
            List<ClientDTO> clients = clientDAO.ReadAll();
            List<ClientDTG> dtgClients = new List<ClientDTG>();
            foreach (var client in clients)
            {
                dtgClients.Add(new ClientDTG(client));
            }
            this.dtgClients.DataSource = dtgClients;
            this.dtgClients.Columns["Emails"].Visible = false;
        }

        private void dtgClients_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (dgvPrevIndex == index || index == -1)
            {
                ClearForm();
                dtgEmails.Rows.Clear();
            }
            else
            {
                var row = dtgClients.Rows[index];
                originalID = Guid.Parse(row.Cells[0].Value.ToString());
                txtUsername.Text = row.Cells[1].Value.ToString();
                originalUsername = row.Cells[1].Value.ToString();
                txtPassword.Text = row.Cells[2].Value.ToString();
                txtConfirmPassword.Text = row.Cells[2].Value.ToString();
                txtFirstName.Text = row.Cells[3].Value.ToString();
                txtFatherLastName.Text = row.Cells[4].Value.ToString();
                txtMotherLastName.Text = row.Cells[5].Value.ToString();
                dtpDateOfBirth.Value = Convert.ToDateTime(row.Cells[7].Value.ToString());
                txtCURP.Text = row.Cells[8].Value.ToString();
                cbGender.SelectedIndex = cbGender.FindString(row.Cells[9].Value.ToString());

                dtgEmails.Rows.Clear();
                cbEmails.Items.Clear();
                IEnumerable<string> emails = row.Cells[6].Value as IEnumerable<string>;
                if (emails == null)
                {
                    MessageBox.Show("Error inesperado", "Ambar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                foreach (var email in emails.ToList())
                {
                    dtgEmails.Rows.Add(email);
                    cbEmails.Items.Add(email);
                }

                btnAccept.Enabled = false;
                btnUpdate.Enabled = true;
                btnDelete.Enabled = true;

                dgvPrevIndex = index;
            }

        }

        public void ClearDisableUsers()
        {
            txtDisable.Clear();
            btnEnabling.Enabled = false;
            lbDisableClients.ClearSelected();
            lbPrevIndex = -1;
        }

        public void FillDisableUsers()
        {
            lbDisableClients.DataSource = clientDAO.ReadAllDisable();
            lbDisableClients.ClearSelected();
        }

        private void lbDisableClients_Click(object sender, EventArgs e)
        {
            if (lbPrevIndex == lbDisableClients.SelectedIndex)
            {
                ClearDisableUsers();
            }
            else
            {
                txtDisable.Text = lbDisableClients.SelectedItem.ToString();
                btnEnabling.Enabled = true;
                lbPrevIndex = lbDisableClients.SelectedIndex;
            }
        }

        private void cbEmails_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (cbPrevIndex != -1)
                {
                    // Si dejo vacio se borra, si escribio un email que ya existe, igual se borra para
                    // que quede el que ya estaba
                    if (cbEmails.Text == string.Empty || cbEmails.FindString(cbEmails.Text) != -1)
                    {
                        cbEmails.Items.RemoveAt(cbPrevIndex);
                    }
                    else
                    {
                        cbEmails.Items[cbPrevIndex] = cbEmails.Text;
                    }
                    cbPrevIndex = -1;
                }
                else
                {
                    if (cbEmails.FindString(cbEmails.Text) == -1 && cbEmails.Text != string.Empty)
                    {
                        cbEmails.Items.Add(cbEmails.Text);
                    }
                }
                cbEmails.Text = "";
            }
        }

        private void cbEmails_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbPrevIndex = cbEmails.SelectedIndex;
        }

    }
}