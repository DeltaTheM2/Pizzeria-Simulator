using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customer
{
    public Order order { get; private set; }
    public float waitTime { get; private set; }
    public float waitTimeThreshold { get; private set; }


    public bool isServed { get; private set; } = false;
    public bool hasLeft { get; private set; } = false;

    public Customer()
        {
        order = new Order();
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