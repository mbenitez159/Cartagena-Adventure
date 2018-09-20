using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Ej_Interfaz_Proyecto.Clases_1280x1024
{
    class Profesion
    {
        string codigo;
        string nombre;

        public string Codigo
        {
            set
            {
                this.codigo = value;
            }
        }

        public string Nombre
        {
            set
            {
                this.nombre = value;
            }
        }

        public bool VerificarCodigo()
        {
            bool existe = false;
            Int32 c;
            string SQL = "SELECT COUNT(*)FROM PROFESION WHERE ID_PROFESION=@ID";
            Conexion conexion = new Conexion();
            try
            {
                conexion.AbrirConexion();
                SqlCommand cmd=new SqlCommand(SQL,conexion.GetConexion);
                cmd.Parameters.AddWithValue("@ID",codigo);
                cmd.CommandType=CommandType.Text;

                c = Int32.Parse(cmd.ExecuteScalar().ToString());
                if (c == 1)
                {
                    existe = true;
                }
            }
            catch (Exception)
            {
                throw new Exception("Error al verificar el código");
            }
            finally
            {
                conexion.CerrarConexion();
            }
            return existe;
        }

        public void Registrar()
        {
            string SQL = "INSERT INTO PROFESION VALUES(@NOMBRE)";
            Conexion conexion = new Conexion();
            try
            {
                conexion.AbrirConexion();
                SqlCommand cmdConsulta = new SqlCommand(SQL, conexion.GetConexion);
                cmdConsulta.Parameters.AddWithValue("@NOMBRE", nombre);
                cmdConsulta.CommandType = CommandType.Text;
                cmdConsulta.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            finally
            {
                conexion.CerrarConexion();
            }
        }
        public void Modificar(string IdActual)
        {
            string SQL = "UPDATE PROFESION SET NOMBRE_PROFESION=@NOMBRE WHERE ID_PROFESION=@ID2";
            Conexion conexion = new Conexion();
            try
            {
                conexion.AbrirConexion();
                SqlCommand cmdConsulta = new SqlCommand(SQL, conexion.GetConexion);
                cmdConsulta.Parameters.AddWithValue("@NOMBRE", nombre);
                cmdConsulta.Parameters.AddWithValue("@ID2", IdActual);
                cmdConsulta.ExecuteNonQuery();

                cmdConsulta.Parameters.Clear();
                cmdConsulta.Dispose();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            finally
            {
                conexion.CerrarConexion();
            }
        }

        public void Eliminar() 
        {
            string SQL = "DELETE  PROFESION  WHERE ID_PROFESION=@ID";
            Conexion conexion = new Conexion();
            try
            {
                conexion.AbrirConexion();
                SqlCommand cmdConsulta = new SqlCommand(SQL, conexion.GetConexion);
                cmdConsulta.Parameters.AddWithValue("@ID", codigo);
               
                cmdConsulta.ExecuteNonQuery();

                cmdConsulta.Parameters.Clear();
                cmdConsulta.Dispose();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            finally
            {
                conexion.CerrarConexion();
            }
        }

        public static DataTable ListarProfesiones()
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM PROFESION", Conexion.CadenaDeConexion);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
