using Assets.Scripts.nMasterGraph;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class cGameReceiverObject : MonoBehaviour
{
    public virtual void Awake()
    {
        cGameConnector.Instance.GameGraph.CommandGraph.ConnectToCommands(this);
    }

    public virtual void OnDestroy()
    {
        cGameConnector.Instance.GameGraph.CommandGraph.DisconnectToCommands(this);
    }
}
