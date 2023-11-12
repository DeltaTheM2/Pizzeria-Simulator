using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pizza 
    {
    public static int unlockedPizza = 3;
    public enum PizzaType
    {
     
        Cheese,
        Pepperoni,
        Veggie,
        BaconPepperoni,
        MeatLovers,
        Supreme,
        Works
    } 
    public PizzaType type { get; private set; }
    public float CookingTime
    {
        get
        {
            switch (type)  
            {
                case PizzaType.BaconPepperoni: return 7.0f;
                case PizzaType.Cheese: return 5.0f;
                case PizzaType.MeatLovers: return 8.0f;
                case PizzaType.Pepperoni: return 7.0f;
                case PizzaType.Veggie: return 6.0f;
                case PizzaType.Supreme: return 8.0f;
                case PizzaType.Works: return 10.0f;
                default: return 5.0f;
            }
        }    
    }
    public float Price
    {
        get
        {
            switch (type)
            {
                case PizzaType.BaconPepperoni: return 15.0f;
                case PizzaType.Cheese: return 11.0f;
                case PizzaType.MeatLovers: return 16.0f;
                case PizzaType.Pepperoni: return 16.0f;
                case PizzaType.Veggie: return 14.0f;
                case PizzaType.Supreme: return 17.0f;
                case PizzaType.Works: return 20.0f;
                default: return 5.0f;
            }
        }
    }
    public Pizza(PizzaType type)
    {
        this.type = type;
    }

    public override String ToString() {
        switch (type)
        {
            case PizzaType.BaconPepperoni: return "Bacon Pepperoni";
            case PizzaType.Cheese: return "Cheese";
            case PizzaType.MeatLovers: return "Meat Lovers";
            case PizzaType.Pepperoni: return "Pepperoni";
            case PizzaType.Veggie: return "Veggie";
            case PizzaType.Supreme: return "Supreme";
            case PizzaType.Works: return "Works";
            default: return "Normal";
        }
    }
}