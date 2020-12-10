using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D6TReader.Controller
{
    public class SerialController
    {
        public static IEnumerable<string> Ports()
        {
            return SerialPort.GetPortNames();
        }

        public static SerialPort GetPort(string com_port , int baud)
        {
            SerialPort port = new SerialPort(com_port, baud);
            port.Open();
            
            return port;
        }
    }
}
