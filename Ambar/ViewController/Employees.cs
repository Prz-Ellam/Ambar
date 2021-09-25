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
        EmployeeDAO dao = new EmployeeDAO();
        UserDAO userDAO = new UserDAO();
        public Employees()
        {
            InitializeComponent();
            dgvEmpleados.DataSource = dao.ReadAll();
            //SendMessage(txtNames.Handle, EM_SETCUEBANNER, 0, "NAME(S)");
            //SendMessage(txtFatherLastName.Handle, EM_SETCUEBANNER, 0, "FATHER LAST NAME");
            //SendMessage(txtMotherLastName.Handle, EM_SETCUEBANNER, 0, "MOTHER LAST NAME");
            //SendMessage(txtRFC.Handle, EM_SETCUEBANNER, 0, "RFC");
            //SendMessage(txtCURP.Handle, EM_SETCUEBANNER, 0, "CURP");
            //SendMessage(txtUsername.Handle, EM_SETCUEBANNER, 0, "USERNAME");
            //SendMessage(txtPassword.Handle, EM_SETCUEBANNER, 0, "PASSWORD");
        }

        private void Empleados_Load(object sender, EventArgs e)
        {

        }

        private void btnAccept_Click(object sender, EventArgs e)
        {

            if (txtNames.Text == "" || txtFatherLastName.Text == "" || txtMotherLastName.Text == "" || txtRFC.Text == ""
                || txtCURP.Text == "" || txtUsername.Text == "" || txtPassword.Text == "" || txtConfirmPassword.Text == "")
            {
                pbWarningIcon.Visible = true;
                lblError.Visible = true;
                lblError.Text = "TODOS LOS CAMPOS SON OBLIGATORIOS";
                return;
            }   

            if (txtPassword.Text != txtConfirmPassword.Text)
            {
                pbWarningIcon.Visible = true;
                lblError.Visible = true;
                lblError.Text = "VERIFICAR CONTRASEÑA";
                return;
            }

            string res = @"^([A-Z][AEIOUX][A-Z]{2}\d{2}(?:0[1-9]|1[0-2])(?:0[1-9]|[12]\d|3[01])[HM](?:AS|B[CS]|C[CLMSH]|D[FG]|G[TR]|HG|JC|M[CNS]|N[ETL]|OC|PL|Q[TR]|S[PLR]|T[CSL]|VZ|YN|ZS)[B-DF-HJ-NP-TV-Z]{3}[A-Z\d])(\d)$";
            Regex rx = new Regex(res, RegexOptions.Compiled | RegexOptions.IgnoreCase);

            if (!rx.IsMatch(txtCURP.Text))
            {
                pbWarningIcon.Visible = true;
                lblError.Visible = true;
                lblError.Text = "VERIFICAR CURP";
                return;
            }

            userDAO.Create(txtUsername.Text, txtPassword.Text, "Employee");

            EmployeeDTO employee = new EmployeeDTO();
            employee.User_ID = userDAO.GetUserID(txtUsername.Text);
            employee.First_Name = txtNames.Text;
            employee.Father_Last_Name = txtFatherLastName.Text;
            employee.Mother_Last_Name = txtMotherLastName.Text;
            employee.Date_Of_Birth = new LocalDate(dtpBirthday.Value.Year, dtpBirthday.Value.Month, dtpBirthday.Value.Day);
            employee.RFC = txtRFC.Text;
            employee.CURP = txtCURP.Text;

            dao.Create(employee);
            dgvEmpleados.DataSource = dao.ReadAll();

            txtNames.Clear();
            txtFatherLastName.Clear();
            txtMotherLastName.Clear();
            txtRFC.Clear();
            txtCURP.Clear();
            txtUsername.Clear();
            txtPassword.Clear();
            txtConfirmPassword.Clear();
            dtpBirthday.Value = DateTime.Now;
        }


        private void btnDelete_Click(object sender, EventArgs e)
        {
            // QUERY PARA ELIMINAR UN EMPLEADO
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            // QUERY PARA ACTUALIZAR UN EMPLEADO
        }

        private void dgvEmpleados_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txtNames.Text = dgvEmpleados.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtFatherLastName.Text = dgvEmpleados.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtMotherLastName.Text = dgvEmpleados.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtRFC.Text = dgvEmpleados.Rows[e.RowIndex].Cells[5].Value.ToString();
            txtCURP.Text = dgvEmpleados.Rows[e.RowIndex].Cells[6].Value.ToString();

            UserDTO dto = userDAO.Read((Guid)dgvEmpleados.Rows[e.RowIndex].Cells[0].Value);
            txtUsername.Text = dto.User_Name;
            txtPassword.Text = txtConfirmPassword.Text = dto.Password;

        }

    }
}
