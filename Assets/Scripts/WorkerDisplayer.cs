using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Runtime.ExceptionServices;
using System;

public class WorkerDisplayer : MonoBehaviour
{
    TextMeshProUGUI uGUI;

    void Awake() {
        uGUI = GetComponent<TextMeshProUGUI>();
    }

    void Update() {
        DisplayFunds();
    }

    void DisplayFunds() {
        uGUI.text = "Workers: -$" + (GameManager.Instance.workers * 25).ToString();
    }
}
