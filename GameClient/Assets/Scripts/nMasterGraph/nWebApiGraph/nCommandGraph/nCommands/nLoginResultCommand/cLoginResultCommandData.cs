using Assets.Scripts.nDatabase.nEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assets.Scripts.nMasterGraph.nWebApiGraph.nCommandGraph.nCommands.nLoginResultCommand
{
    public class cLoginResultCommandData
    {
        public cUser User { get; set; }
        public bool Logined { get; set; }
    }
}
