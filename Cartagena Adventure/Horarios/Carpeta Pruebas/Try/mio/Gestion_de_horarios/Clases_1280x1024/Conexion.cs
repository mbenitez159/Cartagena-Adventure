using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
namespace Ej_Interfaz_Proyecto.Clases_1280x1024
{
    class Conexion
    {
        //SISYEMA\\SQLEXPRESS
       private SqlConnection con;
       private static string cadenaConexion = "Data Source= .;Initial Catalog=Generar_horario; integrated Security=true";
      
        public static string CadenaDeConexion
        {
            get
            {
                return cadenaConexion;
            }
        }

        public SqlConnection GetConexion
        {
            get
            {
                return con;
            }
        }

        public void AbrirConexion()
        {
            try
            {
                con = new SqlConnection(cadenaConexion);
                con.Open();

            }
            catch (Exception e)
            {
                MessageBox.Show("Error de conexión" + e.Message);
            }
            
        }


        public void CerrarConexion()//cierra la conexion
        {
            con.Close();
        }

    }
}
