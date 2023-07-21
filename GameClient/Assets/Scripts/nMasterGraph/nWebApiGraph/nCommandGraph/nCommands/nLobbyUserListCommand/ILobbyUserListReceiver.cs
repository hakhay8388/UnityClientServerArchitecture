
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assets.Scripts.nMasterGraph.nWebApiGraph.nCommandGraph.nCommands.nLobbyUserListCommand
{
    public interface ILobbyUserListReceiver : ICommandReceiver
    {
        void ReceiveLobbyUserListData(cListenerEvent _ListenerEvent, cLobbyUserListCommandData _ReceivedData);
    }
}
