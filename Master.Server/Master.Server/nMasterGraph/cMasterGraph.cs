using Master.Server.nMasterGraph.nWebApiGraph.nActionGraph;
using Master.Server.nMasterGraph.nWebApiGraph.nCommandGraph;
using NewClientServerSampleWithUdp;
using Master.Server.nMasterGraph.nWebApiGraph.nListenerGraph;
using System;
using System.Diagnostics;


public class cMasterGraph : cBaseGraph
{
    public cMasterGraph(cServer _Server)
        : base(_Server)
    {
    }

    public override void Init()
    {
        ActionGraph = new cActionGraph(this);
        CommandGraph = new cCommandGraph(this);
        ListenerGraph = new cListenerGraph(this);

        ActionGraph.Init();
        CommandGraph.Init();
        ListenerGraph.Init();
    }
}
