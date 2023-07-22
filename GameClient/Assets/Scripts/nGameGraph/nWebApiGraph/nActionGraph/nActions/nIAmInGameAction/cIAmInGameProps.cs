using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assets.Scripts.nDatabase.nEntities;
using Newtonsoft.Json.Linq;

namespace Assets.Scripts.nGameGraph.nWebApiGraph.nActionGraph.nActions.nIAmInGameAction

{
    public class cIAmInGameProps : cBaseProps
    {
        public cUser User { get; set; }
        public cIAmInGameProps()
            :base()
        {
        }
    }
}
