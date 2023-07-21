using Assets.Scripts.nMasterGraph.nWebApiGraph.nActionGraph.nActions.nGetLobbyUsersAction;
using Assets.Scripts.nMasterGraph.nWebApiGraph.nActionGraph.nActions.nIAmInLobbyAction;
using Assets.Scripts.nMasterGraph.nWebApiGraph.nActionGraph.nActions.nJoinLobbyAction;
using Assets.Scripts.nMasterGraph.nWebApiGraph.nActionGraph.nActions.nLoginAction;
using Assets.Scripts.nMasterGraph.nWebApiGraph.nActionGraph.nActions.nTestAction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Assets.Scripts.nMasterGraph.nWebApiGraph.nActionGraph
{
    public class cActionGraph
    {

        public cTestAction TestAction { get; set; }
        public cLoginAction LoginAction { get; set; }
        public cIAmInLobbyAction IAmInLobbyAction { get; set; }
        public cGetLobbyUsersAction GetLobbyUsersAction { get; set; }
        public cJoinLobbyAction JoinLobbyAction { get; set; }

        cBaseGraph Graph { get; set; }

        public cActionGraph(cBaseGraph _Graph)
        {
            Graph = _Graph;
        }

        public void Init()
        {
            TestAction = new cTestAction(Graph);
            LoginAction = new cLoginAction(Graph);
            GetLobbyUsersAction = new cGetLobbyUsersAction(Graph);
            JoinLobbyAction = new cJoinLobbyAction(Graph);
            IAmInLobbyAction = new cIAmInLobbyAction(Graph);
        }
    }
}