using NewClientServerSampleWithUdp.nSocketManagers.nSocket;
using NewClientServerSampleWithUdp.nSocketManagers.nSocket.nPacket;
using NewClientServerSampleWithUdp.nSocketManagers.nSocket.nTcp.nTcpNodes;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NewClientServerSampleWithUdp.nSocketManagers.nTcp
{
    public class cTcpClient : INodeEventReceiver
    {
        public cTcpNode TcpNode { get; set; }
        ITcpDataReceiver TcpDataReceiver { get; set; }
        public cTcpClient(ITcpDataReceiver _TcpDataReceiver)
        {
            TcpDataReceiver = _TcpDataReceiver;
        }

        public void TryToConnect(string _IP, int _Port, Action _ServerFound, Action _ServerNotFound)
        {
            Socket __ConnectingSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            int __Counter = 0;
            while (!__ConnectingSocket.Connected)
            {
                Thread.Sleep(1000);

                try
                {
                    __ConnectingSocket.Connect(new IPEndPoint(IPAddress.Parse(_IP), _Port));
                }
                catch
                {
                    __Counter++;
                    if (__Counter > 10)
                    {
                        _ServerNotFound();
                        throw new Exception("Server not found!");
                    }
                }
            }
            if (__ConnectingSocket.Connected)
            {
                _ServerFound();
                SetupClient(__ConnectingSocket); 
            }
            
        }

        private void SetupClient(Socket _Socket)
        {
            TcpNode = new cTcpNode(_Socket, Guid.NewGuid().ToString(), this);
        }

        public void Send(string _Message)
        {
            try
            {
                TcpNode.Send(_Message);
            }
            catch(Exception ex)
            {
                
            }
        }

        public void OnPacketReceive(INode _Sender, cBasePacket _Data)
        {
            TcpDataReceiver.OnTcpMessageReceive((cTcpNode)_Sender, _Data);
        }

        public void OnDisconnected(INode _Node)
        {
            TcpDataReceiver.OnTcpDisconnected((cTcpNode)_Node);
        }
    }
}
