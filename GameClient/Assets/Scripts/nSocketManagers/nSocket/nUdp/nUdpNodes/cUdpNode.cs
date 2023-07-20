using NewClientServerSampleWithUdp.nSocketManagers.nSocket.nUdp.nPacket;
using NewClientServerSampleWithUdp.nSocketManagers.nSocket.nUtils;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace NewClientServerSampleWithUdp.nSocketManagers.nSocket.nUdp.nUdpNodes
{
    public class cUdpNode : cBaseUdpNode
    {
        public cUdpNode(IPEndPoint _IPEndPoint, INodeEventReceiver _PacketReceiver)
            : base(_IPEndPoint, _PacketReceiver)
        {
        }

        public cUdpNode(string _Host, int _Port, INodeEventReceiver _PacketReceiver)
            : base(IPUtils.CreateIPEndPoint(_Host + ":" + _Port.ToString()), _PacketReceiver)
        {
        }


        protected override UdpClient Init()
        {
            UdpClient __UdpUser = new UdpClient();
            __UdpUser.Connect(IPEndPoint);
            return __UdpUser;
        }

        public void SendToServer(string _Message)
        {
            cUdpPacket __Packet = new cUdpPacket(IPEndPoint, _Message);
            byte[] __Data = __Packet.Serialize();
            UdpClient.Send(__Data, __Data.Length);
        }
    }
}
