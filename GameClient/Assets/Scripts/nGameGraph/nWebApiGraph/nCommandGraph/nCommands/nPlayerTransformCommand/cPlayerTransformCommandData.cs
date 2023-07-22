using Assets.Scripts.nDatabase.nEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;

namespace Assets.Scripts.nGameGraph.nWebApiGraph.nCommandGraph.nCommands.nPlayerTransformCommand
{
    public class cPlayerTransformCommandData
    {
        public long UserID { get; set; }
        public Vector3 Position { get; set; }
    }
}
