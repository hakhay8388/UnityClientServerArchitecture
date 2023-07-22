using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Game.Server.nGameGraph.nWebApiGraph.nActionGraph.nActionIDs;

namespace Game.Server.nGameGraph.nWebApiGraph.nActionGraph.nActions.nPlayerFinishedGameAction
{
    public class cPlayerFinishedGameAction : cBaseActionWithProps<cPlayerFinishedGameProps>
    {
        public cPlayerFinishedGameAction(cBaseGraph _Graph)
           : base(_Graph, ActionIDs.PlayerFinishedGame)
        {
        }
    }
}
