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
using Ej_Interfaz_Proyecto.FrmMinimizados_1280x1024;

namespace Ej_Interfaz_Proyecto.Formularios_1280x1024
{
    public partial class Programa_1280x1024 : Form
    {

        public int pos = 0;
        public int posM = 0;

        // Declaraciones del API PARA MOVER EL FORMULARIO
        [System.Runtime.InteropServices.DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        //
        [System.Runtime.InteropServices.DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);


        string codigo_Actual;
        FrmPrincipal_1280x1024 principal;
        private string Codigoprograma;
        public Programa_1280x1024(FrmPrincipal_1280x1024 principal)
        {
           
            this.principal = principal;

            InitializeComponent();


            this.BackColor = Color.FromArgb(4, 123, 117);
            this.btnGuardar.ForeColor = Color.FromArgb(4, 123, 117);

            this.button1.ForeColor = Color.FromArgb(4, 123, 117);
            this.button2.ForeColor = Color.FromArgb(4, 123, 117);
            this.button3.ForeColor = Color.FromArgb(4, 123, 117);

            this.btnProfesiones.ForeColor = Color.FromArgb(4, 123, 117);

        }


        private void Solo_numeros(object sender, KeyPressEventArgs e)
        {
            if (Char.IsNumber(e.KeyChar) || e.KeyChar == (Char)Keys.Back)
            {
                e.Handled = false;
            }
            else
                e.Handled = true;
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {

            if (rdbId.Checked)
            {
                ListadoIncrementalInstructores("Id", txtBuscar.Text.Trim());
            }
            if (rdbNombre.Checked)
            {
                ListadoIncrementalInstructores("Nombre", txtBuscar.Text.Trim());
            }

        }

        private void ListadoIncrementalInstructores(string parametro, string texto)
        {
            try
            {
                dgvPrograma.AutoGenerateColumns = false;

                DataTable dt = Programa_Formacion.ListadoIncrementalDeProgramas(parametro, texto);

                dgvPrograma.Columns["id"].DataPropertyName = "ID_PROGRAMA";
                dgvPrograma.Columns["Nomb"].DataPropertyName = "NOMBRE_PROGRAMA";
                dgvPrograma.Columns["Dur"].DataPropertyName = "DURACION_PROGRAMA";
                dgvPrograma.Columns["nivel"].DataPropertyName = "NOMBRE_NIVEL";
                dgvPrograma.DataSource = dt;
            }
            catch (Exception ex)
            {
                VentanaMsjes ventana2 = new VentanaMsjes("ERROR", ex.Message);
                ventana2.iconoPregunta.Image = global::Ej_Interfaz_Proyecto.Properties.Resources.icn_err;
                ventana2.btnAceptar.Visible = true;
                ventana2.ShowDialog();
            }
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            ListadoProgramas();
            LimpiarSeleccion();

        }

        private void ListadoNiveles()
        {
            cbNivel.DataSource = Niveles.ListarNiveles();
            cbNivel.DisplayMember = "NOMBRE_NIVEL";
            cbNivel.ValueMember = "ID";
            cbNivel.SelectedIndex = -1;

        }
     
        private void LimpiarSeleccion()
        {
            for (int i = 0; i < dgvPrograma.Rows.Count; i++)
            {
                dgvPrograma.Rows[i].Selected = false;
            }
           
        }

        private void ListadoProgramas()
        {
            try
            {
                dgvPrograma.AutoGenerateColumns = false;

                DataTable dt = Programa_Formacion.ListadoGeneralDeProgramas();

                dgvPrograma.Columns[0].DataPropertyName = "ID_PROGRAMA".Trim();
                dgvPrograma.Columns[1].DataPropertyName = "NOMBRE_PROGRAMA".Trim();
                dgvPrograma.Columns[2].DataPropertyName = "DURACION_PROGRAMA".Trim();
                dgvPrograma.Columns[3].DataPropertyName = "ID_NIVEL".Trim();
                
                dgvPrograma.DataSource = dt;
            }
            catch (Exception ex)
            {
                VentanaMsjes ventana2 = new VentanaMsjes("ERROR", ex.Message);
                ventana2.iconoPregunta.Image = global::Ej_Interfaz_Proyecto.Properties.Resources.icn_err;
                ventana2.btnAceptar.Visible = true;
                ventana2.ShowDialog();
            }
        }

       

        private void dgvPrograma_SelectionChanged(object sender, EventArgs e)
        {

            if (rdbModificar.Checked == true)
            {

                try
                {
                   
                    textCodigo.Text = dgvPrograma[0, dgvPrograma.CurrentRow.Index].Value.ToString();
                    txtNombre.Text = dgvPrograma[1, dgvPrograma.CurrentRow.Index].Value.ToString();
                    cbxDuraciónDiurna.Text = dgvPrograma[2, dgvPrograma.CurrentRow.Index].Value.ToString();
                    cbNivel.Text = dgvPrograma.CurrentRow.Cells[3].Value.ToString();//Programa_Formacion.devueltaconnivel(dgvPrograma[3, dgvPrograma.CurrentRow.Index].Value.ToString()); Modificado Miguel esto es antifuncional

                    codigo_Actual = textCodigo.Text;
                }
                catch (Exception ex)
                {
                    VentanaMsjes ventana2 = new VentanaMsjes("ERROR", ex.Message);
                    ventana2.iconoPregunta.Image = global::Ej_Interfaz_Proyecto.Properties.Resources.icn_err;
                    ventana2.btnAceptar.Visible = true;
                    ventana2.ShowDialog();
                }

            }

        }

        private void rdbModificar_CheckedChanged(object sender, EventArgs e)
        {
            ListadoNiveles();
            LimpiarSeleccion();
            Limpiar();

        }

        private void cbNivel_DropDown(object sender, EventArgs e)
        {
           ListadoNiveles();
        }

        private void btnProfesiones_Click(object sender, EventArgs e)
        {
            FrmNiveles_1280x1024 _FrmNiveles = new FrmNiveles_1280x1024();
            _FrmNiveles.MdiParent = principal;
            _FrmNiveles.Show();
            


        }

        private void rdbNuevo_CheckedChanged(object sender, EventArgs e)
        {
            LimpiarSeleccion();
            Limpiar();
        }

        private void Limpiar()
        {
            textCodigo.Text = "";
            txtNombre.Text = "";
            cbxDuraciónDiurna.SelectedIndex = -1;
            cbNivel.SelectedIndex = -1;

            textCodigo.Focus();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (textCodigo.Text.Trim().Equals("") || txtNombre.Text.Trim().Equals("") ||
              cbxDuraciónDiurna.SelectedIndex==-1 || cbNivel.SelectedIndex == -1)
            {
                VentanaMsjes ventana = new VentanaMsjes("GUARDAR", "Diligencie toda la información requerida");
                ventana.iconoPregunta.Image = global::Ej_Interfaz_Proyecto.Properties.Resources.icn_inf;
                ventana.btnAceptar.Visible = true;
                ventana.ShowDialog();

                return;
            }

           if (rdbNuevo.Checked)
            {
                try
                {
                    Programa_Formacion ClasePrograma = new Programa_Formacion();
                    ClasePrograma.Codigo = textCodigo.Text.Trim();
                    if (ClasePrograma.VerificarCodigo())
                    {
                        VentanaMsjes ventana = new VentanaMsjes("AVISO", "El codigo ya existe");
                        ventana.iconoPregunta.Image = global::Ej_Interfaz_Proyecto.Properties.Resources.icn_inf;
                        ventana.btnAceptar.Visible = true;
                        ventana.ShowDialog();

                        
                        textCodigo.Focus();
                        textCodigo.SelectAll();
                        return;
                    }

                    ClasePrograma.Nombre = txtNombre.Text.Trim();
                    ClasePrograma.Duracion = cbxDuraciónDiurna.Text.Trim();
                    ClasePrograma.Nivel = cbNivel.SelectedValue.ToString();
                    /////////////////////////Ambientes//////////////////////////
                   
                    ClasePrograma.Registrar();
                    ListadoProgramas();
                    Limpiar();

                    VentanaMsjes ventana2 = new VentanaMsjes("GUARDAR", "¡Registro exitoso!");
                    ventana2.iconoPregunta.Image = global::Ej_Interfaz_Proyecto.Properties.Resources.icn_inf;
                    ventana2.btnAceptar.Visible = true;
                    ventana2.ShowDialog();

                }
                catch (Exception ex)
                {
                    VentanaMsjes ventana2 = new VentanaMsjes("ERROR", ex.Message);
                    ventana2.iconoPregunta.Image = global::Ej_Interfaz_Proyecto.Properties.Resources.icn_err;
                    ventana2.btnAceptar.Visible = true;
                    ventana2.ShowDialog();
                }
            }

            else if (rdbModificar.Checked)
            {
             //   try
               // {
                    Programa_Formacion ClasePrograma = new Programa_Formacion();
                    ClasePrograma.Codigo = textCodigo.Text.Trim();
                    //if (!codigo_Actual.Trim().Equals(textCodigo.Text.Trim()))Editado por Miguel Benítez esta validación no hace nada (relentiza el programa)
                    //{
                    //    if (ClasePrograma.VerificarCodigo())
                    //    {
                    //        VentanaMsjes ventana = new VentanaMsjes("AVISO", "El programa ya existe");
                    //        ventana.iconoPregunta.Image = global::Ej_Interfaz_Proyecto.Properties.Resources.icn_inf;
                    //        ventana.btnAceptar.Visible = true;
                    //        ventana.ShowDialog();
                    //        textCodigo.Focus();
                    //        textCodigo.SelectAll();
                    //        return;
                    //    }
                    //}

                    ClasePrograma.Nombre = txtNombre.Text.Trim();
                    ClasePrograma.Duracion = cbxDuraciónDiurna.Text.Trim();
                    ClasePrograma.Nivel = cbNivel.SelectedValue.ToString();
                    /////////////////////////Ambientes//////////////////////////
                    //List<string> Ambientes = new List<string>();
                    //for (int i = 0; i < clbAmbiente.Items.Count; i++)
                    //{
                    //    clbAmbiente.SelectedIndex = i;
                    //    if (clbAmbiente.GetItemCheckState(i) == CheckState.Checked)
                    //    {
                    //        Ambientes.Add(clbAmbiente.SelectedValue.ToString());
                    //    }
                    //}

                    //ClasePrograma.Ambientes = Ambientes;
                    ClasePrograma.Modificar(codigo_Actual);

                    ListadoProgramas();
                    Limpiar();
                    LimpiarSeleccion();
                    codigo_Actual = "";
                    Limpiar();
                    VentanaMsjes ventana2 = new VentanaMsjes("MODIFICAR", "¡Modificación exitosa!");
                    ventana2.iconoPregunta.Image = global::Ej_Interfaz_Proyecto.Properties.Resources.icn_inf;
                    ventana2.btnAceptar.Visible = true;
                    ventana2.ShowDialog();

             /*   }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }*/

            }
           
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Programa_FormClosed(object sender, FormClosedEventArgs e)
        {
            principal.BtnPrograma.Enabled = true;
        }

        private void tsbCompetencias_Click(object sender, EventArgs e)
        {
            

           

        }

        private void tsbGrupos_Click(object sender, EventArgs e)
        {
           
        }

        private void tbsCompetenciasTransversales_Click(object sender, EventArgs e)
        {
           


        }

        private void dgvPrograma_Leave(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmCompetenciasTecnicas_1280x1024 _FrmCompetencias = new FrmCompetenciasTecnicas_1280x1024(principal);
            _FrmCompetencias.MdiParent = principal;
            _FrmCompetencias.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmCompetenciasTransversales_1280x1024 Transversales = new FrmCompetenciasTransversales_1280x1024(principal);
            Transversales.MdiParent = principal;
            Transversales.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textCodigo.Focus();
            if (dgvPrograma.CurrentRow.Index > -1)
            {
                FrmGrupos_1280x1024 grupo = new FrmGrupos_1280x1024(Codigoprograma);
                grupo.MdiParent = principal;
                grupo.Show();


            }
            else
            {
                VentanaMsjes ventana = new VentanaMsjes("AVISO", "Seleccione un programa de formación");
                ventana.iconoPregunta.Image = global::Ej_Interfaz_Proyecto.Properties.Resources.icn_inf;
                ventana.btnAceptar.Visible = true;
                ventana.ShowDialog();

               
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
            principal.BtnPrograma.Enabled = true;
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
            //WindowState = FormWindowState.Minimized;

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
                    FrmMinProgram MinPrograma = new FrmMinProgram(this, principal);
                    MinPrograma.MdiParent = principal;
                    MinPrograma.Location = new Point(pos, Screen.PrimaryScreen.Bounds.Height - 150 - 20);
                    MinPrograma.StartPosition = FormStartPosition.Manual;
                    MinPrograma.Show();

                    i = 10;
                }


            }
           
                

              


        }

        private void Programa_MouseDown(object sender, MouseEventArgs e)
        {

            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void textCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            Solo_numeros(sender,e);
        }

        private void dgvPrograma_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Codigoprograma = dgvPrograma[0, dgvPrograma.CurrentRow.Index].Value.ToString();
        }


    }
}
