using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D6TReader.FallDetection
{
    public class FrameAnalizeOptions
    {
        public int[][] StandZones { get; }
        public int[][] FallZones { get; }
        public int[] AllZone { get; }

        public float HeatTransferThreshold { get; }
        public float HeatAverageThreshold { get; }
        public float DeltaThreshold { get; }

        public FrameAnalizeOptions
            (
            int[][] standzones,
            int[][] fallzones,
            int[] allzone,
            float heatTransferThreshold = 0.20f,
            float heatAverageThreshold = 1.0f,
            float deltaThreshold = 0.4f
            )
        {
            StandZones = standzones;
            FallZones = fallzones;
            AllZone = allzone;
            HeatTransferThreshold = heatTransferThreshold;
            HeatAverageThreshold = heatAverageThreshold;
            DeltaThreshold = deltaThreshold;
        }
    }
}
