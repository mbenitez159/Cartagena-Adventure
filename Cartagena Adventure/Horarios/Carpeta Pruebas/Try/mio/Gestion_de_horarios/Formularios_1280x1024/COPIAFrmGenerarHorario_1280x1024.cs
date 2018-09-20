 using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Threading;
using Ej_Interfaz_Proyecto.FrmMinimizados_1280x1024;
using Ej_Interfaz_Proyecto.Clases_1280x1024;


namespace Ej_Interfaz_Proyecto.Formularios_1280x1024
{
    public partial class FrmGenerarHorario_1280x1024 : Form
    {
        public int pos = 0;
        public int posM = 0;
        SqlCommand consulta, consulta2;
        SqlDataAdapter da;
        DataSet ds;
        Conexion conexion;
        string id_competencia = "";
        string id_grupo = "";
        TreeNode padre = null;
        TreeNode hijo = null;
        int columna = 0;
        int fila = 0;
        string dia,rango;
        int cantidadResultado = 0;
        FrmPrincipal_1280x1024 principal;
        Thread Hi;
        Boolean hilo = false;

        // Declaraciones del API PARA MOVER EL FORMULARIO
        [System.Runtime.InteropServices.DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        //
        [System.Runtime.InteropServices.DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        public FrmGenerarHorario_1280x1024(FrmPrincipal_1280x1024 principal)
        {
            InitializeComponent();
            this.principal = principal;
            conexion = new Conexion();
            CheckForIllegalCrossThreadCalls = false;


            this.button1.ForeColor = Color.FromArgb(4, 123, 117);
            this.button2.ForeColor = Color.FromArgb(4, 123, 117);
            this.button3.ForeColor = Color.FromArgb(4, 123, 117);
            this.BackColor = Color.FromArgb(4, 123, 117);
        }

        private void FrmProgramacionResultados_Load(object sender, EventArgs e)
        {

            cargar_rangos();

            dataGridViewActivado();

            conexion = new Conexion();

            conexion.AbrirConexion();

            cargar_areas();

            LimpiarSeleccion();



        }

        public void dataGridViewActivado()
        {
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                for (int x = 1; x <= 6; x++)
                {

                    dataGridView1.Rows[i].Cells[x].Style.BackColor = Color.White;
                    dataGridView1.Rows[i].Cells[x].Style.SelectionBackColor = Color.White;
                    dataGridView1.Rows[i].Cells[x].Style.ForeColor = Color.White;
                    dataGridView1.Rows[i].Cells[x].Style.SelectionForeColor = Color.White;
                }

            }


        }
        public void quitarseleccion(TreeViewEventArgs e)
        {

        for (int x = 0; x < e.Node.Nodes.Count; x++)
        {
                e.Node.Nodes[x].BackColor = Color.White;
                e.Node.Nodes[x].ForeColor = Color.Black;

        }

        }


        private void LimpiarSeleccion()
        {
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                dataGridView1.Rows[i].Selected = false;
            }
        }

        public void cargar_rangos()
        {
            this.dataGridView1.Rows.Add("07:00 - 08:00");
            this.dataGridView1.Rows.Add("08:00 - 09:00");
            this.dataGridView1.Rows.Add("09:00 - 10:00");
            this.dataGridView1.Rows.Add("10:00 - 11:00");
            this.dataGridView1.Rows.Add("11:00 - 12:00");
            this.dataGridView1.Rows.Add("12:00 - 13:00");
            this.dataGridView1.Rows.Add("13:00 - 14:00");
            this.dataGridView1.Rows.Add("14:00 - 15:00");
            this.dataGridView1.Rows.Add("15:00 - 16:00");
            this.dataGridView1.Rows.Add("16:00 - 17:00");
            this.dataGridView1.Rows.Add("17:00 - 18:00");
            this.dataGridView1.Rows.Add("18:00 - 19:00");
            this.dataGridView1.Rows.Add("19:00 - 20:00");
            this.dataGridView1.Rows.Add("20:00 - 21:00");
            this.dataGridView1.Rows.Add("21:00 - 22:00");


        }


        public void cargar_areas()
        {
            conexion.AbrirConexion();
            consulta = new SqlCommand("SELECT ID,NOMBRE FROM AREAS", conexion.GetConexion);

            consulta.CommandType = CommandType.Text;

            da = new SqlDataAdapter(consulta);

            ds = new DataSet();

            da.Fill(ds, "AREAS");

            CbxArea.DataSource = ds.Tables[0];

            CbxArea.DisplayMember = "NOMBRE";

            CbxArea.ValueMember = "ID";

            CbxArea.SelectedIndex = -1;

        }

        public void cargar_instructores(string tipo)
        {
            String consultasql="";
            
            conexion.AbrirConexion();
            
            if(tipo.Equals("Tecnico"))
            {

                consultasql ="SELECT distinct INSTRUCTOR.ID_INSTRUCTOR,INSTRUCTOR.NOMBRE FROM COMPETENCIAS_TECNICAS,RESULTADOS_TECNICOS,INSTRUCTOR_RESULTADOS,INSTRUCTOR,PROGRAMA,GRUPO WHERE PROGRAMA.ID_PROGRAMA=COMPETENCIAS_TECNICAS.ID_PROGRAMA AND COMPETENCIAS_TECNICAS.ID_COMPETENCIA_TECNICA=RESULTADOS_TECNICOS.ID_COMPETENCIA_TECNICA AND RESULTADOS_TECNICOS.ID_RESULTADO_TECNICO=INSTRUCTOR_RESULTADOS.RESULTADO_TECNICO AND INSTRUCTOR_RESULTADOS.ID_INSTRUCTOR=INSTRUCTOR.ID_INSTRUCTOR AND GRUPO.ID_PROGRAMA=PROGRAMA.ID_PROGRAMA AND GRUPO.ID_GRUPO='" + CbxGrupos.GetItemText(CbxGrupos.SelectedValue) + "'";

            }
            else if (tipo == "Transversal")
            {

                consultasql="SELECT distinct INSTRUCTOR.ID_INSTRUCTOR,INSTRUCTOR.NOMBRE FROM PROGRAMA_COMPETENCIAS_TRANSVERSALES,COMPETENCIAS_TRANSVERSALES,RESULTADOS_TRANSVERSALES,INSTRUCTOR_RESULTADOS,INSTRUCTOR,PROGRAMA,GRUPO WHERE PROGRAMA.ID_PROGRAMA=PROGRAMA_COMPETENCIAS_TRANSVERSALES.ID_PROGRAMA AND PROGRAMA_COMPETENCIAS_TRANSVERSALES.ID_COMPETENCIA_TRANSVERSAL=COMPETENCIAS_TRANSVERSALES.ID_COMPETENCIA_TRANSVERSAL AND COMPETENCIAS_TRANSVERSALES.ID_COMPETENCIA_TRANSVERSAL=RESULTADOS_TRANSVERSALES.ID_COMPETENCIA_TRANSVERSAL AND RESULTADOS_TRANSVERSALES.ID_RESULTADO_TRANSVERSAL=INSTRUCTOR_RESULTADOS.RESULTADO_TRANSVERSAL AND INSTRUCTOR_RESULTADOS.ID_INSTRUCTOR=INSTRUCTOR.ID_INSTRUCTOR AND GRUPO.ID_PROGRAMA=PROGRAMA.ID_PROGRAMA AND GRUPO.ID_GRUPO='" + CbxGrupos.GetItemText(CbxGrupos.SelectedValue) + "'";


            }

            consulta = new SqlCommand(consultasql, conexion.GetConexion);
           
            da = new SqlDataAdapter(consulta);

            ds = new DataSet();

            da.Fill(ds, "INSTRUCTOR");

            CbxInstructores.DataSource = ds.Tables[0];

            CbxInstructores.DisplayMember = "NOMBRE";

            CbxInstructores.ValueMember = "ID_INSTRUCTOR";

            CbxInstructores.SelectedIndex = -1;

            CbxInstructores.Enabled = true;

        }

