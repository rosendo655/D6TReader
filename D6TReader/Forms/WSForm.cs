using D6TReader.Controller;
using EmbedIO;
using Newtonsoft.Json;
using Swan.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace D6TReader.Forms
{
    public partial class WSForm : Form
    {
        private class HRJsonData
        {
            public decimal[] frame { get; set; }
            public int any { get; set; }
        }

        public WSForm()
        {
            InitializeComponent();
        }

        private void WSForm_Load(object sender, EventArgs e)
        {
            var url = "http://192.168.137.1:8080/";
            a_panel.SetSize(4, 4);
            CreateServer(url);
            DataReceiverWebsocket.OnStringReceived += DataReceiverWebsocket_OnStringReceived;
        }

        private void DataReceiverWebsocket_OnStringReceived(object sender, string e)
        {
            var content = JsonConvert.DeserializeObject<HRJsonData>(e);

            

            this.Invoke((MethodInvoker)delegate {
                setData(content.frame.Select(s => (float)s).ToArray());
            });

            if(content.any == 1 )
            {
                SoundPlayer simpleSound = new SoundPlayer(@"c:\Windows\Media\chimes.wav");
                simpleSound.Play();
            }

        }

        private void setData(float[] data)
        {
            a_panel.SetValues(data);
        }

        static async void CreateServer(string url)
        {

            // Our web server is disposable.
            using (var server = CreateWebServer(url))
            {
                // Once we've registered our modules and configured them, we call the RunAsync() method.
                await server.RunAsync();

                var browser = new System.Diagnostics.Process()
                {
                    StartInfo = new System.Diagnostics.ProcessStartInfo(url) { UseShellExecute = true }
                };
                //browser.Start();
                // Wait for any key to be pressed before disposing of our web server.
                // In a service, we'd manage the lifecycle of our web server using
                // something like a BackgroundWorker or a ManualResetEvent.
                while (true) ;
            }
        }

        private static WebServer CreateWebServer(string url)
        {
            string[] prefixes =
            {


                "http://*:8080/",
            };
            var server = new WebServer(o => o
                    .WithUrlPrefixes(prefixes)
                    .WithMode(HttpListenerMode.EmbedIO))
                    .WithModule(new DataReceiverWebsocket("/ws"));
            // Listen for state changes.
            server.StateChanged += (s, e) => $"WebServer New State - {e.NewState}".Info();

            return server;
        }
    }
}
