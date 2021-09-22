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

namespace Ambar.ViewController
{
    public partial class Login : Form
    {

        UserDAO user = UserDAO.GetInstance();
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
                pbWarningIcon.Visible = true;
                lblError.Text = "TODOS LOS CAMPOS SON OBLIGATORIOS";
                lblError.Visible = true;
                return;
            }
            else
            {
                bool userExist = user.Login(txtUsername.Text, txtPassword.Text);

                if (userExist)
                {
                    user.rememberUser(txtUsername.Text, chkRemember.Checked);
                    AmbarMenu menu = new AmbarMenu();
                    menu.Show();
                    this.Hide();
                }
                else
                {
                    pbWarningIcon.Visible = true;
                    lblError.Text = "SUS CREDENCIALES NO COINCIDEN";
                    lblError.Visible = true;
                    txtUsername.Clear();
                    txtPassword.Clear();
                    txtUsername.Focus();
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

        private void btnMinimized_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txtUsername_Leave(object sender, EventArgs e)
        {
            txtPassword.Text = user.readPassword(txtUsername.Text);
        }
    }
}
