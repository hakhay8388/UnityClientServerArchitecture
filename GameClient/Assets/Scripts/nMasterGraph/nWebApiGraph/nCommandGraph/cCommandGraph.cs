using Assets.Scripts.nMasterGraph.nWebApiGraph.nCommandGraph.nCommandIDs;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;

namespace Assets.Scripts.nMasterGraph.nWebApiGraph.nCommandGraph
{

    public class cCommandGraph
    {
        public List<cBaseCommand> CommandList { get; set; }
        public cMasterGraph Graph { get; set; }



        public cCommandGraph(cMasterGraph _Graph)
        {
            CommandList = new List<cBaseCommand>();
            Graph = _Graph;
        }


        public void Init()
        {
            /*cLoginCommand __LoginCommand = new cLoginCommand();
            CommandList.Add(__LoginCommand);*/
            for (int i = 0; i < CommandIDs.TypeList.Count; i++)
            {
                cBaseCommand __Command = new cGenericCommand(Graph, CommandIDs.TypeList[i]);
                CommandList.Add(__Command);
            }
        }

        public cBaseCommand GetCommandByID(CommandIDs _CommandID)
        {
            return CommandList.Find(__Item => __Item.CommandID.ID == _CommandID.ID);
        }

        public void InterpreterCommand(string _Message)
        {
            try
            {
                JObject __CommandJson = JObject.Parse(_Message);
                bool __IsUsableForMe = false;
                bool __CommandFound = false;

                if (__CommandJson.ContainsKey("CID"))
                {
                    int __CID = (int)__CommandJson["CID"];
                    CommandIDs __CommandID = CommandIDs.GetByID(__CID, null);


                    if (__CommandJson.ContainsKey("Data"))
                    {
                        JToken __Data = __CommandJson["Data"];
                        for (int i = 0; i < CommandList.Count; i++)
                        {
                            if (CommandList[i].CommandID.ID == __CID)
                            {
                                __CommandFound = true;
                                CommandList[i].Interpret(__Data);
                            }
                        }
                    }
                }

            }
            catch (Exception _Ex)
            {
            }
        }

        public void DisconnectToCommands(Object _Object)
        {
            CommandMethods(_Object, "Disconnect");
        }

        public void ConnectToCommands(Object _Object)
        {
            CommandMethods(_Object, "Connect");
        }

        public void CommandMethods(Object _Object, string _MethodName)
        {


            Type[] __Interfaces = _Object.GetType().GetInterfaces();
            for (int i = 0; i < __Interfaces.Length; i++)
            {
                for (int j = 0; j < CommandList.Count; j++)
                {
                    cBaseCommand __Command = CommandList[j];
                    if (__Interfaces[i].Name == "I" + __Command.CommandID.Name + "Receiver")
                    {
                        try
                        {
                            if (_MethodName == "Connect")
                            {
                                MethodInfo __Method = __Command.GetType().GetMethod(_MethodName, new Type[] { typeof(object), typeof(int) });
                                __Method.Invoke(__Command, new object[] { _Object, 0 });
                            }
                            else
                            {
                                MethodInfo __Method = __Command.GetType().GetMethod(_MethodName, new Type[] { typeof(object) });
                                __Method.Invoke(__Command, new object[] { _Object });
                            }
                        }
                        catch (Exception _Ex)
                        {
                        }
                    }
                }
            }
        }

    }

}
