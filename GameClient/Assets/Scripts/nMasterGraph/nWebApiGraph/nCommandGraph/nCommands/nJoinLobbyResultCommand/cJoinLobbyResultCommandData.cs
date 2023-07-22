using Assets.Scripts.nDatabase.nEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assets.Scripts.nMasterGraph.nWebApiGraph.nCommandGraph.nCommands.nJoinLobbyResultCommand
{
    public class cJoinLobbyResultCommandData
    {
        public bool Success { get; set; }
        public bool GameWillStart { get; set; }

        public int Port { get; set; }
        public List<cUser> Users { get; set; }
    }
}
