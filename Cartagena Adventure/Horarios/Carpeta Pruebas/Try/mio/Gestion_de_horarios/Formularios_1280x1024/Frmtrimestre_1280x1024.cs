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

namespace Ej_Interfaz_Proyecto.Formularios_1280x1024
{
    public partial class Frmtrimestre_1280x1024 : Form
    {
        // Declaraciones del API PARA MOVER EL FORMULARIO
        [System.Runtime.InteropServices.DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        //
        [System.Runtime.InteropServices.DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);


        string tipoCompetencia;

        string id_Competencia;
        string descripcion="";
        
        FrmCompetenciasTecnicas_1280x1024 frmCompTecnicas;
        FrmCompetenciasTransversales_1280x1024 frmCompTrans;
        
        
        public Frmtrimestre_1280x1024(string id_Competencia,FrmCompetenciasTecnicas_1280x1024 formulario,string descripcioN)
        {
            this.frmCompTecnicas = formulario;
            this.id_Competencia = id_Competencia;
            this.descripcion = descripcioN;
            tipoCompetencia = "tecnica";
            InitializeComponent();
            this.btnGuardar.ForeColor = Color.FromArgb(4, 123, 117);
            this.BackColor = Color.FromArgb(4, 123, 117);
            
        }

        public Frmtrimestre_1280x1024(string id_Competencia, FrmCompetenciasTransversales_1280x1024 formulario, string descripcioN)
        {
            this.frmCompTrans = formulario;
            this.id_Competencia = id_Competencia;
            this.descripcion = descripcioN;
            tipoCompetencia = "transversal";
            InitializeComponent();
            this.btnGuardar.ForeColor = Color.FromArgb(4, 123, 117);
            this.BackColor = Color.FromArgb(4, 123, 117);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cbxJornada.Text.Trim()) || string.IsNullOrEmpty(txtDuracion.Text.Trim()) || string.IsNullOrEmpty(textCodigo1.Text.Trim()))
            {
                VentanaMsjes ventana = new VentanaMsjes("GUARDAR", "Diligencie todos campos");
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
                    System.Data.SqlClient.SqlCommand cm = new System.Data.SqlClient.SqlCommand("exec ModificarTrimestre '" + dgvResultado.CurrentRow.Cells[0].Value.ToString() + "' ,'" + id_Competencia + "','" + textCodigo1.Text.Trim() + "','" + txtDuracion.Text.Trim() + "','" + cbxJornada.Text.Trim() + "'   ", C.GetConexion);
                    System.Data.SqlClient.SqlDataReader dr = cm.ExecuteReader();
                    while (dr.Read())
                    {
                        a = dr.GetString(0);
                    }
                    Limpiar();
                    muestradata();
                    VentanaMsjes ventana = new VentanaMsjes("Modificar", a);
                    ventana.iconoPregunta.Image = global::Ej_Interfaz_Proyecto.Properties.Resources.icn_inf;
                    ventana.btnAceptar.Visible = true;
                    ventana.ShowDialog();                    
                    dr.Close();
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
                    string a="try";
                    System.Data.SqlClient.SqlCommand cm = new System.Data.SqlClient.SqlCommand("exec registroTrimestre '" + id_Competencia + "','" + textCodigo1.Text.Trim() + "','" + txtDuracion.Text.Trim() + "','" + cbxJornada.Text.Trim() + "' ", C.GetConexion);
                    System.Data.SqlClient.SqlDataReader dr=cm.ExecuteReader();
                    while (dr.Read())
                    {
                        a = dr.GetString(0);
                    }
                    Limpiar();
                    muestradata();
                    VentanaMsjes ventana = new VentanaMsjes("Registro", a);
                    ventana.iconoPregunta.Image = global::Ej_Interfaz_Proyecto.Properties.Resources.icn_inf;
                    ventana.btnAceptar.Visible = true;
                    ventana.ShowDialog();                    
                    dr.Close();
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

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
            Limpiar();

            if (tipoCompetencia == "tecnica")
                frmCompTecnicas.OpcionResultados = "";
            else
                frmCompTrans.OpcionCompetencia = "";
        }

