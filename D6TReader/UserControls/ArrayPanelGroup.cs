using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace D6TReader.UserControls
{
    public partial class ArrayPanelGroup : UserControl
    {
        private DisplayPanel[] panels;

        private int x_tile_count = 1;
        private int XTileCount
        {
            get { return x_tile_count; }
            set { x_tile_count = value; }
        }

        private int y_tile_count = 1;
        private int YTileCount
        {
            get { return y_tile_count; }
            set { y_tile_count = value; }
        }

        private float[] _currentValues;

        public Action<DisplayPanel, float, float> _setPanelAction;
        public Action<DisplayPanel, float, float> SetPanelAction
        {
            get => _setPanelAction;
            set
            {
                _setPanelAction = value;
                Refresh();
            }
        }


        public ArrayPanelGroup()
        {
            InitializeComponent();
            panels = new DisplayPanel[1];
            this.SizeChanged += ArrayPanelGroup_SizeChanged;
        }

        public void SetSize(int x, int y)
        {
            XTileCount = x;
            YTileCount = y;

            panels = new DisplayPanel[x * y];

            for (int i = 0; i < x * y; i++)
            {
                panels[i] = new DisplayPanel();
                panels[i].Text = "DATA";
                fl_container.Controls.Add(panels[i]);
            }

        }

        public void SetValues(float[] values)
        {
            if (values.Count() != XTileCount * YTileCount)
            {
                //err
            }
            
            float avg = values.Average();
            for (int i = 0; i < values.Count(); i++)
            {
                var action = SetPanelAction ?? ArrayPanelDisplayActions.AverageDifference;

                try
                {
                    action(panels[i], values[i], avg);
                }
                catch 
                {

                }
                
            }
            _currentValues = values;
        }

        public void RefreshValues()
        {
            SetValues(_currentValues);
        }

        private void ArrayPanelGroup_SizeChanged(object sender, EventArgs e)
        {
            if (panels == null) return;
            int min_size = Math.Min(Height / YTileCount, Width / XTileCount);

            for (int i = 0; i < x_tile_count * y_tile_count; i++)
            {
                if (panels[i] == null) return;
                panels[i].Width =
                panels[i].Height = min_size;
            }

        }


        public class ArrayPanelDisplayActions
        {
            public static float Sensitivity { get; set; } = 0.8f;
            public static float LowUmbral { get; set; } = 0.0f;
            public static float HighUmbral { get; set; } = 70.0f;

            public static void Absolute(DisplayPanel panel, float value, float avg)
            {
                int red, blue;
                red = (255 / 50) * (int)value;
                blue = (255 / 50) * (50 - (int)value);

                Color color = Color.FromArgb(red, 0, blue);

                panel.Text = $"{value: 0.00}";
                panel.Color = color;
            }

            public static void AverageDifference(DisplayPanel panel, float value, float avg)
            {

                float difference = value - avg;
                panel.Text = $"{difference: 0.00}";
                panel.Color = difference > Sensitivity ? Color.Red : Color.White;
            }

            public static void Umbral(DisplayPanel panel , float value , float avg)
            {
                int red = (int) map(value, LowUmbral, HighUmbral, 0, 255);
                int blue = (int)map(value, HighUmbral, LowUmbral, 0, 255);
                Color color = Color.FromArgb(red, 0, blue);
                panel.Text = $"{value: 0.00}";
                panel.Color = color;
            }

            private static float map(float value, float fromLow, float fromHigh, float toLow, float toHigh)
            {
                return (value - fromLow) * (toHigh - toLow) / (fromHigh - fromLow) + toLow;
            }
        }
    }
}
