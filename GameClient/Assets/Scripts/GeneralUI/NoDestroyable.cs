using UnityEngine;
using System.Collections;

public class NoDestroyable : MonoBehaviour
{

    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }
}
