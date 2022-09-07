using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;


class conexion
{
    SqlConnection cn; // Variable que nos permite crear la conexion
    SqlCommand cmd; // Variable que nos servirá para poder hacer el crud
    SqlDataReader dr; // Variable que usaremos en el update
    SqlDataAdapter adaptador; // Variable que usaremos en este proyecto para adaptar al grid
    DataSet ds;

    // Constructor, se llama igual que la clase y no retorna valor
    public conexion()
    {
        try
        {
            // Se crea la variable SqlConnection en Proyecto (Nuevo origen de datos)
            cn = new SqlConnection("Data Source=HARU\\SQLEXPRESS;Initial Catalog=bd1;Integrated Security=True");
            cn.Open(); // Se abre la conexión
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

    public void cargarUsuario(DataGridView tabla) //Nombre datagrid
    {
        try
        {
            adaptador = new SqlDataAdapter("Select * from usuarios", cn);
            ds = new DataSet();
            adaptador.Fill(ds, "usuarios");
            tabla.DataSource = ds.Tables["usuarios"];
        }
        catch (Exception ex)
        {
            MessageBox.Show("No se consulto la información: " + ex.ToString());
        }

    }

    //Sobrecarga de parametros, metodo creado para buscar rut dentro del datagrid
    public void cargarUsuario(DataGridView tabla, string rut) //Nombre datagrid
    {
        try
        {
            adaptador = new SqlDataAdapter("Select * from usuarios where rut like '" + "%" + rut + "%" + "'", cn); //busqueda total
            ds = new DataSet();
            adaptador.Fill(ds, "usuarios");
            tabla.DataSource = ds.Tables["usuarios"];
        }
        catch (Exception ex)
        {
            MessageBox.Show("No se consulto la información: " + ex.ToString());
        }

    }

    public string eliminarUsuario(string rut)
    {
        string salida = "Se eliminó correctamente el RUT: " + rut;
        try
        {
            cmd = new SqlCommand("Delete from usuarios where RUT='" + rut + "'", cn);
            cmd.ExecuteNonQuery(); //ejecutar la sentencia
        }
        catch (Exception ex)
        {
            salida = "No se Eliminó el Registro: " + ex.ToString();
        }
        return salida;
    }

    public string traerUsuario(string Rut)
    {
        string salida = "Se trajo el usuario exitosamente";
        try
        {
            cmd = new SqlCommand("select * from usuarios where rut = " + Rut, cn);
            cmd.ExecuteNonQuery(); //Sentencia que ejecuta el comando

            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                DatosConsultados(GetTxtRutConsultado(), GetTxtNombreConsultado(), GetTxtApellidoConsultado());
            }
            else
            {
                MessageBox.Show("No existe el rut ingresado en la bd");
            }

        }
        catch (Exception ex)
        {
            salida = ("No se pudo traer los datos de: " + ex.ToString());
        }
        return salida;
    }

    public string GetTxtRutConsultado()
    {
        return dr["rut"].ToString();
    }

    public string GetTxtNombreConsultado()
    {
        return dr["nombre"].ToString();
    }

    public string GetTxtApellidoConsultado()
    {
        return dr["apellido"].ToString();
    }

    public void DatosConsultados(string txtRutConsultado, string txtNombreConsultado, string txtApellidoConsultado)
    {
    }

    public string ModificarUsuario(string Rut, string Nombre, string Apellido)
    {
        string salida = "Se registró el usuario exitosamente";
        try
        {
            cmd = new SqlCommand("update usuarios set rut='" + Rut.ToString() + "', nombre='" + Nombre.ToString() + "', apellido='" + Apellido.ToString() + "' where rut ='" + Rut.ToString() + "'", cn);
            cmd.ExecuteNonQuery(); //Sentencia que ejecuta el comando
        }
        catch (Exception ex)
        {
            salida = ("No se insertó: " + ex.ToString());
        }

        return salida;
    }
}
