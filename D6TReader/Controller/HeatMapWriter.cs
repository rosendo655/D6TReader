using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D6TReader.Controller
{
    public class HeatMapWriter
    {
        private Queue<(DateTime, float[])> writeQueue;
        StreamWriter writer;
        private bool WriteToFile;
        private bool StopWriting;

        public HeatMapWriter(StreamWriter writer)
        {
            writeQueue = new Queue<(DateTime, float[])>();
            this.writer = writer;
            WriteToFile = false;
            
        }

        public async void Cycle()
        {
            while(WriteToFile)
            {
                if(writeQueue.Count >0)
                {
                    var tuple = writeQueue.Dequeue();
                    string toWrite = $"{tuple.Item1.Ticks}\t{string.Join("\t", tuple.Item2)}\n";
                    await writer.WriteAsync(toWrite);
                    await writer.FlushAsync();
                }
            }
        }

        public async void Start()
        {
            WriteToFile = true;
            await Task.Run(Cycle);
        }

        public void Stop()
        {
            WriteToFile = false;
        }

        public void Attach(FrameSequencer sequencer)
        {
            sequencer.OnNewFrame += Sequencer_OnNewFrame;
        }

        

        public void Dettach(FrameSequencer sequencer)
        {
            sequencer.OnNewFrame -= Sequencer_OnNewFrame;
        }
        
        private void Sequencer_OnNewFrame(object sender, float[] e)
        {
            writeQueue.Enqueue(new ValueTuple<DateTime,float[]>(DateTime.Now,e));
        }
    }
}
