using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
/*
 * once you press a button to begin a day the StartDay() will be called and a day will be started.
 * in this function a new list of customers should be made. 
 * the Customers then wikll be spawned in different times during the day that are random, and then when they spawn they will
 * have to move towards the counter. when They get to the counter they will need to order.
 * after they place their order, they will move towards another place or sit down and just wait there till their order is ready.
 * after it's ready, they will walk to the counter, pay the money and walk out of the restaurant
 * I plan to use lists of triggers for the places that the customers can wait, sit and walk to ensure that they do not go in each other. 
 */
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

    public Transform OrderContent;
    public GameObject orderTextPrefab;

    public List<GameObject> CustomerPrefabs = new List<GameObject>();


    private void Start()
    {
        equipment = new Equipment();
        customers = new List<Customer>();
        Day = 1;
        timeLeft = 8f;
        isWorkHour = true;
        StartDay();
    }
    public void UpdateOrderUI(Customer _customer)
    {
        TextMeshProUGUI orderText = Instantiate(orderTextPrefab, OrderContent).GetComponent<TextMeshProUGUI>();
        orderText.text = $"{_customer.order}: {_customer.order.CalculateTotalCookingTime()}s";
    }
    public void StartDay()
    {
        totalRevenue = 0;
        customers.Clear();
        customers.Add(CustomerPrefabs[Random.Range(0, CustomerPrefabs.Count - 1)].GetComponent<Customer>());
        foreach(Customer c in customers)
        {
            //Instantiate the customers one at a time
            //Instantiate(c);
        }

    }
    public void ProcessOrder(Customer customer)
    {
        float orderRevenue = customer.order.CalculateTotalPrice();
        totalRevenue += orderRevenue;
        foreach (Customer _customer in customers) {
        customer.UpdateWaitTime(Time.deltaTime);
        }
    }
    public void EndDay()
    {
        totalRevenue -= totalCosts;
        //Add other tasks afterwards.
    }
}
