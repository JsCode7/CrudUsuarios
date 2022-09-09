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

        private void cargaDatosAutomatica(object sender, EventArgs e)
        {
            Conexion inst1 = new Conexion(); //instancia de la clase conexión, llama automaticamente al constructor
            inst1.cargarUsuario(dvUsuario);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Conexion inst2 = new Conexion();
            inst2.cargarUsuario(dvUsuario);
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            Conexion inst3 = new Conexion();
            MessageBox.Show(inst3.insertarUsuario(txtRut.Text, txtNombre.Text, txtApellido.Text));
            inst3.cargarUsuario(dvUsuario); //mostrar el datagrid al insertar
        }

        void limpiar()
        {
            txtRut.Text = "";
            txtNombre.Text = "";
            txtApellido.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void dvUsuario_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtRut_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Conexion inst4 = new Conexion();
            MessageBox.Show(inst4.eliminarUsuario(txtRut.Text));
            inst4.cargarUsuario(dvUsuario); //cargar el grid al momento de eliminar
        }

        private void btnTraer_Click(object sender, EventArgs e)
        {
            Conexion inst5 = new Conexion();
            MessageBox.Show(inst5.traerUsuario(txtRut.Text));
            
            txtRut.Text = inst5.GetTxtRutConsultado();
            txtNombre.Text = inst5.GetTxtNombreConsultado();
            txtApellido.Text = inst5.GetTxtApellidoConsultado();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            Conexion inst6 = new Conexion();
            MessageBox.Show(inst6.ModificarUsuario(txtRut.Text, txtNombre.Text, txtApellido.Text));
            inst6.cargarUsuario(dvUsuario); //mostrar el datagrid al updatear
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
