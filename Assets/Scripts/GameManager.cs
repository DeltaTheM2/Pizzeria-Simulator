using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<Customer> customers { get; private set; }
    public float totalRevenue { get; private set; }
    public float totalCosts { get; set; } = 50.00f;
    public float profit => totalRevenue - totalCosts;

    public Equipment equipment{ get; set; }


    public int Day;
    public float timeLeft, timeOfDay;
    public bool isWorkHour;
    public Player player;
    public float dayIncome, dayRevenue;


    private void Start()
    {
        customers = new List<Customer>();
        Day = 1;
        timeLeft = 8f;
        isWorkHour = true;
        StartDay();
    }
    private void Update()
    {
       
    }
    public void StartDay()
    {
       totalRevenue = 0;
        customers.Clear();
    }
    public void ProcessOrder(Customer customer)
    {
        float orderRevenue = customer.order.CalculateTotalPrice();
        totalRevenue += orderRevenue;
        foreach (Customer _customer in customers) {
            _customer.UpdateWaitTime(Time.deltaTime);
        }
    }
    public void EndDay()
    {
        totalRevenue -= totalCosts;
        //Add other tasks afterwards.
    }
}
