using NewClientServerSampleWithUdp.nSocketManagers.nSocket;
using NewClientServerSampleWithUdp.nSocketManagers.nSocket.nPacket;
using NewClientServerSampleWithUdp.nSocketManagers.nSocket.nUdp.nPacket;
using NewClientServerSampleWithUdp.nSocketManagers.nSocket.nUdp.nUdpNodes;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace NewClientServerSampleWithUdp.nSocketManagers.nUdp
{
    public class cUdpClient : INodeEventReceiver
    {
        public IUdpDataReceiver UdpDataReceiver { get; set; }
        public cUdpNode UdpNode { get; set; }
        public cUdpClient(string _Host, int _Port, IUdpDataReceiver _UdpDataReceiver)
        {
            UdpDataReceiver = _UdpDataReceiver;
            UdpNode = new cUdpNode(_Host, _Port, this);
        }

        public void OnPacketReceive(INode _Sender, cBasePacket _Data)
        {
            UdpDataReceiver.OnUdpMessageReceive(_Sender, _Data);
        }

        public void OnDisconnected(INode _Node)
        {
            UdpDataReceiver.OnUdpDisconnected(_Node);
        }

        public void Send(string _Message)
        {
            UdpNode.SendToServer(_Message);
        }
    }
}
