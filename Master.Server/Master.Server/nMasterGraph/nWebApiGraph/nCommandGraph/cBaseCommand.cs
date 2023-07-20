using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Master.Server.nMasterGraph.nWebApiGraph.nCommandGraph.nCommandIDs;
using Master.Server.nSessionManager;

namespace Master.Server.nMasterGraph.nWebApiGraph.nCommandGraph
{
    public abstract class cBaseCommand
    {
        public CommandIDs CommandID;
        public cBaseGraph Graph { get; set; }

        public cBaseCommand(cBaseGraph _Graph, CommandIDs _CommandID)
        {
            CommandID = _CommandID;
            Graph = _Graph;
        }

        public abstract void Interpret(cSession _Session , JToken _JsonObject);
    }

}
