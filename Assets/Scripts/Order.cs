using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Order
{
    public List<Pizza> pizzas { get; private set; } = new List<Pizza>();

    public Order()
    {
        int pizzaCount = Random.Range(1, 6);
        for (int i = 0; i < pizzaCount; i++)
        {
            Pizza.PizzaType randomType = (Pizza.PizzaType)Random.Range(0, System.Enum.GetValues(typeof(Pizza.PizzaType)).Length);
            pizzas.Add(new Pizza(randomType));
        }
    }

    public float CalculateTotalCookingTime(Equipment equipment)
    {
        float totalCookingTime = 0;
        foreach (Pizza pizza in pizzas)
        {
            totalCookingTime += pizza.CookingTime * equipment.GetCookingTimeMultiplier();
        }
        return totalCookingTime;
    }
    public float CalculateTotalPrice()
    {
        float totalPrice = 0;
        foreach (Pizza pizza in pizzas)
        {
            totalPrice += pizza.Price;
        }
        return totalPrice;
    }
}