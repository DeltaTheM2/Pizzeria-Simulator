using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equipment 
{
    // BaconPepperoni,
    //   Cheese,
    // MeatLovers,
    //   Pepperoni,
    //   Veggie,
    //   Supreme,
    //   Works
    private float ovenQuality;
    public float upgradeMultiplier = 1.2f;

    public int upgradeLevel { get; private set; } = 0;

    public Equipment()
    {
        ovenQuality = 1.0f;
        upgradeMultiplier = 1.2f;
    }
    
    public float GetCookingTimeMultiplier(Pizza.PizzaType pizzaType)
    {
        switch (pizzaType)                                                                           


        {
            case Pizza.PizzaType.BaconPepperoni:
                return ovenQuality;
            case Pizza.PizzaType.Cheese:
                return ovenQuality;
            case Pizza.PizzaType.MeatLovers:
                return ovenQuality;
            case Pizza.PizzaType.Pepperoni: 
                return ovenQuality;
            case Pizza.PizzaType.Veggie:
                return ovenQuality;
            case Pizza.PizzaType.Supreme:
                return ovenQuality;
            case Pizza.PizzaType.Works:
                return ovenQuality;
            default:
                return ovenQuality;                                                                                                               
        }

    }

    public void UpgradeOven()
    {
     upgradeMultiplier *= 0.3f;
    }
}