        private void CbxArea_SelectionChangeCommitted(object sender, EventArgs e)
        {
            limpiar_bloquear_datagri();

            dataGridViewActivado();

            limpiarCamposTexto();

            CbxAmbiente.SelectedIndex = -1;

            comboBox1.SelectedIndex = -1;

            CbxInstructores.SelectedIndex = -1;

            CbxGrupos.SelectedIndex = -1;
            
            cargar_ambientes();

            horas.Text = "0";
            cantidadResultado = 0;

        }

        public void cargar_ambientes()
        {

            consulta = new SqlCommand("SELECT AMBIENTE.ID_AMBIENTE, AMBIENTE.NOMBRE_AMBIENTE FROM AMBIENTE,AREAS WHERE AMBIENTE.ID_AREA=AREAS.ID AND AREAS.ID='" + CbxArea.GetItemText(CbxArea.SelectedValue) + "'", conexion.GetConexion);

            da = new SqlDataAdapter(consulta);

            ds = new DataSet();

            da.Fill(ds, "NOMBRE_AMBIENTE");

            CbxAmbiente.DataSource = ds.Tables[0];

            CbxAmbiente.DisplayMember = "NOMBRE_AMBIENTE";

            CbxAmbiente.ValueMember = "ID_AMBIENTE";

            CbxAmbiente.SelectedIndex = -1;

            CbxAmbiente.Enabled = true;

        }


        public void cargar_grupos()
        {

            conexion.AbrirConexion();

            consulta = new SqlCommand("SELECT GRUPO.ID_GRUPO FROM AMBIENTE,GRUPO WHERE GRUPO.ID_AMBIENTE=AMBIENTE.ID_AMBIENTE AND AMBIENTE.ID_AMBIENTE='" + CbxAmbiente.GetItemText(CbxAmbiente.SelectedValue) + "'", conexion.GetConexion);

            da = new SqlDataAdapter(consulta);

            ds = new DataSet();

            da.Fill(ds, "GRUPO");

            CbxGrupos.DataSource = ds.Tables[0].DefaultView;

            CbxGrupos.ValueMember = "ID_GRUPO";

            CbxGrupos.SelectedIndex = -1;

            CbxGrupos.Enabled = true;

        }

        private void CbxPrograma_SelectionChangeCommitted(object sender, EventArgs e)
        {
            cargar_grupos();
            
            
        }

        private void CbxGrupos_SelectionChangeCommitted(object sender, EventArgs e)
        {
            limpiar_bloquear_datagri();

            limpiarCamposTexto();

            informacion_grupo();

            cambiar_estado_horario();

            dataGridViewActivado();

            comboBox1.Enabled = true;
            
            CbxInstructores.Enabled = true;

            comboBox1.SelectedIndex = -1;

            CbxInstructores.SelectedIndex = -1;

            cargar_horario(CbxAmbiente.SelectedValue.ToString());

            id_grupo = CbxGrupos.GetItemText(CbxGrupos.SelectedValue);

            horas.Text = "0";

            cantidadResultado = 0;

          
        }

        public void cambiar_estado_horario()
        {
        conexion.AbrirConexion();
        SqlCommand cmd = new SqlCommand("SELECT ID_HORARIO,TRIMESTRE FROM HORARIO,GRUPO WHERE GRUPO.ID_GRUPO=HORARIO.ID_GRUPO AND GRUPO.ID_GRUPO=@ID_GRUPO", conexion.GetConexion);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.AddWithValue("@ID_GRUPO", CbxGrupos.GetItemText(CbxGrupos.SelectedValue));

        SqlDataReader reader = cmd.ExecuteReader();

        while(reader.Read())
        {
            if (Convert.ToString(reader["TRIMESTRE"]) != CbxTrimestre.Text)
            {

                string SQL = "UPDATE HORARIO SET ESTADO = @ESTADO WHERE ID_HORARIO= @ID";

                    SqlCommand cmd2Consulta = new SqlCommand(SQL, conexion.GetConexion);
                    cmd2Consulta.Parameters.AddWithValue("@ID", Convert.ToString(reader["ID_HORARIO"]));
                    cmd2Consulta.Parameters.AddWithValue("@ESTADO", "Antiguo");
                    cmd2Consulta.CommandType = CommandType.Text;
                    cmd2Consulta.ExecuteNonQuery();
                    cmd2Consulta.Parameters.Clear();
                    cmd2Consulta.Dispose();
            }        
        }

        reader.Close();

        }

        public void informacion_grupo()
        {
            conexion.AbrirConexion();

            SqlCommand cmd = new SqlCommand("SELECT ID_GRUPO,JORNADA,TRIMESTRE_ACTUAL,NOMBRE_PROGRAMA FROM GRUPO,PROGRAMA WHERE GRUPO.ID_GRUPO=@ID_GRUPO AND PROGRAMA.ID_PROGRAMA=GRUPO.ID_PROGRAMA", conexion.GetConexion);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@ID_GRUPO", CbxGrupos.GetItemText(CbxGrupos.SelectedValue));

            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {

                CodigoGrupo.Text = Convert.ToString(reader["ID_GRUPO"]);
                Jornada.Text = Convert.ToString(reader["JORNADA"]);
                CbxTrimestre.SelectedItem = Convert.ToString(reader["TRIMESTRE_ACTUAL"]);
                textBox1.Text = Convert.ToString(reader["NOMBRE_PROGRAMA"]);


            }

            reader.Close();

        }

