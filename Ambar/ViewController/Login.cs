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

        UserDAO user = new UserDAO();
        (string, uint) loginIntents = ("", 0);

        public Login()
        {
            InitializeComponent();
            WinAPI.SendMessage(txtUsername.Handle, WinAPI.EM_SETCUEBANNER, 0, "USUARIO");
            WinAPI.SendMessage(txtPassword.Handle, WinAPI.EM_SETCUEBANNER, 0, "CONTRASEÑA");
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text == "" || txtPassword.Text == "")
            {
                printErrorLogin("TODOS LOS CAMPOS SON OBLIGATORIOS");
            }
            else
            {
                UserDTO userInfo = user.Login(txtUsername.Text, txtPassword.Text);
                bool userExists = user.Exists(txtUsername.Text);

                if (userInfo == null)
                {
                    if (loginIntents.Item1 == txtUsername.Text)
                    {
                        loginIntents.Item2++;
                    }
                    else if (userExists && txtUsername.Text != ConfigurationManager.AppSettings["admin"].ToString())
                    {
                        loginIntents.Item1 = txtUsername.Text;
                        loginIntents.Item2 = 0;
                    }

                    if (loginIntents.Item2 == 2)
                    {
                        user.SetEnabled(loginIntents.Item1, false);
                    }

                    printErrorLogin("SUS CREDENCIALES NO COINCIDEN");
                }
                else if (userInfo.Enabled)
                {
                    printErrorLogin("SU USUARIO SE ENCUENTRA BLOQUEADO");
                }
                else
                {
                    user.RememberUser(txtUsername.Text, txtPassword.Text, chkRemember.Checked);
                    UserCache.position = userInfo.Position;
                    UserCache.username = userInfo.User_Name;
                    AmbarMenu menu = new AmbarMenu();
                    menu.Show();
                    this.Hide();
                }

            }

        }

        private void txtUsername_Leave(object sender, EventArgs e)
        {
            (string, bool) values = user.ReadPassword(txtUsername.Text);
            txtPassword.Text = values.Item1;
            chkRemember.Checked = values.Item2;
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
            pbWarningIcon.Visible = true;
            lblError.Text = error;
            lblError.Visible = true;
            txtUsername.Clear();
            txtPassword.Clear();
            txtUsername.Focus();
        }

    }
}
