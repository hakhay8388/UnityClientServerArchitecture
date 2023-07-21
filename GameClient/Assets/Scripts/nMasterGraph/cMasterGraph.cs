using Assets.Scripts.nMasterGraph.nWebApiGraph.nActionGraph;
using Assets.Scripts.nMasterGraph.nWebApiGraph.nCommandGraph;
using Assets.Scripts.nMasterGraph.nWebApiGraph.nListenerGraph;
using System;
using System.Diagnostics;


public class cMasterGraph : cBaseGraph
{
    public cMasterGraph(cBaseConnector _Connector)
        : base(_Connector)
    {
        Connector = _Connector;
        Init();
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
