using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cGameMessagePanel : cBaseGameUIItem
{
    public static cGameMessagePanel Instance;
    // Start is called before the first frame update
    public override void Awake()
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

   

    public void SetMessage(string _Message)
    {
        transform.GetChild(0).gameObject.GetComponent<Text>().text = _Message;
        //GameObject.FindGameObjectsWithTag("PanelText")[0].gameObject.GetComponent<Text>().text = _Message;
        //transform.Find("Text").gameObject.GetComponent<Text>().text = _Message;
    }
}
