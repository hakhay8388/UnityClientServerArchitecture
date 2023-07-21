
using Master.Server.nSessionManager;
using NewClientServerSampleWithUdp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Master.Server.nMasterGraph.nWebApiGraph.nCommandGraph.nCommands.nLoginCommand
{
    public interface ILoginReceiver : ICommandReceiver
    {
        void ReceiveLoginData(cSession _Session, cListenerEvent _ListenerEvent, cLoginCommandData _ReceivedData);
    }
}
