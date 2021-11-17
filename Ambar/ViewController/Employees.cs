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
using Ambar.Common;
using Cassandra;
using Ambar.Model.AmbarMapper;

namespace Ambar.ViewController
{
    public partial class Employees : Form
    {
        // DAO para hacer queries a la entidad empleados
        EmployeeDAO employeeDAO = new EmployeeDAO();
        UserRememberDAO userRemember = new UserRememberDAO();
        /* 
           Guardamos el username y el ID original de un empleado al que se le este aplicando una edicion o borrado para 
           tener una referencia de los datos originales
        */
        string originalUsername; 
        Guid originalID;

        // Indices seleccionados del combobox y el data grid view
        int dtgPrevIndex = -1;
        int lbPrevIndex = -1;

        public Employees()
        {
            InitializeComponent();
        }

        private void Empleados_Load(object sender, EventArgs e)
        {
            FillDataGridView();
            FillDisableUsers();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (btnUpdate.Enabled || btnDelete.Enabled) // Por seguridad
            {
                MessageBox.Show("Error inesperado", "Ambar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            EmployeeForm employee = FillEmployee(Operations.Create);
            if (!Validate(employee, Operations.Create))
            {
                return;
            }

            EmployeeDTO employeeDTO = EmployeeMapper.CreateDTO(employee);
            employeeDAO.Create(employeeDTO);

            string action = "[Empleado] Fue creado: " + employee.Username + ", con ID: " + employee.ID;
            userRemember.Action(UserCache.id, action);

            FillDataGridView();
            ClearForm();
            MessageBox.Show("La operación se realizó exitosamente", "Ambar", MessageBoxButtons.OK);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (btnAccept.Enabled)
            {
                return;
            }

            EmployeeForm employee = FillEmployee(Operations.Update);
            if (!Validate(employee, Operations.Update)) 
            {
                return;
            }

            EmployeeDTO employeeDTO = EmployeeMapper.CreateDTO(employee);
            employeeDAO.Update(employeeDTO, originalUsername);
            if (userRemember.RememberUserExists("Employee", originalUsername)) {
                userRemember.UpdateRememberUser("Employee", originalUsername, employee.Username, employee.Password);
            }

            string action = "[Empleado] Fue modificado: " + originalUsername + ", por " + employee.Username + ", con ID: " + employee.ID;
            userRemember.Action(UserCache.id, action);

            FillDataGridView();
            FillDisableUsers();
            ClearForm();
            MessageBox.Show("La operación se realizó exitosamente", "Ambar", MessageBoxButtons.OK);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (btnAccept.Enabled)
            {
                return;
            }

            DialogResult res = MessageBox.Show("¿Está seguro que desea realizar esta acción?", "Advertencia", 
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (res == DialogResult.Yes)
            {
                employeeDAO.Delete(originalID, originalUsername);
                if (userRemember.RememberUserExists("Employee", originalUsername))
                {
                    userRemember.ForgerPassword("Employee", originalUsername);
                }

                string action = "[Empleado] Fue eliminado: " + originalUsername + ", con ID: " + originalID;
                userRemember.Action(UserCache.id, action);

                FillDataGridView();
                FillDisableUsers();
                ClearForm();
                MessageBox.Show("La operación se realizó exitosamente", "Ambar", MessageBoxButtons.OK);
            }
        }

        private void btnEnabling_Click(object sender, EventArgs e)
        {
            employeeDAO.Enabled(txtDisable.Text, true);
            ClearDisableUsers();
            FillDisableUsers();
            MessageBox.Show("La operación se realizó exitosamente", "Ambar", MessageBoxButtons.OK);
        }

        private EmployeeForm FillEmployee(Operations operationCode)
        {
            EmployeeForm employee = new EmployeeForm();
            employee.ID = (operationCode == Operations.Update) ? originalID : Guid.NewGuid();
            employee.FirstName = StringUtils.GetText(txtFirstName.Text);
            employee.FatherLastName = StringUtils.GetText(txtFatherLastName.Text);
            employee.MotherLastName = StringUtils.GetText(txtMotherLastName.Text);
            employee.DateOfBirth = dtpDateOfBirth.Value;
            employee.RFC = StringUtils.GetText(txtRFC.Text);
            employee.CURP = StringUtils.GetText(txtCURP.Text);
            employee.Username = StringUtils.GetText(txtUsername.Text);
            employee.Password = StringUtils.GetText(txtPassword.Text);
            employee.ConfirmPassword = StringUtils.GetText(txtConfirmPassword.Text);
            return employee;
        }

        private bool Validate(EmployeeForm employee, Operations operationCode)
        {
            if (employee.FirstName == string.Empty || employee.FatherLastName == string.Empty ||
                employee.MotherLastName == string.Empty || employee.RFC == string.Empty ||
                employee.CURP == string.Empty || employee.Username == string.Empty ||
                employee.Password == string.Empty || employee.ConfirmPassword == string.Empty)
            {
                MessageBox.Show("Todos los campos son obligatorios", "Ambar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (employee.Password != employee.ConfirmPassword)
            {
                MessageBox.Show("Verificar contraseña", "Ambar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (employee.DateOfBirth > DateTime.Now)
            {
                MessageBox.Show("Fecha de nacimiento no valida", "Ambar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (!RegexUtils.VerifyCURP(employee.CURP))
            {
                MessageBox.Show("Verificar CURP", "Ambar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (!RegexUtils.VerifyRFC(employee.RFC))
            {
                MessageBox.Show("Verificar RFC", "Ambar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // No se permite agregar usernames ya existentes, a menos que se quiera sobreescribir el que ya se tenia
            // originalmente
            bool userExists = employeeDAO.UserExists(employee.Username);
            if (userExists && operationCode != Operations.Update || userExists && originalUsername != employee.Username)
            {
                MessageBox.Show("El nombre de usuario ya existe", "Ambar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        public void ClearForm()
        {
            txtFirstName.Clear();
            txtFatherLastName.Clear();
            txtMotherLastName.Clear();
            dtpDateOfBirth.Value = DateTime.Now;
            txtRFC.Clear();
            txtCURP.Clear();
            txtUsername.Clear();
            txtPassword.Clear();
            txtConfirmPassword.Clear();
            btnAccept.Enabled = true;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
            txtFirstName.Focus();
            dtgPrevIndex = -1;
        }

        public void FillDataGridView()
        {
            List<EmployeeDTO> employees = employeeDAO.ReadAll();
            List<EmployeeDTG> dtgEmployeesList = new List<EmployeeDTG>();
            foreach (var employee in employees)
            {
                dtgEmployeesList.Add(new EmployeeDTG(employee));
            }
            dtgEmployees.DataSource = dtgEmployeesList;
        }

        private void dtgEmployees_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (dtgPrevIndex == index || index == -1)
            {
                ClearForm();
            }
            else
            {
                var row = dtgEmployees.Rows[index];
                originalID = Guid.Parse(row.Cells[0].Value.ToString());
                txtUsername.Text = row.Cells[1].Value.ToString();
                originalUsername = row.Cells[1].Value.ToString();
                txtPassword.Text = row.Cells[2].Value.ToString();
                txtConfirmPassword.Text = row.Cells[2].Value.ToString();
                txtFirstName.Text = row.Cells[3].Value.ToString();
                txtFatherLastName.Text = row.Cells[4].Value.ToString();
                txtMotherLastName.Text = row.Cells[5].Value.ToString();
                dtpDateOfBirth.Value = Convert.ToDateTime(row.Cells[6].Value.ToString());
                txtRFC.Text = row.Cells[7].Value.ToString();
                txtCURP.Text = row.Cells[8].Value.ToString();

                btnAccept.Enabled = false;
                btnUpdate.Enabled = true;
                btnDelete.Enabled = true;

                dtgPrevIndex = index;
            }
        }

        public void ClearDisableUsers()
        {
            txtDisable.Clear();
            btnEnabling.Enabled = false;
            lbDisableEmployees.ClearSelected();
            lbPrevIndex = -1;
        }

        public void FillDisableUsers()
        {
            lbDisableEmployees.DataSource = employeeDAO.ReadAllDisable();
            lbDisableEmployees.ClearSelected();
        }

        private void lbDisableEmployees_Click(object sender, EventArgs e)
        {
            if (lbDisableEmployees.SelectedIndex == lbPrevIndex)
            {
                ClearDisableUsers();
            }
            else
            {
                txtDisable.Text = lbDisableEmployees.SelectedItem.ToString();
                btnEnabling.Enabled = true;
                lbPrevIndex = lbDisableEmployees.SelectedIndex;
            }
        }

    }
}