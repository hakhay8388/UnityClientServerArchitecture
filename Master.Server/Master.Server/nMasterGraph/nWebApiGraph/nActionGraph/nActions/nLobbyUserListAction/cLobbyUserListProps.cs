using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Master.Server.nDatabase.nEntities;
using Newtonsoft.Json.Linq;

namespace Master.Server.nMasterGraph.nWebApiGraph.nActionGraph.nActions.nLobbyUserListAction
{
    public class cLobbyUserListProps : cBaseProps
    {
        public List<cUser> Users { get; set; }
    }
}
