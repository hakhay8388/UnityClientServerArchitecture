using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NewClientServerSampleWithUdp.nSocketManagers.nSocket.nPacket
{
    public abstract class cBasePacket
    {
        public IPEndPoint IPEndPoint { get; set; }
        public string Message { get; set; }

        public cBasePacket(IPEndPoint _IPEndPoint, string _Message)
        {
            Message = _Message;
            IPEndPoint = _IPEndPoint;
        }

        public cBasePacket(IPEndPoint _IPEndPoint, byte[] _Message)
        {
            IPEndPoint = _IPEndPoint;
            Message = Encoding.ASCII.GetString(_Message, 0, _Message.Length);
        }

        public abstract byte[] Serialize();
    }
}
