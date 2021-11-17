using Ambar.Model;
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
        string loginIntentsUsername = "";
        uint loginIntentsCount = 0;

        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            WinAPI.SendMessage(txtUsername.Handle, WinAPI.EM_SETCUEBANNER, 0, "USUARIO");
            WinAPI.SendMessage(txtPassword.Handle, WinAPI.EM_SETCUEBANNER, 0, "CONTRASEÑA");
            cbPositions.SelectedIndex = 0;
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            string username = StringUtils.GetText(txtUsername.Text);
            string password = StringUtils.GetText(txtPassword.Text);

            if (username == string.Empty || password == string.Empty)
            {
                PrintErrorLogin("TODOS LOS CAMPOS SON OBLIGATORIOS");
            }
            else
            {
                switch (cbPositions.SelectedItem)
                {
                    case "Administrador":
                    {
                        AdministratorDAO dao = new AdministratorDAO();
                        AdministratorLoginDTO dto = dao.Login(username, password);

                        if (dto == null)
                        {
                            PrintErrorLogin("SUS CREDENCIALES NO COINCIDEN");
                        }
                        else
                        {
                            RememberMe("Administrator", dto);
                            ShowMenu("Administrator", dto.User_name);
                        }

                        break;
                    }
                    case "Empleado":
                    {
                        EmployeeDAO dao = new EmployeeDAO();
                        EmployeeLoginDTO dto = dao.Login(username, password);

                        if (dto == null) // Credenciales incorrectas y/o usuario inexistente
                        {
                            bool exists = dao.EmployeeExists(username);
                            if (exists)
                            {
                                FailedLogin(dao, username);
                            }
                            PrintErrorLogin("SUS CREDENCIALES NO COINCIDEN");
                        }
                        else if (dto.Enabled == false)
                        {
                            PrintErrorLogin("SU USUARIO SE ENCUENTRA BLOQUEADO");
                        }
                        else
                        {
                            RememberMe("Employee", dto);
                            ShowMenu("Employee", dto.User_name);
                        }

                        break;
                    }
                    case "Cliente":
                    {
                        ClientDAO dao = new ClientDAO();
                        ClientLoginDTO dto = dao.Login(username, password);

                        if (dto == null) // Credenciales incorrectas y/o usuario inexistente
                        {
                            bool exists = dao.ClientExists(username);
                            if (exists)
                            {
                                FailedLogin(dao, username);
                            }
                            PrintErrorLogin("SUS CREDENCIALES NO COINCIDEN");
                        }
                        else if (dto.Enabled == false)
                        {
                            PrintErrorLogin("SU USUARIO SE ENCUENTRA BLOQUEADO");
                        }
                        else
                        {
                            RememberMe("Client", dto);
                            ShowMenu("Client", dto.User_name);
                        }
                        break;
                    }
                }
            }
        }

        private void FailedLogin<T>(T dao, string username) where T : IEnableable
        {
            if (loginIntentsUsername != username)
            {
                loginIntentsUsername = username;
                loginIntentsCount = 0;
            }
            else
            {
                loginIntentsCount++;
            }

            if (loginIntentsCount == 2)
            {
                dao.Enabled(loginIntentsUsername, false);
            }
        }

        private void ShowMenu(string position, string username)
        {
            UserCache.position = position;
            UserCache.username = username;
            UserCache.id = userRemember.GetUserID(position, username);
            AmbarMenu menu = new AmbarMenu();
            menu.Show();
            this.Hide();
        }

        private void RememberMe<T>(string position, T dto) where T : LoginDTO
        {
            if (chkRemember.Checked)
            {
                userRemember.RememberPassword(position, dto.User_name, dto.Password);
            }
            else
            {
                userRemember.ForgerPassword(position, dto.User_name);
            }
        }

        void PrintErrorLogin(string error)
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
            if (cbPositions.SelectedIndex == -1) // Evitar que sea -1 en algun momento
            {
                cbPositions.SelectedIndex = 0;
            }

            string position = GetComboboxPosition();
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
                string position = GetComboboxPosition();
                txtPassword.Text = userRemember.ReadPassword(position, txtUsername.Text);
                chkRemember.Checked = true;
                txtPassword.Focus();
            }
        }

        private string GetComboboxPosition()
        {
            switch (cbPositions.SelectedItem)
            {
                case "Administrador":
                {
                    return "Administrator";
                }
                case "Empleado":
                {
                    return "Employee";
                }
                case "Cliente":
                {
                    return "Client";
                }
                default:
                {
                    return null;
                }
            }
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

        private void fadeIn_Tick(object sender, EventArgs e)
        {
            Opacity = Opacity + 0.05f % 1;
        }

        private void btnMinimized_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
