using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Assets.Scripts.nMasterGraph
{
    public class EConnectionState : cBaseConstType<EConnectionState>
    {
        public static List<EConnectionState> TypeList { get; set; }

        public static EConnectionState None = new EConnectionState(GetVariableName(() => None), 1);
        public static EConnectionState Connecting = new EConnectionState(GetVariableName(() => Connecting), 2);
        public static EConnectionState Connected = new EConnectionState(GetVariableName(() => Connected), 3);
        public static EConnectionState ServerNotFound = new EConnectionState(GetVariableName(() => ServerNotFound), 4);


        public EConnectionState(string _Name, int _ID)
            : base(_Name, _Name, _ID)
        {
            TypeList = TypeList ?? new List<EConnectionState>();
            TypeList.Add(this);
        }
        public static EConnectionState GetByID(int _ID, EConnectionState _DefaultCommandID)
        {
            return GetByID(TypeList, _ID, _DefaultCommandID);
        }
        public static EConnectionState GetByName(string _Name, EConnectionState _DefaultCommandID)
        {
            return GetByName(TypeList, _Name, _DefaultCommandID);
        }
    }
}
