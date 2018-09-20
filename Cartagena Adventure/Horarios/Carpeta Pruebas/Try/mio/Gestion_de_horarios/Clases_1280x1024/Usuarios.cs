using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Ej_Interfaz_Proyecto.Formularios_1280x1024;
using System.Drawing;
using System.Windows.Forms;
namespace Ej_Interfaz_Proyecto.Clases_1280x1024
{
    class Usuarios
    {
        internal String tipo_usuario;
        FrmPrincipal_1280x1024 acceso;
        FrmInicioSesion_1280x1024 inicio;
        FrmConsultarHorario_1280x1024 fc;
        public Usuarios(FrmPrincipal_1280x1024 acceso, FrmInicioSesion_1280x1024 inicio)
        {
            this.inicio = inicio;
            this.acceso = acceso;
        }
        public void setTipoUsuario(string tipo_usuario)
        {
            this.tipo_usuario = tipo_usuario;
        }

        public string getTipoUusario()
        {
            return tipo_usuario;
        }

        public bool VerificarUsuario(string nombre, string contraseña)
        {
            string SQL = "select top 1 * from Usuarios where usuario = @nomb and Contraseña = @cont ";
            Conexion con = null;
            
            bool busqueda = false;

            try
            {
                con = new Conexion();
                con.AbrirConexion();

                SqlCommand cmd = new SqlCommand(SQL, con.GetConexion);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@nomb", nombre);
                cmd.Parameters.AddWithValue("@cont", contraseña);
                //cmd.Parameters.AddWithValue("@tipousu",tipo);

                //return true;
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    busqueda = true;
                    nombre = Convert.ToString(reader["usuario"]);
                    contraseña = Convert.ToString(reader["contraseña"]);
                    tipo_usuario = Convert.ToString(reader["TIPO_USUARIO"]);

                    if (tipo_usuario.Equals("Administrador"))
                    {

                    acceso.Habilitar();
                    inicio.Close();
                    acceso.cerrar_sesion.Visible = true;
                    acceso.cerrar_sesion.Text = tipo_usuario+" | Cerrar Sesión";
                    acceso.cerrar_sesion.Location = new System.Drawing.Point((acceso.Size.Width - 11) - acceso.cerrar_sesion.Size.Width, 78);

                    }
                    else if (tipo_usuario.Equals("Coordinador"))
                    {

                        acceso.HabilitarC();
                        inicio.Close();
                        acceso.cerrar_sesion.Visible = true;
                        acceso.cerrar_sesion.Text = tipo_usuario + " | Cerrar Sesión";
                        acceso.cerrar_sesion.Location = new System.Drawing.Point((acceso.Size.Width - 11) - acceso.cerrar_sesion.Size.Width, 78);

                    }
                    else if (tipo_usuario.Equals("Visor"))
                    {

                         inicio.Close();
                        acceso.cerrar_sesion.Visible = true;
                        acceso.cerrar_sesion.Text = tipo_usuario + " | Cerrar Sesión";
                        acceso.cerrar_sesion.Location = new System.Drawing.Point((acceso.Size.Width - 11) - acceso.cerrar_sesion.Size.Width, 78);
                        fc = new FrmConsultarHorario_1280x1024("",acceso);
                        fc.Show();

                    }
                }

            }
            catch (Exception ex)
            {
                 System.Windows.Forms.MessageBox.Show(ex.Message);
            }
            finally
            {
                con.CerrarConexion();
            }
            return busqueda;
        }
        
    }
}
