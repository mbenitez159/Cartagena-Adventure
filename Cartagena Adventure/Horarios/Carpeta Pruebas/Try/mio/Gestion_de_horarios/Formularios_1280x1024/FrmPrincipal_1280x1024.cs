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
    public partial class FrmPrincipal_1280x1024 : Form
    {

        public string[] EspacioMin = new string[6];

        public FrmPrincipal_1280x1024()
        {
            InitializeComponent();

            EspacioMin[0] = "Desocupado";
            EspacioMin[1] = "Desocupado";
            EspacioMin[2] = "Desocupado";
            EspacioMin[3] = "Desocupado";
            EspacioMin[4] = "Desocupado";
            EspacioMin[5] = "Desocupado";
        }


        public void Habilitar()
        {
            BtnAmbiente.Enabled = true;
            BtnAreas.Enabled = true;
            BtnPrograma.Enabled = true;
            BtnInstructor.Enabled = true;
            BtnHorario.Enabled = true;
            btnAdmin.Enabled = true;
        }
        public void HabilitarC()
        {
            BtnAmbiente.Enabled = true;
            BtnAreas.Enabled = true;
            BtnPrograma.Enabled = true;
            BtnInstructor.Enabled = true;
            BtnHorario.Enabled = true;
        }
        public void Deshabilitar()
        {
            foreach (Form item in this.MdiChildren)
            {
                item.Close();
                item.Dispose();
            }
            BtnAmbiente.Enabled = false;
            BtnAreas.Enabled = false;
            BtnPrograma.Enabled = false;
            BtnInstructor.Enabled = false;
            BtnHorario.Enabled = false;
            btnAdmin.Enabled = false;

        }


        private void ColorFondo()
        {
            MdiClient ctlMDI;

            foreach (Control ctl in this.Controls)
            {
                try
                {
                  
                    ctlMDI = (MdiClient)ctl;

                  
                    ctlMDI.BackColor = Color.FromArgb(228, 234, 234);
                }
                catch (InvalidCastException)
                {
                  
                }
            }
        }

        private void FrmPrincipalN_Load(object sender, EventArgs e)
        {
            Deshabilitar();

            this.BackColor = Color.FromArgb(228, 234, 234);
            ColorFondo();
            this.pictureBox1.BackColor = Color.FromArgb(4, 123, 117);
            this.TextoSuperior.ForeColor = Color.FromArgb(4, 123, 117);
           this.TextCentro.ForeColor = Color.FromArgb(153, 153, 153);

            this.Size = new System.Drawing.Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height - 40);
            this.Location = new System.Drawing.Point(0, 0);
            int centro = (this.Size.Width) / 2;


           this.TextoSuperior.Location = new System.Drawing.Point(centro - (TextoSuperior.Size.Width / 2), 10);
            this.Cerrar.Location = new System.Drawing.Point(Screen.PrimaryScreen.Bounds.Width - 38, 7);
            this.Maximizar.Location = new System.Drawing.Point(Screen.PrimaryScreen.Bounds.Width - 74, 7);
            this.Minimizar.Location = new System.Drawing.Point(Screen.PrimaryScreen.Bounds.Width - 110, 7);
            this.pictureBox1.Size = new System.Drawing.Size(Screen.PrimaryScreen.Bounds.Width, 2);
            this.TextCentro.Location = new System.Drawing.Point(centro - (TextCentro.Size.Width / 2), (Screen.PrimaryScreen.Bounds.Height - 40) - 22);

            this.BtnInstructor.Location = new System.Drawing.Point(centro - (BtnInstructor.Size.Width / 2)+40, 55);
            this.BtnAreas.Location = new System.Drawing.Point(BtnInstructor.Location.X + 86, 63);
            this.BtnHorario.Location = new System.Drawing.Point(BtnInstructor.Location.X + 180, 63);
            this.BtnPrograma.Location = new System.Drawing.Point(BtnInstructor.Location.X - 104, 63);
            this.BtnAmbiente.Location = new System.Drawing.Point(BtnInstructor.Location.X - 195, 55);
            this.btnAdmin.Location = new System.Drawing.Point(BtnInstructor.Location.X - 295, 60);

            cerrar_sesion.ForeColor = Color.FromArgb(4, 123, 117);
            cerrar_sesion.BackColor = Color.FromArgb(228, 234, 234);
           

            CargarInicio();


        }

        private void BtnAmbiente_MouseMove(object sender, MouseEventArgs e)
        {
            this.BtnAmbiente.Image = global::Ej_Interfaz_Proyecto.Properties.Resources.btn_amb_focus;
        
            this.TextoSuperior.Text = "GESTIÓN DE HORARIOS | AMBIENTES";

            int centro = (this.Size.Width) / 2;
            this.TextoSuperior.Location = new System.Drawing.Point(centro-(TextoSuperior.Size.Width/2), 10);

 
        }

        private void BtnAmbiente_MouseLeave(object sender, EventArgs e)
        {
            this.BtnAmbiente.Image = global::Ej_Interfaz_Proyecto.Properties.Resources.btn_amb_normal;
            this.TextoSuperior.Text = "GESTIÓN DE HORARIOS";
            int centro = (this.Size.Width) / 2;
            this.TextoSuperior.Location = new System.Drawing.Point(centro - (TextoSuperior.Size.Width / 2), 10);
        }

        private void BtnPrograma_MouseLeave(object sender, EventArgs e)
        {
            this.BtnPrograma.Image = global::Ej_Interfaz_Proyecto.Properties.Resources.btn_pdf_normal;
            this.TextoSuperior.Text = "GESTIÓN DE HORARIOS";
            int centro = (this.Size.Width) / 2;
            this.TextoSuperior.Location = new System.Drawing.Point(centro - (TextoSuperior.Size.Width / 2), 10);
            
        }

        private void BtnPrograma_MouseMove(object sender, MouseEventArgs e)
        {
            this.BtnPrograma.Image = global::Ej_Interfaz_Proyecto.Properties.Resources.btn_pdf_focus;
            this.TextoSuperior.Text = "GESTIÓN DE HORARIOS | PROGRAMAS DE FORMACIÓN";
            int centro = (this.Size.Width) / 2;
            this.TextoSuperior.Location = new System.Drawing.Point(centro - (TextoSuperior.Size.Width / 2), 10);
        }

        private void BtnInstructor_MouseLeave(object sender, EventArgs e)
        {
            this.BtnInstructor.Image = global::Ej_Interfaz_Proyecto.Properties.Resources.btn_ins_normal;
            this.TextoSuperior.Text = "GESTIÓN DE HORARIOS";
            int centro = (this.Size.Width) / 2;
            this.TextoSuperior.Location = new System.Drawing.Point(centro - (TextoSuperior.Size.Width / 2), 10);
        }

        private void BtnInstructor_MouseMove(object sender, MouseEventArgs e)
        {
            this.BtnInstructor.Image = global::Ej_Interfaz_Proyecto.Properties.Resources.btn_ins_focus;
            this.TextoSuperior.Text = "GESTIÓN DE HORARIOS | INSTRUCTORES";
            int centro = (this.Size.Width) / 2;
            this.TextoSuperior.Location = new System.Drawing.Point(centro - (TextoSuperior.Size.Width / 2), 10);
        }

        private void BtnAreas_MouseLeave(object sender, EventArgs e)
        {
            this.BtnAreas.Image = global::Ej_Interfaz_Proyecto.Properties.Resources.btn_are_normal;
            this.TextoSuperior.Text = "GESTIÓN DE HORARIOS";
            int centro = (this.Size.Width) / 2;
            this.TextoSuperior.Location = new System.Drawing.Point(centro - (TextoSuperior.Size.Width / 2), 10);
        }

        private void BtnAreas_MouseMove(object sender, MouseEventArgs e)
        {
            this.BtnAreas.Image = global::Ej_Interfaz_Proyecto.Properties.Resources.btn_are_focus;
            this.TextoSuperior.Text = "GESTIÓN DE HORARIOS | ÁREAS";
            int centro = (this.Size.Width) / 2;
            this.TextoSuperior.Location = new System.Drawing.Point(centro - (TextoSuperior.Size.Width / 2), 10);
        }

        private void BtnHorario_MouseLeave(object sender, EventArgs e)
        {
            this.BtnHorario.Image = global::Ej_Interfaz_Proyecto.Properties.Resources.btn_hor_normal;
            this.TextoSuperior.Text = "GESTIÓN DE HORARIOS";
            int centro = (this.Size.Width) / 2;
            this.TextoSuperior.Location = new System.Drawing.Point(centro - (TextoSuperior.Size.Width / 2), 10);
        }

        private void BtnHorario_MouseMove(object sender, MouseEventArgs e)
        {
            this.BtnHorario.Image = global::Ej_Interfaz_Proyecto.Properties.Resources.btn_hor_focus;
            this.TextoSuperior.Text = "GESTIÓN DE HORARIOS | GENERAR HORARIOS";
            int centro = (this.Size.Width) / 2;
            this.TextoSuperior.Location = new System.Drawing.Point(centro - (TextoSuperior.Size.Width / 2), 10);
        }

        private void Minimizar_MouseLeave(object sender, EventArgs e)
        {
            this.Minimizar.Image = global::Ej_Interfaz_Proyecto.Properties.Resources.btn_min_normal;

        }

        private void Minimizar_MouseMove(object sender, MouseEventArgs e)
        {
            this.Minimizar.Image = global::Ej_Interfaz_Proyecto.Properties.Resources.btn_min_focus;
        }

        private void Cerrar_MouseLeave(object sender, EventArgs e)
        {
            this.Cerrar.Image = global::Ej_Interfaz_Proyecto.Properties.Resources.btn_cer_normal;
        }

        private void Cerrar_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cerrar.Image = global::Ej_Interfaz_Proyecto.Properties.Resources.btn_cer_focus;
        }

        private void Cerrar_Click(object sender, EventArgs e)
        {

        this.Close();

        }

        private void Minimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        public void CargarInicio()
        {

            FrmInicioSesion_1280x1024 inicio = new FrmInicioSesion_1280x1024(this);

            //inicio.Location = new System.Drawing.Point(this.Size.Width / 2 - (inicio.Size.Width / 2), this.Size.Height / 2 - (inicio.Size.Height / 2));

            inicio.MdiParent = this;

            inicio.Show();
        }

        private void BtnAmbiente_Click(object sender, EventArgs e)
        {
            FrmAmbientes_1280x1024 _FrmAmbientes = new FrmAmbientes_1280x1024(this);
            _FrmAmbientes.MdiParent = this;
            BtnAmbiente.Enabled = false;
            _FrmAmbientes.Show();
        }

        private void BtnPrograma_Click(object sender, EventArgs e)
        {
            Programa_1280x1024 program = new Programa_1280x1024(this);
            BtnPrograma.Enabled = false;
            program.MdiParent = this;
            program.Show();
        }
        FrmInstructor_1280x1024 _FrmInstructor =null;
        private void BtnInstructor_Click(object sender, EventArgs e)
        {
            // if (_FrmInstructor == null)
            //{
             _FrmInstructor = new FrmInstructor_1280x1024(this);
                BtnInstructor.Enabled = false;
                _FrmInstructor.MdiParent = this;
                //  _FrmInstructor.Location = new Point(this.Size.Width / 2 - (_FrmInstructor.Size.Width / 2), 140);
                _FrmInstructor.Show();
            // }
            
        }

        private void BtnHorario_Click(object sender, EventArgs e)
        {
            GestionHorario.GenerarHorario horario = new GestionHorario.GenerarHorario(this);
            //BtnHorario.Enabled = false;            
            horario.Location = new Point(this.Size.Width / 2 - (horario.Size.Width / 2), 140);
            horario.Show();
        }

        private void cerrar_sesion_Click(object sender, EventArgs e)
        {
            Deshabilitar();
            cerrar_sesion.Visible = false;
            CargarInicio();
        }

        private void BtnAreas_Click(object sender, EventArgs e)
        {
            FrmArea_1280x1024 area = new FrmArea_1280x1024(this);
            BtnAreas.Enabled = false;
            area.MdiParent = this;
            area.Show();
        }

        private void FrmPrincipal_1280x1024_FormClosing(object sender, FormClosingEventArgs e)
        {
            VentanaMsjes ventana = new VentanaMsjes("GESTIÓN DE HORARIOS", "¿Está seguro que desea salir del aplicativo?");
            ventana.iconoPregunta.Image = global::Ej_Interfaz_Proyecto.Properties.Resources.icn_inf;
            ventana.btnSi.Visible = true;
            ventana.btnNo.Visible = true;
            DialogResult msgdresult = ventana.ShowDialog();
            if (!msgdresult.Equals(DialogResult.OK))
            {
                e.Cancel = true;

            }
        }

        private void btnAdmin_MouseLeave(object sender, EventArgs e)
        {
            this.btnAdmin.Image = global::Ej_Interfaz_Proyecto.Properties.Resources.tool__1_;
            this.TextoSuperior.Text = "GESTIÓN DE HORARIOS";
            int centro = (this.Size.Width) / 2;
            this.TextoSuperior.Location = new System.Drawing.Point(centro - (TextoSuperior.Size.Width / 2), 10);
        }

        private void btnAdmin_MouseMove(object sender, MouseEventArgs e)
        {
            this.btnAdmin.Image = global::Ej_Interfaz_Proyecto.Properties.Resources.tool__1_1;
            this.TextoSuperior.Text = "GESTIÓN DE HORARIO | ADMINISTRADOR";
            int centro = (this.Size.Width) / 2;
            this.TextoSuperior.Location = new System.Drawing.Point(centro - (TextoSuperior.Size.Width / 2), 10);
        }



        private void btnAdmin_Click_1(object sender, EventArgs e)
        {
          FrmAdmin_1280x1024 cm = new FrmAdmin_1280x1024(this);
            btnAdmin.Enabled = false;
            cm.MdiParent = this;
            cm.Show();
        }


    }
}
