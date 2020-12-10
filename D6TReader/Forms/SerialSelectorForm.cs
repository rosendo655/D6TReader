using D6TReader.Controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace D6TReader.Forms
{
    public partial class SerialSelectorForm : Form
    {
        public SerialSelectorForm()
        {
            InitializeComponent();
        }

        private void SerialSelectorForm_Load(object sender, EventArgs e)
        {
            LoadForm();
        }
        
        private void btn_accept_Click(object sender, EventArgs e)
        {
            Accept();
        }

        private void b_open_Click(object sender, EventArgs e)
        {
            Open();
        }


        private void LoadForm()
        {
            cb_port.Items.Clear();
            cb_port.Items.AddRange(Controller.SerialController.Ports().ToArray());

            tb_baudRate.Text = "19200";
        }
        
        private void Accept()
        {
            var port = SerialController.GetPort(cb_port.Text, int.Parse(tb_baudRate.Text));

            ReaderForm form = new ReaderForm(port);

            this.Visible = false;

            form.Activate();
            form.Visible = true;

            form.FormClosed += (sen, ev) =>
            {
                this.Visible = true;
                port.Dispose();
                port = null;
            };
        }

        private void Open()
        {
            Stream file = DataController.OpenFile();

            if (file == null) return;

            FileReaderForm form = new FileReaderForm(file);

            this.Visible = false;

            form.Activate();
            form.Visible = true;

            form.FormClosed += (sen, ev) =>
            {
                this.Visible = true;
            };
        }


    }
}
