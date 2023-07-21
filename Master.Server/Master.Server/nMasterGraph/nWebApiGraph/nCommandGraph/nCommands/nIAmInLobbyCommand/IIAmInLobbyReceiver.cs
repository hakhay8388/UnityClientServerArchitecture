
using Master.Server.nSessionManager;
using NewClientServerSampleWithUdp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Master.Server.nMasterGraph.nWebApiGraph.nCommandGraph.nCommands.nIAmInLobbyCommand
{
    public interface IIAmInLobbyReceiver : ICommandReceiver
    {
        void ReceiveIAmInLobbyData(cSession _Session, cListenerEvent _ListenerEvent, cIAmInLobbyCommandData _ReceivedData);
    }
}
