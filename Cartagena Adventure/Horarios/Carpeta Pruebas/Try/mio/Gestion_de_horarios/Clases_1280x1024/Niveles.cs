using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Ej_Interfaz_Proyecto.Clases_1280x1024
{
    class Niveles
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
            string SQL = "SELECT COUNT(*)FROM NIVELPROGRAMA WHERE ID=@CODIGO";
            Conexion conexion = new Conexion();
            try
            {
                conexion.AbrirConexion();
                SqlCommand cmd = new SqlCommand(SQL,conexion.GetConexion);
                cmd.Parameters.AddWithValue("@CODIGO", codigo);
                cmd.CommandType = CommandType.Text;

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



        public static DataTable ListarNiveles()
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM NIVELPROGRAMA", Conexion.CadenaDeConexion);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public void Registrar()
        {
            string SQL = "INSERT INTO NIVELPROGRAMA VALUES(@NOMBRE)";
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
            string SQL = "UPDATE NIVELPROGRAMA SET NOMBRE_NIVEL=@NOMBRE WHERE ID=@CODIGO2";
            Conexion conexion = new Conexion();
            try
            {
                conexion.AbrirConexion();
                SqlCommand cmdConsulta = new SqlCommand(SQL, conexion.GetConexion);
                cmdConsulta.Parameters.AddWithValue("@NOMBRE", nombre);
                cmdConsulta.Parameters.AddWithValue("@CODIGO2", IdActual);
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
            string SQL = "DELETE  NIVELPROGRAMA  WHERE ID=@CODIGO";
            Conexion conexion = new Conexion();
            try
            {
                conexion.AbrirConexion();
                SqlCommand cmdConsulta = new SqlCommand(SQL, conexion.GetConexion);
                cmdConsulta.Parameters.AddWithValue("@CODIGO", codigo);

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


    }
}
