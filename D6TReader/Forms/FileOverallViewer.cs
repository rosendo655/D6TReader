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
    public partial class FileOverallViewer : Form
    {
        
        public FileOverallViewer()
        {
            InitializeComponent();
        }

        public FileOverallViewer(Stream inputStream, string name) : this()
        {
            StreamReader reader = new StreamReader(inputStream);

            string content = reader.ReadToEnd();
            int index = 1;
            var views = content.Split('\n')
                .Where(w => !string.IsNullOrEmpty(w) && !string.IsNullOrWhiteSpace(w))
                .Select(s => s.Split(',').Skip(1).Select(num => float.Parse(num)))
                .Select(flnum =>
                {
                    ArrayPanelGroup apg = new ArrayPanelGroup();
                    apg.SetSize(4, 4);
                    apg.SetValues(flnum.ToArray());
                    apg.Width = 100;
                    apg.Height = 100;
                    Panel p = new Panel();
                    p.Padding = new Padding(20);
                    p.Controls.Add(apg);
                    p.Controls.Add(new Label() { Text = $"{index++}"  });
                    return p;
                });

            foreach(var view  in views)
            {
                flPanel.Controls.Add(view);
            }

        }
    }
}
