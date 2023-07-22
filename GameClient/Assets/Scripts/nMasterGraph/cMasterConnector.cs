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
using Assets.Scripts.nMasterGraph;
using System.Collections.Concurrent;
using UnityEngine.Analytics;
using Assets.Scripts.nDatabase.nEntities;

public class cMasterConnector : cBaseConnector
{
    public static cMasterConnector Instance;
    public static cUser User;
    public cMasterGraph MasterGraph;

    public static readonly ConcurrentQueue<Action> RunOnMainThread = new ConcurrentQueue<Action>();

    public EConnectionState ConnectionState = EConnectionState.None;
    void Awake()
    {
        Instance = this;
        Screen.fullScreen = false;
        Screen.SetResolution(800, 600, false);
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

    void Start()
    {
        MasterGraph = new cMasterGraph(this);
        Application.LoadLevel("MainScreen");
        Thread __Thread = new Thread(new ThreadStart(ConnectToServer));
        __Thread.Start();
    }

    void ConnectToServer()
    {
        ConnectionState = EConnectionState.Connecting;
        Connect(Settings.MasterServerIP, Settings.MasterServerPort);
    }

    public override bool OnUdpMessageReceive(INode _Sender, cBasePacket _Data)
    {
        if (base.OnUdpMessageReceive(_Sender, _Data))
        {
            MasterGraph.CommandGraph.InterpreterCommand(_Data.Message);
        }
        return true;
    }

    public override bool OnTcpMessageReceive(cTcpNode _TcpNode, cBasePacket _Data)
    {
        if (base.OnTcpMessageReceive(_TcpNode, _Data))
        {
            MasterGraph.CommandGraph.InterpreterCommand(_Data.Message);
        }

        return true;
    }

    public override void OnTcpDisconnected(cTcpNode _TcpNode)
    {
        base.OnTcpDisconnected(_TcpNode);

        Thread __Thread = new Thread(new ThreadStart(ConnectToServer));
        __Thread.Start();
    }



    public override void ServerNotFound()
    {
        ConnectionState = EConnectionState.ServerNotFound;
    }

    public override void ServerFound()
    {
        ConnectionState = EConnectionState.Connected;
    }
}