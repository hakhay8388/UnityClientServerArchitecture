using Master.Server.nMasterGraph.nWebApiGraph.nActionGraph.nActions.nJoinLobbyResultAction;
using Master.Server.nMasterGraph.nWebApiGraph.nActionGraph.nActions.nLobbyUserListAction;
using Master.Server.nMasterGraph.nWebApiGraph.nActionGraph.nActions.nLoginResultAction;
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
        public cLoginResultAction LoginResultAction { get; set; }

        public cLobbyUserListAction LobbyUserListAction { get; set; }

        public cJoinLobbyResultAction JoinLobbyResultAction { get; set; }

        cBaseGraph Graph { get; set; }

        public cActionGraph(cBaseGraph _Graph)
        {
            Graph = _Graph;
        }

        public void Init()
        {
            TestAction = new cTestAction(Graph);
            LoginResultAction = new cLoginResultAction(Graph);
            LobbyUserListAction = new cLobbyUserListAction(Graph);
            JoinLobbyResultAction = new cJoinLobbyResultAction(Graph);
        }
    }
}