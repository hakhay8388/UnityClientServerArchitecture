using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Game.Server.nGameGraph.nWebApiGraph.nListenerGraph
{
    public class cBaseListener 
    {
        public cBaseGraph Graph { get; set; }

		public cBaseListener(cBaseGraph _Graph)
        {
            Graph = _Graph;
        }

        public void Init()
        {
            Graph.CommandGraph.ConnectToCommands(this);
        }
    }
}
