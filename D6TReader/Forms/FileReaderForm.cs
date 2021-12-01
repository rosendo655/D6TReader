using D6TReader.Controller;
using D6TReader.UserControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
        private bool[] _real_fall;
        private int _cur_position;
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

        private void UpdateChecbox(bool value)
        {
            cb_caida.Checked = value;
        }

        public FileReaderForm(Stream inputStream, string name) : this()
        {
            Text = name;
            _streamReader = new StreamReader(inputStream);
        }

        private void FileReaderForm_Load(object sender, EventArgs e)
        {
            a_panel.SetSize(4, 4);
            ScanFile();
            numeric.Maximum = _frameCount - 1;
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
                    tmpPositions.Add(stream.Position);
                }

                prev_input = input;
                input = stream.ReadByte();
            }

            _startPositions = tmpPositions.ToArray();
            _real_fall = new bool[_startPositions.Length];
            tmpPositions = null;

        }

        private void trb_time_ValueChanged(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {

            }

        }

        private void GoToLine(int pos)
        {
            _cur_position = pos;
            DateTime time = default;
            float[] values = default;
            long startPosition = _startPositions[pos];
            _streamReader.DiscardBufferedData();
            _streamReader.BaseStream.Seek(startPosition, SeekOrigin.Begin);
            _curLine = _streamReader.ReadLine();
            List<string> data = _curLine.Split(',').ToList();
            DateTime.TryParse(data[0], out time);
            if (data.Count == 17)
            {
                values = data.Skip(1).Select(s => float.Parse(s)).ToArray();
                _real_fall[pos] = _real_fall[pos] || false;
            }
            else
            {
                values = data.Skip(1).Take(16).Select(s => float.Parse(s)).ToArray();
                bool filevalue = bool.Parse(data.Last());
                _real_fall[pos] = _real_fall[pos] ? _real_fall[pos] : filevalue;
            }


            a_panel.SetValues(values);
            UpdateTime(time);
            UpdateChecbox(_real_fall[pos]);
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

        private void cb_caida_CheckedChanged(object sender, EventArgs e)
        {
            _real_fall[_cur_position] = cb_caida.Checked;
        }

        private void guardarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Stream file = DataController.SaveFile();

            if (file == null) return;
            CultureInfo culture = new CultureInfo("en-US");
            string dateFormat = "yyyy-MM-dd HH:mm:ss.ffffff";
            StreamWriter sw = new StreamWriter(file);
            _streamReader.DiscardBufferedData();
            _streamReader.BaseStream.Position = 0;

            int curline = 0;
            int errcount = 0;
            while (!_streamReader.EndOfStream)
            {
                try
                {

                    string line = _streamReader.ReadLine();
                    string[] data = line.Split('\t');
                    DateTime time;

                    DateTime.TryParseExact(data[0], dateFormat, culture, DateTimeStyles.None, out time);
                    float[] temps = data.Skip(1).Take(16).Select(s => float.Parse(s)).ToArray();
                    bool real_fall = _real_fall[curline++];
                    string numbers = string.Join("\t", temps.Select(s => s.ToString("0.0")));
                    string lineToWrite = $"{time.ToString(dateFormat)}\t{numbers}\t{real_fall}";

                    sw.WriteLine(lineToWrite);

                }
                catch (Exception)
                {
                    curline += 2;
                    errcount++;
                }


            }
            MessageBox.Show($"Errores: {errcount}");
            sw.Flush();
            sw.Close();
        }

        private void FileReaderForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ' ')
            {
                cb_caida.Checked = !cb_caida.Checked;
            }
        }

        private void numeric_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                GoToLine((int)numeric.Value);
            }
            catch (Exception ex)
            {

            }
        }

        private void numeric_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ' ')
            {
                cb_caida.Checked = !cb_caida.Checked;
                numeric.Value += numeric.Value == numeric.Maximum ? 0 : 1;

            }
        }

        private string[] GetLine(int line_number)
        {
            long streamPos = _startPositions[line_number];
            _streamReader.DiscardBufferedData();
            _streamReader.BaseStream.Seek(streamPos, SeekOrigin.Begin);
            string str_line = _streamReader.ReadLine();
            return str_line.Split('\t');
        }



        private void clasificarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int ffile = 0;
            int nffile = 0;
            string path = "";

            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    path = fbd.SelectedPath;



                }
            }

            List<(int frame, int group, bool state)> line_group = new List<(int, int, bool)>();

            int cur_group = 0;
            bool prev_state = false;

            for (int frame = 0; frame < _frameCount; frame++)
            {
                string[] current_data = GetLine(frame);
                bool fall_state;
                bool.TryParse(current_data.Last(), out fall_state);

                if (fall_state != prev_state)
                {
                    prev_state = fall_state;
                    cur_group++;
                }

                line_group.Add((frame, cur_group, fall_state));

            }

            var grouped_frames = line_group.GroupBy(g => g.group);



            foreach (var group in grouped_frames)
            {

                bool state = group.First().state;



                int prev_frame_count = 30;

                int first = group.First().frame;
                var prev_frames = Enumerable.Range(first - prev_frame_count < 0 ? 0 : first - prev_frame_count, prev_frame_count);
                var line_numbers = state ?
                                        prev_frames.Concat(group.Select(s => s.frame)) :
                                        group.Select(s => s.frame).Take(group.Count() - prev_frame_count);
                var lines = line_numbers.Select(s => GetLine(s).Take(17));

                if (lines.Count() == 0)
                {
                    continue;
                }

                if (state)
                {
                    ffile++;
                }
                else
                {
                    nffile++;
                }
                string filename = $"{(state ? "f" : "nf")}_{(state ? ffile : nffile)}.csv";
                FileStream out_file = File.Open(path + "\\" + filename, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                StreamWriter sw = new StreamWriter(out_file);



                foreach (var line in lines)
                {
                    sw.WriteLine(string.Join(",", line.ToArray()));
                }

                sw.Flush();
                sw.Close();

            }

        }

        private bool saving = false;
        private (int from, int to) range = (0, 0);
        private string filename = "";
        private string filepath = null;

        private void b_create_Click(object sender, EventArgs e)
        {
            if (saving)
            {
                if(filepath == null)
                {
                    using (var fbd = new FolderBrowserDialog())
                    {
                        DialogResult result = fbd.ShowDialog();

                        if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                        {
                            filepath = fbd.SelectedPath;
                        }
                        else
                        {
                            return;
                        }
                    }
                }
                range.to = _cur_position;
                FileStream stream = File.Open(filepath +"\\"+ filename + ".csv", FileMode.OpenOrCreate, FileAccess.Write);
                StreamWriter sw = new StreamWriter(stream);
                for(int i = range.from; i <= range.to; i ++)
                {
                    string[] line = GetLine(i);
                    sw.WriteLine(string.Join(",", line.Take(17)));
                }
                sw.Flush();
                sw.Close();

                var match = Regex.Match(filename, "\\d+")?.Value ?? "";
                int number = int.Parse(match);
                number++;
                tb_file.Text = tb_file.Text.Replace(match, number.ToString());
                b_create.Text = "Start";
                saving = false;
            }
            else
            {
                filename = tb_file.Text;
                if (string.IsNullOrEmpty(filename))
                {
                    MessageBox.Show("invalid name");
                    return;
                }

                if (!Regex.IsMatch(filename, "\\d+"))
                {
                    MessageBox.Show("invalid name must contain a number");
                    return;
                }

                range.from = _cur_position;
                saving = true;
                b_create.Text = "Save";
            }
        }
    }
}
