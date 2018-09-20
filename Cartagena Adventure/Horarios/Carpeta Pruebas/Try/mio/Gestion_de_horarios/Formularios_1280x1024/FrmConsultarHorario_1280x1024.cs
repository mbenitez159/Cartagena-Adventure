using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;
using Ej_Interfaz_Proyecto.Clases_1280x1024;
using Microsoft.Office.Interop.Excel;

namespace Ej_Interfaz_Proyecto.Formularios_1280x1024
{
    public partial class FrmConsultarHorario_1280x1024 : Form
    {

        // Declaraciones del API PARA MOVER EL FORMULARIO
        [System.Runtime.InteropServices.DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        //
        [System.Runtime.InteropServices.DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        SqlDataAdapter da;
        DataSet ds;
        Conexion conexion;
        SqlCommand consulta;
        SqlCommand consulta2;
        int columna = 0;
        int fila = 0;
        String tipo = "";
        int tipo1 = 3;
        string id;
        string Jornada="";
        string resultadoencontrado = "no";
        FrmPrincipal_1280x1024 principal;
        SqlDataReader reader2;
        int[,] ID_HORARIO = new int[15, 7];

        
        public FrmConsultarHorario_1280x1024(String IdInstructor, FrmPrincipal_1280x1024 principal)
        {
            InitializeComponent();

            //cargar_rangos();

            //dataGridViewActivado();

            //conexion = new Conexion();

            //conexion.AbrirConexion();

            //cargar_instructores();

             tipo = "Instructor";
             tipo1 = 1;

            ////CargarHorarioInstructor(IdInstructor, tipo);

            //LimpiarSeleccion();

            //this.BackColor = Color.FromArgb(4, 123, 117);

            this.principal = principal;

        }

        public void CargarHorarioInstructor(String IdInstructor,String Tip)
        {
           dataGridView1.Rows.Clear();    
            cargar_rangos();
          
            conexion = new Conexion();

            conexion.AbrirConexion();
            
            if(Tip.Equals("Instructor")){

                consulta = new SqlCommand("SELECT HORARIO.ID_HORARIO,HORARIO.PERIODO,HORARIO.DIA,AMBIENTE.NOMBRE_AMBIENTE AS AMBIENTE,HORARIO.ID_GRUPO AS NUMERO_DE_FICHA,AREAS.NOMBRE AS AREA,HORARIO.[TRIMESTRE_ANIO] FROM HORARIO INNER JOIN AMBIENTE ON HORARIO.ID_AMBIENTE=AMBIENTE.ID_AMBIENTE INNER JOIN AREAS ON AREAS.ID=HORARIO.ID_AREA INNER JOIN INSTRUCTOR ON HORARIO.ID_INSTRUCTOR=INSTRUCTOR.ID_INSTRUCTOR AND HORARIO.ID_INSTRUCTOR=@ID_INSTRUCTOR AND HORARIO.ESTADO='ACTUAL' AND HORARIO.[TRIMESTRE_ANIO]='" + comboBox1.Text + "' ", conexion.GetConexion);

                consulta.CommandType = CommandType.Text;
                consulta.Parameters.AddWithValue("@ID_INSTRUCTOR", IdInstructor);

            }
            else if (Tip.Equals("Ambiente"))
            {
                consulta = new SqlCommand("SELECT HORARIO.ID_HORARIO,HORARIO.PERIODO,INSTRUCTOR.NOMBRE AS INSTRUCTOR,HORARIO.DIA,HORARIO.ID_GRUPO AS NUMERO_DE_FICHA,HORARIO.[TRIMESTRE_ANIO] FROM HORARIO INNER JOIN AMBIENTE ON HORARIO.ID_AMBIENTE=AMBIENTE.ID_AMBIENTE AND HORARIO.ID_AMBIENTE=@ID_AMBIENTE AND HORARIO.ESTADO='ACTUAL' INNER JOIN INSTRUCTOR ON HORARIO.ID_INSTRUCTOR=INSTRUCTOR.ID_INSTRUCTOR AND HORARIO.[TRIMESTRE_ANIO]='" + comboBox1.Text + "' ", conexion.GetConexion);

                 consulta.CommandType = CommandType.Text;

                 consulta.Parameters.AddWithValue("@ID_AMBIENTE", id);

            }
            else if (Tip.Equals("Grupo"))
            {
                consulta = new SqlCommand("SELECT HORARIO.ID_HORARIO,HORARIO.PERIODO,HORARIO.DIA,AMBIENTE.NOMBRE_AMBIENTE AS AMBIENTE,AREAS.NOMBRE AS AREA,INSTRUCTOR.NOMBRE AS INSTRUCTOR,HORARIO.[TRIMESTRE_ANIO] FROM HORARIO INNER JOIN AMBIENTE ON HORARIO.ID_AMBIENTE=AMBIENTE.ID_AMBIENTE INNER JOIN AREAS ON AREAS.ID=HORARIO.ID_AREA INNER JOIN INSTRUCTOR ON HORARIO.ID_INSTRUCTOR=INSTRUCTOR.ID_INSTRUCTOR AND HORARIO.ID_GRUPO=@ID_GRUPO AND HORARIO.ESTADO='ACTUAL' AND HORARIO.[TRIMESTRE_ANIO]='" + comboBox1.Text + "' ", conexion.GetConexion);

                consulta.CommandType = CommandType.Text;

                consulta.Parameters.AddWithValue("@ID_GRUPO",id);
                
            }

           
            SqlDataReader reader = consulta.ExecuteReader();
          //  MessageBox.Show("voi a while");
            while (reader.Read())
            {
             //   MessageBox.Show("EN while");
                int fila = 0;

                int columna = 1;

                if (Convert.ToString(reader["PERIODO"]).Equals("06:00 - 07:00"))
                {
                    fila = 0;

                }
                if (Convert.ToString(reader["PERIODO"]).Equals("07:00 - 08:00"))
                {
                    fila = 1;

                }
                else if (Convert.ToString(reader["PERIODO"]).Equals("08:00 - 09:00"))
                {
                    fila = 2;
                }

                else if (Convert.ToString(reader["PERIODO"]).Equals("09:00 - 10:00"))
                {
                    fila = 3;
                }
                else if (Convert.ToString(reader["PERIODO"]).Equals("10:00 - 11:00"))
                {
                    fila = 4;
                }

                else if (Convert.ToString(reader["PERIODO"]).Equals("11:00 - 12:00"))
                {
                    fila = 5;
                }
                else if (Convert.ToString(reader["PERIODO"]).Equals("12:00 - 13:00"))
                {
                    fila = 6;
                }
                else if (Convert.ToString(reader["PERIODO"]).Equals("13:00 - 14:00"))
                {
                    fila = 7;
                }
                else if (Convert.ToString(reader["PERIODO"]).Equals("14:00 - 15:00"))
                {
                    fila = 8;
                }
                else if (Convert.ToString(reader["PERIODO"]).Equals("15:00 - 16:00"))
                {
                    fila = 9;
                }
                else if (Convert.ToString(reader["PERIODO"]).Equals("16:00 - 17:00"))
                {
                    fila = 10;
                }
                else if (Convert.ToString(reader["PERIODO"]).Equals("17:00 - 18:00"))
                {
                    fila = 11;
                }
                else if (Convert.ToString(reader["PERIODO"]).Equals("18:00 - 19:00"))
                {
                    fila = 12;
                }
                else if (Convert.ToString(reader["PERIODO"]).Equals("19:00 - 20:00"))
                {
                    fila = 13;
                }
                else if (Convert.ToString(reader["PERIODO"]).Equals("20:00 - 21:00"))
                {
                    fila = 14;
                }
                else if (Convert.ToString(reader["PERIODO"]).Equals("21:00 - 22:00"))
                {
                    fila = 15;
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
               // MessageBox.Show(  " JEIICOR [ "+fila+"]---["+columna);
               if (reader["TRIMESTRE_ANIO"].ToString().Equals(comboBox1.Text))//SI =A A TRIMESTRE SELECCIONADO
                {
                 //   MessageBox.Show("ya  voisa lista");

                    if (Tip.Equals("Instructor"))
                    {
                        ID_HORARIO[fila, columna] = Convert.ToInt16(reader["ID_HORARIO"]);
                        dataGridView1.Rows[fila].Cells[columna].Value = "Área: " + Convert.ToString(reader["AREA"]) + Environment.NewLine + Convert.ToString(reader["AMBIENTE"]) + Environment.NewLine + "Numero De Ficha: " + Convert.ToString(reader["NUMERO_DE_FICHA"]);
                        ID_HORARIO[fila, columna] = Convert.ToInt16(reader["ID_HORARIO"]);

                    }
                    else if (Tip.Equals("Ambiente"))
                    {

                        dataGridView1.Rows[fila].Cells[columna].Value = "Grupo: " + Convert.ToString(reader["NUMERO_DE_FICHA"]) + Environment.NewLine + "INSTRUCTOR: " + Convert.ToString(reader["INSTRUCTOR"]);
                        ID_HORARIO[fila, columna] = Convert.ToInt16(reader["ID_HORARIO"]);
                    }

                    else if (Tip.Equals("Grupo"))
                    {

                        dataGridView1.Rows[fila].Cells[columna].Value = "Área: " + Convert.ToString(reader["AREA"]) + Environment.NewLine + Convert.ToString(reader["AMBIENTE"]) + Environment.NewLine + "INSTRUCTOR: " + Convert.ToString(reader["INSTRUCTOR"]);
                        ID_HORARIO[fila, columna] = Convert.ToInt16(reader["ID_HORARIO"]);
                    }

                }//IF = TRIMESTRE A MOSTRAR
                dataGridView1.Rows[fila].Cells[columna].Style.ForeColor = Color.Black;
                dataGridView1.Rows[fila].Cells[columna].Style.BackColor = Color.FromArgb(4, 123, 117);
                }
                
                reader.Close();

         

                for (int i = 0; i < 15; i++)
                {
                    for (int x = 0; x < 7; x++)
                    {
                       
                        if (ID_HORARIO[i, x]!=0)
                        {
                                resultadoencontrado = "no";

                                conexion.AbrirConexion();    

                               // consulta = new SqlCommand("SELECT DESCRIPCION_RESULTADO_TRANSVERSAL FROM RESULTADOS_PROGRAMADOS,RESULTADOS_TRANSVERSALES,HORARIO WHERE RESULTADOS_PROGRAMADOS.ID_HORARIO=HORARIO.ID_HORARIO AND HORARIO.ID_HORARIO=@ID_HORARIO AND RESULTADOS_PROGRAMADOS.ID_RESULTADO_TRANSVERSAL=RESULTADOS_TRANSVERSALES.ID_RESULTADO_TRANSVERSAL AND RESULTADOS_PROGRAMADOS.ID_RESULTADO_TRANSVERSAL IS NOT NULL AND HORARIO.ESTADO='ACTUAL'", conexion.GetConexion);
                                String csl = "SELECT DESCRIPCION FROM TIEMPO_RESULTADOS,RESULTADOS,HORARIO WHERE TIEMPO_RESULTADOS.ID_RESULTADO=HORARIO.ID_RESULTADO AND HORARIO.ID_HORARIO=@ID_HORARIO  AND " +
                                             "TIEMPO_RESULTADOS.ID_RESULTADO=RESULTADOS.ID AND TIEMPO_RESULTADOS.ID_RESULTADO IS NOT NULL AND HORARIO.ESTADO='ACTUAL'";

                                consulta = new SqlCommand(csl, conexion.GetConexion);
                               


                                consulta.CommandType = CommandType.Text;

                                consulta.Parameters.AddWithValue("@ID_HORARIO", ID_HORARIO[i, x]);

                                reader2 = consulta.ExecuteReader();

                                if (reader2.Read())
                                {
                                    if (reader2["DESCRIPCION"] != null)
                                    {

                                        //dataGridView1.Rows[i].Cells[x].Value = dataGridView1.Rows[i].Cells[x].Value + "Resultado Transversal"+ Environment.NewLine + Convert.ToString(reader2["DESCRIPCION"]);

                                        resultadoencontrado = "si";

                                    }

                                }

                                reader2.Close();

                                if (resultadoencontrado.Equals("no"))
                                {

                                    consulta2 = new SqlCommand("SELECT DESCRIPCION FROM TIEMPO_RESULTADOS ,RESULTADOS,HORARIO WHERE TIEMPO_RESULTADOS.ID_GRUPO=HORARIO.ID_GRUPO AND HORARIO.ID_HORARIO=@ID_HORARIO2 AND TIEMPO_RESULTADOS.ID_RESULTADO=RESULTADOS.ID AND TIEMPO_RESULTADOS.ID_RESULTADO IS NOT NULL AND HORARIO.ESTADO='ACTUAL'", conexion.GetConexion);

                                    consulta2.CommandType = CommandType.Text;

                                    consulta2.Parameters.AddWithValue("@ID_HORARIO2", ID_HORARIO[i, x]);

                                    reader2 = consulta2.ExecuteReader();

                                    if (reader2.Read())
                                    {

                                        dataGridView1.Rows[i].Cells[x].Value = dataGridView1.Rows[i].Cells[x].Value + Environment.NewLine + "Resultado Tecnico" + Environment.NewLine + Convert.ToString(reader2["DESCRIPCION"]);

                                      
                                    }

                                    reader2.Close();
                            }
                        }

                    }
                }
                
            
        }

        public void dataGridViewActivado()
        {
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                for (int x = 1; x <= 6; x++)
                {

                    dataGridView1.Rows[i].Cells[x].Style.BackColor = Color.White;
                    dataGridView1.Rows[i].Cells[x].Style.SelectionBackColor = Color.White;
                    dataGridView1.Rows[i].Cells[x].Style.ForeColor = Color.Black;
                    dataGridView1.Rows[i].Cells[x].Style.SelectionForeColor = Color.White;
                }

            }


        }

        private void LimpiarSeleccion()
        {
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                dataGridView1.Rows[i].Selected = false;
            }
        }

        public void cargar_rangos()
        {
            this.dataGridView1.Rows.Add("06:00 - 07:00");
            this.dataGridView1.Rows.Add("07:00 - 08:00");
            this.dataGridView1.Rows.Add("08:00 - 09:00");
            this.dataGridView1.Rows.Add("09:00 - 10:00");
            this.dataGridView1.Rows.Add("10:00 - 11:00");
            this.dataGridView1.Rows.Add("11:00 - 12:00");
            this.dataGridView1.Rows.Add("12:00 - 13:00");
            this.dataGridView1.Rows.Add("13:00 - 14:00");
            this.dataGridView1.Rows.Add("14:00 - 15:00");
            this.dataGridView1.Rows.Add("15:00 - 16:00");
            this.dataGridView1.Rows.Add("16:00 - 17:00");
            this.dataGridView1.Rows.Add("17:00 - 18:00");
            this.dataGridView1.Rows.Add("18:00 - 19:00");
            this.dataGridView1.Rows.Add("19:00 - 20:00");
            this.dataGridView1.Rows.Add("20:00 - 21:00");
            this.dataGridView1.Rows.Add("21:00 - 22:00");


        }

             
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (this.columna > 0 && this.fila >= 0)
            {

                if (dataGridView1.Rows[this.fila].Cells[this.columna].Value != null)
                {

                    FrmDetallesHorario_1280x1024 detalle = new FrmDetallesHorario_1280x1024(ID_HORARIO[this.fila,this.columna].ToString());
                    detalle.MdiParent = principal;
                    detalle.Show();
                }

            }
        }

