using EmbedIO.WebSockets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D6TReader.Controller
{
    public class DataReceiverWebsocket : WebSocketModule
    {
        public static event EventHandler<string> OnStringReceived;

        public DataReceiverWebsocket(string urlPath)
            : base(urlPath, true)
        {
            // placeholder
        }

        /// <inheritdoc />
        protected override async Task OnMessageReceivedAsync(
            IWebSocketContext context,
            byte[] rxBuffer,
            IWebSocketReceiveResult rxResult)
            => OnStringReceived?.Invoke(this, Encoding.GetString(rxBuffer));

        /// <inheritdoc />
        protected override async Task OnClientConnectedAsync(IWebSocketContext context)
        {

        }

        /// <inheritdoc />
        protected override async Task OnClientDisconnectedAsync(IWebSocketContext context)
        {

        }

        private async Task SendToOthersAsync(IWebSocketContext context, string payload)
        {

        }
    }
}
