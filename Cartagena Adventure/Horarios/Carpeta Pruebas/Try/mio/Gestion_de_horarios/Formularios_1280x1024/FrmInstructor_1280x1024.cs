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
    public partial class FrmInstructor_1280x1024 : Form
    {
        public int pos = 0;
        public int posM = 0;

        // Declaraciones del API PARA MOVER EL FORMULARIO
        [System.Runtime.InteropServices.DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        //
        [System.Runtime.InteropServices.DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);


        string idActual;
        FrmPrincipal_1280x1024 principal1;
        public FrmInstructor_1280x1024(FrmPrincipal_1280x1024 principal)
        {
            InitializeComponent();
            this.principal1 = principal;
            this.ResultadosInstructor.ForeColor = Color.FromArgb(4, 123, 117);
            this.btnGuardar.ForeColor = Color.FromArgb(4, 123, 117);
            this.btnEliminar.ForeColor = Color.FromArgb(128, 128, 128);
            this.BackColor = Color.FromArgb(4, 123, 117);
            this.dateTimePicker1_ValueChanged(null, null);

            this.btnProfesiones.ForeColor = Color.FromArgb(4, 123, 117);
           // this.btnResultadoInstructor.ForeColor = Color.FromArgb(4, 123, 117);

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

        private void Limpiar()
        {
            txtIdentificacion.Text = "";
            txtNombre.Text = "";
            txtDireccion.Text = "";
            txtTelefono.Text = "";
            txtCelular.Text = "";
            txtEmail.Text = "";
            cbProfesion.SelectedIndex = -1;
            cbTipo.SelectedIndex = -1;

           // cbxProgramaFormacion.SelectedIndex = -1;

          /*  for (int i = 0; i < clbCompetencias.Items.Count; i++)
            {
                clbCompetencias.SetItemChecked(i, false);

            } 
            **/
            txtIdentificacion.Focus();
        }
               
        private void LimpiarSeleccion()
        {
            dgvInstructor.ClearSelection();
        }
                    
        private void ListadoDeInstructores(BuscarInstructorPor criterio, string texto)
        {
            try
            {
                dgvInstructor.AutoGenerateColumns = false;
                
               DataTable dt= Instructor.ListadoDeInstructores(criterio, texto,false);
               dgvInstructor.Columns["Id"].DataPropertyName = "ID_INSTRUCTOR";
               dgvInstructor.Columns["Nomb"].DataPropertyName = "NOMBRE";
               dgvInstructor.Columns["Dir"].DataPropertyName = "DIRECCION";
               dgvInstructor.Columns["Tel"].DataPropertyName = "TELEFONO";
               dgvInstructor.Columns["Cel"].DataPropertyName = "CELULAR";
               dgvInstructor.Columns["Email"].DataPropertyName = "EMAIL";
               dgvInstructor.Columns["Tipo"].DataPropertyName = "TIPO";
               dgvInstructor.Columns["Prof"].DataPropertyName = "NOMBRE_PROFESION";
               //dgvInstructor.Columns["Exp_contrat"].DataPropertyName = "EXP_CONTRATO";
               dgvInstructor.DataSource =dt;
                

            }
            catch (Exception ex)
            {
                VentanaMsjes ventana2 = new VentanaMsjes("ERROR", ex.Message);
                ventana2.iconoPregunta.Image = global::Ej_Interfaz_Proyecto.Properties.Resources.icn_err;
                ventana2.btnAceptar.Visible = true;
                ventana2.ShowDialog();
            }
        }
        private void ListadoProfesiones()
        {
            cbProfesion.DataSource = Profesion.ListarProfesiones();
            cbProfesion.DisplayMember = "NOMBRE_PROFESION";
            cbProfesion.ValueMember = "ID_PROFESION";
            cbProfesion.SelectedIndex = -1;
           
        }
        private void btnProfesiones_Click(object sender, EventArgs e)
        {
            FrmProfesion_1280x1024 _FrmProfesion = new FrmProfesion_1280x1024();
            _FrmProfesion.MdiParent = principal1;
            _FrmProfesion.Show();
            
        }

        private void cbProfesion_DropDown(object sender, EventArgs e)
        {
            try
            {
                ListadoProfesiones();
            }
            catch (Exception ex)
            {
                VentanaMsjes ventana2 = new VentanaMsjes("ERROR", ex.Message);
                ventana2.iconoPregunta.Image = global::Ej_Interfaz_Proyecto.Properties.Resources.icn_err;
                ventana2.btnAceptar.Visible = true;
                ventana2.ShowDialog();
            }
           
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtIdentificacion.Text.Trim().Equals("") || txtNombre.Text.Trim().Equals("") )
                
            
            {
                VentanaMsjes ventana = new VentanaMsjes("GUARDAR", "Diligencie toda la información requerida");
                ventana.iconoPregunta.Image = global::Ej_Interfaz_Proyecto.Properties.Resources.icn_inf;
                ventana.btnAceptar.Visible = true;
                ventana.ShowDialog();

                return;
            }
            if(cbTipo.SelectedIndex==-1)
            {
                VentanaMsjes ventana = new VentanaMsjes("GUARDAR", "Seleccione el tipo de instructor");
                ventana.iconoPregunta.Image = global::Ej_Interfaz_Proyecto.Properties.Resources.icn_inf;
                ventana.btnAceptar.Visible = true;
                ventana.ShowDialog();

                
                return;
            }

            //if (cbProfesion.SelectedIndex == -1) voy a mandar este campo null porque no es obligatorio!!
            //{
            //    VentanaMsjes ventana = new VentanaMsjes("GUARDAR", "Seleccione la profesión");
            //    ventana.iconoPregunta.Image = global::Ej_Interfaz_Proyecto.Properties.Resources.icn_inf;
            //    ventana.btnAceptar.Visible = true;
            //    ventana.ShowDialog();
                
            //    return;
            //}
         
            if (rdbNuevo.Checked)
            {
                try
                {
                    Instructor instructor = new Instructor();
                    instructor.Identificacion = txtIdentificacion.Text.Trim();
                    if (instructor.VerificarIdentificacion())
                    {
                        VentanaMsjes ventana = new VentanaMsjes("AVISO", "La identificación ya existe");
                        ventana.iconoPregunta.Image = global::Ej_Interfaz_Proyecto.Properties.Resources.icn_inf;
                        ventana.btnAceptar.Visible = true;
                        ventana.ShowDialog();

                        
                        txtIdentificacion.Focus();
                        txtIdentificacion.SelectAll();
                        return;
                    } 

                    //MessageBox.Show(cbProfesion.Text.ToString());
                    instructor.Nombre = txtNombre.Text.Trim();
                    instructor.Direccion = txtDireccion.Text.Trim();
                    instructor.Telefono = txtTelefono.Text.Trim();
                    instructor.Celular = txtCelular.Text.Trim();
                    instructor.Email = txtEmail.Text.Trim();
                    instructor.Tipo = cbTipo.SelectedItem.ToString();
                    if (cbProfesion.Text != "")
                    {
                        instructor.Profesion = cbProfesion.SelectedValue.ToString();
                    }
                    else
                    {
                        instructor.Profesion = "null";
                    }
                    //instructor.Exp_Contrato = textBox1.Text;
                    instructor.Registrar();
                    txtBuscar.Text = "";
                    ListadoDeInstructores(BuscarInstructorPor.Identificación,txtBuscar.Text.Trim());
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
                if (idActual == "")
                {
                    VentanaMsjes ventana2 = new VentanaMsjes("MODIFICAR", "Seleccione una fila del listado de instructores");
                    ventana2.iconoPregunta.Image = global::Ej_Interfaz_Proyecto.Properties.Resources.icn_inf;
                    ventana2.btnAceptar.Visible = true;
                    ventana2.ShowDialog();

                    
                    return;
                }
                try
                {
                    Instructor instructor = new Instructor();
                    instructor.Identificacion = txtIdentificacion.Text.Trim();

                    if(! idActual.Trim().Equals(txtIdentificacion.Text.Trim()))
                    {
                        if (instructor.VerificarIdentificacion())
                        {
                            VentanaMsjes ventana = new VentanaMsjes("MODIFICAR", "La identificación ya existe");
                            ventana.iconoPregunta.Image = global::Ej_Interfaz_Proyecto.Properties.Resources.icn_inf;
                            ventana.btnAceptar.Visible = true;
                            ventana.ShowDialog();
                            txtIdentificacion.Focus();
                            txtIdentificacion.SelectAll();
                            return;
                        }
                    }
                    instructor.Nombre = txtNombre.Text.Trim();
                    instructor.Direccion = txtDireccion.Text.Trim();
                    instructor.Telefono = txtTelefono.Text.Trim();
                    instructor.Celular = txtCelular.Text.Trim();
                    instructor.Email = txtEmail.Text.Trim();
                    instructor.Tipo = cbTipo.SelectedItem.ToString();
                    instructor.Profesion = cbProfesion.SelectedValue.ToString();
                    //instructor.Exp_Contrato = textBox1.Text;
                    
                    instructor.Modificar(idActual);

                    txtBuscar.Text = "";
                    ListadoDeInstructores(BuscarInstructorPor.Identificación, txtBuscar.Text.Trim());

                    LimpiarSeleccion();
                    Limpiar();
                    idActual = "";

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

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmInstructor_Load(object sender, EventArgs e)
        {
            //this.Top = (this.Parent.ClientSize.Height - this.Height) / 2;
            //this.Left = (this.Parent.ClientSize.Width - this.Width) / 2;
            try
            {
                ListadoDeInstructores(BuscarInstructorPor.Identificación, txtBuscar.Text.Trim());
                ListadoProfesiones();
               // ObtenerListadoAreas();
            }
            catch (Exception ex)
            {
                VentanaMsjes ventana2 = new VentanaMsjes("ERROR", ex.Message);
                ventana2.iconoPregunta.Image = global::Ej_Interfaz_Proyecto.Properties.Resources.icn_err;
                ventana2.btnAceptar.Visible = true;
                ventana2.ShowDialog();
            }
            
            LimpiarSeleccion();
            txtIdentificacion.Focus();
        }

        
        private void dgvInstructor_SelectionChanged(object sender, EventArgs e)
        {

            if (rdbModificar.Checked==true)
            {
                
                try
                {
                    txtIdentificacion.Text = dgvInstructor[0, dgvInstructor.CurrentRow.Index].Value.ToString();
                    txtNombre.Text = dgvInstructor[1, dgvInstructor.CurrentRow.Index].Value.ToString();
                    txtDireccion.Text = dgvInstructor[2, dgvInstructor.CurrentRow.Index].Value.ToString();
                    txtTelefono.Text = dgvInstructor[3, dgvInstructor.CurrentRow.Index].Value.ToString();
                    txtCelular.Text = dgvInstructor[4, dgvInstructor.CurrentRow.Index].Value.ToString();
                    txtEmail.Text = dgvInstructor[5, dgvInstructor.CurrentRow.Index].Value.ToString();
                    cbTipo.Text = dgvInstructor[6, dgvInstructor.CurrentRow.Index].Value.ToString();
                    cbProfesion.Text = dgvInstructor[7, dgvInstructor.CurrentRow.Index].Value.ToString();

                    idActual = txtIdentificacion.Text;
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
            if (rdbNuevo.Checked)
            {
                LimpiarSeleccion();
                Limpiar();
                btnEliminar.Enabled = false;
                idActual = "";
                
            }
        }

       

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            if(rdbId.Checked)
            {
                ListadoDeInstructores(BuscarInstructorPor.Identificación, txtBuscar.Text.Trim());
            }
            if(rdbNombre.Checked)
            {
                  ListadoDeInstructores(BuscarInstructorPor.Nombre, txtBuscar.Text.Trim());
            }
        }

        private void rdbId_CheckedChanged(object sender, EventArgs e)
        {
            
                txtBuscar.Text = "";
                txtBuscar.Focus();
            
        }

        private void rdbModificar_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbModificar.Checked)
            {
                ListadoProfesiones();
                LimpiarSeleccion();
                Limpiar();
                btnEliminar.Enabled = true;
                idActual = "";
            }
        }


        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (idActual == "")
            {
                VentanaMsjes ventana = new VentanaMsjes("ELIMINAR", "Seleccione una fila del listado de instructores");
                ventana.iconoPregunta.Image = global::Ej_Interfaz_Proyecto.Properties.Resources.icn_inf;
                ventana.btnAceptar.Visible = true;
                ventana.ShowDialog();

               
                return;
            }
            try
            {
                Instructor instructor = new Instructor();
                instructor.Identificacion = idActual;

                VentanaMsjes ventana = new VentanaMsjes("ELIMINAR", "¿Confirma eliminar el instructor?");
                ventana.btnSi.Visible = true;
                ventana.btnNo.Visible = true;
                ventana.iconoPregunta.Image = global::Ej_Interfaz_Proyecto.Properties.Resources.icn_pre;
                DialogResult msgdresult = ventana.ShowDialog();

                if (msgdresult.ToString().Equals("OK"))
                {
                    instructor.Eliminar();

                    txtBuscar.Text = "";
                    ListadoDeInstructores(BuscarInstructorPor.Identificación, txtBuscar.Text.Trim());

                    VentanaMsjes ventana2 = new VentanaMsjes("ELIMINAR", "Eliminación exitosa");
                    ventana2.iconoPregunta.Image = global::Ej_Interfaz_Proyecto.Properties.Resources.icn_inf;
                    ventana2.btnAceptar.Visible = true;
                    ventana2.ShowDialog();
                }
                LimpiarSeleccion();
                Limpiar();
                idActual = "";

            }
            catch (Exception ex)
            {
                VentanaMsjes ventana2 = new VentanaMsjes("ERROR", ex.Message);
                ventana2.iconoPregunta.Image = global::Ej_Interfaz_Proyecto.Properties.Resources.icn_err;
                ventana2.btnAceptar.Visible = true;
                ventana2.ShowDialog();
            }
        }

        private void FrmInstructor_FormClosed(object sender, FormClosedEventArgs e)
        {
            principal1.BtnInstructor.Enabled = true;
        }

        private void txtIdentificacion_KeyPress(object sender, KeyPressEventArgs e)
        {
            soloNumeros(e);
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
            principal1.BtnInstructor.Enabled = true;
            this.Close();
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
            this.Hide();
            for (int i = 0; i < 5; i++)
            {
                if (principal1.EspacioMin[i].Equals("Desocupado"))
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

                    principal1.EspacioMin[i] = ("Ocupado");

                    FrmMinInstructor MinInstructor = new FrmMinInstructor(this, principal1);
                    MinInstructor.MdiParent = principal1;
                    MinInstructor.Location = new Point(pos, Screen.PrimaryScreen.Bounds.Height - 150-20);
                    MinInstructor.StartPosition = FormStartPosition.Manual;
                    MinInstructor.Show();
                    i = 10;
                }


            }
        }

        private void label14_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void FrmInstructor_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void txtCelular_KeyPress(object sender, KeyPressEventArgs e)
        {
            soloNumeros(e);
        }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            soloNumeros(e);
        }

        private void cbProfesion_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ResultadosInstructor_Click(object sender, EventArgs e)
        {
           

            if (dgvInstructor.SelectedRows.Count >= 1)
            {
                FrmResultados_Instructor_1280x1024 Resultados = new FrmResultados_Instructor_1280x1024(dgvInstructor[0, dgvInstructor.CurrentRow.Index].Value.ToString(),dgvInstructor[1, dgvInstructor.CurrentRow.Index].Value.ToString());
                Resultados.MdiParent = principal1;
                Resultados.Show();


            }
            else
            {
                VentanaMsjes ventana = new VentanaMsjes("AVISO", "Seleccione un instructor");
                ventana.iconoPregunta.Image = global::Ej_Interfaz_Proyecto.Properties.Resources.icn_inf;
                ventana.btnAceptar.Visible = true;
                ventana.ShowDialog();


            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            int dia = dateTimePicker1.Value.Day;
            int mes = dateTimePicker1.Value.Month;
            int ani = dateTimePicker1.Value.Year + 1;

        }

        //private void btnBuscarResultados_Click(object sender, EventArgs e)
        //{
        //    FrmGestionarResultados Resultados = new FrmGestionarResultados();
        //    Resultados.Owner = this;
        //    Resultados.StartPosition = FormStartPosition.CenterParent;
        //    Resultados.ShowDialog();
        //}

    }
}
