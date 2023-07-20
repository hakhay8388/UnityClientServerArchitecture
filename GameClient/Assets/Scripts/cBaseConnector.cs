using UnityEngine;
using NewClientServerSampleWithUdp.nSocketManagers.nTcp;
using NewClientServerSampleWithUdp.nSocketManagers.nSocket.nPacket;
using NewClientServerSampleWithUdp.nSocketManagers.nSocket;
using NewClientServerSampleWithUdp.nSocketManagers.nSocket.nTcp.nTcpNodes;
using NewClientServerSampleWithUdp.nSocketManagers.nUdp;

public abstract class cBaseConnector : MonoBehaviour, ITcpDataReceiver, IUdpDataReceiver
{
    public string ConnectionID { get; set; }
    public bool CanUseUDP { get; set; }
    public cTcpClient TcpClient { get; set; }
    public cUdpClient UdpClient { get; set; }
    public string Host { get; set; }
    public int Port { get; set; }

    public bool Connected { get { return TcpClient.TcpNode.Connected; } }


    public void Connect(string _Host, int _Port)
    {
        Host = _Host;
        Port = _Port;
        TcpClient = new cTcpClient(this);
        TcpClient.TryToConnect(Host, Port, ServerFound, ServerNotFound);
        CanUseUDP = false;
        TcpClient.Send("GetConnectionID");
        Debug.Log("TCP Connecting...");
    }

    public abstract void ServerNotFound();
    public abstract void ServerFound();

    public virtual bool OnTcpMessageReceive(cTcpNode _TcpNode, cBasePacket _Data)
    {
        if (_Data.Message.StartsWith("GetConnectionID"))
        {
            Debug.Log("TCP Connected");
            Debug.Log("UDP Connecting...");
            ConnectionID = _Data.Message.Split(":")[1];
            UdpClient = new cUdpClient(Host, Port, this);
            UdpClient.Send("ID:" + ConnectionID);
            return false;
        }
        return true;
    }

    public virtual void OnTcpDisconnected(cTcpNode _TcpNode)
    {
        Debug.Log("DC");
    }

    public virtual bool OnUdpMessageReceive(INode _Sender, cBasePacket _Data)
    {
        if (_Data.Message.StartsWith("ID"))
        {
            CanUseUDP = ConnectionID == _Data.Message.Split(":")[1];
            if (CanUseUDP)
            {
                Debug.Log("UDP Connected");
            }
            return false;
        }
        return true;
    }

    public virtual void OnUdpDisconnected(INode _Node)
    {
    }

    public void Send(string _Message)
    {
        if (CanUseUDP)
        {
            UdpClient.Send(_Message);
        }
        else
        {
            TcpClient.Send(_Message);
        }
    }

}