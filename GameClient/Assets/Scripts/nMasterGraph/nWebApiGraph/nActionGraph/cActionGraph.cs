using Assets.Scripts.nMasterGraph.nWebApiGraph.nActionGraph.nActions.nNotificationAction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Assets.Scripts.nMasterGraph.nWebApiGraph.nActionGraph
{
    public class cActionGraph
    {

        public cTestAction TestAction { get; set; }

        cBaseGraph Graph { get; set; }

        public cActionGraph(cBaseGraph _Graph)
        {
            Graph = _Graph;
            Init();
        }

        public void Init()
        {
            TestAction = new cTestAction(Graph);
        }
    }
}