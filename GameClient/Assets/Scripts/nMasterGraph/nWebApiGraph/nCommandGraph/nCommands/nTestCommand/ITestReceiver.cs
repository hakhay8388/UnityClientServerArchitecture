
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assets.Scripts.nMasterGraph.nWebApiGraph.nCommandGraph.nCommands.nBatchJobStartCommand
{
    public interface ITestReceiver : ICommandReceiver
    {
        void ReceiveBatchJobStartData(cListenerEvent _ListenerEvent, cTestCommandData _ReceivedData);
    }
}
