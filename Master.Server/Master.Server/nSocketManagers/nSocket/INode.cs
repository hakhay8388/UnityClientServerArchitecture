using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace NewClientServerSampleWithUdp.nSocketManagers.nSocket
{
    public interface INode
    {
        INodeEventReceiver PacketReceiver { get; set; }
        IPEndPoint IPEndPoint { get; set; }

        void Disconnect();
    }
}
