using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Master.Server.nDatabase.nEntities;
using Newtonsoft.Json.Linq;

namespace Master.Server.nMasterGraph.nWebApiGraph.nActionGraph.nActions.nJoinLobbyResultAction
{
    public class cJoinLobbyResultProps : cBaseProps
    {
        public bool Success { get; set; }
        public List<cUser> Users { get; set; }
    }
}
