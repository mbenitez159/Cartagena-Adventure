using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Windows.Forms;
using Ej_Interfaz_Proyecto.Clases_1280x1024;

namespace Ej_Interfaz_Proyecto.Formularios_1280x1024
{
    public partial class FrmDetallesHorasTrabajadas : Form
    {

        SqlDataAdapter da;
        DataSet ds;
        Conexion conexion;
        SqlCommand consulta;
        int NumeroDeHoras=0;
        int RecargosNocturnos = 0;
        public FrmDetallesHorasTrabajadas()
        {
            InitializeComponent();

            conexion = new Conexion();

            conexion.AbrirConexion();

            this.BackColor = Color.FromArgb(4, 123, 117);
        }

        private void FrmDetallesHorasTrabajadas_Load(object sender, EventArgs e)
        {
            cargar_instructores();
        }


        public void cargar_instructores()
        {
            String consultasql = "";

            conexion.AbrirConexion();


            consultasql = "SELECT * FROM INSTRUCTOR";

            consulta = new SqlCommand(consultasql, conexion.GetConexion);

            da = new SqlDataAdapter(consulta);

            ds = new DataSet();

            da.Fill(ds, "INSTRUCTOR");

            CbxInstructores.DataSource = ds.Tables[0];

            CbxInstructores.DisplayMember = "NOMBRE";

            CbxInstructores.ValueMember = "ID_INSTRUCTOR";

            CbxInstructores.SelectedIndex = -1;

            CbxInstructores.Enabled = true;


        }


        public void ConsultarHorarioInstructor(String IdInstructor)
        {
            conexion = new Conexion();

            conexion.AbrirConexion();

            consulta = new SqlCommand("SELECT HORARIO.ID_HORARIO,HORARIO.PERIODO,HORARIO.DIA,AMBIENTE.NOMBRE_AMBIENTE AS AMBIENTE,HORARIO.ID_GRUPO AS NUMERO_DE_FICHA,AREAS.NOMBRE AS AREA FROM HORARIO INNER JOIN AMBIENTE ON HORARIO.ID_AMBIENTE=AMBIENTE.ID_AMBIENTE INNER JOIN AREAS ON AREAS.ID=HORARIO.ID_AREA INNER JOIN INSTRUCTOR ON HORARIO.ID_INSTRUCTOR=INSTRUCTOR.ID_INSTRUCTOR AND HORARIO.ID_INSTRUCTOR=@ID_INSTRUCTOR AND HORARIO.ESTADO='ACTUAL'", conexion.GetConexion);

            consulta.CommandType = CommandType.Text;

            consulta.Parameters.AddWithValue("@ID_INSTRUCTOR", IdInstructor);

            SqlDataReader reader = consulta.ExecuteReader();

            while (reader.Read())
            {
                int fila = 0;

                int columna = 1;

                if (Convert.ToString(reader["PERIODO"]).Equals("07:00 - 08:00"))
                {
                    fila = 0;
                    NumeroDeHoras = NumeroDeHoras + 1;

                }
                else if (Convert.ToString(reader["PERIODO"]).Equals("08:00 - 09:00"))
                {
                    fila = 1;
                    NumeroDeHoras = NumeroDeHoras + 1;
                }

                else if (Convert.ToString(reader["PERIODO"]).Equals("09:00 - 10:00"))
                {
                    fila = 2;
                    NumeroDeHoras = NumeroDeHoras + 1;
                }
                else if (Convert.ToString(reader["PERIODO"]).Equals("10:00 - 11:00"))
                {
                    fila = 3;
                    NumeroDeHoras = NumeroDeHoras + 1;
                }

                else if (Convert.ToString(reader["PERIODO"]).Equals("11:00 - 12:00"))
                {
                    fila = 4;
                    NumeroDeHoras = NumeroDeHoras + 1;
                }
                else if (Convert.ToString(reader["PERIODO"]).Equals("12:00 - 13:00"))
                {
                    fila = 5;
                    NumeroDeHoras = NumeroDeHoras + 1;
                }
                else if (Convert.ToString(reader["PERIODO"]).Equals("13:00 - 14:00"))
                {
                    fila = 6;
                    NumeroDeHoras = NumeroDeHoras + 1;
                }
                else if (Convert.ToString(reader["PERIODO"]).Equals("14:00 - 15:00"))
                {
                    fila = 7;
                    NumeroDeHoras = NumeroDeHoras + 1;
                }
                else if (Convert.ToString(reader["PERIODO"]).Equals("15:00 - 16:00"))
                {
                    fila = 8;
                    NumeroDeHoras = NumeroDeHoras + 1;
                }
                else if (Convert.ToString(reader["PERIODO"]).Equals("16:00 - 17:00"))
                {
                    fila = 9;
                    NumeroDeHoras = NumeroDeHoras + 1;
                }
                else if (Convert.ToString(reader["PERIODO"]).Equals("17:00 - 18:00"))
                {
                    fila = 10;
                    NumeroDeHoras = NumeroDeHoras + 1;
                }
                else if (Convert.ToString(reader["PERIODO"]).Equals("18:00 - 19:00"))
                {
                    fila = 11;
                    NumeroDeHoras = NumeroDeHoras + 1;
                }
                else if (Convert.ToString(reader["PERIODO"]).Equals("19:00 - 20:00"))
                {
                    fila = 12;
                    NumeroDeHoras = NumeroDeHoras + 1;
                }
                else if (Convert.ToString(reader["PERIODO"]).Equals("20:00 - 21:00"))
                {
                    fila = 13;
                    NumeroDeHoras = NumeroDeHoras + 1;
                    RecargosNocturnos = RecargosNocturnos + 1;
                    
                }
                else if (Convert.ToString(reader["PERIODO"]).Equals("21:00 - 22:00"))
                {
                    fila = 14;
                    NumeroDeHoras = NumeroDeHoras + 1;
                    RecargosNocturnos = RecargosNocturnos + 1;
                }


                if (Convert.ToString(reader["DIA"]).Equals("lunes"))
                {
                    columna = 1;

                }

                else if (Convert.ToString(reader["DIA"]).Equals("Martes"))
                {
                    columna = 2;

                }
                else if (Convert.ToString(reader["DIA"]).Equals("Miercoles"))
                {
                    columna = 3;

                }
                else if (Convert.ToString(reader["DIA"]).Equals("Jueves"))
                {
                    columna = 4;

                }
                else if (Convert.ToString(reader["DIA"]).Equals("Viernes"))
                {
                    columna = 5;

                }
                else if (Convert.ToString(reader["DIA"]).Equals("Sabado"))
                {
                    columna = 6;

                }

            }


            TxtHoras.Text = NumeroDeHoras.ToString();

        }

        private void CbxInstructores_SelectionChangeCommitted(object sender, EventArgs e)
        {
            TxtHoras.Text = "0";
            Recargos.Text = "0";
            NumeroDeHoras = 0;
            RecargosNocturnos = 0;
            
            ConsultarHorarioInstructor(CbxInstructores.GetItemText(CbxInstructores.SelectedValue));
        }

        private void pictureBox4_MouseLeave(object sender, EventArgs e)
        {
            this.pictureBox4.Image = global::Ej_Interfaz_Proyecto.Properties.Resources.btn_cer_normal2;
        }

        private void pictureBox4_MouseMove(object sender, MouseEventArgs e)
        {
            this.pictureBox4.Image = global::Ej_Interfaz_Proyecto.Properties.Resources.btn_cer_focus2;
        }
    }
}
