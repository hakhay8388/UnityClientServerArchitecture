using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Assets.Scripts.nGameGraph.nWebApiGraph.nActionGraph.nActionIDs;

namespace Assets.Scripts.nGameGraph.nWebApiGraph.nActionGraph.nActions.nKeyPressedAction
{
    public class cKeyPressedAction : cBaseActionWithProps<cKeyPressedProps>
    {
        public cKeyPressedAction(cGameGraph _Graph)
           : base(_Graph, ActionIDs.KeyPressed)
        {
        }
    }
}
