using D6TReader.UserControls;
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
    public partial class FileReaderForm : Form
    {
        private DisplayPanel[] _panels;
        private StreamReader _streamReader;
        private int _frameCount;
        private long[] _startPositions;
        private string _curLine;

        public FileReaderForm()
        {
            InitializeComponent();

            
        }

        public void UpdateSensitivity()
        {
            float sensitivity = (float)tb_sensibilidad.Value / 10.0f;
            lbl_sensitivity.Text = $"{sensitivity:0.0} C";
            ArrayPanelGroup.ArrayPanelDisplayActions.Sensitivity = sensitivity;
            a_panel.Refresh();
        }

        public void UpdateTime(DateTime time)
        {
            lbl_hora.Text = time.ToString("hh:mm:ss.fff");
        }

        public FileReaderForm(Stream inputStream) : this()
        {
            _streamReader = new StreamReader(inputStream);
        }

        private void FileReaderForm_Load(object sender, EventArgs e)
        {
            a_panel.SetSize(4, 4);
            ScanFile();
            trb_time.Maximum = _frameCount - 1;
        }

        private void ScanFile()
        {
            _frameCount = 0;
            _streamReader.BaseStream.Position = 0;
            Stream stream = _streamReader.BaseStream;
            List<long> tmpPositions = new List<long> { 0 };
            int input = stream.ReadByte();
            int prev_input;
            while (input != -1)
            {
                if (input == '\n')
                {
                    _frameCount++;
                    tmpPositions.Add(_streamReader.BaseStream.Position );
                }

                prev_input = input;
                input = stream.ReadByte();
            }

            _startPositions = tmpPositions.ToArray();
            tmpPositions = null;

        }

        private void trb_time_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                GoToLine(trb_time.Value);
            }
            catch (Exception ex)
            {

            }
            
        }

        private void GoToLine(int pos)
        {
            long startPosition = _startPositions[pos];
            _streamReader.BaseStream.Position = startPosition;
            _curLine = _streamReader.ReadLine();
            List<string> data = _curLine.Split('\t').ToList();
            DateTime time = new DateTime(long.Parse(data[0]));
            float[] values = data.Skip(1).Select(s => float.Parse(s)).ToArray();

            a_panel.SetValues(values);
            UpdateTime(time);
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
    }
}
