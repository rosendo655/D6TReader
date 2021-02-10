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
            this.lv_caidas_registradas = new System.Windows.Forms.ListView();
            this.label2 = new System.Windows.Forms.Label();
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
            this.b_grabar.Location = new System.Drawing.Point(16, 33);
            this.b_grabar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.b_grabar.Name = "b_grabar";
            this.b_grabar.Size = new System.Drawing.Size(145, 36);
            this.b_grabar.TabIndex = 1;
            this.b_grabar.Text = "Grabar";
            this.b_grabar.UseVisualStyleBackColor = true;
            this.b_grabar.Click += new System.EventHandler(this.b_grabar_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.modoToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1131, 28);
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
            this.modoToolStripMenuItem.Size = new System.Drawing.Size(63, 24);
            this.modoToolStripMenuItem.Text = "Modo";
            // 
            // diferenciaPromedioToolStripMenuItem
            // 
            this.diferenciaPromedioToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sensibilidadAPromToolStripMenuItem});
            this.diferenciaPromedioToolStripMenuItem.Name = "diferenciaPromedioToolStripMenuItem";
            this.diferenciaPromedioToolStripMenuItem.Size = new System.Drawing.Size(230, 26);
            this.diferenciaPromedioToolStripMenuItem.Text = "Diferencia promedio";
            this.diferenciaPromedioToolStripMenuItem.Click += new System.EventHandler(this.diferenciaPromedioToolStripMenuItem_Click);
            // 
            // sensibilidadAPromToolStripMenuItem
            // 
            this.sensibilidadAPromToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tstb_sensibilidad});
            this.sensibilidadAPromToolStripMenuItem.Name = "sensibilidadAPromToolStripMenuItem";
            this.sensibilidadAPromToolStripMenuItem.Size = new System.Drawing.Size(228, 26);
            this.sensibilidadAPromToolStripMenuItem.Text = "Sensibilidad a prom.";
            // 
            // tstb_sensibilidad
            // 
            this.tstb_sensibilidad.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.tstb_sensibilidad.Name = "tstb_sensibilidad";
            this.tstb_sensibilidad.Size = new System.Drawing.Size(100, 27);
            this.tstb_sensibilidad.Text = "0.8";
            this.tstb_sensibilidad.TextChanged += new System.EventHandler(this.tstb_sensibilidad_TextChanged);
            // 
            // absolutoToolStripMenuItem
            // 
            this.absolutoToolStripMenuItem.Name = "absolutoToolStripMenuItem";
            this.absolutoToolStripMenuItem.Size = new System.Drawing.Size(230, 26);
            this.absolutoToolStripMenuItem.Text = "Absoluto";
            this.absolutoToolStripMenuItem.Click += new System.EventHandler(this.absolutoToolStripMenuItem_Click);
            // 
            // umbralToolStripMenuItem
            // 
            this.umbralToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.hastaToolStripMenuItem});
            this.umbralToolStripMenuItem.Name = "umbralToolStripMenuItem";
            this.umbralToolStripMenuItem.Size = new System.Drawing.Size(230, 26);
            this.umbralToolStripMenuItem.Text = "Umbral";
            this.umbralToolStripMenuItem.Click += new System.EventHandler(this.umbralToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tstb_desde});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(134, 26);
            this.toolStripMenuItem1.Text = "Desde";
            // 
            // tstb_desde
            // 
            this.tstb_desde.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.tstb_desde.Name = "tstb_desde";
            this.tstb_desde.Size = new System.Drawing.Size(100, 27);
            this.tstb_desde.Text = "0";
            this.tstb_desde.TextChanged += new System.EventHandler(this.tstb_desde_TextChanged);
            // 
            // hastaToolStripMenuItem
            // 
            this.hastaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tstb_hasta});
            this.hastaToolStripMenuItem.Name = "hastaToolStripMenuItem";
            this.hastaToolStripMenuItem.Size = new System.Drawing.Size(134, 26);
            this.hastaToolStripMenuItem.Text = "Hasta";
            // 
            // tstb_hasta
            // 
            this.tstb_hasta.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.tstb_hasta.Name = "tstb_hasta";
            this.tstb_hasta.Size = new System.Drawing.Size(100, 27);
            this.tstb_hasta.Text = "70";
            this.tstb_hasta.TextChanged += new System.EventHandler(this.tstb_hasta_TextChanged);
            // 
            // bt_detener
            // 
            this.bt_detener.Location = new System.Drawing.Point(183, 33);
            this.bt_detener.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.bt_detener.Name = "bt_detener";
            this.bt_detener.Size = new System.Drawing.Size(145, 36);
            this.bt_detener.TabIndex = 4;
            this.bt_detener.Text = "Detener";
            this.bt_detener.UseVisualStyleBackColor = true;
            this.bt_detener.Click += new System.EventHandler(this.bt_detener_Click);
            // 
            // lbl_status
            // 
            this.lbl_status.AutoSize = true;
            this.lbl_status.Location = new System.Drawing.Point(351, 43);
            this.lbl_status.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_status.Name = "lbl_status";
            this.lbl_status.Size = new System.Drawing.Size(31, 17);
            this.lbl_status.TabIndex = 5;
            this.lbl_status.Text = "stat";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(472, 43);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 17);
            this.label1.TabIndex = 6;
            this.label1.Text = "Sensibilidad";
            // 
            // tb_sensibilidad
            // 
            this.tb_sensibilidad.Location = new System.Drawing.Point(564, 33);
            this.tb_sensibilidad.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tb_sensibilidad.Maximum = 30;
            this.tb_sensibilidad.Name = "tb_sensibilidad";
            this.tb_sensibilidad.Size = new System.Drawing.Size(275, 56);
            this.tb_sensibilidad.TabIndex = 7;
            this.tb_sensibilidad.Value = 8;
            this.tb_sensibilidad.ValueChanged += new System.EventHandler(this.tb_sensibilidad_ValueChanged);
            // 
            // lbl_sensitivity
            // 
            this.lbl_sensitivity.AutoSize = true;
            this.lbl_sensitivity.Location = new System.Drawing.Point(847, 43);
            this.lbl_sensitivity.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_sensitivity.Name = "lbl_sensitivity";
            this.lbl_sensitivity.Size = new System.Drawing.Size(28, 17);
            this.lbl_sensitivity.TabIndex = 8;
            this.lbl_sensitivity.Text = "0.8";
            // 
            // lv_caidas_registradas
            // 
            this.lv_caidas_registradas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lv_caidas_registradas.HideSelection = false;
            this.lv_caidas_registradas.Location = new System.Drawing.Point(901, 73);
            this.lv_caidas_registradas.Name = "lv_caidas_registradas";
            this.lv_caidas_registradas.Size = new System.Drawing.Size(218, 761);
            this.lv_caidas_registradas.TabIndex = 9;
            this.lv_caidas_registradas.UseCompatibleStateImageBehavior = false;
            this.lv_caidas_registradas.View = System.Windows.Forms.View.List;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(898, 43);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(126, 17);
            this.label2.TabIndex = 10;
            this.label2.Text = "Caidas registradas";
            // 
            // a_panel
            // 
            this.a_panel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.a_panel.Location = new System.Drawing.Point(4, 73);
            this.a_panel.Margin = new System.Windows.Forms.Padding(5);
            this.a_panel.Name = "a_panel";
            this.a_panel.SetPanelAction = null;
            this.a_panel.Size = new System.Drawing.Size(871, 754);
            this.a_panel.TabIndex = 2;
            // 
            // ReaderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1131, 846);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lv_caidas_registradas);
            this.Controls.Add(this.lbl_sensitivity);
            this.Controls.Add(this.tb_sensibilidad);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbl_status);
            this.Controls.Add(this.bt_detener);
            this.Controls.Add(this.a_panel);
            this.Controls.Add(this.b_grabar);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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
        private System.Windows.Forms.ListView lv_caidas_registradas;
        private System.Windows.Forms.Label label2;
    }
}