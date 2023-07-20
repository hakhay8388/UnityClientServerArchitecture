using Master.Server.nDatabase.nEntities;
using NewClientServerSampleWithUdp;
using NewClientServerSampleWithUdp.nSocketManagers.nSocket.nTcp.nTcpNodes;
using System;
using System.Collections.Generic;
using System.Net;

namespace Master.Server.nSessionManager
{
    public class cSession
    {
        public cServer Server { get; set; }
        public DateTime CreateTime { get; set; }
        public string ConnectionID { get; set; }
        public cTcpNode TcpNode { get; set; }

        public IPEndPoint UDP_IPEndPoint { get; set; }

        public cUser User { get; set; }

        public cSession(cServer _Server, cTcpNode _TcpNode, IPEndPoint _UDP_IPEndPoint, string _ConnectionID)
        {
            Server = _Server;
            TcpNode = _TcpNode;
            UDP_IPEndPoint = _UDP_IPEndPoint;
            ConnectionID = _ConnectionID; ;
        }
   
        public void RefreshValue()
        {
            CreateTime = DateTime.Now;
        }

        public bool IsLogined
        {
            get
            {
                return User != null;
            }
        }
    }
}
