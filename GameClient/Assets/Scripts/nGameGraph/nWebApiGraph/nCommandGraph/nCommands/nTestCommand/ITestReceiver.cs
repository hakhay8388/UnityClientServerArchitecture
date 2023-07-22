﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assets.Scripts.nGameGraph.nWebApiGraph.nCommandGraph.nCommands.nTestCommand
{
    public interface ITestReceiver : ICommandReceiver
    {
        void ReceiveTestData(cListenerEvent _ListenerEvent, cTestCommandData _ReceivedData);
    }
}
