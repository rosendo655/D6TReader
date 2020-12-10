using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D6TReader.Controller
{
    public static class SerialPortExtensions
    {
        public static void Subscribe(this SerialPort port)
        {
            port.DataReceived += Port_DataReceived;
            
        }

        private static void Port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            
        }
    }
}
