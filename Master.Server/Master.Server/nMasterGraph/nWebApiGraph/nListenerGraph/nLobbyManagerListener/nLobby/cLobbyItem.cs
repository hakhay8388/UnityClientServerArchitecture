using Master.Server.nDatabase.nEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Master.Server.nMasterGraph.nWebApiGraph.nListenerGraph.nLobbyManagerListener.nLobby
{
    public class cLobbyItem
    {
        public string LobbyID { get; set; }
        public List<cUser> Users { get; set; }

        public bool GameStarted { get; set; }
        public cLobbyItem(string _LobbyID) 
        {
            LobbyID = _LobbyID;
            GameStarted = false;
            Users = new List<cUser>();
        }
    }
}
