using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Ej_Interfaz_Proyecto.Clases_1280x1024
{
    class ResultadosTecnicos
    {

        private string codigo;
        private string descripcion;
        private string competencia;
        private string duracion;

        public string ID_Competencia
        {
            set
            {
                this.competencia = value;
            }
            get {
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
            get {
                return descripcion;
            }
        }

        public string Duracion
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
            string SQL = "UPDATE RESULTADOS SET DESCRIPCION = @DESCRIPCION, DURACION = @DURACION_RESULT_TEC WHERE ID= @ID";
            Conexion conexion = new Conexion();
            try
            {
                conexion.AbrirConexion();
                SqlCommand cmdConsulta = new SqlCommand(SQL, conexion.GetConexion);

                cmdConsulta.Parameters.AddWithValue("@DESCRIPCION", descripcion);
                cmdConsulta.Parameters.AddWithValue("@DURACION_RESULT_TEC", duracion);
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

            string SQL = "INSERT INTO RESULTADOS (DESCRIPCION, ID_COMPETENCIA, DURACION) VALUES(@DESCRIPCION, @ID_COMPETENCIA_TECNICA, @DURACION_RESULT_TEC)";
            Conexion conexion = new Conexion();
            try
            {
                conexion.AbrirConexion();
                SqlCommand cmdConsulta = new SqlCommand(SQL, conexion.GetConexion);

                cmdConsulta.Parameters.AddWithValue("@DESCRIPCION", descripcion);
                cmdConsulta.Parameters.AddWithValue("@ID_COMPETENCIA_TECNICA", competencia);
                cmdConsulta.Parameters.AddWithValue("@DURACION_RESULT_TEC", duracion);

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

        public static DataTable ListadoIncrementalIDeResultados(string texto, string idcompetencia)
        {
            Conexion conexion = new Conexion();

            string SQL = "";

            SQL = "SELECT RT.ID, RT.DESCRIPCION, RT.DURACION FROM " +
            "RESULTADOS AS RT JOIN COMPETENCIAS AS CT ON RT.ID_COMPETENCIA = CT.ID WHERE RT.DESCRIPCION LIKE '" + texto + "%' AND CT.ID = '" + idcompetencia + "' AND CT.TIPO=1 ORDER BY RT.DESCRIPCION";
          
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

            string SQL = "SELECT RESULTADOS.ID, RESULTADOS.DESCRIPCION, RESULTADOS.DURACION FROM RESULTADOS, COMPETENCIAS WHERE RESULTADOS.ID_COMPETENCIA = COMPETENCIAS.ID AND COMPETENCIAS.TIPO =1 AND COMPETENCIAS.ID=@ID";

            try
            {
                SqlDataAdapter da = new SqlDataAdapter(SQL, Conexion.CadenaDeConexion);
                da.SelectCommand.Parameters.AddWithValue("@ID",Idcompetencia);
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