        private void Limpiar()
        {
            textCodigo1.SelectedIndex = -1;            
            txtDuracion.Text = "";
            cbxJornada.SelectedIndex = -1;
            cbxJornada.Focus();
        }
        private string consultarTrimestres() {
            string miRetorno = "";
            Conexion c = new Conexion();
            c.AbrirConexion();
            System.Data.SqlClient.SqlCommand cm1 = new System.Data.SqlClient.SqlCommand("select p.DURACION_PROGRAMA from programa p , COMPETENCIAS c, RESULTADOS r where p.ID_PROGRAMA=c.ID_PROGRAMA and c.ID=r.ID_COMPETENCIA and r.ID="+id_Competencia+" ", c.GetConexion);
            System.Data.SqlClient.SqlDataReader dr1 = cm1.ExecuteReader();
            while (dr1.Read())
            {
                miRetorno = dr1.GetString(0);
            }
            dr1.Close();
            c.CerrarConexion();
            return miRetorno;
        }
        private void muestradata() {
            try
            {
                Conexion c = new Conexion();
                c.AbrirConexion();
                System.Data.SqlClient.SqlCommand cm1 = new System.Data.SqlClient.SqlCommand("select t.codigo as Código, r.DESCRIPCION as [Descripción del resultado],t.trimestre as [Trimestre] ,t.duracion as [Duración],t.jornada from trimestre t, RESULTADOS r  where  r.ID=t.idresultado  and r.DESCRIPCION='" + descripcion + "' ", c.GetConexion);
                System.Data.SqlClient.SqlDataReader dr1 = cm1.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr1);
                dgvResultado.Columns[0].DataPropertyName = "Código".Trim();
                dgvResultado.Columns[1].DataPropertyName = "Descripción del resultado".Trim();
                dgvResultado.Columns[2].DataPropertyName = "Trimestre".Trim();
                dgvResultado.Columns[3].DataPropertyName = "Duración".Trim();
                dgvResultado.Columns[4].DataPropertyName = "jornada".Trim();
                dgvResultado.DataSource = dt;
                txtResultado.Text = this.descripcion;
                dr1.Close();
                c.CerrarConexion();
            }
            catch (Exception ex)
            {
                MessageBox.Show(""+ex);
                
            }

        }


        private void FrmRegistroResultados_Load(object sender, EventArgs e)
        {
            Limpiar();
            muestradata();
        }

        private void pictureBox4_MouseLeave(object sender, EventArgs e)
        {
            this.pictureBox4.Image = global::Ej_Interfaz_Proyecto.Properties.Resources.btn_cer_normal2;
        }

        private void pictureBox4_MouseMove(object sender, MouseEventArgs e)
        {
            this.pictureBox4.Image = global::Ej_Interfaz_Proyecto.Properties.Resources.btn_cer_focus2;
        }



        private void pictureBox3_Click(object sender, EventArgs e)
        {
            //WindowState = FormWindowState.Minimized;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmRegistroResultados_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void textCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            soloNumeros(e);
        }

        private void soloNumeros(KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;

            }
            else if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;

            }
            else if (char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;

            }
            else
            {
                e.Handled = true;
            }
        }

        private void txtDuracion_KeyPress(object sender, KeyPressEventArgs e)
        {
            soloNumeros(e);
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

                try
                {
                    Conexion c = new Conexion();
                    c.AbrirConexion();
                    System.Data.SqlClient.SqlCommand cm1 = new System.Data.SqlClient.SqlCommand("delete trimestre where codigo="+dgvResultado.CurrentRow.Cells[0].Value.ToString()+"", c.GetConexion);
                    cm1.ExecuteNonQuery();
                    muestradata();
                    Limpiar();
                    VentanaMsjes ventana = new VentanaMsjes("Eliminación", "¡Eliminación exitosa!");
                    ventana.iconoPregunta.Image = global::Ej_Interfaz_Proyecto.Properties.Resources.icn_inf;
                    ventana.btnAceptar.Visible = true;
                    ventana.ShowDialog();                    
                }
                catch (Exception ex)
                {
                    VentanaMsjes ventana2 = new VentanaMsjes("ERROR", ex.Message);
                    ventana2.iconoPregunta.Image = global::Ej_Interfaz_Proyecto.Properties.Resources.icn_err;
                    ventana2.btnAceptar.Visible = true;
                    ventana2.ShowDialog();
                }

            
        }

        private void rdbModificar_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbModificar.Checked)
            {
                btnEliminar.Enabled = true;
                Limpiar();
                textCodigo1.Enabled = false;
                textCodigo1.SelectedIndex = -1;
            }
            else
            {
                textCodigo1.Enabled = false;
                textCodigo1.SelectedIndex = -1;
                Limpiar();
            }
        }

        private void dgvResultado_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            if (rdbModificar.Checked)
            {
                cbxJornada.Text = dgvResultado.CurrentRow.Cells[4].Value.ToString();
                txtDuracion.Text = dgvResultado.CurrentRow.Cells[3].Value.ToString();                
                textCodigo1.Enabled = true;
                textCodigo1.Text = dgvResultado.CurrentRow.Cells[2].Value.ToString();
            }
            else
            {
                Limpiar();
            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int Trimestre=int.Parse(consultarTrimestres());
            textCodigo1.Items.Clear();
            if (cbxJornada.SelectedIndex==0)
            {
                for (int i = 1; i <Trimestre+1; i++)
                {
                    textCodigo1.Items.Add(i);
                }
                textCodigo1.Enabled = true;
                textCodigo1.SelectedIndex = 0;
            }
            else
            {
                for (int i = 1; i < (Trimestre*2)+1; i++)
                {
                    textCodigo1.Items.Add(i);
                }
                textCodigo1.Enabled = true;
                textCodigo1.SelectedIndex = 0;
            }
        }
    }
}
