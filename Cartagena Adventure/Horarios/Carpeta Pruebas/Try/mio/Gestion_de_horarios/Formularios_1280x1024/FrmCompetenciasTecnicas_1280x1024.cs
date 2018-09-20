using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ej_Interfaz_Proyecto.Clases_1280x1024;
using Ej_Interfaz_Proyecto.Formularios_1280x1024;

namespace Ej_Interfaz_Proyecto.Formularios_1280x1024
{
    public partial class FrmCompetenciasTecnicas_1280x1024 : Form
    {
        // Declaraciones del API PARA MOVER EL FORMULARIO
        [System.Runtime.InteropServices.DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        //
        [System.Runtime.InteropServices.DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        FrmPrincipal_1280x1024 principal;
        public string OpcionCompetencia="";
        public string OpcionResultados = "";
        string id_competencia="";
        public string tipoCompetencia = "";

        //instancia unica****************************************************
        private static FrmCompetenciasTecnicas_1280x1024 m_FormDefInstance;
        public static FrmCompetenciasTecnicas_1280x1024 DefInstance
        {
            get
            {
                if (m_FormDefInstance == null || m_FormDefInstance.IsDisposed)
                    m_FormDefInstance = new FrmCompetenciasTecnicas_1280x1024();
                return m_FormDefInstance;
            }
            set
            {
                m_FormDefInstance = value;
            }
        }
        ///**********************************************************
        public FrmCompetenciasTecnicas_1280x1024(FrmPrincipal_1280x1024 principal)
        {
            this.principal = principal;
            InitializeComponent();

 

            this.BackColor = Color.FromArgb(4, 123, 117);
        }

        public FrmCompetenciasTecnicas_1280x1024()
        {
            InitializeComponent();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void FrmResultados_Load(object sender, EventArgs e)
        {
            ListadoProgramas();
           
            id_competencia = "";
        }

        private void ListadoProgramas()
        {
            CmbProgramas.DataSource = Programa_Formacion.ListadoGeneralDeProgramas();
            CmbProgramas.DisplayMember = "NOMBRE_PROGRAMA";
            CmbProgramas.ValueMember = "ID_PROGRAMA";
            CmbProgramas.SelectedIndex = -1;

        }

        public void ListadoCompetenciasTecnicas()
        {
            try
            {
                dgvCompetencia_tecnicas.AutoGenerateColumns = false;

                
                DataTable dt = Competencias_tecnicas.ListadoDeCompetencias(CmbProgramas.SelectedValue.ToString());

                dgvCompetencia_tecnicas.Columns[0].DataPropertyName = "ID";
                dgvCompetencia_tecnicas.Columns[1].DataPropertyName = "DESCRIPCION";
                dgvCompetencia_tecnicas.Columns[2].DataPropertyName = "DURACION";
                dgvCompetencia_tecnicas.DataSource = dt;

            }
            catch (Exception ex)
            {
                VentanaMsjes ventana2 = new VentanaMsjes("ERROR", ex.Message);
                ventana2.iconoPregunta.Image = global::Ej_Interfaz_Proyecto.Properties.Resources.icn_err;
                ventana2.btnAceptar.Visible = true;
                ventana2.ShowDialog();
            }
        }

        private void ListadoIncrementalCompetencias(string parametro, string programa, string texto)
        {
            try
            {
                dgvCompetencia_tecnicas.DataSource = null;
                dgvCompetencia_tecnicas.AutoGenerateColumns = false;

                DataTable dt = Competencias_tecnicas.ListadoIncrementalDeCompetencias(parametro, programa, texto);
                dgvCompetencia_tecnicas.DataSource = dt;
                dgvCompetencia_tecnicas.Columns[0].DataPropertyName = "ID";
                dgvCompetencia_tecnicas.Columns[1].DataPropertyName = "DESCRIPCION";
                dgvCompetencia_tecnicas.Columns[2].DataPropertyName = "DURACION";
            }
            catch (Exception ex)
            {
                VentanaMsjes ventana2 = new VentanaMsjes("ERROR", ex.Message);
                ventana2.iconoPregunta.Image = global::Ej_Interfaz_Proyecto.Properties.Resources.icn_err;
                ventana2.btnAceptar.Visible = true;
                ventana2.ShowDialog();
            }
        }

        private void ListadoIncrementalResultados(string texto)
        {
            try
            {
                DGVResultadostecnicos.AutoGenerateColumns = false;
                DataTable dt = ResultadosTecnicos.ListadoIncrementalIDeResultados(texto, id_competencia);

                DGVResultadostecnicos.Columns["CodigoResultado"].DataPropertyName = "ID";
                DGVResultadostecnicos.Columns["DescriResultado"].DataPropertyName = "DESCRIPCION";
                DGVResultadostecnicos.Columns[2].DataPropertyName = "DURACION";
                DGVResultadostecnicos.DataSource = dt;


            }
            catch (Exception ex)
            {
                VentanaMsjes ventana2 = new VentanaMsjes("ERROR", ex.Message);
                ventana2.iconoPregunta.Image = global::Ej_Interfaz_Proyecto.Properties.Resources.icn_err;
                ventana2.btnAceptar.Visible = true;
                ventana2.ShowDialog();
            }
        }

        
        public void ListadoResultadosTecnicos(string Idcompetencia)
        {
            try
            {
                DGVResultadostecnicos.DataSource = null;
                DGVResultadostecnicos.AutoGenerateColumns = false;

                DataTable dt = ResultadosTecnicos.ListadoDeResultados(Idcompetencia);

                DGVResultadostecnicos.Columns[0].DataPropertyName = "ID";
                DGVResultadostecnicos.Columns[1].DataPropertyName = "DESCRIPCION";
                DGVResultadostecnicos.Columns[2].DataPropertyName = "DURACION";
                DGVResultadostecnicos.DataSource = dt;


            }
            catch (Exception ex)
            {
                VentanaMsjes ventana2 = new VentanaMsjes("ERROR", ex.Message);
                ventana2.iconoPregunta.Image = global::Ej_Interfaz_Proyecto.Properties.Resources.icn_err;
                ventana2.btnAceptar.Visible = true;
                ventana2.ShowDialog();
            }
        }

        private void LimpiarSeleccion()
        {
            for (int i = 0; i < dgvCompetencia_tecnicas.Rows.Count; i++)
            {
                dgvCompetencia_tecnicas.Rows[i].Selected = false;
            }

            for (int i = 0; i < DGVResultadostecnicos.Rows.Count; i++)
            {
                DGVResultadostecnicos.Rows[i].Selected = false;
            }


        }

       /* public void ListadoCompetenciasTransversales()
        {
            try
            {
                dgvCompetencia_transversales.AutoGenerateColumns = false;

                DataTable dt = Competencias_transversales.ListadoDeCompetenciasTransversales(CmbProgramas.SelectedValue.ToString());

                dgvCompetencia_transversales.Columns[0].DataPropertyName = "IDCOMP";
                dgvCompetencia_transversales.Columns[1].DataPropertyName = "DESCRIPCION_TRANSVERSAL";
                dgvCompetencia_transversales.DataSource = dt;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }*/

        

      /*  public void ListadoResultadosTransversales(string Idcompetencia)
        {
            try
            {

                DGVResultadostransversales.AutoGenerateColumns = false;

                DataTable dt = ResultadosTransversales.ListadoDeResultados(Idcompetencia);

                DGVResultadostransversales.Columns[0].DataPropertyName = "ID_RESULTADO_TRANSVERSAL";
                DGVResultadostransversales.Columns[1].DataPropertyName = "DESCRIPCION_RESULTADO_TRANSVERSAL";

                DGVResultadostransversales.DataSource = dt;


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }*/



        private void dgvCompetencia_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvCompetencia_tecnicas.SelectedRows.Count == 1)
            {
                ListadoResultadosTecnicos(dgvCompetencia_tecnicas[0, dgvCompetencia_tecnicas.CurrentRow.Index].Value.ToString());

                tipoCompetencia = "Tecnica";
                id_competencia = dgvCompetencia_tecnicas[0, dgvCompetencia_tecnicas.CurrentRow.Index].Value.ToString();


            }
            else
            {
                DGVResultadostecnicos.DataSource = null;
            }

        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {  
            if (rdbId.Checked)
            {
                ListadoIncrementalCompetencias("Id", CmbProgramas.SelectedValue.ToString(), txtBuscarComp.Text.Trim());
            }
            if (rdbNombre.Checked)
            {
                ListadoIncrementalCompetencias("Descripcion", CmbProgramas.SelectedValue.ToString(), txtBuscarComp.Text.Trim());
            }
        }

        

        private void CmbProgramas_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                ListadoCompetenciasTecnicas();
            }
            catch (Exception ex)
            {
                VentanaMsjes ventana2 = new VentanaMsjes("ERROR", ex.Message);
                ventana2.iconoPregunta.Image = global::Ej_Interfaz_Proyecto.Properties.Resources.icn_err;
                ventana2.btnAceptar.Visible = true;
                ventana2.ShowDialog();
            }

        }

