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

namespace Ambar.ViewController
{
    public partial class Employees : Form, IAmbarForm
    {
        // DAO para hacer queries a la entidad empleados
        EmployeeDAO EmployeeDao = new EmployeeDAO();
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
            if (btnUpdate.Enabled || btnDelete.Enabled)
            {
                return;
            }

            // Creamos un objeto de transferencia de datos para la entidad empleado y lo rellenamos
            EmployeeDTO employee = new EmployeeDTO();
            employee.User_ID = Guid.NewGuid();
            employee.First_Name = StringUtils.GetText(txtNames);
            employee.Father_Last_Name = StringUtils.GetText(txtFatherLastName);
            employee.Mother_Last_Name = StringUtils.GetText(txtMotherLastName);
            employee.Date_Of_Birth = new LocalDate(dtpBirthday.Value.Year, dtpBirthday.Value.Month, dtpBirthday.Value.Day);
            employee.RFC = StringUtils.GetText(txtRFC);
            employee.CURP = StringUtils.GetText(txtCURP);
            employee.User_Name = StringUtils.GetText(txtUsername);
            employee.Password = StringUtils.GetText(txtPassword);
            string confirmPassword = StringUtils.GetText(txtConfirmPassword);

            // Se realizan las validaciones necesarias
            if (employee.First_Name == string.Empty || employee.Father_Last_Name == string.Empty ||
                employee.Mother_Last_Name == string.Empty || employee.RFC == string.Empty ||
                employee.CURP == string.Empty || employee.User_Name == string.Empty ||
                employee.Password == string.Empty || confirmPassword == string.Empty)
            {
                PrintError("TODOS LOS CAMPOS SON OBLIGATORIOS");
                return;
            }

            if (employee.Password != confirmPassword)
            {
                PrintError("VERIFICAR CONTRASEÑA");
                return;
            }

            if (!RegexUtils.VerifyCURP(employee.CURP))
            {
                PrintError("VERIFICAR CURP");
                return;
            }

            if (!RegexUtils.VerifyRFC(employee.RFC))
            {
                PrintError("VERIFICAR RFC");
                return;
            }

            if (EmployeeDao.UserExists(employee.User_Name))
            {
                PrintError("EL NOMBRE DE USUARIO YA EXISTE");
                return;
            }

            // Se crea en la base de datos
            EmployeeDao.Create(employee);

            FillDataGridView();

            ClearForm();
            MessageBox.Show("La operación se realizó exitosamente", "", MessageBoxButtons.OK);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            // Nunca se deberia dar este caso, pero en caso de cualquier error se previene con este if
            if (btnAccept.Enabled)
            {
                return;
            }

            EmployeeDTO employee = new EmployeeDTO();
            employee.User_ID = originalID;
            employee.First_Name = StringUtils.GetText(txtNames);
            employee.Father_Last_Name = StringUtils.GetText(txtFatherLastName);
            employee.Mother_Last_Name = StringUtils.GetText(txtMotherLastName);
            employee.Date_Of_Birth = new LocalDate(dtpBirthday.Value.Year, dtpBirthday.Value.Month, dtpBirthday.Value.Day);
            employee.RFC = StringUtils.GetText(txtRFC);
            employee.CURP = StringUtils.GetText(txtCURP);
            employee.User_Name = StringUtils.GetText(txtUsername);
            employee.Password = StringUtils.GetText(txtPassword);
            string confirmPassword = StringUtils.GetText(txtConfirmPassword);

            if (employee.First_Name == string.Empty || employee.Father_Last_Name == string.Empty ||
                employee.Mother_Last_Name == string.Empty || employee.RFC == string.Empty ||
                employee.CURP == string.Empty || employee.User_Name == string.Empty ||
                employee.Password == string.Empty || confirmPassword == string.Empty)
            {
                PrintError("TODOS LOS CAMPOS SON OBLIGATORIOS");
                return;
            }

            if (employee.Password != confirmPassword)
            {
                PrintError("VERIFICAR CONTRASEÑA");
                return;
            }