        public void ListadoDeCompetencias(string tipocompetencia)
        {
            string CONSULTASQL = "";
            conexion.AbrirConexion();

            if (tipocompetencia.Equals("Tecnico"))
            {


                CONSULTASQL = "SELECT distinct COMPETENCIAS_TECNICAS.ID_COMPETENCIA_TECNICA,COMPETENCIAS_TECNICAS.DESCRIPCION_TECNICA FROM GRUPO,DURACION_TECNICAS, COMPETENCIAS_TECNICAS,RESULTADOS_TECNICOS,INSTRUCTOR_RESULTADOS,INSTRUCTOR,PROGRAMA WHERE INSTRUCTOR.ID_INSTRUCTOR=INSTRUCTOR_RESULTADOS.ID_INSTRUCTOR AND INSTRUCTOR_RESULTADOS.RESULTADO_TECNICO=RESULTADOS_TECNICOS.ID_RESULTADO_TECNICO AND RESULTADOS_TECNICOS.ID_COMPETENCIA_TECNICA=COMPETENCIAS_TECNICAS.ID_COMPETENCIA_TECNICA AND INSTRUCTOR.ID_INSTRUCTOR='" + CbxInstructores.GetItemText(CbxInstructores.SelectedValue) + "' AND RESULTADOS_TECNICOS.ID_RESULTADO_TECNICO=DURACION_TECNICAS.ID_RESULTADO_TECNICO AND DURACION_TECNICAS.TIEMPO_RESTANTE IS NOT NULL AND DURACION_TECNICAS.ID_GRUPO=GRUPO.ID_GRUPO AND GRUPO.ID_GRUPO='" + CbxGrupos.GetItemText(CbxGrupos.SelectedValue) + "'";

            }
            else if (tipocompetencia.Equals("Transversal"))
            {

                CONSULTASQL = "SELECT distinct COMPETENCIAS_TRANSVERSALES.ID_COMPETENCIA_TRANSVERSAL,COMPETENCIAS_TRANSVERSALES.DESCRIPCION_TRANSVERSAL FROM GRUPO,DURACION_TRANSVERSAL,COMPETENCIAS_TRANSVERSALES,RESULTADOS_TRANSVERSALES,INSTRUCTOR_RESULTADOS,INSTRUCTOR,PROGRAMA WHERE INSTRUCTOR.ID_INSTRUCTOR=INSTRUCTOR_RESULTADOS.ID_INSTRUCTOR AND INSTRUCTOR_RESULTADOS.RESULTADO_TRANSVERSAL=RESULTADOS_TRANSVERSALES.ID_RESULTADO_TRANSVERSAL AND RESULTADOS_TRANSVERSALES.ID_COMPETENCIA_TRANSVERSAL=COMPETENCIAS_TRANSVERSALES.ID_COMPETENCIA_TRANSVERSAL AND INSTRUCTOR.ID_INSTRUCTOR='" + CbxInstructores.GetItemText(CbxInstructores.SelectedValue) + "' AND RESULTADOS_TRANSVERSALES.ID_RESULTADO_TRANSVERSAL=DURACION_TRANSVERSAL.ID_RESULTADO_TRANSVERSAL AND DURACION_TRANSVERSAL.TIEMPO_RESTANTE IS NOT NULL AND DURACION_TRANSVERSAL.ID_GRUPO=GRUPO.ID_GRUPO AND GRUPO.ID_GRUPO='" + CbxGrupos.GetItemText(CbxGrupos.SelectedValue) + "'";
            }


            try
            {

                SqlCommand consulta2 = new SqlCommand(CONSULTASQL, conexion.GetConexion);

                consulta2.CommandType = CommandType.Text;

                SqlDataAdapter da = new SqlDataAdapter(consulta2);

                DataSet ds = new DataSet();

                da.Fill(ds, "fila");

                DataTable dt = ds.Tables["fila"];

                treeView1.Nodes.Clear();

                if (dt != null)
                {

                    foreach (DataRow dr in dt.Rows)
                    {


                        padre = new TreeNode(dr.ItemArray[1].ToString());

                        DataTable dthijo = ListadoDeResultados(dr.ItemArray[0].ToString(), tipocompetencia);

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

        public DataTable ListadoDeResultados(string id_competencia,string tipocompetencia)
        {
            string CONSULTASQL = "";
            conexion.AbrirConexion();
            if (tipocompetencia.Equals("Tecnico"))
            {

                CONSULTASQL = "SELECT distinct RESULTADOS_TECNICOS.ID_RESULTADO_TECNICO,RESULTADOS_TECNICOS.DESCRIPCION_RESULTADO_TECNICO FROM GRUPO,DURACION_TECNICAS,COMPETENCIAS_TECNICAS,RESULTADOS_TECNICOS,INSTRUCTOR_RESULTADOS,INSTRUCTOR,PROGRAMA WHERE INSTRUCTOR.ID_INSTRUCTOR=INSTRUCTOR_RESULTADOS.ID_INSTRUCTOR AND INSTRUCTOR_RESULTADOS.RESULTADO_TECNICO=RESULTADOS_TECNICOS.ID_RESULTADO_TECNICO AND RESULTADOS_TECNICOS.ID_COMPETENCIA_TECNICA=COMPETENCIAS_TECNICAS.ID_COMPETENCIA_TECNICA AND INSTRUCTOR.ID_INSTRUCTOR='" + CbxInstructores.GetItemText(CbxInstructores.SelectedValue) + "' AND COMPETENCIAS_TECNICAS.ID_COMPETENCIA_TECNICA='" + id_competencia + "'  AND RESULTADOS_TECNICOS.ID_RESULTADO_TECNICO=DURACION_TECNICAS.ID_RESULTADO_TECNICO AND DURACION_TECNICAS.TIEMPO_RESTANTE IS NOT NULL AND DURACION_TECNICAS.ID_GRUPO=GRUPO.ID_GRUPO AND GRUPO.ID_GRUPO='" + CbxGrupos.GetItemText(CbxGrupos.SelectedValue) + "' ";

            }
            else if (tipocompetencia.Equals("Transversal"))
            {

                CONSULTASQL = "SELECT distinct RESULTADOS_TRANSVERSALES.ID_RESULTADO_TRANSVERSAL,RESULTADOS_TRANSVERSALES.DESCRIPCION_RESULTADO_TRANSVERSAL FROM GRUPO,DURACION_TRANSVERSAL,COMPETENCIAS_TRANSVERSALES,RESULTADOS_TRANSVERSALES,INSTRUCTOR_RESULTADOS,INSTRUCTOR,PROGRAMA WHERE INSTRUCTOR.ID_INSTRUCTOR=INSTRUCTOR_RESULTADOS.ID_INSTRUCTOR AND INSTRUCTOR_RESULTADOS.RESULTADO_TRANSVERSAL=RESULTADOS_TRANSVERSALES.ID_RESULTADO_TRANSVERSAL AND RESULTADOS_TRANSVERSALES.ID_COMPETENCIA_TRANSVERSAL=COMPETENCIAS_TRANSVERSALES.ID_COMPETENCIA_TRANSVERSAL AND INSTRUCTOR.ID_INSTRUCTOR='" + CbxInstructores.GetItemText(CbxInstructores.SelectedValue) + "' AND COMPETENCIAS_TRANSVERSALES.ID_COMPETENCIA_TRANSVERSAL='" + id_competencia + "'  AND RESULTADOS_TRANSVERSALES.ID_RESULTADO_TRANSVERSAL=DURACION_TRANSVERSAL.ID_RESULTADO_TRANSVERSAL AND DURACION_TRANSVERSAL.TIEMPO_RESTANTE IS NOT NULL AND DURACION_TRANSVERSAL.ID_GRUPO=GRUPO.ID_GRUPO AND GRUPO.ID_GRUPO='" + CbxGrupos.GetItemText(CbxGrupos.SelectedValue) + "'";
            }

            consulta = new SqlCommand(CONSULTASQL, conexion.GetConexion);

            consulta.CommandType = CommandType.Text;

            SqlDataAdapter da = new SqlDataAdapter(consulta);

            DataSet ds = new DataSet();

            da.Fill(ds, "fila"); 

            return ds.Tables["fila"];



        }

        private void button1_Click(object sender, EventArgs e)
        {

            ListResultados.Items.Add(treeView1.SelectedNode.Text);
        }

        private void CbxAmbiente_SelectionChangeCommitted(object sender, EventArgs e)
        {
            limpiar_bloquear_datagri();

            limpiarCamposTexto();

            dataGridViewActivado();

            comboBox1.SelectedIndex = -1;

            CbxInstructores.SelectedIndex = -1;

            CbxGrupos.SelectedIndex = -1;

            cargar_horario(CbxAmbiente.SelectedValue.ToString());

            cargar_grupos();

            horas.Text = "0";
            cantidadResultado = 0;
            
           
        }

        public void limpiarCamposTexto()
        {

            textBox1.Text = "";

            CodigoGrupo.Text = "";

            Jornada.Text = "";

            CbxTrimestre.SelectedIndex = -1;


        }

        public void limpiar_bloquear_datagri()
        {
            ListResultados.Items.Clear();

            treeView1.Nodes.Clear();

   

            for (int y = 0; y < dataGridView1.Rows.Count; y++)
            {
                for (int x = 1; x <= 6; x++)
                {
                    if (dataGridView1.Rows[y].Cells[x].Style.BackColor == Color.FromArgb(128, 128, 128))
                    {
                        dataGridView1.Rows[y].Cells[x].Style.BackColor = Color.White;
                        dataGridView1.Rows[y].Cells[x].Style.SelectionBackColor = Color.White;
                        dataGridView1.Rows[y].Cells[x].Style.ForeColor = Color.White;
                        dataGridView1.Rows[y].Cells[x].Style.SelectionForeColor = Color.White;
                    }


                }

            }

        }

        private void CbxInstructores_SelectionChangeCommitted(object sender, EventArgs e)
        {

            limpiar_bloquear_datagri();
            ListadoDeCompetencias(comboBox1.SelectedItem.ToString());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
    
            Boolean existe = false;

            conexion.AbrirConexion();

            for (int i = 0; i < ListResultados.Items.Count; i++) 
            {
                ListResultados.SelectedIndex = i;

                if (treeView1.SelectedNode.Text.Equals(ListResultados.Text))
                {

                    existe = true;
                }

            }

            if (existe == false)
            {
                if (treeView1.Nodes.Count>0)
                {
                    if (verificar_resultado(treeView1.SelectedNode.Text,comboBox1.SelectedItem.ToString()) == true)
                    {
                        if(comboBox1.SelectedItem.Equals("Tecnico")){

                        if (cantidadResultado == 0)
                        {
                            ListResultados.Items.Add(treeView1.SelectedNode.Text);
                            ListResultados.SetSelected(0, true);


                            consulta = new SqlCommand("SELECT RESULTADOS_TECNICOS.ID_RESULTADO_TECNICO,DURACION_TECNICAS.TIEMPO_RESTANTE FROM GRUPO, RESULTADOS_TECNICOS,DURACION_TECNICAS Where RESULTADOS_TECNICOS.DESCRIPCION_RESULTADO_TECNICO=@DESCRIPCION AND RESULTADOS_TECNICOS.ID_RESULTADO_TECNICO=DURACION_TECNICAS.ID_RESULTADO_TECNICO AND GRUPO.ID_GRUPO=DURACION_TECNICAS.ID_GRUPO AND GRUPO.ID_GRUPO=@ID_GRUPO", conexion.GetConexion);

                            // consulta = new SqlCommand("SELECT RESULTADOS_TRANSVERSALES.ID_RESULTADO_TRANSVERSAL,DURACION.TIEMPO_RESTANTE FROM RESULTADOS_TRANSVERSALES,GRUPO,DURACION Where DURACION.ID_RESULTADO_TRASNVERSAL=RESULTADOS_TRANSVERSALES.ID_RESULTADO_TRANSVERSAL AND RESULTADOS_TRANSVERSALES.DESCRIPCION_RESULTADO_TRANSVERSAL=@DESCRIPCION AND GRUPO.ID_GRUPO=DURACION.ID_GRUPO AND GRUPO.ID_GRUPO=@ID_GRUPO", conexion.AbrirConexion());

                            consulta.CommandType = CommandType.Text;

                            consulta.Parameters.AddWithValue("@DESCRIPCION", treeView1.SelectedNode.Text);
                            
                            consulta.Parameters.AddWithValue("@ID_GRUPO", CbxGrupos.GetItemText(CbxGrupos.SelectedValue));


                            SqlDataReader reader = consulta.ExecuteReader();

                            if (reader.Read())
                            {

                                horas.Text = Convert.ToString(reader["TIEMPO_RESTANTE"]);
                                id_competencia = Convert.ToString(reader["ID_RESULTADO_TECNICO"]);



                            }

                            reader.Close();

                            cantidadResultado = 1;

                        }
                        else
                        {
                            VentanaMsjes ventana = new VentanaMsjes("AVISO", "Solo se permite programar un resultado técnico");
                            ventana.iconoPregunta.Image = global::Ej_Interfaz_Proyecto.Properties.Resources.icn_inf;
                            ventana.btnAceptar.Visible = true;
                            ventana.ShowDialog();     
                        }


                        }
                        else if (comboBox1.SelectedItem.Equals("Transversal"))
                        {
                            if (cantidadResultado == 0)
                            {
                                ListResultados.Items.Add(treeView1.SelectedNode.Text);
                                ListResultados.SetSelected(0,true);

                                consulta = new SqlCommand("SELECT RESULTADOS_TRANSVERSALES.ID_RESULTADO_TRANSVERSAL,DURACION_TRANSVERSAL.TIEMPO_RESTANTE FROM GRUPO, RESULTADOS_TRANSVERSALES,DURACION_TRANSVERSAL Where RESULTADOS_TRANSVERSALES.DESCRIPCION_RESULTADO_TRANSVERSAL=@DESCRIPCION AND RESULTADOS_TRANSVERSALES.ID_RESULTADO_TRANSVERSAL=DURACION_TRANSVERSAL.ID_RESULTADO_TRANSVERSAL AND GRUPO.ID_GRUPO=DURACION_TRANSVERSAL.ID_GRUPO AND GRUPO.ID_GRUPO=@ID_GRUPO", conexion.GetConexion);

                               // consulta = new SqlCommand("SELECT RESULTADOS_TRANSVERSALES.ID_RESULTADO_TRANSVERSAL,DURACION.TIEMPO_RESTANTE FROM RESULTADOS_TRANSVERSALES,GRUPO,DURACION Where DURACION.ID_RESULTADO_TRASNVERSAL=RESULTADOS_TRANSVERSALES.ID_RESULTADO_TRANSVERSAL AND RESULTADOS_TRANSVERSALES.DESCRIPCION_RESULTADO_TRANSVERSAL=@DESCRIPCION AND GRUPO.ID_GRUPO=DURACION.ID_GRUPO AND GRUPO.ID_GRUPO=@ID_GRUPO", conexion.AbrirConexion());

                                consulta.CommandType = CommandType.Text;

                                consulta.Parameters.AddWithValue("@DESCRIPCION", treeView1.SelectedNode.Text);
                                consulta.Parameters.AddWithValue("@ID_GRUPO", CbxGrupos.GetItemText(CbxGrupos.SelectedValue));
                                

                                SqlDataReader reader = consulta.ExecuteReader();

                                if (reader.Read())
                                {

                                    horas.Text = Convert.ToString(reader["TIEMPO_RESTANTE"]);
                                    id_competencia = Convert.ToString(reader["ID_RESULTADO_TRANSVERSAL"]);



                                }

                                reader.Close();

                                cantidadResultado = 1;

                            }
                            else
                            {


                                VentanaMsjes ventana = new VentanaMsjes("AVISO", "Solo se permite programar un resultado transversal");
                                ventana.iconoPregunta.Image = global::Ej_Interfaz_Proyecto.Properties.Resources.icn_inf;
                                ventana.btnAceptar.Visible = true;
                                ventana.ShowDialog();
                            }
                            

                        }

                       
                    }
                    else
                    {
                        VentanaMsjes ventana = new VentanaMsjes("AVISO", "No se permite agregar la competencia");
                        ventana.iconoPregunta.Image = global::Ej_Interfaz_Proyecto.Properties.Resources.icn_inf;
                        ventana.btnAceptar.Visible = true;
                        ventana.ShowDialog();
                        

                    }

                   
                }            

            }
            else
            {
                VentanaMsjes ventana = new VentanaMsjes("AVISO", "El resultado ya fue agregado");
                ventana.iconoPregunta.Image = global::Ej_Interfaz_Proyecto.Properties.Resources.icn_inf;
                ventana.btnAceptar.Visible = true;
                ventana.ShowDialog();

                

            }
        }

        public Boolean verificar_resultado(string descripcion,string tiporesultado)
        {
            Boolean encontrado = false;
            conexion.AbrirConexion();

            if(tiporesultado.Equals("Tecnico"))
            {

                consulta = new SqlCommand(" SELECT ID_RESULTADO_TECNICO FROM RESULTADOS_TECNICOS WHERE DESCRIPCION_RESULTADO_TECNICO='" + descripcion + "'", conexion.GetConexion);
            }

            else if(tiporesultado.Equals("Transversal"))
            {
                consulta = new SqlCommand(" SELECT ID_RESULTADO_TRANSVERSAL FROM RESULTADOS_TRANSVERSALES WHERE DESCRIPCION_RESULTADO_TRANSVERSAL='" + descripcion + "'", conexion.GetConexion);

            }

           

            consulta.CommandType = CommandType.Text;

            SqlDataReader reader = consulta.ExecuteReader();

            if (reader.Read())
            {

            encontrado = true;

            }

            reader.Close();

            return encontrado;

        }


        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex > 0 && e.RowIndex>=0)
            {

                if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor == Color.White)
                {

                    DIA_RANGO(e.RowIndex, e.ColumnIndex);

                    if (CONSULTAR_DISPONIBILIDAD_INSTRUCTOR() == true)
                    {
                      
                            if (Convert.ToInt16(horas.Text) > 0)
                            {
                                dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.SelectionBackColor = Color.FromArgb(128, 128, 128);

                                dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.FromArgb(128, 128, 128);

                                dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.ForeColor = Color.FromArgb(128, 128, 128);

                                dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.SelectionForeColor = Color.FromArgb(128, 128, 128);

                                horas.Text = Convert.ToString(Convert.ToInt32(horas.Text) - 1);

                            }
                            else
                            {
                                if (ListResultados.SelectedIndex!=-1)
                                {

                                    VentanaMsjes ventana = new VentanaMsjes("AVISO", "La duración de la competencia llego a 0");
                                    ventana.iconoPregunta.Image = global::Ej_Interfaz_Proyecto.Properties.Resources.icn_inf;
                                    ventana.btnAceptar.Visible = true;
                                    ventana.ShowDialog();

                                
                                }
                            }
                        

                      
                    }
                    else
                    {

                        VentanaMsjes ventana = new VentanaMsjes("AVISO", "¿El Instructor No Se Encuentra Disponible. Desea Consultar Horario?");
                        ventana.btnSi.Visible = true;
                        ventana.btnNo.Visible = true;
                        ventana.iconoPregunta.Image = global::Ej_Interfaz_Proyecto.Properties.Resources.icn_pre;
                        DialogResult msgdresult = ventana.ShowDialog();



                        if (msgdresult.ToString().Equals("OK"))
                        {

                            FrmConsultarHorario_1280x1024 HORARIO = new FrmConsultarHorario_1280x1024(CbxInstructores.GetItemText(CbxInstructores.SelectedValue),principal);
                            HORARIO.MdiParent = principal;
                            HORARIO.Show();
                        }


                    }

                }
                else if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor == Color.FromArgb(4, 123, 117))
                {

                    dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.SelectionBackColor = Color.FromArgb(4, 123, 117);

                    dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.FromArgb(4, 123, 117);

                    dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.ForeColor = Color.FromArgb(4, 123, 117);

                    dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.SelectionForeColor = Color.FromArgb(4, 123, 117);

                }

                else
                {
                    
                    
                    dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.SelectionBackColor = Color.White;

                    dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.White;

                    dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "";

                    dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.ForeColor = Color.White;

                    dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.SelectionForeColor = Color.White;

                  

                        horas.Text = Convert.ToString(Convert.ToInt32(horas.Text) + 1);

                    

                }

            }
        }

