using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cMessagePanel : cBaseUIItem
{
    public static cMessagePanel Instance;
    // Start is called before the first frame update

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
            if (cMasterConnector.Instance.ConnectionState != 1)
            {
                Show();
                if (ConnectionLastState == 0)
                {
                    SetMessage("Connecting..");
                }
                else if (ConnectionLastState == 2)
                {
                    SetMessage("Server Not Found..");
                }
            }
            else
            {
                Hide();
            }
        }
    }

    public void SetMessage(string _Message)
    {
        GameObject.FindGameObjectsWithTag("PanelText")[0].gameObject.GetComponent<Text>().text = _Message;
        //transform.Find("Text").gameObject.GetComponent<Text>().text = _Message;
    }
}
