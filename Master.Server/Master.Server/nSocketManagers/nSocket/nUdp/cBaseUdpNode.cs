using NewClientServerSampleWithUdp.nSocketManagers.nSocket.nUdp.nPacket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace NewClientServerSampleWithUdp.nSocketManagers.nSocket.nUdp
{
    public abstract class cBaseUdpNode : cBaseNode, IUdpNode
    {
        public INodeEventReceiver PacketReceiver { get; set; }
        public UdpClient UdpClient { get; set; }
        public IPEndPoint IPEndPoint { get; set; }

        protected cBaseUdpNode(IPEndPoint _IPEndPoint, INodeEventReceiver _PacketReceiver)
            : base(_IPEndPoint, _PacketReceiver)
        {
            IPEndPoint = _IPEndPoint;
            PacketReceiver = _PacketReceiver;
            UdpClient = Init();
            UdpClient.BeginReceive(ReceiveUdpCallback, UdpClient);

        }
        protected abstract UdpClient Init();

        public void ReceiveUdpCallback(IAsyncResult _Result)
        {
            UdpClient __UdpListener = (UdpClient)_Result.AsyncState;
            IPEndPoint __RemoteEndPoint = new IPEndPoint(IPAddress.Any, 0);
            byte[] __ReceivedData = __UdpListener.EndReceive(_Result, ref __RemoteEndPoint);

            cUdpPacket __Packet = new cUdpPacket(__RemoteEndPoint, __ReceivedData);
            try
            {
                PacketReceiver.OnPacketReceive(this, __Packet);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error : cBaseUDPItem.ReceivePacketData");
            }
            __UdpListener.BeginReceive(ReceiveUdpCallback, __UdpListener);
        }

        public override void Disconnect()
        {
            UdpClient.Close();
            if (PacketReceiver != null)
            {
                PacketReceiver.OnDisconnected(this);
            }
        }

    }
}
