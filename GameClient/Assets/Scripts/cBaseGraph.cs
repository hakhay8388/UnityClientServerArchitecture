using Assets.Scripts.nMasterGraph.nWebApiGraph.nActionGraph;
using Assets.Scripts.nMasterGraph.nWebApiGraph.nCommandGraph;
using Assets.Scripts.nMasterGraph.nWebApiGraph.nListenerGraph;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public abstract class cBaseGraph
{
    public cActionGraph ActionGraph { get; set; }
    public cCommandGraph CommandGraph { get; set; }
    public cListenerGraph ListenerGraph { get; set; }
    public cBaseConnector Connector { get; set; }
    public cBaseGraph(cBaseConnector _Connector)
    {
        Connector = _Connector;
        Init();
    }


    public abstract void Init();
}
