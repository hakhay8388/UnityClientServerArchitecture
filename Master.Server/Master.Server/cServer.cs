using Master.Server.nSessionManager;
using NewClientServerSampleWithUdp.nSocketManagers.nSocket;
using NewClientServerSampleWithUdp.nSocketManagers.nSocket.nPacket;
using NewClientServerSampleWithUdp.nSocketManagers.nSocket.nTcp.nTcpNodes;
using NewClientServerSampleWithUdp.nSocketManagers.nSocket.nUdp;
using NewClientServerSampleWithUdp.nSocketManagers.nSocket.nUdp.nUdpNodes;
using NewClientServerSampleWithUdp.nSocketManagers.nTcp;
using NewClientServerSampleWithUdp.nSocketManagers.nUdp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace NewClientServerSampleWithUdp
{
    public class cServer: ITcpDataReceiver, IUdpDataReceiver
    {
        public cSessionManager SessionManager { get; set; }
        public cMasterGraph MasterGraph { get; set; }
        public cTcpServer TcpServer { get; set; }
        public cUdpServer UdpServer { get; set; }
        public cServer(int _Port)
        {
            Init(_Port);
        }

        private void Init(int _Port)
        {
            SessionManager = new cSessionManager(this);
            MasterGraph = new cMasterGraph(this);
            TcpServer = new cTcpServer(_Port, this);
            TcpServer.StartListening();

            UdpServer = new cUdpServer(TcpServer, this);
        }

        public bool OnTcpMessageReceive(cTcpNode _Sender, cBasePacket _Data)
        {
            if (_Data.Message == "GetConnectionID")
            {
                _Sender.Send("GetConnectionID:"+_Sender.Id);
            }
            return true;
        }

        public void OnTcpDisconnected(cTcpNode _Node)
        {
            SessionManager.DeleteSessionByConnectionID(_Node.Id);
        }

        public bool OnUdpMessageReceive(INode _Sender, cBasePacket _Data)
        {
            cBaseUdpNode __UdpServer = (cBaseUdpNode)_Sender;
            if (_Data.Message.StartsWith("ID"))
            {
                string __ConnectionID = _Data.Message.Split(":")[1];
                cTcpNode __TcpNode = TcpServer.TcpNodes.Where(__Item => __Item.Id == __ConnectionID).FirstOrDefault();
                __TcpNode.SetUdpNode(_Data.IPEndPoint);
                UdpServer.Send(_Data.IPEndPoint, "ID:" + __TcpNode.Id);
                SessionManager.CreateSession(this, __TcpNode, _Data.IPEndPoint, __TcpNode.Id);
            }
            else
            {
                cSession __Session = SessionManager.GetSessionByIPEndPoint(_Data.IPEndPoint);
                MasterGraph.CommandGraph.InterpreterCommand(__Session, _Data.Message);
                //UdpServer.SendToAll(_Data.Message);
            }
            return true;            
        }

        public void OnUdpDisconnected(INode _Node)
        {
            
        }
    }
}
