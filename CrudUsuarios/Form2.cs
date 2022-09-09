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
            string Usuario = txtUsuarioLogin.Text.ToString(); //Con esto agarra el texto y los mete en variable
            string Pass = txtPassLogin.Text.ToString(); // Esto agarra la pass y la guarda en variable
            Conexion inst7 = new Conexion(); //Se abre una conexion a la bd

            bool validacion = inst7.ValidarLogin(Usuario, Pass); //Aqui se pasa el metodo a la conexion, y se valida
                                                                 // Aqui se devuelve el VERDADERO o FALSO de la 
                                                                 // conexion.cs ValidarLogin(Usuario, Pass)
            Hide();

            if (validacion == true) { //Si es que la Validacion es VERDADERA, o sea, que se ingresó bien el 
                                     //usuario y la contraseña, entonces se abre el FORM1
                Form1 formHome = new Form1();// Aqui se inicializa el FORM1
                formHome.Show(); // Aqui se muestra el FORM1
            }
            else
            {
                Close(); // Si no, se cierra todo el programa
            }
            
        }
    }
}
