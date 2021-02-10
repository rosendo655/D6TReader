using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D6TReader.FallDetection
{
    public enum FrameAnalizeResult
    {
        NONE = 0,
        HEAT_AVG_THRESHOLD = 1 << 0,
        DELTA_AVG_THRESHOLD = 1 << 1,
        DELTA_AVG_TRANSFER = 1 << 2,
        DELTA_AVG_NEGATIVE_TRANSFER = 1 << 3,
        DELTA_AVG_PERCENTAGE_TRANSFER = 1 << 4,
        LAST_DETECTED_TIME_THRESHOLD = 1 << 5,
        FALL =
            HEAT_AVG_THRESHOLD
            | DELTA_AVG_THRESHOLD
            | DELTA_AVG_TRANSFER
            | DELTA_AVG_NEGATIVE_TRANSFER
            | DELTA_AVG_PERCENTAGE_TRANSFER
            | LAST_DETECTED_TIME_THRESHOLD
    }
}
