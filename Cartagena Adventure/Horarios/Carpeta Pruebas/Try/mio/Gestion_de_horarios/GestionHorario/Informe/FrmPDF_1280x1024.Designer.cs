namespace Ej_Interfaz_Proyecto.Formularios_1280x1024
{
    partial class FrmPDF_1280x1024
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPDF_1280x1024));
            this.horaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.Generar_horarioDataSet = new Ej_Interfaz_Proyecto.Generar_horarioDataSet();
            this.informeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.horaTableAdapter = new Ej_Interfaz_Proyecto.Generar_horarioDataSetTableAdapters.horaTableAdapter();
            this.label11 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.informeTableAdapter = new Ej_Interfaz_Proyecto.Generar_horarioDataSetTableAdapters.informeTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.horaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Generar_horarioDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.informeBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.SuspendLayout();
            // 
            // horaBindingSource
            // 
            this.horaBindingSource.DataMember = "hora";
            this.horaBindingSource.DataSource = this.Generar_horarioDataSet;
            // 
            // Generar_horarioDataSet
            // 
            this.Generar_horarioDataSet.DataSetName = "Generar_horarioDataSet";
            this.Generar_horarioDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // informeBindingSource
            // 
            this.informeBindingSource.DataMember = "informe";
            this.informeBindingSource.DataSource = this.Generar_horarioDataSet;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.reportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.horaBindingSource;
            reportDataSource2.Name = "DataSet2";
            reportDataSource2.Value = this.informeBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Ej_Interfaz_Proyecto.Reporte.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(12, 50);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(990, 425);
            this.reportViewer1.TabIndex = 0;
            // 
            // horaTableAdapter
            // 
            this.horaTableAdapter.ClearBeforeFill = true;
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(428, 9);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(193, 20);
            this.label11.TabIndex = 109;
            this.label11.Text = "REPORTE DE HORARIO";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.White;
            this.pictureBox2.Location = new System.Drawing.Point(-193, 38);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(2246, 2);
            this.pictureBox2.TabIndex = 108;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox4.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox4.Image = global::Ej_Interfaz_Proyecto.Properties.Resources.btn_cer_normal2;
            this.pictureBox4.Location = new System.Drawing.Point(973, 5);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(29, 28);
            this.pictureBox4.TabIndex = 111;
            this.pictureBox4.TabStop = false;
            this.pictureBox4.Click += new System.EventHandler(this.pictureBox4_Click);
            this.pictureBox4.MouseLeave += new System.EventHandler(this.pictureBox4_MouseLeave);
            this.pictureBox4.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox4_MouseMove);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Location = new System.Drawing.Point(3, 39);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1005, 453);
            this.groupBox1.TabIndex = 112;
            this.groupBox1.TabStop = false;
            // 
            // informeTableAdapter
            // 
            this.informeTableAdapter.ClearBeforeFill = true;
            // 
            // FrmPDF_1280x1024
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1014, 504);
            this.ControlBox = false;
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmPDF_1280x1024";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PDF";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmPDF_1280x1024_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FrmPDF_1280x1024_MouseDown);
            this.Resize += new System.EventHandler(this.FrmPDF_1280x1024_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.horaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Generar_horarioDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.informeBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private Generar_horarioDataSetTableAdapters.horaTableAdapter horaTableAdapter;
        private System.Windows.Forms.BindingSource horaBindingSource;
        private Generar_horarioDataSet Generar_horarioDataSet;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.BindingSource informeBindingSource;
        private Generar_horarioDataSetTableAdapters.informeTableAdapter informeTableAdapter;


    }
}