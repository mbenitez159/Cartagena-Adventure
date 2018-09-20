using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using exc = Microsoft.Office.Interop.Excel;
using Ej_Interfaz_Proyecto.Formularios_1280x1024;
using Ej_Interfaz_Proyecto.FrmMinimizados_1280x1024;

namespace Ej_Interfaz_Proyecto.GestionHorario
{
    public partial class GenerarHorario : Form
    {
        FrmPrincipal_1280x1024 principal;
        public int pos = 0;
        public int posM = 0;
        int cantidadResultado = 0;
        String fechavalidacion = "";
        string sql1 = "";
        Boolean bandera = false;      
        DataRow dr;
        string [,] selecciomMultipleIns = new string [18,7];
        public GenerarHorario(FrmPrincipal_1280x1024 p)
        {
            InitializeComponent();
            
            this.principal = p;

            CbxArea.DataSource = new ControlHorario().TodasLasAreas();

            CbxArea.DisplayMember = "NOMBRE";
            CbxArea.ValueMember = "CODIGO";

            if (CbxArea.Items.Count == 0)
                CbxArea.Enabled = false;
            else
            {
                CbxArea.SelectedIndex = 0;
                CbxArea.Enabled = true;
            }

        }

        public GenerarHorario()
        {
            InitializeComponent();
            CbxArea.DataSource = new ControlHorario().TodasLasAreas();

            CbxArea.DisplayMember = "NOMBRE";
            CbxArea.ValueMember = "CODIGO";

            if (CbxArea.Items.Count == 0)
                CbxArea.Enabled = false;
            else
            {
                CbxArea.SelectedIndex = 0;
                CbxArea.Enabled = true;
            }

        }


        private void CbxArea_SelectedIndexChanged(object sender, EventArgs e)
        {
            //CbxAmbiente.Enabled = CbxGrupos.Enabled = CbxTInstructor.Enabled = false;
            //CbxAmbiente.Text = CbxGrupos.Text = CbxTInstructor.Text = ""; 
            
            
            CbxAmbiente.DataSource = new ControlHorario().TodasLosAmbientes(CbxArea.SelectedValue.ToString());
            
            CbxAmbiente.DisplayMember = "NOMBRE";
            CbxAmbiente.ValueMember = "id_ambiente";

            if (CbxAmbiente.Items.Count == 0)
            {
                CbxAmbiente.Enabled = false;

            }
            else
            {
                // CbxAmbiente.SelectedIndex = 0;
                CbxAmbiente.Enabled = true;

            }
            CbxGrupos.Enabled = false;
            CbxTInstructor.Enabled = false;
            CbxInstructores.Enabled = false;
            CbxGrupos.DataSource = null;
            CbxInstructores.DataSource = null;
            CbxGrupos.Items.Clear();
            CbxInstructores.Items.Clear();
            //try
            //{
            //    Conexion conexion = new Conexion(); 
            //    String consultasql = "";
            //    SqlCommand consulta;
            //    SqlDataAdapter da = new SqlDataAdapter();
            //    DataSet ds = new DataSet();
            //    conexion.AbrirConexion();

            //    consultasql = "SELECT * FROM INSTRUCTOR";

            //    consulta = new SqlCommand(consultasql, conexion.GetConexion);

            //    da = new SqlDataAdapter(consulta);

            //    ds = new DataSet();

            //    da.Fill(ds, "INSTRUCTOR");

            //    CbxInstructores.DataSource = ds.Tables[0];

            //    CbxInstructores.DisplayMember = "NOMBRE";

            //    CbxInstructores.ValueMember = "ID_INSTRUCTOR";

            //    CbxInstructores.SelectedIndex = -1;

            //    CbxInstructores.Enabled = true;    
            //}
            //catch (Exception re)
            //{
            //    MessageBox.Show(re.ToString());
            //}
        }

