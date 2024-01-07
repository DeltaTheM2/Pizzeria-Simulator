using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Cryptography;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    //Type of Pizza and their ingredients
    Dictionary<Pizza.PizzaType, List<string>> ingredientList = new Dictionary<Pizza.PizzaType, List<string>>();
    //the amount of each item in the inventory
    Dictionary<string, int> inventory = new Dictionary<string, int>();
    private static InventoryManager _instance;
    public static InventoryManager Instance { get { return _instance; } }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }
    public void initiateInventory()
    {
        ingredientList.Add(Pizza.PizzaType.Cheese, new List<string>()
        { "dough",
          "cheese",
          "sauce"
        });
        ingredientList.Add(Pizza.PizzaType.Veggie, new List<string>()
        { "dough",
          "cheese",
          "sauce",
          "veggies"
        });
        ingredientList.Add(Pizza.PizzaType.Pepperoni, new List<string>()
        { "dough",
          "cheese",
          "sauce",
          "pepperoni"
        });
        ingredientList.Add(Pizza.PizzaType.BaconPepperoni, new List<string>()
        { "dough",
          "cheese",
          "sauce",
          "pepperoni",
          "bacon"
        });
        ingredientList.Add(Pizza.PizzaType.Works, new List<string>()
        { "dough",
          "cheese",
          "sauce",
          "pepperoni",
          "bacon",
          "veggies"
        });
        ingredientList.Add(Pizza.PizzaType.MeatLovers, new List<string>()
        { "dough",
          "cheese",
          "sauce",
          "pepperoni",
          "bacon",
          "sausage",
          "meatballs"
        });
        ingredientList.Add(Pizza.PizzaType.Supreme, new List<string>()
        { "dough",
          "cheese",
          "sauce",
          "pepperoni",
          "bacon",
          "sausage",
          "veggies"
        });
        
        
        inventory.Add("dough", 25);
        inventory.Add("sauce", 100);
        inventory.Add("cheese", 100);
        inventory.Add("pepperoni", 100);
        inventory.Add("veggies", 100);
        inventory.Add("bacon", 100);
        inventory.Add("meatballs", 100);
        inventory.Add("sausage", 100);



    }
    public void UseIngredients(Pizza.PizzaType pizzaType)
    {
        inventory["dough"]--;
        inventory["cheese"] -= 5;
        inventory["sauce"] -= 5;
        switch (pizzaType)
        {
            case Pizza.PizzaType.Cheese:
                
                break;
            case Pizza.PizzaType.Veggie:
                inventory["veggies"] -= 10;
                break;
            case Pizza.PizzaType.Pepperoni:
                inventory["pepperoni"] -= 5;
                break;
            case Pizza.PizzaType.BaconPepperoni:
                inventory["pepperoni"] -= 5;
                inventory["bacon"] -= 5;
                break;
            case Pizza.PizzaType.MeatLovers:
                inventory["pepperoni"] -= 5;
                inventory["meatballs"] -= 5;
                inventory["sausage"] -= 5;
                break;
            case Pizza.PizzaType.Supreme:
                inventory["veggie"] -= 10;
                inventory["pepperoni"] -= 5;
                inventory["sausage"] -= 5;
                inventory["bacon"] -= 5;
                break;
            case Pizza.PizzaType.Works:
                inventory["pepperoni"] -= 10;
                inventory["bacon"] -= 10;
                inventory["veggies"] -= 10;
                break;

        }
        foreach(string key in inventory.Keys)
        {
            Debug.Log(key + " " + inventory[key]);
        }
    }
}
//"dough",
//        "sauce",
//        "cheese",
//        "pepperoni",
//        "bacon",
//        "veggies"