
using Game.Server.nSessionManager;
using NewClientServerSampleWithUdp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Game.Server.nGameGraph.nWebApiGraph.nCommandGraph.nCommands.nDisconnectedCommand
{
    public interface IDisconnectedReceiver : ICommandReceiver
    {
        void ReceiveDisconnectedData(cSession _Session, cListenerEvent _ListenerEvent, cDisconnectedCommandData _ReceivedData);
    }
}
