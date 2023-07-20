using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Assets.Scripts.nMasterGraph.nWebApiGraph.nCommandGraph;
using System;
using Assets.Scripts.nMasterGraph.nWebApiGraph.nActionGraph.nActionIDs;
using System.Collections.Generic;

namespace Assets.Scripts.nMasterGraph.nWebApiGraph.nActionGraph.nActions
{
    public abstract class cBaseAction
    {
        public ActionIDs ActionID { get; set; }
        public cBaseGraph Graph { get; set; }

        public cBaseAction(cBaseGraph _Graph, ActionIDs _ActionID)
        {
            Graph = _Graph;
            ActionID = _ActionID;
        }

        protected JObject PrepereObject(JObject _Object)
        {
            JObject __JsonObject = new JObject();
            //__JsonObject["ActionID"] = JObject.FromObject(ActionID);
            __JsonObject["CID"] = ActionID.ID;
            __JsonObject["Data"] = _Object;
            return __JsonObject;
        }

        protected void Action(JObject _Object)
        {
            JObject __JObject = PrepereObject(_Object);
            Graph.Connector.Send(JsonConvert.SerializeObject(__JObject));
        }
        
        public virtual void Action()
        {
            Action(JObject.FromObject(new { }));
        }
    }
}
