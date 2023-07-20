using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Master.Server.nMasterGraph.nWebApiGraph.nCommandGraph;
using System;
using Master.Server.nMasterGraph.nWebApiGraph.nActionGraph.nActionIDs;
using System.Collections.Generic;
using Master.Server.nSessionManager;

namespace Master.Server.nMasterGraph.nWebApiGraph.nActionGraph.nActions
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

        protected void Action(cSession _Session, JObject _Object)
        {
            JObject __JObject = PrepereObject(_Object);
            Graph.Server.UdpServer.Send(_Session.UDP_IPEndPoint,  (JsonConvert.SerializeObject(__JObject)));
        }

        protected void Action(List<cSession> _Sessions, JObject _Object)
        {
            JObject __JObject = PrepereObject(_Object);
            for (int i = 0; i < _Sessions.Count; i++)
            {
                Graph.Server.UdpServer.Send(_Sessions[i].UDP_IPEndPoint, (JsonConvert.SerializeObject(__JObject)));
            }            
        }

        public virtual void Action(cSession _Session)
        {
            Action(_Session, JObject.FromObject(new { }));
        }

        public virtual void Action(List<cSession> _Sessions)
        {
            for (int i = 0; i < _Sessions.Count; i++)
            {
                Action(_Sessions[i]);
            }
        }
    }
}
