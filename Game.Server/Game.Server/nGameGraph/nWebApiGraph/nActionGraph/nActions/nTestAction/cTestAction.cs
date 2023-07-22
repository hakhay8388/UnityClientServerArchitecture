using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Game.Server.nGameGraph.nWebApiGraph.nActionGraph.nActionIDs;

namespace Game.Server.nGameGraph.nWebApiGraph.nActionGraph.nActions.nTestAction
{
    public class cTestAction : cBaseActionWithProps<cTestProps>
    {
        public cTestAction(cBaseGraph _Graph)
           : base(_Graph, ActionIDs.Test)
        {
        }
    }
}
