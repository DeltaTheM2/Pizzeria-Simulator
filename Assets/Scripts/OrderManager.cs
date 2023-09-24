using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class OrderManager : MonoBehaviour
{
    public Transform pickUpSpot;
    public Transform exitSpot;
    public int minOrderingDuration, maxOrderingDuration;
    public Dictionary<CustomerMovement, Order> orders = new Dictionary<CustomerMovement, Order>();

    private static OrderManager _instance;
    public static OrderManager Instance { get { return _instance; } }
    public Animator cashier;

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        } else {
            _instance = this;
        }

        GenerateOrder();
    }

    public List<Pizza> GenerateOrder()
    {
        int pizzaCount = Random.Range(1, 6);

        List<Pizza> order = new List<Pizza>();
        for (int i = 0; i < pizzaCount; i++)
        {
            Pizza.PizzaType randomType = (Pizza.PizzaType)Random.Range(0, System.Enum.GetValues(typeof(Pizza.PizzaType)).Length);
            order.Add(new Pizza(randomType));
        }

        return order;
    }

    public void TakeOrder() {
        StartCoroutine(OrderProcess());
    }

    IEnumerator OrderProcess() {
        CustomerMovement customer = LineManager.Instance.customerPositions.Peek();
        
        //wait until a seat is available
        while (!WaitingManager.Instance.VacantSeatAvailable()) {
            yield return null;
        }
        cashier.SetBool("isTalking", true);
        //we can just make up an order, the customer does not need to maintain its own order
        Order o = new Order();
        orders.Add(customer, o);
        FundManager.Instance.funds += o.cost;
        StartCoroutine(CookOrder(customer, o)); //runs in background; no yield

        //get a random duration
        //this is [minOrderingDuration, maxOrderingDuration)
        yield return new WaitForSeconds(Random.Range(minOrderingDuration, maxOrderingDuration));

        //dequeue the line
        LineManager.Instance.DequeueCustomer();
        cashier.SetBool("isTalking", false);
    }

    IEnumerator CookOrder(CustomerMovement c, Order order) {
        while (order.cookTimeRemaining > 0)
        {
            yield return null; //wait a frame
            order.cookTimeRemaining -= Time.deltaTime;
        }
        orders.Remove(c);
        
        c.NotifyOrderCompleted();
    }
}