        public void DIA_RANGO(int FILA, int COLUMNA)
        {
            if (FILA == 0)
            {

            rango = "07:00 - 08:00";

            }
            else if (FILA == 1)
            {
                rango = "08:00 - 09:00";
            }

            else if (FILA == 2)
            {
                rango = "09:00 - 10:00";
            }

            else if (FILA == 3)
            {
                rango = "10:00 - 11:00";
            }
            else if (FILA == 4)
            {
                rango = "11:00 - 12:00";
            }
            else if (FILA == 5)
            {
                rango = "12:00 - 13:00";
            }
            else if (FILA == 6)
            {
                rango = "13:00 - 14:00";
            }
            else if (FILA == 7)
            {
                rango = "14:00 - 15:00";
            }
            else if (FILA == 8)
            {
                rango = "15:00 - 16:00";
            }
            else if (FILA == 9)
            {
                rango = "16:00 - 17:00";
            }
            else if (FILA == 10)
            {
                rango = "17:00 - 18:00";
            }
            else if (FILA == 11)
            {
                rango = "18:00 - 19:00";
            }
            else if (FILA == 12)
            {
                rango = "19:00 - 20:00";
            }
            else if (FILA == 13)
            {
                rango = "20:00 - 21:00";
            }
            else if (FILA == 13)
            {
                rango = "21:00 - 22:00";
            }

            if(COLUMNA==1){

                dia = "Lunes";

            }
            else if(COLUMNA==2){
                dia = "Martes";

            }
            else if (COLUMNA == 3)
            {
                dia = "Miercoles";

            }

            else if (COLUMNA == 4)
            {
                dia = "Jueves";

            }
            else if (COLUMNA == 5)
            {
                dia = "Viernes";

            }
            else if (COLUMNA == 6)
            {
                dia = "Sabado";

            }

        }

