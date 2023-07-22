using Assets.Scripts.nGameGraph.nWebApiGraph.nActionGraph.nActionIDs;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Assets.Scripts.nGameGraph.nWebApiGraph.nCommandGraph.nCommandIDs
{
    public class CommandIDs : cBaseConstType<CommandIDs>
    {

        public static List<CommandIDs> TypeList { get; set; }

        public static CommandIDs Test = new CommandIDs(GetVariableName(() => Test), 1);
        
        public static CommandIDs OpenGame = new CommandIDs(GetVariableName(() => OpenGame), 10);
        public static CommandIDs CountDown = new CommandIDs(GetVariableName(() => CountDown), 11);
        public static CommandIDs ReturnToLobby = new CommandIDs(GetVariableName(() => ReturnToLobby), 12);
        public static CommandIDs PlayerTransform = new CommandIDs(GetVariableName(() => PlayerTransform), 13);


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
