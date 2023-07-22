using Assets.Scripts.nMasterGraph.nWebApiGraph.nActionGraph.nActionIDs;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Assets.Scripts.nMasterGraph.nWebApiGraph.nCommandGraph.nCommandIDs
{
    public class CommandIDs : cBaseConstType<CommandIDs>
    {

        public static List<CommandIDs> TypeList { get; set; }

        public static CommandIDs Test = new CommandIDs(GetVariableName(() => Test), 1);
        public static CommandIDs LoginResult = new CommandIDs(GetVariableName(() => LoginResult), 2);

        public static CommandIDs LobbyUserList = new CommandIDs(GetVariableName(() => LobbyUserList), 10);
        public static CommandIDs JoinLobbyResult = new CommandIDs(GetVariableName(() => JoinLobbyResult), 11);



        public CommandIDs(string _Name, int _ID)
            : base(_Name, _Name, _ID)
        {
            TypeList = TypeList ?? new List<CommandIDs>();
            TypeList.Add(this);
        }
       
        public static CommandIDs GetByID(int _ID, CommandIDs _DefaultCommandID)
        {
            return GetByID(TypeList, _ID, _DefaultCommandID);
        }
        public static CommandIDs GetByName(string _Name, CommandIDs _DefaultCommandID)
        {
            return GetByName(TypeList, _Name, _DefaultCommandID);
        }
    }
}
