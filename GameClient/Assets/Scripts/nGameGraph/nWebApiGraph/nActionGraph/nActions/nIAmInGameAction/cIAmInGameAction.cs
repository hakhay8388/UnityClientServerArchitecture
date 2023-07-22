using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Assets.Scripts.nGameGraph.nWebApiGraph.nActionGraph.nActionIDs;

namespace Assets.Scripts.nGameGraph.nWebApiGraph.nActionGraph.nActions.nIAmInGameAction
{
    public class cIAmInGameAction : cBaseActionWithProps<cIAmInGameProps>
    {
        public cIAmInGameAction(cGameGraph _Graph)
           : base(_Graph, ActionIDs.IAmInGame)
        {
        }
    }
}
