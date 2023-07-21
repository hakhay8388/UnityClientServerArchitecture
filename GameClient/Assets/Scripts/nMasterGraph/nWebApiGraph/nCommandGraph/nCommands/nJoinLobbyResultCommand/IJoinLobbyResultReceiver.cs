
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assets.Scripts.nMasterGraph.nWebApiGraph.nCommandGraph.nCommands.nJoinLobbyResultCommand
{
    public interface IJoinLobbyResultReceiver : ICommandReceiver
    {
        void ReceiveJoinLobbyResultData(cListenerEvent _ListenerEvent, cJoinLobbyResultCommandData _ReceivedData);
    }
}
