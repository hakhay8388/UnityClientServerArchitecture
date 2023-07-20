using Assets.Scripts.nMasterGraph.nWebApiGraph.nActionGraph.nActions.nNotificationAction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.UI;
using UnityEngine;



public class cBaseUIItem : MonoBehaviour
{
    Vector3 VisiblePosition;

    public virtual void Start()
    {
        VisiblePosition = transform.localPosition;
    }

    public void Hide()
    {
        transform.localPosition = new Vector3(50000, 0, 0);
    }

    public void Show()
    {
        transform.localPosition = VisiblePosition;
    }
}
