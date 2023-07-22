using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Assets.Scripts.nGameGraph.nWebApiGraph.nActionGraph.nActionIDs
{
    public class ActionIDs : cBaseConstType<ActionIDs>
    {
        public static List<ActionIDs> TypeList { get; set; }

        public static ActionIDs Test = new ActionIDs(GetVariableName(() => Test), 1, "", true);
        public static ActionIDs Login = new ActionIDs(GetVariableName(() => Login), 2, "", true);

        public static ActionIDs IAmInGame = new ActionIDs(GetVariableName(() => IAmInGame), 10, "", true);
        public static ActionIDs KeyPressed = new ActionIDs(GetVariableName(() => KeyPressed), 11, "", true);

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
