using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assets.Scripts.nMasterGraph.nWebApiGraph.nCommandGraph.nCommandIDs;


namespace Assets.Scripts.nMasterGraph.nWebApiGraph.nCommandGraph
{
    public abstract class cBaseCommand
    {
        public CommandIDs CommandID;
        public cMasterGraph Graph { get; set; }

        public cBaseCommand(cMasterGraph _Graph, CommandIDs _CommandID)
        {
            CommandID = _CommandID;
            Graph = _Graph;
        }

        public abstract void Interpret(JToken _JsonObject);
    }

}
