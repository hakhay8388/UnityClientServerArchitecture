using Master.Server.nMasterGraph.nWebApiGraph.nActionGraph;
using Master.Server.nMasterGraph.nWebApiGraph.nCommandGraph;
using NewClientServerSampleWithUdp;
using Master.Server.nMasterGraph.nWebApiGraph.nListenerGraph;
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
    public cServer Server { get; set; }
    public cBaseGraph(cServer _Server)
    {
        Server = _Server;
        Init();
    }

    public abstract void Init();
}

