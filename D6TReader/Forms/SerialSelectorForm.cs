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

            tb_baudRate.Text = "9600";
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
            var file = DataController.OpenFile();
            
            if (file == default) return;

            FileReaderForm form = new FileReaderForm(file.Item1,file.Item2);

            this.Visible = false;

            form.Activate();
            form.Visible = true;

            form.FormClosed += (sen, ev) =>
            {
                this.Visible = true;
            };
        }

        private void OpenOverall()
        {
            var file = DataController.OpenFile();

            if (file == default) return;

            FileOverallViewer form = new FileOverallViewer(file.Item1, file.Item2);

            this.Visible = false;

            form.Activate();
            form.Visible = true;

            form.FormClosed += (sen, ev) =>
            {
                this.Visible = true;
            };
        }

        private void ws_button_Click(object sender, EventArgs e)
        {
            WSForm form = new WSForm();

            this.Visible = false;

            form.Activate();
            form.Visible = true;

            form.FormClosed += (sen, ev) =>
            {
                this.Visible = true;
            };
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenOverall();
        }
    }
}
