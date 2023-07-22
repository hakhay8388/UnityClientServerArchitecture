
using Game.Server.nDatabase.nEntities;
using Game.Server.nGameGraph.nWebApiGraph.nActionGraph.nActions.nTestAction;
using Game.Server.nGameGraph.nWebApiGraph.nCommandGraph;
using Game.Server.nGameGraph.nWebApiGraph.nCommandGraph.nCommands.nTestCommand;
using Game.Server.nSessionManager;

namespace Game.Server.nGameGraph.nWebApiGraph.nListenerGraph.nGeneralListener
{
    public class cGeneralListener : cBaseListener
        , ITestReceiver
    {
        public static int TempID = 0;
        public cGeneralListener(cBaseGraph _Graph)
          : base(_Graph)
        {
        }

        public void ReceiveTestData(cSession _Session, cListenerEvent _ListenerEvent, cTestCommandData _ReceivedData)
        {
            Graph.ActionGraph.TestAction.Action(_Session, new cTestProps() { Test = "Deneme" });
        }
    }
}
