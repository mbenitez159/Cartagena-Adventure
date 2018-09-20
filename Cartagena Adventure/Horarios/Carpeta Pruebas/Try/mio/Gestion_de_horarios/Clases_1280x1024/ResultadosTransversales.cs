using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Ej_Interfaz_Proyecto.Clases_1280x1024
{
    class ResultadosTransversales
    {
        private string codigo;
        private string descripcion;
        private string competencia;
        private int duracion;

        public string ID_Competencia
        {
            set
            {
                this.competencia = value;
            }
            get
            {
                return competencia;
            }
        }


        public string Codigo
        {
            set
            {
                this.codigo = value;
            }
            get
            {
                return codigo;
            }
        }

        public string Descripcion
        {
            set
            {
                this.descripcion = value;
            }
            get
            {
                return descripcion;
            }
        }

        public int Duracion
        {
            set
            {
                this.duracion = value;
            }
            get
            {
                return duracion;
            }
        }

        public void Modificar()
        {

            string SQL = "UPDATE RESULTADOS SET DESCRIPCION = @DESCRIPCION, DURACION = @DURACION_RESULT_TRANS WHERE ID= @ID";
            Conexion conexion = new Conexion();
            try
            {
                conexion.AbrirConexion();
                SqlCommand cmdConsulta = new SqlCommand(SQL, conexion.GetConexion);
                cmdConsulta.Parameters.AddWithValue("@DESCRIPCION", descripcion);
                cmdConsulta.Parameters.AddWithValue("@DURACION_RESULT_TRANS", duracion);
                cmdConsulta.Parameters.AddWithValue("@ID", codigo);
                cmdConsulta.CommandType = CommandType.Text;

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


        public void Registrar()
        {
            string SQL = "INSERT INTO RESULTADOS VALUES(@DESCRIPCION, @ID_COMPETENCIA_TRANSVERSAL, @DURACION_RESULT_TRANS)";
            Conexion conexion = new Conexion();
            try
            {
                conexion.AbrirConexion();
                SqlCommand cmdConsulta = new SqlCommand(SQL, conexion.GetConexion);

                cmdConsulta.Parameters.AddWithValue("@DESCRIPCION", descripcion);
                cmdConsulta.Parameters.AddWithValue("@ID_COMPETENCIA_TRANSVERSAL", competencia);
                cmdConsulta.Parameters.AddWithValue("@DURACION_RESULT_TRANS", duracion);

                cmdConsulta.CommandType = CommandType.Text;

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


        public bool VerificarCodigo()
        {
            bool existe = false;
            Int32 c = 0;
            string SQL = "SELECT COUNT(*) FROM RESULTADOS WHERE ID = @ID";
            Conexion conexion = new Conexion();
            try
            {
                conexion.AbrirConexion();
                SqlCommand cmdConsulta = new SqlCommand(SQL, conexion.GetConexion);
                cmdConsulta.Parameters.AddWithValue("@ID", codigo);
                cmdConsulta.CommandType = CommandType.Text;

                c = Int32.Parse(cmdConsulta.ExecuteScalar().ToString());

                cmdConsulta.Parameters.Clear();
                cmdConsulta.Dispose();

                if (c == 1)
                {
                    existe = true;
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            finally
            {
                conexion.CerrarConexion();
            }


            return existe;
        }


        public static DataTable ListadoIncrementalIDeResultados(string texto, string id_competencia)
        {
            Conexion conexion = new Conexion();
            string SQL = "SELECT RESULTADOS.ID, RESULTADOS.DESCRIPCION, RESULTADOS.DURACION FROM RESULTADOS, COMPETENCIAS WHERE RESULTADOS.ID_COMPETENCIA = COMPETENCIAS.ID AND COMPETENCIAS.ID='" + id_competencia + "' AND COMPETENCIAS.TIPO = 2 AND RESULTADOS.DESCRIPCION LIKE '" + texto + "%'";
             
            try
            {
                SqlDataAdapter da = new SqlDataAdapter(SQL, Conexion.CadenaDeConexion);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public static DataTable ListadoDeResultados(string Idcompetencia)
        {
            Conexion conexion = new Conexion();

            string SQL = "SELECT RESULTADOS.ID, RESULTADOS.DESCRIPCION, RESULTADOS.DURACION FROM RESULTADOS, COMPETENCIAS WHERE RESULTADOS.ID_COMPETENCIA = COMPETENCIAS.ID AND COMPETENCIAS.ID=@ID AND COMPETENCIAS.TIPO = 2";

            try
            {
                SqlDataAdapter da = new SqlDataAdapter(SQL, Conexion.CadenaDeConexion);
                da.SelectCommand.Parameters.AddWithValue("@ID", Idcompetencia);
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
