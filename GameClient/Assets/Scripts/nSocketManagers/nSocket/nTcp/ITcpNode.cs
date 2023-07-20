using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace NewClientServerSampleWithUdp.nSocketManagers.nSocket.nTcp
{
    public interface ITcpNode : INode
    {
        void StartReceiving();
        string Id { get; }
        bool Connected { get; }
        void Disconnect();
    }
}
