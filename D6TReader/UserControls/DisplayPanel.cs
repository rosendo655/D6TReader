using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;

namespace D6TReader.UserControls
{
    public partial class DisplayPanel : UserControl
    {
        static Color[] colors =
        {

            Color.FromArgb(0xFF,0x40,0x00,0x40),
            Color.FromArgb(0xFF,0x00,0x00,0x80),
            Color.FromArgb(0xFF,0x00,0x60,0x60),
            Color.FromArgb(0xFF,0x00,0x80,0x00),
            Color.FromArgb(0xFF,0xC0,0xC0,0x00),
            Color.FromArgb(0xFF,0xE0,0xA0,0x00),
            Color.FromArgb(0xFF,0xE0,0x00,0x00),
            Color.FromArgb(0xFF,0xF0,0x80,0x80),

        };

        new public String Text
        {
            set => lbl_text.Text = value;
            get => lbl_text.Text;
        }

        public Color Color
        {
            set => BackColor = value;
            get => BackColor;
        }

        public float Temp
        {
            set
            {
                Text = value.ToString();
                BackColor = GetColor(value);
            }
        }

        private Color GetColor(float temp)
        {
            try
            {
                int pos = (int)(temp / 5.0);
                pos = Math.Min(pos, 7);
                return colors[pos];
            }
            catch
            {

            }

            return Color.Black;
        }


        public DisplayPanel()
        {
            InitializeComponent();
        }

        private static decimal map(decimal value, decimal fromLow, decimal fromHigh, decimal toLow, decimal toHigh)
        {
            return (value - fromLow) * (toHigh - toLow) / (fromHigh - fromLow) + toLow;
        }


    }
}
