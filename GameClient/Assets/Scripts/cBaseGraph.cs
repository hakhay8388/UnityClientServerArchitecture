using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class cBaseGraph
{
    public cBaseConnector Connector { get; set; }
    public cBaseGraph(cBaseConnector _Connector)
    {
        Connector = _Connector;
    }
}

