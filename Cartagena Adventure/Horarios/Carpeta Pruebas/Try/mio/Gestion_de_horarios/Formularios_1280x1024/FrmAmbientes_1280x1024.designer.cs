namespace Ej_Interfaz_Proyecto.Formularios_1280x1024
{
    partial class FrmAmbientes_1280x1024
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
            this.btnGuardar = new System.Windows.Forms.Button();
            this.cbArea = new System.Windows.Forms.ComboBox();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.rdbModificar = new System.Windows.Forms.RadioButton();
            this.rdbNuevo = new System.Windows.Forms.RadioButton();
            this.txtCapacidad = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtArea = new System.Windows.Forms.TextBox();
            this.dgvAmbientes = new System.Windows.Forms.DataGridView();
            this.Cod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Capacidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AreaM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Areaf = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAmbientes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            this.SuspendLayout();
            // 
            // btnGuardar
            // 
            this.btnGuardar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.Location = new System.Drawing.Point(784, 538);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(80, 25);
            this.btnGuardar.TabIndex = 7;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // cbArea
            // 
            this.cbArea.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbArea.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbArea.FormattingEnabled = true;
            this.cbArea.Location = new System.Drawing.Point(15, 537);
            this.cbArea.Name = "cbArea";
            this.cbArea.Size = new System.Drawing.Size(589, 24);
            this.cbArea.TabIndex = 11;
            this.cbArea.DropDown += new System.EventHandler(this.cbArea_DropDown);
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescripcion.Location = new System.Drawing.Point(15, 455);
            this.txtDescripcion.MaxLength = 50;
            this.txtDescripcion.Multiline = true;
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(954, 54);
            this.txtDescripcion.TabIndex = 9;
            // 
            // rdbModificar
            // 
            this.rdbModificar.AutoSize = true;
            this.rdbModificar.BackColor = System.Drawing.Color.Transparent;
            this.rdbModificar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbModificar.ForeColor = System.Drawing.Color.White;
            this.rdbModificar.Location = new System.Drawing.Point(884, 321);
            this.rdbModificar.Name = "rdbModificar";
            this.rdbModificar.Size = new System.Drawing.Size(91, 24);
            this.rdbModificar.TabIndex = 1;
            this.rdbModificar.TabStop = true;
            this.rdbModificar.Text = "Modificar";
            this.rdbModificar.UseVisualStyleBackColor = false;
            this.rdbModificar.CheckedChanged += new System.EventHandler(this.rdbModificar_CheckedChanged);
            // 
            // rdbNuevo
            // 
            this.rdbNuevo.AutoSize = true;
            this.rdbNuevo.BackColor = System.Drawing.Color.Transparent;
            this.rdbNuevo.Checked = true;
            this.rdbNuevo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbNuevo.ForeColor = System.Drawing.Color.White;
            this.rdbNuevo.Location = new System.Drawing.Point(772, 321);
            this.rdbNuevo.Name = "rdbNuevo";
            this.rdbNuevo.Size = new System.Drawing.Size(72, 24);
            this.rdbNuevo.TabIndex = 0;
            this.rdbNuevo.TabStop = true;
            this.rdbNuevo.Text = "Nuevo";
            this.rdbNuevo.UseVisualStyleBackColor = false;
            this.rdbNuevo.CheckedChanged += new System.EventHandler(this.rdbNuevo_CheckedChanged);
            // 
            // txtCapacidad
            // 
            this.txtCapacidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCapacidad.Location = new System.Drawing.Point(595, 381);
            this.txtCapacidad.MaxLength = 4;
            this.txtCapacidad.Multiline = true;
            this.txtCapacidad.Name = "txtCapacidad";
            this.txtCapacidad.Size = new System.Drawing.Size(150, 30);
            this.txtCapacidad.TabIndex = 5;
            this.txtCapacidad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCapacidad_KeyPress);
            // 
            // txtNombre
            // 
            this.txtNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombre.Location = new System.Drawing.Point(15, 381);
            this.txtNombre.MaxLength = 50;
            this.txtNombre.Multiline = true;
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(506, 30);
            this.txtNombre.TabIndex = 3;
            // 
            // txtArea
            // 
            this.txtArea.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtArea.Location = new System.Drawing.Point(819, 381);
            this.txtArea.MaxLength = 4;
            this.txtArea.Multiline = true;
            this.txtArea.Name = "txtArea";
            this.txtArea.Size = new System.Drawing.Size(150, 30);
            this.txtArea.TabIndex = 7;
            this.txtArea.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtArea_KeyPress);
            // 
            // dgvAmbientes
            // 
            this.dgvAmbientes.AllowUserToAddRows = false;
            this.dgvAmbientes.AllowUserToDeleteRows = false;
            this.dgvAmbientes.BackgroundColor = System.Drawing.Color.White;
            this.dgvAmbientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAmbientes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Cod,
            this.Nombre,
            this.Descripcion,
            this.Capacidad,
            this.AreaM,
            this.Areaf});
            this.dgvAmbientes.Location = new System.Drawing.Point(15, 78);
            this.dgvAmbientes.MultiSelect = false;
            this.dgvAmbientes.Name = "dgvAmbientes";
            this.dgvAmbientes.ReadOnly = true;
            this.dgvAmbientes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAmbientes.Size = new System.Drawing.Size(954, 217);
            this.dgvAmbientes.TabIndex = 0;
            this.dgvAmbientes.SelectionChanged += new System.EventHandler(this.dgvAmbientes_SelectionChanged);
            // 
            // Cod
            // 
            this.Cod.HeaderText = "Código";
            this.Cod.Name = "Cod";
            this.Cod.ReadOnly = true;
            // 
            // Nombre
            // 
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.Name = "Nombre";
            this.Nombre.ReadOnly = true;
            this.Nombre.Width = 200;
            // 
            // Descripcion
            // 
            this.Descripcion.HeaderText = "Descripción";
            this.Descripcion.Name = "Descripcion";
            this.Descripcion.ReadOnly = true;
            this.Descripcion.Width = 200;
            // 
            // Capacidad
            // 
            this.Capacidad.HeaderText = "Capacidad";
            this.Capacidad.Name = "Capacidad";
            this.Capacidad.ReadOnly = true;
            this.Capacidad.Width = 150;
            // 
            // AreaM
            // 
            this.AreaM.HeaderText = "Área (m2)";
            this.AreaM.Name = "AreaM";
            this.AreaM.ReadOnly = true;
            this.AreaM.Width = 130;
            // 
            // Areaf
            // 
            this.Areaf.HeaderText = "Área de formación";
            this.Areaf.Name = "Areaf";
            this.Areaf.ReadOnly = true;
            this.Areaf.Width = 130;
            // 
            // btnEliminar
            // 
            this.btnEliminar.Enabled = false;
            this.btnEliminar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminar.Location = new System.Drawing.Point(889, 538);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(80, 25);
            this.btnEliminar.TabIndex = 8;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.Location = new System.Drawing.Point(0, 40);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(985, 2);
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Image = global::Ej_Interfaz_Proyecto.Properties.Resources.icn_amb;
            this.pictureBox2.Location = new System.Drawing.Point(20, 4);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(20, 33);
            this.pictureBox2.TabIndex = 10;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox3.Image = global::Ej_Interfaz_Proyecto.Properties.Resources.btn_min_normal2;
            this.pictureBox3.Location = new System.Drawing.Point(905, 6);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(28, 28);
            this.pictureBox3.TabIndex = 11;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Click += new System.EventHandler(this.pictureBox3_Click);
            this.pictureBox3.MouseLeave += new System.EventHandler(this.pictureBox3_MouseLeave);
            this.pictureBox3.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox3_MouseMove);
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox4.Image = global::Ej_Interfaz_Proyecto.Properties.Resources.btn_cer_normal2;
            this.pictureBox4.Location = new System.Drawing.Point(945, 6);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(29, 28);
            this.pictureBox4.TabIndex = 12;
            this.pictureBox4.TabStop = false;
            this.pictureBox4.Click += new System.EventHandler(this.pictureBox4_Click);
            this.pictureBox4.MouseLeave += new System.EventHandler(this.pictureBox4_MouseLeave);
            this.pictureBox4.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox4_MouseMove);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(441, 10);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(102, 20);
            this.label6.TabIndex = 13;
            this.label6.Text = "AMBIENTES";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(11, 51);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(191, 20);
            this.label7.TabIndex = 14;
            this.label7.Text = "LISTADO DE AMBIENTE";
            // 
            // pictureBox5
            // 
            this.pictureBox5.BackColor = System.Drawing.Color.White;
            this.pictureBox5.Location = new System.Drawing.Point(15, 310);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(954, 5);
            this.pictureBox5.TabIndex = 15;
            this.pictureBox5.TabStop = false;
            // 
            // pictureBox6
            // 
            this.pictureBox6.BackColor = System.Drawing.Color.White;
            this.pictureBox6.Location = new System.Drawing.Point(15, 350);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(954, 5);
            this.pictureBox6.TabIndex = 16;
            this.pictureBox6.TabStop = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(11, 323);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(186, 20);
            this.label8.TabIndex = 17;
            this.label8.Text = "DATOS DEL AMBIENTE";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(11, 359);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 20);
            this.label9.TabIndex = 18;
            this.label9.Text = "Nombre";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(590, 359);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(85, 20);
            this.label10.TabIndex = 19;
            this.label10.Text = "Capacidad";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(816, 359);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(79, 20);
            this.label11.TabIndex = 20;
            this.label11.Text = "Área (m2)";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(11, 425);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 20);
            this.label1.TabIndex = 21;
            this.label1.Text = "Descripción";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(11, 514);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(139, 20);
            this.label2.TabIndex = 22;
            this.label2.Text = "Área de formación";
            // 
            // pictureBox7
            // 
            this.pictureBox7.BackColor = System.Drawing.Color.White;
            this.pictureBox7.Location = new System.Drawing.Point(15, 580);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(954, 5);
            this.pictureBox7.TabIndex = 23;
            this.pictureBox7.TabStop = false;
            // 
            // FrmAmbientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(985, 600);
            this.Controls.Add(this.pictureBox7);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbArea);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtDescripcion);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.rdbModificar);
            this.Controls.Add(this.pictureBox6);
            this.Controls.Add(this.rdbNuevo);
            this.Controls.Add(this.pictureBox5);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtCapacidad);
            this.Controls.Add(this.txtArea);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.dgvAmbientes);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnGuardar);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.Name = "FrmAmbientes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ambientes";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmAmbientes_FormClosed);
            this.Load += new System.EventHandler(this.FrmAmbientes_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FrmAmbientes_MouseDown);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAmbientes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.RadioButton rdbModificar;
        private System.Windows.Forms.RadioButton rdbNuevo;
        private System.Windows.Forms.TextBox txtCapacidad;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtArea;
        private System.Windows.Forms.DataGridView dgvAmbientes;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.ComboBox cbArea;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cod;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Capacidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn AreaM;
        private System.Windows.Forms.DataGridViewTextBoxColumn Areaf;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox7;
    }
}