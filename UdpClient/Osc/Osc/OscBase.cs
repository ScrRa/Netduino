using System;
using Microsoft.SPOT;
using System.Net.Sockets;
using System.Net;

namespace Osc.Osc
{
    abstract class OscBase
    {
        protected IPEndPoint _ipEndPoint;
        protected Socket _socket;
        protected int _port;
        protected string _address;

        public static int DEFAULT_PORT = 12345;
        public static string DEFAULT_IPADDRESS = "127.0.0.1";

        public OscBase()
        {
            this._port = OscBase.DEFAULT_PORT;
            this._socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            this._ipEndPoint = new IPEndPoint(IPAddress.Parse(OscBase.DEFAULT_IPADDRESS), OscBase.DEFAULT_PORT);
        }

        ~OscBase()
        {
            if (this._socket != null)
            {
                this._socket.Close();
                this._socket = null;
            }
            if (this._ipEndPoint != null)
            {
                this._ipEndPoint = null;
            }
        }
    }
}