        public Boolean CONSULTAR_DISPONIBILIDAD_INSTRUCTOR()
        {
            Boolean estado = true;

            conexion.AbrirConexion();

            consulta = new SqlCommand("SELECT PERIODO,DIA FROM HORARIO Where ID_INSTRUCTOR=@INSTRUCTOR AND ESTADO='Actual'", conexion.GetConexion);

            consulta.CommandType = CommandType.Text;

            consulta.Parameters.AddWithValue("@INSTRUCTOR", CbxInstructores.GetItemText(CbxInstructores.SelectedValue));

            SqlDataReader reader2 = consulta.ExecuteReader();
         

            while (reader2.Read())
            {
                if (Convert.ToString(reader2["PERIODO"]).Equals(rango))
                {

                    if (Convert.ToString(reader2["DIA"]).Equals(dia))
                    {
                   
                        estado = false;
                     
                    }

                }

            }


            reader2.Close();
     

            return estado;
        }

        public void cargar_horario(String ID_AMBIENTE)

        {
            // Llamamos al metodo AbrirConexion() de la clase Conexion
            
            conexion.AbrirConexion();
            
            // Realizamos la consulta a la base de datos
            
            consulta = new SqlCommand("SELECT ID_HORARIO,PERIODO,DIA FROM HORARIO Where ID_AMBIENTE=@ID_AMBIENTE AND ESTADO='ACTUAL'",               conexion.GetConexion);

            consulta.CommandType = CommandType.Text;
              
            // Le pasamos el parametro de la consulta 
            consulta.Parameters.AddWithValue("@ID_AMBIENTE", ID_AMBIENTE);
            
            // Creamos un objeto SqlDataReader Para Guardar lo que nos trae La Consulta
            SqlDataReader reader = consulta.ExecuteReader();
            
            // Recorremos el objeto SqlDataReader 
            while (reader.Read())
            {
                // Creamos una variable fila para definir en q fila de la tabla va hacer asignado dicho horario
                int fila = 0;
                
                // Creamos una variable columna para definir en q columna de la tabla va hacer asignado dicho horario
                int columna = 1;

                
                // Verificamos si el objeto reader Periodo = "07:00 - 08:00" de ser asi la fila tomaria el valor de 0
                if (Convert.ToString(reader["PERIODO"]).Equals("07:00 - 08:00"))
                {
                    fila = 0;

                }
                // Verificamos si el objeto reader Periodo = "08:00 - 09:00" de ser asi la fila tomaria el valor de 1 y asi sucesivamente
                // hasta la fila 14
                else if (Convert.ToString(reader["PERIODO"]).Equals("08:00 - 09:00"))
                {
                    fila = 1;
                }

                else if (Convert.ToString(reader["PERIODO"]).Equals("09:00 - 10:00"))
                {
                    fila = 2;
                }
                else if (Convert.ToString(reader["PERIODO"]).Equals("10:00 - 11:00"))
                {
                    fila = 3;
                }

                else if (Convert.ToString(reader["PERIODO"]).Equals("11:00 - 12:00"))
                {
                    fila = 4;
                }
                else if (Convert.ToString(reader["PERIODO"]).Equals("12:00 - 13:00"))
                {
                    fila = 5;
                }
                else if (Convert.ToString(reader["PERIODO"]).Equals("13:00 - 14:00"))
                {
                    fila = 6;
                }
                else if (Convert.ToString(reader["PERIODO"]).Equals("14:00 - 15:00"))
                {
                    fila = 7;
                }
                else if (Convert.ToString(reader["PERIODO"]).Equals("15:00 - 16:00"))
                {
                    fila = 8;
                }
                else if (Convert.ToString(reader["PERIODO"]).Equals("16:00 - 17:00"))
                {
                    fila = 9;
                }
                else if (Convert.ToString(reader["PERIODO"]).Equals("17:00 - 18:00"))
                {
                    fila = 10;
                }
                else if (Convert.ToString(reader["PERIODO"]).Equals("18:00 - 19:00"))
                {
                    fila = 11;
                }
                else if (Convert.ToString(reader["PERIODO"]).Equals("19:00 - 20:00"))
                {
                    fila = 12;
                }
                else if (Convert.ToString(reader["PERIODO"]).Equals("20:00 - 21:00"))
                {
                    fila = 13;
                }
                else if (Convert.ToString(reader["PERIODO"]).Equals("21:00 - 22:00"))
                {
                    fila = 14;
                }

                // Verificamos si el objeto reader DIA = "lunes" de ser asi la columna tomaria el valor de 1 y asi sucesivamente hasta
                // llegar al dia Sabado
                if (Convert.ToString(reader["DIA"]).Equals("lunes"))
                {
                    columna = 1;

                }

                else if (Convert.ToString(reader["DIA"]).Equals("Martes"))
                {
                    columna = 2;

                }
                else if (Convert.ToString(reader["DIA"]).Equals("Miercoles"))
                {
                    columna = 3;

                }
                else if (Convert.ToString(reader["DIA"]).Equals("Jueves"))
                {
                    columna = 4;

                }
                else if (Convert.ToString(reader["DIA"]).Equals("Viernes"))
                {
                    columna = 5;

                }
                else if (Convert.ToString(reader["DIA"]).Equals("Sabado"))
                {
                    columna = 6;

                }        

                //Asignamos al dataGridView1 la fila y la celda correspondiente de las condiciones anterios lo pasamos el id del horario
                // para poder hacer posteriores consulas

                dataGridView1.Rows[fila].Cells[columna].Value = Convert.ToString(reader["ID_HORARIO"]);
                
                //le asignamos a la celda el color rojo

                dataGridView1.Rows[fila].Cells[columna].Style.ForeColor = Color.FromArgb(4, 123, 117);

                dataGridView1.Rows[fila].Cells[columna].Style.SelectionForeColor = Color.FromArgb(4, 123, 117);

                dataGridView1.Rows[fila].Cells[columna].Style.BackColor = Color.FromArgb(4, 123, 117);


            }
            //cerramos el objeto reader
            reader.Close();


            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                for (int x = 1; x <= 6; x++)
                {

                    if (dataGridView1.Rows[i].Cells[x].Style.BackColor == Color.FromArgb(4, 123, 117))
                    {

                        dataGridView1.Rows[i].Cells[x].Style.SelectionBackColor = Color.FromArgb(4, 123, 117);

                        dataGridView1.Rows[i].Cells[x].Style.BackColor = Color.FromArgb(4, 123, 117);

                        dataGridView1.Rows[i].Cells[x].Style.ForeColor = Color.FromArgb(4, 123, 117);

                        dataGridView1.Rows[i].Cells[x].Style.SelectionForeColor = Color.FromArgb(4, 123, 117);

                    }
                }

            }

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        if(this.columna>0 && this.fila>=0){


            if (dataGridView1.Rows[this.fila].Cells[this.columna].Style.BackColor == Color.FromArgb(4, 123, 117))
            {

                FrmDetallesHorario_1280x1024 detalle = new FrmDetallesHorario_1280x1024(dataGridView1.Rows[this.fila].Cells[this.columna].Value.ToString());

                detalle.Show();

            }

            else if (dataGridView1.Rows[this.fila].Cells[this.columna].Style.BackColor == Color.FromArgb(128, 128, 128))
            {
                VentanaMsjes ventana2 = new VentanaMsjes("AVISO", "Guarde para ver los detalles");
                ventana2.iconoPregunta.Image = global::Ej_Interfaz_Proyecto.Properties.Resources.icn_inf;
                ventana2.btnAceptar.Visible = true;
                ventana2.ShowDialog();

                
            }

            else if (dataGridView1.Rows[this.fila].Cells[this.columna].Style.BackColor == Color.White)
            {

                VentanaMsjes ventana2 = new VentanaMsjes("AVISO", "Espacio sin asignar");
                ventana2.iconoPregunta.Image = global::Ej_Interfaz_Proyecto.Properties.Resources.icn_inf;
                ventana2.btnAceptar.Visible = true;
                ventana2.ShowDialog();

               

            }   

        }

        }

