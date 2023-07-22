using Assets.Scripts.nDatabase.nEntities;
using Assets.Scripts.nGameGraph.nWebApiGraph.nActionGraph.nActions.nIAmInGameAction;
using Assets.Scripts.nGameGraph.nWebApiGraph.nActionGraph.nActions.nKeyPressedAction;
using Assets.Scripts.nGameGraph.nWebApiGraph.nCommandGraph;
using Assets.Scripts.nGameGraph.nWebApiGraph.nCommandGraph.nCommands.nCountDownCommand;
using Assets.Scripts.nGameGraph.nWebApiGraph.nCommandGraph.nCommands.nOpenGameCommand;
using Assets.Scripts.nGameGraph.nWebApiGraph.nCommandGraph.nCommands.nPlayerFinishedGameCommand;
using Assets.Scripts.nGameGraph.nWebApiGraph.nCommandGraph.nCommands.nReturnToLobbyCommand;
using System.Collections.Generic;
using UnityEngine;

public class cGeneralGameListener : cGameReceiverObject
    , IOpenGameReceiver
    , ICountDownReceiver
    , IReturnToLobbyReceiver
    , IPlayerFinishedGameReceiver
{
    public static cGeneralGameListener Instance { get;set;}
    bool Inited = false;

    public GameObject PlayerPrefab;
    int StartTimer = 10;

    public GameObject Player;

    public List<GameObject> AllPlayer;


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

        if (cGameConnector.Instance.CanUseUDP && !Inited)
        {
            Inited = true;
            cGameConnector.Instance.GameGraph.ActionGraph.IAmInGameAction.Action(new cIAmInGameProps() { User = cMasterConnector.User });
        }

    }

    void FixedUpdate()
    {
        if (StartTimer == 0)
        {

            bool[] __Inputs = new bool[]
              {
                    Input.GetKey(KeyCode.UpArrow),
                    Input.GetKey(KeyCode.DownArrow),
                    Input.GetKey(KeyCode.LeftArrow),
                    Input.GetKey(KeyCode.RightArrow)
              };

            cGameConnector.Instance.GameGraph.ActionGraph.KeyPressedAction.Action(new cKeyPressedProps() { Keys = __Inputs });
        }
    }

    public void ReceiveOpenGameData(cListenerEvent _ListenerEvent, cOpenGameCommandData _ReceivedData)
    {
        AllPlayer = new List<GameObject>();
        PlayerPrefab.SetActive(false);

        for (int i = 0; i < _ReceivedData.Users.Count; i++)
        {
            GameObject __User = Instantiate(PlayerPrefab, null);

            __User.SetActive(true);
            TextMesh __TextMesh = __User.transform.GetChild(0).gameObject.GetComponent<TextMesh>();
            __TextMesh.text = _ReceivedData.Users[i].Name;
            if (_ReceivedData.Users[i].id == cMasterConnector.User.id)
            {
                __TextMesh.color = Color.blue;
                Player = __User;
            }

            __User.GetComponent<cPlayer>().ID = _ReceivedData.Users[i].id;


            __User.transform.position = new Vector3(0, 0.53f, -3 + (float)((12f / (float)_ReceivedData.Users.Count) * i));

            AllPlayer.Add(__User);
        }

        //FindObjectOfType<Canvas>().gameObject.SetActive(false);

    }

    public void ReceiveCountDownData(cListenerEvent _ListenerEvent, cCountDownCommandData _ReceivedData)
    {
        if (_ReceivedData.Value != 0)
        {
            cGameMessagePanel.Instance.SetMessage(_ReceivedData.Value.ToString());
        }
        else
        {
            cGameMessagePanel.Instance.Hide();
        }
        StartTimer = _ReceivedData.Value;
    }

    public void ReceiveReturnToLobbyData(cListenerEvent _ListenerEvent, cReturnToLobbyCommandData _ReceivedData)
    {
        cGameConnector.Instance.Disconnect();
    }

    public void ReceivePlayerFinishedGameData(cListenerEvent _ListenerEvent, cPlayerFinishedGameCommandData _ReceivedData)
    {
        if (_ReceivedData.User.id == cMasterConnector.User.id)
        {
            cGameMessagePanel.Instance.SetMessage("Your Rank : " + _ReceivedData.Rank.ToString() + " , TotalPuan : " + _ReceivedData.User.Puan);
            cGameMessagePanel.Instance.Show();
        }
        else
        {
            for (int i = 0; i < AllPlayer.Count; i++)
            {
                if (AllPlayer[i].GetComponent<cPlayer>().ID == _ReceivedData.User.id)
                {
                    TextMesh __TextMesh = AllPlayer[i].transform.GetChild(0).gameObject.GetComponent<TextMesh>();
                    __TextMesh.text = "Rank " + _ReceivedData.Rank.ToString() + " : " + _ReceivedData.User.Name + " , TotalPuan : " + _ReceivedData.User.Puan;
                }
            }

        }
    }
}
