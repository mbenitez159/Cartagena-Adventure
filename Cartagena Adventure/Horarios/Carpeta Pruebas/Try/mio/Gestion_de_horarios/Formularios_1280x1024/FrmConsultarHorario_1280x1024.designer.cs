namespace Ej_Interfaz_Proyecto.Formularios_1280x1024
{
    partial class FrmConsultarHorario_1280x1024
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmConsultarHorario_1280x1024));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Hora = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Lunes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Martes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Miercoles = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Jueves = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Viernes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sabado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Detalles = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.eToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generarReporteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.detalleLaboralToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label6 = new System.Windows.Forms.Label();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.BtnAreas = new System.Windows.Forms.PictureBox();
            this.BtnAmbiente = new System.Windows.Forms.PictureBox();
            this.BtnInstructor = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.txtInstructor = new System.Windows.Forms.TextBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.ptbPDF = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.Detalles.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BtnAreas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BtnAmbiente)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BtnInstructor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbPDF)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.Black;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Hora,
            this.Lunes,
            this.Martes,
            this.Miercoles,
            this.Jueves,
            this.Viernes,
            this.Sabado});
            this.dataGridView1.ContextMenuStrip = this.Detalles;
            this.dataGridView1.GridColor = System.Drawing.Color.Black;
            this.dataGridView1.Location = new System.Drawing.Point(16, 179);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(746, 286);
            this.dataGridView1.TabIndex = 44;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseDown);
            // 
            // Hora
            // 
            this.Hora.FillWeight = 99.57326F;
            this.Hora.HeaderText = "Hora";
            this.Hora.Name = "Hora";
            this.Hora.ReadOnly = true;
            this.Hora.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // Lunes
            // 
            this.Lunes.FillWeight = 99.75243F;
            this.Lunes.HeaderText = "Lunes";
            this.Lunes.Name = "Lunes";
            this.Lunes.ReadOnly = true;
            this.Lunes.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // Martes
            // 
            this.Martes.FillWeight = 99.90612F;
            this.Martes.HeaderText = "Martes";
            this.Martes.Name = "Martes";
            this.Martes.ReadOnly = true;
            this.Martes.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Martes.Width = 101;
            // 
            // Miercoles
            // 
            this.Miercoles.FillWeight = 100.0379F;
            this.Miercoles.HeaderText = "Miercoles";
            this.Miercoles.Name = "Miercoles";
            this.Miercoles.ReadOnly = true;
            this.Miercoles.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // Jueves
            // 
            this.Jueves.FillWeight = 100.151F;
            this.Jueves.HeaderText = "Jueves";
            this.Jueves.Name = "Jueves";
            this.Jueves.ReadOnly = true;
            this.Jueves.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Jueves.Width = 101;
            // 
            // Viernes
            // 
            this.Viernes.FillWeight = 100.248F;
            this.Viernes.HeaderText = "Viernes";
            this.Viernes.Name = "Viernes";
            this.Viernes.ReadOnly = true;
            this.Viernes.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // Sabado
            // 
            this.Sabado.FillWeight = 100.3312F;
            this.Sabado.HeaderText = "Sabado";
            this.Sabado.Name = "Sabado";
            this.Sabado.ReadOnly = true;
            this.Sabado.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Sabado.Width = 101;
            // 
            // Detalles
            // 
            this.Detalles.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.eToolStripMenuItem,
            this.generarReporteToolStripMenuItem,
            this.detalleLaboralToolStripMenuItem});
            this.Detalles.Name = "Detalles";
            this.Detalles.ShowImageMargin = false;
            this.Detalles.Size = new System.Drawing.Size(146, 92);
            this.Detalles.Text = "Detalles";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(145, 22);
            this.toolStripMenuItem1.Text = "+ Detalles";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // eToolStripMenuItem
            // 
            this.eToolStripMenuItem.Name = "eToolStripMenuItem";
            this.eToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.eToolStripMenuItem.Text = "+ Eliminar";
            this.eToolStripMenuItem.Click += new System.EventHandler(this.eToolStripMenuItem_Click);
            // 
            // generarReporteToolStripMenuItem
            // 
            this.generarReporteToolStripMenuItem.Name = "generarReporteToolStripMenuItem";
            this.generarReporteToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.generarReporteToolStripMenuItem.Text = "+ Generar Reporte";
            this.generarReporteToolStripMenuItem.Click += new System.EventHandler(this.generarReporteToolStripMenuItem_Click);
            // 
            // detalleLaboralToolStripMenuItem
            // 
            this.detalleLaboralToolStripMenuItem.Name = "detalleLaboralToolStripMenuItem";
            this.detalleLaboralToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.detalleLaboralToolStripMenuItem.Text = "+ Detalle Laboral";
            this.detalleLaboralToolStripMenuItem.Click += new System.EventHandler(this.detalleLaboralToolStripMenuItem_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(286, 10);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(198, 20);
            this.label6.TabIndex = 59;
            this.label6.Text = "CONSULTAR HORARIOS";
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = global::Ej_Interfaz_Proyecto.Properties.Resources.icn_hor;
            this.pictureBox5.Location = new System.Drawing.Point(20, 3);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(34, 34);
            this.pictureBox5.TabIndex = 63;
            this.pictureBox5.TabStop = false;
            // 
            // BtnAreas
            // 
            this.BtnAreas.BackColor = System.Drawing.Color.Transparent;
            this.BtnAreas.Image = global::Ej_Interfaz_Proyecto.Properties.Resources.btn_gru_normal;
            this.BtnAreas.Location = new System.Drawing.Point(406, 57);
            this.BtnAreas.Name = "BtnAreas";
            this.BtnAreas.Size = new System.Drawing.Size(52, 64);
            this.BtnAreas.TabIndex = 62;
            this.BtnAreas.TabStop = false;
            this.BtnAreas.Click += new System.EventHandler(this.BtnAreas_Click);
            this.BtnAreas.MouseLeave += new System.EventHandler(this.BtnAreas_MouseLeave);
            this.BtnAreas.MouseMove += new System.Windows.Forms.MouseEventHandler(this.BtnAreas_MouseMove);
            // 
            // BtnAmbiente
            // 
            this.BtnAmbiente.BackColor = System.Drawing.Color.Transparent;
            this.BtnAmbiente.Image = global::Ej_Interfaz_Proyecto.Properties.Resources.btn_amb_normal2;
            this.BtnAmbiente.Location = new System.Drawing.Point(65, 55);
            this.BtnAmbiente.Name = "BtnAmbiente";
            this.BtnAmbiente.Size = new System.Drawing.Size(39, 66);
            this.BtnAmbiente.TabIndex = 61;
            this.BtnAmbiente.TabStop = false;
            this.BtnAmbiente.Click += new System.EventHandler(this.BtnAmbiente_Click);
            this.BtnAmbiente.MouseLeave += new System.EventHandler(this.BtnAmbiente_MouseLeave);
            this.BtnAmbiente.MouseMove += new System.Windows.Forms.MouseEventHandler(this.BtnAmbiente_MouseMove);
            // 
            // BtnInstructor
            // 
            this.BtnInstructor.BackColor = System.Drawing.Color.Transparent;
            this.BtnInstructor.Image = global::Ej_Interfaz_Proyecto.Properties.Resources.bt_ins_normal2;
            this.BtnInstructor.Location = new System.Drawing.Point(246, 57);
            this.BtnInstructor.Name = "BtnInstructor";
            this.BtnInstructor.Size = new System.Drawing.Size(28, 64);
            this.BtnInstructor.TabIndex = 60;
            this.BtnInstructor.TabStop = false;
            this.BtnInstructor.Click += new System.EventHandler(this.BtnInstructor_Click);
            this.BtnInstructor.MouseLeave += new System.EventHandler(this.BtnInstructor_MouseLeave);
            this.BtnInstructor.MouseMove += new System.Windows.Forms.MouseEventHandler(this.BtnInstructor_MouseMove);
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox4.Image = global::Ej_Interfaz_Proyecto.Properties.Resources.btn_cer_normal2;
            this.pictureBox4.Location = new System.Drawing.Point(741, 6);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(29, 28);
            this.pictureBox4.TabIndex = 58;
            this.pictureBox4.TabStop = false;
            this.pictureBox4.Click += new System.EventHandler(this.pictureBox4_Click);
            this.pictureBox4.MouseLeave += new System.EventHandler(this.pictureBox4_MouseLeave);
            this.pictureBox4.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox4_MouseMove);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.Location = new System.Drawing.Point(0, 40);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(780, 2);
            this.pictureBox1.TabIndex = 56;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(595, 57);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(47, 66);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 64;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.BackColor = System.Drawing.Color.White;
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(580, 137);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(188, 24);
            this.comboBox1.TabIndex = 65;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // pictureBox6
            // 
            this.pictureBox6.BackColor = System.Drawing.Color.White;
            this.pictureBox6.Location = new System.Drawing.Point(17, 170);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(749, 2);
            this.pictureBox6.TabIndex = 104;
            this.pictureBox6.TabStop = false;
            // 
            // txtInstructor
            // 
            this.txtInstructor.Location = new System.Drawing.Point(20, 137);
            this.txtInstructor.Multiline = true;
            this.txtInstructor.Name = "txtInstructor";
            this.txtInstructor.ReadOnly = true;
            this.txtInstructor.Size = new System.Drawing.Size(490, 24);
            this.txtInstructor.TabIndex = 105;
            this.txtInstructor.TextChanged += new System.EventHandler(this.txtInstructor_TextChanged);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(516, 137);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(42, 26);
            this.btnBuscar.TabIndex = 106;
            this.btnBuscar.Text = "...";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // ptbPDF
            // 
            this.ptbPDF.BackColor = System.Drawing.Color.Transparent;
            this.ptbPDF.Image = ((System.Drawing.Image)(resources.GetObject("ptbPDF.Image")));
            this.ptbPDF.Location = new System.Drawing.Point(680, 57);
            this.ptbPDF.Name = "ptbPDF";
            this.ptbPDF.Size = new System.Drawing.Size(61, 64);
            this.ptbPDF.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ptbPDF.TabIndex = 107;
            this.ptbPDF.TabStop = false;
            this.ptbPDF.Click += new System.EventHandler(this.pictureBox7_Click);
            // 
            // FrmConsultarHorario_1280x1024
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(780, 490);
            this.Controls.Add(this.ptbPDF);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.txtInstructor);
            this.Controls.Add(this.pictureBox6);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox5);
            this.Controls.Add(this.BtnAmbiente);
            this.Controls.Add(this.BtnAreas);
            this.Controls.Add(this.BtnInstructor);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.dataGridView1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmConsultarHorario_1280x1024";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Consultar Horarios";
            this.Load += new System.EventHandler(this.FrmConsultarHorario_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FrmConsultarHorario_MouseDown);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.Detalles.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BtnAreas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BtnAmbiente)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BtnInstructor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbPDF)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ContextMenuStrip Detalles;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox1;
        public System.Windows.Forms.PictureBox BtnInstructor;
        public System.Windows.Forms.PictureBox BtnAmbiente;
        public System.Windows.Forms.PictureBox BtnAreas;
        private System.Windows.Forms.ToolStripMenuItem eToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem generarReporteToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn Hora;
        private System.Windows.Forms.DataGridViewTextBoxColumn Lunes;
        private System.Windows.Forms.DataGridViewTextBoxColumn Martes;
        private System.Windows.Forms.DataGridViewTextBoxColumn Miercoles;
        private System.Windows.Forms.DataGridViewTextBoxColumn Jueves;
        private System.Windows.Forms.DataGridViewTextBoxColumn Viernes;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sabado;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.ToolStripMenuItem detalleLaboralToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.TextBox txtInstructor;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.PictureBox ptbPDF;
    }
}