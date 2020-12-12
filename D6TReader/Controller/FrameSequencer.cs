using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace D6TReader.Controller
{
    public class FrameSequencer
    {
        private int FPS;
        private D6TReader reader;
        private int FPSDelay => 1000 / FPS;
        private Timer timer;

        public event EventHandler<float[]> OnNewFrame;

        public FrameSequencer(D6TReader reader, int fps)
        {
            FPS = fps;
            this.reader = reader;
            timer = new Timer();
            timer.Interval = FPSDelay;
            timer.Enabled = true;
            timer.Tick += Timer_Tick;

        }

        public void Start()
        {
            timer.Start();
        }

        public void Stop()
        {
            timer.Stop();
        }

        private async void Timer_Tick(object sender, EventArgs e)
        {
            var data = await reader.GetData();
            if (data != null)
            {
                OnNewFrame?.Invoke(this, data.ToArray());
            }
        }
    }
}
