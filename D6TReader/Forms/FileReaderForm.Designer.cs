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
            this.trb_time = new System.Windows.Forms.TrackBar();
            this.a_panel = new D6TReader.UserControls.ArrayPanelGroup();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.modoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.diferenciaPromedioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.absolutoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lbl_sensitivity = new System.Windows.Forms.Label();
            this.tb_sensibilidad = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.lbl_hora = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.trb_time)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tb_sensibilidad)).BeginInit();
            this.SuspendLayout();
            // 
            // trb_time
            // 
            this.trb_time.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.trb_time.Location = new System.Drawing.Point(12, 564);
            this.trb_time.Maximum = 30;
            this.trb_time.Name = "trb_time";
            this.trb_time.Size = new System.Drawing.Size(670, 45);
            this.trb_time.TabIndex = 0;
            this.trb_time.ValueChanged += new System.EventHandler(this.trb_time_ValueChanged);
            // 
            // a_panel
            // 
            this.a_panel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.a_panel.Location = new System.Drawing.Point(12, 79);
            this.a_panel.Name = "a_panel";
            this.a_panel.SetPanelAction = null;
            this.a_panel.Size = new System.Drawing.Size(670, 479);
            this.a_panel.TabIndex = 1;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.modoToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(694, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // modoToolStripMenuItem
            // 
            this.modoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.diferenciaPromedioToolStripMenuItem,
            this.absolutoToolStripMenuItem});
            this.modoToolStripMenuItem.Name = "modoToolStripMenuItem";
            this.modoToolStripMenuItem.Size = new System.Drawing.Size(51, 20);
            this.modoToolStripMenuItem.Text = "Modo";
            // 
            // diferenciaPromedioToolStripMenuItem
            // 
            this.diferenciaPromedioToolStripMenuItem.Name = "diferenciaPromedioToolStripMenuItem";
            this.diferenciaPromedioToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.diferenciaPromedioToolStripMenuItem.Text = "Diferencia promedio";
            this.diferenciaPromedioToolStripMenuItem.Click += new System.EventHandler(this.diferenciaPromedioToolStripMenuItem_Click);
            // 
            // absolutoToolStripMenuItem
            // 
            this.absolutoToolStripMenuItem.Name = "absolutoToolStripMenuItem";
            this.absolutoToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.absolutoToolStripMenuItem.Text = "Absoluto";
            this.absolutoToolStripMenuItem.Click += new System.EventHandler(this.absolutoToolStripMenuItem_Click);
            // 
            // lbl_sensitivity
            // 
            this.lbl_sensitivity.AutoSize = true;
            this.lbl_sensitivity.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_sensitivity.Location = new System.Drawing.Point(665, 35);
            this.lbl_sensitivity.Name = "lbl_sensitivity";
            this.lbl_sensitivity.Size = new System.Drawing.Size(25, 13);
            this.lbl_sensitivity.TabIndex = 11;
            this.lbl_sensitivity.Text = "0.8";
            // 
            // tb_sensibilidad
            // 
            this.tb_sensibilidad.Location = new System.Drawing.Point(453, 27);
            this.tb_sensibilidad.Maximum = 30;
            this.tb_sensibilidad.Name = "tb_sensibilidad";
            this.tb_sensibilidad.Size = new System.Drawing.Size(206, 45);
            this.tb_sensibilidad.TabIndex = 10;
            this.tb_sensibilidad.Value = 8;
            this.tb_sensibilidad.ValueChanged += new System.EventHandler(this.tb_sensibilidad_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(384, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Sensibilidad";
            // 
            // lbl_hora
            // 
            this.lbl_hora.AutoSize = true;
            this.lbl_hora.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_hora.ForeColor = System.Drawing.Color.Red;
            this.lbl_hora.Location = new System.Drawing.Point(48, 35);
            this.lbl_hora.Name = "lbl_hora";
            this.lbl_hora.Size = new System.Drawing.Size(75, 13);
            this.lbl_hora.TabIndex = 12;
            this.lbl_hora.Text = "Sensibilidad";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Hora:";
            // 
            // FileReaderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(694, 621);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbl_hora);
            this.Controls.Add(this.lbl_sensitivity);
            this.Controls.Add(this.tb_sensibilidad);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.a_panel);
            this.Controls.Add(this.trb_time);
            this.Name = "FileReaderForm";
            this.Text = "FileReaderForm";
            this.Load += new System.EventHandler(this.FileReaderForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.trb_time)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tb_sensibilidad)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TrackBar trb_time;
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
    }
}