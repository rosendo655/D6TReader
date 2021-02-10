using D6TReader.Controller;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D6TReader.FallDetection
{
    public class HeatMapAnalizer
    {
        public event EventHandler<FrameAnalizeResult[,]> OnFrameResult;
        private HeatCell[] cells;
        private FrameAnalizeOptions analizeOptions;
        private int CellCount { get; }

        public float AvgTemp(int[] zone)
            => Calc(zone, cells => cells.Average(a => a.Current));

        public float SumTemp(int[] zone)
            => Calc(zone, cells => cells.Sum(s => s.Current));

        public float AvgDelta(int[] zone)
            => Calc(zone, cells => cells.Average(a => a.TemperatureDelta));

        public float SumDelta(int[] zone)
            => Calc(zone, cells => cells.Sum(s => s.TemperatureDelta));

        public float AvgDifference(int[] zone)
            => Calc(zone, cells => cells.Average(a => a.TemperatureDifference));

        public float SumDifference(int[] zone)
            => Calc(zone, cells => cells.Sum(s => s.TemperatureDifference));


        private float Calc(int[] zone, Func<IEnumerable<HeatCell>, float> calcFunction)
            => calcFunction(zone.Select(z => cells[z]));


        public HeatMapAnalizer(int cellCount, int frameBufferCount, FrameAnalizeOptions analizeOpt)
        {
            CellCount = cellCount;
            analizeOptions = analizeOpt;
            cells = new HeatCell[cellCount];
            for (int i = 0; i < cellCount; i++)
            {
                cells[i] = new HeatCell(frameBufferCount);
            }
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
            for (int i = 0; i < CellCount || i < e.Length; i++)
            {
                cells[i].AddTemp(e[i]);
            }
            AnalizeFrame();
        }

        public void AnalizeFrame()
        {
            if (analizeOptions == null) return;
            var result = Analize(analizeOptions);
            OnFrameResult?.Invoke(this, result);
        }

        DateTime lastDetected = DateTime.MinValue;

        public FrameAnalizeResult[,] Analize(FrameAnalizeOptions options)
        {
            return AnalizeOptions(options);
        }

        private FrameAnalizeResult[,] AnalizeOptions(FrameAnalizeOptions options)
        {
            FrameAnalizeResult[,] results = new FrameAnalizeResult[options.StandZones.Length, options.FallZones.Length];
            for (int stand = 0; stand < options.StandZones.Length; stand++)
            {
                for (int fall = 0; fall < options.FallZones.Length; fall++)
                {
                    results[stand, fall] = AnalizeFrame(options.StandZones[stand], options.FallZones[fall], options.AllZone);
                }
            }
            return results;
        }

        private FrameAnalizeResult AnalizeFrame
            (
            int[] startZone,
            int[] endZone,
            int[] allZone,
            float heatTransferThreshold = 0.20f,
            float heatAverageThreshold = 1.0f,
            float deltaThreshold = 0.4f
            )
        {
            float allDeltaAvg = AvgDelta(allZone);
            float standDeltaAvg = AvgDelta(startZone);
            float fallDeltaAvg = AvgDelta(endZone);

            float allCurrentAvg = AvgTemp(allZone);
            float fallCurrentAvg = AvgTemp(endZone);
            float standCurrentAvg = AvgTemp(startZone);

            FrameAnalizeResult result = FrameAnalizeResult.NONE;

            if (!(standCurrentAvg < (allCurrentAvg + heatAverageThreshold)
                && (allCurrentAvg + heatAverageThreshold) < fallCurrentAvg))
            {
                return result;
            }
            result |= FrameAnalizeResult.HEAT_AVG_THRESHOLD;

            if (!(standDeltaAvg <= (-deltaThreshold) && fallDeltaAvg >= deltaThreshold))
            {
                return result;
            }
            // la zona de caida es mas caliente
            result |= FrameAnalizeResult.DELTA_AVG_THRESHOLD;

            if (!(standDeltaAvg < allDeltaAvg && allDeltaAvg < fallDeltaAvg))
            {
                return result;
            }
            // si la zona stand hubo una transicion negativa y en la fall hubo una positiva
            result |= FrameAnalizeResult.DELTA_AVG_TRANSFER;

            float heatTransferPercentage = standDeltaAvg / (fallDeltaAvg == 0 ? 0.0001f : fallDeltaAvg);
            if (!(heatTransferPercentage < 0))
            {
                return result;
            }
            //hubo transicion inversa
            result |= FrameAnalizeResult.DELTA_AVG_NEGATIVE_TRANSFER;

            float heatTransferAbs = Math.Abs(heatTransferPercentage);
            if (!((1.0f - heatTransferThreshold) <= heatTransferAbs &&
                heatTransferAbs <= (1.0f + heatTransferThreshold)))
            {
                return result;
            }
            //se transfirio la mayoria del calor
            result |= FrameAnalizeResult.DELTA_AVG_PERCENTAGE_TRANSFER;

            if (!(DateTime.Now - lastDetected >= TimeSpan.FromSeconds(1.5)))
            {
                return result;
            }
            // paso  mas de un segundo y medio
            result |= FrameAnalizeResult.LAST_DETECTED_TIME_THRESHOLD;
            lastDetected = DateTime.Now;

            return result;
        }

        private bool AnalizarTransicion
            (
            int[] zonaInicio,
            int[] zonaFinal,
            int[] zonaReferencia,
            float rangoTransferenciaCalor = 0.20f,
            float heatAverageThreshold = 1.0f,
            float deltaThreshold = 0.4f
            )
        {
            float deltaReferencia = AvgDelta(zonaReferencia);
            float deltaInicio = AvgDelta(zonaInicio);
            float deltaFinal = AvgDelta(zonaFinal);

            float promedioReferencia = AvgTemp(zonaReferencia);
            float promedioInicio = AvgTemp(zonaInicio);
            float promedioFinal = AvgTemp(zonaFinal);

            
            if (promedioInicio < (promedioReferencia + heatAverageThreshold) && (promedioReferencia + heatAverageThreshold) < promedioFinal)
            {
                if (deltaInicio <= (-deltaThreshold) && deltaFinal >= deltaThreshold)
                {
                    // la zona de caida es mas caliente
                    if (deltaInicio < deltaReferencia && deltaReferencia < deltaFinal)
                    {
                        // si la zona stand hubo una transicion negativa y en la fall hubo una positiva
                        float porcentajeTransferenciaCalor = deltaInicio / (deltaFinal == 0 ? 0.0001f : deltaFinal);
                        if (porcentajeTransferenciaCalor < 0)
                        {
                            //hubo transicion inversa
                            float porcentajeTransferenciaAbsoluto = Math.Abs(porcentajeTransferenciaCalor);
                            if ((1.0f - rangoTransferenciaCalor) <= porcentajeTransferenciaAbsoluto && porcentajeTransferenciaAbsoluto <= (1.0f + rangoTransferenciaCalor))
                            {
                                //se transfirio la mayoria del calor

                                return true;
                            }
                        }
                    }
                }
            }
            return false;
        }

    }
}
