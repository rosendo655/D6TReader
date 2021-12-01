namespace D6TReader.Forms
{
    partial class SerialSelectorForm
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
            this.btn_accept = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cb_port = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_baudRate = new System.Windows.Forms.TextBox();
            this.b_open = new System.Windows.Forms.Button();
            this.ws_button = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_accept
            // 
            this.btn_accept.Location = new System.Drawing.Point(15, 216);
            this.btn_accept.Name = "btn_accept";
            this.btn_accept.Size = new System.Drawing.Size(227, 23);
            this.btn_accept.TabIndex = 0;
            this.btn_accept.Text = "Aceptar";
            this.btn_accept.UseVisualStyleBackColor = true;
            this.btn_accept.Click += new System.EventHandler(this.btn_accept_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Puerto";
            // 
            // cb_port
            // 
            this.cb_port.FormattingEnabled = true;
            this.cb_port.Location = new System.Drawing.Point(71, 10);
            this.cb_port.Name = "cb_port";
            this.cb_port.Size = new System.Drawing.Size(172, 21);
            this.cb_port.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "BaudRate";
            // 
            // tb_baudRate
            // 
            this.tb_baudRate.Location = new System.Drawing.Point(75, 43);
            this.tb_baudRate.Name = "tb_baudRate";
            this.tb_baudRate.Size = new System.Drawing.Size(168, 20);
            this.tb_baudRate.TabIndex = 4;
            // 
            // b_open
            // 
            this.b_open.Location = new System.Drawing.Point(16, 132);
            this.b_open.Name = "b_open";
            this.b_open.Size = new System.Drawing.Size(227, 23);
            this.b_open.TabIndex = 5;
            this.b_open.Text = "Abrir archivo";
            this.b_open.UseVisualStyleBackColor = true;
            this.b_open.Click += new System.EventHandler(this.b_open_Click);
            // 
            // ws_button
            // 
            this.ws_button.Location = new System.Drawing.Point(16, 162);
            this.ws_button.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ws_button.Name = "ws_button";
            this.ws_button.Size = new System.Drawing.Size(226, 19);
            this.ws_button.TabIndex = 6;
            this.ws_button.Text = "WebSocket";
            this.ws_button.UseVisualStyleBackColor = true;
            this.ws_button.Click += new System.EventHandler(this.ws_button_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(16, 187);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(227, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "Abrir archivo (general)";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // SerialSelectorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(255, 251);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.ws_button);
            this.Controls.Add(this.b_open);
            this.Controls.Add(this.tb_baudRate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cb_port);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_accept);
            this.Name = "SerialSelectorForm";
            this.Text = "SerialSelectorForm";
            this.Load += new System.EventHandler(this.SerialSelectorForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_accept;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cb_port;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tb_baudRate;
        private System.Windows.Forms.Button b_open;
        private System.Windows.Forms.Button ws_button;
        private System.Windows.Forms.Button button1;
    }
}