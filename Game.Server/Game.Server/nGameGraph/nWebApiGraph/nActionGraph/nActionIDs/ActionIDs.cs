using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Game.Server.nGameGraph.nWebApiGraph.nActionGraph.nActionIDs
{
    public class ActionIDs : cBaseConstType<ActionIDs>
    {
        public static List<ActionIDs> TypeList { get; set; }

        public static ActionIDs Test = new ActionIDs(GetVariableName(() => Test), 1, "", true);


        public static ActionIDs OpenGame = new ActionIDs(GetVariableName(() => OpenGame), 10, "", true);
        public static ActionIDs CountDown = new ActionIDs(GetVariableName(() => CountDown), 11, "", true);
        public static ActionIDs ReturnToLobby = new ActionIDs(GetVariableName(() => ReturnToLobby), 12, "", true);
        public static ActionIDs PlayerTransform = new ActionIDs(GetVariableName(() => PlayerTransform), 13, "", true);

        public bool Enabled { get; set; }
        public string Info { get; set; }


        public ActionIDs(string _Name, int _ID, string _Info, bool _Enabled)
            : base(_Name, _Name, _ID)
        {
            TypeList = TypeList ?? new List<ActionIDs>();
            Enabled = _Enabled;
            Info = _Info;
            TypeList.Add(this);
        }
        public static ActionIDs GetByID(int _ID, ActionIDs _DefaultCommandID)
        {
            return GetByID(TypeList, _ID, _DefaultCommandID);
        }
        public static ActionIDs GetByName(string _Name, ActionIDs _DefaultCommandID)
        {
            return GetByName(TypeList, _Name, _DefaultCommandID);
        }
    }
}
