using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Assets.Scripts.nGameGraph.nWebApiGraph.nCommandGraph;
using System;
using Assets.Scripts.nGameGraph.nWebApiGraph.nActionGraph.nActionIDs;
using System.Collections.Generic;

namespace Assets.Scripts.nGameGraph.nWebApiGraph.nActionGraph.nActions
{
    public abstract class cBaseActionWithProps<TActionProps> : cBaseAction
        where TActionProps : cBaseProps
    {
        public cBaseActionWithProps(cGameGraph _Graph, ActionIDs _ActionID)
            :base(_Graph, _ActionID)
        {            
        }
        
        public virtual void Action(TActionProps _ActionData)
        {
            Action(_ActionData.SerializeObject());
        }
	}
}
