﻿using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Master.Server.nMasterGraph.nWebApiGraph.nCommandGraph;
using System;
using Master.Server.nMasterGraph.nWebApiGraph.nActionGraph.nActionIDs;
using System.Collections.Generic;
using Master.Server.nSessionManager;

namespace Master.Server.nMasterGraph.nWebApiGraph.nActionGraph.nActions
{
    public abstract class cBaseActionWithProps<TActionProps> : cBaseAction
        where TActionProps : cBaseProps
    {
        public cBaseActionWithProps(cBaseGraph _Graph, ActionIDs _ActionID)
            :base(_Graph, _ActionID)
        {            
        }
        
        public virtual void Action(cSession _Session, TActionProps _ActionData)
        {
            Action(_Session, _ActionData.SerializeObject());
        }


        public void Action(List<cSession> _Sessions, TActionProps _ActionData)
        {
            Action(_Sessions, _ActionData.SerializeObject());
        }
    }
}
