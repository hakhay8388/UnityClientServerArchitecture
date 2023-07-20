using Assets.Scripts.nMasterGraph.nWebApiGraph.nActionGraph.nActions.nNotificationAction;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.UI;

public class cLoginPanel : cBaseUIItem
{
    public static cLoginPanel Instance;

    public GameObject LoginPanel;
    public InputField UserNameField;


    int ConnectionLastState = 500;

    private void Awake()
    {
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
            if (cMasterConnector.Instance.ConnectionState == 1)
            {
                Show();
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
        cMasterConnector.Instance.MasterGraph.ActionGraph.TestAction.Action(new cTestProps("Deneme"));

        //cClient2.instance.ConnectToServer();
    }
}
