namespace Ej_Interfaz_Proyecto.Formularios_1280x1024
{
    partial class FrmInicioSesion_1280x1024
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
            this.Texto = new System.Windows.Forms.Label();
            this.NombreUsuario = new System.Windows.Forms.TextBox();
            this.Contraseña = new System.Windows.Forms.TextBox();
            this.Entrar = new System.Windows.Forms.Button();
            this.ImgContraseña = new System.Windows.Forms.PictureBox();
            this.ImgUsuario = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ImgContraseña)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImgUsuario)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // Texto
            // 
            this.Texto.AutoSize = true;
            this.Texto.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Texto.Location = new System.Drawing.Point(4, 9);
            this.Texto.Name = "Texto";
            this.Texto.Size = new System.Drawing.Size(150, 20);
            this.Texto.TabIndex = 6;
            this.Texto.Text = "INICIO DE SESIÓN";
            // 
            // NombreUsuario
            // 
            this.NombreUsuario.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.NombreUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NombreUsuario.Location = new System.Drawing.Point(178, 109);
            this.NombreUsuario.Multiline = true;
            this.NombreUsuario.Name = "NombreUsuario";
            this.NombreUsuario.Size = new System.Drawing.Size(157, 20);
            this.NombreUsuario.TabIndex = 13;
            this.NombreUsuario.Text = "Nombre de usuario";
            this.NombreUsuario.Enter += new System.EventHandler(this.NombreUsuario_Enter);
            this.NombreUsuario.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NombreUsuario_KeyPress);
            this.NombreUsuario.Leave += new System.EventHandler(this.NombreUsuario_Leave);
            // 
            // Contraseña
            // 
            this.Contraseña.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Contraseña.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Contraseña.Location = new System.Drawing.Point(178, 167);
            this.Contraseña.Name = "Contraseña";
            this.Contraseña.Size = new System.Drawing.Size(157, 15);
            this.Contraseña.TabIndex = 14;
            this.Contraseña.Text = "Contraseña";
            this.Contraseña.Enter += new System.EventHandler(this.Contraseña_Enter);
            this.Contraseña.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Contraseña_KeyPress);
            this.Contraseña.Leave += new System.EventHandler(this.Contraseña_Leave);
            // 
            // Entrar
            // 
            this.Entrar.Location = new System.Drawing.Point(140, 221);
            this.Entrar.Name = "Entrar";
            this.Entrar.Size = new System.Drawing.Size(201, 25);
            this.Entrar.TabIndex = 15;
            this.Entrar.Text = "Entrar";
            this.Entrar.UseVisualStyleBackColor = true;
            this.Entrar.Click += new System.EventHandler(this.Entrar_Click);
            // 
            // ImgContraseña
            // 
            this.ImgContraseña.Image = global::Ej_Interfaz_Proyecto.Properties.Resources.icn_can_normal;
            this.ImgContraseña.Location = new System.Drawing.Point(147, 163);
            this.ImgContraseña.Name = "ImgContraseña";
            this.ImgContraseña.Size = new System.Drawing.Size(20, 25);
            this.ImgContraseña.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.ImgContraseña.TabIndex = 12;
            this.ImgContraseña.TabStop = false;
            // 
            // ImgUsuario
            // 
            this.ImgUsuario.Image = global::Ej_Interfaz_Proyecto.Properties.Resources.icn_use_normal;
            this.ImgUsuario.Location = new System.Drawing.Point(151, 104);
            this.ImgUsuario.Name = "ImgUsuario";
            this.ImgUsuario.Size = new System.Drawing.Size(12, 27);
            this.ImgUsuario.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.ImgUsuario.TabIndex = 9;
            this.ImgUsuario.TabStop = false;
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = global::Ej_Interfaz_Proyecto.Properties.Resources.img_imp;
            this.pictureBox5.Location = new System.Drawing.Point(140, 160);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(201, 31);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox5.TabIndex = 11;
            this.pictureBox5.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::Ej_Interfaz_Proyecto.Properties.Resources.img_imp;
            this.pictureBox4.Location = new System.Drawing.Point(140, 102);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(201, 31);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox4.TabIndex = 10;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(0, 4);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(480, 37);
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(137, 276);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(185, 16);
            this.label1.TabIndex = 17;
            this.label1.Text = "Nombre de usuario incorrecto";
            this.label1.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(137, 260);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(139, 16);
            this.label2.TabIndex = 18;
            this.label2.Text = "Contraseña incorrecta";
            this.label2.Visible = false;
            // 
            // FrmInicioSesion_1280x1024
            // 
            this.AcceptButton = this.Entrar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Ej_Interfaz_Proyecto.Properties.Resources.bg_inp;
            this.ClientSize = new System.Drawing.Size(480, 301);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Entrar);
            this.Controls.Add(this.Contraseña);
            this.Controls.Add(this.NombreUsuario);
            this.Controls.Add(this.ImgContraseña);
            this.Controls.Add(this.ImgUsuario);
            this.Controls.Add(this.pictureBox5);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.Texto);
            this.Controls.Add(this.pictureBox2);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmInicioSesion_1280x1024";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmInicioSesionN";
            this.Load += new System.EventHandler(this.FrmInicioSesionN_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FrmInicioSesionN_MouseDown);
            ((System.ComponentModel.ISupportInitialize)(this.ImgContraseña)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImgUsuario)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label Texto;
        private System.Windows.Forms.PictureBox ImgUsuario;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.PictureBox ImgContraseña;
        private System.Windows.Forms.Button Entrar;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox NombreUsuario;
        public System.Windows.Forms.TextBox Contraseña;
    }
}