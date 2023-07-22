using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Game.Server.nDatabase.nEntities;
using Newtonsoft.Json.Linq;

namespace Game.Server.nGameGraph.nWebApiGraph.nActionGraph.nActions.nOpenGameAction
{
    public class cOpenGameProps : cBaseProps
    {
        public List<cUser> Users { get; set; }
    }
}
