
using Master.Server.nDatabase.nEntities;
using Master.Server.nMasterGraph.nWebApiGraph.nActionGraph.nActions.nLoginResultAction;
using Master.Server.nMasterGraph.nWebApiGraph.nActionGraph.nActions.nTestAction;
using Master.Server.nMasterGraph.nWebApiGraph.nCommandGraph;
using Master.Server.nMasterGraph.nWebApiGraph.nCommandGraph.nCommands.nLoginCommand;
using Master.Server.nMasterGraph.nWebApiGraph.nCommandGraph.nCommands.nTestCommand;
using Master.Server.nSessionManager;

namespace Master.Server.nMasterGraph.nWebApiGraph.nListenerGraph.nGeneralListener
{
    public class cGeneralListener : cBaseListener
        , ITestReceiver
        , ILoginReceiver
    {
        public static int TempID = 0;
        public cGeneralListener(cBaseGraph _Graph)
          : base(_Graph)
        {
        }

        public void ReceiveLoginData(cSession _Session, cListenerEvent _ListenerEvent, cLoginCommandData _ReceivedData)
        {
            TempID++;
            _Session.User = new cUser() { Name = _ReceivedData.UserName, ID = TempID };
            Graph.ActionGraph.LoginResultAction.Action(_Session, new cLoginResultProps() { Logined = true });
        }

        public void ReceiveTestData(cSession _Session, cListenerEvent _ListenerEvent, cTestCommandData _ReceivedData)
        {
            Graph.ActionGraph.TestAction.Action(_Session, new cTestProps() { Test = "Deneme" });
        }
    }
}
