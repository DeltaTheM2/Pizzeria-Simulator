using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Cryptography;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    //Type of Pizza and their ingredients
    Dictionary<Pizza.PizzaType, List<string>> ingredientList = new Dictionary<Pizza.PizzaType, List<string>>();
    //the amount of each item in the inventory
    public Dictionary<string, int> inventory = new Dictionary<string, int>();
    private static InventoryManager _instance;
    public static InventoryManager Instance { get { return _instance; } }
    public GameObject ingredientPrefab;
    public GameObject ingredientGrid;
    public GameObject deliveryTruck;
    public List<GameObject> ingredients;
    public bool hasOrder = false;

    private void Awake()
    {
        deliveryTruck.SetActive(false);
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
        
        
        inventory.Add("dough", 100);
        inventory.Add("sauce", 100);
        inventory.Add("cheese", 100);
        inventory.Add("pepperoni", 100);
        inventory.Add("veggies", 100);
        inventory.Add("bacon", 100);
        inventory.Add("meatballs", 100);
        inventory.Add("sausage", 100);
        foreach(string key in inventory.Keys)
        {
            GameObject ingredient = Instantiate(ingredientPrefab, ingredientGrid.transform);
            ingredient.transform.Find("Title").GetComponent<TextMeshProUGUI>().text = key;
            ingredient.transform.Find("Amount").GetComponent<Slider>().value = inventory[key];
            ingredient.transform.Find("Restock").GetComponent<Button>().onClick.AddListener(() => 
            {
                RestockIngredient(key);
                hasOrder = true;
                
            });
            ingredients.Add(ingredient);

        }



    }
    public void UseIngredients(Pizza.PizzaType pizzaType)
    {
        inventory["dough"]-= 5;
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
    public void RestockIngredient(string ingredientName)
    {
        int difference = 100 - inventory[ingredientName];
        if(FundManager.Instance.funds > difference * 2)
        {
            FundManager.Instance.funds -= difference * 2;
            inventory[ingredientName] = 100;
            UpdateSliders();
        }

    }
    void UpdateSliders()
    {
        foreach(GameObject ing in ingredients)
        {
            ing.transform.Find("Amount").GetComponent<Slider>().value = inventory[ing.transform.Find("Title").GetComponent<TextMeshProUGUI>().text];
        }
    }
}
//"dough",
//        "sauce",
//        "cheese",
//        "pepperoni",
//        "bacon",
//        "veggies"