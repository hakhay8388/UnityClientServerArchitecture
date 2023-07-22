using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assets.Scripts.nDatabase.nEntities;
using Newtonsoft.Json.Linq;

namespace Assets.Scripts.nGameGraph.nWebApiGraph.nActionGraph.nActions.nKeyPressedAction

{
    public class cKeyPressedProps : cBaseProps
    {
        public bool[] Keys { get; set; }
        public cKeyPressedProps()
            :base()
        {
        }
    }
}
