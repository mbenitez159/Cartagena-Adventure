using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ej_Interfaz_Proyecto.Clases_1280x1024;
namespace Ej_Interfaz_Proyecto.Formularios_1280x1024
{
    public partial class FrmResultados_Instructor_1280x1024 : Form
    {
        // Declaraciones del API PARA MOVER EL FORMULARIO
        [System.Runtime.InteropServices.DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        //
        [System.Runtime.InteropServices.DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
   
        string id_instructor, nombre_instructor;
        DataTable dt;

        public FrmResultados_Instructor_1280x1024(String identificacion,String Nombre)
        {
            InitializeComponent();
            textBox1.Text = Nombre;
            nombre_instructor = Nombre;
            id_instructor = identificacion;

            this.btnGuardarResultados.ForeColor = Color.FromArgb(4, 123, 117);
            this.btnRemover.ForeColor = Color.FromArgb(4, 123, 117);
            this.BackColor = Color.FromArgb(4, 123, 117);
        }

        private void soloNumeros(KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;

            }
            else if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;

            }
            else if (char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;

            }
            else
            {
                e.Handled = true;
            }
        }

      

        ///////////////////////METODOS NUEVOS//////////////////////////

        private void ListadoProgramas()
        {
            cbProgramas_de_formacion.DataSource = Programa_Formacion.ListadoGeneralDeProgramas();
            cbProgramas_de_formacion.DisplayMember = "NOMBRE_PROGRAMA";
            cbProgramas_de_formacion.ValueMember = "ID_PROGRAMA";
            cbProgramas_de_formacion.SelectedIndex = -1;
        }

        public void ListadoCompetenciasTecnicas()
        {
            try
            {
                dgvCompetencias.AutoGenerateColumns = false;

               DataTable dt = Competencias_tecnicas.ListadoDeCompetencias(cbProgramas_de_formacion.SelectedValue.ToString());
       
                dgvCompetencias.Columns[0].DataPropertyName = "ID";
                dgvCompetencias.Columns[1].DataPropertyName = "DESCRIPCION";
                dgvCompetencias.Columns[2].DataPropertyName = "DURACION";
                dgvCompetencias.DataSource = dt;
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
                dgvResultadosCompetencia.DataSource = null;
                dgvResultadosCompetencia.AutoGenerateColumns = false;

                DataTable dt = ResultadosTecnicos.ListadoDeResultados(Idcompetencia);

                dgvResultadosCompetencia.Columns[0].DataPropertyName = "ID";
                dgvResultadosCompetencia.Columns[1].DataPropertyName = "DESCRIPCION";
                dgvResultadosCompetencia.Columns[2].DataPropertyName = "DURACION";
                dgvResultadosCompetencia.DataSource = dt;
            }
            catch (Exception ex)
            {
                VentanaMsjes ventana2 = new VentanaMsjes("ERROR", ex.Message);
                ventana2.iconoPregunta.Image = global::Ej_Interfaz_Proyecto.Properties.Resources.icn_err;
                ventana2.btnAceptar.Visible = true;
                ventana2.ShowDialog();
            }
        }

        public void ListadoCompetenciasTransversales()
        {
            try
            {
                dgvCompetencias.AutoGenerateColumns = false;

                DataTable dt = Competencias_transversales.ListadoDeCompetenciasTransversales(cbProgramas_de_formacion.SelectedValue.ToString());

                dgvCompetencias.Columns[0].DataPropertyName = "ID";
                dgvCompetencias.Columns[1].DataPropertyName = "DESCRIPCION";
                dgvCompetencias.Columns[2].DataPropertyName = "DURACION";
                dgvCompetencias.DataSource = dt;

            }
            catch (Exception ex)
            {
                VentanaMsjes ventana2 = new VentanaMsjes("ERROR", ex.Message);
                ventana2.iconoPregunta.Image = global::Ej_Interfaz_Proyecto.Properties.Resources.icn_err;
                ventana2.btnAceptar.Visible = true;
                ventana2.ShowDialog();
            }
        }

        public void ListadoResultadosTransversales(string Idcompetencia)
        {
            try
            {

                dgvResultadosCompetencia.AutoGenerateColumns = false;

                dt = ResultadosTransversales.ListadoDeResultados(Idcompetencia);

                dgvResultadosCompetencia.Columns[0].DataPropertyName = "ID";
                dgvResultadosCompetencia.Columns[1].DataPropertyName = "DESCRIPCION";
                dgvResultadosCompetencia.Columns[2].DataPropertyName ="DURACION";
                dgvResultadosCompetencia.DataSource = dt;


            }
            catch (Exception ex)
            {
                VentanaMsjes ventana2 = new VentanaMsjes("ERROR", ex.Message);
                ventana2.iconoPregunta.Image = global::Ej_Interfaz_Proyecto.Properties.Resources.icn_err;
                ventana2.btnAceptar.Visible = true;
                ventana2.ShowDialog();
            }
        }

        public void ListadoInstructorResultados()
        {
            try
            {
                dgvResultadosAsignados.AutoGenerateColumns = false;

                DataTable dt = Instructor.ListadoDeResultadosInstructores(id_instructor);

                dgvResultadosAsignados.Columns[0].DataPropertyName = "CODIGO";
                dgvResultadosAsignados.Columns[1].DataPropertyName = "RESULTADOS";
              
                dgvResultadosAsignados.DataSource = dt;

            }
            catch (Exception ex)
            {
                VentanaMsjes ventana2 = new VentanaMsjes("ERROR", ex.Message);
                ventana2.iconoPregunta.Image = global::Ej_Interfaz_Proyecto.Properties.Resources.icn_err;
                ventana2.btnAceptar.Visible = true;
                ventana2.ShowDialog();
            }
        }
    
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

   
    
