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
    public partial class FrmGrupos_1280x1024 : Form
    {
        // Declaraciones del API PARA MOVER EL FORMULARIO
        [System.Runtime.InteropServices.DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        //
        [System.Runtime.InteropServices.DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);


        System.Data.DataRow dr;
        string codigoActual;
        int NumeroAlumnos;
        Grupos grupo = new Grupos();
        private string Fichagrupo;
        string idInstruct;
        public FrmGrupos_1280x1024(string Codigoprograma)
        {
            InitializeComponent();
            txtProgramaFormacion.Text = Codigoprograma;
            this.btnGuardar.ForeColor = Color.FromArgb(4, 123, 117);
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

        private void LimpiarSeleccion()
        {
            dgvGrupos.ClearSelection();
        }

        private void Limpiar()
        {
            txtFicha.Text = "";
            txtTrimestre.Text = "";
            cbAmbiente.SelectedIndex = -1;
            cboJornada.SelectedIndex = -1;
            cbPrograma.SelectedIndex = -1;
            cbEstado.SelectedIndex = -1;
            txtCantidad.Text = string.Empty;
            txtIdIns.Visible = false;
            chBAsigLider.Checked = false;
            txtIdIns.Clear();
            txtFicha.Focus();
        }

        private void ObtenerListadoGrupos()
        {
            try
            {
                
                dgvGrupos.AutoGenerateColumns = false;
                dgvGrupos.DataSource = Grupos.ListadoDeGrupos1(txtProgramaFormacion.Text);
                dgvGrupos.Columns[0].DataPropertyName = "ID_GRUPO";
                dgvGrupos.Columns[1].DataPropertyName = "JORNADA";
                dgvGrupos.Columns[2].DataPropertyName = "NOMBRE_PROGRAMA";
                dgvGrupos.Columns[3].DataPropertyName = "TRIMESTRE_ACTUAL";
                dgvGrupos.Columns[4].DataPropertyName = "NOMBRE_AMBIENTE";
                dgvGrupos.Columns[5].DataPropertyName = "ESTADO";
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ListadoProgramas()
        {
            cbPrograma.DataSource = Programa_Formacion.ListadoGeneralDeProgramas();
            cbPrograma.DisplayMember = "NOMBRE_PROGRAMA";
            cbPrograma.ValueMember = "ID_PROGRAMA";
            cbPrograma.SelectedIndex = -1;

        }

        private void ListadoAmbientes()
        {
            cbAmbiente.DataSource = Ambientes.ListarAmbientes();
            cbAmbiente.DisplayMember = "NOMBRE_AMBIENTE";
            cbAmbiente.ValueMember = "ID_AMBIENTE";
            cbAmbiente.SelectedIndex = -1;

        }

        private void ListadoEstado()
        {
            cbEstado.DataSource = Grupos.ListarEstado();
            cbEstado.DisplayMember = "ESTADO";
            cbEstado.ValueMember = "ID_ESTADO";
            cbEstado.SelectedIndex = -1;

        }
        private void FrmGrupos_Load(object sender, EventArgs e)
        {
            
            ObtenerListadoGrupos();
            ListadoProgramas();
            ListadoAmbientes();
            ListadoEstado();
            dgvGrupos.ClearSelection();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbPrograma_DropDown(object sender, EventArgs e)
        {
            ListadoProgramas();
        }

        private void cbAmbiente_DropDown(object sender, EventArgs e)
        {
            ListadoAmbientes();
        }

        private void dgvGrupos_SelectionChanged(object sender, EventArgs e)
        {
            //if (dgvGrupos.RowCount >= 0)

           
            if (rdbModificar.Checked == true)
            {
                try
                {
                    txtFicha.Text = dgvGrupos[0, dgvGrupos.CurrentRow.Index].Value.ToString();
                    cboJornada.Text = dgvGrupos[1, dgvGrupos.CurrentRow.Index].Value.ToString();
                    txtTrimestre.Text = dgvGrupos[3, dgvGrupos.CurrentRow.Index].Value.ToString();
                    cbPrograma.Text = dgvGrupos[2, dgvGrupos.CurrentRow.Index].Value.ToString();
                    if (dgvGrupos[4, dgvGrupos.CurrentRow.Index].Value.ToString().Equals(""))
                    {
                        cbAmbiente.SelectedIndex = -1;
                    }
                    else
                    {
                        cbAmbiente.Text = dgvGrupos[4, dgvGrupos.CurrentRow.Index].Value.ToString();
                    }
                    cbEstado.Text = dgvGrupos[5, dgvGrupos.CurrentRow.Index].Value.ToString();

                    codigoActual = txtFicha.Text;
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

        private void rdbNuevo_CheckedChanged(object sender, EventArgs e)
        {
            LimpiarSeleccion();
            Limpiar();
            codigoActual = "";
        }

        private void rdbModificar_CheckedChanged(object sender, EventArgs e)
        {
            LimpiarSeleccion();
            Limpiar();
            codigoActual = "";
        }

        private void txtTrimestre_KeyPress(object sender, KeyPressEventArgs e)
        {
            soloNumeros(e);
        }

        public string ConsultarNivel()
        {
            
            Conexion conexion = new Conexion();
            System.Data.DataSet ds = new DataSet();
            try
            {
                conexion.AbrirConexion();
                string SQL="select TOP 1 n.NOMBRE_NIVEL AS NIVEL from NIVELPROGRAMA n INNER JOIN PROGRAMA p ON p.ID_NIVEL=n.ID AND p.NOMBRE_PROGRAMA=@NOMBRE_PROGRAMA";
                System.Data.SqlClient.SqlCommand consulta = new System.Data.SqlClient.SqlCommand(SQL,conexion.GetConexion);
                consulta.Parameters.Clear();
                consulta.Parameters.AddWithValue("@NOMBRE_PROGRAMA", cbPrograma.Text);
                consulta.ExecuteNonQuery();
                System.Data.SqlClient.SqlDataAdapter DA = new System.Data.SqlClient.SqlDataAdapter(consulta);
                DA.Fill(ds, "NIVELPROGRAMA");
                dr=ds.Tables["NIVELPROGRAMA"].Rows[0];

            }
            catch (Exception error)
            {
                
                VentanaMsjes ventana2 = new VentanaMsjes("GUARDAR",error.Message);
                ventana2.iconoPregunta.Image = global::Ej_Interfaz_Proyecto.Properties.Resources.icn_inf;
                ventana2.btnAceptar.Visible = true;
                ventana2.ShowDialog();
            }
            return dr["NIVEL"].ToString();
        }

        public void llenarCampos(){
            
            grupo.Jornada = cboJornada.Text.Trim();
            grupo.Id_Programa = cbPrograma.SelectedValue.ToString();
            grupo.TrimestreActual = txtTrimestre.Text.Trim();
            grupo.Id_Ambiente = cbAmbiente.SelectedValue.ToString();
            grupo.Id_Estado = cbEstado.SelectedValue.ToString();
            if (txtIdIns.Visible.Equals(true))
            {
                grupo.Lider = idInstruct;
            }


            int M = dateTimePicker1.Value.Month;
            int y = dateTimePicker1.Value.Year;
            string ss = "";
            /*esta parte valida e asigan en trimestre, pero esto es mejor capturarlo en fecha es mejor y más facil*/
            if (M <= 3 && M > 0) ss = "1-" + y;
            if (M <= 6 && M > 3) ss = "2-" + y;
            if (M <= 9 && M > 6) ss = "3-" + y;
            if (M <= 12 && M > 9) ss = "4-" + y;

            ConsultarNivel();
            if (DateTime.Parse(dateTimePicker1.Text)>=DateTime.Parse("01/01/"+dateTimePicker1.Value.Year) && DateTime.Parse(dateTimePicker1.Text)<=DateTime.Parse("31/03/"+dateTimePicker1.Value.Year)  )
            {
                ss = "01/01/"+dateTimePicker1.Value.Year;
            }
            else if (DateTime.Parse(dateTimePicker1.Text)>=DateTime.Parse("01/04/"+dateTimePicker1.Value.Year) && DateTime.Parse(dateTimePicker1.Text)<=DateTime.Parse("30/06/"+dateTimePicker1.Value.Year) )
            {
                ss = "01/04/"+dateTimePicker1.Value.Year;
            }
            else if (DateTime.Parse(dateTimePicker1.Text)>=DateTime.Parse("01/07/"+dateTimePicker1.Value.Year) && DateTime.Parse(dateTimePicker1.Text)<=DateTime.Parse("30/09/"+dateTimePicker1.Value.Year) )
            {
                ss = "01/07/"+dateTimePicker1.Value.Year;
            }
            else if (DateTime.Parse(dateTimePicker1.Text)>=DateTime.Parse("01/10/"+dateTimePicker1.Value.Year) && DateTime.Parse(dateTimePicker1.Text)<=DateTime.Parse("31/12/"+dateTimePicker1.Value.Year) )
            {
                ss = "01/10/" + dateTimePicker1.Value.Year;
            }
            
            grupo.FechaInicio = ss;//dateTimePicker1.Value.Year+"/"+dateTimePicker1.Value.Month+"/"+dateTimePicker1.Value.Day;//editado por mi antes tenia "ss" de variable
            grupo.fechaFin = dateTimePicker1.Text;                                           // if (ConsultarNivel().Equals("Tecnologo")) grupo.fechaFin = "" + M + "-" + (y + 2);
           // if (ConsultarNivel().Equals("Tecnico")) grupo.fechaFin = "" + M + "-" + (y + 1);
           // if (ConsultarNivel().Equals("") || ConsultarNivel().Equals(null)) grupo.fechaFin = "";
            if (txtCantidad.Text != string.Empty)
            {
                NumeroAlumnos = int.Parse(txtCantidad.Text);
                grupo.Cantidad = NumeroAlumnos;
            }
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtFicha.Text.Equals("") || cboJornada.SelectedIndex == -1 || txtTrimestre.Text.Equals("") || cbPrograma.SelectedIndex == -1 || cbAmbiente.SelectedIndex == -1 || cbEstado.SelectedIndex == -1)
            {
                VentanaMsjes ventana2 = new VentanaMsjes("AVISO", "Diligencie todos los datos requeridos");
                ventana2.iconoPregunta.Image = global::Ej_Interfaz_Proyecto.Properties.Resources.icn_inf;
                ventana2.btnAceptar.Visible = true;
                ventana2.ShowDialog();

               
                return;
            }
            if (rdbNuevo.Checked)
            {
                try
                {
                    grupo.Id_grupo = txtFicha.Text.Trim();
                    if (grupo.VerificarNumeroDeFicha())
                    {
                        VentanaMsjes ventana2 = new VentanaMsjes("GUARDAR", "La ficha ya existe");
                        ventana2.iconoPregunta.Image = global::Ej_Interfaz_Proyecto.Properties.Resources.icn_inf;
                        ventana2.btnAceptar.Visible = true;
                        ventana2.ShowDialog();

                        
                        txtFicha.Focus();
                        txtFicha.SelectAll();
                        return;
                    }

                    llenarCampos();
                    grupo.RegistrarGrupo();

                    Limpiar();
                    LimpiarSeleccion();
                    ObtenerListadoGrupos();
                    VentanaMsjes ventana3 = new VentanaMsjes("GUARDAR", "¡Registro Exitoso!");
                    ventana3.iconoPregunta.Image = global::Ej_Interfaz_Proyecto.Properties.Resources.icn_inf;
                    ventana3.btnAceptar.Visible = true;
                    ventana3.ShowDialog();

                }
                catch (Exception ex)
                {

                    VentanaMsjes ventana2 = new VentanaMsjes("ERROR", ex.Message);
                    ventana2.iconoPregunta.Image = global::Ej_Interfaz_Proyecto.Properties.Resources.icn_err;
                    ventana2.btnAceptar.Visible = true;
                    ventana2.ShowDialog();
                }
            }

            if (rdbModificar.Checked)
            {
                try
                {
                    grupo.Id_grupo = txtFicha.Text.Trim();
                    if (!codigoActual.Equals(txtFicha.Text.Trim()))
                    {
                        if (grupo.VerificarNumeroDeFicha())
                        {
                            VentanaMsjes ventana2 = new VentanaMsjes("MODIFICAR", "La ficha ya existe");
                            ventana2.iconoPregunta.Image = global::Ej_Interfaz_Proyecto.Properties.Resources.icn_inf;
                            ventana2.btnAceptar.Visible = true;
                            ventana2.ShowDialog();

                            txtFicha.Focus();
                            txtFicha.SelectAll();
                            return;
                        }
                    }
                    llenarCampos();
                    if (txtIdIns.Visible.Equals(false))
                    {
                        grupo.Lider = "";
                    }
                    grupo.ModificarGrupo(codigoActual);


                    LimpiarSeleccion();
                    ObtenerListadoGrupos();
                    Limpiar();
                    codigoActual = "";

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

        private void btnAsignarDuracion_Click(object sender, EventArgs e)
        {
            if (dgvGrupos.SelectedRows.Count >= 1)
            {
                /*FrmDuracion asignar = new FrmDuracion(Fichagrupo,txtProgramaFormacion.Text);
                asignar.ShowDialog();*/
                int filasAfectadas = 0;
                try
                {
                    Grupos grupo = new Grupos();
                    grupo.Id_grupo = Fichagrupo;
                    grupo.Id_Programa = txtProgramaFormacion.Text.Trim();
                    filasAfectadas = grupo.ActualizarDuracionResultados();
                    string mensaje = filasAfectadas.ToString() + " resultados actualizados";

                    VentanaMsjes ventana2 = new VentanaMsjes("ACTUALIZACIÓN", mensaje);
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
            else
            {
                VentanaMsjes ventana2 = new VentanaMsjes("AVISO", "Seleccione un grupo");
                ventana2.iconoPregunta.Image = global::Ej_Interfaz_Proyecto.Properties.Resources.icn_inf;
                ventana2.btnAceptar.Visible = true;
                ventana2.ShowDialog();
               
            }

            
        }

       
        private void dgvGrupos_Leave(object sender, EventArgs e)
        {
            Fichagrupo = dgvGrupos[0, dgvGrupos.CurrentRow.Index].Value.ToString();
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
            //this.pictureBox3.Image = global::Ej_Interfaz_Proyecto.Properties.Resources.btn_min_normal2;
        }

        private void pictureBox3_MouseMove(object sender, MouseEventArgs e)
        {
           // this.pictureBox3.Image = global::Ej_Interfaz_Proyecto.Properties.Resources.btn_min_focus2;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            //WindowState = FormWindowState.Minimized;
        }

        private void FrmGrupos_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void txtFicha_KeyPress(object sender, KeyPressEventArgs e)
        {
            soloNumeros(e);
        }

        private void chBAsigLider_CheckedChanged(object sender, EventArgs e)
        {
            if (chBAsigLider.Checked)
            {
                txtIdIns.Visible = true;
                btnBuscar.Visible = true;
            }
            else
            {
                txtIdIns.Visible = false;
                btnBuscar.Visible = false;
            }
        }
        

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            soloNumeros(e);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            FrmBusqueda_1280x1024 bu = new FrmBusqueda_1280x1024(null, "Identificación", "Nombre", "Celular","Instructor");
            bu.pasando +=new FrmBusqueda_1280x1024.pasar(bu_pasando);
            bu.ShowDialog();
        }

        void bu_pasando(string id, string nombre, string Cell_Jor)
        {
            txtIdIns.Text =nombre;
            idInstruct = id;

        }
      
       
    }
}
