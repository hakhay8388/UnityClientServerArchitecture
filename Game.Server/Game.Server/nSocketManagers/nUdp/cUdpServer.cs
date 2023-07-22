using NewClientServerSampleWithUdp.nSocketManagers.nSocket;
using NewClientServerSampleWithUdp.nSocketManagers.nSocket.nPacket;
using NewClientServerSampleWithUdp.nSocketManagers.nSocket.nTcp.nTcpNodes;
using NewClientServerSampleWithUdp.nSocketManagers.nSocket.nUdp.nUdpNodes;
using NewClientServerSampleWithUdp.nSocketManagers.nTcp;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace NewClientServerSampleWithUdp.nSocketManagers.nUdp
{
    public class cUdpServer : INodeEventReceiver
    {
        cTcpServer TcpServer { get; set; }
        public IUdpDataReceiver UdpDataReceiver { get; set; }
        public cUdpListener UDPListener { get; set; }
        public cUdpServer(cTcpServer _TcpServer, IUdpDataReceiver _UdpDataReceiver)
        {
            TcpServer = _TcpServer;
            UdpDataReceiver = _UdpDataReceiver;
            UDPListener = new cUdpListener(new IPEndPoint(IPAddress.Any, TcpServer.Port), this);
        }

        public void OnPacketReceive(INode _Sender, cBasePacket _Data)
        {
            UdpDataReceiver.OnUdpMessageReceive(_Sender, _Data);
        }

        public void OnDisconnected(INode _Node)
        {
            UdpDataReceiver.OnUdpDisconnected(_Node);
        }

        public void SendToAll(string _Data)
        {
            foreach (cTcpNode __Client in TcpServer.TcpNodes)
            {
                if (__Client.Connected)
                {
                    Send(__Client.UdpIPEndPoint, _Data);
                }
            }
        }

        public void Send(IPEndPoint _IPEndPoint, string _Data)
        {
            try
            {
                UDPListener.SendToClient(_IPEndPoint, _Data);
            }
            catch
            {
            }            
        }
    }
}
