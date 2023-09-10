using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Runtime.ExceptionServices;
using System;

public class OrderDisplayer : MonoBehaviour
{
    TextMeshProUGUI uGUI;

    void Awake() {
        uGUI = GetComponent<TextMeshProUGUI>();
    }

    void Update() {
        DisplayOrders();
    }

    void DisplayOrders() {
        uGUI.text = "";
        foreach (KeyValuePair<CustomerMovement, Order> order in OrderManager.Instance.orders) {
            String orderString = "Order #" + order.Value.id + ":\n";
            orderString += "Progress: " + order.Value.cookTimeRemaining + "\n";
            foreach (Pizza p in order.Value.pizzas) {
                orderString += "\t" + p.ToString() + "\n";
            }
            uGUI.text += orderString;
        }
    }
}
