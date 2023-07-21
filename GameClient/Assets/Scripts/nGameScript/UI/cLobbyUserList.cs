using Assets.Scripts.nDatabase.nEntities;
using Assets.Scripts.nMasterGraph.nWebApiGraph.nCommandGraph;
using Assets.Scripts.nMasterGraph.nWebApiGraph.nCommandGraph.nCommands.nJoinLobbyResultCommand;
using Assets.Scripts.nMasterGraph.nWebApiGraph.nCommandGraph.nCommands.nLobbyUserListCommand;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cLobbyUserList : cBaseMasterUIItem, ILobbyUserListReceiver, IJoinLobbyResultReceiver
{
    GameObject Template;

    public void ReceiveJoinLobbyResultData(cListenerEvent _ListenerEvent, cJoinLobbyResultCommandData _ReceivedData)
    {
        RefreshUserList(_ReceivedData.Users);
    }

    public void ReceiveLobbyUserListData(cListenerEvent _ListenerEvent, cLobbyUserListCommandData _ReceivedData)
    {
        RefreshUserList(_ReceivedData.Users);
    }

    public void RefreshUserList(List<cUser> _User)
    {
        int __Count = transform.childCount;

        for (int i = 1; i < __Count; i++)
        {
            GameObject __Temp = transform.GetChild(i).gameObject;
            Destroy(__Temp);
        }

        for (int i = 0; i < _User.Count; i++)
        {
            GameObject __User = Instantiate(Template, transform);
            __User.SetActive(true);
            __User.GetComponent<Text>().text = _User[i].Name;
        }
    }

    void Start()
    {
        Template = transform.GetChild(0).gameObject;
        Template.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
