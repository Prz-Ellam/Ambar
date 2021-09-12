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
    public partial class Empleados : Form
    {
        private const int EM_SETCUEBANNER = 0x1501;
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern Int32 SendMessage(IntPtr hWnd, int msg, int wParam, [MarshalAs(UnmanagedType.LPWStr)] string lParam);
        public Empleados()
        {
            InitializeComponent();
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
    }
}
