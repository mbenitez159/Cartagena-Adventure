using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Ej_Interfaz_Proyecto.Clases_1280x1024
{
    class Area
    {
        string nombre;
        string codigo;
        public string Nombre 
        
        {
            set { this.nombre = value; }
            get { return nombre; }
        }

        public string Codigo
        {
            set { this.codigo = value; }
            get { return codigo; }
        }

        public bool VerificarNombre()
        {
            bool existe = false;
            Int32 c;
            string SQL = "SELECT COUNT(*)FROM AREAS WHERE NOMBRE=@NOMB";
            Conexion conexion = new Conexion();
            try
            {
                conexion.AbrirConexion();
                SqlCommand cmd = new SqlCommand(SQL, conexion.GetConexion);
                cmd.Parameters.AddWithValue("@NOMB", nombre);
                cmd.CommandType = CommandType.Text;

                c = Int32.Parse(cmd.ExecuteScalar().ToString());
                if (c == 1)
                {
                    existe = true;
                }
            }
            catch (Exception)
            {
                throw new Exception("Error al verificar el nombre");
            }
            finally
            {
                conexion.CerrarConexion();
            }
            return existe;
        }

        public void Registrar()
        {
            string SQL = "INSERT INTO AREAS VALUES(@NOMBRE)";
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
        public void Modificar()
        {
            string SQL = "UPDATE AREAS SET NOMBRE = @NOMBRE WHERE ID=@ID2";
            Conexion conexion = new Conexion();
            try
            {
                conexion.AbrirConexion();
                SqlCommand cmdConsulta = new SqlCommand(SQL, conexion.GetConexion);
                cmdConsulta.Parameters.AddWithValue("@NOMBRE", nombre);
                cmdConsulta.Parameters.AddWithValue("@ID2", codigo);
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
            string SQL = "DELETE  AREAS  WHERE ID=@ID";
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

        public static DataTable ListarAreas()
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM AREAS", Conexion.CadenaDeConexion);
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
