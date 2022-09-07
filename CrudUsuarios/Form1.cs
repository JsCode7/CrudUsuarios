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
            conexion inst1 = new conexion(); //instancia de la clase conexión, llama automaticamente al constructor
            inst1.cargarUsuario(dvUsuario);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            conexion inst2 = new conexion();
            inst2.cargarUsuario(dvUsuario);
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            conexion inst3 = new conexion();
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
            conexion inst4 = new conexion();
            MessageBox.Show(inst4.eliminarUsuario(txtRut.Text));
            inst4.cargarUsuario(dvUsuario); //cargar el grid al momento de eliminar
        }

        private void btnTraer_Click(object sender, EventArgs e)
        {
            conexion inst5 = new conexion();
            MessageBox.Show(inst5.traerUsuario(txtRut.Text));
            
            txtRut.Text = inst5.GetTxtRutConsultado();
            txtNombre.Text = inst5.GetTxtNombreConsultado();
            txtApellido.Text = inst5.GetTxtApellidoConsultado();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            conexion inst6 = new conexion();
            MessageBox.Show(inst6.ModificarUsuario(txtRut.Text, txtNombre.Text, txtApellido.Text));
            inst6.cargarUsuario(dvUsuario); //mostrar el datagrid al updatear
        }
    }
}
