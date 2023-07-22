using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Assets.Scripts.nMasterGraph.nWebApiGraph.nActionGraph.nActionIDs;

namespace Assets.Scripts.nMasterGraph.nWebApiGraph.nActionGraph.nActions.nLoginAction
{
    public class cLoginAction : cBaseActionWithProps<cLoginProps>
    {
        public cLoginAction(cMasterGraph _Graph)
           : base(_Graph, ActionIDs.Login)
        {
        }
    }
}
