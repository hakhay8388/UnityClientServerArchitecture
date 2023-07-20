using NewClientServerSampleWithUdp.nSocketManagers.nSocket.nUdp.nPacket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace NewClientServerSampleWithUdp.nSocketManagers.nSocket.nUdp.nUdpNodes
{
    public class cUdpListener : cBaseUdpNode
    {
        public cUdpListener(IPEndPoint _IPEndPoint, INodeEventReceiver _PacketReceiver)
               : base(_IPEndPoint, _PacketReceiver)
        {
        }

        protected override UdpClient Init()
        {
            UdpClient __UdpUser = new UdpClient(IPEndPoint);
            return __UdpUser;
        }

        public void SendToClient(IPEndPoint _IPEndPoint, string _Message)
        {
            cUdpPacket __Packet = new cUdpPacket(_IPEndPoint, _Message);
            byte[] __Data = __Packet.Serialize();
            UdpClient.Send(__Data, __Data.Length, _IPEndPoint);
        }
    }
}
