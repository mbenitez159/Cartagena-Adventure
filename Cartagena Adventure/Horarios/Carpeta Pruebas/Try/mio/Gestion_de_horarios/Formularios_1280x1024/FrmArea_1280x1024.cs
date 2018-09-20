using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ej_Interfaz_Proyecto.Clases_1280x1024;
using Ej_Interfaz_Proyecto.FrmMinimizados_1280x1024;
namespace Ej_Interfaz_Proyecto.Formularios_1280x1024
{
    public partial class FrmArea_1280x1024 : Form
    {
        string codActual;
        string nombreActual;
        public int pos = 0;
        public int posM = 0;
       
        FrmPrincipal_1280x1024 principal;


        // Declaraciones del API PARA MOVER EL FORMULARIO
        [System.Runtime.InteropServices.DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        //
        [System.Runtime.InteropServices.DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        public FrmArea_1280x1024(FrmPrincipal_1280x1024 principal)
        {
            InitializeComponent();
            this.principal = principal;
            this.btnGuardar.ForeColor = Color.FromArgb(4, 123, 117);
            this.btnEliminar.ForeColor = Color.FromArgb(128, 128, 128);
            this.BackColor = Color.FromArgb(4, 123, 117);
        }


        private void LimpiarSeleccion()
        {
            dgvArea.ClearSelection();
        }

        private void Limpiar()
        {
            
            txtNombreArea.Text = "";
        }

        private void ObtenerListadoAreas()
        {
            try
            {
                dgvArea.AutoGenerateColumns = false;
                dgvArea.DataSource = Area.ListarAreas();
                dgvArea.Columns[0].DataPropertyName = "Id";
                dgvArea.Columns[1].DataPropertyName = "Nombre";
                
            }
            catch (Exception)
            {
                
                throw new Exception("Error al obtener el listado de areas");
            }
            

        }

        private void FrmArea_Load(object sender, EventArgs e)
        {
            ObtenerListadoAreas();
        }

        private void rdbNuevo_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbNuevo.Checked)
            {
                LimpiarSeleccion();
                Limpiar();
                btnEliminar.Enabled = false;
            }
        }

        private void rdbModificar_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbModificar.Checked)
            {
                LimpiarSeleccion();
                Limpiar();
                btnEliminar.Enabled = true;
            }
        }

        private void dgvArea_SelectionChanged(object sender, EventArgs e)
        {
            if (rdbModificar.Checked)
            {
                
                txtNombreArea.Text = dgvArea[1, dgvArea.CurrentRow.Index].Value.ToString();

                codActual = dgvArea[0, dgvArea.CurrentRow.Index].Value.ToString();
                nombreActual = dgvArea[1, dgvArea.CurrentRow.Index].Value.ToString();
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtNombreArea.Text.Trim().Equals(""))
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
                    Area area = new Area();
                    area.Nombre = txtNombreArea.Text.Trim();
                    if (area.VerificarNombre())
                    {
                        VentanaMsjes ventana = new VentanaMsjes("AVISO", "El nombre ya existe");
                        ventana.iconoPregunta.Image = global::Ej_Interfaz_Proyecto.Properties.Resources.icn_inf;
                        ventana.btnAceptar.Visible = true;
                        ventana.ShowDialog();
                       
                        txtNombreArea.Focus();
                        txtNombreArea.SelectAll();
                        return;
                    }
                    area.Registrar();

                    ObtenerListadoAreas();
                    LimpiarSeleccion();
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
                try
                {
                    Area area = new Area();
                    area.Nombre = txtNombreArea.Text.Trim();
                    if (!nombreActual.Equals(txtNombreArea.Text.Trim()))
                    {
                        if (area.VerificarNombre())
                        {
                            VentanaMsjes ventana = new VentanaMsjes("AVISO", "El nombre ya existe");
                            ventana.iconoPregunta.Image = global::Ej_Interfaz_Proyecto.Properties.Resources.icn_inf;
                            ventana.btnAceptar.Visible = true;
                            ventana.ShowDialog();

                            return;
                        }
                    }
                    area.Codigo = codActual;
                    area.Modificar();

                    ObtenerListadoAreas();
                    LimpiarSeleccion();
                    Limpiar();
                    codActual = "";

                    VentanaMsjes ventana2 = new VentanaMsjes("MODIFICAR", "¡Modificación exitosa!");
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
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                Area area = new Area();
                area.Codigo = codActual;


                VentanaMsjes ventana = new VentanaMsjes("ELIMINAR", "¿Confirma eliminar el área?");
                ventana.btnSi.Visible = true;
                ventana.btnNo.Visible = true;
                ventana.iconoPregunta.Image = global::Ej_Interfaz_Proyecto.Properties.Resources.icn_pre;
                DialogResult msgdresult = ventana.ShowDialog();

                if (msgdresult.ToString().Equals("OK"))
                {
                    area.Eliminar();
                    ObtenerListadoAreas();
                    LimpiarSeleccion();
                    Limpiar();
                    codActual = "";

                    VentanaMsjes ventana2 = new VentanaMsjes("ELIMINAR", "Eliminación exitosa");
                    ventana2.iconoPregunta.Image = global::Ej_Interfaz_Proyecto.Properties.Resources.icn_inf;
                    ventana2.btnAceptar.Visible = true;
                    ventana2.ShowDialog();
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

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmArea_FormClosed(object sender, FormClosedEventArgs e)
        {
            principal.BtnAreas.Enabled = true;
        }

        private void txtNombreArea_TextChanged(object sender, EventArgs e)
        {

        }

        private void dgvArea_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_MouseMove(object sender, MouseEventArgs e)
        {
            this.pictureBox4.Image = global::Ej_Interfaz_Proyecto.Properties.Resources.btn_cer_focus2;
        }

        private void pictureBox4_MouseLeave(object sender, EventArgs e)
        {
            this.pictureBox4.Image = global::Ej_Interfaz_Proyecto.Properties.Resources.btn_cer_normal2;
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
            principal.BtnAreas.Enabled = true;
             
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
                    else if (i==5)
                    {
                        pos = 860;
                    }

                    posM = i;

                    principal.EspacioMin[i] = ("Ocupado");
                    FrmMinAreas MinAreas = new FrmMinAreas(this, principal);
                    MinAreas.MdiParent = principal;
                    MinAreas.Location = new Point(pos, Screen.PrimaryScreen.Bounds.Height - 150 - 20);
                    MinAreas.StartPosition = FormStartPosition.Manual;
                    MinAreas.Show();

                    i = 10;
                }


            }
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void FrmArea_MouseDown(object sender, MouseEventArgs e)
        {

            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
    }
}
