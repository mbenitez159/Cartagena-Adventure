using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Ej_Interfaz_Proyecto.Clases_1280x1024
{
    class Programa_Formacion
    {
        private string codigo;
        private string nombre;
        private string duracion;
        private string nivel;
       // private List<string> ambientes;
        

        //public List<string> Ambientes
        //{
        //    set
        //    {
        //        this.ambientes = value;
        //    }
        //}
      

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

        public string Duracion
        {
            set
            {
                this.duracion = value;
            }
        }

    
        public string Nivel
        {
            set
            {
                this.nivel = value;
            }
        }

        public void Registrar()
        {

            string SQL = "INSERT INTO PROGRAMA VALUES(@ID, @NOMBRE, @DURACION,  @NIVEL)";
            Conexion conexion = new Conexion();
           // SqlTransaction transaction = null;
            try
            {
                conexion.AbrirConexion();
                //transaction = conexion.GetConexion.BeginTransaction();
                SqlCommand cmdPrograma = new SqlCommand(SQL, conexion.GetConexion);
               // cmdPrograma.Transaction = transaction;
                cmdPrograma.Parameters.AddWithValue("@ID", codigo);
                cmdPrograma.Parameters.AddWithValue("@NOMBRE", nombre);
                cmdPrograma.Parameters.AddWithValue("@DURACION", duracion);
                cmdPrograma.Parameters.AddWithValue("@NIVEL", nivel);


                cmdPrograma.CommandType = CommandType.Text;

                cmdPrograma.ExecuteNonQuery();

                cmdPrograma.Parameters.Clear();
                cmdPrograma.Dispose();

                ////////////AMBIENTES////////////////////////////
                //SQL = "INSERT INTO PROGRAMA_AMBIENTE VALUES(@ID_PROGRAMA, @ID_AMBIENTE)";
                //SqlCommand cmdAmbientes = new SqlCommand(SQL, conexion.GetConexion);
                //cmdAmbientes.Transaction = transaction;
                //for (int i = 0; i < ambientes.Count; i++)
                //{
                //    cmdAmbientes.Parameters.AddWithValue("@ID_PROGRAMA", codigo);
                //    cmdAmbientes.Parameters.AddWithValue("@ID_AMBIENTE", ambientes[i].ToString());
                //    cmdAmbientes.ExecuteNonQuery();

                //    cmdAmbientes.Parameters.Clear();
                //}

                //transaction.Commit();
         
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

        public static string devueltaconnivel(string id)
        {
            
            string a = null;
            Conexion conexion = new Conexion();
            conexion.AbrirConexion();
            try
            {
                SqlCommand cm = new SqlCommand("select n.NOMBRE_NIVEL from NIVELPROGRAMA n where ID=" +id+" ", conexion.GetConexion);
                a = cm.ExecuteScalar().ToString();
            }
            catch (Exception ex)
            {
               throw new Exception(ex.Message);
            }
            return a;

        }
        public bool VerificarCodigo()
        {
            bool existe = false;
            Int32 c = 0;
            string SQL = "SELECT COUNT(*) FROM PROGRAMA WHERE ID_PROGRAMA = @ID";
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

        public static DataTable ListadoGeneralDeProgramas()
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT ID_PROGRAMA, NOMBRE_PROGRAMA, DURACION_PROGRAMA,n.NOMBRE_NIVEL as ID_NIVEL FROM PROGRAMA, NIVELPROGRAMA n where ID_NIVEL=n.ID ORDER BY NOMBRE_PROGRAMA", Conexion.CadenaDeConexion);
                
                DataTable dt = new DataTable();
                
                da.Fill(dt);
                
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable ListadoParcialDeProgramas()
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

        public static DataTable ListadoIncrementalDeProgramas(string tipoParametro, string texto)
        {
            Conexion conexion = new Conexion();
            
            string SQL = "";

            if (tipoParametro == "Id")
            {
                SQL = "SELECT ID_PROGRAMA, NOMBRE_PROGRAMA, DURACION_PROGRAMA, NOMBRE_NIVEL FROM PROGRAMA LEFT JOIN NIVELPROGRAMA ON NIVELPROGRAMA.ID = PROGRAMA.ID_NIVEL WHERE ID_PROGRAMA LIKE'" + texto + "%' ORDER BY ID_PROGRAMA";
            }
            else if (tipoParametro == "Nombre")
            {
                SQL = "SELECT ID_PROGRAMA, NOMBRE_PROGRAMA, DURACION_PROGRAMA, NOMBRE_NIVEL FROM PROGRAMA LEFT JOIN NIVELPROGRAMA ON NIVELPROGRAMA.ID = PROGRAMA.ID_NIVEL WHERE NOMBRE_PROGRAMA LIKE'" + texto + "%' ORDER BY ID_PROGRAMA";
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


        public void Modificar(string CodigoActual)
        {

            string SQL = "UPDATE PROGRAMA SET ID_PROGRAMA = @ID, NOMBRE_PROGRAMA = @NOMBRE, DURACION_PROGRAMA = @DURACION, "
            + "ID_NIVEL = @NIVEL WHERE ID_PROGRAMA = @ID2";
            Conexion conexion = new Conexion();
            //SqlTransaction transaction = null;
            try
            {
                conexion.AbrirConexion();
              //  transaction = conexion.GetConexion.BeginTransaction();

                SqlCommand cmdPrograma = new SqlCommand(SQL, conexion.GetConexion);
               // cmdPrograma.Transaction = transaction;

                cmdPrograma.Parameters.AddWithValue("@ID", codigo);
                cmdPrograma.Parameters.AddWithValue("@NOMBRE", nombre);
                cmdPrograma.Parameters.AddWithValue("@DURACION", duracion);
                cmdPrograma.Parameters.AddWithValue("@NIVEL", nivel);
                cmdPrograma.Parameters.AddWithValue("@ID2", CodigoActual);
                cmdPrograma.CommandType = CommandType.Text;

                cmdPrograma.ExecuteNonQuery();

                cmdPrograma.Parameters.Clear();
                cmdPrograma.Dispose();

                //////////////////////////Ambientes//////////////////////////
                //SQL = "DELETE FROM PROGRAMA_AMBIENTE WHERE ID_PROGRAMA = @ID_PROGRAMA";
                //SqlCommand cmdLimpiarAmbientes = new SqlCommand(SQL, conexion.GetConexion);
                //cmdLimpiarAmbientes.Transaction = transaction;
                //cmdLimpiarAmbientes.Parameters.AddWithValue("@ID_PROGRAMA", codigo);
                //cmdLimpiarAmbientes.ExecuteNonQuery();
                //cmdLimpiarAmbientes.Dispose();

                // SQL = "INSERT INTO PROGRAMA_AMBIENTE VALUES(@ID_PROGRAMA, @ID_AMBIENTE)";
                //SqlCommand cmdAmbientes = new SqlCommand(SQL, conexion.GetConexion);
                //cmdAmbientes.Transaction = transaction;
                //for (int i = 0; i < ambientes.Count; i++)
                //{
                //    cmdAmbientes.Parameters.AddWithValue("@ID_PROGRAMA", codigo);
                //    cmdAmbientes.Parameters.AddWithValue("@ID_AMBIENTE", ambientes[i].ToString());
                //    cmdAmbientes.ExecuteNonQuery();

                //    cmdAmbientes.Parameters.Clear();
                //}
                //cmdAmbientes.Dispose();
                //transaction.Commit();
         
              }
            catch (Exception ex)
            {
                //try
                //{
                //    transaction.Rollback();
                //}
                //catch (Exception)
                //{
                    
                //    throw new Exception("Error de transacción");
                //}
                throw new Exception(ex.Message);
            }
            finally
            {
                conexion.CerrarConexion();
            }

        }

        public static DataTable ListadoCompetenciasProgramas(string idPrograma)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT CO.ID_COMPETENCIA, CO.DESCRIPCION FROM PROGRAMA AS PR JOIN PROGRAMA_COMPETENCIA AS PRCO " +
                    "ON PR.ID_PROGRAMA = PRCO.ID_PROGRAMA JOIN COMPETENCIA AS CO ON PRCO.ID_COMPETENCIA = CO.ID_COMPETENCIA WHERE PR.ID_PROGRAMA = @ID", Conexion.CadenaDeConexion);
                da.SelectCommand.Parameters.AddWithValue("@ID", idPrograma);
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
