using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;
using Game.Server.nDatabase.nEntities;
using Newtonsoft.Json.Linq;

namespace Game.Server.nGameGraph.nWebApiGraph.nActionGraph.nActions.nPlayerTransformActions
{
    public class cPlayerTransformProps : cBaseProps
    {
        public long UserID { get; set; }
        public Vector3 Position { get; set; }

    }
}
