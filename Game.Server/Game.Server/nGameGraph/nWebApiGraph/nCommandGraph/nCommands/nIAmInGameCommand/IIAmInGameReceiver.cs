
using Game.Server.nSessionManager;
using NewClientServerSampleWithUdp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Game.Server.nGameGraph.nWebApiGraph.nCommandGraph.nCommands.nIAmInGameCommand
{
    public interface IIAmInGameReceiver : ICommandReceiver
    {
        void ReceiveIAmInGameData(cSession _Session, cListenerEvent _ListenerEvent, cIAmInGameCommandData _ReceivedData);
    }
}
