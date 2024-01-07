using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UIElements;

public class Order
{
    static int current_id = 1;
    public int id;
    public List<Pizza> pizzas = new List<Pizza>();
    public float cookTimeRemaining;
    public float cost;
    public Order()
    {
        id = current_id;
        current_id++;

        int pizzaCount = Random.Range(1, 6);
        for (int i = 0; i < pizzaCount; i++)
        {
            Pizza.PizzaType randomType = (Pizza.PizzaType)Random.Range(0,Pizza.unlockedPizza);
            pizzas.Add(new Pizza(randomType));
            cookTimeRemaining += pizzas[i].CookingTime;
            cost += pizzas[i].Price;
            
            InventoryManager.Instance.UseIngredients(randomType);
        }
        cookTimeRemaining -= 0.05f * cookTimeRemaining * GameManager.Instance.workers;
    }
}
