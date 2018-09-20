using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
namespace Ej_Interfaz_Proyecto.Clases_1280x1024
{
    class Competencias_transversales
    {
        private string codigo;
        private string descripcion;
        private string id_programa;
        private string duracion;

        public string Id_Programa
        {
            set
            {
                this.id_programa = value;
            }
            get {
                return id_programa;
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

        public bool VerificarCodigo()
        {
            bool existe = false;
            Int32 c = 0;
            string SQL = "SELECT COUNT(*) FROM COMPETENCIAS WHERE ID = @ID";
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


        public static DataTable ListadoDeCompetenciasTransversales(string idprograma)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT COMPTET.ID, COMPTET.DESCRIPCION, COMPTET.DURACION FROM COMPETENCIAS  AS COMPTET JOIN PROGRAMA AS PROG " +
                   "ON COMPTET.ID_PROGRAMA=PROG.ID_PROGRAMA WHERE PROG.ID_PROGRAMA=@ID AND COMPTET.TIPO='2' ORDER BY COMPTET.ID", Conexion.CadenaDeConexion);
                da.SelectCommand.Parameters.AddWithValue("@ID", idprograma);
                
                DataTable dt = new DataTable();

                da.Fill(dt);

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable ListadoIncrementalDeCompetencias(string tipoParametro, string texto, string id_programa)
        {
            Conexion conexion = new Conexion();

            string SQL = "";

            if (tipoParametro == "Id")
            {
                SQL = "SELECT TRANS.ID_COMPETENCIA_TRANSVERSAL, TRANS.DESCRIPCION_TRANSVERSAL, TRANS.DURACION_TRANSVERSAL  FROM COMPETENCIAS_TRANSVERSALES AS TRANS, PROGRAMA_COMPETENCIAS_TRANSVERSALES AS PROCOMP, PROGRAMA AS PRO " +
                "WHERE TRANS.ID_COMPETENCIA_TRANSVERSAL LIKE'" + texto + "%' AND TRANS.ID_COMPETENCIA_TRANSVERSAL=PROCOMP.ID_COMPETENCIA_TRANSVERSAL "+
              "AND PROCOMP.ID_PROGRAMA=PRO.ID_PROGRAMA AND PRO.ID_PROGRAMA  = '" + id_programa + "' ORDER BY TRANS.ID_COMPETENCIA_TRANSVERSAL";
            }
            else if (tipoParametro == "Descripcion")
            {
                SQL = "SELECT TRANS.ID_COMPETENCIA_TRANSVERSAL, TRANS.DESCRIPCION_TRANSVERSAL, TRANS.DURACION_TRANSVERSAL  FROM COMPETENCIAS_TRANSVERSALES AS TRANS, PROGRAMA_COMPETENCIAS_TRANSVERSALES AS PROCOMP, PROGRAMA AS PRO " +
                "WHERE TRANS.DESCRIPCION_TRANSVERSAL LIKE'" + texto + "%' AND TRANS.ID_COMPETENCIA_TRANSVERSAL=PROCOMP.ID_COMPETENCIA_TRANSVERSAL " +
              "AND PROCOMP.ID_PROGRAMA=PRO.ID_PROGRAMA AND PRO.ID_PROGRAMA  = '" + id_programa + "' ORDER BY TRANS.ID_COMPETENCIA_TRANSVERSAL";
            }
      
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

        //listo
        public void Registrar()
        {

            string SQL = "INSERT INTO COMPETENCIAS VALUES(@ID_COMPETENCIA, @DESCRIPCION, @ID_PROGRAMA, @DURACION,2)";
            Conexion conexion = new Conexion();
            try
            {
                conexion.AbrirConexion();
                SqlCommand cmdConsulta = new SqlCommand(SQL, conexion.GetConexion);

                cmdConsulta.Parameters.AddWithValue("@ID_COMPETENCIA", codigo);
                cmdConsulta.Parameters.AddWithValue("@DESCRIPCION", descripcion);
                cmdConsulta.Parameters.AddWithValue("@ID_PROGRAMA", id_programa);
                cmdConsulta.Parameters.AddWithValue("@DURACION", duracion);
               
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

        //listo
        public void Registrar_Programa_Competencia_Transversal()
        {
            /* modificado por jefferson
            string SQL = "INSERT INTO PROGRAMA_COMPETENCIAS_TRANSVERSALES VALUES(@ID_PROGRAMA, @ID_COMPETENCIA_TRANSVERSAL)";
            Conexion conexion = new Conexion();
            try
            {
                conexion.AbrirConexion();
                SqlCommand cmdConsulta = new SqlCommand(SQL, conexion.GetConexion);

                cmdConsulta.Parameters.AddWithValue("@ID_COMPETENCIA_TRANSVERSAL", codigo);
                cmdConsulta.Parameters.AddWithValue("@ID_PROGRAMA", id_programa);

               
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
            }*/
        }

       
        public void Modificar(string CodigoActual)
        {

            string SQL = "UPDATE COMPETENCIAS SET ID = @ID_COMPETENCIA_TRANSVERSAL, DESCRIPCION = @DESCRIPCION_TRANSVERSAL WHERE  tipo = 2 and ID = @ID2";
            Conexion conexion = new Conexion();
            try
            {
                conexion.AbrirConexion();
                SqlCommand cmdConsulta = new SqlCommand(SQL, conexion.GetConexion);

                cmdConsulta.Parameters.AddWithValue("@ID_COMPETENCIA_TRANSVERSAL", codigo);
                cmdConsulta.Parameters.AddWithValue("@DESCRIPCION_TRANSVERSAL", descripcion);
                cmdConsulta.Parameters.AddWithValue("@ID2", CodigoActual);
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

        public static DataTable ListadoProgramasNoRelacionados()
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT ID_PROGRAMA, NOMBRE_PROGRAMA FROM PROGRAMA", Conexion.CadenaDeConexion);

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
