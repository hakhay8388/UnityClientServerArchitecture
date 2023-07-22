using Assets.Scripts.nGameGraph.nWebApiGraph.nActionGraph.nActions.nIAmInGameAction;
using Assets.Scripts.nGameGraph.nWebApiGraph.nActionGraph.nActions.nKeyPressedAction;
using Assets.Scripts.nGameGraph.nWebApiGraph.nActionGraph.nActions.nTestAction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Assets.Scripts.nGameGraph.nWebApiGraph.nActionGraph
{
    public class cActionGraph
    {

        public cTestAction TestAction { get; set; }
        public cIAmInGameAction IAmInGameAction { get; set; }
        public cKeyPressedAction KeyPressedAction { get; set; }
        cGameGraph Graph { get; set; }

        public cActionGraph(cGameGraph _Graph)
        {
            Graph = _Graph;
        }

        public void Init()
        {
            TestAction = new cTestAction(Graph);
            IAmInGameAction = new cIAmInGameAction(Graph);
            KeyPressedAction = new cKeyPressedAction(Graph);
        }
    }
}