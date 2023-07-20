
using Master.Server.nMasterGraph.nWebApiGraph.nActionGraph.nActions.nTestAction;
using Master.Server.nMasterGraph.nWebApiGraph.nCommandGraph;
using Master.Server.nMasterGraph.nWebApiGraph.nCommandGraph.nCommands.nTestCommand;
using Master.Server.nSessionManager;

namespace Master.Server.nMasterGraph.nWebApiGraph.nListenerGraph.nGeneralListener
{
    public class cGeneralListener : cBaseListener
        , ITestReceiver
    {
        public cGeneralListener(cBaseGraph _Graph)
          : base(_Graph)
        {
        }

        public void ReceiveTestData(cSession _Session, cListenerEvent _ListenerEvent, cTestCommandData _ReceivedData)
        {
            Graph.ActionGraph.TestAction.Action(_Session, new cTestProps("Denem22e"));
        }
    }
}
