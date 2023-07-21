using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Master.Server.nDatabase.nEntities;
using Newtonsoft.Json.Linq;

namespace Master.Server.nMasterGraph.nWebApiGraph.nActionGraph.nActions.nLoginResultAction
{
    public class cLoginResultProps : cBaseProps
    {
        public bool Logined { get; set; }
    }
}
