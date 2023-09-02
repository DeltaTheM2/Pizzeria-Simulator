using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Customer
{
    public Order order;
    public float waitTime { get; private set; }
    public float waitTimeThreshold { get; private set; }


    public bool isServed { get; private set; } = false;
    public bool hasLeft { get; private set; } = false;


    private void Start()
    {
        order.StartOrder();
        order.CalculateTotalPrice();
        order.CalculateTotalCookingTime();

    }
    public Customer()
    {
        waitTimeThreshold = Random.Range(10.0f, 20.0f);
    }

    public void UpdateWaitTime(float deltaTime)
    {
        if (isServed || hasLeft) return;

        waitTime += deltaTime;

        if(waitTime >= waitTimeThreshold)
        {
            LeaveWithoutOrder();
        }
    }

    public void ServeOrder()
    {
        isServed = true;
    }
    private void LeaveWithoutOrder()
    {
        hasLeft = true;
    }
}