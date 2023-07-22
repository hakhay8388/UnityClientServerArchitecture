using Assets.Scripts.nMasterGraph.nWebApiGraph.nActionGraph;
using Assets.Scripts.nMasterGraph.nWebApiGraph.nCommandGraph;
using Assets.Scripts.nMasterGraph.nWebApiGraph.nListenerGraph;
using System;
using System.Diagnostics;


public class cMasterGraph
{
    public cActionGraph ActionGraph { get; set; }
    public cCommandGraph CommandGraph { get; set; }
    public cListenerGraph ListenerGraph { get; set; }
    public cBaseConnector Connector { get; set; }

    public cMasterGraph(cBaseConnector _Connector)
    {
        Connector = _Connector;
        Init();
    }

    public void Init()
    {
        ActionGraph = new cActionGraph(this);
        CommandGraph = new cCommandGraph(this);
        ListenerGraph = new cListenerGraph(this);

        ActionGraph.Init();
        CommandGraph.Init();
        ListenerGraph.Init();
    }
}
