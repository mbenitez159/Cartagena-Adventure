using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Sql;
using System.Data.SqlClient;

namespace Ej_Interfaz_Proyecto.GestionHorario
{
    class ControlHorario
    {
        private SqlDataReader leer;
        private SqlCommand ejecutar1;
        private Conexion conectar = new Conexion();
        private String Sql = "";

        public List<Clases_1280x1024.Area> TodasLasAreas() {
            List<Clases_1280x1024.Area> ta = new List<Clases_1280x1024.Area>();
            Sql = "select * from AREAS";
            try {
                conectar.AbrirConexion();
                ejecutar1 = new SqlCommand(Sql, conectar.GetConexion);
                leer = ejecutar1.ExecuteReader();
                while (leer.Read()) {
                    Clases_1280x1024.Area t =new Clases_1280x1024.Area();
                    t.Codigo=leer[0].ToString();
                    t.Nombre=leer[1].ToString();
                    ta.Add(t);
                }
                leer.Close();
            }catch(SqlException){}
            return ta;
        }

        public List<Clases_1280x1024.Ambientes> TodasLosAmbientes(String idarea)
        {
            List<Clases_1280x1024.Ambientes> ta = new List<Clases_1280x1024.Ambientes>();
            Sql = "select * from AMBIENTE where AMBIENTE.ID_AREA ='"+idarea +"'";
            try
            {
                conectar.AbrirConexion();
                ejecutar1 = new SqlCommand(Sql, conectar.GetConexion);
                leer = ejecutar1.ExecuteReader();
                while (leer.Read())
                {
                    Clases_1280x1024.Ambientes t = new Clases_1280x1024.Ambientes();
                    t.Id_ambiente = leer[0].ToString();
                    t.Nombre = leer[1].ToString();
                    t.Descripcion = leer[2].ToString();
                    t.Capacidad =Convert.ToInt16( leer[3].ToString());
                    t.Area = Convert.ToInt16(leer[4].ToString());
                    t.Id_area = leer[5].ToString();
                    ta.Add(t);
                }
                leer.Close();
            }
            catch (SqlException) { }
            return ta;
        }

        public List<Clases_1280x1024.Grupos> TodasLosGrupos(String idambiente)
        {
            List<Clases_1280x1024.Grupos> ta = new List<Clases_1280x1024.Grupos>();
            Sql = "select * from GRUPO where GRUPO.ID_AMBIENTE = '" + idambiente + "'";
            try
            {
                conectar.AbrirConexion();
                ejecutar1 = new SqlCommand(Sql, conectar.GetConexion);
                leer = ejecutar1.ExecuteReader();
                while (leer.Read())
                {
                    Clases_1280x1024.Grupos t = new Clases_1280x1024.Grupos();
                    t.Id_grupo = leer[0].ToString();
                    t.Jornada = leer[1].ToString();
                    t.Id_Programa = leer[2].ToString();
                    t.TrimestreActual = leer[3].ToString();
                    t.Id_Ambiente = leer[4].ToString();
                    t.Id_Estado = leer[5].ToString();
                    ta.Add(t);
                }
                leer.Close();
            }
            catch (SqlException) { }
            return ta;
        }

        public Clases_1280x1024.Grupos UnGrupos(String idgrupo)
        {
            Sql = "select * from GRUPO where GRUPO.ID_GRupo = '" + idgrupo + "'";

            Clases_1280x1024.Grupos t = null;
            try
            {
                conectar.AbrirConexion();
                ejecutar1 = new SqlCommand(Sql, conectar.GetConexion);
                leer = ejecutar1.ExecuteReader();
                while (leer.Read())
                {
                    t = new Clases_1280x1024.Grupos();
                    t.Id_grupo = leer[0].ToString();
                    t.Jornada = leer[1].ToString();
                    t.Id_Programa = leer[2].ToString();
                    t.TrimestreActual = leer[3].ToString();
                    t.Id_Ambiente = leer[4].ToString();
                    t.Id_Estado = leer[5].ToString();
                    t.FechaInicio = leer[6].ToString();
               }
                leer.Close();
            }
            catch (SqlException) { }
            return t;
        }

