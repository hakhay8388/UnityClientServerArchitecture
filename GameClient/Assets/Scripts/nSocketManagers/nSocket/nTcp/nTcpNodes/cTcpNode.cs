using NewClientServerSampleWithUdp.nSocketManagers.nSocket.nTcp.nPacket;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace NewClientServerSampleWithUdp.nSocketManagers.nSocket.nTcp.nTcpNodes
{
    public class cTcpNode : cBaseNode, ITcpNode
    {
        public IPEndPoint UdpIPEndPoint { get; private set; }
        public Socket TcpSocket { get; private set; }
        public string Id { get; private set; }
        public bool Connected { get { return TcpSocket.Connected; } }

        byte[] m_Buffer { get; set; }

        public cTcpNode(Socket _TcpSocket, string _Id, INodeEventReceiver _PacketReceiver)
            : base((IPEndPoint)_TcpSocket.RemoteEndPoint, _PacketReceiver)
        {
            Id = _Id;
            TcpSocket = _TcpSocket;
            StartReceiving();
        }

        public void SetUdpNode(IPEndPoint _UdpIPEndPoint)
        {
            UdpIPEndPoint = _UdpIPEndPoint;
        }

        public override void Disconnect()
        {
            try
            {
                TcpSocket.Disconnect(true);
            }
            catch(Exception ex) { }
            
            if (PacketReceiver != null)
            {
                PacketReceiver.OnDisconnected(this);
            }
        }

        public void StartReceiving()
        {
            try
            {
                m_Buffer = new byte[4];
                TcpSocket.BeginReceive(m_Buffer, 0, m_Buffer.Length, SocketFlags.None, ReceiveCallback, null);
            }
            catch { }
        }

        private void ReceiveCallback(IAsyncResult _AsyncResult)
        {
            try
            {
                if (TcpSocket.EndReceive(_AsyncResult) > 1)
                {
                    m_Buffer = new byte[BitConverter.ToInt32(m_Buffer, 0)];
                    TcpSocket.Receive(m_Buffer, m_Buffer.Length, SocketFlags.None);
                    cTcpPacket __Packet = new cTcpPacket(IPEndPoint, m_Buffer);
                    if (PacketReceiver != null)
                    {
                        PacketReceiver.OnPacketReceive(this, __Packet);
                    }

                    StartReceiving();
                }
                else
                {
                    Disconnect();
                }
            }
            catch (Exception _Ex)
            {
                if (!Connected)
                {
                    Disconnect();
                }
                else
                {
                    StartReceiving();
                }
            }
        }

        public void Send(string _Data)
        {
            if (Connected)
            {
                try
                {
                    cTcpPacket __Packet = new cTcpPacket(IPEndPoint, _Data);
                    TcpSocket.Send(__Packet.Serialize());
                }
                catch (Exception _Ex)
                {

                    throw new Exception();
                }
            }
            else
            {
                Console.WriteLine("Disconnected!");
            }
        }
    }
}
