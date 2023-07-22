
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assets.Scripts.nGameGraph.nWebApiGraph.nCommandGraph.nCommands.nOpenGameCommand
{
    public interface IOpenGameReceiver : ICommandReceiver
    {
        void ReceiveOpenGameData(cListenerEvent _ListenerEvent, cOpenGameCommandData _ReceivedData);
    }
}
