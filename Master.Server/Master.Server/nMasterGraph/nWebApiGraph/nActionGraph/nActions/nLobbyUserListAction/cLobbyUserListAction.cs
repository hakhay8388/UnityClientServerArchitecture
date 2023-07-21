using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Master.Server.nMasterGraph.nWebApiGraph.nActionGraph.nActionIDs;

namespace Master.Server.nMasterGraph.nWebApiGraph.nActionGraph.nActions.nLobbyUserListAction
{
    public class cLobbyUserListAction : cBaseActionWithProps<cLobbyUserListProps>
    {
        public cLobbyUserListAction(cBaseGraph _Graph)
           : base(_Graph, ActionIDs.LobbyUserList)
        {
        }
    }
}
