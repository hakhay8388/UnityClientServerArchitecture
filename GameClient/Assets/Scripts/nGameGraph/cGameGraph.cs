using Assets.Scripts.nGameGraph.nWebApiGraph.nActionGraph;
using Assets.Scripts.nGameGraph.nWebApiGraph.nCommandGraph;
using Assets.Scripts.nGameGraph.nWebApiGraph.nListenerGraph;
using System;
using System.Diagnostics;


public class cGameGraph
{
    public cActionGraph ActionGraph { get; set; }
    public cCommandGraph CommandGraph { get; set; }
    public cListenerGraph ListenerGraph { get; set; }

    public cBaseConnector Connector { get; set; }
    public cGameGraph(cBaseConnector _Connector)
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
