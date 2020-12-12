namespace D6TReader.Forms
{
    partial class ReaderForm
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
            this.SerialTimer = new System.Windows.Forms.Timer(this.components);
            this.b_grabar = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.modoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.diferenciaPromedioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sensibilidadAPromToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tstb_sensibilidad = new System.Windows.Forms.ToolStripTextBox();
            this.absolutoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.umbralToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.tstb_desde = new System.Windows.Forms.ToolStripTextBox();
            this.hastaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tstb_hasta = new System.Windows.Forms.ToolStripTextBox();
            this.bt_detener = new System.Windows.Forms.Button();
            this.lbl_status = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tb_sensibilidad = new System.Windows.Forms.TrackBar();
            this.lbl_sensitivity = new System.Windows.Forms.Label();
            this.a_panel = new D6TReader.UserControls.ArrayPanelGroup();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tb_sensibilidad)).BeginInit();
            this.SuspendLayout();
            // 
            // SerialTimer
            // 
            this.SerialTimer.Tick += new System.EventHandler(this.SerialTimer_Tick);
            // 
            // b_grabar
            // 
            this.b_grabar.Location = new System.Drawing.Point(12, 27);
            this.b_grabar.Name = "b_grabar";
            this.b_grabar.Size = new System.Drawing.Size(109, 29);
            this.b_grabar.TabIndex = 1;
            this.b_grabar.Text = "Grabar";
            this.b_grabar.UseVisualStyleBackColor = true;
            this.b_grabar.Click += new System.EventHandler(this.b_grabar_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.modoToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(707, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // modoToolStripMenuItem
            // 
            this.modoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.diferenciaPromedioToolStripMenuItem,
            this.absolutoToolStripMenuItem,
            this.umbralToolStripMenuItem});
            this.modoToolStripMenuItem.Name = "modoToolStripMenuItem";
            this.modoToolStripMenuItem.Size = new System.Drawing.Size(51, 20);
            this.modoToolStripMenuItem.Text = "Modo";
            // 
            // diferenciaPromedioToolStripMenuItem
            // 
            this.diferenciaPromedioToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sensibilidadAPromToolStripMenuItem});
            this.diferenciaPromedioToolStripMenuItem.Name = "diferenciaPromedioToolStripMenuItem";
            this.diferenciaPromedioToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.diferenciaPromedioToolStripMenuItem.Text = "Diferencia promedio";
            this.diferenciaPromedioToolStripMenuItem.Click += new System.EventHandler(this.diferenciaPromedioToolStripMenuItem_Click);
            // 
            // sensibilidadAPromToolStripMenuItem
            // 
            this.sensibilidadAPromToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tstb_sensibilidad});
            this.sensibilidadAPromToolStripMenuItem.Name = "sensibilidadAPromToolStripMenuItem";
            this.sensibilidadAPromToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.sensibilidadAPromToolStripMenuItem.Text = "Sensibilidad a prom.";
            // 
            // tstb_sensibilidad
            // 
            this.tstb_sensibilidad.Name = "tstb_sensibilidad";
            this.tstb_sensibilidad.Size = new System.Drawing.Size(100, 23);
            this.tstb_sensibilidad.Text = "0.8";
            this.tstb_sensibilidad.TextChanged += new System.EventHandler(this.tstb_sensibilidad_TextChanged);
            // 
            // absolutoToolStripMenuItem
            // 
            this.absolutoToolStripMenuItem.Name = "absolutoToolStripMenuItem";
            this.absolutoToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.absolutoToolStripMenuItem.Text = "Absoluto";
            this.absolutoToolStripMenuItem.Click += new System.EventHandler(this.absolutoToolStripMenuItem_Click);
            // 
            // umbralToolStripMenuItem
            // 
            this.umbralToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.hastaToolStripMenuItem});
            this.umbralToolStripMenuItem.Name = "umbralToolStripMenuItem";
            this.umbralToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.umbralToolStripMenuItem.Text = "Umbral";
            this.umbralToolStripMenuItem.Click += new System.EventHandler(this.umbralToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tstb_desde});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(106, 22);
            this.toolStripMenuItem1.Text = "Desde";
            // 
            // tstb_desde
            // 
            this.tstb_desde.Name = "tstb_desde";
            this.tstb_desde.Size = new System.Drawing.Size(100, 23);
            this.tstb_desde.Text = "0";
            this.tstb_desde.TextChanged += new System.EventHandler(this.tstb_desde_TextChanged);
            // 
            // hastaToolStripMenuItem
            // 
            this.hastaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tstb_hasta});
            this.hastaToolStripMenuItem.Name = "hastaToolStripMenuItem";
            this.hastaToolStripMenuItem.Size = new System.Drawing.Size(106, 22);
            this.hastaToolStripMenuItem.Text = "Hasta";
            // 
            // tstb_hasta
            // 
            this.tstb_hasta.Name = "tstb_hasta";
            this.tstb_hasta.Size = new System.Drawing.Size(100, 23);
            this.tstb_hasta.Text = "70";
            this.tstb_hasta.TextChanged += new System.EventHandler(this.tstb_hasta_TextChanged);
            // 
            // bt_detener
            // 
            this.bt_detener.Location = new System.Drawing.Point(137, 27);
            this.bt_detener.Name = "bt_detener";
            this.bt_detener.Size = new System.Drawing.Size(109, 29);
            this.bt_detener.TabIndex = 4;
            this.bt_detener.Text = "Detener";
            this.bt_detener.UseVisualStyleBackColor = true;
            this.bt_detener.Click += new System.EventHandler(this.bt_detener_Click);
            // 
            // lbl_status
            // 
            this.lbl_status.AutoSize = true;
            this.lbl_status.Location = new System.Drawing.Point(263, 35);
            this.lbl_status.Name = "lbl_status";
            this.lbl_status.Size = new System.Drawing.Size(24, 13);
            this.lbl_status.TabIndex = 5;
            this.lbl_status.Text = "stat";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(354, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Sensibilidad";
            // 
            // tb_sensibilidad
            // 
            this.tb_sensibilidad.Location = new System.Drawing.Point(423, 27);
            this.tb_sensibilidad.Maximum = 30;
            this.tb_sensibilidad.Name = "tb_sensibilidad";
            this.tb_sensibilidad.Size = new System.Drawing.Size(206, 45);
            this.tb_sensibilidad.TabIndex = 7;
            this.tb_sensibilidad.Value = 8;
            this.tb_sensibilidad.ValueChanged += new System.EventHandler(this.tb_sensibilidad_ValueChanged);
            // 
            // lbl_sensitivity
            // 
            this.lbl_sensitivity.AutoSize = true;
            this.lbl_sensitivity.Location = new System.Drawing.Point(635, 35);
            this.lbl_sensitivity.Name = "lbl_sensitivity";
            this.lbl_sensitivity.Size = new System.Drawing.Size(22, 13);
            this.lbl_sensitivity.TabIndex = 8;
            this.lbl_sensitivity.Text = "0.8";
            // 
            // a_panel
            // 
            this.a_panel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.a_panel.Location = new System.Drawing.Point(3, 59);
            this.a_panel.Name = "a_panel";
            this.a_panel.SetPanelAction = null;
            this.a_panel.Size = new System.Drawing.Size(692, 613);
            this.a_panel.TabIndex = 2;
            // 
            // ReaderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(707, 687);
            this.Controls.Add(this.lbl_sensitivity);
            this.Controls.Add(this.tb_sensibilidad);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbl_status);
            this.Controls.Add(this.bt_detener);
            this.Controls.Add(this.a_panel);
            this.Controls.Add(this.b_grabar);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "ReaderForm";
            this.Text = "ReaderForm";
            this.Load += new System.EventHandler(this.ReaderForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tb_sensibilidad)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer SerialTimer;
        private System.Windows.Forms.Button b_grabar;
        private UserControls.ArrayPanelGroup a_panel;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem modoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem diferenciaPromedioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem absolutoToolStripMenuItem;
        private System.Windows.Forms.Button bt_detener;
        private System.Windows.Forms.Label lbl_status;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TrackBar tb_sensibilidad;
        private System.Windows.Forms.Label lbl_sensitivity;
        private System.Windows.Forms.ToolStripMenuItem umbralToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripTextBox tstb_desde;
        private System.Windows.Forms.ToolStripMenuItem hastaToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox tstb_hasta;
        private System.Windows.Forms.ToolStripMenuItem sensibilidadAPromToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox tstb_sensibilidad;
    }
}