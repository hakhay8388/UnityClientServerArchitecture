
using Assets.Scripts.nMasterGraph.nWebApiGraph.nListenerGraph.nGeneralListener;

namespace Assets.Scripts.nMasterGraph.nWebApiGraph.nListenerGraph
{
    public class cListenerGraph
    {
        public cBaseGraph Graph { get; set; }

        public cGeneralListener GeneralListener { get; set; }
        public cListenerGraph(cBaseGraph _Graph)
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
