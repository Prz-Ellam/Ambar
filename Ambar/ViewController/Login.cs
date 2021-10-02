﻿using Ambar.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ambar.Model.DAO;
using Ambar.Model.DTO;
using System.Configuration;
using Ambar.Common;

namespace Ambar.ViewController
{
    public partial class Login : Form
    {
        UserRememberDAO userRemember = new UserRememberDAO();
        (string, uint) loginIntents = ("", 0);

        public Login()
        {
            InitializeComponent();
            WinAPI.SendMessage(txtUsername.Handle, WinAPI.EM_SETCUEBANNER, 0, "USUARIO");
            WinAPI.SendMessage(txtPassword.Handle, WinAPI.EM_SETCUEBANNER, 0, "CONTRASEÑA");

            cbPositions.SelectedIndex = 0;
            AutoCompleteStringCollection allowedTypes = new AutoCompleteStringCollection();
            allowedTypes.AddRange(userRemember.GetRememberUsers("Administrator").ToArray());
            txtUsername.AutoCompleteCustomSource = allowedTypes;
            txtUsername.AutoCompleteMode = AutoCompleteMode.Suggest;
            txtUsername.AutoCompleteSource = AutoCompleteSource.CustomSource;

        }

        private void btnAccept_Click(object sender, EventArgs e)
        {

            if (txtUsername.Text == "" || txtPassword.Text == "")
            {
                printErrorLogin("TODOS LOS CAMPOS SON OBLIGATORIOS");
            }
            else
            {
                switch (cbPositions.SelectedItem)
                {
                    case "Administrador":
                    {
                        AdministratorDAO dao = new AdministratorDAO();
                        AdministratorDTO dto = dao.Login(txtUsername.Text, txtPassword.Text);

                        if (dto == null)
                        {
                            printErrorLogin("SUS CREDENCIALES NO COINCIDEN");
                        }
                        else
                        {
                            RememberMe("Administrator");
                            ShowMenu("Administrator", dto.User_Name);
                        }

                        break;
                    }
                    case "Empleado":
                    {
                        EmployeeDAO dao = new EmployeeDAO();
                        EmployeeLoginDTO dto;
                        bool exists;
                        (dto, exists) = dao.Login(txtUsername.Text, txtPassword.Text);

                        if (dto == null && exists == false) // Credenciales incorrectas e usuario inexistente
                        {
                            printErrorLogin("SUS CREDENCIALES NO COINCIDEN");
                        }
                        else if (dto == null && exists == true)
                        {
                            FailedLogin();

                            if (loginIntents.Item2 == 2)
                            {
                                dao.Enabled(loginIntents.Item1, false);
                            }
                            printErrorLogin("SUS CREDENCIALES NO COINCIDEN");
                        }
                        else if (dto.Enabled == false)
                        {
                            printErrorLogin("SU USUARIO SE ENCUENTRA BLOQUEADO");
                        }
                        else
                        {
                            RememberMe("Employee");
                            ShowMenu("Employee", dto.User_name);
                        }

                        break;
                    }
                    case "Cliente":
                    {
                        ClientDAO dao = new ClientDAO();
                        ClientLoginDTO dto;
                        bool exists;
                        (dto, exists) = dao.Login(txtUsername.Text, txtPassword.Text);

                        if (dto == null && exists == false) // Credenciales incorrectas e usuario inexistente
                        {
                            printErrorLogin("SUS CREDENCIALES NO COINCIDEN");
                        }
                        else if (dto == null && exists == true)
                        {
                            FailedLogin();

                            if (loginIntents.Item2 == 2)
                            {
                                dao.Enabled(loginIntents.Item1, false);
                            }
                            printErrorLogin("SUS CREDENCIALES NO COINCIDEN");
                        }
                        else if (dto.Enabled == false)
                        {
                            printErrorLogin("SU USUARIO SE ENCUENTRA BLOQUEADO");
                        }
                        else
                        {
                            RememberMe("Client");
                            ShowMenu("Client", dto.User_name);
                        }
                        break;
                    }
                    default:
                    {
                        return;
                    }
                }
            }

        }

        private void FailedLogin()
        {
            if (loginIntents.Item1 != txtUsername.Text)
            {
                loginIntents.Item1 = txtUsername.Text;
                loginIntents.Item2 = 0;
            }
            else
            {
                loginIntents.Item2++;
            }
        }
        private void ShowMenu(string position, string username)
        {
            UserCache.position = position;
            UserCache.username = username;
            AmbarMenu menu = new AmbarMenu();
            menu.Show();
            this.Hide();
        }

        private void RememberMe(string position)
        {
            if (chkRemember.Checked)
            {
                userRemember.RememberPassword(position, txtUsername.Text, txtPassword.Text);
            }
            else
            {
                userRemember.ForgerPassword(position, txtUsername.Text);
            }
        }

        private void txtUsername_Leave(object sender, EventArgs e)
        {
        }

        private void Login_MouseDown(object sender, MouseEventArgs e)
        {
            WinAPI.ReleaseCapture();
            WinAPI.SendMessage(this.Handle, WinAPI.WM_SYSCOMMAND, 0xf012, 0);
        }

        private void gradientPanel_MouseDown(object sender, MouseEventArgs e)
        {
            WinAPI.ReleaseCapture();
            WinAPI.SendMessage(this.Handle, WinAPI.WM_SYSCOMMAND, 0xf012, 0);
        }

        private void btnMinimized_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        void printErrorLogin(string error)
        {
            chkRemember.Checked = false;
            pbWarningIcon.Visible = true;
            lblError.Text = error;
            lblError.Visible = true;
            txtUsername.Clear();
            txtPassword.Clear();
            txtUsername.Focus();
        }

        private void cbPositions_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cbPositions.SelectedIndex == -1)
            {
                cbPositions.SelectedIndex = 0;
            }

            string position;
            switch (cbPositions.SelectedItem)
            {
                case "Administrador":
                {
                    position = "Administrator";
                    break;
                }
                case "Empleado":
                {
                    position = "Employee";
                    break;
                }
                case "Cliente":
                {
                    position = "Client";
                    break;
                }
                default:
                {
                    position = null;
                    break;
                }
            }

            AutoCompleteStringCollection allowedTypes = new AutoCompleteStringCollection();
            allowedTypes.AddRange(userRemember.GetRememberUsers(position).ToArray());
            txtUsername.AutoCompleteCustomSource = allowedTypes;
            txtUsername.AutoCompleteMode = AutoCompleteMode.Suggest;
            txtUsername.AutoCompleteSource = AutoCompleteSource.CustomSource;
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {
            if (txtUsername.AutoCompleteCustomSource.Contains(txtUsername.Text))
            {
                string position;
                switch (cbPositions.SelectedItem)
                {
                    case "Administrador":
                    {
                        position = "Administrator";
                        break;
                    }
                    case "Empleado":
                    {
                        position = "Employee";
                        break;
                    }
                    case "Cliente":
                    {
                        position = "Client";
                        break;
                    }
                    default:
                    {
                        position = null;
                        break;
                    }
                }

                txtPassword.Text = userRemember.ReadPassword(position, txtUsername.Text);
                chkRemember.Checked = true;
                txtPassword.Focus();
            }
        }
    }
}
