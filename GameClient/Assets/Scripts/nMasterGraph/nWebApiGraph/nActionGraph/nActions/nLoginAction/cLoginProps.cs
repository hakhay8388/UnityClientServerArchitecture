using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace Assets.Scripts.nMasterGraph.nWebApiGraph.nActionGraph.nActions.nLoginAction
{
    public class cLoginProps : cBaseProps
    {
        public string UserName { get; set; }

        public cLoginProps(string _UserName)
            :base()
        {
            UserName = _UserName;
        }
    }
}
