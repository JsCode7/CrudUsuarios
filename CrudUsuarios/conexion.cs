using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;


class conexion
{
    SqlConnection cn; // Variable que nos permite crear la conexion
    SqlCommand cmd; // Variable que nos servirá para poder hacer el crud
                    // SqlDataReader dr; // Variable que usaremos en el update
                    // SqlDataAdapter adaptador; // Variable que usaremos en este proyecto para adaptar al grid
                    // DataSet ds;

    // Constructor, se llama igual que la clase y no retorna valor
    public conexion()
    {
        try
        {
            // Se crea la variable SqlConnection en Proyecto (Nuevo origen de datos)
            cn = new SqlConnection("Data Source=HARU\\SQLEXPRESS;Initial Catalog=bd1;Integrated Security=True");
            cn.Open(); // Se abre la conexión
            MessageBox.Show("Conexion Exitosa");
        }
        catch (Exception ex)
        {
            //En caso de que no se realice la conexión, se muestra un mensaje.
            MessageBox.Show("No se conectó a la base de datos" + ex.ToString());
        }
    }

    public string insertarUsuario(string Rut, string Nombre, string Apellido)
    {
        string salida = "Se registró el usuario exitosamente";
        try
        {
            cmd = new SqlCommand("Insert into usuarios(rut, nombre, apellido) values ('" + Rut.ToString() + "','" + Nombre + "','" + Apellido + "')", cn);
            cmd.ExecuteNonQuery(); //Sentencia que ejecuta el comando
        }
        catch (Exception ex)
        {
            salida = ("No se insertó: " + ex.ToString());
        }

        return salida;
    }

}
