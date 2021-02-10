using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D6TReader.Controller
{
    public class D6TReader
    {
        SerialPort _port;
        private TaskCompletionSource<IEnumerable<float>> DataReceived;
        private event EventHandler OnLineReceived;
        public event EventHandler<IEnumerable<float>> OnDataRead;
        bool dataReceived = true;
        string buffer;
        bool _isDisposed;


        public D6TReader(SerialPort port)
        {
            _port = port;
            _port.DataReceived += _port_DataReceived;
            this.OnLineReceived += D6TReader_OnLineReceived;
            port.Disposed += Port_Disposed;
            _isDisposed = false;
            buffer = "";
        }

        private void Port_Disposed(object sender, EventArgs e)
        {
            _isDisposed = true;

        }

        private void D6TReader_OnLineReceived(object sender, EventArgs e)
        {
            try
            {
                var data = buffer.Split(',').Select(s => float.Parse(s)).ToList();
                buffer = "";
                DataReceived.TrySetResult(data);
            }
            catch (Exception ex)
            { 
                
            }

            
        }

        private void _port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            while(!_isDisposed && _port.BytesToRead > 0)
            {
                char inputChar = (char)_port.ReadChar();
                buffer += inputChar;
                
                if(inputChar == 0x0A)
                {
                    OnLineReceived?.Invoke(this, new EventArgs());
                }
            }
        }

        public async Task<IEnumerable<float>> GetData()
        {
            _port.Write("r");
            if(!dataReceived)
            {
                return null;
            }
            dataReceived = false;
            DataReceived = new TaskCompletionSource<IEnumerable<float>>();
            
            var result = await DataReceived.Task;
            dataReceived = true;
            OnDataRead?.Invoke(this, result);
            return result;
        }
    }
}
