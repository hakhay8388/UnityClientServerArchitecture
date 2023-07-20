using System;
using System.Collections.Generic;
using System.Text;
using NewClientServerSampleWithUdp.nSocketManagers.nSocket.nPacket;
using NewClientServerSampleWithUdp.nSocketManagers.nSocket.nTcp.nTcpNodes;

namespace NewClientServerSampleWithUdp.nSocketManagers.nSocket
{
    public interface INodeEventReceiver
    {
        void OnPacketReceive(INode _Sender, cBasePacket _Data);

        void OnDisconnected(INode _Node);
    }
}
