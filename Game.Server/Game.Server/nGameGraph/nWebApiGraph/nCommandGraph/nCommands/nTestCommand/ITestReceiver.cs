
using Game.Server.nSessionManager;
using NewClientServerSampleWithUdp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Game.Server.nGameGraph.nWebApiGraph.nCommandGraph.nCommands.nTestCommand
{
    public interface ITestReceiver : ICommandReceiver
    {
        void ReceiveTestData(cSession _Session, cListenerEvent _ListenerEvent, cTestCommandData _ReceivedData);
    }
}
