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

namespace Ej_Interfaz_Proyecto.FrmMinimizados_1280x1024
{
    public partial class FrmMinProgram : Form

    {
        Programa_1280x1024 Programa;
        FrmPrincipal_1280x1024 principal;

        public FrmMinProgram(Programa_1280x1024 Programa, FrmPrincipal_1280x1024 principal)
        {
            InitializeComponent();
            this.Programa = Programa;          
            this.principal = principal;
            this.BackColor = Color.FromArgb(4, 123, 117);
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Close();
            Programa.Show();

            VentanaMsjes ventana = new VentanaMsjes("CERRAR", "¿Confirma que desea cerrar esta ventana?");
            ventana.btnSi.Visible = true;
            ventana.btnNo.Visible = true;
            ventana.iconoPregunta.Image = global::Ej_Interfaz_Proyecto.Properties.Resources.icn_pre;
            DialogResult msgdresult = ventana.ShowDialog();

            if (msgdresult.ToString().Equals("OK"))
            {
                Programa.Close();
                principal.BtnPrograma.Enabled = true;
            }



            principal.EspacioMin[Programa.posM] = "Desocupado";
        }

        public void click()
        {
            this.Close();
            principal.EspacioMin[Programa.posM] = "Desocupado";
            Programa.Show();

        }

        private void FrmMinProgram_MouseClick(object sender, MouseEventArgs e)
        {
            click();

        }

        private void FrmMinProgram_MouseMove(object sender, MouseEventArgs e)
        {
            this.BackColor = Color.FromArgb(2, 150, 132);
        }

        private void FrmMinProgram_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(4, 123, 117);
        }

        private void label2_MouseMove(object sender, MouseEventArgs e)
        {
            this.BackColor = Color.FromArgb(2, 150, 132);
        }

        private void label2_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(4, 123, 117);
        }

        private void label3_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(4, 123, 117);
        }

        private void label3_MouseMove(object sender, MouseEventArgs e)
        {
            this.BackColor = Color.FromArgb(2, 150, 132);
        }

        private void label4_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(4, 123, 117);
        }

        private void label4_MouseMove(object sender, MouseEventArgs e)
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

        private void label3_Click(object sender, EventArgs e)
        {
            click();
        }

        private void label4_Click(object sender, EventArgs e)
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
