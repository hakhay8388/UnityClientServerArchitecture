using Bootstrapper.Core.nHandlers.nProcessHandler;
using Master.Server.nDatabase.nEntities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Master.Server.nMasterGraph.nWebApiGraph.nListenerGraph.nLobbyManagerListener.nLobby
{
    public class cLobbyItem
    {
        public string LobbyID { get; set; }
        public List<cUser> Users { get; set; }
        int Port { get; set; }
        public Process GameProcess { get; set; }

        public bool GameStarted { get; set; }
        public cLobbyItem(string _LobbyID) 
        {
            LobbyID = _LobbyID;
            GameStarted = false;
            Users = new List<cUser>();
        }

        public void StartServer(int _Port)
        {
            Port = _Port;
            
            Thread __Thread = new Thread(new ThreadStart(ServerStarterThread));
            __Thread.Start();
        }

        public void ServerStarterThread()
        {
            GameProcess = cProcessHandler.OpenModalProcess(Settings.GameServerPath, Port.ToString() + " " + Settings.GamePlayerCount);
        }

        public void End()
        {
            if (GameProcess != null)
            {
                GameProcess.Close();
            }            
        }

    }
}
