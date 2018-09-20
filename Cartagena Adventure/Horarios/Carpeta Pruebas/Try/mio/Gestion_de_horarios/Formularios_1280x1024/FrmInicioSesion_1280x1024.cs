using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using Ej_Interfaz_Proyecto.Clases_1280x1024;
using Ej_Interfaz_Proyecto.Formularios_1280x1024;

namespace Ej_Interfaz_Proyecto.Formularios_1280x1024
{
    public partial class FrmInicioSesion_1280x1024 : Form
    {
        FrmPrincipal_1280x1024 principal;
        Boolean contraseña = false;
     
        // Declaraciones del API PARA MOVER EL FORMULARIO
        [System.Runtime.InteropServices.DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        //
        [System.Runtime.InteropServices.DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        public FrmInicioSesion_1280x1024(FrmPrincipal_1280x1024 principal)
        {
            InitializeComponent();
            this.principal = principal;
        }

        private void FrmInicioSesionN_Load(object sender, EventArgs e)
        {
            this.ActiveControl = Entrar;       
            
            this.BackColor = Color.FromArgb(228, 234, 234);
            this.pictureBox2.BackColor = Color.FromArgb(228, 234, 234);
            this.Texto.ForeColor = Color.FromArgb(4, 123, 117);
            this.Contraseña.BackColor = Color.FromArgb(228, 234, 234);
            this.NombreUsuario.BackColor = Color.FromArgb(228, 234, 234);
            this.Entrar.ForeColor = Color.FromArgb(4, 123, 117);
            this.label1.ForeColor = Color.FromArgb(228, 234, 234);
            this.label2.ForeColor = Color.FromArgb(228, 234, 234);
            this.NombreUsuario.ForeColor = Color.FromArgb(128, 128, 128);
            this.Contraseña.ForeColor = Color.FromArgb(128, 128, 128);
            this.Entrar.Focus();

            

  

        }

        private void Cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    
     

        private void Cerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void NombreUsuario_Enter(object sender, EventArgs e)
        {
            this.ImgUsuario.Image = global::Ej_Interfaz_Proyecto.Properties.Resources.icn_use_focus;

            if (NombreUsuario.Text.Equals("Nombre de usuario"))
            {
                NombreUsuario.Text = "";
                
            }           
            
            this.NombreUsuario.ForeColor = Color.FromArgb(4, 123, 117);
        }

        private void Contraseña_Enter(object sender, EventArgs e)
        {
            this.ImgContraseña.Image = global::Ej_Interfaz_Proyecto.Properties.Resources.icn_can_focus;

            if (Contraseña.Text.Equals("Contraseña"))
            {

                Contraseña.Text = "";
            }


            this.Contraseña.UseSystemPasswordChar = true; 

            this.Contraseña.ForeColor = Color.FromArgb(4, 123, 117);
           
           
        }

        private void NombreUsuario_Leave(object sender, EventArgs e)
        {
            this.ImgUsuario.Image = global::Ej_Interfaz_Proyecto.Properties.Resources.icn_use_normal;
            
            
            if(NombreUsuario.Text.Equals(""))
            {
                NombreUsuario.Text = "Nombre de usuario";
                this.NombreUsuario.ForeColor = Color.FromArgb(128, 128, 128);


            }
         

        }

        private void Contraseña_Leave(object sender, EventArgs e)
        {
            this.ImgContraseña.Image = global::Ej_Interfaz_Proyecto.Properties.Resources.icn_can_normal;


            if (Contraseña.Text.Equals(""))
            {
                Contraseña.Text = "Contraseña";
                this.Contraseña.UseSystemPasswordChar = false; 
                this.Contraseña.ForeColor = Color.FromArgb(128, 128, 128);


            }
        }

        private void FrmInicioSesionN_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void Entrar_Click(object sender, EventArgs e)
        {
            //entrar sin user ni contraseña
            //NombreUsuario.Text = "admin";
            //Contraseña.Text = "12345";
            //
            if (NombreUsuario.Text != "Nombre de usuario")
            {
                if (verificar_usuario(NombreUsuario.Text)== true)
                {
                
                if (Contraseña.Text != "Contraseña")
                {
                    verificar_usuario(NombreUsuario.Text);

                    if (contraseña == true)
                    {

                        new Usuarios(principal, this).VerificarUsuario(NombreUsuario.Text, Contraseña.Text);


                    }

                    else
                    {

                        label1.Visible = false;
                        label2.Visible = true;
                        label2.Location = new System.Drawing.Point(342, 160);
                        Contraseña.Text = "";
                        Contraseña.Focus();
                        label2.Text = "Contraseña" + Environment.NewLine + "incorrecta";


                    }        

                }

                else
                {
                    label1.Visible = false;
                    label2.Visible = true;
                    label2.Location = new System.Drawing.Point(342, 160);
                    Contraseña.Text = "";
                    Contraseña.Focus();
                    label2.Text = "Por Favor ingrese una" + Environment.NewLine + "contraseña";
                }


                }
                else
                {
                    label2.Visible = false;             
                    label1.Visible = true;
                    label1.Location = new System.Drawing.Point(342, 102);
                    NombreUsuario.Text = "";
                    NombreUsuario.Focus();
                    Contraseña.Text = "Contraseña";
                    this.Contraseña.UseSystemPasswordChar = false; 
                    Contraseña.ForeColor = Color.FromArgb(128, 128, 128);
                    label1.Text = "Nombre de usuario" + Environment.NewLine + "incorrecto";
                }

                
                
            }
            else
            {
                label2.Visible = false;
                label1.Visible = true;
                label1.Location = new System.Drawing.Point(342, 102);
                NombreUsuario.Text = "";
                NombreUsuario.Focus();
                label1.Text = "Por Favor ingrese un" + Environment.NewLine + "nombre de usuario";


            }
           
        }

        private void NombreUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            label1.Visible = false;
            label2.Visible = false;
        }

        private void Contraseña_KeyPress(object sender, KeyPressEventArgs e)
        {
            label1.Visible = false;
            label2.Visible = false;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        public Boolean verificar_usuario(string nombre_usuario)
        {
            Boolean encontrado = false;
            contraseña=false;
            Conexion con = null;
            

            string SQL = "select * from Usuarios where usuario = @nomb";
            try
            {

            con = new Conexion();
            con.AbrirConexion();

            SqlCommand cmd = new SqlCommand(SQL, con.GetConexion);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@nomb", nombre_usuario);

            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                encontrado = true;

                if (Convert.ToString(reader["contraseña"]).Equals(Contraseña.Text))
                {

                contraseña = true;

                }

            }
            }

            catch (Exception ex)
            {
                VentanaMsjes ventana2 = new VentanaMsjes("ERROR", ex.Message);
                ventana2.iconoPregunta.Image = global::Ej_Interfaz_Proyecto.Properties.Resources.icn_err;
                ventana2.btnAceptar.Visible = true;
                ventana2.ShowDialog();
            }
            finally
            {
                con.CerrarConexion();
            }


            return encontrado;

        }

      

       
    }
}
