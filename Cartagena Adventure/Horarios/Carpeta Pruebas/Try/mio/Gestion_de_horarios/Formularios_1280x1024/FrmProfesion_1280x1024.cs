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
    public partial class FrmProfesion_1280x1024 : Form
    {
        // Declaraciones del API PARA MOVER EL FORMULARIO
        [System.Runtime.InteropServices.DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        //
        [System.Runtime.InteropServices.DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);



        string codActual;
        public FrmProfesion_1280x1024()
        {
            InitializeComponent();
            this.btnGuardar.ForeColor = Color.FromArgb(4, 123, 117);
            this.btnEliminar.ForeColor = Color.FromArgb(128, 128, 128);
            this.BackColor = Color.FromArgb(4, 123, 117);


        }

        private void Limpiar()
        {
         
            txtNombre.Text = "";

         
        }

        private void LimpiarSeleccion()
        {
            for (int i = 0; i < dgvProfesiones.Rows.Count; i++)
            {
                dgvProfesiones.Rows[i].Selected = false;
            }
        }

        private void ListadoProfesiones()
        {
            dgvProfesiones.AutoGenerateColumns = false;
            dgvProfesiones.DataSource = Profesion.ListarProfesiones();
            dgvProfesiones.Columns[0].DataPropertyName = "ID_PROFESION";
            dgvProfesiones.Columns[1].DataPropertyName = "NOMBRE_PROFESION";
        }
        private void FrmProfesion_Load(object sender, EventArgs e)
        {
            ListadoProfesiones();
            LimpiarSeleccion();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvProfesiones_SelectionChanged(object sender, EventArgs e)
        {
            if (rdbModificar.Checked)
            {
                codActual = dgvProfesiones[0, dgvProfesiones.CurrentRow.Index].Value.ToString();
                txtNombre.Text = dgvProfesiones[1, dgvProfesiones.CurrentRow.Index].Value.ToString();
                
                
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text.Trim().Equals(""))
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
                    Profesion profesion = new Profesion();
                   
                    profesion.Nombre = txtNombre.Text.Trim();
                    profesion.Registrar();
                    
                    ListadoProfesiones();
                    LimpiarSeleccion();
                    Limpiar();

                    VentanaMsjes ventana = new VentanaMsjes("GUARDAR", "¡Registro exitoso!");
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
            else if (rdbModificar.Checked)
            {
                try
                {
                    Profesion profesion = new Profesion();
                   
                    profesion.Nombre = txtNombre.Text.Trim();


                    profesion.Modificar(codActual);
                    
                    ListadoProfesiones();
                    LimpiarSeleccion();
                    Limpiar();
                    codActual = "";

                    VentanaMsjes ventana = new VentanaMsjes("MODIFICAR", "¡Modificación exitosa!");
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
            
        }

        private void rdbNuevo_CheckedChanged(object sender, EventArgs e)
        {
            LimpiarSeleccion();
            Limpiar();
            btnEliminar.Enabled = false;
        }

        private void rdbModificar_CheckedChanged(object sender, EventArgs e)
        {
            LimpiarSeleccion();
            Limpiar();
            btnEliminar.Enabled = true;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                Profesion profesion = new Profesion();
                profesion.Codigo = codActual;
                if (codActual!="")
                {

                    VentanaMsjes ventana = new VentanaMsjes("ELIMINAR", "¿Confirma eliminar el ambiente?");
                    ventana.btnSi.Visible = true;
                    ventana.btnNo.Visible = true;
                    ventana.iconoPregunta.Image = global::Ej_Interfaz_Proyecto.Properties.Resources.icn_pre;
                    DialogResult msgdresult = ventana.ShowDialog();

                if (msgdresult.ToString().Equals("OK"))
                {
                    profesion.Eliminar();
                    ListadoProfesiones();
                    LimpiarSeleccion();
                    Limpiar();
                    codActual = "";

                    VentanaMsjes ventana2 = new VentanaMsjes("ELIMINAR", "Eliminación exitosa");
                    ventana2.iconoPregunta.Image = global::Ej_Interfaz_Proyecto.Properties.Resources.icn_inf;
                    ventana2.btnAceptar.Visible = true;
                    ventana2.ShowDialog();
                }
                }
            }
            catch (Exception ex)
            {
                VentanaMsjes ventana2 = new VentanaMsjes("ERROR", ex.Message);
                ventana2.iconoPregunta.Image = global::Ej_Interfaz_Proyecto.Properties.Resources.icn_err;
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

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            //WindowState = FormWindowState.Minimized;
        }

        private void FrmProfesion_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
    }
}
