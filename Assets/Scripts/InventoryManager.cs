using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    
    Dictionary<Pizza.PizzaType, List<string>> ingredientList = new Dictionary<Pizza.PizzaType, List<string>>();
    Dictionary<string, int> inventory = new Dictionary<string, int>();

    void initiateInventory()
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
        
        
        inventory.Add("dough", 100);
        inventory.Add("sauce", 100);
        inventory.Add("cheese", 100);
        inventory.Add("pepperoni", 100);
        inventory.Add("veggies", 100);
        inventory.Add("bacon", 100);
        inventory.Add("meatballs", 100);
        inventory.Add("sausage", 100);



    }
}
//"dough",
//        "sauce",
//        "cheese",
//        "pepperoni",
//        "bacon",
//        "veggies"