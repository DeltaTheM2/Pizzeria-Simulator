using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProductManager : MonoBehaviour
{
    public string productName;
    public string ingredients;
    public float price;
    public float TimeToMake;
    public List<Product> products;

    public bool isMade;

    public void MakePizza()
    {
        if(isMade)
        {
            StartCoroutine(Bake());
        }
    }

    private IEnumerator Bake()
        {
        yield return new WaitForSeconds(TimeToMake);

        print("the italian bread is done");
    }
}