        private void rdbId_CheckedChanged(object sender, EventArgs e)
        {
            txtBuscarComp.Enabled = true;
            txtBuscarComp.Text = "";
        }

        private void rdbNombre_CheckedChanged(object sender, EventArgs e)
        {
            txtBuscarComp.Enabled = true;
            txtBuscarComp.Text = "";
        }

        private void MdfCompetencias_Click(object sender, EventArgs e)
        {
           

        }

        private void MdfResultados_Click(object sender, EventArgs e)
        {
            
           
        }

        private void txtBuscarResultado_TextChanged(object sender, EventArgs e)
        {
            ListadoIncrementalResultados(txtBuscarResultado.Text.Trim());
        }

        private void btnAgregarComp_Click(object sender, EventArgs e)
        {
           
        }

        private void btnRegistrarResultado_Click(object sender, EventArgs e)
        {
           
        }

        private void pictureBox7_MouseLeave(object sender, EventArgs e)
        {
            this.pictureBox7.Image = global::Ej_Interfaz_Proyecto.Properties.Resources.btn_act_normal;
        }

        private void pictureBox7_MouseMove(object sender, MouseEventArgs e)
        {
            this.pictureBox7.Image = global::Ej_Interfaz_Proyecto.Properties.Resources.btn_act_focus;
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            OpcionCompetencia = "Modificar";
            
            if (dgvCompetencia_tecnicas.SelectedRows.Count == 1)
            {
                FrmRegistroCompetencias_1280x1024 Resultados = new FrmRegistroCompetencias_1280x1024(id_competencia,CmbProgramas.SelectedValue.ToString(), this);
                Resultados.MdiParent = principal;
                Resultados.Show();
            }
            else
            {
                VentanaMsjes ventana2 = new VentanaMsjes("AVISO", "Debe Seleccionar La Competencia");
                ventana2.iconoPregunta.Image = global::Ej_Interfaz_Proyecto.Properties.Resources.icn_inf;
                ventana2.btnAceptar.Visible = true;
                ventana2.ShowDialog();
            }
        }

