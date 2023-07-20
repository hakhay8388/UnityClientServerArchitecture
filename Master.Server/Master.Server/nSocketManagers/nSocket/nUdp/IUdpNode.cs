using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewClientServerSampleWithUdp.nSocketManagers.nSocket.nUdp
{
    public interface IUdpNode : INode
    {
        void ReceiveUdpCallback(IAsyncResult _Result);
    }
}
