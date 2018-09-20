using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ej_Interfaz_Proyecto.Formularios_1280x1024;
using Ej_Interfaz_Proyecto.GestionHorario;

namespace Ej_Interfaz_Proyecto.FrmMinimizados_1280x1024
{
    public partial class FrmMinHorarios : Form
    {
        GenerarHorario horario;
        FrmPrincipal_1280x1024 principal;
        public FrmMinHorarios(GenerarHorario horario, FrmPrincipal_1280x1024 principal)
        {
            InitializeComponent();

            this.horario = horario;
            this.principal = principal;
            this.BackColor = Color.FromArgb(4, 123, 117);
        }

        private void FrmMinHorarios_MouseClick(object sender, MouseEventArgs e)
        {
            click();
        }

        private void label1_Click(object sender, EventArgs e)
        {

            this.Close();
            horario.Show();

            VentanaMsjes ventana = new VentanaMsjes("CERRAR", "¿Confirma que desea cerrar esta ventana?");
            ventana.btnSi.Visible = true;
            ventana.btnNo.Visible = true;
            ventana.iconoPregunta.Image = global::Ej_Interfaz_Proyecto.Properties.Resources.icn_pre;
            DialogResult msgdresult = ventana.ShowDialog();

            if (msgdresult.ToString().Equals("OK"))
            {
                horario.Close();
                principal.BtnHorario.Enabled = true;
            }

            principal.EspacioMin[horario.posM] = "Desocupado";
        }

        public void click()
        {

            this.Close();
            principal.EspacioMin[horario.posM] = "Desocupado";
            horario.Show();
        }

        private void FrmMinHorarios_MouseMove(object sender, MouseEventArgs e)
        {
            this.BackColor = Color.FromArgb(2, 150, 132);
        }

        private void FrmMinHorarios_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(4, 123, 117);
        }

        private void label2_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(4, 123, 117);
        }

        private void label2_MouseMove(object sender, MouseEventArgs e)
        {
            this.BackColor = Color.FromArgb(2, 150, 132);
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(4, 123, 117);
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            this.BackColor = Color.FromArgb(2, 150, 132);
        }

        private void label2_Click(object sender, EventArgs e)
        {
            click();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            click();
        }

        private void label1_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(4, 123, 117);
        }

        private void label1_MouseMove(object sender, MouseEventArgs e)
        {
            this.BackColor = Color.FromArgb(2, 150, 132);
        }

       
    }
}
