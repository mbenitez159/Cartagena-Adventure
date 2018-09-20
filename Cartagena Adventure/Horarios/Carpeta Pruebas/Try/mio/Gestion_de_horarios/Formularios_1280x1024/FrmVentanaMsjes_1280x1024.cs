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
    public partial class VentanaMsjes : Form
    {

        // Declaraciones del API PARA MOVER EL FORMULARIO
        [System.Runtime.InteropServices.DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        //
        [System.Runtime.InteropServices.DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        public VentanaMsjes(String titulo, String texto_ventana)
        {
            InitializeComponent();
            this.TituloVentana.Text = titulo;
            this.TextoMsje.Text = texto_ventana;
            this.TituloVentana.Location = new System.Drawing.Point(200 - (TituloVentana.Size.Width / 2), 10);
            this.TextoMsje.Location = new System.Drawing.Point(200 - (TextoMsje.Size.Width / 2), 112);
            this.BackColor = Color.FromArgb(4, 123, 117);
            this.btnNo.ForeColor = Color.FromArgb(128, 128, 128); 
            this.btnSi.ForeColor = Color.FromArgb(4, 123, 117);
            this.btnAceptar.ForeColor = Color.FromArgb(4, 123, 117);

        }

        private void pictureBox6_MouseLeave(object sender, EventArgs e)
        {
            this.pictureBox6.Image = global::Ej_Interfaz_Proyecto.Properties.Resources.btn_cer_normal2;
        }

        private void pictureBox6_MouseMove(object sender, MouseEventArgs e)
        {
            this.pictureBox6.Image = global::Ej_Interfaz_Proyecto.Properties.Resources.btn_cer_focus2;
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void VentanaMsjes_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnSi_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnNo_Click(object sender, EventArgs e)
        {
                this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
