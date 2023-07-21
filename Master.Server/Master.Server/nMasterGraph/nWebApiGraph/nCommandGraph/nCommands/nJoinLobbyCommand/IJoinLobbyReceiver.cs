
using Master.Server.nSessionManager;
using NewClientServerSampleWithUdp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Master.Server.nMasterGraph.nWebApiGraph.nCommandGraph.nCommands.nJoinLobbyCommand
{
    public interface IJoinLobbyReceiver : ICommandReceiver
    {
        void ReceiveJoinLobbyData(cSession _Session, cListenerEvent _ListenerEvent, cJoinLobbyCommandData _ReceivedData);
    }
}
