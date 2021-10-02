using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ambar.ViewController;
using Ambar.Model.DAO;
using Ambar.Model.DTO;
using System.Text.RegularExpressions;
using Cassandra;

namespace Ambar.ViewController
{
    public partial class Employees : Form
    {
        // DAO para hacer queries a la entidad empleados
        EmployeeDAO dao = new EmployeeDAO(); 
        /* 
           Guardamos el username y el ID original de un empleado al que se le este aplicando una edicion o borrado para 
           tener una referencia de los datos originales
        */
        string originalUsername; 
        Guid originalID;

        // Indices seleccionados del combobox y el data grid view
        int dgvPrevIndex = -1;
        int lbPrevIndex = -1;

        public Employees()
        {
            InitializeComponent();
        }

        private void Empleados_Load(object sender, EventArgs e)
        {
            dgvEmpleados.DataSource = dao.ReadAll();

            List<string> names = dao.ReadAllDisable();
            foreach (var ls in names)
            {
                lbDisableEmployees.Items.Add(names);
            }
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {

            if (txtNames.Text == string.Empty || txtFatherLastName.Text == string.Empty || 
                txtMotherLastName.Text == string.Empty || txtRFC.Text == string.Empty || 
                txtCURP.Text == string.Empty || txtUsername.Text == string.Empty || 
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

            if (dao.UserExists(txtUsername.Text))
            {
                PrintError("EL NOMBRE DE USUARIO YA EXISTE");
                return;
            }

            // Creamos un objeto de transferencia de datos para la entidad empleado y lo mandamos a Cassandra
            EmployeeDTO employee = new EmployeeDTO();
            employee.First_Name = txtNames.Text;
            employee.Father_Last_Name = txtFatherLastName.Text;
            employee.Mother_Last_Name = txtMotherLastName.Text;
            employee.Date_Of_Birth = new LocalDate(dtpBirthday.Value.Year, dtpBirthday.Value.Month, dtpBirthday.Value.Day);
            employee.RFC = txtRFC.Text;
            employee.CURP = txtCURP.Text;
            employee.User_Name = txtUsername.Text;
            employee.Password = txtPassword.Text;

            dao.Create(employee);

            dgvEmpleados.DataSource = dao.ReadAll();

            ClearForm();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            // Nunca se deberia dar este caso, pero en caso de cualquier error se previene con este if
            if (btnAccept.Enabled == false)
            {
                return;
            }

            if (txtNames.Text == string.Empty || txtFatherLastName.Text == string.Empty ||
                txtMotherLastName.Text == string.Empty || txtRFC.Text == string.Empty ||
                txtCURP.Text == string.Empty || txtUsername.Text == string.Empty ||
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

            if (dao.UserExists(txtUsername.Text) && originalUsername != txtUsername.Text)
            {
                PrintError("EL NOMBRE DE USUARIO YA EXISTE");
                return;
            }

            EmployeeDTO employee = new EmployeeDTO();
            employee.User_ID = originalID;
            employee.First_Name = txtNames.Text;
            employee.Father_Last_Name = txtFatherLastName.Text;
            employee.Mother_Last_Name = txtMotherLastName.Text;
            employee.Date_Of_Birth = new LocalDate(dtpBirthday.Value.Year, dtpBirthday.Value.Month, dtpBirthday.Value.Day);
            employee.RFC = txtRFC.Text;
            employee.CURP = txtCURP.Text;
            employee.User_Name = txtUsername.Text;
            employee.Password = txtPassword.Text;

            dao.Update(employee, originalUsername);

            dgvEmpleados.DataSource = dao.ReadAll();

            ClearForm();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            // Nunca se deberia dar este caso, pero en caso de cualquier error se previene con este if
            if (btnAccept.Enabled == false)
            {
                return;
            }

            dao.Delete(originalID, originalUsername);
            dgvEmpleados.DataSource = dao.ReadAll();

            ClearForm();
        }

        private void dgvEmpleados_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
           

        }

        private void dgvEmpleados_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (dgvPrevIndex == index)
            {
                ClearForm();
                dgvPrevIndex = -1;
                return;
            }
            else
            {
                originalID = (Guid)dgvEmpleados.Rows[index].Cells[0].Value;
                txtNames.Text = dgvEmpleados.Rows[index].Cells[5].Value.ToString();
                txtFatherLastName.Text = dgvEmpleados.Rows[index].Cells[6].Value.ToString();
                txtMotherLastName.Text = dgvEmpleados.Rows[index].Cells[7].Value.ToString();
                dtpBirthday.Value = Convert.ToDateTime(dgvEmpleados.Rows[index].Cells[8].Value.ToString());
                txtRFC.Text = dgvEmpleados.Rows[index].Cells[9].Value.ToString();
                txtCURP.Text = dgvEmpleados.Rows[index].Cells[10].Value.ToString();
                txtUsername.Text = originalUsername = dgvEmpleados.Rows[index].Cells[1].Value.ToString();
                txtPassword.Text = dgvEmpleados.Rows[index].Cells[2].Value.ToString();
                txtConfirmPassword.Text = dgvEmpleados.Rows[index].Cells[2].Value.ToString();
                btnAccept.Enabled = false;
                btnUpdate.Enabled = true;
                btnDelete.Enabled = true;
            }

            dgvPrevIndex = index;
        }

        private void lbDisableEmployees_SelectedIndexChanged(object sender, EventArgs e)
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

        private void btnEnabling_Click(object sender, EventArgs e)
        {
            dao.Enabled(txtDisable.Text, true);
        }

        private void ClearForm()
        {
            txtNames.Clear();
            txtFatherLastName.Clear();
            txtMotherLastName.Clear();
            dtpBirthday.Value = DateTime.Now;
            txtRFC.Clear();
            txtCURP.Clear();
            txtUsername.Clear();
            txtPassword.Clear();
            txtConfirmPassword.Clear();
            btnAccept.Enabled = true;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
            pbWarningIcon.Visible = false;
            lblError.Visible = false;
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

    }
}
