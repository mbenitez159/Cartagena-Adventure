using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using Ej_Interfaz_Proyecto.Clases_1280x1024;

namespace Ej_Interfaz_Proyecto.Formularios_1280x1024
{
    public partial class FrmDetallesHorario_1280x1024 : Form
    {
        // Declaraciones del API PARA MOVER EL FORMULARIO
        [System.Runtime.InteropServices.DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        //
        [System.Runtime.InteropServices.DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);


        SqlCommand consulta;
        Conexion conexion;
        TreeNode padre = null;
        TreeNode hijo = null;



        public FrmDetallesHorario_1280x1024(string id_horario)
        {
            InitializeComponent();

            conexion = new Conexion();

            conexion.AbrirConexion();

            consultar_detalle(id_horario);

            ListadoDeCompetencias(id_horario);

            this.BackColor = Color.FromArgb(4, 123, 117);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        public void consultar_detalle(string ID_HORARIO)
        {

        consulta = new SqlCommand("SELECT INSTRUCTOR.NOMBRE,GRUPO.ID_GRUPO,PROGRAMA.NOMBRE_PROGRAMA,AMBIENTE.NOMBRE_AMBIENTE FROM HORARIO,GRUPO,PROGRAMA,INSTRUCTOR,AMBIENTE Where HORARIO.ID_HORARIO=@ID_HORARIO AND GRUPO.ID_PROGRAMA=PROGRAMA.ID_PROGRAMA AND HORARIO.ID_INSTRUCTOR = INSTRUCTOR.ID_INSTRUCTOR AND HORARIO.ID_GRUPO=GRUPO.ID_GRUPO AND AMBIENTE.ID_AMBIENTE=HORARIO.ID_AMBIENTE", conexion.GetConexion);

        consulta.CommandType = CommandType.Text;

        consulta.Parameters.AddWithValue("@ID_HORARIO", ID_HORARIO);

        SqlDataReader reader = consulta.ExecuteReader();

        while (reader.Read())
        {
            
            TxtInstructor.Text = Convert.ToString(reader["NOMBRE"]);
            TxtPrograma.Text = Convert.ToString(reader["NOMBRE_PROGRAMA"]);
            TxtGrupo.Text = Convert.ToString(reader["ID_GRUPO"]);
            ambiente.Text = Convert.ToString(reader["NOMBRE_AMBIENTE"]);


        }
        reader.Close();


        }

        public void ListadoDeCompetencias(string ID_HORARIO)
        {
            try
            {
                string tipodecompetencia="tecnica";

                String SQL="";

                SqlDataAdapter da=null;


                SQL="SELECT distinct COMPETENCIAS_TECNICAS.ID_COMPETENCIA_TECNICA,COMPETENCIAS_TECNICAS.DESCRIPCION_TECNICA FROM HORARIO,RESULTADOS_PROGRAMADOS,COMPETENCIAS_TECNICAS,RESULTADOS_TECNICOS WHERE HORARIO.ID_HORARIO=RESULTADOS_PROGRAMADOS.ID_HORARIO AND RESULTADOS_PROGRAMADOS.ID_RESULTADO_TECNICO=RESULTADOS_TECNICOS.ID_RESULTADO_TECNICO AND COMPETENCIAS_TECNICAS.ID_COMPETENCIA_TECNICA=RESULTADOS_TECNICOS.ID_COMPETENCIA_TECNICA AND HORARIO.ID_HORARIO='" + ID_HORARIO + "'";
                   
                da = new SqlDataAdapter(SQL, Conexion.CadenaDeConexion);

                DataSet ds = new DataSet();

                da.Fill(ds, "fila");

                DataTable dt = ds.Tables["fila"];
        
                treeView1.Nodes.Clear();

                //MessageBox.Show(ds.Tables["fila"].Rows.Count.ToString());

                if (ds.Tables["fila"].Rows.Count==0)
                {
                    SQL = "SELECT distinct COMPETENCIAS_TRANSVERSALES.ID_COMPETENCIA_TRANSVERSAL,COMPETENCIAS_TRANSVERSALES.DESCRIPCION_TRANSVERSAL FROM HORARIO,RESULTADOS_PROGRAMADOS,COMPETENCIAS_TRANSVERSALES,RESULTADOS_TRANSVERSALES WHERE HORARIO.ID_HORARIO=RESULTADOS_PROGRAMADOS.ID_HORARIO AND RESULTADOS_PROGRAMADOS.ID_RESULTADO_TRANSVERSAL=RESULTADOS_TRANSVERSALES.ID_RESULTADO_TRANSVERSAL AND COMPETENCIAS_TRANSVERSALES.ID_COMPETENCIA_TRANSVERSAL=RESULTADOS_TRANSVERSALES.ID_COMPETENCIA_TRANSVERSAL AND HORARIO.ID_HORARIO='" + ID_HORARIO + "'";

                    da = new SqlDataAdapter(SQL, Conexion.CadenaDeConexion);

                    ds = new DataSet();

                    da.Fill(ds, "fila");

                    dt = ds.Tables["fila"];

                    tipodecompetencia = "transversal";
                }

                if (dt != null)
                {

                    foreach (DataRow dr in dt.Rows)
                    {


                        padre = new TreeNode(dr.ItemArray[1].ToString());

                        DataTable dthijo = ListadoDeResultados(dr.ItemArray[0].ToString(), ID_HORARIO, tipodecompetencia);

                        foreach (DataRow dr2 in dthijo.Rows)
                        {

                            hijo = new TreeNode(dr2.ItemArray[1].ToString());
                            padre.Nodes.Add(hijo);

                        }

                        treeView1.Nodes.Add(padre);


                    }

                }
                



            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable ListadoDeResultados(string id_competencia,string ID_HORARIO,string tipo)
        {
            SqlDataAdapter da;
            String SQL;

            if (tipo.Equals("tecnica"))
            {
                SQL="SELECT distinct RESULTADOS_TECNICOS.ID_RESULTADO_TECNICO,RESULTADOS_TECNICOS.DESCRIPCION_RESULTADO_TECNICO FROM HORARIO,RESULTADOS_PROGRAMADOS,COMPETENCIAS_TECNICAS,RESULTADOS_TECNICOS WHERE HORARIO.ID_HORARIO=RESULTADOS_PROGRAMADOS.ID_HORARIO AND RESULTADOS_PROGRAMADOS.ID_RESULTADO_TECNICO=RESULTADOS_TECNICOS.ID_RESULTADO_TECNICO AND COMPETENCIAS_TECNICAS.ID_COMPETENCIA_TECNICA=RESULTADOS_TECNICOS.ID_COMPETENCIA_TECNICA AND HORARIO.ID_HORARIO='"+ID_HORARIO+"' AND COMPETENCIAS_TECNICAS.ID_COMPETENCIA_TECNICA='"+id_competencia+"'";

            }
            else
            {
                SQL="SELECT distinct RESULTADOS_TRANSVERSALES.ID_RESULTADO_TRANSVERSAL,RESULTADOS_TRANSVERSALES.DESCRIPCION_RESULTADO_TRANSVERSAL FROM HORARIO,RESULTADOS_PROGRAMADOS,COMPETENCIAS_TRANSVERSALES,RESULTADOS_TRANSVERSALES WHERE HORARIO.ID_HORARIO=RESULTADOS_PROGRAMADOS.ID_HORARIO AND RESULTADOS_PROGRAMADOS.ID_RESULTADO_TRANSVERSAL=RESULTADOS_TRANSVERSALES.ID_RESULTADO_TRANSVERSAL AND COMPETENCIAS_TRANSVERSALES.ID_COMPETENCIA_TRANSVERSAL=RESULTADOS_TRANSVERSALES.ID_COMPETENCIA_TRANSVERSAL AND HORARIO.ID_HORARIO='"+ID_HORARIO+"' AND COMPETENCIAS_TRANSVERSALES.ID_COMPETENCIA_TRANSVERSAL='"+id_competencia+"'";


            }
            da = new SqlDataAdapter(SQL, Conexion.CadenaDeConexion);
            
            DataSet ds = new DataSet();

            da.Fill(ds, "fila");

            return ds.Tables["fila"];



        }

        public String tipo_de_competencia(string ID_COMPETENCIA)
        {
            String tipo="transversal";


            consulta = new SqlCommand("SELECT ID_COMPETENCIA_TECNICA FROM COMPETENCIAS_TECNICAS WHERE ID_COMPETENCIA_TECNICA=@ID_COMPETENCIA ", conexion.GetConexion);

            consulta.Parameters.AddWithValue("@ID_COMPETENCIA", ID_COMPETENCIA);

            consulta.CommandType = CommandType.Text;

            SqlDataReader reader = consulta.ExecuteReader();

            if (reader.Read())
            {

                tipo = "tecnica";


            }
            reader.Close();
            return tipo;
   
        }

        private void FrmDetallesHorario_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox4_MouseLeave(object sender, EventArgs e)
        {
            this.pictureBox4.Image = global::Ej_Interfaz_Proyecto.Properties.Resources.btn_cer_normal2;
        }

        private void pictureBox4_MouseMove(object sender, MouseEventArgs e)
        {
            this.pictureBox4.Image = global::Ej_Interfaz_Proyecto.Properties.Resources.btn_cer_focus2;
        }

        private void pictureBox3_MouseLeave(object sender, EventArgs e)
        {
            this.pictureBox3.Image = global::Ej_Interfaz_Proyecto.Properties.Resources.btn_min_normal2;
        }

        private void pictureBox3_MouseMove(object sender, MouseEventArgs e)
        {
            this.pictureBox3.Image = global::Ej_Interfaz_Proyecto.Properties.Resources.btn_min_focus2;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            //WindowState = FormWindowState.Minimized;
        }

        private void FrmDetallesHorario_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

     
     

    }
}
