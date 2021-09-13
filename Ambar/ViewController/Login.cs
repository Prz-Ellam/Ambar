using Ambar.Model;
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

namespace Ambar.ViewController
{
    public partial class Login : Form
    {
        private const int EM_SETCUEBANNER = 0x1501;
        private const int WM_SYSCOMMAND = 0x112;

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern Int32 SendMessage(IntPtr hWnd, int msg, int wParam, [MarshalAs(UnmanagedType.LPWStr)]string lParam);

        [DllImport("user32.dll", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.dll", EntryPoint = "SendMessage")]
        private extern static void SendMessage(IntPtr hWnd, int msg, int wParam, int lParam);

        public Login()
        {
            InitializeComponent();
            SendMessage(txtUsername.Handle, EM_SETCUEBANNER, 0, "USUARIO");
            SendMessage(txtPassword.Handle, EM_SETCUEBANNER, 0, "CONTRASEÑA");

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMinimized_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Login_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, WM_SYSCOMMAND, 0xf012, 0);
        }

        private void gradientPanel_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, WM_SYSCOMMAND, 0xf012, 0);
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            // Logica para verificar usuario
            AmbarMenu menu = new AmbarMenu();
            menu.Show();
            this.Hide();
        }

        private void gradientPanel1_MouseDown(object sender, MouseEventArgs e)
        {

        }
    }
}
