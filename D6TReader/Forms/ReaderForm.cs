using D6TReader.Controller;
using D6TReader.UserControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace D6TReader.Forms
{
    public partial class ReaderForm : Form
    {
        Controller.D6TReader _reader;
        Stream _fileStream;
        StreamWriter _writer;
        bool _canWrite = false;

        public ReaderForm()
        {
            InitializeComponent();
        }

        public ReaderForm(SerialPort port) : this()
        {
            _reader = new Controller.D6TReader(port);

        }

        public void UpdateRecord()
        {
            lbl_status.Text = _canWrite ? "GRABANDO" : "DETENIDO";
            lbl_status.ForeColor = _canWrite ? Color.Red : Color.Black;
            bt_detener.Enabled = _canWrite;
            b_grabar.Enabled = !_canWrite;
        }

        public void UpdateSensitivity()
        {
            float sensitivity = (float)tb_sensibilidad.Value / 10.0f;
            lbl_sensitivity.Text = $"{sensitivity:0.0} C";
            ArrayPanelGroup.ArrayPanelDisplayActions.Sensitivity = sensitivity;
        }

        private void ReaderForm_Load(object sender, EventArgs e)
        {
            a_panel.SetSize(4, 4);

        }

        private async void SerialTimer_Tick(object sender, EventArgs e)
        {
            float[] data = (await _reader.GetData()).ToArray();

            a_panel.SetValues(data);

            if (_canWrite)
            {
                Control.FunctionExtensions.Try(() => Write(data), ex => Console.WriteLine(ex.Message) );
            }
        }


        private async void Write(IEnumerable<float> temps)
        {
            string toWrite = $"{DateTime.Now.Ticks}\t{string.Join("\t", temps)}\n";
            await _writer.WriteAsync(toWrite);
            await _writer.FlushAsync();
        }

        private void b_grabar_Click(object sender, EventArgs e)
        {
            StartRec();
            UpdateRecord();
        }

        private void StartRec()
        {
            Stream st = DataController.SaveFile();
            if (st != null)
            {
                _writer = new StreamWriter(st);
                _canWrite = true;
            }
        }

        private void StopRec()
        {
            _canWrite = false;
            _writer.Dispose();
            _writer = null;
        }

        private void diferenciaPromedioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            a_panel.SetPanelAction = ArrayPanelGroup.ArrayPanelDisplayActions.AverageDifference;
        }

        private void absolutoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            a_panel.SetPanelAction = ArrayPanelGroup.ArrayPanelDisplayActions.Absolute;
        }

        private void tb_sensibilidad_ValueChanged(object sender, EventArgs e)
        {
            UpdateSensitivity();
        }

        private void bt_detener_Click(object sender, EventArgs e)
        {
            StopRec();
            UpdateRecord();
        }

        private void umbralToolStripMenuItem_Click(object sender, EventArgs e)
        {
            a_panel.SetPanelAction = ArrayPanelGroup.ArrayPanelDisplayActions.Umbral;
        }

        private void tstb_sensibilidad_TextChanged(object sender, EventArgs e)
        {
            if(ValidateInput(tstb_sensibilidad.Text))
            {
                ArrayPanelGroup.ArrayPanelDisplayActions.Sensitivity = float.Parse(tstb_sensibilidad.Text);
            }
        }

        private void tstb_desde_TextChanged(object sender, EventArgs e)
        {
            if (ValidateInput(tstb_desde.Text))
            {
                ArrayPanelGroup.ArrayPanelDisplayActions.LowUmbral = float.Parse(tstb_desde.Text);
            }
        }

        private void tstb_hasta_TextChanged(object sender, EventArgs e)
        {
            if (ValidateInput(tstb_hasta.Text))
            {
                ArrayPanelGroup.ArrayPanelDisplayActions.HighUmbral = float.Parse(tstb_hasta.Text);
            }
        }

        private bool ValidateInput(string str)
        {
            return Regex.IsMatch(str, "[+-]?([0-9]*[.])?[0-9]+");
        }
    }
}
