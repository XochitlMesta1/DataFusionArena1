namespace DataFusionArena1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            btnMostrarDatos = new Button();
            lblCategoria = new Label();
            txtCategoria = new TextBox();
            txtBuscarID = new TextBox();
            btnAgrupar = new Button();
            btnOrdenar = new Button();
            btnDuplicados = new Button();
            btnGrafica = new Button();
            btnBuscarId = new Button();
            btnFiltrar = new Button();
            btnCargar = new Button();
            dgvListaDatos = new DataGridView();
            chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)dgvListaDatos).BeginInit();
            ((System.ComponentModel.ISupportInitialize)chart1).BeginInit();
            SuspendLayout();
            // 
            // btnMostrarDatos
            // 
            btnMostrarDatos.Location = new Point(84, 420);
            btnMostrarDatos.Name = "btnMostrarDatos";
            btnMostrarDatos.Size = new Size(183, 43);
            btnMostrarDatos.TabIndex = 25;
            btnMostrarDatos.Text = "Mostrar Datos";
            btnMostrarDatos.UseVisualStyleBackColor = true;
            btnMostrarDatos.Click += btnMostrarDatos_Click;
            // 
            // lblCategoria
            // 
            lblCategoria.AutoSize = true;
            lblCategoria.Location = new Point(139, 230);
            lblCategoria.Name = "lblCategoria";
            lblCategoria.Size = new Size(88, 25);
            lblCategoria.TabIndex = 24;
            lblCategoria.Text = "Categoria";
            // 
            // txtCategoria
            // 
            txtCategoria.Location = new Point(65, 269);
            txtCategoria.Name = "txtCategoria";
            txtCategoria.Size = new Size(255, 31);
            txtCategoria.TabIndex = 23;
            // 
            // txtBuscarID
            // 
            txtBuscarID.Location = new Point(176, 145);
            txtBuscarID.Name = "txtBuscarID";
            txtBuscarID.Size = new Size(192, 31);
            txtBuscarID.TabIndex = 22;
            // 
            // btnAgrupar
            // 
            btnAgrupar.Location = new Point(530, 40);
            btnAgrupar.Name = "btnAgrupar";
            btnAgrupar.Size = new Size(130, 43);
            btnAgrupar.TabIndex = 21;
            btnAgrupar.Text = "Agrupar";
            btnAgrupar.UseVisualStyleBackColor = true;
            btnAgrupar.Click += btnAgrupar_Click_1;
            // 
            // btnOrdenar
            // 
            btnOrdenar.Location = new Point(666, 40);
            btnOrdenar.Name = "btnOrdenar";
            btnOrdenar.Size = new Size(130, 43);
            btnOrdenar.TabIndex = 20;
            btnOrdenar.Text = "Ordenar";
            btnOrdenar.UseVisualStyleBackColor = true;
            btnOrdenar.Click += btnOrdenar_Click_1;
            // 
            // btnDuplicados
            // 
            btnDuplicados.Location = new Point(802, 40);
            btnDuplicados.Name = "btnDuplicados";
            btnDuplicados.Size = new Size(130, 43);
            btnDuplicados.TabIndex = 19;
            btnDuplicados.Text = "Duplicados";
            btnDuplicados.UseVisualStyleBackColor = true;
            btnDuplicados.Click += btnDuplicados_Click_1;
            // 
            // btnGrafica
            // 
            btnGrafica.Location = new Point(938, 40);
            btnGrafica.Name = "btnGrafica";
            btnGrafica.Size = new Size(130, 43);
            btnGrafica.TabIndex = 18;
            btnGrafica.Text = "Grafica";
            btnGrafica.UseVisualStyleBackColor = true;
            btnGrafica.Click += btnGrafica_Click_1;
            // 
            // btnBuscarId
            // 
            btnBuscarId.Location = new Point(40, 139);
            btnBuscarId.Name = "btnBuscarId";
            btnBuscarId.Size = new Size(130, 43);
            btnBuscarId.TabIndex = 17;
            btnBuscarId.Text = "Buscar ID";
            btnBuscarId.UseVisualStyleBackColor = true;
            btnBuscarId.Click += btnBuscarId_Click_1;
            // 
            // btnFiltrar
            // 
            btnFiltrar.Location = new Point(108, 338);
            btnFiltrar.Name = "btnFiltrar";
            btnFiltrar.Size = new Size(130, 43);
            btnFiltrar.TabIndex = 16;
            btnFiltrar.Text = "Filtrar";
            btnFiltrar.UseVisualStyleBackColor = true;
            btnFiltrar.Click += btnFiltrar_Click_1;
            // 
            // btnCargar
            // 
            btnCargar.Location = new Point(394, 40);
            btnCargar.Name = "btnCargar";
            btnCargar.Size = new Size(130, 43);
            btnCargar.TabIndex = 15;
            btnCargar.Text = "Cargar";
            btnCargar.UseVisualStyleBackColor = true;
            btnCargar.Click += btnCargar_Click;
            // 
            // dgvListaDatos
            // 
            dgvListaDatos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvListaDatos.Location = new Point(394, 109);
            dgvListaDatos.Name = "dgvListaDatos";
            dgvListaDatos.RowHeadersWidth = 62;
            dgvListaDatos.Size = new Size(680, 248);
            dgvListaDatos.TabIndex = 14;
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            chart1.Legends.Add(legend1);
            chart1.Location = new Point(394, 384);
            chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            chart1.Series.Add(series1);
            chart1.Size = new Size(680, 261);
            chart1.TabIndex = 26;
            chart1.Text = "chart1";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1157, 661);
            Controls.Add(chart1);
            Controls.Add(btnMostrarDatos);
            Controls.Add(lblCategoria);
            Controls.Add(txtCategoria);
            Controls.Add(txtBuscarID);
            Controls.Add(btnAgrupar);
            Controls.Add(btnOrdenar);
            Controls.Add(btnDuplicados);
            Controls.Add(btnGrafica);
            Controls.Add(btnBuscarId);
            Controls.Add(btnFiltrar);
            Controls.Add(btnCargar);
            Controls.Add(dgvListaDatos);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dgvListaDatos).EndInit();
            ((System.ComponentModel.ISupportInitialize)chart1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnMostrarDatos;
        private Label lblCategoria;
        private TextBox txtCategoria;
        private TextBox txtBuscarID;
        private Button btnAgrupar;
        private Button btnOrdenar;
        private Button btnDuplicados;
        private Button btnGrafica;
        private Button btnBuscarId;
        private Button btnFiltrar;
        private Button btnCargar;
        private DataGridView dgvListaDatos;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
    }
}