        private void cbTipoCompetencia_SelectionChangeCommitted(object sender, EventArgs e)
        {
         
        }

        private void dgvCompetencias_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvCompetencias.SelectedRows.Count == 1)
            {
                if (cbTipoCompetencia.SelectedIndex == 0)
                    ListadoResultadosTecnicos(dgvCompetencias[0, dgvCompetencias.CurrentRow.Index].Value.ToString());

                else
                    ListadoResultadosTransversales(dgvCompetencias[0, dgvCompetencias.CurrentRow.Index].Value.ToString());
                //id_competencia = dgvCompetencias[0, dgvCompetencias.CurrentRow.Index].Value.ToString();
            }
            else
            {
                dgvResultadosCompetencia.DataSource = null;
            }
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
          

        }

        private void btnRemover_Click(object sender, EventArgs e)
        {
            Instructor ins = new Instructor();
            ins.EliminarResultado(id_instructor, dgvResultadosAsignados.CurrentRow.Cells[0].Value.ToString());
           dgvResultadosAsignados.Rows.RemoveAt(this.dgvResultadosAsignados.CurrentRow.Index);        

        }

     

        private void btnGuardarResultados_Click(object sender, EventArgs e)
        {
            try
            {
                Instructor instructor_resultado = new Instructor();

                List<string> resultados= new List<string>();

                for (int i = 0; i < dgvResultadosAsignados.Rows.Count; i++)
                {
                    resultados.Add(dgvResultadosAsignados[0,i].Value.ToString());

                }

                
                if (cbTipoCompetencia.SelectedIndex == 0) 
                {
                    instructor_resultado.Identificacion = id_instructor;
                    instructor_resultado.Resultado_tecnico = resultados;
                    instructor_resultado.AsignarResultados("Tecnica");
                }
                else if (cbTipoCompetencia.SelectedIndex == 1)
                {
                    instructor_resultado.Identificacion = id_instructor;
                    instructor_resultado.Resultado_transversal = resultados;
                    instructor_resultado.AsignarResultados("Transversal");
                }

                VentanaMsjes ventana = new VentanaMsjes("GUARDAR", "Resultados asignados exitosamente");
                ventana.iconoPregunta.Image = global::Ej_Interfaz_Proyecto.Properties.Resources.icn_inf;
                ventana.btnAceptar.Visible = true;
                ventana.ShowDialog();


               
            }
            catch (Exception ex)
            {
                VentanaMsjes ventana2 = new VentanaMsjes("ERROR", ex.Message);
                ventana2.iconoPregunta.Image = global::Ej_Interfaz_Proyecto.Properties.Resources.icn_err;
                ventana2.btnAceptar.Visible = true;
                ventana2.ShowDialog();
            }
            
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dgvResultadosAsignados.Rows.Count; i++)
            {
                if (dgvResultadosAsignados[0, i].Value.Equals(dgvResultadosCompetencia[0, dgvResultadosCompetencia.CurrentRow.Index].Value))
                {
                    VentanaMsjes ventana = new VentanaMsjes("AVISO", "Este resultado de aprendizaje ya existe");
                    ventana.iconoPregunta.Image = global::Ej_Interfaz_Proyecto.Properties.Resources.icn_inf;
                    ventana.btnAceptar.Visible = true;
                    ventana.ShowDialog();

                 
                    return;
                }
            }



            dt = dgvResultadosAsignados.DataSource as DataTable;

            DataRow row = dt.NewRow();

            row[0] = dgvResultadosCompetencia[0, dgvResultadosCompetencia.CurrentRow.Index].Value;
            row[1] = dgvResultadosCompetencia[1, dgvResultadosCompetencia.CurrentRow.Index].Value;
       
            dt.Rows.Add(row);

            dgvResultadosAsignados.DataSource = dt;            
            //dgvResultadosAsignados.Rows.Add(dgvResultadosCompetencia[0, dgvResultadosCompetencia.CurrentRow.Index].Value, dgvResultadosCompetencia[1, dgvResultadosCompetencia.CurrentRow.Index].Value);
        }

        private void pictureBox6_MouseLeave(object sender, EventArgs e)
        {
            this.pictureBox6.Image = global::Ej_Interfaz_Proyecto.Properties.Resources.btn_sel_normal;
        }

        private void pictureBox6_MouseMove(object sender, MouseEventArgs e)
        {
            this.pictureBox6.Image = global::Ej_Interfaz_Proyecto.Properties.Resources.btn_sel_focus;
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

        private void FrmResultados_Instructor_Load(object sender, EventArgs e)
        {
            ListadoProgramas();
            ListadoInstructorResultados();
        }

        private void FrmResultados_Instructor_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void cbTipoCompetencia_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbProgramas_de_formacion.SelectedIndex == -1)
            {
                VentanaMsjes ventana = new VentanaMsjes("AVISO", "Seleccione un programa de formación");
                ventana.iconoPregunta.Image = global::Ej_Interfaz_Proyecto.Properties.Resources.icn_inf;
                ventana.btnAceptar.Visible = true;
                ventana.ShowDialog();

                //cbTipoCompetencia.SelectedIndex = -1;
                return;
            }
            if (cbTipoCompetencia.SelectedIndex == 0)
            {
                ListadoCompetenciasTecnicas();
            }
            else
            {
                ListadoCompetenciasTransversales();
            }
        }

    }
}
