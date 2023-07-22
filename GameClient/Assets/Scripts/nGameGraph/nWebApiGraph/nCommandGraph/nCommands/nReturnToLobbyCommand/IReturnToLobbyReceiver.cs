
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assets.Scripts.nGameGraph.nWebApiGraph.nCommandGraph.nCommands.nReturnToLobbyCommand
{
    public interface IReturnToLobbyReceiver : ICommandReceiver
    {
        void ReceiveReturnToLobbyData(cListenerEvent _ListenerEvent, cReturnToLobbyCommandData _ReceivedData);
    }
}
