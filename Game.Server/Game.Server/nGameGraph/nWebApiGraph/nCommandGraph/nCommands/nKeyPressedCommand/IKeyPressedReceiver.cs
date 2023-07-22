
using Game.Server.nSessionManager;
using NewClientServerSampleWithUdp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Game.Server.nGameGraph.nWebApiGraph.nCommandGraph.nCommands.nKeyPressedCommand
{
    public interface IKeyPressedReceiver : ICommandReceiver
    {
        void ReceiveKeyPressedData(cSession _Session, cListenerEvent _ListenerEvent, cKeyPressedCommandData _ReceivedData);
    }
}