        private void dataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                this.columna = e.ColumnIndex;
                this.fila = e.RowIndex;
             }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
         }

        private void BtnAmbiente_MouseLeave(object sender, EventArgs e)
        {
            this.BtnAmbiente.Image = global::Ej_Interfaz_Proyecto.Properties.Resources.btn_amb_normal2;
            this.label6.Text = "CONSULTAR HORARIOS";
            int centro = (this.Size.Width) / 2;
            this.label6.Location = new System.Drawing.Point(centro - (label6.Size.Width / 2), 10);
        }

        private void BtnAmbiente_MouseMove(object sender, MouseEventArgs e)
        {
            this.BtnAmbiente.Image = global::Ej_Interfaz_Proyecto.Properties.Resources.btn_amb_focus2;
            this.label6.Text = "CONSULTAR HORARIOS | AMBIENTES";
            int centro = (this.Size.Width) / 2;
            this.label6.Location = new System.Drawing.Point(centro - (label6.Size.Width / 2), 10);
        }

        private void BtnInstructor_MouseLeave(object sender, EventArgs e)
        {
            this.BtnInstructor.Image = global::Ej_Interfaz_Proyecto.Properties.Resources.bt_ins_normal2;
            this.label6.Text = "CONSULTAR HORARIOS";
            int centro = (this.Size.Width) / 2;
            this.label6.Location = new System.Drawing.Point(centro - (label6.Size.Width / 2), 10);
        }

        private void BtnInstructor_MouseMove(object sender, MouseEventArgs e)
        {
            this.BtnInstructor.Image = global::Ej_Interfaz_Proyecto.Properties.Resources.bt_ins_focus2;
            this.label6.Text = "CONSULTAR HORARIOS | INSTRUCTORES";
            int centro = (this.Size.Width) / 2;
            this.label6.Location = new System.Drawing.Point(centro - (label6.Size.Width / 2), 10);
        }

        private void BtnAreas_MouseLeave(object sender, EventArgs e)
        {
            this.BtnAreas.Image = global::Ej_Interfaz_Proyecto.Properties.Resources.btn_gru_normal;
            this.label6.Text = "CONSULTAR HORARIOS";
            int centro = (this.Size.Width) / 2;
            this.label6.Location = new System.Drawing.Point(centro - (label6.Size.Width / 2), 10);
        }

        private void BtnAreas_MouseMove(object sender, MouseEventArgs e)
        {
            this.BtnAreas.Image = global::Ej_Interfaz_Proyecto.Properties.Resources.btn_gru_focus;
            this.label6.Text = "CONSULTAR HORARIOS | GRUPOS";
            int centro = (this.Size.Width) / 2;
            this.label6.Location = new System.Drawing.Point(centro - (label6.Size.Width / 2), 10);
        }

     

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void reload1()
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                for (int i = 1; i < dataGridView1.ColumnCount; i++)
                {
                    row.Cells[i].Value = "";
                }
            }

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            //WindowState = FormWindowState.Minimized;
        }

        private void BtnAmbiente_Click(object sender, EventArgs e)
        {
            dataGridViewActivado();
            tipo = "Ambiente";
            tipo1 = 3;
            reload1();
        }

        private void BtnInstructor_Click(object sender, EventArgs e)
        {
            dataGridViewActivado();
            tipo = "Instructor";
            tipo1 = 1;
            reload1();
        }

        private void BtnAreas_Click(object sender, EventArgs e)
        {
            dataGridViewActivado();
            tipo = "Grupo";
            tipo1 = 2;
            reload1();
        }


        private void pictureBox3_MouseLeave(object sender, EventArgs e)
        {
           // this.pictureBox3.Image = global::Ej_Interfaz_Proyecto.Properties.Resources.btn_min_normal2;
        }

        private void pictureBox3_MouseMove(object sender, MouseEventArgs e)
        {
            //this.pictureBox3.Image = global::Ej_Interfaz_Proyecto.Properties.Resources.btn_min_focus2;
        }

        private void pictureBox4_MouseLeave(object sender, EventArgs e)
        {
            this.pictureBox4.Image = global::Ej_Interfaz_Proyecto.Properties.Resources.btn_cer_normal2;
        }

        private void pictureBox4_MouseMove(object sender, MouseEventArgs e)
        {
            this.pictureBox4.Image = global::Ej_Interfaz_Proyecto.Properties.Resources.btn_cer_focus2;
        }

        private void eToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.columna > 0 && this.fila >= 0)
            {

                if (dataGridView1.Rows[this.fila].Cells[this.columna].Value!=null)
                {
                    VentanaMsjes ventana = new VentanaMsjes("ELIMINAR", "¿Confirma eliminar el horario?");
                    ventana.btnSi.Visible = true;
                    ventana.btnNo.Visible = true;
                    ventana.iconoPregunta.Image = global::Ej_Interfaz_Proyecto.Properties.Resources.icn_pre;
                    DialogResult msgdresult = ventana.ShowDialog();

                    if (msgdresult.ToString().Equals("OK"))
                    {

                        Eliminar(ID_HORARIO[this.fila, this.columna].ToString());

                        dataGridView1.Rows[this.fila].Cells[this.columna].Style.BackColor = Color.White;
                
                        dataGridView1.Rows[this.fila].Cells[this.columna].Style.ForeColor = Color.White;
               
                        dataGridView1.Rows[this.fila].Cells[this.columna].Value = null;

                        dataGridViewActivado();

                        CargarHorarioInstructor(id, tipo);

                        LimpiarSeleccion();

                        for (int i = 0; i < dataGridView1.Columns.Count; i++)
                        {
                            dataGridView1.Columns[i].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                            dataGridView1.Columns[i].Width = 150;
                        }

                        for (int i = 0; i < dataGridView1.RowCount; i++)
                        {
                            dataGridView1.Rows[i].Height = 180;
                        }


                        VentanaMsjes ventana2 = new VentanaMsjes("ELIMINAR", "Eliminación exitosa");
                        ventana2.iconoPregunta.Image = global::Ej_Interfaz_Proyecto.Properties.Resources.icn_inf;
                        ventana2.btnAceptar.Visible = true;
                        ventana2.ShowDialog();
                    }

                }

            }
        }

        public void Eliminar(string ID_HORARIO)
        {
            string SQL = "DELETE  HORARIO  WHERE ID_HORARIO=@ID";
            Conexion conexion = new Conexion();
            try
            {
                conexion.AbrirConexion();
                SqlCommand cmdConsulta = new SqlCommand(SQL, conexion.GetConexion);
                cmdConsulta.Parameters.AddWithValue("@ID", ID_HORARIO);

                cmdConsulta.ExecuteNonQuery();

                cmdConsulta.Parameters.Clear();
                cmdConsulta.Dispose();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            finally
            {
                conexion.CerrarConexion();
            }
        }


        //REPORTE EN EXCEL
        public void exporta_a_excel()
        {

            Microsoft.Office.Interop.Excel.ApplicationClass excel = new Microsoft.Office.Interop.Excel.ApplicationClass();

            excel.Application.Workbooks.Add(true);

            int ColumnIndex = 0;

            //excel.Cells[1, 1] = "INSTRUCTOR: "+CbxInstructores.Text;

            excel.get_Range("A4", "G4").Font.Bold = true; //Letra negrita
            excel.get_Range("A4", "A17").Font.Bold = true; //Letra negrita
            excel.get_Range("A4", "G4").Interior.ColorIndex = 10; //Color de Fondo, 9 es rojo oscuro, 
            excel.get_Range("A4", "A17").Interior.ColorIndex = 10; //Color de Fondo, 9 es rojo oscuro, 

            //excel.get_Range("A1", "G1").Font.ColorIndex = 2; //Color de letra, 2 es blanco, entre 0-56
            //excel.get_Range("A1", "A14").Font.ColorIndex = 2; //Color de letra, 2 es blanco, entre 0-56

            excel.get_Range("A4", "G4").ColumnWidth = 25; //Ancho de la columna

            excel.get_Range("A4", "G4").BorderAround(Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous, Microsoft.Office.Interop.Excel.XlBorderWeight.xlMedium, Microsoft.Office.Interop.Excel.XlColorIndex.xlColorIndexAutomatic, Microsoft.Office.Interop.Excel.XlColorIndex.xlColorIndexAutomatic); //Borde
            excel.get_Range("A5", "G5").BorderAround(Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous, Microsoft.Office.Interop.Excel.XlBorderWeight.xlMedium, Microsoft.Office.Interop.Excel.XlColorIndex.xlColorIndexAutomatic, Microsoft.Office.Interop.Excel.XlColorIndex.xlColorIndexAutomatic); //Borde
            excel.get_Range("A6", "G6").BorderAround(Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous, Microsoft.Office.Interop.Excel.XlBorderWeight.xlMedium, Microsoft.Office.Interop.Excel.XlColorIndex.xlColorIndexAutomatic, Microsoft.Office.Interop.Excel.XlColorIndex.xlColorIndexAutomatic); //Borde
            excel.get_Range("A7", "G7").BorderAround(Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous, Microsoft.Office.Interop.Excel.XlBorderWeight.xlMedium, Microsoft.Office.Interop.Excel.XlColorIndex.xlColorIndexAutomatic, Microsoft.Office.Interop.Excel.XlColorIndex.xlColorIndexAutomatic); //Borde
            excel.get_Range("A8", "G8").BorderAround(Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous, Microsoft.Office.Interop.Excel.XlBorderWeight.xlMedium, Microsoft.Office.Interop.Excel.XlColorIndex.xlColorIndexAutomatic, Microsoft.Office.Interop.Excel.XlColorIndex.xlColorIndexAutomatic); //Borde
            excel.get_Range("A9", "G9").BorderAround(Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous, Microsoft.Office.Interop.Excel.XlBorderWeight.xlMedium, Microsoft.Office.Interop.Excel.XlColorIndex.xlColorIndexAutomatic, Microsoft.Office.Interop.Excel.XlColorIndex.xlColorIndexAutomatic); //Borde
            excel.get_Range("A10", "G10").BorderAround(Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous, Microsoft.Office.Interop.Excel.XlBorderWeight.xlMedium, Microsoft.Office.Interop.Excel.XlColorIndex.xlColorIndexAutomatic, Microsoft.Office.Interop.Excel.XlColorIndex.xlColorIndexAutomatic); //Borde
            excel.get_Range("A11", "G11").BorderAround(Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous, Microsoft.Office.Interop.Excel.XlBorderWeight.xlMedium, Microsoft.Office.Interop.Excel.XlColorIndex.xlColorIndexAutomatic, Microsoft.Office.Interop.Excel.XlColorIndex.xlColorIndexAutomatic); //Borde
            excel.get_Range("A12", "G12").BorderAround(Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous, Microsoft.Office.Interop.Excel.XlBorderWeight.xlMedium, Microsoft.Office.Interop.Excel.XlColorIndex.xlColorIndexAutomatic, Microsoft.Office.Interop.Excel.XlColorIndex.xlColorIndexAutomatic); //Borde
            excel.get_Range("A13", "G13").BorderAround(Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous, Microsoft.Office.Interop.Excel.XlBorderWeight.xlMedium, Microsoft.Office.Interop.Excel.XlColorIndex.xlColorIndexAutomatic, Microsoft.Office.Interop.Excel.XlColorIndex.xlColorIndexAutomatic); //Borde
            excel.get_Range("A14", "G14").BorderAround(Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous, Microsoft.Office.Interop.Excel.XlBorderWeight.xlMedium, Microsoft.Office.Interop.Excel.XlColorIndex.xlColorIndexAutomatic, Microsoft.Office.Interop.Excel.XlColorIndex.xlColorIndexAutomatic); //Borde
            excel.get_Range("A15", "G15").BorderAround(Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous, Microsoft.Office.Interop.Excel.XlBorderWeight.xlMedium, Microsoft.Office.Interop.Excel.XlColorIndex.xlColorIndexAutomatic, Microsoft.Office.Interop.Excel.XlColorIndex.xlColorIndexAutomatic); //Borde
            excel.get_Range("A16", "G16").BorderAround(Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous, Microsoft.Office.Interop.Excel.XlBorderWeight.xlMedium, Microsoft.Office.Interop.Excel.XlColorIndex.xlColorIndexAutomatic, Microsoft.Office.Interop.Excel.XlColorIndex.xlColorIndexAutomatic); //Borde
            excel.get_Range("A17", "G17").BorderAround(Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous, Microsoft.Office.Interop.Excel.XlBorderWeight.xlMedium, Microsoft.Office.Interop.Excel.XlColorIndex.xlColorIndexAutomatic, Microsoft.Office.Interop.Excel.XlColorIndex.xlColorIndexAutomatic); //Borde
            excel.get_Range("A18", "G18").BorderAround(Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous, Microsoft.Office.Interop.Excel.XlBorderWeight.xlMedium, Microsoft.Office.Interop.Excel.XlColorIndex.xlColorIndexAutomatic, Microsoft.Office.Interop.Excel.XlColorIndex.xlColorIndexAutomatic); //Borde


            excel.get_Range("A4", "A19").BorderAround(Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous, Microsoft.Office.Interop.Excel.XlBorderWeight.xlMedium, Microsoft.Office.Interop.Excel.XlColorIndex.xlColorIndexAutomatic, Microsoft.Office.Interop.Excel.XlColorIndex.xlColorIndexAutomatic); //Borde
            excel.get_Range("B4", "B19").BorderAround(Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous, Microsoft.Office.Interop.Excel.XlBorderWeight.xlMedium, Microsoft.Office.Interop.Excel.XlColorIndex.xlColorIndexAutomatic, Microsoft.Office.Interop.Excel.XlColorIndex.xlColorIndexAutomatic); //Borde
            excel.get_Range("C4", "C19").BorderAround(Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous, Microsoft.Office.Interop.Excel.XlBorderWeight.xlMedium, Microsoft.Office.Interop.Excel.XlColorIndex.xlColorIndexAutomatic, Microsoft.Office.Interop.Excel.XlColorIndex.xlColorIndexAutomatic); //Borde
            excel.get_Range("D4", "D19").BorderAround(Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous, Microsoft.Office.Interop.Excel.XlBorderWeight.xlMedium, Microsoft.Office.Interop.Excel.XlColorIndex.xlColorIndexAutomatic, Microsoft.Office.Interop.Excel.XlColorIndex.xlColorIndexAutomatic); //Borde
            excel.get_Range("E4", "E19").BorderAround(Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous, Microsoft.Office.Interop.Excel.XlBorderWeight.xlMedium, Microsoft.Office.Interop.Excel.XlColorIndex.xlColorIndexAutomatic, Microsoft.Office.Interop.Excel.XlColorIndex.xlColorIndexAutomatic); //Borde
            excel.get_Range("F4", "F19").BorderAround(Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous, Microsoft.Office.Interop.Excel.XlBorderWeight.xlMedium, Microsoft.Office.Interop.Excel.XlColorIndex.xlColorIndexAutomatic, Microsoft.Office.Interop.Excel.XlColorIndex.xlColorIndexAutomatic); //Borde
            excel.get_Range("G4", "G19").BorderAround(Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous, Microsoft.Office.Interop.Excel.XlBorderWeight.xlMedium, Microsoft.Office.Interop.Excel.XlColorIndex.xlColorIndexAutomatic, Microsoft.Office.Interop.Excel.XlColorIndex.xlColorIndexAutomatic); //Borde

            foreach (DataGridViewColumn col in dataGridView1.Columns)
            {

                ColumnIndex++;

                excel.Cells[4, ColumnIndex] = col.Name;

            }

            int rowIndex = 3;

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {

                rowIndex++;

                ColumnIndex = 0;

                foreach (DataGridViewColumn col in dataGridView1.Columns)
                {

                    ColumnIndex++;

                    excel.Cells[rowIndex + 1, ColumnIndex] = row.Cells[col.Name].Value;

                }

            }

            excel.Visible = true;

            Worksheet worksheet = (Worksheet)excel.ActiveSheet;

            //worksheet.Activate();

        }

        private void generarReporteToolStripMenuItem_Click(object sender, EventArgs e)
        {

            exporta_a_excel();
        }

        private void FrmConsultarHorario_Load(object sender, EventArgs e)
        {

        }

        private void FrmConsultarHorario_MouseDown(object sender, MouseEventArgs e)
        {

            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void detalleLaboralToolStripMenuItem_Click(object sender, EventArgs e)
        {

            FrmDetallesHorasTrabajadas detalle = new FrmDetallesHorasTrabajadas();
            detalle.MdiParent = principal;
            detalle.Show();

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            VentanaMsjes ventana = new VentanaMsjes("EXPORTACIÓN A EXCEL", "Espere un momento mientras el aplicativo importa los datos a excel...");
            ventana.iconoPregunta.Image = global::Ej_Interfaz_Proyecto.Properties.Resources.icn_inf;
            ventana.btnAceptar.Visible = true;
            ventana.ShowDialog();
            exporta_a_excel();  
        }





        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarHorarioInstructor("" + id, tipo);
            //esta vaildación elimina filas para la mañana
            if (Jornada.Equals("Mañana"))
            {
                for (int i = 6; i < dataGridView1.RowCount + 7; i++)
                {
                    dataGridView1.Rows.RemoveAt(6);
                }
                dataGridView1.Rows.RemoveAt(6);
            }
            else if (Jornada.Equals("Tarde"))
            {
                for (int i = 0; i < 6; i++)
                {
                    dataGridView1.Rows.RemoveAt(0);
                }
                for (int i = 0; i < 4; i++)
                {
                    dataGridView1.Rows.RemoveAt(6);
                }

            }
            else if (Jornada.Equals("Nocturna"))
            {
                for (int i = 0; i < dataGridView1.RowCount + 7; i++)
                {
                    dataGridView1.Rows.RemoveAt(0);
                }
            }
            else if (Jornada.Equals("Jornada continua"))
            {
                for (int i = 0; i < 4; i++)
                {
                    dataGridView1.Rows.RemoveAt(12);
                }
            }


        }
        private void cargaMonetaneo()
        {
            String sql = " Select TRIMESTRE_ANIO from HORARIO where ";
            comboBox1.Items.Clear();
            if (tipo.Equals("Instructor"))
            {
                sql += " ID_INSTRUCTOR";
            }
            if (tipo.Equals("Ambiente"))
            {
                sql += "ID_AMBIENTE";
            }
            if (tipo.Equals("Grupo"))
            {
                sql += " ID_GRUPO";
            }
            sql += " ='" + id + "'";
            try
            {
                System.Data.DataTable dt = new System.Data.DataTable();
                GestionHorario.Conexion c = new GestionHorario.Conexion();
                c.AbrirConexion();

                consulta = new SqlCommand(sql, c.GetConexion);

                SqlDataReader r = consulta.ExecuteReader();

                while (r.Read())
                {
                    int xx = 0;

                    for (int i = 0; i < comboBox1.Items.Count; i++)
                    {

                        if (comboBox1.Items[i].Equals(r[0].ToString()))
                        {

                            xx = 1;
                            break;
                        }
                    }

                    if (xx == 0)
                    {
                        comboBox1.Items.Add(r[0].ToString());
                    }
                }

            }
            catch (SqlException error)
            {

                VentanaMsjes ventana2 = new VentanaMsjes("ERROR", error.Message);
                ventana2.iconoPregunta.Image = global::Ej_Interfaz_Proyecto.Properties.Resources.icn_err;
                ventana2.btnAceptar.Visible = true;
                ventana2.ShowDialog();
            }
            // CargarHorarioInstructor();
            
        }

        private void CbxInstructores_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargaMonetaneo();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            
            string sql=null;
            string id_co = "Identificación";
            string name = "Nombre";
            string area_jor = "Celular";
            if (tipo.Equals("Ambiente"))
            {
                sql = "select a.ID_AMBIENTE as Código,a.NOMBRE_AMBIENTE as Nombre,ar.NOMBRE as Área from AMBIENTE a, AREAS ar where a.ID_AREA=ar.ID";
                id_co = "Código";
                area_jor = "Área";

            }
            else if (tipo.Equals("Grupo"))
            {
                sql = "select g.ID_GRUPO as Código,p.NOMBRE_PROGRAMA as Programa, g.JORNADA as Jornada from GRUPO g, PROGRAMA p where p.ID_PROGRAMA=g.ID_PROGRAMA";
                id_co = "Código";
                name = "Programa";
                area_jor = "Jornada";
            }

            FrmBusqueda_1280x1024 bu = new FrmBusqueda_1280x1024(sql,id_co,name,area_jor,tipo);
            bu.pasando +=new FrmBusqueda_1280x1024.pasar(bu_pasando);
            bu.ShowDialog();
        }


        void bu_pasando(string id, string nombre,string Cell_Jor)
        {
            dataGridView1.Rows.Clear();
            txtInstructor.Text = "      "+id+" - "+nombre;
            this.id = id;
            this.Jornada = Cell_Jor;
            cargaMonetaneo();
        }

        private void txtInstructor_TextChanged(object sender, EventArgs e)
        {

        }
        private void horas_jornada( FrmPDF_1280x1024 g) {
            int mañana = 0;
            int tarde = 0;
            int noche = 0;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                for (int j = 0; j < dataGridView1.ColumnCount; j++)
                {
                    if (i >= 0 && i<6 && dataGridView1.Rows[i].Cells[j].Style.BackColor==Color.FromArgb(4, 123, 117))
                    {
                        mañana++;
                    }
                    else if (i >= 6 && i<12 && dataGridView1.Rows[i].Cells[j].Style.BackColor==Color.FromArgb(4, 123, 117))
                    {
                        tarde++;
                    }
                    else if (i >= 12 && dataGridView1.Rows[i].Cells[j].Style.BackColor==Color.FromArgb(4, 123, 117))
                    {
                        noche++;
                    }
                }

            }               
            
            g.mañana = ""+mañana;
            g.tarde = ""+tarde;
            g.noche = ""+noche;
        }
        private Boolean exiten() {
            Boolean muestra = false;
            for (int i = 1; i < dataGridView1.Rows.Count; i++)
            {
                for (int j = 0; j <dataGridView1.ColumnCount ; j++ )
                {
                    if (dataGridView1.Rows[i].Cells[j].Style.BackColor==Color.FromArgb(4,123,117))
                    {
                        muestra = true;
                        break;                        
                    }
                }
            }
            return muestra;
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count>0 && exiten()==true)
            {
                FrmPDF_1280x1024 c = new FrmPDF_1280x1024(generaConsulta(), tipo1, id, comboBox1.Text);
                horas_jornada(c);
                c.ShowDialog();
            }
            else
            {
                VentanaMsjes ventana = new VentanaMsjes("AVISO", "No es posible generar reporte sin selecionar el tipo de horario y el trimestre del año.");
                ventana.btnSi.Visible = false;
                ventana.btnNo.Visible = false;
                ventana.btnAceptar.Visible = true;
                ventana.iconoPregunta.Image = global::Ej_Interfaz_Proyecto.Properties.Resources.icn_pre;
                ventana.ShowDialog();
            }

                 
        }
        private string generaConsulta() {
            int lunes = 0;
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
		        if (!string.IsNullOrEmpty(Convert.ToString(dataGridView1.Rows[i].Cells[1].Value)))
                {
                    lunes++;
                }
            }

            int Martes = 0;
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                if (!string.IsNullOrEmpty(Convert.ToString(dataGridView1.Rows[i].Cells[2].Value)))
                {
                    Martes++;
                }
            }
            int Miercoles = 0;
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                if (!string.IsNullOrEmpty(Convert.ToString(dataGridView1.Rows[i].Cells[3].Value)))
                {
                    Miercoles++;
                }
            }
            int Jueves = 0;
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                if (!string.IsNullOrEmpty(Convert.ToString(dataGridView1.Rows[i].Cells[4].Value)))
                {
                    Jueves++;
                }
            }
            int Viernes = 0;
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                if (!string.IsNullOrEmpty(Convert.ToString(dataGridView1.Rows[i].Cells[5].Value)))
                {
                    Viernes++;
                }
            }
            int sabado = 0;
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                if (!string.IsNullOrEmpty(Convert.ToString(dataGridView1.Rows[i].Cells[6].Value)))
                {
                    sabado++;
                }
            }
           string miconsulta = "truncate table hora; ";
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                miconsulta += " insert into hora values('" + Convert.ToString(row.Cells[0].Value) + "','" + Convert.ToString(row.Cells[1].Value) + "','" + Convert.ToString(row.Cells[2].Value) + "','" + Convert.ToString(row.Cells[3].Value) + "','" + Convert.ToString(row.Cells[4].Value) + "','" + Convert.ToString(row.Cells[5].Value) + "','" + Convert.ToString(row.Cells[6].Value) + "');";
            }
            miconsulta += " insert into hora values('Total Horas Diarias por Semana','" + lunes + "','" + Martes + "','" + Miercoles + "','" + Jueves + "','" + Viernes + "','" +sabado + "');";
            miconsulta += " insert into hora values('Total Horas Diarias por Mes','" + lunes *4 + "','" + Martes *4 + "','" + Miercoles *4 + "','" + Jueves *4 + "','" + Viernes *4 + "','" + sabado *4 + "');"; 
            miconsulta += " insert into hora values('Total Horas Diarias por Trimestre','" + lunes * 12 + "','" + Martes * 12 + "','" + Miercoles * 12 + "','" + Jueves * 12 + "','" + Viernes * 12 + "','" + sabado * 12 + "');"; 
            return miconsulta;            
        }



    }
}
