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

        public float PromedioTemperaturaZona(int[] zone)
            => Calc(zone, cells => cells.Average(a => a.Current));

        public float SumTemp(int[] zone)
            => Calc(zone, cells => cells.Sum(s => s.Current));

        public float PromedioDeltaZona(int[] zone)
            => Calc(zone, cells => cells.Average(a => a.TemperatureDelta));

        public float SumDelta(int[] zone)
            => Calc(zone, cells => cells.Sum(s => s.TemperatureDelta));

        public float AvgDifference(int[] zone)
            => Calc(zone, cells => cells.Average(a => a.TemperatureDifference));

        public float SumDifference(int[] zone)
            => Calc(zone, cells => cells.Sum(s => s.TemperatureDifference));

        //dado una zona [] y una funcion para calcular un flotante a partir de una coleccion de heatcells
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


        //algoritmo original
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
            float allDeltaAvg = PromedioDeltaZona(allZone);
            float standDeltaAvg = PromedioDeltaZona(startZone);
            float fallDeltaAvg = PromedioDeltaZona(endZone);

            float allCurrentAvg = PromedioTemperaturaZona(allZone);
            float fallCurrentAvg = PromedioTemperaturaZona(endZone);
            float standCurrentAvg = PromedioTemperaturaZona(startZone);

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




        private bool AnalizarCaida
            (
            int[] IZ,                               //ZONA INICIAL
            int[] FZ,                               //ZONA FINAL
            int[] RZ,                               //ZONA REFERENCIA
            float HPT = 0.20f,                      //LIMITE PORCENTAJE TRANSFERENCIA CALOR
            float AHT = 1.0f,                       //LIMITE PROMEDIO CALOR
            float AHD = 0.4f                        //LIMITE DIFERENCIA PROMEDIO CALOR
            )
        {
            //EN LOS METODOS 'PromedioDeltaZona()' y 'PromedioTemperaturaZona()' esta incluido el
            //parametro W de tamaño de ventana, por eso no se encuentra en los parametroz de entrada

            float RZDA = PromedioDeltaZona(RZ);                     //PROMEDIO DELTA ZONA REFERENCIA
            float IZDA = PromedioDeltaZona(IZ);                     //PROMEDIO DELTA ZONA INICIAL
            float FZDA = PromedioDeltaZona(FZ);                     //PROMEDIO DELTA ZONA FINAL

            float RZA = PromedioTemperaturaZona(RZ);                //PROMEDIO TEMPERATURA ZONA REFERENCIA
            float IZA = PromedioTemperaturaZona(IZ);                //PROMEDIO TEMPERATURA ZONA INICIAL
            float FZA = PromedioTemperaturaZona(FZ);                //PROMEDIO TEMPERATURA ZONA FINAL

            float HTP = IZDA / (FZDA == 0 ? 0.0001f : FZDA);        //PORCENTAJE DE TRANSFERENCIA DE CALOR
            float AHTP = Math.Abs(HTP);                             //PORCENTAJE DE TRANSFERENCIA DE CALOR ABSOLUTO

            return (IZA < (RZA + AHT) && (RZA + AHT) < FZA) &&      //CONDICION 1
                   (IZDA <= (-AHD) && FZDA >= AHD) &&               //CONDICION 2
                   (HTP < 0) &&                                     //CONDICION 3
                   ((1.0f - HPT) <= AHTP && AHTP <= (1.0f + HPT));  //CONDICION 4
        }





        //Algoritmo equivalente
        private bool AnalizarTransicion
            (
            int[] zonaInicio,
            int[] zonaFinal,
            int[] zonaReferencia,
            float rangoTransferenciaCalor = 0.20f,
            float temperaturaMinima = 1.0f,
            float deltaMinimo = 0.4f
            )
        {

            //calculo de deltas promedio de zona
            float deltaReferencia = PromedioDeltaZona(zonaReferencia);
            float deltaInicio = PromedioDeltaZona(zonaInicio);
            float deltaFinal = PromedioDeltaZona(zonaFinal);

            //calculo de promedio de temperaturas de zona
            float promedioReferencia = PromedioTemperaturaZona(zonaReferencia);
            float promedioInicio = PromedioTemperaturaZona(zonaInicio);
            float promedioFinal = PromedioTemperaturaZona(zonaFinal);

            
            if (promedioInicio < (promedioReferencia + temperaturaMinima) && (promedioReferencia + temperaturaMinima) < promedioFinal)
            {
                if (deltaInicio <= (-deltaMinimo) && deltaFinal >= deltaMinimo)
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
