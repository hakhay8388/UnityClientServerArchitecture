using NewClientServerSampleWithUdp.nSocketManagers.nSocket.nPacket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace NewClientServerSampleWithUdp.nSocketManagers.nSocket.nUdp.nPacket
{
    public class cUdpPacket : cBasePacket
    {
        public cUdpPacket(IPEndPoint _IPEndPoint, string _Message)
            : base(_IPEndPoint, _Message)
        {
        }

        public cUdpPacket(IPEndPoint _IPEndPoint, byte[] _Message)
            : base(_IPEndPoint, _Message)
        {
        }

        public override byte[] Serialize()
        {
            return Encoding.ASCII.GetBytes(Message);
        }
    }
}
