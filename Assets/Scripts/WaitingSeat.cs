using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitingSeat : MonoBehaviour
{
    void Awake() {
        WaitingManager.Instance.AddNewVacantSeat(transform);
    }
}
