using Assets.Scripts.nMasterGraph;
using Assets.Scripts.nMasterGraph.nWebApiGraph.nActionGraph.nActions.nGetLobbyUsersAction;
using Assets.Scripts.nMasterGraph.nWebApiGraph.nActionGraph.nActions.nIAmInLobbyAction;
using Assets.Scripts.nMasterGraph.nWebApiGraph.nActionGraph.nActions.nJoinLobbyAction;
using Assets.Scripts.nMasterGraph.nWebApiGraph.nCommandGraph;
using Assets.Scripts.nMasterGraph.nWebApiGraph.nCommandGraph.nCommands.nLoginResultCommand;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cLobbyPanel : cBaseMasterUIItem, ILoginResultReceiver
{
    EConnectionState ConnectionLastState = EConnectionState.None;

    public static cLobbyPanel Instance;
    public override void Awake()
    {
        base.Awake();
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Debug.Log("Instance already exists, destroying object!");
            Destroy(this);
        }
    }

    void Update()
    {
        if (cMasterConnector.Instance.ConnectionState != ConnectionLastState)
        {
            ConnectionLastState = cMasterConnector.Instance.ConnectionState;
            if (cMasterConnector.Instance.ConnectionState.ID != EConnectionState.Connected.ID)
            {
                Hide();
            }
        }
    }

    public void JoinGame()
    {
        cMasterConnector.Instance.MasterGraph.ActionGraph.JoinLobbyAction.Action(new cJoinLobbyProps());

    }
    public void ReceiveLoginResultData(cListenerEvent _ListenerEvent, cLoginResultCommandData _ReceivedData)
    {
        if (_ReceivedData.Logined)
        {
            Show();
            cMasterConnector.Instance.MasterGraph.ActionGraph.IAmInLobbyAction.Action(new cIAmInLobbyProps());
        }
    }
}
