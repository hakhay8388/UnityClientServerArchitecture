using Assets.Scripts.nMasterGraph;
using Assets.Scripts.nMasterGraph.nWebApiGraph.nActionGraph.nActions.nJoinLobbyAction;
using Assets.Scripts.nMasterGraph.nWebApiGraph.nActionGraph.nActions.nLoginAction;
using Assets.Scripts.nMasterGraph.nWebApiGraph.nCommandGraph;
using Assets.Scripts.nMasterGraph.nWebApiGraph.nCommandGraph.nCommands.nLoginResultCommand;
using UnityEngine;
using UnityEngine.UI;

public class cLoginPanel : cBaseMasterUIItem, ILoginResultReceiver
{
    public static cLoginPanel Instance;

    public GameObject LoginPanel;
    public InputField UserNameField;
    public bool Logined = false;
    public bool LastLogined = false;

    EConnectionState ConnectionLastState = EConnectionState.None;

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
            if (cMasterConnector.Instance.ConnectionState.ID == EConnectionState.Connected.ID)
            {
                Show();
            }
            else if (cMasterConnector.Instance.ConnectionState.ID == EConnectionState.Connecting.ID)
            {
                Logined = false;
                Hide();
            }
            else
            {
                Hide();
            }
        }
    }

    /// <summary>Attempts to connect to the server.</summary>
    public void ConnectToServer()
    {
        //LoginPanel.SetActive(false);
        //UserNameField.interactable = false;
        cMasterConnector.Instance.MasterGraph.ActionGraph.LoginAction.Action(new cLoginProps(UserNameField.text));

        //cClient2.instance.ConnectToServer();
    }

  

    public void ReceiveLoginResultData(cListenerEvent _ListenerEvent, cLoginResultCommandData _ReceivedData)
    {
        Logined = _ReceivedData.Logined;
        if (Logined)
        {
            Hide();
        }
    }
}
