using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Ej_Interfaz_Proyecto.Clases_1280x1024
{
    class Grupos
    {
        private string id_grupo;
        private string jornada;
        private string id_programa;
        private string trimestreActual;
        private string id_ambiente;
        private string id_estado;
        private string fechainicio;
        private string fechafin;
        private string lider;
        private int cantidad;
        public String FechaInicio {
            set { fechainicio = value; }
            get { return fechainicio; }
        }
        public int Cantidad
        {
            set { cantidad = value; }
            get { return cantidad; }
        }
        public String fechaFin
        {
            set { fechafin = value; }
            get { return fechafin; }
        }
        public String Lider
        {
            set { lider = value; }
            get { return lider; }
        }
        public String Id_grupo
        {
            set
            {
                this.id_grupo = value;
            }
            get { return id_grupo; }
        }
        public string Jornada
        {
            set
            {
                this.jornada = value;
            }
            get { return jornada; }
        }

        public string Id_Programa
        {
            set
            {
                this.id_programa = value;
            }
            get { return id_programa; }
        }

        public string TrimestreActual
        {
            set
            {
                this.trimestreActual = value;
            }
            get { return trimestreActual; }
        }

        public string Id_Ambiente
        {
            set
            {
                this.id_ambiente = value;
            }
            get { return id_ambiente; }
        }

        public string Id_Estado
        {
            set
            {
                this.id_estado = value;
            }
            get { return id_estado; }
        }

        public bool VerificarNumeroDeFicha()
        { 
                 
            bool existe = false;
            Int32 c;
            string SQL = "SELECT COUNT(*)FROM GRUPO WHERE ID_GRUPO=@ID";
            Conexion conexion = new Conexion();
            try
            {
                conexion.AbrirConexion();
                SqlCommand cmd = new SqlCommand (SQL ,conexion.GetConexion);
                cmd.Parameters.AddWithValue("@ID", id_grupo);
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

        public void RegistrarGrupo()
        {
            string SQL_Grupo = "INSERT INTO GRUPO VALUES('" + id_grupo+ "', '"+jornada+"', '"+id_programa+"','"+trimestreActual+"',"+id_ambiente+","+id_estado+",'" + fechainicio + "','"+fechafin+"',"+cantidad+",'"+lider+"')";
            /*
            string SQL_ResultTrans="INSERT INTO DURACION_TRANSVERSAL (ID_GRUPO, ID_RESULTADO_TRANSVERSAL, TIEMPO_RESTANTE) "+
                    "SELECT GR.ID_GRUPO, RT.ID_RESULTADO_TRANSVERSAL, RT.DURACION_RESULT_TRANS "+
                    "FROM RESULTADOS_TRANSVERSALES AS RT, GRUPO AS GR,COMPETENCIAS_TRANSVERSALES AS CTR, PROGRAMA_COMPETENCIAS_TRANSVERSALES AS PCT, PROGRAMA AS PR "+
                    "WHERE GR.ID_GRUPO=@ID_GRUPO  AND CTR.ID_COMPETENCIA_TRANSVERSAL = RT.ID_COMPETENCIA_TRANSVERSAL "+
                    "AND CTR.ID_COMPETENCIA_TRANSVERSAL = PCT.ID_COMPETENCIA_TRANSVERSAL AND PCT.ID_PROGRAMA = PR.ID_PROGRAMA  AND PCT.ID_PROGRAMA = @ID_PROG";

            string SQL_ResultTecs = "INSERT INTO DURACION_TECNICAS (ID_GRUPO, ID_RESULTADO_TECNICO, TIEMPO_RESTANTE) "+
                                    "SELECT GR.ID_GRUPO, RT.ID_RESULTADO_TECNICO, RT.DURACION_RESULT_TEC "+
                                    "FROM RESULTADOS_TECNICOS AS RT, GRUPO AS GR, COMPETENCIAS_TECNICAS AS CT "+
                                    "WHERE GR.ID_GRUPO=@ID_GRUPO AND CT.ID_PROGRAMA = @ID_PROG AND CT.ID_COMPETENCIA_TECNICA = RT.ID_COMPETENCIA_TECNICA"; 
            */
            Conexion conexion = new Conexion();
            SqlTransaction trans = null;
            try
            {
                conexion.AbrirConexion();
                trans = conexion.GetConexion.BeginTransaction();

                SqlCommand cmdGrupo = new SqlCommand(SQL_Grupo, conexion.GetConexion,trans);
     ///           cmdGrupo.Parameters.AddWithValue("@ID", id_grupo);
                //cmdGrupo.Parameters.AddWithValue("@JORNADA", jornada);
                //cmdGrupo.Parameters.AddWithValue("@ID_PROGRAMA", id_programa); MOdificado pro Miguel código más optimo como esta
                //cmdGrupo.Parameters.AddWithValue("@TRIMESTRE_ACTUAL", trimestreActual); alli arriba
                //cmdGrupo.Parameters.AddWithValue("@ID_AMBIENTE", id_ambiente);
                //cmdGrupo.Parameters.AddWithValue("@ID_ESTADO", id_estado);

              //  cmdGrupo.Parameters.AddWithValue("@FECHA_FINAL",fechaFin);
               // cmdGrupo.Parameters.AddWithValue("@CANTIDAD_ALUMNOS",cantidad);
               // cmdGrupo.Parameters.AddWithValue("@INSTRUCTOR_LIDER", lider);

     //           cmdGrupo.CommandType = CommandType.Text;

                cmdGrupo.ExecuteNonQuery();

         //       cmdGrupo.Parameters.Clear();
                /*
                //DURACION RESULTADOS TECNICOS
                SqlCommand cmdResultTecs = new SqlCommand(SQL_ResultTecs, conexion.GetConexion, trans);
                cmdResultTecs.Parameters.AddWithValue("@ID_GRUPO", id_grupo);
                cmdResultTecs.Parameters.AddWithValue("@ID_PROG", id_programa);
                cmdResultTecs.CommandType = CommandType.Text;
                cmdResultTecs.ExecuteNonQuery();
                cmdResultTecs.Parameters.Clear();

                //DURACION RESULTADOS TRANSVERSALES
                SqlCommand cmdResultTrans = new SqlCommand(SQL_ResultTrans, conexion.GetConexion, trans);
                cmdResultTrans.Parameters.AddWithValue("@ID_GRUPO", id_grupo);
                cmdResultTrans.Parameters.AddWithValue("@ID_PROG", id_programa);
                cmdResultTrans.CommandType = CommandType.Text;
                cmdResultTrans.ExecuteNonQuery();
                cmdResultTrans.Parameters.Clear();

           */
                trans.Commit();

                cmdGrupo.Dispose();
               // cmdResultTecs.Dispose();
               // cmdResultTrans.Dispose();
            }
            catch (Exception ex)
            {
                try
                {

                }
                catch (Exception ex2)
                {
                    trans.Rollback();
                    throw new Exception(ex2.Message);
                }
                throw new Exception(ex.Message);
            }
            finally
            {
                conexion.CerrarConexion();
            }
        }

        public void ModificarGrupo(string CodigoActual)
        {
            string SQL = "UPDATE GRUPO SET ID_GRUPO = @ID, JORNADA = @JORNADA, ID_PROGRAMA = @ID_PROGRAMA, "
            + "TRIMESTRE_ACTUAL = @TRIMESTRE_ACTUAL ,ID_AMBIENTE=@ID_AMBIENTE,ID_ESTADO=@ID_ESTADO,INICIO=@INICIO,FECHA_FINAL=@FECHA_FINAL,CANTIDAD_ALUMNOS=@CANTIDAD_ALUMNOS,INSTRUCTOR_LIDER=@INSTRUCTOR_LIDER WHERE ID_GRUPO = @ID2";
            Conexion conexion = new Conexion();
            try
            {
                conexion.AbrirConexion();

                SqlCommand cmdGrupo = new SqlCommand(SQL, conexion.GetConexion);

                cmdGrupo.Parameters.AddWithValue("@ID", id_grupo);
                cmdGrupo.Parameters.AddWithValue("@JORNADA", jornada);
                cmdGrupo.Parameters.AddWithValue("@ID_PROGRAMA", id_programa);
                cmdGrupo.Parameters.AddWithValue("@TRIMESTRE_ACTUAL", trimestreActual);
                cmdGrupo.Parameters.AddWithValue("@ID_AMBIENTE", id_ambiente);
                cmdGrupo.Parameters.AddWithValue("@ID_ESTADO", id_estado);
                cmdGrupo.Parameters.AddWithValue("@ID2", CodigoActual);
                cmdGrupo.Parameters.AddWithValue("@INICIO",fechainicio);
                cmdGrupo.Parameters.AddWithValue("@FECHA_FINAL", fechaFin);
                cmdGrupo.Parameters.AddWithValue("@CANTIDAD_ALUMNOS", cantidad);
                cmdGrupo.Parameters.AddWithValue("@INSTRUCTOR_LIDER", lider);
                cmdGrupo.CommandType = CommandType.Text;

                cmdGrupo.ExecuteNonQuery();

                cmdGrupo.Parameters.Clear();
                cmdGrupo.Dispose();
            }
            catch (Exception ex)
            {
               
                //throw new Exception(ex.Message);
            }
            finally
            {
                conexion.CerrarConexion();
            }
        }

        public int ActualizarDuracionResultados()
        {

            int filasAfectadas=0;
            string SQL_ResultTecs = "INSERT INTO DURACION_TECNICAS (ID_GRUPO, ID_RESULTADO_TECNICO, TIEMPO_RESTANTE) " +
                                    "SELECT GR.ID_GRUPO, RT.ID_RESULTADO_TECNICO, RT.DURACION_RESULT_TEC "+
                                    "FROM RESULTADOS_TECNICOS AS RT, GRUPO AS GR, COMPETENCIAS_TECNICAS AS CT "+
                                    "WHERE GR.ID_GRUPO=@ID_GRUPO AND CT.ID_PROGRAMA = @ID_PROGRAMA AND CT.ID_COMPETENCIA_TECNICA = RT.ID_COMPETENCIA_TECNICA "+
                                    "AND RT.ID_RESULTADO_TECNICO NOT IN(SELECT ID_RESULTADO_TECNICO FROM DURACION_TECNICAS WHERE ID_GRUPO=@ID_GRUPO2)";

            string SQL_ResultTrans = "INSERT INTO DURACION_TRANSVERSAL (ID_GRUPO, ID_RESULTADO_TRANSVERSAL, TIEMPO_RESTANTE) "+ 
                                     "SELECT GR.ID_GRUPO, RT.ID_RESULTADO_TRANSVERSAL, RT.DURACION_RESULT_TRANS " +
                                     "FROM RESULTADOS_TRANSVERSALES AS RT, GRUPO AS GR, COMPETENCIAS_TRANSVERSALES AS CTR, PROGRAMA_COMPETENCIAS_TRANSVERSALES AS PCT, PROGRAMA AS PR " +
                                     "WHERE GR.ID_GRUPO=@ID_GRUPO  AND CTR.ID_COMPETENCIA_TRANSVERSAL = RT.ID_COMPETENCIA_TRANSVERSAL "+
                                     "AND CTR.ID_COMPETENCIA_TRANSVERSAL = PCT.ID_COMPETENCIA_TRANSVERSAL AND PCT.ID_PROGRAMA = PR.ID_PROGRAMA  AND PCT.ID_PROGRAMA = @ID_PROGRAMA "+
                                     "AND RT.ID_RESULTADO_TRANSVERSAL NOT IN(SELECT ID_RESULTADO_TRANSVERSAL FROM DURACION_TRANSVERSAL WHERE ID_GRUPO=@ID_GRUPO2)";

            Conexion conexion = new Conexion();

            SqlTransaction trans = null;
            try
            {
                conexion.AbrirConexion();

                trans = conexion.GetConexion.BeginTransaction();

                //ACTUALIZA LOS RESULTADOS TRANSVERSALES
                SqlCommand cmdResultTrans = new SqlCommand(SQL_ResultTrans, conexion.GetConexion, trans);
                cmdResultTrans.Parameters.AddWithValue("@ID_GRUPO", id_grupo);
                cmdResultTrans.Parameters.AddWithValue("@ID_PROGRAMA", id_programa);
                cmdResultTrans.Parameters.AddWithValue("@ID_GRUPO2", id_grupo);
                cmdResultTrans.CommandType = CommandType.Text;
                filasAfectadas += cmdResultTrans.ExecuteNonQuery();

                //ACTUALIZA LOS RESULTADOS TECNICOS
                SqlCommand cmdResultTecs = new SqlCommand(SQL_ResultTecs, conexion.GetConexion, trans);
                cmdResultTecs.Parameters.AddWithValue("@ID_GRUPO", id_grupo);
                cmdResultTecs.Parameters.AddWithValue("@ID_PROGRAMA", id_programa);
                cmdResultTecs.Parameters.AddWithValue("@ID_GRUPO2", id_grupo);
                cmdResultTecs.CommandType = CommandType.Text;
                filasAfectadas += cmdResultTecs.ExecuteNonQuery();
                

                trans.Commit();

                cmdResultTrans.Parameters.Clear();
                cmdResultTrans.Dispose();

                cmdResultTecs.Dispose();
                cmdResultTecs.Parameters.Clear();
                return filasAfectadas;
            }
            catch (Exception EX)
            {
                try
                {
                    trans.Rollback();
                }
                catch (Exception)
                {
                    
                    throw new Exception("Error al revertir la transacción");
                }
                throw new Exception(EX.Message + ": Error al actualizar la duración de los resultados");
            }
            finally
            {
                conexion.CerrarConexion();
            }
        }
        public static DataTable ListadoDeGrupos1( string id)
        {
            string cad = "";
            if (id.Equals(""))
            {
                cad = "SELECT GR.ID_GRUPO, GR.JORNADA, PR.NOMBRE_PROGRAMA, GR.TRIMESTRE_ACTUAL, AM.NOMBRE_AMBIENTE,ES.ESTADO FROM GRUPO AS GR LEFT JOIN PROGRAMA AS PR  ON GR.ID_PROGRAMA = PR.ID_PROGRAMA LEFT JOIN AMBIENTE AS AM ON GR.ID_AMBIENTE = AM.ID_AMBIENTE LEFT JOIN ESTADOgrupos AS ES ON GR.ID_ESTADO=ES.ID_ESTADO WHERE GR.ID_ESTADO=1  ORDER BY PR.ID_PROGRAMA";
            }
            else
            {
               cad = "SELECT GR.ID_GRUPO, GR.JORNADA, PR.NOMBRE_PROGRAMA, GR.TRIMESTRE_ACTUAL, AM.NOMBRE_AMBIENTE,ES.ESTADO FROM GRUPO AS GR LEFT JOIN PROGRAMA AS PR" +
               " ON GR.ID_PROGRAMA = PR.ID_PROGRAMA LEFT JOIN AMBIENTE AS AM ON GR.ID_AMBIENTE = AM.ID_AMBIENTE LEFT JOIN ESTADOgrupos AS ES ON GR.ID_ESTADO=ES.ID_ESTADO WHERE GR.ID_ESTADO=1 and PR.ID_PROGRAMA='"+id+"' ORDER BY PR.ID_PROGRAMA";
            }
            
            
            DataTable dt = new DataTable();
            ListadoDeGrupos(cad).Fill(dt);
            return dt;
        }

        private static SqlDataAdapter ListadoDeGrupos( string query)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter(query, Conexion.CadenaDeConexion);
              
                return da;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public static DataTable ListarEstado()
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM ESTADOGRUPOS", Conexion.CadenaDeConexion);
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
