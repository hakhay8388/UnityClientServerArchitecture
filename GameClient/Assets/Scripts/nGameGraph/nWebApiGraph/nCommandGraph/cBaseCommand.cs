using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assets.Scripts.nGameGraph.nWebApiGraph.nCommandGraph.nCommandIDs;


namespace Assets.Scripts.nGameGraph.nWebApiGraph.nCommandGraph
{
    public abstract class cBaseCommand
    {
        public CommandIDs CommandID;
        public cGameGraph Graph { get; set; }

        public cBaseCommand(cGameGraph _Graph, CommandIDs _CommandID)
        {
            CommandID = _CommandID;
            Graph = _Graph;
        }

        public abstract void Interpret(JToken _JsonObject);
    }

}
