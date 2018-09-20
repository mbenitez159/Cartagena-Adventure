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
    public partial class FrmRegistroResultados_1280x1024 : Form
    {
        // Declaraciones del API PARA MOVER EL FORMULARIO
        [System.Runtime.InteropServices.DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        //
        [System.Runtime.InteropServices.DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);


        string tipoCompetencia;

        string id_Competencia;
        string codigo_Actual="";
        FrmCompetenciasTecnicas_1280x1024 frmCompTecnicas;
        FrmCompetenciasTransversales_1280x1024 frmCompTrans;
        public FrmRegistroResultados_1280x1024(string id_Competencia,FrmCompetenciasTecnicas_1280x1024 formulario)
        {
            this.frmCompTecnicas = formulario;
            this.id_Competencia = id_Competencia;
            tipoCompetencia = "tecnica";
            InitializeComponent();

            this.btnGuardar.ForeColor = Color.FromArgb(4, 123, 117);
            this.BackColor = Color.FromArgb(4, 123, 117);


        }

        public FrmRegistroResultados_1280x1024(string id_Competencia, FrmCompetenciasTransversales_1280x1024 formulario)
        {
            this.frmCompTrans = formulario;
            this.id_Competencia = id_Competencia;
            tipoCompetencia = "transversal";
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

            if (txtDescripcion.Text.Trim().Equals(""))
            {

                VentanaMsjes ventana = new VentanaMsjes("GUARDAR", "Diligencie toda la información requerida");
                ventana.iconoPregunta.Image = global::Ej_Interfaz_Proyecto.Properties.Resources.icn_inf;
                ventana.btnAceptar.Visible = true;
                ventana.ShowDialog(); 
                
                return;

            }
            if (tipoCompetencia == "tecnica")
            {
                if (frmCompTecnicas.OpcionResultados == "Modificar")
                {
                    try
                    {
                        ResultadosTecnicos ClaseResultados = new ResultadosTecnicos();
                        ClaseResultados.Codigo = textCodigo.Text.Trim();
                        
                        ClaseResultados.Descripcion = txtDescripcion.Text.Trim();
                        ClaseResultados.Duracion=txtDuracion.Text.Trim();
                        ClaseResultados.Modificar();
                        Limpiar();

                        VentanaMsjes ventana = new VentanaMsjes("MODIFICAR", "¡Modificación exitosa!");
                        ventana.iconoPregunta.Image = global::Ej_Interfaz_Proyecto.Properties.Resources.icn_inf;
                        ventana.btnAceptar.Visible = true;
                        ventana.ShowDialog();

                        frmCompTecnicas.ListadoResultadosTecnicos(id_Competencia);

                        frmCompTecnicas.OpcionResultados = "";

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

                else//registro de competencia tecnica
                {

                    try
                    {
                        ResultadosTecnicos ClaseResultado = new ResultadosTecnicos();

                        ClaseResultado.Descripcion = txtDescripcion.Text.Trim();
                        ClaseResultado.ID_Competencia = id_Competencia;
                        ClaseResultado.Duracion = txtDuracion.Text.Trim();

                        ClaseResultado.Registrar();

                        Limpiar();
                        VentanaMsjes ventana = new VentanaMsjes("GUARDAR", "¡Registro exitoso!");
                        ventana.iconoPregunta.Image = global::Ej_Interfaz_Proyecto.Properties.Resources.icn_inf;
                        ventana.btnAceptar.Visible = true;
                        ventana.ShowDialog();

                        frmCompTecnicas.ListadoResultadosTecnicos(id_Competencia);

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

            }

            //////////////////////////////////////////////////
            if (tipoCompetencia == "transversal")
            {
                if (frmCompTrans.OpcionResultados == "Modificar")
                {
                    try
                    {
                        ResultadosTransversales ClaseResultados = new ResultadosTransversales();
                        ClaseResultados.Codigo = textCodigo.Text.Trim();
                        
                        ClaseResultados.Descripcion = txtDescripcion.Text.Trim();
                        ClaseResultados.Duracion=int.Parse(txtDuracion.Text.Trim());
                        ClaseResultados.Modificar();
                        Limpiar();

                        VentanaMsjes ventana = new VentanaMsjes("MODIFICAR", "¡Modificación exitosa!");
                        ventana.iconoPregunta.Image = global::Ej_Interfaz_Proyecto.Properties.Resources.icn_inf;
                        ventana.btnAceptar.Visible = true;
                        ventana.ShowDialog();

                        frmCompTrans.ListadoResultadosTransversales(id_Competencia);

                        frmCompTrans.OpcionResultados = "";

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

                else//registro de competencia transversal
                {

                    try
                    {
                        ResultadosTransversales ClaseResultado = new ResultadosTransversales();
                        
                        ClaseResultado.Descripcion = txtDescripcion.Text.Trim();
                        ClaseResultado.ID_Competencia = id_Competencia;

                        ClaseResultado.Registrar();

                        Limpiar();
                        VentanaMsjes ventana = new VentanaMsjes("GUARDAR", "¡Registro exitoso!");
                        ventana.iconoPregunta.Image = global::Ej_Interfaz_Proyecto.Properties.Resources.icn_inf;
                        ventana.btnAceptar.Visible = true;
                        ventana.ShowDialog();

                        frmCompTrans.ListadoResultadosTransversales(id_Competencia);

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
            }

        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
            Limpiar();

            if (tipoCompetencia == "tecnica")
                frmCompTecnicas.OpcionResultados = "";
            else
                frmCompTrans.OpcionCompetencia = "";
        }

        private void Limpiar()
        {
            textCodigo.Text = "";
            txtDescripcion.Text = "";
            txtDuracion.Text = "";
           

            textCodigo.Focus();
        }

        private void FrmRegistroResultados_Load(object sender, EventArgs e)
        {
            Limpiar();
            if (tipoCompetencia == "tecnica")
            {
                if (frmCompTecnicas.OpcionResultados == "Modificar")
                {
                    try
                    {
                       Limpiar();

                        textCodigo.Text = frmCompTecnicas.DGVResultadostecnicos[0, frmCompTecnicas.DGVResultadostecnicos.CurrentRow.Index].Value.ToString();
                        txtDescripcion.Text = frmCompTecnicas.DGVResultadostecnicos[1, frmCompTecnicas.DGVResultadostecnicos.CurrentRow.Index].Value.ToString();
                        txtDuracion.Text = frmCompTecnicas.DGVResultadostecnicos[2, frmCompTecnicas.DGVResultadostecnicos.CurrentRow.Index].Value.ToString();

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

            if (tipoCompetencia == "transversal")
            {
                if (frmCompTrans.OpcionResultados == "Modificar")
                {
                    try
                    {
                        Limpiar();

                        textCodigo.Text = frmCompTrans.DGVResultadostransversales[0, frmCompTrans.DGVResultadostransversales.CurrentRow.Index].Value.ToString();
                        txtDescripcion.Text = frmCompTrans.DGVResultadostransversales[1, frmCompTrans.DGVResultadostransversales.CurrentRow.Index].Value.ToString();
                        txtDuracion.Text = frmCompTrans.DGVResultadostransversales[2, frmCompTrans.DGVResultadostransversales.CurrentRow.Index].Value.ToString();
                        
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

        private void FrmRegistroResultados_MouseDown(object sender, MouseEventArgs e)
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
