using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DayDisplayer : MonoBehaviour
{
    TextMeshProUGUI uGUI;

    void Awake() {
        uGUI = GetComponent<TextMeshProUGUI>();
    }

    void Update() {
        DisplayDay();
    }

    void DisplayDay() {
        uGUI.text = "Day: " + DayManager.Instance.day.ToString();
    }
}