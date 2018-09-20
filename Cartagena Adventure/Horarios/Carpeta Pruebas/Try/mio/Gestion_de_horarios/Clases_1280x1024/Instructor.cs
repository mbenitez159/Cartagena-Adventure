using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
namespace Ej_Interfaz_Proyecto.Clases_1280x1024
{
    class Instructor
    {
        private string identificacion;
        private string nombre;
        private string direccion;
        private string telefono;
        private string celular;
        private string email;
        private string tipo;
        private string profesion;
        private string exp_cont;

        private List<string> resultado_tecnico;
        private List<string> resultado_transversal;
        private List<string> areas;

         public string Exp_Contrato
        {
            set
            {
                this.exp_cont = value;
            }
        }

        public string Identificacion
        {
            set
            {
                this.identificacion = value;
            }
        }

        public string Nombre
        {
            set
            {
                this.nombre = value;
            }
        }

        public string Direccion
        {
            set
            {
                this.direccion = value;
            }
        }

        public string Telefono
        {
            set
            {
                this.telefono = value;
            }
        }

        public string Celular
        {
            set
            {
                this.celular = value;
            }
        }

        public string Email
        {
            set
            {
                this.email = value;
            }
        }

        public string Tipo
        {
            set
            {
                this.tipo = value;
            }
        }

        public string Profesion
        {
            set
            {
                this.profesion = value;
            }
        }
        public List<string> Areas 
        {
            set
            {
                this.areas = value;
            }
        }
        //////////////////////////////////////////
       

        public List<string> Resultado_tecnico
        {
            set
            {
                this.resultado_tecnico = value;
            }
        }

        public List<string> Resultado_transversal
        {
            set
            {
                this.resultado_transversal = value;
            }
        }
        //////////////////////////////////////////

