using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assets.Scripts.nGameGraph.nWebApiGraph.nListenerGraph
{
    public class cBaseListener 
    {
        public cGameGraph Graph { get; set; }

		public cBaseListener(cGameGraph _Graph)
        {
            Graph = _Graph;
        }

        public void Init()
        {
            Graph.CommandGraph.ConnectToCommands(this);
        }
    }
}
