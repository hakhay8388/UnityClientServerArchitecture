

using Assets.Scripts.nGameGraph.nWebApiGraph.nActionGraph.nActions.nIAmInGameAction;
using Assets.Scripts.nGameGraph.nWebApiGraph.nCommandGraph;
using Assets.Scripts.nGameGraph.nWebApiGraph.nCommandGraph.nCommands.nTestCommand;

namespace Assets.Scripts.nGameGraph.nWebApiGraph.nListenerGraph.nGeneralListener
{
    public class cGeneralListener : cBaseListener
        , ITestReceiver
    {
        public cGeneralListener(cGameGraph _Graph)
          : base(_Graph)
        {
        }


        public void ReceiveTestData(cListenerEvent _ListenerEvent, cTestCommandData _ReceivedData)
        {
            //throw new System.NotImplementedException();
        }
    }
}
