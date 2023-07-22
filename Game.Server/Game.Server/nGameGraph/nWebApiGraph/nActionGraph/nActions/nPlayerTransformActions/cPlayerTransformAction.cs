using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Game.Server.nGameGraph.nWebApiGraph.nActionGraph.nActionIDs;

namespace Game.Server.nGameGraph.nWebApiGraph.nActionGraph.nActions.nPlayerTransformActions
{
    public class cPlayerTransformAction : cBaseActionWithProps<cPlayerTransformProps>
    {
        public cPlayerTransformAction(cBaseGraph _Graph)
           : base(_Graph, ActionIDs.PlayerTransform)
        {
        }
    }
}
