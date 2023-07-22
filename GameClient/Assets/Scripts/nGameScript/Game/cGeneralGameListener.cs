using Assets.Scripts.nDatabase.nEntities;
using Assets.Scripts.nGameGraph.nWebApiGraph.nActionGraph.nActions.nIAmInGameAction;
using Assets.Scripts.nGameGraph.nWebApiGraph.nActionGraph.nActions.nKeyPressedAction;
using Assets.Scripts.nGameGraph.nWebApiGraph.nCommandGraph;
using Assets.Scripts.nGameGraph.nWebApiGraph.nCommandGraph.nCommands.nCountDownCommand;
using Assets.Scripts.nGameGraph.nWebApiGraph.nCommandGraph.nCommands.nOpenGameCommand;
using Assets.Scripts.nGameGraph.nWebApiGraph.nCommandGraph.nCommands.nReturnToLobbyCommand;
using UnityEngine;

public class cGeneralGameListener : cGameReceiverObject
    , IOpenGameReceiver
    , ICountDownReceiver
    , IReturnToLobbyReceiver
{
    public static cGeneralGameListener Instance { get;set;}
    bool Inited = false;

    public GameObject PlayerPrefab;
    public cUser User;
    int StartTimer = 10;

    public GameObject Player;


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
            User = new cUser() { Name = "Test", ID = (int)Mathf.Round(Random.value * 5000) };
            cGameConnector.Instance.GameGraph.ActionGraph.IAmInGameAction.Action(new cIAmInGameProps() { User = User });
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
        PlayerPrefab.SetActive(false);

        for (int i = 0; i < _ReceivedData.Users.Count; i++)
        {
            GameObject __User = Instantiate(PlayerPrefab, null);

            __User.SetActive(true);
            TextMesh __TextMesh = __User.transform.GetChild(0).gameObject.GetComponent<TextMesh>();
            __TextMesh.text = _ReceivedData.Users[i].Name;
            if (_ReceivedData.Users[i].ID == User.ID)
            {
                __TextMesh.color = Color.blue;
                Player = __User;
            }

            __User.GetComponent<cPlayer>().ID = _ReceivedData.Users[i].ID;


            __User.transform.position = new Vector3(0, 0.53f, -3 + (float)((12f / (float)_ReceivedData.Users.Count) * i));
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
}