        private void pictureBox8_MouseLeave(object sender, EventArgs e)
        {
            this.pictureBox8.Image = global::Ej_Interfaz_Proyecto.Properties.Resources.btn_mas_normal;
        }

        private void pictureBox8_MouseMove(object sender, MouseEventArgs e)
        {
            this.pictureBox8.Image = global::Ej_Interfaz_Proyecto.Properties.Resources.btn_mas_focus;
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(CmbProgramas.Text))
            {
                OpcionCompetencia = "Registrar";
                FrmRegistroCompetencias_1280x1024 Competencias = new FrmRegistroCompetencias_1280x1024("",CmbProgramas.SelectedValue.ToString(), this);
                Competencias.MdiParent = principal;
                Competencias.Show();
            }
            else
            {
                VentanaMsjes ventana2 = new VentanaMsjes("AVISO", "Debe Seleccionar el programa de formación");
                ventana2.iconoPregunta.Image = global::Ej_Interfaz_Proyecto.Properties.Resources.icn_inf;
                ventana2.btnAceptar.Visible = true;
                ventana2.ShowDialog();
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
           // this.pictureBox3.Image = global::Ej_Interfaz_Proyecto.Properties.Resources.btn_min_normal2;
        }

        private void pictureBox3_MouseMove(object sender, MouseEventArgs e)
        {
           // this.pictureBox3.Image = global::Ej_Interfaz_Proyecto.Properties.Resources.btn_min_focus2;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            //WindowState = FormWindowState.Minimized;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            OpcionResultados = "Modificar";

            if (dgvCompetencia_tecnicas.SelectedRows.Count == 0)
            {
                VentanaMsjes ventana2 = new VentanaMsjes("AVISO", "Debe Seleccionar la Competencia Luego El Resultado");
                ventana2.iconoPregunta.Image = global::Ej_Interfaz_Proyecto.Properties.Resources.icn_inf;
                ventana2.btnAceptar.Visible = true;
                ventana2.ShowDialog();
               
                return;
            }
            else
            {
                if (DGVResultadostecnicos.SelectedRows.Count == 0)
                {
                    VentanaMsjes ventana2 = new VentanaMsjes("AVISO", "Debe Seleccionar El Resultado");
                    ventana2.iconoPregunta.Image = global::Ej_Interfaz_Proyecto.Properties.Resources.icn_inf;
                    ventana2.btnAceptar.Visible = true;
                    ventana2.ShowDialog();
                    
                    return;
                }
                else
                {
                    FrmRegistroResultados_1280x1024 Resultados = new FrmRegistroResultados_1280x1024(id_competencia, this);
                    Resultados.MdiParent = principal;
                    Resultados.Show();
                }
            }
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            string op = "";
            OpcionResultados = "Registrar";

            for (int i = 0; i < dgvCompetencia_tecnicas.Rows.Count; i++)
            {
                if (dgvCompetencia_tecnicas.Rows[i].Selected == true)
                {
                    op = "hay_seleccion";

                }


            }

            if (op == "hay_seleccion")
            {

                FrmRegistroResultados_1280x1024 Resultados = new FrmRegistroResultados_1280x1024(id_competencia, this);
                Resultados.MdiParent = principal;
                Resultados.Show();

            }
            else
            {
                VentanaMsjes ventana2 = new VentanaMsjes("AVISO", "Debe Seleccionar La Competencia");
                ventana2.iconoPregunta.Image = global::Ej_Interfaz_Proyecto.Properties.Resources.icn_inf;
                ventana2.btnAceptar.Visible = true;
                ventana2.ShowDialog();

           
            }
        }

