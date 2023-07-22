using Game.Server.nGameGraph.nWebApiGraph.nActionGraph;
using Game.Server.nGameGraph.nWebApiGraph.nCommandGraph;
using NewClientServerSampleWithUdp;
using Game.Server.nGameGraph.nWebApiGraph.nListenerGraph;
using System;
using System.Diagnostics;


public class cGameGraph : cBaseGraph
{
    public cGameGraph(cServer _Server)
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
