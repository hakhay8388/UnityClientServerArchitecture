using Master.Server.nMasterGraph.nWebApiGraph.nListenerGraph.nGeneralListener;
using Master.Server.nMasterGraph.nWebApiGraph.nListenerGraph.nLobbyManagerListener;

namespace Master.Server.nMasterGraph.nWebApiGraph.nListenerGraph
{
    public class cListenerGraph
    {
        public cBaseGraph Graph { get; set; }

        cGeneralListener GeneralListener { get; set; }

        cLobbyManagerListener LobbyManagerListener { get; set; }
        public cListenerGraph(cBaseGraph _Graph)
        {
            Graph = _Graph;
        }

        public void Init()
        {
            GeneralListener = new cGeneralListener(Graph);
            LobbyManagerListener = new cLobbyManagerListener(Graph);

            GeneralListener.Init();
            LobbyManagerListener.Init();
        }
    }
}