            if (!RegexUtils.VerifyCURP(employee.CURP))
            {
                PrintError("VERIFICAR CURP");
                return;
            }

            if (!RegexUtils.VerifyRFC(employee.RFC))
            {
                PrintError("VERIFICAR RFC");
                return;
            }

            if (EmployeeDao.UserExists(employee.User_Name) && originalUsername != employee.User_Name)
            {
                PrintError("EL NOMBRE DE USUARIO YA EXISTE");
                return;
            }

            EmployeeDao.Update(employee, originalUsername);
            if (userRemember.RememberUserExists("Employee", originalUsername)) {
                userRemember.UpdateRememberUser("Employee", originalUsername, employee.User_Name, employee.Password);
            }

            FillDataGridView();
            FillDisableUsers();

            ClearForm();
            MessageBox.Show("La operación se realizó exitosamente", "", MessageBoxButtons.OK);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            // Nunca se deberia dar este caso, pero en caso de cualquier error se previene con este if
            if (btnAccept.Enabled)
            {
                return;
            }

            DialogResult res = MessageBox.Show("¿Está seguro que desea realizar esta acción?", "ADVERTENCIA", 
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (res == DialogResult.Yes)
            {
                EmployeeDao.Delete(originalID, originalUsername);
                if (userRemember.RememberUserExists("Employee", originalUsername))
                {
                    userRemember.ForgerPassword("Employee", originalUsername);
                }

                FillDataGridView();
                FillDisableUsers();

                ClearForm();
                MessageBox.Show("La operación se realizó exitosamente", "", MessageBoxButtons.OK);
            }
        }

        public void ClearForm()
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
        public void FillDataGridView()
        {
            List<EmployeeDTO> employees = EmployeeDao.Read();
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
            if (dtgPrevIndex == index)
            {
                ClearForm();
                dtgPrevIndex = -1;
            }
            else
            {
                originalID = (Guid)dtgEmployees.Rows[index].Cells[0].Value;
                txtUsername.Text = dtgEmployees.Rows[index].Cells[1].Value.ToString();
                originalUsername = dtgEmployees.Rows[index].Cells[1].Value.ToString();
                txtPassword.Text = dtgEmployees.Rows[index].Cells[2].Value.ToString();
                txtConfirmPassword.Text = dtgEmployees.Rows[index].Cells[2].Value.ToString();
                txtNames.Text = dtgEmployees.Rows[index].Cells[3].Value.ToString();
                txtFatherLastName.Text = dtgEmployees.Rows[index].Cells[4].Value.ToString();
                txtMotherLastName.Text = dtgEmployees.Rows[index].Cells[5].Value.ToString();
                dtpBirthday.Value = Convert.ToDateTime(dtgEmployees.Rows[index].Cells[6].Value.ToString());
                txtRFC.Text = dtgEmployees.Rows[index].Cells[7].Value.ToString();
                txtCURP.Text = dtgEmployees.Rows[index].Cells[8].Value.ToString();

                btnAccept.Enabled = false;
                btnUpdate.Enabled = true;
                btnDelete.Enabled = true;
                pbWarningIcon.Visible = false;
                lblError.Visible = false;

                dtgPrevIndex = index;

            }
        }

        public void ClearDisableUsers()
        {
            txtDisable.Clear();
            btnEnabling.Enabled = false;
            lbPrevIndex = -1;
            lbDisableEmployees.ClearSelected();
        }

        public void FillDisableUsers()
        {
            lbDisableEmployees.Items.Clear();
            List<string> names = EmployeeDao.ReadAllDisable();
            foreach (var name in names)
            {
                lbDisableEmployees.Items.Add(name);
            }
        }

        private void lbDisableEmployees_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbPrevIndex == lbDisableEmployees.SelectedIndex)
            {
                ClearDisableUsers();
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
            EmployeeDao.Enabled(txtDisable.Text, true);

            ClearDisableUsers();

            FillDisableUsers();
        }

        public void PrintError(string error)
        {
            pbWarningIcon.Visible = true;
            lblError.Visible = true;
            lblError.Text = error;
        }
    }
}