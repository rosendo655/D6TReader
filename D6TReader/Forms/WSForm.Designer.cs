namespace D6TReader.Forms
{
    partial class WSForm
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
            this.a_panel = new D6TReader.UserControls.ArrayPanelGroup();
            this.SuspendLayout();
            // 
            // a_panel
            // 
            this.a_panel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.a_panel.Location = new System.Drawing.Point(13, 41);
            this.a_panel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.a_panel.Name = "a_panel";
            this.a_panel.SetPanelAction = null;
            this.a_panel.Size = new System.Drawing.Size(791, 553);
            this.a_panel.TabIndex = 0;
            // 
            // WSForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(825, 607);
            this.Controls.Add(this.a_panel);
            this.Name = "WSForm";
            this.Text = "WSForm";
            this.Load += new System.EventHandler(this.WSForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private UserControls.ArrayPanelGroup a_panel;
    }
}