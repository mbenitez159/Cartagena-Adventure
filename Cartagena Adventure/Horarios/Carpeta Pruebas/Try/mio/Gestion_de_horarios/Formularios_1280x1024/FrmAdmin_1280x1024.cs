using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ej_Interfaz_Proyecto.Clases_1280x1024;
using Ej_Interfaz_Proyecto.FrmMinimizados_1280x1024;
namespace Ej_Interfaz_Proyecto.Formularios_1280x1024
{
    public partial class FrmAdmin_1280x1024 : Form
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
        FrmPrincipal_1280x1024 Principal;
        public FrmAdmin_1280x1024(FrmPrincipal_1280x1024 principal)
        {
            InitializeComponent();
            Principal = principal;
            limpiar();
            this.BackColor = Color.FromArgb(4, 123, 117);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtusuario.Text)|| string.IsNullOrEmpty(txtcontra.Text)|| string.IsNullOrEmpty(cbusu.Text))
            {
                VentanaMsjes ventana = new VentanaMsjes("GUARDAR", "Diligencie ambos campos");
                ventana.iconoPregunta.Image = global::Ej_Interfaz_Proyecto.Properties.Resources.icn_inf;
                ventana.btnAceptar.Visible = true;
                ventana.ShowDialog();

                return;
            }
            else if (rdbModificar.Checked)
            {
                try
                {
                    Conexion C = new Conexion();
                    C.AbrirConexion();
                    string a = "try";
                    System.Data.SqlClient.SqlCommand cm = new System.Data.SqlClient.SqlCommand("exec modificarUser '"+dgvUsuario.CurrentRow.Cells[0].Value.ToString()+"','"+txtusuario.Text+"','"+txtcontra.Text+"','"+cbusu.Text+"'", C.GetConexion);
                    System.Data.SqlClient.SqlDataReader dr = cm.ExecuteReader();
                    while (dr.Read())
                    {
                        a = dr.GetString(0);
                    }
                    limpiar();
                    cargarInicio();
                    VentanaMsjes ventana = new VentanaMsjes("Modificar", a);
                    ventana.iconoPregunta.Image = global::Ej_Interfaz_Proyecto.Properties.Resources.icn_inf;
                    ventana.btnAceptar.Visible = true;
                    ventana.ShowDialog();                    
                    dr.Close();
                    limpiar();
                }
                catch (Exception ex)
                {

                    VentanaMsjes ventana2 = new VentanaMsjes("ERROR", ex.Message);
                    ventana2.iconoPregunta.Image = global::Ej_Interfaz_Proyecto.Properties.Resources.icn_err;
                    ventana2.btnAceptar.Visible = true;
                    ventana2.ShowDialog();
                }
            }
            else
            {
                Conexion C = new Conexion();
                C.AbrirConexion();
                try
                {
                    string a = "try";
                    System.Data.SqlClient.SqlCommand cm = new System.Data.SqlClient.SqlCommand("exec registroUser '"+txtusuario.Text+"', '"+txtcontra.Text+"','"+cbusu.Text+"'", C.GetConexion);
                    System.Data.SqlClient.SqlDataReader dr = cm.ExecuteReader();
                    while (dr.Read())
                    {
                        a = dr.GetString(0);
                    }
                    limpiar();
                    cargarInicio();
                    VentanaMsjes ventana = new VentanaMsjes("Registro", a);
                    ventana.iconoPregunta.Image = global::Ej_Interfaz_Proyecto.Properties.Resources.icn_inf;
                    ventana.btnAceptar.Visible = true;
                    ventana.ShowDialog();                    
                    dr.Close();
                    limpiar();
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

        private void FrmAdmin_1280x1024_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Hide();
            for (int i = 0; i < 5; i++)
            {
                if (Principal.EspacioMin[i].Equals("Desocupado"))
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

                    Principal.EspacioMin[i] = ("Ocupado");
                    FrmMinAdmin admin = new FrmMinAdmin(this, Principal);//agrgar formulario minimisado de admin
                    admin.MdiParent = principal;
                    admin.Location = new Point(pos, Screen.PrimaryScreen.Bounds.Height - 150 - 20);
                    admin.StartPosition = FormStartPosition.Manual;
                    admin.Show();

                    i = 10;
                }


            }
        }

        private void pictureBox3_MouseLeave(object sender, EventArgs e)
        {
            this.pictureBox3.Image = global::Ej_Interfaz_Proyecto.Properties.Resources.btn_min_normal2;
        }

        private void pictureBox3_MouseMove(object sender, MouseEventArgs e)
        {
            this.pictureBox3.Image = global::Ej_Interfaz_Proyecto.Properties.Resources.btn_min_focus2;
        }

        private void pictureBox4_MouseLeave(object sender, EventArgs e)
        {
            this.pictureBox4.Image = global::Ej_Interfaz_Proyecto.Properties.Resources.btn_cer_normal2;
        }

        private void pictureBox4_MouseMove(object sender, MouseEventArgs e)
        {
            this.pictureBox4.Image = global::Ej_Interfaz_Proyecto.Properties.Resources.btn_cer_focus2;
        }

        private void FrmAdmin_1280x1024_Load(object sender, EventArgs e)
        {
            dgvUsuario.Columns[0].DataPropertyName = "Usuario".Trim();
            dgvUsuario.Columns[1].DataPropertyName = "Contraseña".Trim();
            dgvUsuario.Columns[2].DataPropertyName = "Tipo de usuario".Trim();
            cargarInicio();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.Close();
            Principal.btnAdmin.Enabled = true;
        }
        private void cargarInicio() {
            Conexion c = new Conexion();
            c.AbrirConexion();
            SqlCommand cm = c.GetConexion.CreateCommand();
            cm.CommandText = "select u.usuario as Usuario, u.Contraseña as Contraseña, u.TIPO_USUARIO as [Tipo de usuario] from Usuarios u Order by u.TIPO_USUARIO asc";
            SqlDataReader dr = cm.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dr.Close();
            c.CerrarConexion();
            dgvUsuario.DataSource = dt;
        
        }

        private void dgvUsuario_SelectionChanged(object sender, EventArgs e)
        {
            cargaAmbos();
        }

        private void rdbModificar_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbModificar.Checked==true)
            {
                btnEliminar.Enabled = true;
            }
            else
            {
                btnEliminar.Enabled = false;
            }
            limpiar();
        }
        private void limpiar()
        {
            txtusuario.Clear();
            txtcontra.Clear();
            cbusu.SelectedIndex = -1;
        }

        private void dgvUsuario_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            cargaAmbos();
        }
        private void cargaAmbos()
        {
            if (rdbModificar.Checked == true)
            {
                txtusuario.Text = dgvUsuario.CurrentRow.Cells[0].Value.ToString();
                txtcontra.Text = dgvUsuario.CurrentRow.Cells[1].Value.ToString();
                cbusu.Text = dgvUsuario.CurrentRow.Cells[2].Value.ToString();
            }
        }
        
        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            if (rdbUsuario.Checked==true)
            {
                consultar(0, txtBuscar.Text.Trim());
            }
            else
            {
                consultar(1, txtBuscar.Text.Trim());
            }
        }

        private void consultar(int a,string pregunta) {
            string consulta;
           if (string.IsNullOrEmpty(pregunta))
            {
                consulta = "select u.usuario as Usuario, u.Contraseña as Contraseña, u.TIPO_USUARIO as [Tipo de usuario] from Usuarios u Order by u.TIPO_USUARIO asc";
            }
            else if (a==0)
            {
               consulta = "select u.usuario as Usuario, u.Contraseña as Contraseña, u.TIPO_USUARIO as [Tipo de usuario]  from Usuarios u where u.usuario LIKE '"+pregunta+"%' Order by u.TIPO_USUARIO asc";
            }
            else
            {
               consulta = "select u.usuario as Usuario, u.Contraseña as Contraseña, u.TIPO_USUARIO as [Tipo de usuario]  from Usuarios u where u.TIPO_USUARIO LIKE '"+pregunta+"%' Order by u.TIPO_USUARIO asc";
            }

            dgvUsuario.DataSource = ejecutame(consulta);
            
            
        }
        private DataTable ejecutame(string sql)
        {
            DataTable dt=new DataTable();
            Conexion c = new Conexion();
            c.AbrirConexion();
            SqlCommand cm = c.GetConexion.CreateCommand();
            cm.CommandText = sql;
            SqlDataReader dr = cm.ExecuteReader();
            dt.Load(dr);
            c.CerrarConexion();
            return dt;            
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvUsuario.RowCount<1)
            {
                VentanaMsjes ventana = new VentanaMsjes("GUARDAR", "Seleccione el usuario a eliminar");
                ventana.iconoPregunta.Image = global::Ej_Interfaz_Proyecto.Properties.Resources.icn_inf;
                ventana.btnAceptar.Visible = true;
                ventana.ShowDialog();

                return;
            }
            else
            {
                limpiar();                
                ejecutame("delete Usuarios where usuario='"+dgvUsuario.CurrentRow.Cells[0].Value.ToString()+"'");
                cargarInicio();
                VentanaMsjes ventana = new VentanaMsjes("Eliminación", "¡Eliminación exitosa!");
                ventana.iconoPregunta.Image = global::Ej_Interfaz_Proyecto.Properties.Resources.icn_inf;
                ventana.btnAceptar.Visible = true;
                ventana.ShowDialog();  

            }
        }

    }

}
