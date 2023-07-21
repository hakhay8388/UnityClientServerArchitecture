using Assets.Scripts.nMasterGraph;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class cMasterReceiverObject : MonoBehaviour
{
    public virtual void Awake()
    {
        cMasterConnector.Instance.MasterGraph.CommandGraph.ConnectToCommands(this);
    }

    public virtual void OnDestroy()
    {
        cMasterConnector.Instance.MasterGraph.CommandGraph.DisconnectToCommands(this);
    }
}
