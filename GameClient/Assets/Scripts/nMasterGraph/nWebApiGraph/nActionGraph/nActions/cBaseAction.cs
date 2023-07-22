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
        public cMasterGraph Graph { get; set; }

        public cBaseAction(cMasterGraph _Graph, ActionIDs _ActionID)
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

        protected void Action(JObject _Object, bool _UseUDP = false)
        {
            JObject __JObject = PrepereObject(_Object);
            Graph.Connector.Send(JsonConvert.SerializeObject(__JObject));
        }
        
        public virtual void Action(bool _UseUDP = false)
        {
            Action(JObject.FromObject(new { }), _UseUDP);
        }
    }
}