        private void dataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
               
                    this.columna = e.ColumnIndex;
                    this.fila = e.RowIndex;

                
               

            }


        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (CbxArea.SelectedIndex != -1)
            {
                if (CbxAmbiente.SelectedIndex != -1)
                {
                    if (CbxGrupos.SelectedIndex != -1)
                    {
                        if (CbxInstructores.SelectedIndex != -1)
                        {
                            if (ListResultados.Items.Count > 0)
                            {
                               
                                guardar_horario();
                                actualizar_competencia(comboBox1.SelectedItem.ToString());
                                horas.Text = "0";
                                cantidadResultado = 0;
                                comboBox1.SelectedIndex = -1;
                            }

                            else
                            {
                                VentanaMsjes ventana2 = new VentanaMsjes("AVISO", "Debe agregar uno o más resultados");
                                ventana2.iconoPregunta.Image = global::Ej_Interfaz_Proyecto.Properties.Resources.icn_inf;
                                ventana2.btnAceptar.Visible = true;
                                ventana2.ShowDialog();
                               
                            }
                       
                        }
                        else
                        {
                            VentanaMsjes ventana2 = new VentanaMsjes("AVISO", "Debe seleccionar el instructor");
                            ventana2.iconoPregunta.Image = global::Ej_Interfaz_Proyecto.Properties.Resources.icn_inf;
                            ventana2.btnAceptar.Visible = true;
                            ventana2.ShowDialog();

                           
                        }
                    }

                    else
                    {
                        VentanaMsjes ventana2 = new VentanaMsjes("AVISO", "Debe seleccionar un grupo");
                        ventana2.iconoPregunta.Image = global::Ej_Interfaz_Proyecto.Properties.Resources.icn_inf;
                        ventana2.btnAceptar.Visible = true;
                        ventana2.ShowDialog();
                       

                    }
      
                }
                else
                {
                    VentanaMsjes ventana2 = new VentanaMsjes("AVISO", "Debe seleccionar un ambiente");
                    ventana2.iconoPregunta.Image = global::Ej_Interfaz_Proyecto.Properties.Resources.icn_inf;
                    ventana2.btnAceptar.Visible = true;
                    ventana2.ShowDialog();
                    
                }

            }
            else
            {
                VentanaMsjes ventana2 = new VentanaMsjes("AVISO", "Debe seleccionar un área");
                ventana2.iconoPregunta.Image = global::Ej_Interfaz_Proyecto.Properties.Resources.icn_inf;
                ventana2.btnAceptar.Visible = true;
                ventana2.ShowDialog();

             
            }
                
        }

        public void actualizar_competencia(string tipo)
        {
            String consultasql = "";
            conexion.AbrirConexion();

            if (tipo.Equals("Tecnico"))
            {

                consultasql = "UPDATE DURACION_TECNICAS SET TIEMPO_RESTANTE = @TIEMPO WHERE ID_RESULTADO_TECNICO= @ID AND ID_GRUPO=@GRUPO";

            }
            else if (tipo == "Transversal")
            {

                consultasql = "UPDATE DURACION_TRANSVERSAL SET TIEMPO_RESTANTE = @TIEMPO WHERE ID_RESULTADO_TRANSVERSAL= @ID AND ID_GRUPO=@GRUPO";


            }

            //string SQL = "UPDATE DURACION_TECNICA SET TIEMPO_RESTANTE = @TIEMPO WHERE ID_COMPETENCIA_TECNICA= @ID AND ID_GRUPO=@GRUPO";
           
            try
            {

                SqlCommand cmdConsulta = new SqlCommand(consultasql, conexion.GetConexion);
                cmdConsulta.Parameters.AddWithValue("@ID", id_competencia);
                cmdConsulta.Parameters.AddWithValue("@TIEMPO", horas.Text);
                cmdConsulta.Parameters.AddWithValue("@GRUPO", id_grupo);
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

        public void guardar_horario()
        {
            String dia = "";
            Boolean registro = false;
            conexion.AbrirConexion();

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                for (int x = 1; x <= 6; x++)
                {
                    if (x == 1)
                    {
                        dia = "Lunes";
                    }
                    else if (x == 2)
                    {
                        dia = "Martes";
                    }
                    else if (x == 3)
                    {
                        dia = "Miercoles";
                    }
                    else if (x == 4)
                    {
                        dia = "Jueves";
                    }
                    else if (x == 5)
                    {
                        dia = "Viernes";
                    }
                    else if (x == 6)
                    {
                        dia = "Sabado";
                    }


                    if (dataGridView1.Rows[i].Cells[x].Style.BackColor == Color.FromArgb(128, 128, 128))
                    {
                        consulta2 = new SqlCommand("INSERT INTO HORARIO(PERIODO,DIA,ID_INSTRUCTOR,ID_AMBIENTE, ID_GRUPO,ID_AREA,TRIMESTRE,ESTADO) VALUES('" + dataGridView1.Rows[i].Cells[0].Value.ToString() + "','" + dia + "','" + CbxInstructores.GetItemText(CbxInstructores.SelectedValue) + "','" + CbxAmbiente.GetItemText(CbxAmbiente.SelectedValue) + "','" + CbxGrupos.Text + "','" + CbxArea.GetItemText(CbxArea.SelectedValue) + "','" + CbxTrimestre.Text + "','Actual')", conexion.GetConexion);

                        consulta2.CommandType = CommandType.Text;

                        consulta2.ExecuteNonQuery();

                        registro = true;

                        guardar_resultados(comboBox1.SelectedItem.ToString());

                    }

                }


            }

            if (registro == true)
            {
                VentanaMsjes ventana2 = new VentanaMsjes("GUARDAR", "Datos ingresados correctamente");
                ventana2.iconoPregunta.Image = global::Ej_Interfaz_Proyecto.Properties.Resources.icn_inf;
                ventana2.btnAceptar.Visible = true;
                ventana2.ShowDialog();

                
                dataGridViewActivado();
                LimpiarSeleccion();
                Limpiar();
              
                
              
            }
            else
            {
                VentanaMsjes ventana2 = new VentanaMsjes("GUARDAR", "para guardar debe asignarle un día y un rango al instructor");
                ventana2.iconoPregunta.Image = global::Ej_Interfaz_Proyecto.Properties.Resources.icn_inf;
                ventana2.btnAceptar.Visible = true;
                ventana2.ShowDialog();

               

            }

        }

        public void Limpiar()
        {
            cargar_horario(CbxAmbiente.GetItemText(CbxAmbiente.SelectedValue));
            CbxGrupos.SelectedIndex = -1;
            CbxInstructores.SelectedIndex = -1;
            treeView1.Nodes.Clear();
            ListResultados.Items.Clear(); 
         

        }

        public void guardar_resultados(string tipo)
        {

        int id_horario=-1;
        conexion.AbrirConexion();
        consulta = new SqlCommand(" SELECT MAX(ID_HORARIO) AS ULTIMO_REGISTRO FROM HORARIO", conexion.GetConexion);

        consulta.CommandType = CommandType.Text;

        SqlDataReader reader = consulta.ExecuteReader();

        while (reader.Read())
        {

            id_horario = Convert.ToInt16(reader["ULTIMO_REGISTRO"]);

        }

        reader.Close();

        for (int i = 0; i < ListResultados.Items.Count; i++) // Loop through List with for
        {
        ListResultados.SelectedIndex = i;


        if (tipo.Equals("Tecnico"))
        {

            consulta = new SqlCommand("INSERT INTO RESULTADOS_PROGRAMADOS(ID_HORARIO,ID_RESULTADO_TECNICO) VALUES('" + id_horario + "','" + CODIGO_RESULTADO(ListResultados.Text, comboBox1.SelectedItem.ToString()) + "')", conexion.GetConexion);


        }
        else if (tipo == "Transversal")
        {

            consulta = new SqlCommand("INSERT INTO RESULTADOS_PROGRAMADOS(ID_HORARIO,ID_RESULTADO_TRANSVERSAL) VALUES('" + id_horario + "','" + CODIGO_RESULTADO(ListResultados.Text, comboBox1.SelectedItem.ToString()) + "')", conexion.GetConexion);



        }

        
        consulta.CommandType = CommandType.Text;

        consulta.ExecuteNonQuery();

        }

        }

        public string CODIGO_RESULTADO(string DETALLE, string tipo)
        {
        conexion.AbrirConexion();
        string CODIGO="";


        String consultasql = "";

        if (tipo.Equals("Tecnico"))
        {

            consultasql = "SELECT ID_RESULTADO_TECNICO FROM RESULTADOS_TECNICOS WHERE DESCRIPCION_RESULTADO_TECNICO='" + DETALLE + "'";

        }
        else if (tipo == "Transversal")
        {

            consultasql = "SELECT ID_RESULTADO_TRANSVERSAL FROM RESULTADOS_TRANSVERSALES WHERE DESCRIPCION_RESULTADO_TRANSVERSAL='" + DETALLE + "'";


        }

        consulta = new SqlCommand(consultasql, conexion.GetConexion);

        consulta.CommandType = CommandType.Text;

        SqlDataReader reader = consulta.ExecuteReader();

        while (reader.Read())
        {
             if (tipo.Equals("Tecnico"))
            {

            CODIGO = Convert.ToString(reader["ID_RESULTADO_TECNICO"]);

            }

             else if (tipo == "Transversal")
             {
                 CODIGO = Convert.ToString(reader["ID_RESULTADO_TRANSVERSAL"]);

             }



        }

        reader.Close();
        return CODIGO;
        
        }

        


        private void treeView1_AfterExpand(object sender, TreeViewEventArgs e)
        {
            conexion.AbrirConexion();

            ListResultados.Items.Clear();

            int i = e.Node.Index;

            treeView1.SelectedNode = treeView1.Nodes[i];

            for (int x = 0; x < treeView1.Nodes.Count; x++)
            {
                if (x != i)
                {
                    treeView1.Nodes[x].Collapse();
                }
            }

            
        
            for (int y = 0; y < dataGridView1.Rows.Count; y++)
            {
                for (int x = 1; x <= 6; x++)
                {
                    if (dataGridView1.Rows[y].Cells[x].Style.BackColor == Color.FromArgb(128, 128, 128))
                    {
                        dataGridView1.Rows[y].Cells[x].Style.BackColor = Color.White;
                        dataGridView1.Rows[y].Cells[x].Style.SelectionBackColor = Color.White;
                        dataGridView1.Rows[y].Cells[x].Style.ForeColor = Color.White;
                        dataGridView1.Rows[y].Cells[x].Style.SelectionForeColor = Color.White;
                    }

                   
                }

            }

            
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            conexion.AbrirConexion();

            if (ListResultados.SelectedIndex != -1)
            {

                for (int y = 0; y < dataGridView1.Rows.Count; y++)
                {
                    for (int x = 1; x <= 6; x++)
                    {
                        if (dataGridView1.Rows[y].Cells[x].Style.BackColor == Color.Blue)
                        {
                            dataGridView1.Rows[y].Cells[x].Style.BackColor = Color.ForestGreen;
                            dataGridView1.Rows[y].Cells[x].Style.SelectionBackColor = Color.ForestGreen;
                            dataGridView1.Rows[y].Cells[x].Style.ForeColor = Color.ForestGreen;
                            dataGridView1.Rows[y].Cells[x].Style.SelectionForeColor = Color.ForestGreen;
                        }


                    }

                }


                cantidadResultado = 0;
                ListResultados.Items.RemoveAt(ListResultados.SelectedIndex);
                horas.Text = "0";
               


            }
            else
            {
                VentanaMsjes ventana = new VentanaMsjes("ELIMINAR", "Para eliminar debe seleccionar el resultado");
                ventana.iconoPregunta.Image = global::Ej_Interfaz_Proyecto.Properties.Resources.icn_inf;
                ventana.btnAceptar.Visible = true;
                ventana.ShowDialog();
               

            }

        }

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            cantidadResultado = 0;

            limpiar_bloquear_datagri();

            CbxInstructores.SelectedIndex = -1;

            cargar_instructores(comboBox1.SelectedItem.ToString());

            horas.Text = "0";
            cantidadResultado = 0;
        }

        private void CbxInstructores_SelectionChangeCommitted_1(object sender, EventArgs e)
        {
            limpiar_bloquear_datagri();

            ListadoDeCompetencias(comboBox1.SelectedItem.ToString());

            horas.Text = "0";
            cantidadResultado = 0;

        }

        private void FrmGenerarHorario_FormClosed(object sender, FormClosedEventArgs e)
        {
            principal.BtnHorario.Enabled = true;
        }

        private void consultarHorariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
        }

        private void button3_Click(object sender, EventArgs e)
        {   
            OpenFileDialog openFile1 = new OpenFileDialog();

            // Initialize the OpenFileDialog to look for RTF files.
            openFile1.DefaultExt = "*.xls";
            openFile1.Filter = "EXCEL 97 - 2003|*.xls";
            //openFile1.Filter = "EXCEL 2007 - 2013|*.xlsx";

            if (openFile1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                button3.Enabled = false;
                
                Process.Start(@openFile1.FileName);

                hilo = true;

                Hi = new Thread(new ThreadStart(Hilo));

                Hi.Start();

            }


        }


        public void Hilo()
        {

            while (hilo==true)
            {
                String encontrado = "no";

                Thread.Sleep(10);

                Process[] myProcesses = Process.GetProcesses();
                
                foreach (Process myProcess in myProcesses)
                {
                    
                    if (myProcess.ProcessName.Equals("EXCEL"))
                    {

                        encontrado = "si";

                        //idproc = GetIDProcces("EXCEL");

                        //Hi2 = new Thread(new ThreadStart(Hilo2));

                        //Hi2.Start();

                           
                    }
                    
                }

                if (encontrado.Equals("no"))
                {

                    button3.Enabled = true;
                    hilo = false;
                 

                }

            }

        }

        private void ListResultados_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Delete)
            {

                if (ListResultados.SelectedIndex != -1)
                {

                    for (int y = 0; y < dataGridView1.Rows.Count; y++)
                    {
                        for (int x = 1; x <= 6; x++)
                        {
                            if (dataGridView1.Rows[y].Cells[x].Style.BackColor == Color.FromArgb(128, 128, 128))
                            {
                                dataGridView1.Rows[y].Cells[x].Style.BackColor = Color.White;
                                dataGridView1.Rows[y].Cells[x].Style.SelectionBackColor = Color.White;
                                dataGridView1.Rows[y].Cells[x].Style.ForeColor = Color.White;
                                dataGridView1.Rows[y].Cells[x].Style.SelectionForeColor = Color.White;
                            }


                        }

                    }


                    cantidadResultado = 0;
                    ListResultados.Items.RemoveAt(ListResultados.SelectedIndex);
                    horas.Text = "0";



                }
                else
                {

                    VentanaMsjes ventana = new VentanaMsjes("ELIMINAR", "Para eliminar debe seleccionar el resultado");
                    ventana.iconoPregunta.Image = global::Ej_Interfaz_Proyecto.Properties.Resources.icn_inf;
                    ventana.btnAceptar.Visible = true;
                    ventana.ShowDialog();

                }


            }

        }

        private void pictureBox4_MouseLeave(object sender, EventArgs e)
        {
            this.pictureBox4.Image = global::Ej_Interfaz_Proyecto.Properties.Resources.btn_cer_normal2;
        }

        private void pictureBox4_MouseMove(object sender, MouseEventArgs e)
        {
            this.pictureBox4.Image = global::Ej_Interfaz_Proyecto.Properties.Resources.btn_cer_focus2;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox3_MouseLeave(object sender, EventArgs e)
        {
            this.pictureBox3.Image = global::Ej_Interfaz_Proyecto.Properties.Resources.btn_min_normal2;
        }

        private void pictureBox3_MouseMove(object sender, MouseEventArgs e)
        {
            this.pictureBox3.Image = global::Ej_Interfaz_Proyecto.Properties.Resources.btn_min_focus2;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Hide();
            for (int i = 0; i < 5; i++)
            {
                if (principal.EspacioMin[i].Equals("Desocupado"))
                {

                    if (i == 0)
                    {
                        pos = 10;
                    }
                    else if (i == 1)
                    {
                        pos = 180;

                    }

                    else if (i == 2)
                    {
                        pos = 350;

                    }

                    else if (i == 3)
                    {
                        pos = 520;

                    }

                    else if (i == 4)
                    {
                        pos = 690;

                    }

                    posM = i;

                    principal.EspacioMin[i] = ("Ocupado");
                    FrmMinHorarios MinHorario = new FrmMinHorarios(this, principal);
                    MinHorario.MdiParent = principal;
                    MinHorario.Location = new Point(pos, Screen.PrimaryScreen.Bounds.Height - 150 - 20);
                    MinHorario.StartPosition = FormStartPosition.Manual;
                    MinHorario.Show();

                    i = 10;
                }


            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            FrmConsultarHorario_1280x1024 ConsultarHorario = new FrmConsultarHorario_1280x1024("",principal);
            ConsultarHorario.MdiParent = principal;
            ConsultarHorario.Show();
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            this.pictureBox1.Image = global::Ej_Interfaz_Proyecto.Properties.Resources.btn_sel_normal;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            this.pictureBox1.Image = global::Ej_Interfaz_Proyecto.Properties.Resources.btn_sel_focus;
        }

        private void FrmGenerarHorario_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        //public void Hilo2()
        //{

        //    while (hilo2 == true)
        //    {

            
        //         Process[] myProcesses;
        //         // Returns array containing all instances of Notepad.
        //         myProcesses = Process.GetProcessesByName("EXCEL");

        //         for (int i = 0; i < myProcesses.Count(); i++)
        //         {
        //             if (idproc != GetIDProcces(myProcesses[i].ToString()))
        //             {

        //                 myProcesses[i].Kill();
        //             }

        //         }
                   
        //    }


        //}

        //private int GetIDProcces(string nameProcces)
        //{
        //    try
        //    {
        //        Process[] asProccess = Process.GetProcessesByName(nameProcces);
        //        foreach (Process pProccess in asProccess)
        //        {
        //            if (pProccess.MainWindowTitle == "")
        //            {
        //                return pProccess.Id;
        //            }
        //        }
        //        return -1;
        //    }
        //    catch
        //    {
        //        return -1;
        //    }
        //}

        

    }
}
