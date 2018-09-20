using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Ej_Interfaz_Proyecto.Formularios_1280x1024
{
    public partial class FrmPDF_1280x1024 : Form
    {

        // Declaraciones del API PARA MOVER EL FORMULARIO
        [System.Runtime.InteropServices.DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        //
        [System.Runtime.InteropServices.DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        string miconsulta;
        int miIten = 1;
       string tipo;
        string anio;
        public string mañana;
        public string tarde;
        public string noche;
        public FrmPDF_1280x1024(string a, int iten, string tipo, string anio)
        {
            InitializeComponent();           
            miconsulta = a;
            miIten = iten;
            this.tipo = tipo;
            this.anio = anio;
            
        }
        
        private void FrmPDF_1280x1024_Load(object sender, EventArgs e)
        {
            Generar_horarioDataSet.EnforceConstraints = false;
            GestionHorario.Conexion c = new GestionHorario.Conexion();
            c.AbrirConexion();
            SqlCommand cm = new SqlCommand(miconsulta, c.GetConexion);
            cm.ExecuteNonQuery();
            this.horaTableAdapter.Fill(this.Generar_horarioDataSet.hora);            
            this.informeTableAdapter.Fill(this.Generar_horarioDataSet.informe,miIten, tipo,anio,mañana,tarde,noche);
            this.reportViewer1.RefreshReport();     
            cm = new SqlCommand(" truncate table hora;", c.GetConexion);
            cm.ExecuteNonQuery();
            c.CerrarConexion();
            this.WindowState = FormWindowState.Maximized;
        }

        private void FrmPDF_1280x1024_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox4_MouseLeave(object sender, EventArgs e)
        {
            this.pictureBox4.Image = global::Ej_Interfaz_Proyecto.Properties.Resources.btn_cer_normal2;
        }

        private void pictureBox4_MouseMove(object sender, MouseEventArgs e)
        {
            this.pictureBox4.Image = global::Ej_Interfaz_Proyecto.Properties.Resources.btn_cer_focus2;
        }

        private void FrmPDF_1280x1024_Resize(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }
    }
}
