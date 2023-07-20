using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Collections;
using System.Dynamic;
using System.ComponentModel;

namespace Assets.Scripts.nMasterGraph.nWebApiGraph.nActionGraph.nActions
{
    public abstract class cBaseProps
    {
		public cBaseProps()
		{
		}

        public virtual JObject SerializeObject()
        {
			JObject __JObject = JObject.FromObject(this);
            return __JObject;
        }
    }
}
