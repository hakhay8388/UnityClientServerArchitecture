using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Assets.Scripts.nMasterGraph.nWebApiGraph.nCommandGraph.nCommandIDs;
using Bootstrapper.Core.nUtils.nJsonConverter;

namespace Assets.Scripts.nMasterGraph.nWebApiGraph.nCommandGraph
{
    public class cGenericCommand : cBaseCommand
    {
        List<cRecieverItem> ReceiverList = new List<cRecieverItem>();
        Type CommandDataClass = null;
        Type CommandReceiverClass = null;

        public cGenericCommand(cBaseGraph _Graph, CommandIDs _Command)
                : base(_Graph, _Command)
        {
            try
            {
                CommandDataClass = Type.GetType("Assets.Scripts.nMasterGraph.nWebApiGraph.nCommandGraph.nCommands.n" + CommandID.Name + "Command.c" + CommandID.Name + "CommandData");
                CommandReceiverClass = Type.GetType("Assets.Scripts.nMasterGraph.nWebApiGraph.nCommandGraph.nCommands.n" + CommandID.Name + "Command.I" + CommandID.Name + "Receiver");
            }
            catch (Exception _Ex)
            {
            }
        }

        public override void Interpret(JToken _JToken)
        {
            try
            {
                JsonSerializerSettings __Settings = new JsonSerializerSettings
                {
                    Converters = new List<JsonConverter> { new cBadDateFixingConverter() },
                    DateParseHandling = DateParseHandling.None
                };

                Object __Data = JsonConvert.DeserializeObject(_JToken.ToString(), CommandDataClass, __Settings);

                ReceiverList = ReceiverList.OrderBy(__Item => __Item.Order).ToList();
                cListenerEvent __Event = new cListenerEvent(this);


                if (!__Event.IsPropogationStoped)
                {
                    for (int i = 0; i < ReceiverList.Count; i++)
                    {
                        Object __ReceiverObject = ReceiverList[i].Receiver;
                        try
                        {
                            MethodInfo __Receiver = CommandReceiverClass.GetMethod("Receive" + CommandID.Name + "Data", 0, new Type[] { typeof(cListenerEvent), __Data.GetType() });
                            cMasterConnector.RunOnMainThread.Enqueue(() =>
                            {
                                __Receiver.Invoke(__ReceiverObject, new object[] { __Event, __Data });
                            });
                            
                            if (__Event.IsPropogationStoped)
                            {
                                break;
                            }
                        }
                        catch (Exception _Ex)
                        {
                        }
                    }
                }
            }
            catch (Exception _Ex)
            {
            }
        }


        public void Connect(Object _Receiver, int _Order = 0)
        {
            ReceiverList.Add(new cRecieverItem(_Receiver, _Order));
        }

        public void Disconnect(Object _Receiver)
        {
            cRecieverItem __RecieverItem = ReceiverList.Where(__Item => __Item.Receiver == _Receiver).ToList().FirstOrDefault();
            if (__RecieverItem != null)
            {
                ReceiverList.Remove(__RecieverItem);
            }            
        }
    }
}
