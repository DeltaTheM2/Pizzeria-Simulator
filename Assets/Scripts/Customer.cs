using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Customer : MonoBehaviour
{
    public Order order;

    // wait time for the order to get ready
    public float waitTime;
    public float waitTimeThreshold; 

    public float placingOrderTime = 0f;
    public float maxOrderTime = 5f; // Time in seconds to place order
    public Transform seatingNode = null;


    public bool isServed = false;
    public bool hasLeft = false;

    public enum State
    {
        Entering,
        Walking,
        Sitting,
        Waiting,
        placingOrder,
        pickingUp,
        Exiting
    }
    public State state;


    public float speed = 3.0f;
    public int currentNodeIndex = 0;

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

    public void MoveTowards(Transform target)
    {
        Vector3 direction = (target.position - transform.position).normalized;
        transform.position += direction * speed * Time.deltaTime;
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