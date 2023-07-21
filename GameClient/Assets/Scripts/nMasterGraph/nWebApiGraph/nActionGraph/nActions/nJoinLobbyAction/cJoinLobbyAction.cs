using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Assets.Scripts.nMasterGraph.nWebApiGraph.nActionGraph.nActionIDs;

namespace Assets.Scripts.nMasterGraph.nWebApiGraph.nActionGraph.nActions.nJoinLobbyAction
{
    public class cJoinLobbyAction : cBaseActionWithProps<cJoinLobbyProps>
    {
        public cJoinLobbyAction(cBaseGraph _Graph)
           : base(_Graph, ActionIDs.JoinLobby)
        {
        }
    }
}
