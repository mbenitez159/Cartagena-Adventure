namespace Ej_Interfaz_Proyecto.Formularios_1280x1024
{
    partial class FrmProfesion_1280x1024
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
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.dgvProfesiones = new System.Windows.Forms.DataGridView();
            this.Codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rdbNuevo = new System.Windows.Forms.RadioButton();
            this.rdbModificar = new System.Windows.Forms.RadioButton();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProfesiones)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            this.SuspendLayout();
            // 
            // txtNombre
            // 
            this.txtNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombre.Location = new System.Drawing.Point(16, 350);
            this.txtNombre.MaxLength = 100;
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(350, 26);
            this.txtNombre.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(13, 325);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(174, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Nombre de la Profesión";
            // 
            // btnGuardar
            // 
            this.btnGuardar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.Location = new System.Drawing.Point(435, 353);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(80, 25);
            this.btnGuardar.TabIndex = 4;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // dgvProfesiones
            // 
            this.dgvProfesiones.AllowUserToAddRows = false;
            this.dgvProfesiones.AllowUserToDeleteRows = false;
            this.dgvProfesiones.BackgroundColor = System.Drawing.Color.White;
            this.dgvProfesiones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProfesiones.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Codigo,
            this.Nombre});
            this.dgvProfesiones.Location = new System.Drawing.Point(16, 58);
            this.dgvProfesiones.MultiSelect = false;
            this.dgvProfesiones.Name = "dgvProfesiones";
            this.dgvProfesiones.ReadOnly = true;
            this.dgvProfesiones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProfesiones.Size = new System.Drawing.Size(599, 221);
            this.dgvProfesiones.TabIndex = 5;
            this.dgvProfesiones.SelectionChanged += new System.EventHandler(this.dgvProfesiones_SelectionChanged);
            // 
            // Codigo
            // 
            this.Codigo.FillWeight = 194.9239F;
            this.Codigo.HeaderText = "Código";
            this.Codigo.Name = "Codigo";
            this.Codigo.ReadOnly = true;
            this.Codigo.Width = 200;
            // 
            // Nombre
            // 
            this.Nombre.FillWeight = 5.076141F;
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.Name = "Nombre";
            this.Nombre.ReadOnly = true;
            this.Nombre.Width = 360;
            // 
            // rdbNuevo
            // 
            this.rdbNuevo.AutoSize = true;
            this.rdbNuevo.Checked = true;
            this.rdbNuevo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbNuevo.ForeColor = System.Drawing.Color.White;
            this.rdbNuevo.Location = new System.Drawing.Point(415, 286);
            this.rdbNuevo.Name = "rdbNuevo";
            this.rdbNuevo.Size = new System.Drawing.Size(72, 24);
            this.rdbNuevo.TabIndex = 7;
            this.rdbNuevo.TabStop = true;
            this.rdbNuevo.Text = "Nuevo";
            this.rdbNuevo.UseVisualStyleBackColor = true;
            this.rdbNuevo.CheckedChanged += new System.EventHandler(this.rdbNuevo_CheckedChanged);
            // 
            // rdbModificar
            // 
            this.rdbModificar.AutoSize = true;
            this.rdbModificar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbModificar.ForeColor = System.Drawing.Color.White;
            this.rdbModificar.Location = new System.Drawing.Point(525, 286);
            this.rdbModificar.Name = "rdbModificar";
            this.rdbModificar.Size = new System.Drawing.Size(91, 24);
            this.rdbModificar.TabIndex = 8;
            this.rdbModificar.Text = "Modificar";
            this.rdbModificar.UseVisualStyleBackColor = true;
            this.rdbModificar.CheckedChanged += new System.EventHandler(this.rdbModificar_CheckedChanged);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Enabled = false;
            this.btnEliminar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminar.Location = new System.Drawing.Point(535, 353);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(80, 25);
            this.btnEliminar.TabIndex = 9;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox4.Image = global::Ej_Interfaz_Proyecto.Properties.Resources.btn_cer_normal2;
            this.pictureBox4.Location = new System.Drawing.Point(591, 6);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(29, 28);
            this.pictureBox4.TabIndex = 16;
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
            this.pictureBox1.Size = new System.Drawing.Size(630, 2);
            this.pictureBox1.TabIndex = 17;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(264, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 20);
            this.label1.TabIndex = 18;
            this.label1.Text = "PROFESIÓN";
            // 
            // pictureBox5
            // 
            this.pictureBox5.BackColor = System.Drawing.Color.White;
            this.pictureBox5.Location = new System.Drawing.Point(16, 313);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(600, 5);
            this.pictureBox5.TabIndex = 19;
            this.pictureBox5.TabStop = false;
            // 
            // FrmProfesion_1280x1024
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(630, 400);
            this.Controls.Add(this.pictureBox5);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.rdbModificar);
            this.Controls.Add(this.rdbNuevo);
            this.Controls.Add(this.dgvProfesiones);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.label2);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmProfesion_1280x1024";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Profesión";
            this.Load += new System.EventHandler(this.FrmProfesion_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FrmProfesion_MouseDown);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProfesiones)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.DataGridView dgvProfesiones;
        private System.Windows.Forms.RadioButton rdbNuevo;
        private System.Windows.Forms.RadioButton rdbModificar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.PictureBox pictureBox5;
    }
}