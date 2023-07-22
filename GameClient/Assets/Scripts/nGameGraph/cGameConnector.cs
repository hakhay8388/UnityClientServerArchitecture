using System.Collections.Generic;
using System;
using System.Collections;
using System.Text;
using UnityEngine;
using NewClientServerSampleWithUdp.nSocketManagers.nTcp;
using NewClientServerSampleWithUdp.nSocketManagers.nSocket.nPacket;
using NewClientServerSampleWithUdp.nSocketManagers.nSocket;
using NewClientServerSampleWithUdp.nSocketManagers.nSocket.nTcp.nTcpNodes;
using NewClientServerSampleWithUdp.nSocketManagers.nUdp;
using Unity.VisualScripting;
using UnityEngine.UI;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Data;
using Assets.Scripts.nGameGraph;
using System.Collections.Concurrent;
using Assets.Scripts.nGameGraph.nWebApiGraph.nActionGraph.nActions.nIAmInGameAction;
using UnityEngine.Analytics;

public class cGameConnector : cBaseConnector
{
    public static cGameConnector Instance;
    public cGameGraph GameGraph;
    public string Host;
    public int Port;

    public static readonly ConcurrentQueue<Action> RunOnMainThread = new ConcurrentQueue<Action>();

    public EConnectionState ConnectionState = EConnectionState.None;
    void Awake()
    {
        Instance = this;
        //Screen.fullScreen = false;
        //reen.SetResolution(800, 600, false);
    }

    void Update()
    {
        if (!RunOnMainThread.IsEmpty)
        {
            while (RunOnMainThread.TryDequeue(out var _Action))
            {
                _Action?.Invoke();
            }
        }
    }

    public void Disconnect()
    {
        ConnectionState = EConnectionState.None;
        Host = "";
        Port = 0;
        
        cGameConnector.RunOnMainThread.Enqueue(() =>
        {
            try
            {
                cMasterConnector.Instance.MasterGraph.Connector.TcpClient.TcpNode.Disconnect();
            }
            catch
            { 
            }

            try
            {
                cGameConnector.Instance.GameGraph.Connector.TcpClient.TcpNode.Disconnect();
            }
            catch
            {
            }

            

            Application.LoadLevel("Startup");
        });
    }

    void Start()
    {
        GameGraph = new cGameGraph(this);
        //ConnectToServer("127.0.0.1", 1236);
    }

    public void ConnectToServer(string _Host, int _Port)
    {
        Application.LoadLevel("GameScreen");
        Host = _Host;
        Port = _Port;
        Thread __Thread = new Thread(new ThreadStart(ConnectToServerThread));
        __Thread.Start();
    }

    void ConnectToServerThread()
    {
        ConnectionState = EConnectionState.Connecting;
        Connect(Host, Port);
    }

    public override bool OnUdpMessageReceive(INode _Sender, cBasePacket _Data)
    {
        if (base.OnUdpMessageReceive(_Sender, _Data))
        {
            GameGraph.CommandGraph.InterpreterCommand(_Data.Message);
        }
        return true;
    }

    public override bool OnTcpMessageReceive(cTcpNode _TcpNode, cBasePacket _Data)
    {
        if (base.OnTcpMessageReceive(_TcpNode, _Data))
        {
            GameGraph.CommandGraph.InterpreterCommand(_Data.Message);
        }
        return true;
    }

    public override void OnTcpDisconnected(cTcpNode _TcpNode)
    {
        base.OnTcpDisconnected(_TcpNode);

        Thread __Thread = new Thread(new ThreadStart(ConnectToServerThread));
        __Thread.Start();
    }



    public override void ServerNotFound()
    {
        ConnectionState = EConnectionState.ServerNotFound;
        Disconnect();
    }

    public override void ServerFound()
    {
        ConnectionState = EConnectionState.Connected;
        
    }
}