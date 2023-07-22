using Game.Server.nGameGraph.nWebApiGraph.nListenerGraph.nGameManagerListener;
using Game.Server.nGameGraph.nWebApiGraph.nListenerGraph.nGeneralListener;

namespace Game.Server.nGameGraph.nWebApiGraph.nListenerGraph
{
    public class cListenerGraph
    {
        public cBaseGraph Graph { get; set; }

        cGeneralListener GeneralListener { get; set; }

        cGameManagerListener GameManagerListener { get; set; }
        public cListenerGraph(cBaseGraph _Graph)
        {
            Graph = _Graph;
        }

        public void Init()
        {
            GeneralListener = new cGeneralListener(Graph);
            GameManagerListener = new cGameManagerListener(Graph);

            GeneralListener.Init();
            GameManagerListener.Init();
        }
    }
}
