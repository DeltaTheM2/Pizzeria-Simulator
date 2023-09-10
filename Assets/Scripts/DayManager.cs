using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayManager : MonoBehaviour
{
    public int day = 1;
    int customerCount = 0;
    public int minAmountCustomers, maxAmountCustomers;
    public int minWaitDuration, maxWaitDuration;
    public GameObject customerPrefab;
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
            print("Day Over");
            GameManager.Instance.SwitchToUpgrade();
        }
    }

    public void OnDayOver() {
        day++;
        print("Day Over");
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

    IEnumerator InstantiateCustomer()
    {
        //get a random duration
        //this is [minWaitDuration, maxWaitDuration)
        yield return new WaitForSeconds(Random.Range(minWaitDuration, maxWaitDuration));

        Instantiate(customerPrefab, spawnPoint.position, Quaternion.identity);
    }
}
