using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Assets.Scripts.nMasterGraph.nWebApiGraph.nActionGraph.nActionIDs;

namespace Assets.Scripts.nMasterGraph.nWebApiGraph.nActionGraph.nActions.nGetLobbyUsersAction
{
    public class cGetLobbyUsersAction : cBaseActionWithProps<cGetLobbyUsersProps>
    {
        public cGetLobbyUsersAction(cBaseGraph _Graph)
           : base(_Graph, ActionIDs.GetLobbyUsers)
        {
        }
    }
}
