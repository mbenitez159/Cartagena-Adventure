namespace Ej_Interfaz_Proyecto.Formularios_1280x1024
{
    partial class FrmArea_1280x1024
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
            this.label1 = new System.Windows.Forms.Label();
            this.dgvArea = new System.Windows.Forms.DataGridView();
            this.cod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtNombreArea = new System.Windows.Forms.TextBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.rdbNuevo = new System.Windows.Forms.RadioButton();
            this.rdbModificar = new System.Windows.Forms.RadioButton();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvArea)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(13, 325);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre del Área";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // dgvArea
            // 
            this.dgvArea.AllowUserToAddRows = false;
            this.dgvArea.AllowUserToDeleteRows = false;
            this.dgvArea.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvArea.BackgroundColor = System.Drawing.Color.White;
            this.dgvArea.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvArea.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cod,
            this.nom});
            this.dgvArea.Location = new System.Drawing.Point(16, 58);
            this.dgvArea.Name = "dgvArea";
            this.dgvArea.ReadOnly = true;
            this.dgvArea.Size = new System.Drawing.Size(599, 221);
            this.dgvArea.TabIndex = 1;
            this.dgvArea.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvArea_CellContentClick);
            this.dgvArea.SelectionChanged += new System.EventHandler(this.dgvArea_SelectionChanged);
            // 
            // cod
            // 
            this.cod.HeaderText = "Código";
            this.cod.Name = "cod";
            this.cod.ReadOnly = true;
            this.cod.Visible = false;
            // 
            // nom
            // 
            this.nom.HeaderText = "Nombre";
            this.nom.Name = "nom";
            this.nom.ReadOnly = true;
            // 
            // txtNombreArea
            // 
            this.txtNombreArea.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombreArea.Location = new System.Drawing.Point(16, 350);
            this.txtNombreArea.Name = "txtNombreArea";
            this.txtNombreArea.Size = new System.Drawing.Size(350, 26);
            this.txtNombreArea.TabIndex = 2;
            this.txtNombreArea.TextChanged += new System.EventHandler(this.txtNombreArea_TextChanged);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.Location = new System.Drawing.Point(435, 355);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(80, 25);
            this.btnGuardar.TabIndex = 3;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Enabled = false;
            this.btnEliminar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminar.Location = new System.Drawing.Point(535, 355);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(80, 25);
            this.btnEliminar.TabIndex = 4;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
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
            this.rdbNuevo.TabIndex = 6;
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
            this.rdbModificar.TabIndex = 7;
            this.rdbModificar.Text = "Modificar";
            this.rdbModificar.UseVisualStyleBackColor = true;
            this.rdbModificar.CheckedChanged += new System.EventHandler(this.rdbModificar_CheckedChanged);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::Ej_Interfaz_Proyecto.Properties.Resources.ico_are;
            this.pictureBox2.Location = new System.Drawing.Point(20, 3);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(34, 34);
            this.pictureBox2.TabIndex = 15;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox4.Image = global::Ej_Interfaz_Proyecto.Properties.Resources.btn_cer_normal2;
            this.pictureBox4.Location = new System.Drawing.Point(591, 6);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(29, 28);
            this.pictureBox4.TabIndex = 14;
            this.pictureBox4.TabStop = false;
            this.pictureBox4.Click += new System.EventHandler(this.pictureBox4_Click);
            this.pictureBox4.MouseLeave += new System.EventHandler(this.pictureBox4_MouseLeave);
            this.pictureBox4.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox4_MouseMove);
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox3.Image = global::Ej_Interfaz_Proyecto.Properties.Resources.btn_min_normal2;
            this.pictureBox3.Location = new System.Drawing.Point(552, 6);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(28, 28);
            this.pictureBox3.TabIndex = 13;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Click += new System.EventHandler(this.pictureBox3_Click);
            this.pictureBox3.MouseLeave += new System.EventHandler(this.pictureBox3_MouseLeave);
            this.pictureBox3.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox3_MouseMove);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.Location = new System.Drawing.Point(0, 40);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(630, 2);
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(283, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 20);
            this.label2.TabIndex = 16;
            this.label2.Text = "ÁREAS";
            // 
            // pictureBox5
            // 
            this.pictureBox5.BackColor = System.Drawing.Color.White;
            this.pictureBox5.Location = new System.Drawing.Point(16, 313);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(600, 5);
            this.pictureBox5.TabIndex = 17;
            this.pictureBox5.TabStop = false;
            this.pictureBox5.Click += new System.EventHandler(this.pictureBox5_Click);
            // 
            // FrmArea
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(630, 400);
            this.Controls.Add(this.pictureBox5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.rdbModificar);
            this.Controls.Add(this.rdbNuevo);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.txtNombreArea);
            this.Controls.Add(this.dgvArea);
            this.Controls.Add(this.label1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.Name = "FrmArea";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Area de formación";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmArea_FormClosed);
            this.Load += new System.EventHandler(this.FrmArea_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FrmArea_MouseDown);
            ((System.ComponentModel.ISupportInitialize)(this.dgvArea)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvArea;
        private System.Windows.Forms.DataGridViewTextBoxColumn cod;
        private System.Windows.Forms.DataGridViewTextBoxColumn nom;
        private System.Windows.Forms.TextBox txtNombreArea;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.RadioButton rdbNuevo;
        private System.Windows.Forms.RadioButton rdbModificar;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox5;
    }
}