using Master.Server.nMasterGraph.nWebApiGraph.nActionGraph.nActions.nTestAction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Master.Server.nMasterGraph.nWebApiGraph.nActionGraph
{
    public class cActionGraph
    {

        public cTestAction TestAction { get; set; }

        cBaseGraph Graph { get; set; }

        public cActionGraph(cBaseGraph _Graph)
        {
            Graph = _Graph;
        }

        public void Init()
        {
            TestAction = new cTestAction(Graph);
        }
    }
}