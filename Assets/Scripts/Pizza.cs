using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pizza 
    { 

    public enum PizzaType
    {
        BaconPepperoni,
        Cheese,
        MeatLovers,
        Pepperoni,
        Veggie,
        Supreme,
        Works
    } 
    public PizzaType type { get; private set; }
    public float CookingTime
    {
        get
        {
            switch (type    )  
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
                case PizzaType.BaconPepperoni: return 21.0f;
                case PizzaType.Cheese: return 14.0f;
                case PizzaType.MeatLovers: return 23.0f;
                case PizzaType.Pepperoni: return 19.0f;
                case PizzaType.Veggie: return 15.0f;
                case PizzaType.Supreme: return 25.0f;
                case PizzaType.Works: return 27.0f;
                default: return 5.0f;



            }
        }
    }
    public Pizza(PizzaType type)
    {
        this.type = type;
    }
}