        private void pictureBox9_MouseLeave(object sender, EventArgs e)
        {
            this.pictureBox9.Image = global::Ej_Interfaz_Proyecto.Properties.Resources.btn_act_normal;
        }

        private void pictureBox9_MouseMove(object sender, MouseEventArgs e)
        {
            this.pictureBox9.Image = global::Ej_Interfaz_Proyecto.Properties.Resources.btn_act_focus;
        }

        private void pictureBox10_MouseLeave(object sender, EventArgs e)
        {
            this.pictureBox10.Image = global::Ej_Interfaz_Proyecto.Properties.Resources.btn_mas_normal;
        }

        private void pictureBox10_MouseMove(object sender, MouseEventArgs e)
        {
            this.pictureBox10.Image = global::Ej_Interfaz_Proyecto.Properties.Resources.btn_mas_focus;
        }

        private void FrmCompetenciasTecnicas_MouseDown(object sender, MouseEventArgs e)
        {

            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnEliminarCompetencia_Click(object sender, EventArgs e)
        {
            OpcionCompetencia = "Eliminar";


            if (dgvCompetencia_tecnicas.SelectedRows.Count == 1)
            {
                dgvCompetencia_tecnicas.DataSource = Competencias_tecnicas.eliminarCompetencia(dgvCompetencia_tecnicas.CurrentRow.Cells[0].Value.ToString(),"1",CmbProgramas.SelectedValue.ToString());
                VentanaMsjes ventana2 = new VentanaMsjes("Elimicación", "¡Elimicación exitosa!");
                ventana2.iconoPregunta.Image = global::Ej_Interfaz_Proyecto.Properties.Resources.icn_inf;
                ventana2.btnAceptar.Visible = true;
                ventana2.ShowDialog();
            }
            else
            {
                VentanaMsjes ventana2 = new VentanaMsjes("AVISO", "Debe Seleccionar La Competencia");
                ventana2.iconoPregunta.Image = global::Ej_Interfaz_Proyecto.Properties.Resources.icn_inf;
                ventana2.btnAceptar.Visible = true;
                ventana2.ShowDialog();
            }
        }


        private void pictureBoxeliminar_MouseLeave(object sender, EventArgs e)
        {
            btnEliminarCompetencia.BackColor=System.Drawing.Color.FromArgb(0,64,64);
            this.btnEliminarCompetencia.Image = global::Ej_Interfaz_Proyecto.Properties.Resources.delete1;
           
        }

        private void pictureBoxeliminar1_MouseMove(object sender, MouseEventArgs e)
        {
            btnEliminarCompetencia.BackColor = Color.White;
            this.btnEliminarCompetencia.Image = global::Ej_Interfaz_Proyecto.Properties.Resources.delete;
        }

        private void pictureBoxeliresul_MouseLeave(object sender, EventArgs e)
        {
            btnEliminarResultado.BackColor = System.Drawing.Color.FromArgb(0, 64, 64);
            this.btnEliminarResultado.Image = global::Ej_Interfaz_Proyecto.Properties.Resources.delete1;
        }

        private void pictureBoxeliresultado_MouseMove(object sender, MouseEventArgs e)
        {
            btnEliminarResultado.BackColor = Color.White;
            this.btnEliminarResultado.Image = global::Ej_Interfaz_Proyecto.Properties.Resources.delete;
        }

        private void btnEliminarResultado_Click(object sender, EventArgs e)
        {
            OpcionResultados = "Eliminar";
            if (dgvCompetencia_tecnicas.SelectedRows.Count == 1)
            {
                dgvCompetencia_tecnicas.DataSource = Competencias_tecnicas.eliminarCompetencia(DGVResultadostecnicos.CurrentRow.Cells[0].Value.ToString(), "1", CmbProgramas.SelectedValue.ToString());
                VentanaMsjes ventana2 = new VentanaMsjes("Elimicación", "¡Elimicación exitosa!");
                ventana2.iconoPregunta.Image = global::Ej_Interfaz_Proyecto.Properties.Resources.icn_inf;
                ventana2.btnAceptar.Visible = true;
                ventana2.ShowDialog();
            }
            else
            {
                VentanaMsjes ventana2 = new VentanaMsjes("AVISO", "Debe Seleccionar un resultado");
                ventana2.iconoPregunta.Image = global::Ej_Interfaz_Proyecto.Properties.Resources.icn_inf;
                ventana2.btnAceptar.Visible = true;
                ventana2.ShowDialog();
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty( CmbProgramas.Text.ToString()))
            {
                VentanaMsjes ventana2 = new VentanaMsjes("AVISO", "Debe Seleccionar un el programa de formación");
                ventana2.iconoPregunta.Image = global::Ej_Interfaz_Proyecto.Properties.Resources.icn_inf;
                ventana2.btnAceptar.Visible = true;
                ventana2.ShowDialog();
            }
            else
            {
                Frmtrimestre_1280x1024 t = new Frmtrimestre_1280x1024(DGVResultadostecnicos.CurrentRow.Cells[0].Value.ToString(), this,DGVResultadostecnicos.CurrentRow.Cells[1].Value.ToString());
                t.ShowDialog();
            }
           
        }

        private void CmbProgramas_SelectedIndexChanged(object sender, EventArgs e)
        {
         
        }
    }
}
