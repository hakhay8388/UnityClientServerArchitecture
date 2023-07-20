using Master.Server.nMasterGraph.nWebApiGraph.nListenerGraph.nGeneralListener;

namespace Master.Server.nMasterGraph.nWebApiGraph.nListenerGraph
{
    public class cListenerGraph
    {
        public cBaseGraph Graph { get; set; }

        cGeneralListener GeneralListener { get; set; }
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