        public List<Resultados> TodosLosResultadosdeCompetencia(String idcomp, String grupo, string tri)
        {
            List<Resultados> rt = new List<Resultados>();
            List<String> lr = new List<String>();
            
            Sql = "SELECT ID_RESULTADO FROM HORARIO WHERE ID_GRUPO = '" + grupo + "'";
            try
            {
                conectar.AbrirConexion();
                ejecutar1 = new SqlCommand(Sql, conectar.GetConexion);
                leer = ejecutar1.ExecuteReader();
                while (leer.Read())
                {
                    lr.Add(leer[0].ToString());
                }
                leer.Close();
                conectar.CerrarConexion();
            }
            catch (Exception ex) { System.Windows.Forms.MessageBox.Show(""+ex); }


            Sql = "SELECT r.ID, r.DESCRIPCION,r.ID_COMPETENCIA,t.duracion FROM RESULTADOS r, trimestre t WHERE ID_COMPETENCIA = '" + idcomp + "' and r.ID=t.idresultado and t.trimestre=" + tri + "";
            try
            {
                conectar.AbrirConexion();
                ejecutar1 = new SqlCommand(Sql, conectar.GetConexion);
                leer = ejecutar1.ExecuteReader();
                while (leer.Read())
                {
                    Resultados t = new Resultados();
                    t.Codigo = leer[0].ToString();
                    t.Descripcion = leer[1].ToString();
                    t.ID_Competencia = leer[2].ToString();
                    t.Duracion = leer[3].ToString();
                    int o = 0;
                    int up = 0;
                    
                    for (int i = 0; i < lr.Count; i++)
                        if (lr[i] == t.Codigo) {
                            up++;
                                 }

                  if ((up*12) < Convert.ToInt16(t.Duracion))
                        rt.Add(t);

                }
                leer.Close();
                conectar.CerrarConexion();
            }
            catch (SqlException) { }



            return rt;

        }
        private Boolean conprovar(string grupo,string idResultado)
        {
            Boolean comp = false;
            if (string.IsNullOrEmpty(ejecutar("select cast(t.DURACION as varchar(40)) from TIEMPO_RESULTADOS t, RESULTADOS r  where t.ID_RESULTADO=r.ID and ID_GRUPO=" + grupo + " and  r.DESCRIPCION='" + idResultado + "' ")))
            {
                comp = false;
            }
            else  if (int.Parse(ejecutar("select cast(t.DURACION as varchar(40)) from TIEMPO_RESULTADOS t, RESULTADOS r  where t.ID_RESULTADO=r.ID and ID_GRUPO=" + grupo + " and  r.DESCRIPCION='" + idResultado + "' ")) > 0)
            {
                comp = true;
            }

            return comp;
        }
        
        public Resultados UnResultadosdeCompetencia(String detll, string tri, string grupo)
        {
            Resultados t = null;
            Sql = "SELECT r.ID,r.DESCRIPCION,r.ID_COMPETENCIA,t.duracion FROM RESULTADOS r, trimestre t  WHERE DESCRIPCION = '" + detll + "' and t.idresultado=r.ID";
            if (!tri.Equals(null))
            {
                Sql = "SELECT r.ID,r.DESCRIPCION,r.ID_COMPETENCIA,t.duracion FROM RESULTADOS r, trimestre t  WHERE DESCRIPCION = '" + detll + "' and t.idresultado=r.ID and t.trimestre=" + tri + "";
            }
            if (conprovar(grupo,detll).Equals(true) && !string.IsNullOrEmpty(grupo))
            {
                Sql = "SELECT r.ID,r.DESCRIPCION,r.ID_COMPETENCIA,(select t.DURACION from TIEMPO_RESULTADOS t, RESULTADOS r   where r.ID=t.ID_RESULTADO and ID_GRUPO=" + grupo + " and r.DESCRIPCION='" + detll + "') FROM RESULTADOS r, trimestre t  WHERE DESCRIPCION = '" + detll + "' and t.idresultado=r.ID and t.trimestre=" + tri + "";
            }
            try
            {
                conectar.AbrirConexion();
                ejecutar1 = new SqlCommand(Sql, conectar.GetConexion);
                leer = ejecutar1.ExecuteReader();
                while (leer.Read())
                {
                    t = new Resultados();
                    t.Codigo = leer[0].ToString();
                    t.Descripcion = leer[1].ToString();
                    t.ID_Competencia = leer[2].ToString();
                    t.Duracion = leer[3].ToString(); 
                }
                leer.Close();
                conectar.CerrarConexion();
            }
            catch (SqlException) { }


            return t;

        }

        public int HorasRestantesdeResultado(String dett,string grupo) {
            int t = 0;
            Sql = "SELECT * FROM TIEMPO_RESULTADOS WHERE ID_RESULTADO = '" + UnResultadosdeCompetencia(dett,null,null).Codigo + "' AND ID_GRUPO = '"+grupo+"'";
            try
            {
                conectar.AbrirConexion();
                ejecutar1 = new SqlCommand(Sql, conectar.GetConexion);
                leer = ejecutar1.ExecuteReader();
                while (leer.Read())
                {
                    t= Convert.ToInt16(leer[2].ToString());
                }
                leer.Close();
                conectar.CerrarConexion();
            }
            catch (SqlException) { }
            return t;
        }

