using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D6TReader.Controller
{
    public class HeatMapAnalizer
    {
        
        private HeatCell[] cells;
        private int CellCount { get; }
        private int FrameBufferCount { get; }

        private int[] standPosition;
        private int[] fallPosition;

        

        

        public HeatMapAnalizer(int cellCount ,int frameBufferCount)
        {
            FrameBufferCount = frameBufferCount;
            CellCount = cellCount;
            cells = new HeatCell[cellCount];
            for(int i = 0; i < cellCount; i ++)
            {
                cells[i] = new HeatCell(frameBufferCount);
            }
        }

        public void AddZones(int[] standZone , int [] fallZone)
        {
            standPosition = standZone;
            fallPosition = fallZone;
        }


        public HeatMapAnalizer Attach(FrameSequencer sequencer)
        {
            sequencer.OnNewFrame += Sequencer_OnNewFrame;
            return this;
        }
        
        public HeatMapAnalizer Dettach(FrameSequencer sequencer)
        {
            sequencer.OnNewFrame -= Sequencer_OnNewFrame;
            return this;
        }

        private void Sequencer_OnNewFrame(object sender, float[] e)
        {
            for(int i = 0; i < CellCount || i < e.Length; i++)
            {
                cells[i].AddTemp(e[i]);
            }

        }

        private void Analize()
        {
            if (fallPosition == null || standPosition == null) return;


        }



        private class HeatCell
        {
            private int historicSize;
            private List<float> historicTemperature;
            private float temp_at_t;

            public HeatCell(int historicSize)
            {
                this.historicSize = historicSize;
                historicTemperature = new List<float>();
            }

            public void AddTemp(float input)
            {
                historicTemperature.Add(temp_at_t);
                if(historicTemperature.Count >= historicSize)
                {
                    historicTemperature.RemoveAt(0);
                }
                temp_at_t = input;
            }

            public float Current => temp_at_t;
            public float Sum => historicTemperature.Sum() + temp_at_t;
            public float Avg => Sum / historicTemperature.Count + 1;
            public float TemperatureDifference
            {
                get
                {
                    float res = 0;
                    historicTemperature.ForEach(temp => res += temp_at_t - temp);
                    return res / historicSize;
                }
            }

            public float TemperatureDelta => temp_at_t - historicTemperature.First();
        }
    }
}
