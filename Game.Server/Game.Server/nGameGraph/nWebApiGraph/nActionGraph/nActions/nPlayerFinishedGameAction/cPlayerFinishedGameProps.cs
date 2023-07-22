using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;
using Game.Server.nDatabase.nEntities;
using Newtonsoft.Json.Linq;

namespace Game.Server.nGameGraph.nWebApiGraph.nActionGraph.nActions.nPlayerFinishedGameAction
{
    public class cPlayerFinishedGameProps : cBaseProps
    {
        public cUser User { get; set; }
        public int Rank { get; set; }
        public long Puan { get; set; }
    }
}
