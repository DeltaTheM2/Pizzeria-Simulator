using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayManager : MonoBehaviour
{
    public int day = 0;
    int customerCount = 0;
    public int minAmountCustomers, maxAmountCustomers;
    public int minWaitDuration, maxWaitDuration;
    public GameObject[] customerPrefabs;
    public Transform spawnPoint;

    private static DayManager _instance;
    public static DayManager Instance { get { return _instance; } }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        } else {
            _instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
    }

    private void Start()
    {
        StartDay();
    }

    public void OnCustomerCompleted(CustomerMovement c) {
        customerCount--;
        if (customerCount <= 0) {
            GameManager.Instance.OnDayOver();
        }
    }

    public void StartDay()
    {
        //get a random number of customers that will be visiting today
        //this is [minAmountCustomers, maxAmountCustomers)
        customerCount = Random.Range(minAmountCustomers, maxAmountCustomers);

        //spawn n customers. This will add their Customer component to our list.
        for (int i = 0; i < customerCount; i++)
        {
            StartCoroutine(InstantiateCustomer());
        }
    }

    public void OnAfterFirstDay() {
        day++;
        minAmountCustomers += Random.Range(1,3);
        maxAmountCustomers += Random.Range(2,3);
    }

    IEnumerator InstantiateCustomer()
    {
        //get a random duration
        //this is [minWaitDuration, maxWaitDuration)
        yield return new WaitForSeconds(Random.Range(minWaitDuration, maxWaitDuration));

        GameObject customerPrefab = customerPrefabs[Random.Range(0, customerPrefabs.Length-1)];
        Instantiate(customerPrefab, spawnPoint.position, Quaternion.identity);
    }
}
