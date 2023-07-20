using NewClientServerSampleWithUdp.nSocketManagers.nSocket;
using NewClientServerSampleWithUdp.nSocketManagers.nSocket.nPacket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewClientServerSampleWithUdp.nSocketManagers.nUdp
{
    public interface IUdpDataReceiver
    {
        bool OnUdpMessageReceive(INode _Sender, cBasePacket _Data);

        void OnUdpDisconnected(INode _Node);
    }
}
