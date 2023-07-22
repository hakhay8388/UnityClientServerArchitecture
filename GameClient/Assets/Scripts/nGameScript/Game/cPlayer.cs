using Assets.Scripts.nGameGraph.nWebApiGraph.nCommandGraph;
using Assets.Scripts.nGameGraph.nWebApiGraph.nCommandGraph.nCommands.nPlayerTransformCommand;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cPlayer : cGameReceiverObject, IPlayerTransformReceiver
{
    public GameObject Camera;
    public long ID;

    void Start() 
    { 
    }    

    public void ReceivePlayerTransformData(cListenerEvent _ListenerEvent, cPlayerTransformCommandData _ReceivedData)
    {
        if (_ReceivedData.UserID == ID)
        {
            transform.position = new Vector3(_ReceivedData.Position.X, transform.position.y, _ReceivedData.Position.Z);

            if (cMasterConnector.User.id == _ReceivedData.UserID)
            {
                Camera.transform.position = new Vector3(_ReceivedData.Position.X - 7, transform.position.y + 3.5f, _ReceivedData.Position.Z);
            }            
        }
    }
}
