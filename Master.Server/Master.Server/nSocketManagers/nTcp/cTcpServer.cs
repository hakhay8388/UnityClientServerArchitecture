using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using NewClientServerSampleWithUdp.nSocketManagers.nSocket.nPacket;
using NewClientServerSampleWithUdp.nSocketManagers.nSocket.nTcp.nTcpNodes;
using NewClientServerSampleWithUdp.nSocketManagers.nSocket;
using NewClientServerSampleWithUdp.nSocketManagers.nSocket.nTcp;

namespace NewClientServerSampleWithUdp.nSocketManagers.nTcp
{
    public class cTcpServer : INodeEventReceiver
    {
        public List<cTcpNode> TcpNodes = new List<cTcpNode>();
        public Socket MainListenerSocket { private set; get; }
        public int Port { private set; get; }

        ITcpDataReceiver TcpDataReceiver { set; get; }

        public cTcpServer(int _Port, ITcpDataReceiver _TcpDataReceiver)
        {
            Port = _Port;
            TcpDataReceiver = _TcpDataReceiver;
            MainListenerSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }

        public void StartListening()
        {
            try
            {
                Console.WriteLine($"Listening started port:{Port} protocol type: {ProtocolType.Tcp}");
                MainListenerSocket.Bind(new IPEndPoint(IPAddress.Any, Port));
                MainListenerSocket.Listen(10);
                MainListenerSocket.BeginAccept(AcceptCallback, MainListenerSocket);
            }
            catch (Exception _Ex)
            {
                throw new Exception("Listening Error : " + _Ex);
            }
        }

        private cTcpNode GetClientByID(string _Guid)
        {
            cTcpNode __Client = TcpNodes.Find(__Item => __Item.Id == _Guid);
            return __Client;
        }

        private string CreateID()
        {
            string __Guid = Guid.NewGuid().ToString();
            while (GetClientByID(__Guid) != null)
            {
                __Guid = Guid.NewGuid().ToString();
            }
            return __Guid;
        }

        private void AcceptCallback(IAsyncResult _AsyncResult)
        {
            try
            {
                Console.WriteLine($"Accept CallBack port:{Port} protocol type: {ProtocolType.Tcp}");
                Socket __AcceptedSocket = MainListenerSocket.EndAccept(_AsyncResult);

                TcpNodes.Add(new cTcpNode(__AcceptedSocket, CreateID(), this));

                MainListenerSocket.BeginAccept(AcceptCallback, MainListenerSocket);
            }
            catch (Exception _Ex)
            {
                throw new Exception("Base Accept Error : " + _Ex);
            }
        }

        public void RemoveClient(string _Id)
        {
            TcpNodes.Remove(GetClientByID(_Id));
        }

        public void RemoveClient(cTcpNode _Client)
        {
            TcpNodes.Remove(_Client);
        }

        public void SendToAll(string _Data)
        {
            foreach (cTcpNode __Client in TcpNodes)
            {
                if (__Client.Connected)
                {
                    __Client.Send(_Data);
                }
            }
        }

        public void OnPacketReceive(INode _Sender, cBasePacket _Data)
        {
            TcpDataReceiver.OnTcpMessageReceive((cTcpNode)_Sender, _Data);
        }

        public void OnDisconnected(INode _Node)
        {
            RemoveClient((cTcpNode)_Node);
            TcpDataReceiver.OnTcpDisconnected((cTcpNode)_Node);
        }
    }
}
