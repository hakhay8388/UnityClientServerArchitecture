
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assets.Scripts.nGameGraph.nWebApiGraph.nCommandGraph.nCommands.nPlayerTransformCommand
{
    public interface IPlayerTransformReceiver : ICommandReceiver
    {
        void ReceivePlayerTransformData(cListenerEvent _ListenerEvent, cPlayerTransformCommandData _ReceivedData);
    }
}
