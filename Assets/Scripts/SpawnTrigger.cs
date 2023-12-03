using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTrigger : MonoBehaviour
{
    bool _isFull = false;
    public bool isFull()
    {
        return _isFull;

    }
    private void OnTriggerEnter(Collider other)
    {    
        if(other.tag == "Car")
            _isFull = true;
    }

}


