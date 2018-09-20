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
using System.Data.SqlClient;

namespace Ej_Interfaz_Proyecto.Formularios_1280x1024
{
    public partial class FrmRegistroCompetencias_1280x1024 : Form
    {
        // Declaraciones del API PARA MOVER EL FORMULARIO
        [System.Runtime.InteropServices.DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        //
        [System.Runtime.InteropServices.DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        FrmCompetenciasTecnicas_1280x1024 frmCompTecnica;
        FrmCompetenciasTransversales_1280x1024 frmCompTrans;
        string id_Competencia;
        string tipoCompetencia;
        string codigo_Actual;
        public Boolean existe;
        string ProgramaFormacion;
        public FrmRegistroCompetencias_1280x1024(string id_Competencia,string programaFormacion,FrmCompetenciasTecnicas_1280x1024 formulario)
        {
            this.id_Competencia = id_Competencia;
            this.frmCompTecnica = formulario;
            tipoCompetencia = "tecnica";
            this.ProgramaFormacion = programaFormacion;
            InitializeComponent();

            this.btnGuardar.ForeColor = Color.FromArgb(4, 123, 117);
            this.BackColor = Color.FromArgb(4, 123, 117);
        }

        public FrmRegistroCompetencias_1280x1024(string id_Competencia, string programaFormacion, FrmCompetenciasTransversales_1280x1024 formulario)
        {
            this.id_Competencia = id_Competencia;
            this.frmCompTrans = formulario;
            this.ProgramaFormacion = programaFormacion;
            tipoCompetencia = "transversal";
            InitializeComponent();
        }

        private void Limpiar()
        {
            textCodigo.Text = "";
            txtDescripcion.Text = "";
            txtDuracion.Text = "";
           // cbTipo.SelectedIndex = -1;
            
            /*for (int i = 0; i < lbxPrograma.Items.Count; i++)
            {
                lbxPrograma.SetItemChecked(i, false);

            }*/

            textCodigo.Focus();
            
        }

        private void FrmRegistroCompetencias_Load(object sender, EventArgs e)
        {

            btnVerificar.Visible = false;
            if (tipoCompetencia == "tecnica")
            {
                if (frmCompTecnica.OpcionCompetencia == "Modificar")
                {
                    try
                    {
                        Limpiar();

                        textCodigo.Text = frmCompTecnica.dgvCompetencia_tecnicas[0, frmCompTecnica.dgvCompetencia_tecnicas.CurrentRow.Index].Value.ToString().Trim();
                        txtDescripcion.Text = frmCompTecnica.dgvCompetencia_tecnicas[1, frmCompTecnica.dgvCompetencia_tecnicas.CurrentRow.Index].Value.ToString();
                        txtDuracion.Text = frmCompTecnica.dgvCompetencia_tecnicas[2, frmCompTecnica.dgvCompetencia_tecnicas.CurrentRow.Index].Value.ToString();
                        
                        codigo_Actual = textCodigo.Text.Trim();

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

            if (tipoCompetencia == "transversal")
            {
                if (frmCompTrans.OpcionCompetencia == "Modificar")
                {
                    try
                    {
                        Limpiar();

                        textCodigo.Text = frmCompTrans.dgvCompetencia_transversales[0, frmCompTrans.dgvCompetencia_transversales.CurrentRow.Index].Value.ToString().Trim();
                        txtDescripcion.Text = frmCompTrans.dgvCompetencia_transversales[1, frmCompTrans.dgvCompetencia_transversales.CurrentRow.Index].Value.ToString();
                        txtDuracion.Text = frmCompTrans.dgvCompetencia_transversales[2, frmCompTrans.dgvCompetencia_transversales.CurrentRow.Index].Value.ToString();
                        codigo_Actual = textCodigo.Text.Trim();

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
                    btnVerificar.Visible = true;
                }
            }
        }


      
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (textCodigo.Text.Trim().Equals("")||txtDuracion.Text.Trim().Equals("") )
            {
                VentanaMsjes ventana = new VentanaMsjes("GUARDAR", "Diligencie toda la información requerida");
                ventana.iconoPregunta.Image = global::Ej_Interfaz_Proyecto.Properties.Resources.icn_inf;
                ventana.btnAceptar.Visible = true;
                ventana.ShowDialog();

                return;
            }

            
            if (tipoCompetencia == "tecnica")//COMPETENCIAS TECNICAS
            {
                if (txtDescripcion.Text.Trim().Equals(""))
                {
                    VentanaMsjes ventana = new VentanaMsjes("GUARDAR", "Diligencie toda la información requerida");
                    ventana.iconoPregunta.Image = global::Ej_Interfaz_Proyecto.Properties.Resources.icn_inf;
                    ventana.btnAceptar.Visible = true;
                    ventana.ShowDialog();

                    return;
                }
                if (frmCompTecnica.OpcionCompetencia == "Modificar")
                {
                    try
                    {
                        Competencias_tecnicas ClaseCompetencia = new Competencias_tecnicas();
                        ClaseCompetencia.Codigo = textCodigo.Text.Trim();

                        if (!codigo_Actual.Equals(textCodigo.Text.Trim()))
                        {
                            if (ClaseCompetencia.VerificarCodigo())
                            {
                                VentanaMsjes ventana = new VentanaMsjes("AVISO", "El código ya existe");
                                ventana.iconoPregunta.Image = global::Ej_Interfaz_Proyecto.Properties.Resources.icn_inf;
                                ventana.btnAceptar.Visible = true;
                                ventana.ShowDialog();

                               
                                textCodigo.Focus();
                                textCodigo.SelectAll();
                                return;
                            }
                        }

                        ClaseCompetencia.Descripcion = txtDescripcion.Text.Trim();

                        ClaseCompetencia.ID_Programa = id_Competencia;

                        ClaseCompetencia.Duracion = txtDuracion.Text;

                        ClaseCompetencia.ModificarCompetenciasTecnicas(codigo_Actual);

                        ClaseCompetencia.Codigo = textCodigo.Text.Trim();

                        Limpiar();
                        codigo_Actual = "";

                        VentanaMsjes ventana2 = new VentanaMsjes("MODIFICAR", "¡Modificación exitosa!");
                        ventana2.iconoPregunta.Image = global::Ej_Interfaz_Proyecto.Properties.Resources.icn_inf;
                        ventana2.btnAceptar.Visible = true;
                        ventana2.ShowDialog();

                        frmCompTecnica.OpcionCompetencia = "";
                        frmCompTecnica.ListadoCompetenciasTecnicas();

                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        VentanaMsjes ventana2 = new VentanaMsjes("ERROR", ex.Message);
                        ventana2.iconoPregunta.Image = global::Ej_Interfaz_Proyecto.Properties.Resources.icn_err;
                        ventana2.btnAceptar.Visible = true;
                        ventana2.ShowDialog();
                    }
                }
                else//NUEVO registro de competencias tecnicas
                {

                    try
                    {
                        Competencias_tecnicas ClaseCompetencia = new Competencias_tecnicas();
                        ClaseCompetencia.Codigo = textCodigo.Text.Trim();
                        if (ClaseCompetencia.VerificarCodigo())
                        {
                            VentanaMsjes ventana = new VentanaMsjes("AVISO", "El código ya existe");
                            ventana.iconoPregunta.Image = global::Ej_Interfaz_Proyecto.Properties.Resources.icn_inf;
                            ventana.btnAceptar.Visible = true;
                            ventana.ShowDialog();

                            textCodigo.Focus();
                            textCodigo.SelectAll();
                            return;
                        }

                        ClaseCompetencia.Descripcion = txtDescripcion.Text.Trim();
                        ClaseCompetencia.ID_Programa = ProgramaFormacion;
                        ClaseCompetencia.Duracion = txtDuracion.Text;
                        ClaseCompetencia.RegistrarCompetenciasTecnicas();

                        VentanaMsjes ventana2 = new VentanaMsjes("GUARDAR", "¡Registro exitoso!");
                        ventana2.iconoPregunta.Image = global::Ej_Interfaz_Proyecto.Properties.Resources.icn_inf;
                        ventana2.btnAceptar.Visible = true;
                        ventana2.ShowDialog();

                        frmCompTecnica.ListadoCompetenciasTecnicas();
                        Limpiar();

                        this.Close();

                    }
                    catch (Exception ex)
                    {
                        VentanaMsjes ventana2 = new VentanaMsjes("ERROR", ex.Message);
                        ventana2.iconoPregunta.Image = global::Ej_Interfaz_Proyecto.Properties.Resources.icn_err;
                        ventana2.btnAceptar.Visible = true;
                        ventana2.ShowDialog();
                    }

                }
                //fin registro
            }
            else //COMPETENCIAS TRANSVERSALES
            {
                if (frmCompTrans.OpcionCompetencia == "Modificar")
                {
                    if (txtDescripcion.Text.Trim().Equals(""))
                    {
                        VentanaMsjes ventana = new VentanaMsjes("GUARDAR", "Diligencie toda la información requerida");
                        ventana.iconoPregunta.Image = global::Ej_Interfaz_Proyecto.Properties.Resources.icn_inf;
                        ventana.btnAceptar.Visible = true;
                        ventana.ShowDialog();

                        return;
                    }
                    try
                    {
                        Competencias_transversales ClaseCompetencia = new Competencias_transversales();
                        ClaseCompetencia.Codigo = textCodigo.Text.Trim();

                        if (!codigo_Actual.Equals(textCodigo.Text.Trim()))
                        {
                            if (ClaseCompetencia.VerificarCodigo())
                            {
                                VentanaMsjes ventana = new VentanaMsjes("AVISO", "El código ya existe");
                                ventana.iconoPregunta.Image = global::Ej_Interfaz_Proyecto.Properties.Resources.icn_inf;
                                ventana.btnAceptar.Visible = true;
                                ventana.ShowDialog();

                                textCodigo.Focus();
                                textCodigo.SelectAll();
                                return;
                            }
                        }

                        ClaseCompetencia.Descripcion = txtDescripcion.Text.Trim();

                        ClaseCompetencia.Id_Programa = ProgramaFormacion;
                        ClaseCompetencia.Modificar(codigo_Actual);

                        ClaseCompetencia.Codigo = textCodigo.Text.Trim();

                        Limpiar();
                        codigo_Actual = "";

                        VentanaMsjes ventana2 = new VentanaMsjes("MODIFICAR", "¡Modificación exitosa!");
                        ventana2.iconoPregunta.Image = global::Ej_Interfaz_Proyecto.Properties.Resources.icn_inf;
                        ventana2.btnAceptar.Visible = true;
                        ventana2.ShowDialog();

                        frmCompTrans.OpcionCompetencia = "";
                        frmCompTrans.ListadoCompetenciasTransversales();

                        this.Close();

                    }
                    catch (Exception ex)
                    {
                        VentanaMsjes ventana2 = new VentanaMsjes("ERROR", ex.Message);
                        ventana2.iconoPregunta.Image = global::Ej_Interfaz_Proyecto.Properties.Resources.icn_err;
                        ventana2.btnAceptar.Visible = true;
                        ventana2.ShowDialog();
                    }

                }
                else//NUEVO registro de competencias transversales
                {
                   // try
                  //  {
                        Competencias_transversales ClaseCompetencia = new Competencias_transversales();
                        ClaseCompetencia.Codigo = textCodigo.Text.Trim();
                        ClaseCompetencia.Id_Programa = ProgramaFormacion;

                        if (existe)//si ya existe solo se realciona con el programa
                        {
                            ClaseCompetencia.Registrar_Programa_Competencia_Transversal();
                            VentanaMsjes ventana = new VentanaMsjes("GUARDAR", "¡Registro exitoso!");
                            ventana.iconoPregunta.Image = global::Ej_Interfaz_Proyecto.Properties.Resources.icn_inf;
                            ventana.btnAceptar.Visible = true;
                            ventana.ShowDialog();

                            frmCompTrans.ListadoCompetenciasTransversales();
                            Limpiar();

                            this.Close();
                            
                        }
                        else
                        {
                            if (txtDescripcion.Text.Trim().Equals(""))
                            {
                                VentanaMsjes ventana = new VentanaMsjes("GUARDAR", "Diligencie toda la información requerida");
                                ventana.iconoPregunta.Image = global::Ej_Interfaz_Proyecto.Properties.Resources.icn_inf;
                                ventana.btnAceptar.Visible = true;
                                ventana.ShowDialog();

                                return;
                            }
                            if (ClaseCompetencia.VerificarCodigo())
                            {
                                VentanaMsjes ventana = new VentanaMsjes("AVISO", "El código ya existe");
                                ventana.iconoPregunta.Image = global::Ej_Interfaz_Proyecto.Properties.Resources.icn_inf;
                                ventana.btnAceptar.Visible = true;
                                ventana.ShowDialog();

                                textCodigo.Focus();
                                textCodigo.SelectAll();
                                return;
                            }

                            ClaseCompetencia.Descripcion = txtDescripcion.Text.Trim();
                            ClaseCompetencia.Duracion = txtDuracion.Text.Trim();
                            ClaseCompetencia.Id_Programa = ProgramaFormacion;
                            ClaseCompetencia.Codigo = textCodigo.Text.Trim();
                            
                            ClaseCompetencia.Registrar();
                            ClaseCompetencia.Registrar_Programa_Competencia_Transversal();

                            VentanaMsjes ventana2 = new VentanaMsjes("GUARDAR", "¡Registro exitoso!");
                            ventana2.iconoPregunta.Image = global::Ej_Interfaz_Proyecto.Properties.Resources.icn_inf;
                            ventana2.btnAceptar.Visible = true;
                            ventana2.ShowDialog();

                            frmCompTrans.ListadoCompetenciasTransversales();
                            Limpiar();

                            this.Close();
                        }
                 
                }
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnVerificar_Click(object sender, EventArgs e)
        {
            if (textCodigo.Text.Equals(""))
            {
                
                VentanaMsjes ventana2 = new VentanaMsjes("AVISO", "Digite el código");
                ventana2.iconoPregunta.Image = global::Ej_Interfaz_Proyecto.Properties.Resources.icn_inf;
                ventana2.btnAceptar.Visible = true;
                ventana2.ShowDialog();

                return;
            }
            Competencias_transversales ClaseCompetencia = new Competencias_transversales();
            ClaseCompetencia.Codigo = textCodigo.Text.Trim();
            existe = ClaseCompetencia.VerificarCodigo();
            if (existe == true)
            {
                VentanaMsjes ventana2 = new VentanaMsjes("MENSAJE", "La competencia ya existe, seleccione un programa de formación y haga clic en Guardar");
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

        private void FrmRegistroCompetencias_MouseDown(object sender, MouseEventArgs e)
        {

            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void textCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            soloNumeros(e);
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

        private void txtDuracion_KeyPress(object sender, KeyPressEventArgs e)
        {
            soloNumeros(e);
        }

    }
}
