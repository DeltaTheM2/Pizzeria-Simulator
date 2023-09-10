using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FundManager : MonoBehaviour
{
    public float funds = 0;

    private static FundManager _instance;
    public static FundManager Instance { get { return _instance; } }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        } else {
            _instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
    }
}
