using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 This code will be added to the triggers to identify there are any customers standing on the triggers.
 */
public class PositionTrigger : MonoBehaviour
{
    public Boolean isFilled = false;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Customer")
        {
            isFilled = true;
        }
    }
}
