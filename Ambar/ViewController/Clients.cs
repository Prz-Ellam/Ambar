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
        int cbPrevIndex = -1;

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
            if (btnUpdate.Enabled || btnDelete.Enabled)
            {
                return;
            }

            // Objeto de transferencia de datos para la creacion de los datos del cliente
            ClientDTO client = new ClientDTO();
            client.User_ID = Guid.NewGuid();
            client.First_Name = StringUtils.GetText(txtFirstName.Text);
            client.Father_Last_Name = StringUtils.GetText(txtFatherLastName.Text);
            client.Mother_Last_Name = StringUtils.GetText(txtMotherLastName.Text);
            client.CURP = StringUtils.GetText(txtCURP.Text);
            List<string> emailsAux = new List<string>();
            for (int i = 0; i < cbEmails.Items.Count; i++)
            {
                emailsAux.Add(StringUtils.GetText(cbEmails.Items[i].ToString()));
            }
            client.Emails = emailsAux.AsEnumerable<string>();
            client.Date_Of_Birth = new LocalDate(dtpDateOfBirth.Value.Year, dtpDateOfBirth.Value.Month, dtpDateOfBirth.Value.Day);
            client.Gender = cbGender.Text;
            client.User_Name = StringUtils.GetText(txtUsername.Text);
            client.Password = StringUtils.GetText(txtPassword.Text);
            string confirmPassword = StringUtils.GetText(txtConfirmPassword.Text);

            if (client.First_Name == string.Empty || client.Father_Last_Name == string.Empty ||
                client.Mother_Last_Name == string.Empty || client.CURP == string.Empty ||
                client.Emails.Count() <= 0 || client.User_Name == string.Empty || client.Gender == string.Empty ||
                client.Password == string.Empty || confirmPassword == string.Empty)
            {
                PrintError("TODOS LOS CAMPOS SON OBLIGATORIOS");
                return;
            }

            if (client.Password != confirmPassword)
            {
                PrintError("VERIFICAR CONTRASEÑA");
                return;
            }

            if (!RegexUtils.VerifyCURP(client.CURP))
            {
                PrintError("VERIFICAR CURP");
                return;
            }

            for (int i = 0; i < cbEmails.Items.Count; i++)
            {
                if (!RegexUtils.VerifyEmail(cbEmails.Items[i].ToString()))
                {
                    PrintError("VERIFICAR EMAILS");
                    return;
                }
            }

            if (clientDao.UserExists(client.User_Name))
            {
                PrintError("EL NOMBRE DE USUARIO YA EXISTE");
                return;
            }

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

            ClientDTO client = new ClientDTO();
            client.User_ID = originalID;
            client.First_Name = StringUtils.GetText(txtFirstName.Text);
            client.Father_Last_Name = StringUtils.GetText(txtFatherLastName.Text);
            client.Mother_Last_Name = StringUtils.GetText(txtMotherLastName.Text);
            client.CURP = StringUtils.GetText(txtCURP.Text);
            List<string> emailsAux = new List<string>();
            for (int i = 0; i < cbEmails.Items.Count; i++)
            {
                emailsAux.Add(StringUtils.GetText(cbEmails.Items[i].ToString()));
            }
            client.Emails = emailsAux.AsEnumerable<string>();
            client.Date_Of_Birth = new LocalDate(dtpDateOfBirth.Value.Year, dtpDateOfBirth.Value.Month, dtpDateOfBirth.Value.Day);
            client.Gender = cbGender.Text;
            client.User_Name = StringUtils.GetText(txtUsername.Text);
            client.Password = StringUtils.GetText(txtPassword.Text);
            string confirmPassword = StringUtils.GetText(txtConfirmPassword.Text);

            if (client.First_Name == string.Empty || client.Father_Last_Name == string.Empty ||
                client.Mother_Last_Name == string.Empty || client.CURP == string.Empty ||
                client.Emails.Count() <= 0 || client.User_Name == string.Empty ||
                client.Password == string.Empty || confirmPassword == string.Empty)
            {
                PrintError("TODOS LOS CAMPOS SON OBLIGATORIOS");
                return;
            }

            if (client.Password != confirmPassword)
            {
                PrintError("VERIFICAR CONTRASEÑA");
                return;
            }

            if (!RegexUtils.VerifyCURP(client.CURP))
            {
                PrintError("VERIFICAR CURP");
                return;
            }

            for (int i = 0; i < cbEmails.Items.Count; i++)
            {
                if (!RegexUtils.VerifyEmail(cbEmails.Items[i].ToString()))
                {
                    PrintError("VERIFICAR EMAILS");
                    return;
                }
            }

            if (clientDao.UserExists(client.User_Name) && originalUsername != client.User_Name)
            {
                PrintError("EL NOMBRE DE USUARIO YA EXISTE");
                return;
            }

            clientDao.Update(client, originalUsername);
            if (userRemember.RememberUserExists("Client", originalUsername))
            {
                userRemember.UpdateRememberUser("Client", originalUsername, client.User_Name, client.Password);
            }

            FillDataGridView();
            FillDisableUsers();
            dtgEmails.Rows.Clear();

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
                    PrintError("NO SE PUEDE BORRAR CLIENTE PORQUE POSEE UN CONTRATO");
                    return;
                }

                clientDao.Delete(originalID, originalUsername);
                if (userRemember.RememberUserExists("Client", originalUsername))
                {
                    userRemember.ForgerPassword("Client", originalUsername);
                }

                FillDataGridView();
                FillDisableUsers();
                dtgEmails.Rows.Clear();

                ClearForm();
                MessageBox.Show("La operación se realizó exitosamente", "", MessageBoxButtons.OK);
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

        private void dtgClients_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (dgvPrevIndex == index || index == -1)
            {
                ClearForm();
                dtgEmails.Rows.Clear();
                cbEmails.Items.Clear();
                dgvPrevIndex = -1;
                return;
            }
            else
            {
                originalID = Guid.Parse(dtgClients.Rows[index].Cells[0].Value.ToString());
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
                IEnumerable<string> emails = dtgClients.Rows[index].Cells[6].Value as IEnumerable<string>;
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
                pbWarningIcon.Visible = false;
                lblError.Visible = false;

                dgvPrevIndex = index;
            }

        }

        public void ClearDisableUsers()
        {
            txtDisable.Clear();
            btnEnabling.Enabled = false;
            lbPrevIndex = -1;
            lbDisableClients.ClearSelected();
        }

        public void FillDisableUsers()
        {
            lbDisableClients.Items.Clear();
            List<string> names = clientDao.ReadAllDisable();
            foreach (var name in names)
            {
                lbDisableClients.Items.Add(name);
            }
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

        private void btnEnabling_Click(object sender, EventArgs e)
        {
            clientDao.Enabled(txtDisable.Text, true);

            ClearDisableUsers();

            FillDisableUsers();
        }

        private void PrintError(string error)
        {
            pbWarningIcon.Visible = true;
            lblError.Visible = true;
            lblError.Text = error;
        }

        private void cbEmails_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbPrevIndex = cbEmails.SelectedIndex;
        }
    }
}