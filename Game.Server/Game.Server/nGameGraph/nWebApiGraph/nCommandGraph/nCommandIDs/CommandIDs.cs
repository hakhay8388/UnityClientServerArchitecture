using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Game.Server.nGameGraph.nWebApiGraph.nCommandGraph.nCommandIDs
{
    public class CommandIDs : cBaseConstType<CommandIDs>
    {

        public static List<CommandIDs> TypeList { get; set; }

        public static CommandIDs Test = new CommandIDs(GetVariableName(() => Test), 1);
        public static CommandIDs Disconnected = new CommandIDs(GetVariableName(() => Disconnected), 3);


        public static CommandIDs IAmInGame = new CommandIDs(GetVariableName(() => IAmInGame), 10);
        public static CommandIDs KeyPressed = new CommandIDs(GetVariableName(() => KeyPressed), 11);

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
