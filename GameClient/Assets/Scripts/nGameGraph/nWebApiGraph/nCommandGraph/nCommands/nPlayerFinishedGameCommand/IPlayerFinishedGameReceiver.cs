
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assets.Scripts.nGameGraph.nWebApiGraph.nCommandGraph.nCommands.nPlayerFinishedGameCommand
{
    public interface IPlayerFinishedGameReceiver : ICommandReceiver
    {
        void ReceivePlayerFinishedGameData(cListenerEvent _ListenerEvent, cPlayerFinishedGameCommandData _ReceivedData);
    }
}
