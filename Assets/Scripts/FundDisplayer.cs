using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Runtime.ExceptionServices;
using System;

public class FundDisplayer : MonoBehaviour
{
    TextMeshProUGUI uGUI;

    void Awake() {
        uGUI = GetComponent<TextMeshProUGUI>();
    }

    void Update() {
        DisplayFunds();
    }

    void DisplayFunds() {
        uGUI.text = "Money: $" + FundManager.Instance.funds.ToString();
    }
}
