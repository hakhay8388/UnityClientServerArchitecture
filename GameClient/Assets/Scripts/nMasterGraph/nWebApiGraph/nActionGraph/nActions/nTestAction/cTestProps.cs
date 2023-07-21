using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace Assets.Scripts.nMasterGraph.nWebApiGraph.nActionGraph.nActions.nTestAction
{
    public class cTestProps : cBaseProps
    {
        public string Test { get; set; }

        public cTestProps(string _Test)
            :base()
        {
            Test = _Test;
        }
    }
}
