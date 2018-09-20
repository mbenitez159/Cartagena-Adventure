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
    public partial class FrmBusqueda_1280x1024 : Form
    {
        bool Busqueda = true;
        // Declaraciones del API PARA MOVER EL FORMULARIO
        [System.Runtime.InteropServices.DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        //
        [System.Runtime.InteropServices.DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        public delegate void pasar(string id,string nombre, string Cell_Jor);
        public event pasar pasando;


        string miconsulta;
        string id_co;
        string name;
        string area_jor_celu;
        string TIPO;
        public FrmBusqueda_1280x1024(string consulta, string id_Co, string name, string Area_Jor_Cel, string tipo)
        {
            InitializeComponent();
            miconsulta = consulta;
            this.id_co = id_Co;
            this.area_jor_celu = Area_Jor_Cel;
            this.name = name;
            this.TIPO = tipo;
            this.BackColor = Color.FromArgb(4, 123, 117);
            
        }
        //iD es tru Nombre es false
        private void busquedaCorrecta()
        {
            Ambientes a = new Ambientes();
            if (TIPO.Equals("Ambiente"))
            {
                if (Busqueda)
                {
                    dgvBusqueda.DataSource = a.ejecutar("select a.ID_AMBIENTE as Código,a.NOMBRE_AMBIENTE as Nombre,ar.NOMBRE as Área from AMBIENTE a, AREAS ar where a.ID_AREA=ar.ID and cast( a.ID_AMBIENTE as varchar(40)) LIKE '" + txtBuscar.Text + "%'");
                }
                else
                {
                    dgvBusqueda.DataSource = a.ejecutar("select a.ID_AMBIENTE as Código,a.NOMBRE_AMBIENTE as Nombre,ar.NOMBRE as Área from AMBIENTE a, AREAS ar where a.ID_AREA=ar.ID and a.NOMBRE_AMBIENTE LIKE '" + txtBuscar.Text + "%'");
                }

            }
            else if (TIPO.Equals("Grupo"))
            {
                if (Busqueda)
                {
                    dgvBusqueda.DataSource = a.ejecutar("select g.ID_GRUPO as Código,p.NOMBRE_PROGRAMA as Programa, g.JORNADA as Jornada from GRUPO g, PROGRAMA p where p.ID_PROGRAMA=g.ID_PROGRAMA and cast( g.ID_GRUPO  as varchar(40))LIKE '"+txtBuscar.Text+"%'");
                }
                else
                {
                    dgvBusqueda.DataSource = a.ejecutar("select g.ID_GRUPO as Código,p.NOMBRE_PROGRAMA as Programa, g.JORNADA as Jornada from GRUPO g, PROGRAMA p where p.ID_PROGRAMA=g.ID_PROGRAMA and p.NOMBRE_PROGRAMA LIKE'"+txtBuscar.Text+"%'");
                }

            }
            else if (TIPO.Equals("Instructor"))
            {
                if (Busqueda)
                {
                    dgvBusqueda.DataSource = Instructor.ListadoDeInstructores(BuscarInstructorPor.Identificación, txtBuscar.Text, true);
                }
                else
                {
                    dgvBusqueda.DataSource = Instructor.ListadoDeInstructores(BuscarInstructorPor.Nombre, txtBuscar.Text, true);
                }

            }
        }
        
        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            busquedaCorrecta();
        }
       
        private void rdbId_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbId.Checked==true)
            {
                Busqueda = true;
            }
            else
            {
                Busqueda = false;
            }
        }

        private void FrmBusqueda_1280x1024_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void FrmBusqueda_1280x1024_Load(object sender, EventArgs e)
        {                       
            if (string.IsNullOrEmpty(miconsulta))
            {
                miconsulta = "select i.ID_INSTRUCTOR as Identificación,i.NOMBRE as Nombre,i.CELULAR as Celular from instructor i";
                rdbId.Text = "Código";
                
            }
            cargardata();
            radiosBoton();
        }

        private void cargardata()
        {
           Conexion c= new Conexion();
            c.AbrirConexion();
            System.Data.SqlClient.SqlCommand cm = c.GetConexion.CreateCommand();
            cm.CommandText = miconsulta;
            System.Data.SqlClient.SqlDataReader dr = cm.ExecuteReader();
            System.Data.DataTable dt = new DataTable();
            dt.Load(dr);
            dr.Close();
            c.CerrarConexion();
            dgvBusqueda.Columns[0].DataPropertyName = id_co;
            dgvBusqueda.Columns[1].DataPropertyName = name;
            dgvBusqueda.Columns[2].DataPropertyName = area_jor_celu;
            dgvBusqueda.Columns[0].HeaderText = id_co;
            dgvBusqueda.Columns[1].HeaderText = name;
            dgvBusqueda.Columns[2].HeaderText = area_jor_celu; 
            dgvBusqueda.DataSource = dt;
            dr.Close();
            c.CerrarConexion();
        }
        private void radiosBoton()
        {
            rdbId.Text = "Identificación";
            if (TIPO.Equals("Ambiente"))
            {
                rdbId.Text = "Código";
                
            }
            else if (TIPO.Equals("Grupo"))
            {
                rdbId.Text = "Ficha";
                
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            pasando(dgvBusqueda.CurrentRow.Cells[0].Value.ToString(), dgvBusqueda.CurrentRow.Cells[1].Value.ToString(),dgvBusqueda.CurrentRow.Cells[2].Value.ToString());
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
