using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Game.Server.nDatabase.nEntities;
using Newtonsoft.Json.Linq;

namespace Game.Server.nGameGraph.nWebApiGraph.nActionGraph.nActions.nCountDownAction
{
    public class cCountDownProps : cBaseProps
    {
        public int Value { get; set; }
    }
}
