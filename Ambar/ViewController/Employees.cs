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

namespace Ambar.ViewController
{
    public partial class Employees : Form
    {
        EmployeeDAO dao = new EmployeeDAO();
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
                //MessageBox.Show("Todos los campos son obligatorios", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }   

            if (txtPassword.Text != txtConfirmPassword.Text)
            {
                pbWarningIcon.Visible = true;
                lblError.Visible = true;
                lblError.Text = "VERIFICAR CONTRASEÑA";
                //MessageBox.Show("Verificar contraseña", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            new UserDAO().Create(txtUsername.Text, txtPassword.Text, "Employee");
            Guid userID = new UserDAO().GetUserID(txtUsername.Text);

            EmployeeDTO employee = new EmployeeDTO();
            employee.Name = txtNames.Text;
            employee.Father_Last_Name = txtFatherLastName.Text;
            employee.Mother_Last_Name = txtMotherLastName.Text;
            employee.Date_Of_Brith = dtpBirthday.Value;
            employee.RFC = txtRFC.Text;
            employee.CURP = txtCURP.Text;

            dao.Create(employee, userID);

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
    }
}
