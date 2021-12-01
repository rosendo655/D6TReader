namespace D6TReader.Forms
{
    partial class FileReaderForm
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.modoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.diferenciaPromedioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.absolutoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.guardarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clasificarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lbl_sensitivity = new System.Windows.Forms.Label();
            this.tb_sensibilidad = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.lbl_hora = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cb_caida = new System.Windows.Forms.CheckBox();
            this.numeric = new System.Windows.Forms.NumericUpDown();
            this.a_panel = new D6TReader.UserControls.ArrayPanelGroup();
            this.tb_file = new System.Windows.Forms.TextBox();
            this.b_create = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tb_sensibilidad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeric)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.modoToolStripMenuItem,
            this.guardarToolStripMenuItem,
            this.clasificarToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1001, 28);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // modoToolStripMenuItem
            // 
            this.modoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.diferenciaPromedioToolStripMenuItem,
            this.absolutoToolStripMenuItem});
            this.modoToolStripMenuItem.Name = "modoToolStripMenuItem";
            this.modoToolStripMenuItem.Size = new System.Drawing.Size(63, 24);
            this.modoToolStripMenuItem.Text = "Modo";
            // 
            // diferenciaPromedioToolStripMenuItem
            // 
            this.diferenciaPromedioToolStripMenuItem.Name = "diferenciaPromedioToolStripMenuItem";
            this.diferenciaPromedioToolStripMenuItem.Size = new System.Drawing.Size(230, 26);
            this.diferenciaPromedioToolStripMenuItem.Text = "Diferencia promedio";
            this.diferenciaPromedioToolStripMenuItem.Click += new System.EventHandler(this.diferenciaPromedioToolStripMenuItem_Click);
            // 
            // absolutoToolStripMenuItem
            // 
            this.absolutoToolStripMenuItem.Name = "absolutoToolStripMenuItem";
            this.absolutoToolStripMenuItem.Size = new System.Drawing.Size(230, 26);
            this.absolutoToolStripMenuItem.Text = "Absoluto";
            this.absolutoToolStripMenuItem.Click += new System.EventHandler(this.absolutoToolStripMenuItem_Click);
            // 
            // guardarToolStripMenuItem
            // 
            this.guardarToolStripMenuItem.Name = "guardarToolStripMenuItem";
            this.guardarToolStripMenuItem.Size = new System.Drawing.Size(76, 24);
            this.guardarToolStripMenuItem.Text = "Guardar";
            this.guardarToolStripMenuItem.Click += new System.EventHandler(this.guardarToolStripMenuItem_Click);
            // 
            // clasificarToolStripMenuItem
            // 
            this.clasificarToolStripMenuItem.Name = "clasificarToolStripMenuItem";
            this.clasificarToolStripMenuItem.Size = new System.Drawing.Size(83, 24);
            this.clasificarToolStripMenuItem.Text = "Clasificar";
            this.clasificarToolStripMenuItem.Click += new System.EventHandler(this.clasificarToolStripMenuItem_Click);
            // 
            // lbl_sensitivity
            // 
            this.lbl_sensitivity.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_sensitivity.AutoSize = true;
            this.lbl_sensitivity.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_sensitivity.Location = new System.Drawing.Point(944, 42);
            this.lbl_sensitivity.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_sensitivity.Name = "lbl_sensitivity";
            this.lbl_sensitivity.Size = new System.Drawing.Size(31, 17);
            this.lbl_sensitivity.TabIndex = 11;
            this.lbl_sensitivity.Text = "0.8";
            // 
            // tb_sensibilidad
            // 
            this.tb_sensibilidad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_sensibilidad.Location = new System.Drawing.Point(670, 33);
            this.tb_sensibilidad.Margin = new System.Windows.Forms.Padding(4);
            this.tb_sensibilidad.Maximum = 30;
            this.tb_sensibilidad.Name = "tb_sensibilidad";
            this.tb_sensibilidad.Size = new System.Drawing.Size(275, 56);
            this.tb_sensibilidad.TabIndex = 10;
            this.tb_sensibilidad.Value = 8;
            this.tb_sensibilidad.ValueChanged += new System.EventHandler(this.tb_sensibilidad_ValueChanged);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(578, 43);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 17);
            this.label1.TabIndex = 9;
            this.label1.Text = "Sensibilidad";
            // 
            // lbl_hora
            // 
            this.lbl_hora.AutoSize = true;
            this.lbl_hora.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_hora.ForeColor = System.Drawing.Color.Red;
            this.lbl_hora.Location = new System.Drawing.Point(64, 43);
            this.lbl_hora.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_hora.Name = "lbl_hora";
            this.lbl_hora.Size = new System.Drawing.Size(96, 17);
            this.lbl_hora.TabIndex = 12;
            this.lbl_hora.Text = "Sensibilidad";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 43);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 17);
            this.label2.TabIndex = 13;
            this.label2.Text = "Hora:";
            // 
            // cb_caida
            // 
            this.cb_caida.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cb_caida.AutoSize = true;
            this.cb_caida.Location = new System.Drawing.Point(304, 721);
            this.cb_caida.Name = "cb_caida";
            this.cb_caida.Size = new System.Drawing.Size(191, 21);
            this.cb_caida.TabIndex = 14;
            this.cb_caida.Text = "En este cuadro hay caida";
            this.cb_caida.UseVisualStyleBackColor = true;
            this.cb_caida.CheckedChanged += new System.EventHandler(this.cb_caida_CheckedChanged);
            // 
            // numeric
            // 
            this.numeric.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.numeric.Location = new System.Drawing.Point(16, 721);
            this.numeric.Name = "numeric";
            this.numeric.Size = new System.Drawing.Size(268, 22);
            this.numeric.TabIndex = 15;
            this.numeric.ValueChanged += new System.EventHandler(this.numeric_ValueChanged);
            this.numeric.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numeric_KeyPress);
            // 
            // a_panel
            // 
            this.a_panel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.a_panel.Location = new System.Drawing.Point(16, 65);
            this.a_panel.Margin = new System.Windows.Forms.Padding(5);
            this.a_panel.Name = "a_panel";
            this.a_panel.SetPanelAction = null;
            this.a_panel.Size = new System.Drawing.Size(795, 648);
            this.a_panel.TabIndex = 1;
            // 
            // tb_file
            // 
            this.tb_file.Location = new System.Drawing.Point(819, 96);
            this.tb_file.Name = "tb_file";
            this.tb_file.Size = new System.Drawing.Size(170, 22);
            this.tb_file.TabIndex = 16;
            // 
            // b_create
            // 
            this.b_create.Location = new System.Drawing.Point(819, 125);
            this.b_create.Name = "b_create";
            this.b_create.Size = new System.Drawing.Size(170, 23);
            this.b_create.TabIndex = 17;
            this.b_create.Text = "Start";
            this.b_create.UseVisualStyleBackColor = true;
            this.b_create.Click += new System.EventHandler(this.b_create_Click);
            // 
            // FileReaderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1001, 755);
            this.Controls.Add(this.b_create);
            this.Controls.Add(this.tb_file);
            this.Controls.Add(this.numeric);
            this.Controls.Add(this.cb_caida);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbl_hora);
            this.Controls.Add(this.lbl_sensitivity);
            this.Controls.Add(this.tb_sensibilidad);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.a_panel);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FileReaderForm";
            this.Text = "FileReaderForm";
            this.Load += new System.EventHandler(this.FileReaderForm_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FileReaderForm_KeyPress);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tb_sensibilidad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeric)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private UserControls.ArrayPanelGroup a_panel;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem modoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem diferenciaPromedioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem absolutoToolStripMenuItem;
        private System.Windows.Forms.Label lbl_sensitivity;
        private System.Windows.Forms.TrackBar tb_sensibilidad;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbl_hora;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox cb_caida;
        private System.Windows.Forms.ToolStripMenuItem guardarToolStripMenuItem;
        private System.Windows.Forms.NumericUpDown numeric;
        private System.Windows.Forms.ToolStripMenuItem clasificarToolStripMenuItem;
        private System.Windows.Forms.TextBox tb_file;
        private System.Windows.Forms.Button b_create;
    }
}