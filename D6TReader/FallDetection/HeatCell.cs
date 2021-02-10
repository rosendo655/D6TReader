using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D6TReader.FallDetection
{
    public class HeatCell
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
            if (historicTemperature.Count >= historicSize)
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
