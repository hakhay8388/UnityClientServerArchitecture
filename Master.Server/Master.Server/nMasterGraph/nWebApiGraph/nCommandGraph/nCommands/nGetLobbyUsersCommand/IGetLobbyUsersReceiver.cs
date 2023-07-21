
using Master.Server.nSessionManager;
using NewClientServerSampleWithUdp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Master.Server.nMasterGraph.nWebApiGraph.nCommandGraph.nCommands.nGetLobbyUsersCommand
{
    public interface IGetLobbyUsersReceiver : ICommandReceiver
    {
        void ReceiveGetLobbyUsersData(cSession _Session, cListenerEvent _ListenerEvent, cGetLobbyUsersCommandData _ReceivedData);
    }
}
