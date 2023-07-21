

using Assets.Scripts.nMasterGraph.nWebApiGraph.nCommandGraph;
using Assets.Scripts.nMasterGraph.nWebApiGraph.nCommandGraph.nCommands.nJoinLobbyResultCommand;
using Assets.Scripts.nMasterGraph.nWebApiGraph.nCommandGraph.nCommands.nLobbyUserListCommand;
using Assets.Scripts.nMasterGraph.nWebApiGraph.nCommandGraph.nCommands.nLoginResultCommand;
using Assets.Scripts.nMasterGraph.nWebApiGraph.nCommandGraph.nCommands.nTestCommand;

namespace Assets.Scripts.nMasterGraph.nWebApiGraph.nListenerGraph.nGeneralListener
{
    public class cGeneralListener : cBaseListener
        , ITestReceiver
        , ILoginResultReceiver
        , IJoinLobbyResultReceiver
        , ILobbyUserListReceiver
    {
        public cGeneralListener(cBaseGraph _Graph)
          : base(_Graph)
        {
        }

        public void ReceiveJoinLobbyResultData(cListenerEvent _ListenerEvent, cJoinLobbyResultCommandData _ReceivedData)
        {
            //throw new System.NotImplementedException();
        }

        public void ReceiveLobbyUserListData(cListenerEvent _ListenerEvent, cLobbyUserListCommandData _ReceivedData)
        {
            //throw new System.NotImplementedException();
        }

        public void ReceiveLoginResultData(cListenerEvent _ListenerEvent, cLoginResultCommandData _ReceivedData)
        {
            //throw new System.NotImplementedException();
        }

        public void ReceiveTestData(cListenerEvent _ListenerEvent, cTestCommandData _ReceivedData)
        {
            //throw new System.NotImplementedException();
        }
    }
}
