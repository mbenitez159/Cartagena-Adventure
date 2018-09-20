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
    public partial class FrmAmbientes_1280x1024 : Form
    {
        string codActual;
        public int pos = 0;
        public int posM = 0;
        
        FrmPrincipal_1280x1024 principal;

        // Declaraciones del API PARA MOVER EL FORMULARIO
        [System.Runtime.InteropServices.DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        //
        [System.Runtime.InteropServices.DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);


        public FrmAmbientes_1280x1024(FrmPrincipal_1280x1024 principal)
        {
            InitializeComponent();
            this.principal = principal;
            this.btnGuardar.ForeColor = Color.FromArgb(4, 123, 117);
            this.btnEliminar.ForeColor = Color.FromArgb(128, 128, 128);
            this.BackColor = Color.FromArgb(4, 123, 117);
           
        }

        public void Limpiar()
        {
            txtNombre.Text = "";
            txtDescripcion.Text = "";
            txtCapacidad.Text = "";
            txtArea.Text = "";
            cbArea.SelectedIndex = -1;
        }

        private void LimpiarSeleccion()
        {
            dgvAmbientes.ClearSelection();
        }

        private void ListadoDeAmbientes()
        {
            try
            {
                dgvAmbientes.AutoGenerateColumns = false;

                DataTable dt = Ambientes.ListarAmbientes();
                dgvAmbientes.Columns[0].DataPropertyName = "ID_AMBIENTE";
                dgvAmbientes.Columns[1].DataPropertyName = "NOMBRE_AMBIENTE";
                dgvAmbientes.Columns[2].DataPropertyName = "DESCRIPCION";
                dgvAmbientes.Columns[3].DataPropertyName = "CAPACIDAD";
                dgvAmbientes.Columns[4].DataPropertyName = "AREA";
                dgvAmbientes.Columns[5].DataPropertyName = "NOMBRE";

                dgvAmbientes.DataSource = dt;
            }
            catch (Exception ex)
            {

                VentanaMsjes ventana2 = new VentanaMsjes("ERROR", ex.Message);
                ventana2.iconoPregunta.Image = global::Ej_Interfaz_Proyecto.Properties.Resources.icn_err;
                ventana2.btnAceptar.Visible = true;
                ventana2.ShowDialog();
            }
        }

        private void ObtenerListadoAreas()
        {
            try
            {
                
               cbArea.DataSource = Area.ListarAreas();
               cbArea.ValueMember = "Id";
               cbArea.DisplayMember = "Nombre";

            }
            catch (Exception)
            {

                throw new Exception("Error al obtener el listado de areas");
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text.Trim().Equals("") || txtCapacidad.Text.Trim().Equals("") || txtArea.Text.Trim().Equals("") || cbArea.SelectedIndex==-1)
            {

                VentanaMsjes ventana = new VentanaMsjes("GUARDAR", "Diligencie toda la información requerida");
                ventana.iconoPregunta.Image = global::Ej_Interfaz_Proyecto.Properties.Resources.icn_inf;
                ventana.btnAceptar.Visible = true;
                ventana.ShowDialog();
               
                return;
            }

            if (rdbNuevo.Checked)
            {
                Ambientes ambiente = new Ambientes();
                try
                {
                    ambiente.Nombre = txtNombre.Text.Trim();
                    ambiente.Descripcion = txtDescripcion.Text.Trim();
                    ambiente.Capacidad = Convert.ToInt32(txtCapacidad.Text.Trim());
                    ambiente.Area = Convert.ToInt32(txtArea.Text.Trim());
                    ambiente.AreaFormacion = cbArea.SelectedValue.ToString();
                    ambiente.Registrar();

                    Limpiar();
                    ListadoDeAmbientes();
                    txtNombre.Focus();

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
                if (codActual == "")
                {

                    VentanaMsjes ventana = new VentanaMsjes("MODIFICAR", "Seleccione una fila del listado de ambientes");
                    ventana.iconoPregunta.Image = global::Ej_Interfaz_Proyecto.Properties.Resources.icn_inf;
                    ventana.btnAceptar.Visible = true;
                    ventana.ShowDialog();
                    return;
                }
                Ambientes ambiente = new Ambientes();
                try
                {
                    ambiente.Nombre = txtNombre.Text.Trim();
                    ambiente.Descripcion = txtDescripcion.Text.Trim();
                    ambiente.Capacidad = Convert.ToInt32(txtCapacidad.Text.Trim());
                    ambiente.Area = Convert.ToInt32(txtArea.Text.Trim());
                    ambiente.AreaFormacion = cbArea.SelectedValue.ToString();
                    ambiente.Modificar(codActual);
                    ListadoDeAmbientes();
                    LimpiarSeleccion();
                    Limpiar();
                    
                    txtNombre.Focus();
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

        private void FrmAmbientes_Load(object sender, EventArgs e)
        {
            ListadoDeAmbientes();
            ObtenerListadoAreas();
            cbArea.SelectedIndex = -1;

        }

        private void rdbNuevo_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbNuevo.Checked)
            {
                btnEliminar.Enabled = false;
                LimpiarSeleccion();
                Limpiar();
                codActual = "";
            }
        }

        private void rdbModificar_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbModificar.Checked)
            {
                btnEliminar.Enabled = true;
                LimpiarSeleccion();
                Limpiar();
                codActual = "";
            }
        }

        private void dgvAmbientes_SelectionChanged(object sender, EventArgs e)
        {
            if (rdbModificar.Checked == true)
            {
                try
                {
                    txtNombre.Text = dgvAmbientes[1, dgvAmbientes.CurrentRow.Index].Value.ToString();
                    txtDescripcion.Text = dgvAmbientes[2, dgvAmbientes.CurrentRow.Index].Value.ToString();
                    txtCapacidad.Text = dgvAmbientes[3, dgvAmbientes.CurrentRow.Index].Value.ToString();
                    txtArea.Text = dgvAmbientes[4, dgvAmbientes.CurrentRow.Index].Value.ToString();
                    cbArea.Text = dgvAmbientes[5, dgvAmbientes.CurrentRow.Index].Value.ToString();
                    codActual = dgvAmbientes[0, dgvAmbientes.CurrentRow.Index].Value.ToString();
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
            if (codActual == "")
            {
                VentanaMsjes ventana = new VentanaMsjes("ELIMINAR", "Seleccione una fila del listado de ambientes");
                ventana.iconoPregunta.Image = global::Ej_Interfaz_Proyecto.Properties.Resources.icn_inf;
                ventana.btnAceptar.Visible = true;
                ventana.ShowDialog();
                return;
            }
            try
            {
                Ambientes ambiente = new Ambientes();

                VentanaMsjes ventana = new VentanaMsjes("ELIMINAR", "¿Confirma eliminar el ambiente?");
                ventana.btnSi.Visible = true;
                ventana.btnNo.Visible = true;
                ventana.iconoPregunta.Image = global::Ej_Interfaz_Proyecto.Properties.Resources.icn_pre;
                DialogResult msgdresult = ventana.ShowDialog();


                if (msgdresult.ToString().Equals("OK"))
                {
                    ambiente.Eliminar(codActual);

                    ListadoDeAmbientes();

                    VentanaMsjes ventana2 = new VentanaMsjes("ELIMINAR", "Eliminación exitosa");
                    ventana2.iconoPregunta.Image = global::Ej_Interfaz_Proyecto.Properties.Resources.icn_inf;
                    ventana2.btnAceptar.Visible = true;
                    ventana2.ShowDialog();

                    LimpiarSeleccion();
                    Limpiar();
                    codActual = "";
                    
                }
               

            }
            catch (Exception ex)
            {
                VentanaMsjes ventana2 = new VentanaMsjes("ERROR",ex.Message);
                ventana2.iconoPregunta.Image = global::Ej_Interfaz_Proyecto.Properties.Resources.icn_err;
                ventana2.btnAceptar.Visible = true;
                ventana2.ShowDialog();
                
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmAmbientes_FormClosed(object sender, FormClosedEventArgs e)
        {
            principal.BtnAmbiente.Enabled = true;
        }

        private void cbArea_DropDown(object sender, EventArgs e)
        {
            ObtenerListadoAreas();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.Close();
            principal.BtnAmbiente.Enabled = true;
           
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
                    FrmMinAmbiente MinAmbiente = new FrmMinAmbiente(this, principal);
                    MinAmbiente.MdiParent = principal;
                    MinAmbiente.Location = new Point(pos, Screen.PrimaryScreen.Bounds.Height - 150-20);
                    MinAmbiente.StartPosition = FormStartPosition.Manual;
                    MinAmbiente.Show();

                    i = 10;
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
            this.pictureBox3.Image = global::Ej_Interfaz_Proyecto.Properties.Resources.btn_min_normal2;
        }

        private void pictureBox3_MouseMove(object sender, MouseEventArgs e)
        {
            this.pictureBox3.Image = global::Ej_Interfaz_Proyecto.Properties.Resources.btn_min_focus2;
        }

     
        private void FrmAmbientes_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
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

        private void txtCapacidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            Solo_numeros(sender,e);
        }

        private void txtArea_KeyPress(object sender, KeyPressEventArgs e)
        {
            Solo_numeros(sender, e);
        }
        
    }
}
