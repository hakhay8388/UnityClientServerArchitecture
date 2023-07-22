
using Assets.Scripts.nGameGraph.nWebApiGraph.nListenerGraph.nGeneralListener;

namespace Assets.Scripts.nGameGraph.nWebApiGraph.nListenerGraph
{
    public class cListenerGraph
    {
        public cGameGraph Graph { get; set; }

        public cGeneralListener GeneralListener { get; set; }
        public cListenerGraph(cGameGraph _Graph)
        {
            Graph = _Graph;
        }

        public void Init()
        {
            GeneralListener = new cGeneralListener(Graph);

            GeneralListener.Init();
        }
    }
}
