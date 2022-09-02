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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            conexion inst1 = new conexion();
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            conexion inst2 = new conexion();
            MessageBox.Show(inst2.insertarUsuario(txtRut.Text, txtNombre.Text, txtApellido.Text));
        }
    }
}