        //competencias
        public List<Competencias> TodosLasCompetenciasDeProgramaPorTrimestre(String prog,String tipo)
        {
            List<Competencias> ct = new List<Competencias>();


            Sql = "select * from COMPETENCIAS where  ID_PROGRAMA = '" + prog + "' and  TIPO ='"+tipo+"'";
            try
            {
                conectar.AbrirConexion();
                ejecutar1 = new SqlCommand(Sql, conectar.GetConexion);
                leer = ejecutar1.ExecuteReader();
                while (leer.Read())
                {
                    Competencias t = new Competencias();
                    t.Codigo = leer[0].ToString();
                    t.Descripcion = leer[1].ToString();
                    t.ID_Programa = leer[2].ToString();
                    t.Duracion = leer[3].ToString();                    
                    t.Tipo = leer[4].ToString();
                    ct.Add(t);
                }
                leer.Close();
            }
            catch (SqlException) { }
            return ct;
        }
        public List<Competencias> TodosLasCompetenciasDeProgramaPorTrimestre1(String trimestre, String tipo, string idprogram, string jornadaT)
        {
            List<Competencias> ct = new List<Competencias>();


            Sql = "select distinct  c.ID,c.DESCRIPCION,c.ID_PROGRAMA,c.DURACION,t.trimestre,c.TIPO from COMPETENCIAS c, RESULTADOS r,trimestre t where c.TIPO ='" + tipo + "' AND t.trimestre='" + trimestre + "' and c.ID=r.ID_COMPETENCIA and r.ID=t.idresultado and c.ID_PROGRAMA='" + idprogram + "'and t.jornada='"+jornadaT+"' ";
            try
            
            {
                conectar.AbrirConexion();
                ejecutar1 = new SqlCommand(Sql, conectar.GetConexion);
                leer = ejecutar1.ExecuteReader();
                while (leer.Read())
                {
                    Competencias t = new Competencias();
                    t.Codigo = leer[0].ToString();
                    t.Descripcion = leer[1].ToString();
                    t.ID_Programa = leer[2].ToString();
                    t.Duracion = leer[3].ToString();
                    t.Trimestre = leer[4].ToString();
                    t.Tipo = leer[5].ToString();
                    ct.Add(t);
                }
                leer.Close();
            }
            catch (SqlException) { }
            return ct;
        }
        public List<Instructor> TodosLosInstructores(String detll , String fechavalidacion) {
            List<Instructor> li = new List<Instructor>();

            Sql = "select Instructor.* from Instructor,instructor_resultados where instructor.id_instructor = instructor_resultados.id_instructor and instructor_resultados.id_resultado = "+UnResultadosdeCompetencia(detll,null,null).Codigo;
            conectar.AbrirConexion();
            try
            {
                conectar.AbrirConexion();
                ejecutar1 = new SqlCommand(Sql, conectar.GetConexion);
                leer = ejecutar1.ExecuteReader();
                while (leer.Read())
                {
                    Instructor t = new Instructor();
                    t.Identificacion = leer[0].ToString();
                    t.Nombre = leer[1].ToString();
                    t.Direccion = leer[2].ToString();
                    t.Telefono = leer[3].ToString();
                    t.Celular = leer[4].ToString();
                    t.Email = leer[5].ToString();
                    t.Tipo = leer[6].ToString();
                    t.Profesion = leer[7].ToString();
                    t.ExpContrato = leer[9].ToString();

                    //fecha de fin intructor
                    int trim = Int16.Parse(t.ExpContrato.Split('-')[0]);//trimestre de fin
                    int anio = Int16.Parse(t.ExpContrato.Split('-')[1]);//anio de fin

                    //fecha a validar
                    int trim1 = Int16.Parse(fechavalidacion.Split('-')[0]);//trimestre de fin
                    int anio1 = Int16.Parse(fechavalidacion.Split('-')[1]);//anio de fin
                   /*
                    nota: la el contrato expira cuando finalisa el trimestre que dice en el contrato
                    
                    */

                    if (anio > anio1) 
                            li.Add(t);
                    else
                    if (anio == anio1) { // si el año de expiracion del contrato es mayor o igual al año a cursar
                        if (trim >= trim1) { // si el trimestre de expiracion es mayor o igual al trimestre a cursar
                            li.Add(t);
                        }
                    }
                    
                }
                leer.Close();
            }
            catch (SqlException) { }

            return li;
        }
        public string ID_instructor(string nombre){
            string devuelta = "select ID_INSTRUCTOR from INSTRUCTOR where NOMBRE ='" + nombre + "'";            
            return ejecutar(devuelta);
        }
        public string perido(string grupo, string trimestre)
        {
            string devuelta = "declare @a date=(select cast(g.INICIO as date) from GRUPO g where g.ID_GRUPO="+grupo+");declare @b date=(select DATEADD(day,-2,(select DATEADD(QUARTER,"+trimestre+",@a))));select cast(DATEPART(QUARTER,@b) as varchar(max))+'-'+cast(datepart(year,DATEADD(day,1,@b))as varchar(max))";
            return ejecutar(devuelta);
        }
        private string ejecutar(string consulta)
        {
            string retorname = "";
            try
            {
                
                Conexion c = new Conexion();
                c.AbrirConexion();
                SqlCommand cm = c.GetConexion.CreateCommand();
                cm.CommandText = consulta;
                SqlDataReader dr = cm.ExecuteReader();
                while (dr.Read())
                {
                    retorname = dr.GetString(0);
                }

                c.CerrarConexion();
              
            }
            catch (Exception)
            {

                
            }
            return retorname;
        }

    }
}
