using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Ej_Interfaz_Proyecto.Clases_1280x1024
{
    class Ambientes
    {
        private string  id_ambiente,nombre, descripcion, areaFormacion, id_area;
        int capacidad, area;

        public string Id_ambiente
        {
            set
            {
                id_ambiente = value;
            }
            get { return id_ambiente; }

        }
        public string Id_area
        {
            set
            {
                id_area = value;
            }
            get { return id_area; }

        }
        public string Nombre
        {
            set
            {
                nombre = value;
            }
            get { return nombre; }

        }

        public string Descripcion
        {
            set
            {
                descripcion = value;
            }
            get { return descripcion; }
        }

        public int Capacidad
        {
            set
            {
                capacidad = value;
            }
            get { return capacidad; }
        }

        public int Area
        {
            set
            {
                area = value;
            }
            get { return area; }

        }

        public string AreaFormacion
        {
            set
            {
                areaFormacion = value;
            }
            get { return areaFormacion; }
        }

    /*    public bool VerificarCodigo()
        {
            bool existe = false;
            Int32 c;
            string SQL = "SELECT COUNT(*)FROM AMBIENTE WHERE ID_AMBIENTE=@ID";
            Conexion conexion = new Conexion();
            try
            {
                SqlCommand cmd = new SqlCommand(SQL, conexion.AbrirConexion());
                cmd.Parameters.AddWithValue("@ID", codigo);
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
        }*/

        public void Registrar()
        {
            string SQL = "INSERT INTO AMBIENTE VALUES(@NOMBRE_AMBIENTE, @DESCRIPCION, @CAPACIDAD, @AREA, @AREA_F)";
            Conexion conexion = new Conexion();
            try
            {
                conexion.AbrirConexion();
                SqlCommand cmdConsulta = new SqlCommand(SQL, conexion.GetConexion);


                cmdConsulta.Parameters.AddWithValue("@NOMBRE_AMBIENTE", nombre);
                cmdConsulta.Parameters.AddWithValue("@DESCRIPCION", descripcion);
                cmdConsulta.Parameters.AddWithValue("@CAPACIDAD", capacidad);
                cmdConsulta.Parameters.AddWithValue("@AREA", area);
                cmdConsulta.Parameters.AddWithValue("@AREA_F", areaFormacion);
               
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
        public void Modificar(string codActual)
        {
            string SQL = "UPDATE AMBIENTE SET NOMBRE_AMBIENTE = @NOMBRE,  DESCRIPCION = @DESCRIPCION,  CAPACIDAD = @CAPACIDAD, AREA = @AREA, ID_AREA=@AREA_F WHERE ID_AMBIENTE=@ID2";
            Conexion conexion = new Conexion();
            try
            {
                conexion.AbrirConexion();
                SqlCommand cmdConsulta = new SqlCommand(SQL, conexion.GetConexion);

                cmdConsulta.Parameters.AddWithValue("@NOMBRE", nombre);
                cmdConsulta.Parameters.AddWithValue("@DESCRIPCION", descripcion);
                cmdConsulta.Parameters.AddWithValue("@CAPACIDAD", capacidad);
                cmdConsulta.Parameters.AddWithValue("@AREA", area);
                cmdConsulta.Parameters.AddWithValue("@AREA_F", areaFormacion);
                cmdConsulta.Parameters.AddWithValue("@ID2", codActual);
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

        public void Eliminar(string codActual)
        {
            string SQL = "DELETE  AMBIENTE  WHERE ID_AMBIENTE=@ID";
            Conexion conexion = new Conexion();
            try
            {
                conexion.AbrirConexion();
                SqlCommand cmdConsulta = new SqlCommand(SQL, conexion.GetConexion);
                cmdConsulta.Parameters.AddWithValue("@ID", codActual);

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

        public static DataTable ListarAmbientes()
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT ID_AMBIENTE, NOMBRE_AMBIENTE, DESCRIPCION, CAPACIDAD, AREA, NOMBRE FROM AMBIENTE JOIN AREAS ON ID_AREA=ID order by NOMBRE_AMBIENTE", Conexion.CadenaDeConexion);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public DataTable ejecutar(string consulta)
        {
            DataTable dt = new DataTable();
            try
            {
                Conexion c = new Conexion();
                c.AbrirConexion();
                SqlCommand cm = c.GetConexion.CreateCommand();
                cm.CommandText = consulta;
                SqlDataReader dr = cm.ExecuteReader();
                dt.Load(dr);
                dr.Close();
                c.CerrarConexion();
            }
            catch (Exception ex)
            {


            }
            return dt;
        }

    }
}
