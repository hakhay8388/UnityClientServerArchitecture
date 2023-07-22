
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assets.Scripts.nGameGraph.nWebApiGraph.nCommandGraph.nCommands.nCountDownCommand
{
    public interface ICountDownReceiver : ICommandReceiver
    {
        void ReceiveCountDownData(cListenerEvent _ListenerEvent, cCountDownCommandData _ReceivedData);
    }
}
