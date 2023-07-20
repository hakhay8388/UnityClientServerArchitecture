using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;
using NewClientServerSampleWithUdp;
using NewClientServerSampleWithUdp.nSocketManagers.nSocket.nTcp.nTcpNodes;
using System.Net;

namespace Master.Server.nSessionManager
{
    public class cSessionManager
    {
        private List<cSession> SessionItems = null;

        public cServer Server { get; set; }

        public cSessionManager(cServer _Server)
        {
            SessionItems = new List<cSession>();
            Server = _Server;
        }

        public List<cSession> GetSessionItems()
        {
            return SessionItems;
        }

        public List<cSession> GetSessionByUserID(long _UserID)
        {
            lock (SessionItems)
            {
                return SessionItems.Where(__Item => __Item.User != null && __Item.User.ID == _UserID).ToList();
            }
        }

        public List<cSession> GetSessionByUserID(List<long> _UserIDList)
        {
            lock (SessionItems)
            {
                return SessionItems.Where(__Item => __Item.User != null && _UserIDList.Contains(__Item.User.ID)).ToList();
            }
        }
        public List<long> GetAllOnlineUsers()
        {
            lock (SessionItems)
            {
                return SessionItems.Where(__Item => __Item.User != null).Select(x => x.User.ID).ToList();
            }
        }
        public List<cSession> GetSessionByUserIDs(List<long> _UserID)
        {
            lock (SessionItems)
            {
                List<cSession> __ResultList = SessionItems.Where((__Item) =>
                {
                    if (__Item.User != null)
                    {
                        int __Index = _UserID.IndexOf(__Item.User.ID);
                        return __Item.User != null && __Index > -1;
                    }
                    return false;
                }).ToList();
                return __ResultList;
            }
        }

        public cSession CreateSession(cServer _Server, cTcpNode _TcpNode, IPEndPoint _UDP_IPEndPoint, string _ConnectionID)
        {
            lock (SessionItems)
            {
                cSession __CurrentSession = GetSessionByConnectionID(_ConnectionID);
                if (__CurrentSession == null)
                {
                    __CurrentSession = new cSession(_Server, _TcpNode, _UDP_IPEndPoint, _ConnectionID);
                }
                else
                {
                    __CurrentSession.RefreshValue();
                }

                SessionItems.Remove(__CurrentSession);
                SessionItems.Insert(0, __CurrentSession);

                return __CurrentSession;
            }
        }

        public void DeleteSessionByConnectionID(string _ConnectionID)
        {
            lock (SessionItems)
            {
                cSession __CurrentSession = GetSessionByConnectionID(_ConnectionID);
                if (__CurrentSession != null)
                {
                    SessionItems.Remove(__CurrentSession);
                }
            }
        }

        public cSession GetSessionByConnectionID(string _ConnectionID)
        {
            lock (SessionItems)
            {
                return SessionItems.Find(__Item => __Item.ConnectionID == _ConnectionID);
            }
        }

        public cSession GetSessionByIPEndPoint(IPEndPoint _IPEndPoint)
        {
            return SessionItems.Find(__Item => __Item.UDP_IPEndPoint.ToString() == _IPEndPoint.ToString());
        }
    }
}
