using NewClientServerSampleWithUdp.nSocketManagers.nSocket;
using NewClientServerSampleWithUdp.nSocketManagers.nSocket.nPacket;
using NewClientServerSampleWithUdp.nSocketManagers.nSocket.nTcp.nTcpNodes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewClientServerSampleWithUdp.nSocketManagers.nTcp
{
    public interface ITcpDataReceiver
    {
        bool OnTcpMessageReceive(cTcpNode _Node, cBasePacket _Data);

        void OnTcpDisconnected(cTcpNode _Node);
    }
}
