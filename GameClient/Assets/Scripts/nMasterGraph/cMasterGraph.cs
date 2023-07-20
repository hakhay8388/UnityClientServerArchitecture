using Assets.Scripts.nMasterGraph.nWebApiGraph.nActionGraph;
using Assets.Scripts.nMasterGraph.nWebApiGraph.nCommandGraph;
using System;
using System.Diagnostics;


public class cMasterGraph : cBaseGraph
{
    public cActionGraph ActionGraph { get;  set; }
    public cCommandGraph CommandGraph { get; set; }
    public cMasterGraph(cBaseConnector _Connector)
        : base(_Connector)
    {
        Connector = _Connector;
        Init();
    }

    public void Init()
    {
        ActionGraph = new cActionGraph(this);
        CommandGraph = new cCommandGraph(this);
    }
}
