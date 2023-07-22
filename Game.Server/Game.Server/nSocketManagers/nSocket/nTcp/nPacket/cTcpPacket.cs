using NewClientServerSampleWithUdp.nSocketManagers.nSocket.nPacket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace NewClientServerSampleWithUdp.nSocketManagers.nSocket.nTcp.nPacket
{
    public class cTcpPacket : cBasePacket
    {
        public cTcpPacket(IPEndPoint _IPEndPoint, string _Message)
            : base(_IPEndPoint, _Message)
        {
        }

        public cTcpPacket(IPEndPoint _IPEndPoint, byte[] _Message)
            : base(_IPEndPoint, _Message)
        {
        }


        public override byte[] Serialize()
        {
            var __FullPacket = new List<byte>();
            __FullPacket.AddRange(BitConverter.GetBytes(Message.Length));
            __FullPacket.AddRange(Encoding.Default.GetBytes(Message));

            return __FullPacket.ToArray();
        }
    }
}
