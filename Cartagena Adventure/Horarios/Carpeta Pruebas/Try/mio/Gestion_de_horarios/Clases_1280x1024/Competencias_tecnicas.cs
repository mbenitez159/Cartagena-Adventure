using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Ej_Interfaz_Proyecto.Clases_1280x1024
{
    class Competencias_tecnicas
    {

        private string codigo;
        private string descripcion;
        private string id_programa;
        private string duracion;

        public string ID_Programa
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
            string SQL = "SELECT COUNT(*) FROM COMPETENCIAS WHERE ID= @ID";
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

        public void RegistrarCompetenciasTecnicas()
        {

            string SQL = "INSERT INTO COMPETENCIAS VALUES(@ID_COMPETENCIA_TECNICA, @DESCRIPCION_TECNICA, @ID_PROGRAMA, @DURACION_TECNICA,1)";
            Conexion conexion = new Conexion();
            try
            {
                conexion.AbrirConexion();
                SqlCommand cmdConsulta = new SqlCommand(SQL, conexion.GetConexion);

                cmdConsulta.Parameters.AddWithValue("@ID_COMPETENCIA_TECNICA", codigo);
                cmdConsulta.Parameters.AddWithValue("@DESCRIPCION_TECNICA", descripcion);
                cmdConsulta.Parameters.AddWithValue("@ID_PROGRAMA", id_programa);
                cmdConsulta.Parameters.AddWithValue("@DURACION_TECNICA", duracion);
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

        public void ModificarCompetenciasTecnicas(string CodigoActual)
        {

            string SQL = "UPDATE COMPETENCIAS SET ID = @ID_COMPETENCIA_TECNICA, DESCRIPCION = @DESCRIPCION_TECNICA, ID_PROGRAMA = @ID_PROGRAMA, DURACION=@DURACION_TECNICA  WHERE ID = @ID2";
            Conexion conexion = new Conexion();
            try
            {
                conexion.AbrirConexion();
                SqlCommand cmdConsulta = new SqlCommand(SQL, conexion.GetConexion);

                cmdConsulta.Parameters.AddWithValue("@ID_COMPETENCIA_TECNICA", codigo);
                cmdConsulta.Parameters.AddWithValue("@DESCRIPCION_TECNICA", descripcion);
                cmdConsulta.Parameters.AddWithValue("@ID_PROGRAMA", id_programa);
                cmdConsulta.Parameters.AddWithValue("@DURACION_TECNICA", duracion);
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

        public static DataTable ListadoDeCompetencias(string idprograma)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT COMPTET.ID, COMPTET.DESCRIPCION, COMPTET.DURACION FROM COMPETENCIAS  AS COMPTET JOIN PROGRAMA AS PROG " +
                   "ON COMPTET.ID_PROGRAMA=PROG.ID_PROGRAMA WHERE PROG.ID_PROGRAMA=@ID AND COMPTET.TIPO='1' ORDER BY COMPTET.ID", Conexion.CadenaDeConexion);
                da.SelectCommand.Parameters.AddWithValue("@ID",idprograma);                
                dt.Locale = System.Globalization.CultureInfo.InvariantCulture;
                da.Fill(dt);
                int d = dt.Rows.Count;
                
            }
            catch (Exception ex)
            {
                //throw new Exception(ex.Message);
            }
            return dt;
        }

        public static DataTable ListadoDeCompetenciasConDuracion(string idprograma, string ficha)
        {
            
            try
            {
               /* SqlDataAdapter da = new SqlDataAdapter("SELECT COMPTET.ID_COMPETENCIA_TECNICA, COMPTET.DESCRIPCION_TECNICA, DT.DURACION FROM COMPETENCIAS_TECNICAS  AS COMPTET JOIN PROGRAMA AS PROG " +
                   "ON COMPTET.ID_PROGRAMA=PROG.ID_PROGRAMA LEFT JOIN DURACION_TECNICAS AS DT ON COMPTET.ID_COMPETENCIA_TECNICA = DT.ID_COMPETENCIA_TECNICA AND DT.ID_GRUPO = @FICHA WHERE PROG.ID_PROGRAMA = @ID AND DT.ID_GRUPO NOT IN(SELECT ID_GRUPO FROM DURACION_TECNICAS)  ORDER BY COMPTET.ID_COMPETENCIA_TECNICA", Conexion.CadenaDeConexion);*/
                SqlDataAdapter da = new SqlDataAdapter("SELECT COMPTET.ID, COMPTET.DESCRIPCION, COMPTET.DURACION FROM COMPETENCIAS AS COMPTET JOIN PROGRAMA AS PROG " +
                   "ON COMPTET.ID_PROGRAMA=PROG.ID_PROGRAMA  WHERE PROG.ID_PROGRAMA = @ID AND COMPET.TIPO=1  ORDER BY COMPTET.ID", Conexion.CadenaDeConexion);
                da.SelectCommand.Parameters.AddWithValue("@ID", idprograma);
                da.SelectCommand.Parameters.AddWithValue("@FICHA", ficha);
                DataTable dt = new DataTable();

                da.Fill(dt);

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable ListadoIncrementalDeCompetencias(string tipoParametro, string programa, string texto)
        {
            Conexion conexion = new Conexion();

            string SQL = "";

            if (tipoParametro == "Id")
            {
                SQL = "SELECT ID, DESCRIPCION, DURACION FROM COMPETENCIAS WHERE ID LIKE'" + texto + "%' AND ID_PROGRAMA='" + programa + "' AND TIPO =1 ORDER BY COMPETENCIAS.ID";
            }
            else if (tipoParametro == "Descripcion")
            {
                SQL = "SELECT ID, DESCRIPCION, DURACION FROM COMPETENCIAS WHERE DESCRIPCION LIKE'" + texto + "%' AND ID_PROGRAMA='" + programa + "' AND TIPO =1 ORDER BY COMPETENCIAS.ID";
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
        public static DataTable eliminaResultado(string idComp, string tipo, string codigo)
        {
            DataTable dvg = new DataTable();
            Conexion c = new Conexion();
            c.AbrirConexion();
            try
            {
                SqlCommand cm = new SqlCommand("delete RESULTADOS where id='" + idComp + "' ", c.GetConexion);
                cm.ExecuteNonQuery();
                cm = new SqlCommand("select c.ID, c.DESCRIPCION, c.DURACION from COMPETENCIAS c where TIPO=" + tipo + " and c.ID_PROGRAMA='" + codigo + "' ", c.GetConexion);
                SqlDataReader dr = cm.ExecuteReader();
                dvg.Load(dr);

            }
            catch (Exception ex)
            {
                dvg = null;
                throw new Exception(ex.Message);
            }
            return dvg;
        }
        public static DataTable eliminarCompetencia(string idComp,string tipo, string codigo) {
            DataTable dvg = new DataTable();
            Conexion c = new Conexion();
            c.AbrirConexion();
            try
            {
                SqlCommand cm = new SqlCommand("delete COMPETENCIAS where id='" + idComp + "' ", c.GetConexion);
                cm.ExecuteNonQuery();
                cm = new SqlCommand("select c.ID, c.DESCRIPCION, c.DURACION from COMPETENCIAS c where TIPO=" + tipo + " and c.ID_PROGRAMA='"+codigo+"' ", c.GetConexion);
                SqlDataReader dr = cm.ExecuteReader();
                dvg.Load(dr);
                
            }
            catch (Exception ex)
            {
                dvg = null;
             throw new Exception(ex.Message);
            }
            return dvg;
        }

       public static DataTable ListadoParcialDeCompetencias(string idprograma)
        {
            Conexion conexion = new Conexion();

            string SQL = "";

            SQL = "SELECT COMP.ID_COMPETENCIA, COMP.DESCRIPCION FROM COMPETENCIA AS COMP JOIN PROGRAMA AS PROG ON PROG.ID_PROGRAMA=COMP.ID_PROGRAMA  WHERE  PROG.ID_PROGRAMA=@ID";
           
            try
            {
                SqlDataAdapter da = new SqlDataAdapter(SQL, Conexion.CadenaDeConexion);
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
              

    }
}
