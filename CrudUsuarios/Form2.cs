using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CrudUsuarios
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string Usuario = txtUsuarioLogin.Text.ToString();
            string Pass = txtPassLogin.Text.ToString();
            Conexion inst7 = new Conexion();

            bool validacion = inst7.ValidarLogin(Usuario, Pass);
            Hide();

            if (validacion == true) {
                Form1 formHome = new Form1();
                formHome.Show();
            }
            else
            {
                Close();
            }
            

        }
    }
}
