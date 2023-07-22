using Game.Server.nGameGraph.nWebApiGraph.nActionGraph.nActions.nCountDownAction;
using Game.Server.nGameGraph.nWebApiGraph.nActionGraph.nActions.nOpenGameAction;
using Game.Server.nGameGraph.nWebApiGraph.nActionGraph.nActions.nPlayerTransformActions;
using Game.Server.nGameGraph.nWebApiGraph.nActionGraph.nActions.nReturnToLobbyAction;
using Game.Server.nGameGraph.nWebApiGraph.nActionGraph.nActions.nTestAction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Game.Server.nGameGraph.nWebApiGraph.nActionGraph
{
    public class cActionGraph
    {

        public cTestAction TestAction { get; set; }
        public cOpenGameAction OpenGameAction { get; set; }
        public cReturnToLobbyAction ReturnToLobbyAction { get; set; }
        public cCountDownAction CountDownAction { get; set; }
        public cPlayerTransformAction PlayerTransformAction { get; set; }


        cBaseGraph Graph { get; set; }

        public cActionGraph(cBaseGraph _Graph)
        {
            Graph = _Graph;
        }

        public void Init()
        {
            TestAction = new cTestAction(Graph);
            OpenGameAction = new cOpenGameAction(Graph);
            CountDownAction = new cCountDownAction(Graph);
            ReturnToLobbyAction =  new cReturnToLobbyAction(Graph);
            PlayerTransformAction = new cPlayerTransformAction(Graph);
        }
    }
}