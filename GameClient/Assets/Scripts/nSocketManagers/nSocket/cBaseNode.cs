using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace NewClientServerSampleWithUdp.nSocketManagers.nSocket
{
    public abstract class cBaseNode : INode
    {
        public INodeEventReceiver PacketReceiver { get; set; }
        public IPEndPoint IPEndPoint { get; set; }

        protected cBaseNode(IPEndPoint _IPEndPoint, INodeEventReceiver _PacketReceiver)
        {
            IPEndPoint = _IPEndPoint;
            PacketReceiver = _PacketReceiver;
        }

        public abstract void Disconnect();
    }
}