        public bool VerificarIdentificacion()
        {
            bool existe = false;
            Int32 c=0;
            string SQL = "SELECT COUNT(*) FROM Instructor WHERE ID_INSTRUCTOR = @ID";
            Conexion conexion = new Conexion();
            try
            {
                conexion.AbrirConexion();
                SqlCommand cmdConsulta = new SqlCommand(SQL, conexion.GetConexion);
                cmdConsulta.Parameters.AddWithValue("@ID", identificacion);
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

        public void Registrar()
        {

            string SQL;
            Conexion conexion = new Conexion();
            SqlTransaction transaction=null;
            try
            {
                ////////////////////////////////////////////Informacion instructor//////////////////////////////////////////////
                conexion.AbrirConexion();
                
                transaction = conexion.GetConexion.BeginTransaction();
               SQL = "INSERT INTO Instructor VALUES('"+identificacion+"', '"+nombre+"', '"+direccion+"', '"+telefono+"', '"+celular+"', '"+email+"', '"+tipo+"',"+profesion+", '" + null + "', '" + null + "')";
                SqlCommand cmdInstructor = new SqlCommand(SQL, conexion.GetConexion);

                cmdInstructor.Transaction = transaction;

                cmdInstructor.ExecuteNonQuery();

                
                cmdInstructor.Dispose();

                transaction.Commit();
            }
            catch (Exception ex)
            {
                try
                {
                    transaction.Rollback();
                }
                catch (Exception)
                {
                    
                    throw new Exception("Error de transacción");
                }
                throw new Exception(ex.Message);
            }
            finally
            {
                conexion.CerrarConexion();
            }
        }

        public void Modificar(string IdentificacionActual)
        {

            string SQL = "UPDATE Instructor SET ID_INSTRUCTOR = @ID, NOMBRE = @NOMBRE, DIRECCION = @DIRECCION, "
            + "TELEFONO = @TELEFONO, CELULAR=@CELULAR, EMAIL = @EMAIL, TIPO = @TIPO, ID_PROFESION = @PROFESION WHERE ID_INSTRUCTOR = @ID2";
            Conexion conexion = new Conexion();
            try
            {
                conexion.AbrirConexion();
                SqlCommand cmdConsulta = new SqlCommand(SQL, conexion.GetConexion);
                cmdConsulta.Parameters.AddWithValue("@ID", identificacion);
                cmdConsulta.Parameters.AddWithValue("@NOMBRE", nombre);
                cmdConsulta.Parameters.AddWithValue("@DIRECCION", direccion);
                cmdConsulta.Parameters.AddWithValue("@TELEFONO", telefono);
                cmdConsulta.Parameters.AddWithValue("@CELULAR", celular);
                cmdConsulta.Parameters.AddWithValue("@EMAIL", email);
                cmdConsulta.Parameters.AddWithValue("@TIPO", tipo);
                cmdConsulta.Parameters.AddWithValue("@PROFESION", profesion);
                
                cmdConsulta.Parameters.AddWithValue("@ID2", IdentificacionActual);
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

        public void Eliminar()
        {

            string SQL = "DELETE Instructor WHERE ID_INSTRUCTOR = @ID";
            Conexion conexion = new Conexion();
            try
            {
                conexion.AbrirConexion();
                SqlCommand cmdConsulta = new SqlCommand(SQL, conexion.GetConexion);
                cmdConsulta.Parameters.AddWithValue("@ID", identificacion);
                
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
      
        public static DataTable ListadoDeInstructores(BuscarInstructorPor criterio, string texto,bool tipo)
        {
            string SQL="";
            if(criterio==BuscarInstructorPor.Identificación)
            {
                if (tipo==true)
                {
                    SQL = "select i.ID_INSTRUCTOR as Identificación,i.NOMBRE as Nombre,i.CELULAR from instructor i where ID_INSTRUCTOR LIKE'" + texto + "%' order by ID_INSTRUCTOR";
                }
                else
                {
                    SQL = "SELECT ID_INSTRUCTOR, NOMBRE, DIRECCION, TELEFONO, CELULAR, " +
                  "EMAIL, TIPO, NOMBRE_PROFESION  FROM INSTRUCTOR LEFT JOIN PROFESION ON INSTRUCTOR.ID_PROFESION = PROFESION.ID_PROFESION WHERE ID_INSTRUCTOR LIKE @PARAM +'%' ORDER BY ID_INSTRUCTOR";
                }
               
            }
            else if(criterio==BuscarInstructorPor.Nombre)
            {
                if (tipo==true)
                {
                    SQL = "select i.ID_INSTRUCTOR as Identificación,i.NOMBRE as Nombre,i.CELULAR from instructor i where NOMBRE LIKE'"+texto+"%' order by Nombre";
                }
                else
                {
                    SQL = "SELECT ID_INSTRUCTOR, NOMBRE, DIRECCION, TELEFONO, CELULAR,  " +
                   "EMAIL, TIPO, NOMBRE_PROFESION  FROM INSTRUCTOR LEFT JOIN PROFESION ON INSTRUCTOR.ID_PROFESION = PROFESION.ID_PROFESION WHERE NOMBRE LIKE @PARAM +'%' ORDER BY ID_INSTRUCTOR";
                }
                
            }
            try
            {
                SqlDataAdapter da = new SqlDataAdapter(SQL, Conexion.CadenaDeConexion);
                da.SelectCommand.Parameters.AddWithValue("@PARAM", texto);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public void AsignarResultados(string tipoCompetencia)
        {

            string SQL;
            Conexion conexion = new Conexion();
         
            try
            {
                conexion.AbrirConexion();

                string SQLDELETE = "DELETE INSTRUCTOR_RESULTADOS WHERE ID_INSTRUCTOR=@ID";
                SqlCommand cmdDeleteInstructor_Resultados = new SqlCommand(SQLDELETE, conexion.GetConexion);
              //  cmdDeleteInstructor_Resultados.CommandType = CommandType.Text;
                cmdDeleteInstructor_Resultados.Parameters.AddWithValue("@ID", identificacion);
                cmdDeleteInstructor_Resultados.ExecuteNonQuery();
                cmdDeleteInstructor_Resultados.Parameters.Clear();
            
                if (tipoCompetencia.Equals("Tecnica")) 
                {
                    SQL = "INSERT INTO INSTRUCTOR_RESULTADOS (ID_INSTRUCTOR,ID_RESULTADO) VALUES(@ID_INSTRUCTOR, @RESULTADO_TECNICO)";
                    SqlCommand cmdInstructor_Resultados = new SqlCommand(SQL, conexion.GetConexion);

                    for (int i = 0; i < resultado_tecnico.Count; i++)
                    {
                        
                        cmdInstructor_Resultados.Parameters.AddWithValue("@ID_INSTRUCTOR", identificacion);
                        cmdInstructor_Resultados.Parameters.AddWithValue("@RESULTADO_TECNICO", resultado_tecnico[i]);
                        cmdInstructor_Resultados.CommandType = CommandType.Text;

                        cmdInstructor_Resultados.ExecuteNonQuery();

                        cmdInstructor_Resultados.Parameters.Clear();
                    }

                    cmdInstructor_Resultados.Dispose();
                }
                else   
                    if (tipoCompetencia.Equals("Transversal"))
                {
                    SQL = "INSERT INTO INSTRUCTOR_RESULTADOS (ID_INSTRUCTOR,ID_RESULTADO) VALUES(@ID_INSTRUCTOR, @RESULTADO_TRANSVERSAL)";
                    SqlCommand cmd = new SqlCommand(SQL, conexion.GetConexion);

                    for (int i = 0; i < resultado_transversal.Count; i++)
                    {
                        cmd.Parameters.AddWithValue("@ID_INSTRUCTOR", identificacion);
                        cmd.Parameters.AddWithValue("@RESULTADO_TRANSVERSAL", resultado_transversal[i]);
                        cmd.ExecuteNonQuery();

                        cmd.Parameters.Clear();
                    }

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
        }

        public static DataTable ListadoDeResultadosInstructores(string id)
        {
            string SQL1 = "";
            DataTable dt = new DataTable();
            SQL1 = "select res.ID AS CODIGO,res.DESCRIPCION AS RESULTADOS from dbo.RESULTADOS res inner join dbo.INSTRUCTOR_RESULTADOS INS_RES ON res.ID=INS_RES.ID_RESULTADO inner join instructor ins ON ins.ID_INSTRUCTOR=INS_RES.ID_INSTRUCTOR AND ins.ID_INSTRUCTOR=@ID_INSTRUCTOR";
            try
            {
                SqlDataAdapter da = new SqlDataAdapter(SQL1, Conexion.CadenaDeConexion);
                da.SelectCommand.Parameters.AddWithValue("@ID_INSTRUCTOR", id);
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return dt;
        }
        public DataTable EliminarResultado(string idInstru, string IdRes) {
            Conexion c= new Conexion();
            c.AbrirConexion();
            DataTable dt = new DataTable();
            SqlCommand cm = c.GetConexion.CreateCommand();
            cm.CommandText = "delete INSTRUCTOR_RESULTADOS where ID_INSTRUCTOR='"+idInstru+"' and ID_RESULTADO="+IdRes+"";
            cm.ExecuteNonQuery();
            c.CerrarConexion();
            return dt;        
        }


    }
}
