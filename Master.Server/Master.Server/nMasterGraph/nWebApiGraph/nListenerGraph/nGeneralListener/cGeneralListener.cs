
using Master.Server.nDatabase;
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
            cUser __User =  Mongo.GetUserByName(_ReceivedData.UserName);
            if (__User == null)
            {
                __User = Mongo.AddUser(_ReceivedData.UserName);
            }

            _Session.User = __User;
            Graph.ActionGraph.LoginResultAction.Action(_Session, new cLoginResultProps() { Logined = true, User = _Session.User });
        }

        public void ReceiveTestData(cSession _Session, cListenerEvent _ListenerEvent, cTestCommandData _ReceivedData)
        {
            Graph.ActionGraph.TestAction.Action(_Session, new cTestProps() { Test = "Deneme" });
        }
    }
}
