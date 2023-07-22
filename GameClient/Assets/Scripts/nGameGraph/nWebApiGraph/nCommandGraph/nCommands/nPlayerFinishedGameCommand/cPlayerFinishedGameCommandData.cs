using Assets.Scripts.nDatabase.nEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;

namespace Assets.Scripts.nGameGraph.nWebApiGraph.nCommandGraph.nCommands.nPlayerFinishedGameCommand
{
    public class cPlayerFinishedGameCommandData
    {
        public cUser User { get; set; }
        public int Rank { get; set; }
        public long Puan { get; set; }

    }
}