        private void CbxAmbiente_SelectedIndexChanged(object sender, EventArgs e)
        {
            CbxGrupos.DataSource = new ControlHorario().TodasLosGrupos(CbxAmbiente.SelectedValue.ToString());
            CbxGrupos.DisplayMember = "ID_GRUPO";

            if (CbxGrupos.Items.Count == 0)
            {
                CbxGrupos.Enabled = false;
            }
            else
            {
                CbxGrupos.SelectedIndex = 0;
                CbxGrupos.Enabled = true;
                CbxTInstructor.Enabled = true;
                //CbxTInstructor.SelectedIndex = 0;
            }
            try
            {
                cargar_horariohAMBIENTE(); 
            }
            catch (Exception)
            {
                
                
            }
            
            
            
        }
        Clases_1280x1024.Grupos g = null;
        private void CbxGrupos_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox3.Text = new ControlHorario().perido(CbxGrupos.Text, CbxTrimestre.Text);
            try
            {
                SqlCommand consult;
                Conexion conexion = new Conexion();
                DataSet ds = new DataSet();
                DataRow dr;
                conexion.AbrirConexion();
                consult = new SqlCommand("SELECT ID_ESTADO  FROM GRUPO WHERE ID_GRUPO=@ID_GRUPO", conexion.GetConexion);
                consult.Parameters.AddWithValue("@ID_GRUPO", CbxGrupos.Text);
                consult.ExecuteNonQuery();
                SqlDataAdapter da = new SqlDataAdapter(consult);
                da.Fill(ds, "GRUPO");
                dr = ds.Tables["GRUPO"].Rows[0];
                if (dr["ID_ESTADO"].ToString().Equals("1"))
                {
                    estado.Text = "Activo";
                }
                if (dr["ID_ESTADO"].ToString().Equals("2"))
                {
                    estado.Text = "Inactivo";
                }
            }
            catch (Exception de)
            {
                //MessageBox.Show(de.Message);
            }
            g = new ControlHorario().UnGrupos(CbxGrupos.Text);
            if (g != null)
            {

                textBox1.Text = g.Id_Programa;
                CbxGrupos.Text = g.Id_grupo;
                Jornada.Text = g.Jornada;
                CbxTrimestre.Text = g.TrimestreActual;
                CbxTrimestre.Enabled = true;
            }
            else
            {
                textBox1.Text =
                CbxGrupos.Text =
                Jornada.Text =
                CbxTrimestre.Text = "";
                CbxTrimestre.Enabled = false;

            }
            //CbxInstructores.DataSource = null;
            cargar_horarioGRUPO();
            if (estado.Text.Equals("Inactivo"))
            {
                treeView1.Nodes.Clear();
            }
            validaTrimestre();
        }
        private void validaTrimestre()
        {
            CbxTrimestre.Items.Clear();
            string con = "select JORNADA from GRUPO where ID_GRUPO='"+CbxGrupos.Text+"'";
            Clases_1280x1024.Ambientes am = new Clases_1280x1024.Ambientes();

            DataTable dt = am.ejecutar(con);
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0]["JORNADA"].ToString().Equals("Mañana") || dt.Rows[0]["JORNADA"].ToString().Equals("Tarde") || dt.Rows[0]["JORNADA"].ToString().Equals("Jornada continua"))
                {
                    for (int i = 1; i <= 6; i++)
                    {
                        CbxTrimestre.Items.Add(i);
                    }
                    CbxTrimestre.SelectedIndex = 0;

                }
                else
                {
                    for (int i = 1; i <= 12; i++)
                    {
                        CbxTrimestre.Items.Add(i);
                    }
                    CbxTrimestre.SelectedIndex = 0;

                }
            }
        }

        private void CbxTInstructor_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox3.Text = new ControlHorario().perido(CbxGrupos.Text, CbxTrimestre.Text);
            //CbxTrimestre_SelectedIndexChanged(sender, e);
            cargar_horarioINSTRUCTOR();
            validaTrimestre();
        }

        private void CbxTrimestre_SelectedIndexChanged(object sender, EventArgs e)
        {
            Boolean bandera = false;
            contador = 0;
            textoHoraExtra.Visible = false;
            horaExtra.Visible = false;
            if (estado.Text.Equals("Inactivo"))
            {
                VentanaMsjes ventana = new VentanaMsjes("AVISO", "No puede programar en este grupo. Se encuentra en etapa productiva");
                ventana.btnAceptar.Visible = true;
                ventana.iconoPregunta.Image = global::Ej_Interfaz_Proyecto.Properties.Resources.icn_inf;
                DialogResult msgdresult = ventana.ShowDialog();
            }
            else
            {
                string JORNADA = Jornada.Text;
                textBox3.Text = new ControlHorario().perido(CbxGrupos.Text, CbxTrimestre.Text);
                treeView1.Nodes.Clear();
                horasprogramadas = horasrestantes = 0;
                horas.Text = HorasRestante.Text = "0";
                if (!JORNADA.Equals("Nocturna"))
                {
                    JORNADA = "Diurna";
                }

                if (CbxTInstructor.Text == "Tecnico")
                {
                    List<Competencias> l = new ControlHorario().TodosLasCompetenciasDeProgramaPorTrimestre1(CbxTrimestre.Text, "1",textBox1.Text,JORNADA);
                    if(l.Count==0)
                    {
                        treeView1.Nodes.Add("Msj : Todos los Resultados Ya Fueron Asignados O NO Cuenta Con Resultados");
                    }
                    else { 
                    for (int i = 0; i < l.Count; i++)
                    {
                        List<Resultados> li = new ControlHorario().TodosLosResultadosdeCompetencia(l[i].Codigo, CbxGrupos.Text,CbxTrimestre.Text);
                        TreeNode nodo = new TreeNode("Competencia : " + l[i].Descripcion);
                        for (int y = 0; y < li.Count; y++)
                        {
                            nodo.Nodes.Add(li[y].Codigo, li[y].Descripcion);
                        }
                        if (li.Count != 0)
                        {
                            treeView1.Nodes.Add(nodo);
                            bandera = true;
                        }
                       
                    }
                    if (bandera.Equals(false))
                    {
                        treeView1.Nodes.Add("Msj : Todos los Resultados Ya Fueron Asignados O NO Cuenta Con Resultados");
                    }
                    }
                   // textBox3.Text=
                }
                else
                {
                    string tipo = string.Empty;
                    if (CbxTInstructor.Text.Equals("Tecnico"))
                    {
                        tipo = "1";
                    }
                    else
                    {
                        tipo = "2";
                    }
                    //string competencia = "PROMOVER  LA INTERACCION IDONEA CONSIGO MISMO, CON LOS DEMÁS Y CON LA NATURALEZA EN LOS CONTEXTOS LABORAL Y SOCIAL";
                    List<Competencias> l = new ControlHorario().TodosLasCompetenciasDeProgramaPorTrimestre1(CbxTrimestre.Text,tipo,textBox1.Text,Jornada.Text);
                    for (int i = 0; i < l.Count; i++)
                    {
                    List<Resultados> li = new ControlHorario().TodosLosResultadosdeCompetencia(l[i].Codigo,CbxGrupos.Text,CbxTrimestre.Text);
                    TreeNode nodo = new TreeNode("Competencia : " + l[i].Descripcion);
                    for (int y = 0; y < li.Count; y++)
                    {
                        nodo.Nodes.Add(li[y].Codigo, li[y].Descripcion);
                    }
                    if (li.Count != 0)
                    {
                        treeView1.Nodes.Add(nodo);
                    }
                    else
                    {
                        treeView1.Nodes.Add("Msj : Todos los Resultados Ya Fueron Asignados O NO Cuenta Con Resultados");
                    }
                       
                    }

                }

                // Esta es la validacion funcional

                //fecha de inicio del grupo
                //int trim = short.Parse(g.FechaInicio.Split('-')[0]);//trimestre de inicio
                //int anio = short.Parse(g.FechaInicio.Split('-')[1]);//anio de inicio

                //int trima = short.Parse(CbxTrimestre.Text);//trimestre a generar

                //string fech = "";

                //for (int i = 1; i < trima; i++)
                //{
                //    trim++;
                //    if (trim > 4)
                //    {
                //        trim = 1;
                //        anio++;
                //    }
                //}

                //fechavalidacion = fech = trim + "-" + anio;
                //textBox3.Text = fechavalidacion;
                // MessageBox.Show(fech);
                //fin de validacion

                cargar_horariohAMBIENTE();
                cargar_horarioGRUPO();

                if (CbxInstructores.Text != "")
                {
                    CbxInstructores_SelectedIndexChanged(null, null);
                }
                horas.Text = "0";
                cantidadResultado = 0;
                ListResultados.Items.Clear();
                CbxInstructores.SelectedIndex = -1;
                CbxInstructores.Enabled = false;

            }

            
        }


        string id_resultado = "";
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Boolean existe = false;
            //para verificar que no exista en el listview
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
                if (treeView1.Nodes.Count > 0)
                {
                    try
                    {
                        if (!treeView1.SelectedNode.Text.Contains("Competencia : ") && !treeView1.SelectedNode.Text.Contains("Msj : "))
                        {
                            Resultados r = new ControlHorario().UnResultadosdeCompetencia(treeView1.SelectedNode.Text,CbxTrimestre.Text,CbxGrupos.Text);


                            if (CbxTInstructor.SelectedItem.Equals("Tecnico"))
                            {

                                if (cantidadResultado == 0)
                                {

                                    HorasRestante.Text = r.Duracion;
                                    id_resultado = r.Codigo;

                                    ListResultados.Items.Add(treeView1.SelectedNode.Text);
                                    ListResultados.SetSelected(0, true);
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
                            else if (CbxTInstructor.SelectedItem.Equals("Transversal"))
                            {
                                if (cantidadResultado == 0)
                                {

                                    horas.Text = r.Duracion;
                                    id_resultado = r.Codigo;

                                    ListResultados.Items.Add(treeView1.SelectedNode.Text);
                                    ListResultados.SetSelected(0, true);

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
                            try
                            {

                                SqlCommand consult;
                                DataTable dt = new DataTable();
                                Conexion conexion = new Conexion();
                                conexion.AbrirConexion();
                                consult = new SqlCommand("select NOMBRE, INSTRUCTOR.ID_INSTRUCTOR from RESULTADOS,INSTRUCTOR,INSTRUCTOR_RESULTADOS"
                                                            + " where RESULTADOS.ID=INSTRUCTOR_RESULTADOS.ID_RESULTADO and"
                                                            + " INSTRUCTOR.ID_INSTRUCTOR=INSTRUCTOR_RESULTADOS.ID_INSTRUCTOR"
                                                            + " and RESULTADOS.DESCRIPCION='" + ListResultados.Text + "'", conexion.GetConexion);
                                consult.ExecuteNonQuery();
                                SqlDataAdapter da = new SqlDataAdapter(consult);
                                da.Fill(dt);

                                if (dt.Rows.Count > 0)
                                {
                                    CbxInstructores.DisplayMember = "NOMBRE";
                                    CbxInstructores.ValueMember = "INSTRUCTOR.ID_INSTRUCTOR";
                                    CbxInstructores.DataSource = dt;
                                    CbxInstructores.Enabled = true;
                                }

                            }
                            catch (Exception de)
                            {
                                MessageBox.Show(de.Message);
                            }
                            cargar_horarioINSTRUCTOR();
                            cargar_horariohAMBIENTE();
                        }
                        else
                        {
                            VentanaMsjes ventana = new VentanaMsjes("AVISO", "Solo se permite programar Resultados");
                            ventana.iconoPregunta.Image = global::Ej_Interfaz_Proyecto.Properties.Resources.icn_inf;
                            ventana.btnAceptar.Visible = true;
                            ventana.ShowDialog();
                        }
                    }
                    catch (NullReferenceException) { }
                }

            }
            else
            {
                VentanaMsjes ventana = new VentanaMsjes("AVISO", "El resultado ya fue agregado");
                ventana.iconoPregunta.Image = global::Ej_Interfaz_Proyecto.Properties.Resources.icn_inf;
                ventana.btnAceptar.Visible = true;
                ventana.ShowDialog();


            }
            ConsultarHorasDisponibleResultado();
            if (ConsultarHorasDisponibleResultado().Equals(0))
            {
                ConsultarDuracionResultado();
            }
            
        }
       
        private void button1_Click(object sender, EventArgs e)
        {

            if (CbxInstructores.SelectedIndex != -1)
            {
                if (ListResultados.Items.Count > 0)
                {
                    guardar_horario(sender,e);
                    horas.Text = "0";
                    cantidadResultado = 0;
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
            ListResultados.Items.Clear();
        }

        public void guardar_Resultado()
        {
            String consultasql = "";
            Conexion conexion = new Conexion();
            string horasTotal = "";
            if (horaExtra.Visible.Equals(true))
            {
                horasTotal = "" + (int.Parse(horaExtra.Text) * -1);
            }
            else
            {
                horasTotal = HorasRestante.Text;
            }
            conexion.AbrirConexion();
            int horasprog = 0;
            for (int i = 0; i < dataGridView1.RowCount; i++)
                for (int x = 1; x <= 6; x++)
                {
                    if (dataGridView1.Rows[i].Cells[x].Style.BackColor == Color.FromArgb(128, 128, 128))
                    {
                        horasprog++;
                    }
                }


            consultasql = "insert into TIEMPO_RESULTADOS VALUES('" + id_resultado + "','" + CbxGrupos.Text + "','" + horasTotal + "')";

            try
            {
                SqlCommand cmdConsulta = new SqlCommand(consultasql, conexion.GetConexion);
                cmdConsulta.ExecuteNonQuery();
                conexion.CerrarConexion();
            }
            catch (Exception)
            {
                consultasql = "update TIEMPO_RESULTADOS set duracion ='" + HorasRestante.Text + "' where ID_RESULTADO = '" + id_resultado + "' AND ID_GRUPO = '" + CbxGrupos.Text + "'";
                SqlCommand cmdConsulta = new SqlCommand(consultasql, conexion.GetConexion);
                cmdConsulta.ExecuteNonQuery();
                conexion.CerrarConexion();
            }

        }
        public int ConsultarDuracionResultado()
        {
            try
            {
                int grupo = int.Parse(CbxGrupos.Text);
                DataSet ds = new DataSet();
                Conexion conexion = new Conexion();
                conexion.AbrirConexion();
                string sql = "SELECT r.DURACION AS valor FROM TRIMESTRE r WHERE r.idResultado =" + id_resultado + " and r.trimestre="+CbxTrimestre.Text+" ";
                SqlCommand consulta = new SqlCommand(sql, conexion.GetConexion);
                consulta.ExecuteNonQuery();
                SqlDataAdapter DA = new SqlDataAdapter(consulta);
                DA.Fill(ds, "RESULTADOS");
                dr = ds.Tables["RESULTADOS"].Rows[0];
                if (dr["valor"].ToString() != "")
                {
                    horasrestantes = int.Parse(dr["valor"].ToString());
                    return horasrestantes;
                }
            }
            catch (Exception error)
            {
                VentanaMsjes ventana2 = new VentanaMsjes("ERROR", error.Message);
                ventana2.iconoPregunta.Image = global::Ej_Interfaz_Proyecto.Properties.Resources.icn_inf;
                ventana2.btnAceptar.Visible = true;
                ventana2.ShowDialog();
            }
            return 0;
        }
        public int ConsultarHorasDisponibleResultado()
        {
            try
            {
                int grupo = int.Parse(CbxGrupos.Text);
                DataSet ds = new DataSet();
                Conexion conexion = new Conexion();
                conexion.AbrirConexion();
                string sql = "IF EXISTS (SELECT MIN(DURACION) AS valor FROM TIEMPO_RESULTADOS WHERE ID_RESULTADO='" + id_resultado + "' AND ID_GRUPO='" + grupo + "')BEGIN SELECT MIN(DURACION)AS valor FROM TIEMPO_RESULTADOS WHERE ID_RESULTADO = '" + id_resultado + "' AND ID_GRUPO = '"+grupo+"' END";
                SqlCommand consulta = new SqlCommand(sql, conexion.GetConexion);
                consulta.ExecuteNonQuery();
                SqlDataAdapter DA = new SqlDataAdapter(consulta);
                DA.Fill(ds, "TIEMPO_RESULTADOS");
                dr = ds.Tables["TIEMPO_RESULTADOS"].Rows[0];
                if (dr["valor"].ToString() != "")
                {
                    horasrestantes = int.Parse(dr["valor"].ToString());
                    return horasrestantes;
                }
            }
            catch (Exception error)
            {
                VentanaMsjes ventana2 = new VentanaMsjes("ERROR", error.Message);
                ventana2.iconoPregunta.Image = global::Ej_Interfaz_Proyecto.Properties.Resources.icn_inf;
                ventana2.btnAceptar.Visible = true;
                ventana2.ShowDialog();
            }
            return 0;
        }
        public void guardar_horario(object sender, EventArgs e)
        {
            //if (ConsultarHorasResultado() >= 4)
            //{
                Boolean registro = false;
                Conexion conexion = new Conexion();
                SqlCommand consulta2;
               

                for (int i = 0; i < dataGridView1.RowCount; i++)
                    for (int x = 1; x <= 6; x++)
                    {
                        if (dataGridView1.Rows[i].Cells[x].Style.BackColor == Color.FromArgb(128, 128, 128))
                        {
                            conexion.AbrirConexion();
                            consulta2 = new SqlCommand("INSERT INTO HORARIO(PERIODO,DIA,ID_AMBIENTE, ID_GRUPO,ID_AREA,TRIMESTRE,ESTADO,ID_RESULTADO,ID_INSTRUCTOR,TRIMESTRE_ANIO) VALUES('" + dataGridView1.Rows[i].Cells[0].Value.ToString() + "','" + dataGridView1.Columns[x].Name + "','" + CbxAmbiente.GetItemText(CbxAmbiente.SelectedValue) + "','" + CbxGrupos.Text + "','" + CbxArea.GetItemText(CbxArea.SelectedValue) + "','" + CbxTrimestre.Text + "','Actual','" + id_resultado + "','" +selecciomMultipleIns[i,x] + "','" + textBox3.Text+ "')", conexion.GetConexion);

                            consulta2.CommandType = CommandType.Text;

                            consulta2.ExecuteNonQuery();

                            registro = true;

                            //almacenar horas restantes
                        }
                    }
                guardar_Resultado();

                if (registro == true)
                {
                    button4_Click(sender, e);
                    limpiarMatriz();
                    VentanaMsjes ventana2 = new VentanaMsjes("GUARDAR", "Datos ingresados correctamente");
                    ventana2.iconoPregunta.Image = global::Ej_Interfaz_Proyecto.Properties.Resources.icn_inf;
                    ventana2.btnAceptar.Visible = true;
                    ventana2.ShowDialog();
                    //actualizamos las tablas
                    cargar_horarioGRUPO();
                    cargar_horariohAMBIENTE();
                    cargar_horarioINSTRUCTOR();
                    CbxInstructores_SelectedIndexChanged(null, null);
                }
                else
                {
                    VentanaMsjes ventana2 = new VentanaMsjes("GUARDAR", "para guardar debe asignarle un día y un rango al instructor");
                    ventana2.iconoPregunta.Image = global::Ej_Interfaz_Proyecto.Properties.Resources.icn_inf;
                    ventana2.btnAceptar.Visible = true;
                    ventana2.ShowDialog();
                }

           // }
            //else
            //{
            //    VentanaMsjes ventana2 = new VentanaMsjes("ADVERTENCIA", "Ya se ha programado este resultado\nNo hay horas disponible");
            //    ventana2.iconoPregunta.Image = global::Ej_Interfaz_Proyecto.Properties.Resources.icn_inf;
            //    ventana2.btnAceptar.Visible = true;
            //    ventana2.ShowDialog();
            //}
            cantidadResultado = 0;
            contador = 0;
            horaExtra.Visible = false;
            textoHoraExtra.Visible = false;
        }
        private void limpiarMatriz() {
            for (int i = 0; i < 18; i++)
                for (int x = 0; x <= 6; x++)
                {
                     selecciomMultipleIns[i,x] = "";
                }
        }
        private void seleccion_multiple_instructor(Boolean comp,int fila, int colum) {

            if (comp.Equals(true))
            {
                for (int i = 0; i < dataGridView1.RowCount; i++)
                    for (int x = 1; x <= 6; x++)
                    {
                        if (dataGridView1.Rows[i].Cells[x].Style.BackColor == Color.FromArgb(128, 128, 128) && selecciomMultipleIns[i, x].ToString().Equals("") /* string.IsNullOrEmpty(selecciomMultipleIns[i, x])*/)
                        {
                            selecciomMultipleIns[i, x] = CbxInstructores.SelectedValue.ToString();
                        }
                    }
            }
            else
            {
                selecciomMultipleIns[fila, colum] = "";
            }    

        }
        private Boolean ValidarAmbiente() {
            string dia = "";
            switch (dataGridView1.CurrentCell.ColumnIndex)
            {
                case 1:
                    dia = "Lunes";
                    break;
                case 2:
                    dia = "Martes";
                    break;
                case 3:
                    dia = "Miercoles";
                    break;
                case 4:
                    dia = "Jueves";
                    break;
                case 5:
                    dia = "Viernes";
                    break;
                case 6:
                    dia = "Sabado";
                    break;

            }
            Boolean devuelve = false;
            string a = "";
            try
            {
                Conexion c = new Conexion();
                c.AbrirConexion();

                SqlCommand cm = new SqlCommand("select cast(count(ID_HORARIO) as varchar(40)) as cuenta  from HORARIO where ID_AMBIENTE='" + CbxAmbiente.SelectedValue.ToString() + "' and TRIMESTRE_ANIO='" + textBox3.Text + "' and PERIODO='" + dataGridView1.CurrentRow.Cells[0].Value + "' and DIA='" + dia + "'", c.GetConexion);
                SqlDataReader dr = cm.ExecuteReader();
                while (dr.Read())
                {
                    a = dr.GetString(0);
                }
                if (a.Equals("0"))
                {
                    devuelve = true;
                }
                dr.Close();
                c.CerrarConexion();
            }
            catch (Exception ex )
            {
                MessageBox.Show(ex.Message);
                
            }
            return devuelve;
        }

        // carga de instructores
        private void treeView1_MouseClick(object sender, MouseEventArgs e)
        {
            //try
            //{
            //    horasprogramadas = horasrestantes = 0;
            //    horas.Text = label20.Text = "0";
            //    //cargar_horarioGRUPO();

            //    CbxInstructores.DataSource = new ControlHorario().TodosLosInstructores(treeView1.SelectedNode.Text, fechavalidacion);
            //    CbxInstructores.DisplayMember = "Nombre";
            //    CbxInstructores.ValueMember = "Identificacion";
            //    if (new ControlHorario().TodosLosInstructores(treeView1.SelectedNode.Text, fechavalidacion).Count == 0) CbxInstructores_SelectedIndexChanged(null, null);
            //    label20.Text = new ControlHorario().UnResultadosdeCompetencia(treeView1.SelectedNode.Text).Duracion;
            //    horasrestantes = Convert.ToInt16(label20.Text);

            //    int t = new ControlHorario().HorasRestantesdeResultado(treeView1.SelectedNode.Text, CbxGrupos.Text);
            //    if (t != 0)
            //    {
            //        label20.Text = "" + t;
            //        horasrestantes = t;
            //    }
            //}
            //catch (NullReferenceException Error) {
            //    Error.ToString();
            //}

        }
        private void validarUltimaHoraProgramar(DataGridViewCellEventArgs e)
        {
            contador++;
            if (contador == 1)
            {
                VentanaMsjes ventana = new VentanaMsjes("AVISO", "La duración restante del resultado de aprendizaje es inferior a la minima,¿aun asi desea ingresarla?.");
                ventana.btnSi.Visible = true;
                ventana.btnNo.Visible = true;
                ventana.btnAceptar.Visible = false;
                ventana.iconoPregunta.Image = global::Ej_Interfaz_Proyecto.Properties.Resources.icn_pre;
                DialogResult msgdresult = ventana.ShowDialog();
                if (msgdresult.Equals(DialogResult.OK))
                {
                    dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.SelectionBackColor = Color.FromArgb(128, 128, 128);

                    dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.FromArgb(128, 128, 128);

                    dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.ForeColor = Color.FromArgb(128, 128, 128);

                    dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.SelectionForeColor = Color.FromArgb(128, 128, 128);

                    horasprogramadas++;
                    horasrestantes = horasrestantes - 12;
                    horas.Text = Convert.ToString((horasprogramadas * 12));
                    HorasRestante.Text = "0";
                    seleccion_multiple_instructor(true, dataGridView1.CurrentCell.RowIndex, dataGridView1.CurrentCell.ColumnIndex);
                    horaExtra.Visible = true;
                    horaExtra.Text = Convert.ToString("+" + (horasrestantes * -1));
                    textoHoraExtra.Visible = true;

                }
                dataGridView1.CurrentCell.Selected = false;
            }
        }

        int columna, fila;
        int horasprogramadas = 0;
        int horasrestantes = 0;
        int contador = 0;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (ValidarAmbiente()==true)
            {
                this.columna = e.ColumnIndex;
                this.fila = e.RowIndex;

                if (CbxInstructores.Text != "")
                {
                    if (dataGridView1.CurrentCell.Style.BackColor != Color.FromArgb(4, 123, 117))
                    {
                        if (e.ColumnIndex > 0 && e.RowIndex >= 0)
                        {

                            if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor != Color.FromArgb(128, 128, 128))
                            {
                                if (CONSULTAR_DISPONIBILIDAD_INSTRUCTOR() == true)
                                {

                                    if (Convert.ToInt32(HorasRestante.Text) < 12 && horasprogramadas > 0 && contador == 0)
                                    {
                                        validarUltimaHoraProgramar(e);
                                    }
                                    else
                                    {
                                        if (horasrestantes >11 )
                                        {

                                            dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.SelectionBackColor = Color.FromArgb(128, 128, 128);

                                            dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.FromArgb(128, 128, 128);

                                            dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.ForeColor = Color.FromArgb(128, 128, 128);

                                            dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.SelectionForeColor = Color.FromArgb(128, 128, 128);

                                            horasprogramadas++;
                                            horasrestantes = horasrestantes - 12;
                                            horas.Text = Convert.ToString((horasprogramadas * 12));
                                            HorasRestante.Text = "" + horasrestantes;
                                            seleccion_multiple_instructor(true, dataGridView1.CurrentCell.RowIndex, dataGridView1.CurrentCell.ColumnIndex);

                                        }
                                        else if (horasrestantes > 0 && horasrestantes < 12 && contador == 0)
                                        {
                                            validarUltimaHoraProgramar(e); 
                                        }
                                        else
                                        {
                                            dataGridView1.CurrentCell.Selected = false;
                                            VentanaMsjes ventana = new VentanaMsjes("AVISO", "  Ya se programaron Todas las horas del resultado. Pulse el botón guardar para asignarlas");
                                            ventana.btnSi.Visible = false;
                                            ventana.btnNo.Visible = false;
                                            ventana.btnAceptar.Visible = true;
                                            ventana.iconoPregunta.Image = global::Ej_Interfaz_Proyecto.Properties.Resources.icn_pre;
                                            DialogResult msgdresult = ventana.ShowDialog();
                                            if (msgdresult.Equals(DialogResult.OK))
                                            {
                                                FrmConsultarHorario_1280x1024 ConsultarHorario = new FrmConsultarHorario_1280x1024("", principal);
                                                ConsultarHorario.MdiParent = principal;
                                                ConsultarHorario.Show();

                                            }
                                        }
                                    }

                                }
                                else
                                {
                                    dataGridView1.CurrentCell.Selected = false;
                                    VentanaMsjes ventana = new VentanaMsjes("AVISO", "El instructor seleccionado no se encuentra disponible en la hora seleccionada");
                                    ventana.btnSi.Visible = false;
                                    ventana.btnAceptar.Visible = true;
                                    ventana.btnNo.Visible = false;
                                    ventana.iconoPregunta.Image = global::Ej_Interfaz_Proyecto.Properties.Resources.icn_pre;
                                    ventana.ShowDialog();
                                }

                            }
                            else
                            {

                                dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.SelectionBackColor = Color.White;

                                dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.White;

                                dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "";

                                dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.ForeColor = Color.White;

                                dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.SelectionForeColor = Color.White;

                                horasprogramadas--;
                                if (horaExtra.Visible.Equals(false))
                                {
                                    horasrestantes = Convert.ToInt16(HorasRestante.Text) + 12;
                                }
                                else
                                {
                                    horasrestantes = (Convert.ToInt16(horaExtra.Text) * -1) + 12;
                                }

                                HorasRestante.Text = "" + horasrestantes;

                                horas.Text = "" + (Convert.ToInt16(horas.Text) - 12);
                                contador = 0;
                                textoHoraExtra.Visible = false;
                                horaExtra.Visible = false;
                            }

                        }
                    }
                    else
                    {
                        dataGridView1.CurrentCell.Selected = false;
                        VentanaMsjes ventana = new VentanaMsjes("AVISO", "  No es posible selecionar horas que ya fueron programadas.");
                        ventana.btnAceptar.Visible = true;
                        ventana.iconoPregunta.Image = global::Ej_Interfaz_Proyecto.Properties.Resources.icn_inf;
                        ventana.ShowDialog();
                    }

                }
                else
                {
                    dataGridView1.CurrentCell.Selected = false;
                    VentanaMsjes ventana = new VentanaMsjes("AVISO", "  No puede programar sin seleccionar antes un instructor.");
                    ventana.btnAceptar.Visible = true;
                    ventana.iconoPregunta.Image = global::Ej_Interfaz_Proyecto.Properties.Resources.icn_inf;
                    ventana.ShowDialog();

                }
            }
            else
            {
                dataGridView1.CurrentCell.Selected = false;
                VentanaMsjes ventana = new VentanaMsjes("AVISO", "El ambiente no esta disponible en esa hora.");
                ventana.btnAceptar.Visible = true;
                ventana.iconoPregunta.Image = global::Ej_Interfaz_Proyecto.Properties.Resources.icn_inf;
                ventana.ShowDialog();
            }
        }

        public Boolean CONSULTAR_DISPONIBILIDAD_INSTRUCTOR()
        {
            Boolean estado = true;
            Conexion conexion = new Conexion();
            SqlCommand consulta;

             
            conexion.AbrirConexion();
            try
            {
                consulta = new SqlCommand("SELECT PERIODO,DIA FROM HORARIO Where ID_INSTRUCTOR='" + CbxInstructores.SelectedValue.ToString() + "' AND TRIMESTRE_ANIO = '" + textBox3.Text + "'", conexion.GetConexion);

                consulta.CommandType = CommandType.Text;


                SqlDataReader reader2 = consulta.ExecuteReader();


                while (reader2.Read())
                {
                    if (Convert.ToString(reader2["PERIODO"]).Equals(dataGridView1.CurrentRow.Cells[0].Value.ToString()))
                    {
                        int dia = 0;
                        if (Convert.ToString(reader2["DIA"]) == "Lunes") dia = 1;
                        if (Convert.ToString(reader2["DIA"]) == "Martes") dia = 2;
                        if (Convert.ToString(reader2["DIA"]) == "Miercoles") dia = 3;
                        if (Convert.ToString(reader2["DIA"]) == "Jueves") dia = 4;
                        if (Convert.ToString(reader2["DIA"]) == "Viernes") dia = 5;
                        if (Convert.ToString(reader2["DIA"]) == "Sabado") dia = 6;

                        if (this.columna == dia)
                        {
                            estado = false;

                        }
                    }

                }
                reader2.Close();

            }
            catch (Exception)
            {
                
                
            }


            


            return estado;
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
                    else if (i == 5)
                    {
                        pos = 860;
                    }

                    posM = i;

                    principal.EspacioMin[i] = ("Ocupado");
                    FrmMinHorarios MinHorario = new FrmMinHorarios(this, principal);
                    MinHorario.MdiParent = principal;
                    MinHorario.Location = new System.Drawing.Point(pos, Screen.PrimaryScreen.Bounds.Height - 150 - 20);
                    MinHorario.StartPosition = FormStartPosition.Manual;
                    MinHorario.Show();
                    i = 10;
                }


            }
            principal.BtnHorario.Enabled = false;
        }
        private Boolean exitenSinGuardar() {
         bool   prueba = false;
            for (int i = 1; i < dataGridView1.Rows.Count; i++)
            {
                for (int j = 0; j <dataGridView1.ColumnCount ; j++ )
                {
                    if (dataGridView1.Rows[i].Cells[j].Style.BackColor==Color.FromArgb(128,128,128))
                    {
                        prueba = true;
                        break;                        
                    }
                }
            }         
         return prueba;
        }
        private void pictureBox4_Click(object sender, EventArgs e)
        {
            if (exitenSinGuardar().Equals(true))
            {
                VentanaMsjes ventana = new VentanaMsjes("AVISO", "Exiten resultados selecionados, ¿desea salir y guardarlos?.");
                ventana.btnSi.Visible = true;
                ventana.btnNo.Visible = true;
                ventana.btnAceptar.Visible = false;
                ventana.iconoPregunta.Image = global::Ej_Interfaz_Proyecto.Properties.Resources.icn_pre;
                DialogResult msgdresult = ventana.ShowDialog();
                if (msgdresult.Equals(DialogResult.OK)){
                    button1_Click(sender, e);
                    this.Dispose();
                    principal.BtnHorario.Enabled = true;
                }
                else
                {
                    this.Dispose();
                    principal.BtnHorario.Enabled = true;
                }
            }
            else
            {
                this.Dispose();
                principal.BtnHorario.Enabled = true;
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

        private void pictureBox3_MouseLeave(object sender, EventArgs e)
        {
            this.pictureBox3.Image = global::Ej_Interfaz_Proyecto.Properties.Resources.btn_min_normal2;
        }

        private void pictureBox3_MouseMove(object sender, MouseEventArgs e)
        {
            this.pictureBox3.Image = global::Ej_Interfaz_Proyecto.Properties.Resources.btn_min_focus2;
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            pictureBox3_Click(sender,e);
            FrmConsultarHorario_1280x1024 ConsultarHorario = new FrmConsultarHorario_1280x1024("", principal);
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

        private void button4_Click(object sender, EventArgs e)
        {
            horas.Text = "0";
            cantidadResultado = 0;
            ListResultados.Items.Clear();
            CbxTrimestre_SelectedIndexChanged(sender, e);
            CbxInstructores.SelectedIndex = -1;
            CbxInstructores.Enabled = false;
            contador = 0;
            textoHoraExtra.Visible = false;
            horaExtra.Visible = false;
        }

        /************** CARGA DEL HORARIO INSTRUCTOR ***/
        int horasInstructor = 0;
        private void CbxInstructores_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargar_horarioINSTRUCTOR();

        }
        /************* CARGA EL HORARIO DEL AMBIENTE******/
        public void cargar_horariohAMBIENTE()
        {
            
            dataGridView3.Rows.Clear();
            this.dataGridView3.Rows.Add("06:00 - 07:00");
            this.dataGridView3.Rows.Add("07:00 - 08:00");
            this.dataGridView3.Rows.Add("08:00 - 09:00");
            this.dataGridView3.Rows.Add("09:00 - 10:00");
            this.dataGridView3.Rows.Add("10:00 - 11:00");
            this.dataGridView3.Rows.Add("11:00 - 12:00");
            this.dataGridView3.Rows.Add("12:00 - 13:00");
            this.dataGridView3.Rows.Add("13:00 - 14:00");
            this.dataGridView3.Rows.Add("14:00 - 15:00");
            this.dataGridView3.Rows.Add("15:00 - 16:00");
            this.dataGridView3.Rows.Add("16:00 - 17:00");
            this.dataGridView3.Rows.Add("17:00 - 18:00");
            this.dataGridView3.Rows.Add("18:00 - 19:00");
            this.dataGridView3.Rows.Add("19:00 - 20:00");
            this.dataGridView3.Rows.Add("20:00 - 21:00");
            this.dataGridView3.Rows.Add("21:00 - 22:00");

            // Llamamos al metodo AbrirConexion() de la clase Conexion
            Conexion conexion = new Conexion();
            SqlCommand consulta;
            conexion.AbrirConexion();
            int[,] ID_HORARIO = new int[15, 7];

            // Realizamos la consulta a la base de datos

            consulta = new SqlCommand("SELECT ID_HORARIO,PERIODO,DIA,id_grupo FROM HORARIO Where ID_AMBIENTE = '" + CbxAmbiente.SelectedValue.ToString() + "' AND  TRIMESTRE_ANIO = '" + textBox3.Text + "' ", conexion.GetConexion);

            // Creamos un objeto SqlDataReader Para Guardar lo que nos trae La Consulta
            SqlDataReader reader1 = consulta.ExecuteReader();

            // Recorremos el objeto SqlDataReader 
            while (reader1.Read())
            {
                // Creamos una variable fila para definir en q fila de la tabla va hacer asignado dicho horario
                int fila = 0;

                // Creamos una variable columna para definir en q columna de la tabla va hacer asignado dicho horario
                int columna = 1;


                // Verificamos si el objeto reader Periodo = "07:00 - 08:00" de ser asi la fila tomaria el valor de 0
                if (Convert.ToString(reader1["PERIODO"]).Equals("06:00 - 07:00"))
                {
                    fila = 0;

                }
                if (Convert.ToString(reader1["PERIODO"]).Equals("07:00 - 08:00"))
                {
                    fila = 1;

                }
                // Verificamos si el objeto reader Periodo = "08:00 - 09:00" de ser asi la fila tomaria el valor de 1 y asi sucesivamente
                // hasta la fila 14
                else if (Convert.ToString(reader1["PERIODO"]).Equals("08:00 - 09:00"))
                {
                    fila = 2;
                }

                else if (Convert.ToString(reader1["PERIODO"]).Equals("09:00 - 10:00"))
                {
                    fila = 3;
                }
                else if (Convert.ToString(reader1["PERIODO"]).Equals("10:00 - 11:00"))
                {
                    fila = 4;
                }

                else if (Convert.ToString(reader1["PERIODO"]).Equals("11:00 - 12:00"))
                {
                    fila = 5;
                }
                else if (Convert.ToString(reader1["PERIODO"]).Equals("12:00 - 13:00"))
                {
                    fila = 6;
                }
                else if (Convert.ToString(reader1["PERIODO"]).Equals("13:00 - 14:00"))
                {
                    fila = 7;
                }
                else if (Convert.ToString(reader1["PERIODO"]).Equals("14:00 - 15:00"))
                {
                    fila = 8;
                }
                else if (Convert.ToString(reader1["PERIODO"]).Equals("15:00 - 16:00"))
                {
                    fila = 9;
                }
                else if (Convert.ToString(reader1["PERIODO"]).Equals("16:00 - 17:00"))
                {
                    fila = 10;
                }
                else if (Convert.ToString(reader1["PERIODO"]).Equals("17:00 - 18:00"))
                {
                    fila = 11;
                }
                else if (Convert.ToString(reader1["PERIODO"]).Equals("18:00 - 19:00"))
                {
                    fila = 12;
                }
                else if (Convert.ToString(reader1["PERIODO"]).Equals("19:00 - 20:00"))
                {
                    fila = 13;
                }
                else if (Convert.ToString(reader1["PERIODO"]).Equals("20:00 - 21:00"))
                {
                    fila = 14;
                }
                else if (Convert.ToString(reader1["PERIODO"]).Equals("21:00 - 22:00"))
                {
                    fila = 15;
                }

                // Verificamos si el objeto reader DIA = "lunes" de ser asi la columna tomaria el valor de 1 y asi sucesivamente hasta
                // llegar al dia Sabado
                if (Convert.ToString(reader1["DIA"]).Equals("lunes"))
                {
                    columna = 1;

                }

                else if (Convert.ToString(reader1["DIA"]).Equals("Martes"))
                {
                    columna = 2;

                }
                else if (Convert.ToString(reader1["DIA"]).Equals("Miercoles"))
                {
                    columna = 3;

                }
                else if (Convert.ToString(reader1["DIA"]).Equals("Jueves"))
                {
                    columna = 4;
                }
                else if (Convert.ToString(reader1["DIA"]).Equals("Viernes"))
                {
                    columna = 5;

                }
                else if (Convert.ToString(reader1["DIA"]).Equals("Sabado"))
                {
                    columna = 6;

                }

                
                dataGridView3.Rows[fila].Cells[columna].Value = "Ficha : " + Convert.ToString(reader1["id_grupo"]);
                
                //le asignamos a la celda el color verde
                dataGridView3.Rows[fila].Cells[columna].Style.ForeColor = Color.FromArgb(4, 123, 117);

                dataGridView3.Rows[fila].Cells[columna].Style.SelectionForeColor = Color.FromArgb(4, 123, 117);

                dataGridView3.Rows[fila].Cells[columna].Style.BackColor = Color.FromArgb(4, 123, 117);

                //dataGridView3.Rows[fila].Cells[columna].ReadOnly = false;
              
                
                //dataGridView3.Rows[fila].Cells[columna].Value = "Area: " + Convert.ToString(reader["AREA"]) + Environment.NewLine + Convert.ToString(reader["AMBIENTE"]) + Environment.NewLine + "Numero De Ficha: " + Convert.ToString(reader["id_grupo"]);
                //ID_HORARIO[fila, columna] = Convert.ToInt16(reader["ID_HORARIO"]);
            }
            //cerramos el objeto reader
            reader1.Close();


            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                for (int x = 1; x <= 6; x++)
                {

                    if (dataGridView3.Rows[i].Cells[x].Style.BackColor == Color.FromArgb(4, 123, 117))
                    {

                        dataGridView3.Rows[i].Cells[x].Style.SelectionBackColor = Color.FromArgb(4, 123, 117);

                        dataGridView3.Rows[i].Cells[x].Style.BackColor = Color.FromArgb(4, 123, 117);

                        dataGridView3.Rows[i].Cells[x].Style.ForeColor = Color.FromArgb(4, 123, 117);

                        dataGridView3.Rows[i].Cells[x].Style.SelectionForeColor = Color.FromArgb(4, 123, 117);

                    }
                }

            }


            if (estado.Text == "Activo")
            {
                if (Jornada.Text.Equals("Mañana"))
                {

                    for (int i = 0; i < dataGridView3.Rows.Count; i++)
                    {
                        if (i > 5)
                        {
                            dataGridView3.Rows[i].Visible = false;
                        }
                        else
                        {
                            dataGridView3.Rows[i].Visible = true;
                        }
                    }

                }
                if (Jornada.Text.Equals("Tarde"))
                {
                    for (int i = 0; i < dataGridView3.Rows.Count; i++)
                    {
                        if (i < 6 || i > 11)
                        {
                            dataGridView3.Rows[i].Visible = false;
                        }
                        else
                        {
                            dataGridView3.Rows[i].Visible = true;
                        }
                    }
                }
                if (Jornada.Text.Equals("Nocturna"))
                {

                    for (int i = 0; i < dataGridView3.Rows.Count; i++)
                    {
                        if (i < 12)
                        {
                            dataGridView3.Rows[i].Visible = false;
                        }
                        else
                        {
                            dataGridView3.Rows[i].Visible = true;
                        }
                    }

                }
                if (Jornada.Text.Equals("Jornada continua"))
                {
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        if (i > 11)
                        {
                            dataGridView3.Rows[i].Visible = false;
                        }
                        else
                        {
                            dataGridView3.Rows[i].Visible = true;
                        }
                    }
                }
            }
            else
            {
                for (int i = 0; i < dataGridView3.Rows.Count; i++)
                {
                    dataGridView3.Rows[i].Visible = false;
                }
            }
        }
        /************* CARGA EL HORARIO GRUPO ******/
        public void cargar_horarioGRUPO()
        {
            dataGridView1.Rows.Clear();
            this.dataGridView1.Rows.Add("06:00 - 07:00");
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


            // Llamamos al metodo AbrirConexion() de la clase Conexion
            Conexion conexion = new Conexion();
            SqlCommand consulta, consulta2;
            conexion.AbrirConexion();
            string resultadoencontrado = "no";
            int[,] ID_HORARIO = new int[15, 7];

            // Realizamos la consulta a la base de datos

            consulta = new SqlCommand("SELECT HORARIO.ID_HORARIO,HORARIO.PERIODO,HORARIO.DIA,AMBIENTE.NOMBRE_AMBIENTE AS AMBIENTE,AREAS.NOMBRE AS AREA,INSTRUCTOR.NOMBRE AS INSTRUCTOR FROM HORARIO INNER JOIN AMBIENTE ON HORARIO.ID_AMBIENTE=AMBIENTE.ID_AMBIENTE INNER JOIN AREAS ON AREAS.ID=HORARIO.ID_AREA INNER JOIN INSTRUCTOR ON HORARIO.ID_INSTRUCTOR=INSTRUCTOR.ID_INSTRUCTOR AND HORARIO.ID_GRUPO=@ID_GRUPO AND HORARIO.TRIMESTRE='" + CbxTrimestre.Text + "'", conexion.GetConexion);

            consulta.CommandType = System.Data.CommandType.Text;

            consulta.Parameters.AddWithValue("@ID_GRUPO", CbxGrupos.Text);



            SqlDataReader reader = consulta.ExecuteReader();

            while (reader.Read())
            {
                int fila = 0;

                int columna = 1;

                if (Convert.ToString(reader["PERIODO"]).Equals("06:00 - 07:00"))
                {
                    fila = 0;

                }
                if (Convert.ToString(reader["PERIODO"]).Equals("07:00 - 08:00"))
                {
                    fila = 1;

                }
                else if (Convert.ToString(reader["PERIODO"]).Equals("08:00 - 09:00"))
                {
                    fila = 2;
                }

                else if (Convert.ToString(reader["PERIODO"]).Equals("09:00 - 10:00"))
                {
                    fila = 3;
                }
                else if (Convert.ToString(reader["PERIODO"]).Equals("10:00 - 11:00"))
                {
                    fila = 4;
                }

                else if (Convert.ToString(reader["PERIODO"]).Equals("11:00 - 12:00"))
                {
                    fila = 5;
                }
                else if (Convert.ToString(reader["PERIODO"]).Equals("12:00 - 13:00"))
                {
                    fila = 6;
                }
                else if (Convert.ToString(reader["PERIODO"]).Equals("13:00 - 14:00"))
                {
                    fila = 7;
                }
                else if (Convert.ToString(reader["PERIODO"]).Equals("14:00 - 15:00"))
                {
                    fila = 8;
                }
                else if (Convert.ToString(reader["PERIODO"]).Equals("15:00 - 16:00"))
                {
                    fila = 9;
                }
                else if (Convert.ToString(reader["PERIODO"]).Equals("16:00 - 17:00"))
                {
                    fila = 10;
                }
                else if (Convert.ToString(reader["PERIODO"]).Equals("17:00 - 18:00"))
                {
                    fila = 11;
                }
                else if (Convert.ToString(reader["PERIODO"]).Equals("18:00 - 19:00"))
                {
                    fila = 12;
                }
                else if (Convert.ToString(reader["PERIODO"]).Equals("19:00 - 20:00"))
                {
                    fila = 13;
                }
                else if (Convert.ToString(reader["PERIODO"]).Equals("20:00 - 21:00"))
                {
                    fila = 14;
                }
                else if (Convert.ToString(reader["PERIODO"]).Equals("21:00 - 22:00"))
                {
                    fila = 15;
                }


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

                try
                {
                    dataGridView1.Rows[fila].Cells[columna].Value = "Area: " + Convert.ToString(reader["AREA"]) + Environment.NewLine + Convert.ToString(reader["AMBIENTE"]) + Environment.NewLine + "INSTRUCTOR: " + Convert.ToString(reader["INSTRUCTOR"]);
                    ID_HORARIO[fila, columna] = Convert.ToInt16(reader["ID_HORARIO"]);

                    dataGridView1.Rows[fila].Cells[columna].Style.ForeColor = Color.White;

                    //dataGridView1.Rows[fila].Cells[columna].Style.SelectionForeColor = Color.FromArgb(4, 123, 117);

                    dataGridView1.Rows[fila].Cells[columna].Style.BackColor = Color.FromArgb(4, 123, 117);
                }
                catch (Exception f)
                {
                    MessageBox.Show(f.Message);
                }
            }

            reader.Close();



            for (int i = 0; i < 15; i++)
            {
                for (int x = 0; x < 7; x++)
                {
                    if (ID_HORARIO[i, x] != 0)
                    {
                        resultadoencontrado = "no";

                        conexion.AbrirConexion();

                        // consulta = new SqlCommand("SELECT DESCRIPCION_RESULTADO_TRANSVERSAL FROM RESULTADOS_PROGRAMADOS,RESULTADOS_TRANSVERSALES,HORARIO WHERE RESULTADOS_PROGRAMADOS.ID_HORARIO=HORARIO.ID_HORARIO AND HORARIO.ID_HORARIO=@ID_HORARIO AND RESULTADOS_PROGRAMADOS.ID_RESULTADO_TRANSVERSAL=RESULTADOS_TRANSVERSALES.ID_RESULTADO_TRANSVERSAL AND RESULTADOS_PROGRAMADOS.ID_RESULTADO_TRANSVERSAL IS NOT NULL AND HORARIO.ESTADO='ACTUAL'", conexion.GetConexion);
                        String csl = "SELECT DESCRIPCION FROM TIEMPO_RESULTADOS,RESULTADOS,HORARIO WHERE TIEMPO_RESULTADOS.ID_RESULTADO=HORARIO.ID_RESULTADO AND HORARIO.ID_HORARIO=@ID_HORARIO  AND " +
                                     "TIEMPO_RESULTADOS.ID_RESULTADO=RESULTADOS.ID AND TIEMPO_RESULTADOS.ID_RESULTADO IS NOT NULL AND HORARIO.ESTADO='ACTUAL'";

                        consulta = new SqlCommand(csl, conexion.GetConexion);



                        consulta.CommandType = CommandType.Text;

                        consulta.Parameters.AddWithValue("@ID_HORARIO", ID_HORARIO[i, x]);

                        SqlDataReader reader2 = consulta.ExecuteReader();

                        if (reader2.Read())
                        {
                            if (reader2["DESCRIPCION"] != null)
                            {

                                dataGridView1.Rows[i].Cells[x].Value = dataGridView1.Rows[i].Cells[x].Value + Environment.NewLine + "Resultado : " + Environment.NewLine + Convert.ToString(reader2["DESCRIPCION"]);

                                resultadoencontrado = "si";

                            }

                        }

                        reader2.Close();

                        if (resultadoencontrado.Equals("no"))
                        {

                            consulta2 = new SqlCommand("SELECT DESCRIPCION FROM TIEMPO_RESULTADOS ,RESULTADOS,HORARIO WHERE TIEMPO_RESULTADOS.ID_GRUPO=HORARIO.ID_GRUPO AND HORARIO.ID_HORARIO=@ID_HORARIO2 AND TIEMPO_RESULTADOS.ID_RESULTADO=RESULTADOS.ID AND TIEMPO_RESULTADOS.ID_RESULTADO IS NOT NULL AND HORARIO.ESTADO='ACTUAL'", conexion.GetConexion);

                            consulta2.CommandType = CommandType.Text;

                            consulta2.Parameters.AddWithValue("@ID_HORARIO2", ID_HORARIO[i, x]);

                            reader2 = consulta2.ExecuteReader();

                            if (reader2.Read())
                            {

                                dataGridView1.Rows[i].Cells[x].Value = dataGridView1.Rows[i].Cells[x].Value + Environment.NewLine + "Resultado : " + Environment.NewLine + Convert.ToString(reader2["DESCRIPCION"]);


                            }

                            reader2.Close();


                        }
                    }

                }
            }



            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                for (int x = 1; x <= 6; x++)
                {

                    if (dataGridView1.Rows[i].Cells[x].Style.BackColor == Color.White)
                    {
                        dataGridView1.Rows[i].Cells[x].Style.SelectionBackColor = Color.Transparent;

                        dataGridView1.Rows[i].Cells[x].Style.SelectionForeColor = Color.Transparent;
                    }
                }

            }
            if (estado.Text == "Activo")
            {
                if (Jornada.Text.Equals("Mañana"))
                {

                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        if (i > 5)
                        {
                            dataGridView1.Rows[i].Visible = false;
                        }
                        else
                        {
                            dataGridView1.Rows[i].Visible = true;
                        }
                    }

                }
                if (Jornada.Text.Equals("Tarde"))
                {
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        if (i < 6 || i > 11)
                        {
                            dataGridView1.Rows[i].Visible = false;
                        }
                        else
                        {
                            dataGridView1.Rows[i].Visible = true;
                        }
                    }
                }
                if (Jornada.Text.Equals("Nocturna"))
                {

                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        if (i < 12)
                        {
                            dataGridView1.Rows[i].Visible = false;
                        }
                        else
                        {
                            dataGridView1.Rows[i].Visible = true;
                        }
                    }

                }
                if (Jornada.Text.Equals("Jornada continua"))
                {
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        if (i > 11)
                        {
                            dataGridView1.Rows[i].Visible = false;
                        }
                        else
                        {
                            dataGridView1.Rows[i].Visible = true;
                        }
                    }
                }
            }
            else
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    dataGridView1.Rows[i].Visible = false;
                }
            }
        }
        public void AbrirPlaneacion()
        {
            exc.ApplicationClass excel = new exc.ApplicationClass();

            excel.Application.Workbooks.Add(true);

            int ColumnIndex = 0;

            //excel.Cells[1, 1] = "INSTRUCTOR: "+CbxInstructores.Text;

            excel.get_Range("A2", "H2").Font.Bold = true; //Letra negrita
            excel.get_Range("A2", "H2").Interior.ColorIndex = 10; //Color de Fondo, 9 es rojo oscuro, 
            //excel.get_Range("A4", "A17").Interior.ColorIndex = 10; //Color de Fondo, 9 es rojo oscuro, 

            //excel.get_Range("A1", "G1").Font.ColorIndex = 2; //Color de letra, 2 es blanco, entre 0-56
            //excel.get_Range("A1", "A14").Font.ColorIndex = 2; //Color de letra, 2 es blanco, entre 0-56

            excel.get_Range("A2", "H2").ColumnWidth = 25; //Ancho de la columna
            excel.get_Range("A2", "H2").HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter;

            excel.get_Range("A2", "H2").BorderAround(Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous, Microsoft.Office.Interop.Excel.XlBorderWeight.xlMedium, Microsoft.Office.Interop.Excel.XlColorIndex.xlColorIndexAutomatic, Microsoft.Office.Interop.Excel.XlColorIndex.xlColorIndexAutomatic); //Borde
            excel.get_Range("A3", "H3").BorderAround(Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous, Microsoft.Office.Interop.Excel.XlBorderWeight.xlMedium, Microsoft.Office.Interop.Excel.XlColorIndex.xlColorIndexAutomatic, Microsoft.Office.Interop.Excel.XlColorIndex.xlColorIndexAutomatic); //Borde
            excel.get_Range("A4", "H4").BorderAround(Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous, Microsoft.Office.Interop.Excel.XlBorderWeight.xlMedium, Microsoft.Office.Interop.Excel.XlColorIndex.xlColorIndexAutomatic, Microsoft.Office.Interop.Excel.XlColorIndex.xlColorIndexAutomatic); //Borde
            excel.get_Range("A5", "H5").BorderAround(Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous, Microsoft.Office.Interop.Excel.XlBorderWeight.xlMedium, Microsoft.Office.Interop.Excel.XlColorIndex.xlColorIndexAutomatic, Microsoft.Office.Interop.Excel.XlColorIndex.xlColorIndexAutomatic); //Borde
            excel.get_Range("A6", "H6").BorderAround(Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous, Microsoft.Office.Interop.Excel.XlBorderWeight.xlMedium, Microsoft.Office.Interop.Excel.XlColorIndex.xlColorIndexAutomatic, Microsoft.Office.Interop.Excel.XlColorIndex.xlColorIndexAutomatic); //Borde
            excel.get_Range("A7", "H7").BorderAround(Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous, Microsoft.Office.Interop.Excel.XlBorderWeight.xlMedium, Microsoft.Office.Interop.Excel.XlColorIndex.xlColorIndexAutomatic, Microsoft.Office.Interop.Excel.XlColorIndex.xlColorIndexAutomatic); //Borde
            excel.get_Range("A8", "H8").BorderAround(Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous, Microsoft.Office.Interop.Excel.XlBorderWeight.xlMedium, Microsoft.Office.Interop.Excel.XlColorIndex.xlColorIndexAutomatic, Microsoft.Office.Interop.Excel.XlColorIndex.xlColorIndexAutomatic); //Borde
            excel.get_Range("A9", "H9").BorderAround(Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous, Microsoft.Office.Interop.Excel.XlBorderWeight.xlMedium, Microsoft.Office.Interop.Excel.XlColorIndex.xlColorIndexAutomatic, Microsoft.Office.Interop.Excel.XlColorIndex.xlColorIndexAutomatic); //Borde
            excel.get_Range("A10", "H10").BorderAround(Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous, Microsoft.Office.Interop.Excel.XlBorderWeight.xlMedium, Microsoft.Office.Interop.Excel.XlColorIndex.xlColorIndexAutomatic, Microsoft.Office.Interop.Excel.XlColorIndex.xlColorIndexAutomatic); //Borde
            excel.get_Range("A11", "H11").BorderAround(Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous, Microsoft.Office.Interop.Excel.XlBorderWeight.xlMedium, Microsoft.Office.Interop.Excel.XlColorIndex.xlColorIndexAutomatic, Microsoft.Office.Interop.Excel.XlColorIndex.xlColorIndexAutomatic); //Borde
            excel.get_Range("A12", "H12").BorderAround(Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous, Microsoft.Office.Interop.Excel.XlBorderWeight.xlMedium, Microsoft.Office.Interop.Excel.XlColorIndex.xlColorIndexAutomatic, Microsoft.Office.Interop.Excel.XlColorIndex.xlColorIndexAutomatic); //Borde
            excel.get_Range("A13", "H13").BorderAround(Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous, Microsoft.Office.Interop.Excel.XlBorderWeight.xlMedium, Microsoft.Office.Interop.Excel.XlColorIndex.xlColorIndexAutomatic, Microsoft.Office.Interop.Excel.XlColorIndex.xlColorIndexAutomatic); //Borde
            excel.get_Range("A14", "H14").BorderAround(Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous, Microsoft.Office.Interop.Excel.XlBorderWeight.xlMedium, Microsoft.Office.Interop.Excel.XlColorIndex.xlColorIndexAutomatic, Microsoft.Office.Interop.Excel.XlColorIndex.xlColorIndexAutomatic); //Borde
            excel.get_Range("A15", "H15").BorderAround(Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous, Microsoft.Office.Interop.Excel.XlBorderWeight.xlMedium, Microsoft.Office.Interop.Excel.XlColorIndex.xlColorIndexAutomatic, Microsoft.Office.Interop.Excel.XlColorIndex.xlColorIndexAutomatic); //Borde
            excel.get_Range("A16", "H16").BorderAround(Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous, Microsoft.Office.Interop.Excel.XlBorderWeight.xlMedium, Microsoft.Office.Interop.Excel.XlColorIndex.xlColorIndexAutomatic, Microsoft.Office.Interop.Excel.XlColorIndex.xlColorIndexAutomatic); //Borde
            excel.get_Range("A17", "H17").BorderAround(Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous, Microsoft.Office.Interop.Excel.XlBorderWeight.xlMedium, Microsoft.Office.Interop.Excel.XlColorIndex.xlColorIndexAutomatic, Microsoft.Office.Interop.Excel.XlColorIndex.xlColorIndexAutomatic); //Borde
            excel.get_Range("A18", "H18").BorderAround(Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous, Microsoft.Office.Interop.Excel.XlBorderWeight.xlMedium, Microsoft.Office.Interop.Excel.XlColorIndex.xlColorIndexAutomatic, Microsoft.Office.Interop.Excel.XlColorIndex.xlColorIndexAutomatic); //Borde
            excel.get_Range("A19", "H19").BorderAround(Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous, Microsoft.Office.Interop.Excel.XlBorderWeight.xlMedium, Microsoft.Office.Interop.Excel.XlColorIndex.xlColorIndexAutomatic, Microsoft.Office.Interop.Excel.XlColorIndex.xlColorIndexAutomatic); //Borde


            excel.get_Range("A2", "A19").BorderAround(Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous, Microsoft.Office.Interop.Excel.XlBorderWeight.xlMedium, Microsoft.Office.Interop.Excel.XlColorIndex.xlColorIndexAutomatic, Microsoft.Office.Interop.Excel.XlColorIndex.xlColorIndexAutomatic); //Borde
            excel.get_Range("B2", "B19").BorderAround(Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous, Microsoft.Office.Interop.Excel.XlBorderWeight.xlMedium, Microsoft.Office.Interop.Excel.XlColorIndex.xlColorIndexAutomatic, Microsoft.Office.Interop.Excel.XlColorIndex.xlColorIndexAutomatic); //Borde
            excel.get_Range("C2", "C19").BorderAround(Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous, Microsoft.Office.Interop.Excel.XlBorderWeight.xlMedium, Microsoft.Office.Interop.Excel.XlColorIndex.xlColorIndexAutomatic, Microsoft.Office.Interop.Excel.XlColorIndex.xlColorIndexAutomatic); //Borde
            excel.get_Range("D2", "D19").BorderAround(Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous, Microsoft.Office.Interop.Excel.XlBorderWeight.xlMedium, Microsoft.Office.Interop.Excel.XlColorIndex.xlColorIndexAutomatic, Microsoft.Office.Interop.Excel.XlColorIndex.xlColorIndexAutomatic); //Borde
            excel.get_Range("E2", "E19").BorderAround(Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous, Microsoft.Office.Interop.Excel.XlBorderWeight.xlMedium, Microsoft.Office.Interop.Excel.XlColorIndex.xlColorIndexAutomatic, Microsoft.Office.Interop.Excel.XlColorIndex.xlColorIndexAutomatic); //Borde
            excel.get_Range("F2", "F19").BorderAround(Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous, Microsoft.Office.Interop.Excel.XlBorderWeight.xlMedium, Microsoft.Office.Interop.Excel.XlColorIndex.xlColorIndexAutomatic, Microsoft.Office.Interop.Excel.XlColorIndex.xlColorIndexAutomatic); //Borde
            excel.get_Range("G2", "G19").BorderAround(Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous, Microsoft.Office.Interop.Excel.XlBorderWeight.xlMedium, Microsoft.Office.Interop.Excel.XlColorIndex.xlColorIndexAutomatic, Microsoft.Office.Interop.Excel.XlColorIndex.xlColorIndexAutomatic); //Borde
            excel.get_Range("H2", "H19").BorderAround(Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous, Microsoft.Office.Interop.Excel.XlBorderWeight.xlMedium, Microsoft.Office.Interop.Excel.XlColorIndex.xlColorIndexAutomatic, Microsoft.Office.Interop.Excel.XlColorIndex.xlColorIndexAutomatic); //Borde

            excel.get_Range("A3", "H3").HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter;
            excel.get_Range("A4", "H4").HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter;
            excel.get_Range("A5", "H5").HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter;
            excel.get_Range("A6", "H6").HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter;
            excel.get_Range("A7", "H7").HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter;
            excel.get_Range("A8", "H8").HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter;
            excel.get_Range("A9", "H9").HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter;
            excel.get_Range("A10", "H10").HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter;
            excel.get_Range("A11", "H11").HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter;
            excel.get_Range("A12", "H12").HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter;
            excel.get_Range("A13", "H13").HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter;
            excel.get_Range("A14", "H14").HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter;
            excel.get_Range("A15", "H15").HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter;
            excel.get_Range("A16", "H16").HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter;
            excel.get_Range("A17", "H17").HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter;
            excel.get_Range("A18", "H18").HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter;
            excel.get_Range("A19", "H19").HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter;


            excel.get_Range("A2", "A19").HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter;
            excel.get_Range("B2", "B19").HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter;
            excel.get_Range("C2", "C19").HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter;
            excel.get_Range("D2", "D19").HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter;
            excel.get_Range("E2", "E19").HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter;
            excel.get_Range("F2", "F19").HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter;
            excel.get_Range("G2", "G19").HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter;
            excel.get_Range("H2", "H19").HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter;

            string[] Encabezados = { "CODIGO", "NOMBRE", "FICHA", "FECHA INICIAL", "FECHA FINAL", "CANTIDAD ALUMNOS", "DURACION", "INSTRUCTOR LIDER" };
            foreach (string col in Encabezados)
            {

                ColumnIndex++;

                excel.Cells[2, ColumnIndex] = col;


            }
            System.Data.DataTable dt = new System.Data.DataTable();
            try
            {

                Conexion conexion = new Conexion();
                conexion.AbrirConexion();
                string SQL = "select p.ID_PROGRAMA,p.NOMBRE_PROGRAMA AS NOMBRE_PROGRAMA,g.ID_GRUPO,g.INICIO,g.FECHA_FINAL,g.CANTIDAD_ALUMNOS,p.DURACION_PROGRAMA,g.INSTRUCTOR_LIDER from PROGRAMA p inner join GRUPO g ON p.ID_PROGRAMA=g.ID_PROGRAMA";
                SqlCommand consulta = new SqlCommand(SQL, conexion.GetConexion);
                consulta.ExecuteNonQuery();
                System.Data.SqlClient.SqlDataAdapter DA = new System.Data.SqlClient.SqlDataAdapter(consulta);
                DA.Fill(dt);
                DataGridView grilla = new DataGridView();
                grilla.DataSource = dt;
                int rowIndex = 2;
                int fila = -1, Col = -1;
                foreach (DataRow row in dt.Rows)
                {

                    rowIndex++;
                    fila++;
                    ColumnIndex = 0;
                    Col = -1;
                    foreach (DataColumn col in dt.Columns)
                    {

                        ColumnIndex++;
                        Col++;
                        excel.Cells[rowIndex, ColumnIndex] = dt.Rows[fila][Col].ToString();

                    }

                }

                excel.Visible = true;

                exc.Worksheet worksheet = (exc.Worksheet)excel.ActiveSheet;
            }
            catch (Exception error)
            {
                VentanaMsjes ventana2 = new VentanaMsjes("ERROR", error.Message);
                ventana2.iconoPregunta.Image = global::Ej_Interfaz_Proyecto.Properties.Resources.icn_err;
                ventana2.btnAceptar.Visible = true;
                ventana2.ShowDialog();
            }

            //worksheet.Activate();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            AbrirPlaneacion();
        }

        private void GenerarHorario_Load(object sender, EventArgs e)
        {
            CbxInstructores.Enabled = false;
            limpiarMatriz();
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        public Boolean ConsultarEstadoGrupo()
        {

            return true;
        }

        private void treeView1_Click(object sender, EventArgs e)
        {
           
        }

        public void cargar_horarioINSTRUCTOR()
        {
            dataGridView2.Rows.Clear();
            this.dataGridView2.Rows.Add("06:00 - 07:00");
            this.dataGridView2.Rows.Add("07:00 - 08:00");
            this.dataGridView2.Rows.Add("08:00 - 09:00");
            this.dataGridView2.Rows.Add("09:00 - 10:00");
            this.dataGridView2.Rows.Add("10:00 - 11:00");
            this.dataGridView2.Rows.Add("11:00 - 12:00");
            this.dataGridView2.Rows.Add("12:00 - 13:00");
            this.dataGridView2.Rows.Add("13:00 - 14:00");
            this.dataGridView2.Rows.Add("14:00 - 15:00");
            this.dataGridView2.Rows.Add("15:00 - 16:00");
            this.dataGridView2.Rows.Add("16:00 - 17:00");
            this.dataGridView2.Rows.Add("17:00 - 18:00");
            this.dataGridView2.Rows.Add("18:00 - 19:00");
            this.dataGridView2.Rows.Add("19:00 - 20:00");
            this.dataGridView2.Rows.Add("20:00 - 21:00");
            this.dataGridView2.Rows.Add("21:00 - 22:00");
            horasInstructor = 0;

            if (CbxInstructores.Text != "")
            {
                Conexion conexion = new Conexion();
                SqlCommand consulta, consulta2;
                conexion.AbrirConexion();

                string resultadoencontrado = "no";
                int[,] ID_HORARIO = new int[15, 7];

                consulta = new SqlCommand("SELECT HORARIO.ID_HORARIO,HORARIO.PERIODO,HORARIO.DIA,AMBIENTE.NOMBRE_AMBIENTE AS AMBIENTE,HORARIO.ID_GRUPO AS NUMERO_DE_FICHA,AREAS.NOMBRE AS AREA FROM HORARIO INNER JOIN AMBIENTE ON HORARIO.ID_AMBIENTE=AMBIENTE.ID_AMBIENTE INNER JOIN AREAS ON AREAS.ID=HORARIO.ID_AREA INNER JOIN INSTRUCTOR ON HORARIO.ID_INSTRUCTOR=INSTRUCTOR.ID_INSTRUCTOR AND HORARIO.ID_INSTRUCTOR='" +CbxInstructores.SelectedValue.ToString()+ "' AND HORARIO.TRIMESTRE_ANIO ='" + textBox3.Text + "'", conexion.GetConexion);
                consulta.CommandType = CommandType.Text;

                


                SqlDataReader reader = consulta.ExecuteReader();

                while (reader.Read())
                {
                    int fila = 0;

                    int columna = 1;

                    if (Convert.ToString(reader["PERIODO"]).Equals("06:00 - 07:00"))
                    {
                        fila = 0;

                    }
                    if (Convert.ToString(reader["PERIODO"]).Equals("07:00 - 08:00"))
                    {
                        fila = 1;

                    }
                    else if (Convert.ToString(reader["PERIODO"]).Equals("08:00 - 09:00"))
                    {
                        fila = 2;
                    }

                    else if (Convert.ToString(reader["PERIODO"]).Equals("09:00 - 10:00"))
                    {
                        fila = 3;
                    }
                    else if (Convert.ToString(reader["PERIODO"]).Equals("10:00 - 11:00"))
                    {
                        fila = 4;
                    }

                    else if (Convert.ToString(reader["PERIODO"]).Equals("11:00 - 12:00"))
                    {
                        fila = 5;
                    }
                    else if (Convert.ToString(reader["PERIODO"]).Equals("12:00 - 13:00"))
                    {
                        fila = 6;
                    }
                    else if (Convert.ToString(reader["PERIODO"]).Equals("13:00 - 14:00"))
                    {
                        fila = 7;
                    }
                    else if (Convert.ToString(reader["PERIODO"]).Equals("14:00 - 15:00"))
                    {
                        fila = 8;
                    }
                    else if (Convert.ToString(reader["PERIODO"]).Equals("15:00 - 16:00"))
                    {
                        fila = 9;
                    }
                    else if (Convert.ToString(reader["PERIODO"]).Equals("16:00 - 17:00"))
                    {
                        fila = 10;
                    }
                    else if (Convert.ToString(reader["PERIODO"]).Equals("17:00 - 18:00"))
                    {
                        fila = 11;
                    }
                    else if (Convert.ToString(reader["PERIODO"]).Equals("18:00 - 19:00"))
                    {
                        fila = 12;
                    }
                    else if (Convert.ToString(reader["PERIODO"]).Equals("19:00 - 20:00"))
                    {
                        fila = 13;
                    }
                    else if (Convert.ToString(reader["PERIODO"]).Equals("20:00 - 21:00"))
                    {
                        fila = 14;
                    }
                    else if (Convert.ToString(reader["PERIODO"]).Equals("21:00 - 22:00"))
                    {
                        fila = 15;
                    }


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

                    horasInstructor++;

                    dataGridView2.Rows[fila].Cells[columna].Value = "Area: " + Convert.ToString(reader["AREA"]) + Environment.NewLine + Convert.ToString(reader["AMBIENTE"]) + Environment.NewLine + "Numero De Ficha: " + Convert.ToString(reader["NUMERO_DE_FICHA"]);
                    ID_HORARIO[fila, columna] = Convert.ToInt16(reader["ID_HORARIO"]);


                    dataGridView2.Rows[fila].Cells[columna].Style.ForeColor = Color.White;
                    dataGridView2.Rows[fila].Cells[columna].Style.BackColor = Color.FromArgb(4, 123, 117);

                }

                reader.Close();

                textBox2.Text = "" + horasInstructor;


                for (int i = 0; i < 15; i++)
                {
                    for (int x = 0; x < 7; x++)
                    {
                        if (ID_HORARIO[i, x] != 0)
                        {
                            resultadoencontrado = "no";

                            conexion.AbrirConexion();

                            // consulta = new SqlCommand("SELECT DESCRIPCION_RESULTADO_TRANSVERSAL FROM RESULTADOS_PROGRAMADOS,RESULTADOS_TRANSVERSALES,HORARIO WHERE RESULTADOS_PROGRAMADOS.ID_HORARIO=HORARIO.ID_HORARIO AND HORARIO.ID_HORARIO=@ID_HORARIO AND RESULTADOS_PROGRAMADOS.ID_RESULTADO_TRANSVERSAL=RESULTADOS_TRANSVERSALES.ID_RESULTADO_TRANSVERSAL AND RESULTADOS_PROGRAMADOS.ID_RESULTADO_TRANSVERSAL IS NOT NULL AND HORARIO.ESTADO='ACTUAL'", conexion.GetConexion);
                            String csl = "SELECT DESCRIPCION FROM TIEMPO_RESULTADOS,RESULTADOS,HORARIO WHERE TIEMPO_RESULTADOS.ID_RESULTADO=HORARIO.ID_RESULTADO AND HORARIO.ID_HORARIO=@ID_HORARIO  AND " +
                                         "TIEMPO_RESULTADOS.ID_RESULTADO=RESULTADOS.ID AND TIEMPO_RESULTADOS.ID_RESULTADO IS NOT NULL AND HORARIO.ESTADO='ACTUAL'";

                            consulta = new SqlCommand(csl, conexion.GetConexion);



                            consulta.CommandType = CommandType.Text;

                            consulta.Parameters.AddWithValue("@ID_HORARIO", ID_HORARIO[i, x]);

                            SqlDataReader reader2 = consulta.ExecuteReader();

                            if (reader2.Read())
                            {
                                if (reader2["DESCRIPCION"] != null)
                                {

                                    dataGridView2.Rows[i].Cells[x].Value = dataGridView2.Rows[i].Cells[x].Value + Environment.NewLine + "Resultado : " + Environment.NewLine + Convert.ToString(reader2["DESCRIPCION"]);

                                    resultadoencontrado = "si";

                                }

                            }

                            reader2.Close();

                            if (resultadoencontrado.Equals("no"))
                            {

                                consulta2 = new SqlCommand("SELECT DESCRIPCION FROM TIEMPO_RESULTADOS ,RESULTADOS,HORARIO WHERE TIEMPO_RESULTADOS.ID_GRUPO=HORARIO.ID_GRUPO AND HORARIO.ID_HORARIO=@ID_HORARIO2 AND TIEMPO_RESULTADOS.ID_RESULTADO=RESULTADOS.ID AND TIEMPO_RESULTADOS.ID_RESULTADO IS NOT NULL AND HORARIO.ESTADO='ACTUAL'", conexion.GetConexion);

                                consulta2.CommandType = CommandType.Text;

                                consulta2.Parameters.AddWithValue("@ID_HORARIO2", ID_HORARIO[i, x]);

                                reader2 = consulta2.ExecuteReader();

                                if (reader2.Read())
                                {

                                    dataGridView2.Rows[i].Cells[x].Value = dataGridView2.Rows[i].Cells[x].Value + Environment.NewLine + "Resultado : " + Environment.NewLine + Convert.ToString(reader2["DESCRIPCION"]);


                                }

                                reader2.Close();


                            }
                        }

                    }
                }



                for (int i = 0; i < dataGridView2.Rows.Count; i++)
                {
                    for (int x = 1; x <= 6; x++)
                    {

                        if (dataGridView2.Rows[i].Cells[x].Style.BackColor == Color.FromArgb(4, 123, 117))
                        {
                            dataGridView2.Rows[i].Cells[x].Style.SelectionBackColor = Color.Transparent;

                            dataGridView2.Rows[i].Cells[x].Style.SelectionForeColor = Color.Transparent;
                        }
                    }

                }


            }

            if (estado.Text == "Activo")
            {
                if (Jornada.Text.Equals("Mañana"))
                {

                    for (int i = 0; i < dataGridView2.Rows.Count; i++)
                    {
                        if (i > 5)
                        {
                            dataGridView2.Rows[i].Visible = false;
                        }
                        else
                        {
                            dataGridView2.Rows[i].Visible = true;
                        }
                    }

                }
                if (Jornada.Text.Equals("Tarde"))
                {
                    for (int i = 0; i < dataGridView2.Rows.Count; i++)
                    {
                        if (i < 6 || i > 11)
                        {
                            dataGridView2.Rows[i].Visible = false;
                        }
                        else
                        {
                            dataGridView2.Rows[i].Visible = true;
                        }
                    }
                }
                if (Jornada.Text.Equals("Nocturna"))
                {

                    for (int i = 0; i < dataGridView2.Rows.Count; i++)
                    {
                        if (i < 12)
                        {
                            dataGridView2.Rows[i].Visible = false;
                        }
                        else
                        {
                            dataGridView2.Rows[i].Visible = true;
                        }
                    }

                }
                if (Jornada.Text.Equals("Jornada continua"))
                {
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        if (i > 11)
                        {
                            dataGridView2.Rows[i].Visible = false;
                        }
                        else
                        {
                            dataGridView2.Rows[i].Visible = true;
                        }
                    }
                }
            }
            else
            {
                for (int i = 0; i < dataGridView2.Rows.Count; i++)
                {
                    dataGridView2.Rows[i].Visible = false;
                }
            }

         }
    }
}
