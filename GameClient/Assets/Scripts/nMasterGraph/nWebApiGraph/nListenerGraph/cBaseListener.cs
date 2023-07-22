using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assets.Scripts.nMasterGraph.nWebApiGraph.nListenerGraph
{
    public class cBaseListener 
    {
        public cMasterGraph Graph { get; set; }

		public cBaseListener(cMasterGraph _Graph)
        {
            Graph = _Graph;
        }

        public void Init()
        {
            Graph.CommandGraph.ConnectToCommands(this);
        }
    }
}
